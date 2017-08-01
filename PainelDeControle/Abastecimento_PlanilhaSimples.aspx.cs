using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_PlanilhaSimples : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string tipoRel = "", per1 = "", per2 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Tipo de Relatório:  1=Completo   2=Esta Semana  3=Este Mes    4=Especifico
            tipoRel = Request.QueryString["p1"];
           
            switch (tipoRel)
            {
                case "1":
                    //completo
                    per1 = "";
                    per2 = "";
                    lblPer.Text = "COMPLETO";
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
                    lblPer.Text = "ESTA SEMANA";
                    break;

                case "3":
                    //este mês
                    int d1 = DateTime.Today.Day - 1;
                    DateTime d2 = DateTime.Today.AddDays(-d1);

                    per1 = d2.ToString("yyyy-MM-dd");
                    per2 = DateTime.Today.ToString("yyyy-MM-dd");
                    lblPer.Text = "ESTE MÊS";
                    break;

                case "4":
                    //especifico
                    per1 = Request.QueryString["p2"];
                    per2 = Request.QueryString["p3"];

                    var per3 = Convert.ToDateTime(per1).ToString("dd/MM/yyyy");
                    var per4 = Convert.ToDateTime(per2).ToString("dd/MM/yyyy");

                    lblPer.Text = per3 + " à " + per4;
                    break;
            }

            LimpaTabela();
            InsereDebitos();
            InsereCreditos();

            montaCabecalho();
            dadosCorpo();
            montaRodape();

            Literal1.Text = str.ToString();
        }
    }

    private void LimpaTabela()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("DELETE FROM Tbl_Abastecimento_Planilha");
    }

    private void InsereDebitos()
    {
        string filtroPer;

        if (tipoRel == "1") {
            filtroPer = "";
        } else
        {
            filtroPer = "where format(Tbl_Abastecimentos.DataAutoriza,'yyyy-MM-dd') >='" + per1 + "' and " +
                "format(Tbl_Abastecimentos.DataAutoriza,'yyyy-MM-dd') <='" + per2 + "'";
        }

        OperacaoBanco operacao = new OperacaoBanco();
        string stringinsert = @"INSERT INTO Tbl_Abastecimento_Planilha (DataOperacao,Valor,Motorista ,Placa ,Kilometragem ,  Evento )
                            SELECT DataAutoriza, Valor,Nome , Placa, Kilometragem, 'ABASTECIMENTO'
                            FROM Tbl_Abastecimentos " + filtroPer ;
        Boolean inserir = operacao.Insert(stringinsert);
    }

    private void InsereCreditos()
    {
        string filtroPer;

        if (tipoRel == "1")
        {
            filtroPer = "";
        }
        else
        {
            filtroPer = "where format(Tbl_Abastecimentos_Creditos.DataCredito,'yyyy-MM-dd') >='" + per1 + "' and " +
                "format(Tbl_Abastecimentos_Creditos.DataCredito,'yyyy-MM-dd') <='" + per2 + "'";
        }

        OperacaoBanco operacao = new OperacaoBanco();
        string stringinsert = @"INSERT INTO Tbl_Abastecimento_Planilha (DataOperacao,Valor,Evento )
                            SELECT DataCredito , Valor, 'DEPOSITO'
                            FROM Tbl_Abastecimentos_Creditos " + filtroPer ;
        Boolean inserir = operacao.Insert(stringinsert);
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
            "<thead>" +
            "<tr>" +
            "<th>ORDEM</th>" +
            "<th>DATA</th>" +
            "<th>HORÁRIO</th>" +
            "<th>MOTORISTA</th>" +
            "<th>PLACA</th>" +
            "<th>KM</th>" +
            "<th style=\"text-align:right\">VALOR</th>" +
            "<th style=\"text-align:right\">SALDO</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = "select format(DataOperacao ,'dd/MM/yyyy') as DataOper, format(DataOperacao ,'HH:mm:ss') as HoraOper," +
                " Evento , Motorista , Placa , Kilometragem , Valor " +
                " from Tbl_Abastecimento_Planilha" +
                " order by DataOperacao";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        decimal saldo = 0, totalCR = 0, TotalDB = 0;
        int ordem = 1;

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(ordem);     //ordem
            string Coluna1 = Convert.ToString(dados[0]);  //data
            string Coluna2 = Convert.ToString(dados[1]);  //horario
            string Coluna3 = Convert.ToString(dados[2]);  //evento
            string Coluna4 = Convert.ToString(dados[3]);  //motorista
            string Coluna5 = Convert.ToString(dados[4]);  //placa
            string Coluna6 = Convert.ToString(dados[5]);  //Km
            string valorSTR = Convert.ToString(dados[6]); //valor - auxiliar
            string Coluna7 = "";                          //valor - formatada
            string Coluna8 = "";                          //saldo - formatada
            string Coluna7Cor = "";

            decimal valor = Convert.ToDecimal(valorSTR);
            string evento = Coluna3;

            if (evento == "DEPOSITO")
            {
                saldo = saldo + valor;
                totalCR = totalCR + valor;
                Coluna7Cor = "success";
            }
            else
            {
                saldo = saldo - valor;
                TotalDB = TotalDB + valor;
                Coluna7Cor = "danger";
            }
            
            Coluna7 = "<td class=\"text-" + Coluna7Cor + "\" style=\"text-align:right\"> <strong>" + valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>";
            Coluna8 = "<td style=\"text-align:right\"> <strong>" + saldo.ToString("N",CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>";

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                Coluna7 +
                Coluna8 + 
                "</tr>";

            str.Append(stringcomaspas);
            ordem++;
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_TotalCR.Text = "R$ " + totalCR.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
        Literal_TotalDB.Text = "R$ " + TotalDB.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }


}