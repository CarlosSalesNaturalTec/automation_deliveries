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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            montafiltros();

            TabelaHeader();
            TabelaCorpo();
            TabelaRodape();

            MontaPDF("<html><body>" + str.ToString() + "</body></html>");
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

                break;
        }
    }

    private void TabelaHeader()
    {
        string stringcomaspas = "<table>" +
                "<thead>" +
                "<tr>" +
                "<th>NOME</th>" +
                "<th>VALOR (R$)</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";

        str.Clear();
        str.Append(stringcomaspas);
    }

    private void TabelaCorpo()
    {
        string stringcomaspas = "";
       string stringselect = "select Nome, sum(valor) as ValorTotal " +
                "from Tbl_Abastecimento_Local " +
                filtro +
                "group by Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna1 = Convert.ToString(dados[0]);    //Nome
            decimal Coluna2 = Convert.ToDecimal(dados[1]);  //valor
            string Coluna2f = Coluna2.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2f + "</td>" +
                "</tr>";
            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();
    }

    private void TabelaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
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

        Response.AddHeader("content-disposition", "filename=NomedoMeuArquivo.pdf");  //vizualiza em tela

        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.End();

    }

}