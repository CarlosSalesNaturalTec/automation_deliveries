using System;
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
            "<th>EVENTO</th>" +
            "<th>MOTORISTA</th>" +
            "<th>PLACA</th>" +
            "<th>KM</th>" +
            "<th>VALOR</th>" +
            "<th>SALDO</th>" +
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

        int saldo = 0;

        while (dados.Read())
        {
            string evento = Convert.ToString(dados[2]);
            string valorSTR = Convert.ToString(dados[6]);
            int valor = Convert.ToInt16(valorSTR);

            if (evento == "DEPOSITO")
            {
                saldo = saldo + valor;
            }
            else
            {
                saldo = saldo - valor;
            }

            string Coluna1 = Convert.ToString(dados[0]);
            string Coluna2 = Convert.ToString(dados[1]);
            string Coluna3 = Convert.ToString(dados[2]);
            string Coluna4 = Convert.ToString(dados[3]);
            string Coluna5 = Convert.ToString(dados[4]);
            string Coluna6 = Convert.ToString(dados[5]);
            string Coluna7 = Convert.ToString(dados[6]);
            string Coluna8 = saldo.ToString();

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "<td>" + Coluna8 + "</td>" +
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


}