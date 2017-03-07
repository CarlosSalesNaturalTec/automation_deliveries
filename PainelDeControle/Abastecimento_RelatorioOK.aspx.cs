using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_RelatorioOK : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string placa = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            placa = Request.QueryString["p1"];
            Literal_Placa.Text = "Placa : " + placa;

            montaCabecalho();
            dadosCorpo();
            montaRodape();

            Literal_Dados.Text = str.ToString();
        }
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>DATA</th>" +
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
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        String stringselect = "select format(DataAutoriza,'dd/MM/yyyy') as DataOper," +
                " Nome, Kilometragem, Valor, LTGasolina" +
                " from Tbl_Abastecimentos" +
                " where Placa = '"  +  placa + "'" +
                " order by DataAutoriza ";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        int distAnterior = 0;
        int dist = 0;

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]);    //data
            string Coluna1 = Convert.ToString(dados[1]);    //motorista
            string Coluna2 = Convert.ToString(dados[2]);    //Kilometragem
            string Coluna3 = "";                            //distancia
            decimal Coluna4 = Convert.ToDecimal(dados[3]);    //valor
            string Coluna5 = Convert.ToString(dados[4]);    //valor do litro
            string Coluna6 = "";                            //quant de litros
            string Coluna7 = "";                            //indice KM/LT

            if (distAnterior == 0) {distAnterior = Convert.ToInt32(Coluna2);}
            dist = Convert.ToInt32(Coluna2) - distAnterior;
            distAnterior = Convert.ToInt32(Coluna2);

            Coluna3 = dist.ToString(); //distancia desde o ultimo abastecimento

            string coluna4f = Coluna4.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            //quant de litros
            decimal quantLitros = Convert.ToDecimal(Coluna4) / Convert.ToDecimal(Coluna5);
            Coluna6 = quantLitros.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            //indice KM/LT
            decimal kmLT = Convert.ToDecimal(Coluna3) / quantLitros;
            Coluna7 = kmLT.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + " (" + Convert.ToDateTime(dados[0]).ToString("ddd", new CultureInfo("pt-BR")) + ")</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna2 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna3 + "</td>" +
                "<td style=\"text-align:right\">" + coluna4f + "</td>" +
                "<td style=\"text-align:right\">" + Coluna5 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna6 + "</td>" +
                "<td style=\"text-align:right\">" + Coluna7 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();
        

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }

    private string DiaDaSemana(string dia)
    {
        string diaSemana = "xx";

        switch (dia)
        {
            case "0" :
                diaSemana = "Domingo";
                break;
            case "1":
                diaSemana = "Segunda";
                break;
            case "2":
                diaSemana = "Terça";
                break;
            case "3":
                diaSemana = "Quarta";
                break;
            case "4":
                diaSemana = "Quinta";
                break;
            case "5":
                diaSemana = "Sexta";
                break;
            case "7":
                diaSemana = "Sábado";
                break;
            default:
                break;
        }


        return diaSemana;
    }
}