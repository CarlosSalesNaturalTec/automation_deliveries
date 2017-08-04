using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_Planilha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Monta Tabela
            //======================================
            LimpaTabela();
            InsereDebitos();
            InsereCreditos();
            CalculaTotais();

            montaCabecalho();
            dadosCorpo();
            montaRodape();


            //============================================================================
            //graficos - Customize Aqui
            //============================================================================
            string stringDadosGraf;

            // Gasto Total por Placa
            stringDadosGraf = "select Placa, sum(valor) as ValorTotal from Tbl_Abastecimentos where Placa<>'' group by Placa ";
            Literal_Bloco1.Text = Monta_Graf_Morris_Donut(stringDadosGraf, "Bloco1_Chart");
            
            // Gasto Total por Motorista
            stringDadosGraf = "select Nome, sum(valor) as ValorTotal from Tbl_Abastecimentos where Nome<>'' group by Nome ";
            Literal_Bloco2.Text = Monta_Graf_Morris_Donut(stringDadosGraf, "Bloco2_Chart");

            //============================================================================
        }
    }

    private void LimpaTabela()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("DELETE FROM Tbl_Abastecimento_Planilha");
    }

    private void InsereDebitos()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        string stringinsert = @"INSERT INTO Tbl_Abastecimento_Planilha (DataOperacao,Valor,Motorista ,Placa ,Kilometragem ,  Evento )
                            SELECT DataAutoriza, Valor,Nome , Placa, Kilometragem, 'ABASTECIMENTO'
                            FROM Tbl_Abastecimentos";
        Boolean inserir = operacao.Insert(stringinsert);
    }

    private void InsereCreditos()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        string stringinsert = @"INSERT INTO Tbl_Abastecimento_Planilha (DataOperacao,Valor,Evento )
                            SELECT DataCredito , Valor, 'DEPOSITO'
                            FROM Tbl_Abastecimentos_Creditos;";
        Boolean inserir = operacao.Insert(stringinsert);
    }

    private void CalculaTotais()
    {
        string stringselect = "select Evento , Valor " +
                " from Tbl_Abastecimento_Planilha" +
                " order by DataOperacao";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        decimal saldo = 0;

        while (dados.Read())
        {
            string Coluna3 = Convert.ToString(dados[0]);  //evento
            string valorSTR = Convert.ToString(dados[1]); //valor - auxiliar

            decimal valor = Convert.ToDecimal(valorSTR);
            string evento = Coluna3;

            if (evento == "DEPOSITO")
            {
                saldo = saldo + valor;
            }
            else
            {
                saldo = saldo - valor;
            }
        }
        ConexaoBancoSQL.fecharConexao();

        Bloco3_Info.Text = "R$ " + saldo.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

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
       
        string stringselect = "select format(DataOperacao ,'dd/MM/yyyy') as DataOper, format(DataOperacao ,'HH:mm:ss') as HoraOper," +
                " Evento , Motorista , Placa , Kilometragem , Valor " +
                " from Tbl_Abastecimento_Planilha" +
                " order by DataOperacao ";

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
            Coluna8 = "<td style=\"text-align:right\"> <strong>" + saldo.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>";

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
    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);

        Literal_Tabela.Text = str.ToString();
    }

    private string Monta_Graf_Morris_Donut(string stringselect, string ID_Chart)
    {
        string txtAux = "";
        str.Clear();

        txtAux = "<script type=\"text/javascript\">";
        str.Append(txtAux);

        txtAux = "Morris.Donut({element: '" + ID_Chart + "', data: [";
        str.Append(txtAux);

        //dados
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            txtAux = "{label: \"" + Convert.ToString(dados[0]) + "\", value: " + Convert.ToString(dados[1]) + "},";
            str.Append(txtAux);
        }
        ConexaoBancoSQL.fecharConexao();
       
        txtAux = "]});";
        str.Append(txtAux);

        txtAux = "</script>";
        str.Append(txtAux);

        return str.ToString();

    }

}