using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_RelatorioOK : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string placa = "", tipoRel = "", per1 = "", per2 = "", filtro = "", filtroPlaca = "";
    string organizador = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Tipo de Relatório:  1=Completo   2=Esta Semana  3=Este Mes    4=Especifico
            tipoRel = Request.QueryString["p1"];
            placa = Request.QueryString["p4"];
            Literal_Placa.Text = "Placa : " + placa;

            if (placa == "TODOS")
            {
                filtroPlaca = "";
            }
            else
            {
                filtroPlaca = " where Placa = '" + placa + "'";
            }


            switch (tipoRel)
            {
                case "1":
                    //completo
                    filtro = filtroPlaca;
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

                    if (filtroPlaca == "")
                    {
                        filtroPlaca = " where ";
                    }
                    else
                    {
                        filtroPlaca += " and ";
                    }

                    filtro = filtroPlaca +
                        "format(Tbl_Abastecimentos.DataAutoriza,'yyyy-MM-dd') >='" + per1 + "' and " +
                        "format(Tbl_Abastecimentos.DataAutoriza,'yyyy-MM-dd') <='" + per2 + "'";

                    break;

                case "3":
                    //este mês
                    int d1 = DateTime.Today.Day - 1;
                    DateTime d2 = DateTime.Today.AddDays(-d1);

                    per1 = d2.ToString("yyyy-MM-dd");
                    per2 = DateTime.Today.ToString("yyyy-MM-dd");
                    lblPer.Text = "ESTE MÊS";

                    if (filtroPlaca == "")
                    {
                        filtroPlaca = " where ";
                    }
                    else
                    {
                        filtroPlaca += " and ";
                    }

                    filtro = filtroPlaca +
                        "format(Tbl_Abastecimentos.DataAutoriza,'yyyy-MM-dd') >='" + per1 + "' and " +
                        "format(Tbl_Abastecimentos.DataAutoriza,'yyyy-MM-dd') <='" + per2 + "'";

                    break;

                case "4":
                    //especifico
                    per1 = Request.QueryString["p2"];
                    per2 = Request.QueryString["p3"];

                    var per3 = Convert.ToDateTime(per1).ToString("dd/MM/yyyy");
                    var per4 = Convert.ToDateTime(per2).ToString("dd/MM/yyyy");
                    lblPer.Text = per3 + " à " + per4;

                    if (filtroPlaca == "")
                    {
                        filtroPlaca = " where ";
                    }
                    else
                    {
                        filtroPlaca += " and ";
                    }

                    filtro = filtroPlaca +
                        "format(Tbl_Abastecimentos.DataAutoriza,'yyyy-MM-dd') >='" + per1 + "' and " +
                        "format(Tbl_Abastecimentos.DataAutoriza,'yyyy-MM-dd') <='" + per2 + "'";

                    break;
            }

            montaCabecalho();
            dadosCorpo();
            montaRodape();

            Literal_Dados.Text = str.ToString();
        }
    }

    private void montaCabecalho()
    {

        string stringcomaspas = "";

        if (placa == "TODOS")
        {
            stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
                "<thead>" +
                "<tr>" +
                "<th>DATA</th>" +
                "<th>HORÁRIO</th>" +
                "<th>PLACA</th>" +
                "<th>MOTORISTA</th>" +
                "<th style=\"text-align:right\">KILOMETRAGEM</th>" +
                "<th style=\"text-align:right\">VALOR (R$)</th>" +
                "<th style=\"text-align:right\">VALOR LT.(R$)</th>" +
                "<th style=\"text-align:right\">LITROS</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";

            organizador = "placa";

        }
        else
        {
            stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
                "<thead>" +
                "<tr>" +
                "<th>DATA</th>" +
                "<th>HORÁRIO</th>" +
                "<th>MOTORISTA</th>" +
                "<th style=\"text-align:right\">KILOMETRAGEM</th>" +
                "<th style=\"text-align:right\">DIST.(KM)</th>" +
                "<th style=\"text-align:right\">VALOR (R$)</th>" +
                "<th style=\"text-align:right\">VALOR LT.(R$)</th>" +
                "<th style=\"text-align:right\">LITROS</th>" +
                "<th style=\"text-align:right\">KM/LT</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";

            organizador = "DataAutoriza";

        }


        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        String stringselect = "select format(DataAutoriza,'dd/MM/yyyy') as DataOper," +
                " Nome, Kilometragem, Valor, LTGasolina, format(DataAutoriza ,'HH:mm:ss') as HoraOper, placa" +
                " from Tbl_Abastecimentos " +
                filtro +
                " order by " + organizador;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        int distAnterior = 0;
        int dist = 0;

        decimal totalValor = 0;
        decimal totalLts = 0;

        decimal subtotal = 0;
        string placaAnt = "";

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]);    //data
            string Coluna00 = Convert.ToString(dados[5]);   //hora
            string Coluna1 = Convert.ToString(dados[1]);    //motorista
            string Coluna2 = Convert.ToString(dados[2]);    //Kilometragem
            string Coluna3 = "";                            //distancia
            decimal Coluna4 = Convert.ToDecimal(dados[3]);  //valor
            string Coluna5 = Convert.ToString(dados[4]);    //valor do litro
            string Coluna6 = "";                            //quant de litros
            string Coluna7 = "";                            //indice KM/LT
            string Coluna8 = Convert.ToString(dados[6]);    //Placa

            if (distAnterior == 0) { distAnterior = Convert.ToInt32(Coluna2); }
            dist = Convert.ToInt32(Coluna2) - distAnterior;
            distAnterior = Convert.ToInt32(Coluna2);

            Coluna3 = dist.ToString(); //distancia desde o ultimo abastecimento

            string coluna4f = Coluna4.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            //quant de litros
            decimal quantLitros;
            decimal kmLT;

            if (Convert.ToInt16(Coluna4) == 0)
            {
                quantLitros = 0;
                kmLT = 0;
            }
            else
            {
                quantLitros = Convert.ToDecimal(Coluna4) / Convert.ToDecimal(Coluna5);
                kmLT = Convert.ToDecimal(Coluna3) / quantLitros;
            }

            //totalizador de valor e Lts
            totalLts += quantLitros;
            totalValor += Coluna4;

            Coluna6 = quantLitros.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
            Coluna7 = kmLT.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            string stringcomaspas = "";

            if (Coluna8 != placaAnt)
            {
                if (placa == "TODOS")
                {
                    stringcomaspas = "<tr>" +
                    "<td>-</td>" +
                    "<td>-</td>" +
                    "<td>-</td>" +
                    "<td><strong>SUB-TOTAL PLACA: " + placaAnt + "</strong></td>" +
                    "<td style=\"text-align:right\">-</td>" +
                    "<td style=\"text-align:right\"><strong>" + subtotal.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>" +
                    "<td style=\"text-align:right\">-</td>" +
                    "<td style=\"text-align:right\">-</td>" +
                    "</tr>";
                    if (subtotal != 0 )
                    {
                        str.Append(stringcomaspas);
                    }
                    
                }
                placaAnt = Coluna8;
                subtotal = 0;
            }
            subtotal += Coluna4;

            if (placa == "TODOS")
            {
                stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + "</td>" +
                "<td>" + Coluna00 + "</td>" +
                "<td>" + Coluna8 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna2 + "</td>" +
                "<td style=\"text-align:right\">" + coluna4f + "</td>" +
                "<td style=\"text-align:right\">" + Coluna5 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna6 + "</td>" +
                "</tr>";
            }
            else
            {
                stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + "</td>" +
                "<td>" + Coluna00 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna2 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna3 + "</td>" +
                "<td style=\"text-align:right\">" + coluna4f + "</td>" +
                "<td style=\"text-align:right\">" + Coluna5 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna6 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna7 + "</td>" +
                "</tr>";
            }

            str.Append(stringcomaspas);
        }

        if (placa == "TODOS")
        {
            string stringcomaspas = "<tr>" +
            "<td>-</td>" +
            "<td>-</td>" +
            "<td>-</td>" +
            "<td><strong>SUB-TOTAL PLACA: " + placaAnt + "</strong></td>" +
            "<td style=\"text-align:right\">-</td>" +
            "<td style=\"text-align:right\"><strong>" + subtotal.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>" +
            "<td style=\"text-align:right\">-</td>" +
            "<td style=\"text-align:right\">-</td>" +
            "</tr>";
            str.Append(stringcomaspas);
        }

        ConexaoBancoSQL.fecharConexao();

        lbltotalValor.Text = "R$ " + totalValor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
        lbltotalLts.Text = totalLts.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }

}