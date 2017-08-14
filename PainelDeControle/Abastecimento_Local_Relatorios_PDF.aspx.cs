using System;
using System.Globalization;
using System.Text;

using System.IO;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Abastecimento_Local_Relatorios_PDF : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string responsavel = "", tipoRel = "", per1 = "", per2 = "", filtro = "", filtroresponsavel = "";
    string strTabela, strAnalitSint;
    string strCabecalho, strPeriodo;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            strAnalitSint = Request.QueryString["p5"];

            montafiltros();
            TabelaHeader();
            TabelaCorpo();
            TabelaRodape();

            Cabecalho();

            MontaPDF("<html><body>" + strCabecalho + strTabela + "</body></html>");
        }
    }

    private void montafiltros()
    {

        //Tipo de Relatório:  1=Completo   2=Esta Semana  3=Este Mes    4=Especifico
        tipoRel = Request.QueryString["p1"];
        responsavel = Request.QueryString["p4"];

        if (responsavel == "TODOS")
        {
            filtroresponsavel = "";
        }
        else
        {
            filtroresponsavel = " where Nome = '" + responsavel + "'";
        }


        switch (tipoRel)
        {
            case "1":
                //completo
                filtro = filtroresponsavel;
                strPeriodo = "Periodo: TODA A BASE DE DADOS";

                break;

            case "2":
                // esta semana
                DateTime dt = DateTime.Today;
                DateTime dt1, dt2;

                var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
                if (diff < 0)
                    diff += 7;
                dt1 = dt.AddDays(-diff).Date;
                dt2 = dt1.AddDays(1);  // para adequar a brasil

                per1 = dt2.ToString("yyyy-MM-dd");
                per2 = DateTime.Today.ToString("yyyy-MM-dd");

                if (filtroresponsavel == "")
                {
                    filtroresponsavel = " where ";
                }
                else
                {
                    filtroresponsavel += " and ";
                }

                filtro = filtroresponsavel +
                    "format(Tbl_Abastecimento_Local.Data_Abastecimento,'yyyy-MM-dd') >='" + per1 + "' and " +
                    "format(Tbl_Abastecimento_Local.Data_Abastecimento,'yyyy-MM-dd') <='" + per2 + "'";

                strPeriodo = "Periodo: " + dt2.ToString("dd/MM/yyyy") + " a " + DateTime.Today.ToString("dd/MM/yyyy") ;

                break;

            case "3":
                //este mês
                int d1 = DateTime.Today.Day - 1;
                DateTime d2 = DateTime.Today.AddDays(-d1);

                per1 = d2.ToString("yyyy-MM-dd");
                per2 = DateTime.Today.ToString("yyyy-MM-dd");

                if (filtroresponsavel == "")
                {
                    filtroresponsavel = " where ";
                }
                else
                {
                    filtroresponsavel += " and ";
                }

                filtro = filtroresponsavel +
                    "format(Tbl_Abastecimento_Local.Data_Abastecimento,'yyyy-MM-dd') >='" + per1 + "' and " +
                    "format(Tbl_Abastecimento_Local.Data_Abastecimento,'yyyy-MM-dd') <='" + per2 + "'";

                strPeriodo = "Periodo: " + d2.ToString("dd/MM/yyyy") + " a " + DateTime.Today.ToString("dd/MM/yyyy");

                break;

            case "4":
                //especifico
                per1 = Request.QueryString["p2"];
                per2 = Request.QueryString["p3"];

                var per3 = Convert.ToDateTime(per1).ToString("dd/MM/yyyy");
                var per4 = Convert.ToDateTime(per2).ToString("dd/MM/yyyy");

                if (filtroresponsavel == "")
                {
                    filtroresponsavel = " where ";
                }
                else
                {
                    filtroresponsavel += " and ";
                }

                filtro = filtroresponsavel +
                    "format(Tbl_Abastecimento_Local.Data_Abastecimento,'yyyy-MM-dd') >='" + per1 + "' and " +
                    "format(Tbl_Abastecimento_Local.Data_Abastecimento,'yyyy-MM-dd') <='" + per2 + "'";

                strPeriodo = "Periodo: " + per3 + " a " + per4;


                break;
        }
    }

    private void TabelaHeader()
    {
        string stringcomaspas = "<table border='1'>" +
                "<tr>" +
                "<th><b>TIPO BONIFICAÇÃO</b></th>" +
                "<th><b>NOME</b></th>" +
                "<th align='right'><b>VALOR (R$)</b></th>" +
                "</tr>";

        str.Clear();
        str.Append(stringcomaspas);
    }

    private void TabelaCorpo()
    {
        string stringcomaspas = "";
        string stringselect = "";


        if (strAnalitSint == "SINTÉTICO")
        {
            stringselect = "select Nome, Bonificado, sum(valor) as ValorTotal " +
                "from Tbl_Abastecimento_Local " + filtro +
                "group by Nome, Bonificado";

        } else {

            stringselect = "select Nome, Bonificado, valor " +
                "from Tbl_Abastecimento_Local " + filtro +
                "order by Nome, Bonificado";
        }
        

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        string vAnt = "";
        string Coluna2f;

        while (dados.Read())
        {

            string Coluna1 = Convert.ToString(dados[0]);    //Nome     
            string Coluna2 = Convert.ToString(dados[1]);    //Tipo Bonificação        

            // não repete colunas com mesmo conteúdo
            if (Coluna2 != vAnt) { Coluna2f = Coluna2; } else { Coluna2f = ""; }
            vAnt = Coluna2;

            decimal Coluna3 = Convert.ToDecimal(dados[2]);  //valor
            string Coluna3f = Coluna3.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            stringcomaspas = "<tr>" +
                "<td>" + Coluna2f + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td align='right'>" + Coluna3f + "</td>" +
                "</tr>";
            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();
    }

    private void TabelaRodape()
    {
        string footer = "</table>";
        str.Append(footer);

        strTabela = str.ToString();
    }

    private void Cabecalho()
    {
        string strTexto;
        str.Clear();

        strTexto = "<h3><b>LOG Transportes</b></h3>";
        str.Append(strTexto);

        strTexto = "<h3><b>Relatório de Abastecimento (" + strAnalitSint + ")</b></h3>";
        str.Append(strTexto);

        strTexto = "<h4>" + strPeriodo + "</h4>";
        str.Append(strTexto);

        strTexto = "<br><br>";
        str.Append(strTexto);

        strCabecalho = str.ToString();
    }

    private void MontaPDF(string HtmlTxt)
    {

        HtmlForm form = new HtmlForm();
        Document document = new Document(PageSize.A4, 20, 20, 20, 20);
        MemoryStream ms = new MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(document, ms);
        HTMLWorker obj = new HTMLWorker(document);

        StringReader se = new StringReader(HtmlTxt);
        document.Open();
        obj.Parse(se);
        document.Close();
        Response.Clear();

        Response.AddHeader("content-disposition", "filename=RelatorioAbastecimento.pdf");  //vizualiza em tela

        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.End();

    }

    private string LogomarcaDataURI()
    {
        string logomarca = "<img src='data:image/png;base64,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' />";
        return logomarca;

    }

}