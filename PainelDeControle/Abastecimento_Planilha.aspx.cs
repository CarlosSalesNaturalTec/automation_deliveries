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

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
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
        string stringselect = "select format(DataOperacao ,'dd/MM/yyyy') as DataOper, format(DataOperacao ,'hh:mm:ss') as HoraOper," +
                " Evento , Motorista , Placa , Kilometragem , Valor " +
                " from Tbl_Abastecimento_Planilha" +
                " order by DataOperacao";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        decimal saldo = 0;

        while (dados.Read())
        {

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
                Coluna7Cor = "success";
            }
            else
            {
                saldo = saldo - valor;
                Coluna7Cor = "danger";
            }
            
            Coluna7 = "<td class=\"text-" + Coluna7Cor + "\" style=\"text-align:right\"> <strong>" + valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>";
            Coluna8 = "<td style=\"text-align:right\"> <strong>" + saldo.ToString("N",CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>";

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                Coluna7 +
                Coluna8 + 
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();
        Literal_Saldo.Text = "Saldo Atual : " + saldo.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }


}