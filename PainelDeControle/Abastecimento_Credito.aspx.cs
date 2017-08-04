using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_Credito : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // data da operação
            string ScriptDados = "";      
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('inputData').value = \"" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "\";" +
                "</script>";
            Literal1.Text = ScriptDados;

            //Monta Tabela
            //======================================
            LimpaTabela();
            InsereCreditos();
            montaCabecalho();
            dadosCorpo();
            montaRodape();

        }
    }

    private void LimpaTabela()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("DELETE FROM Tbl_Abastecimento_Planilha");
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
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
            "<thead>" +
            "<tr>" +
            "<th>ORDEM</th>" +
            "<th>DATA</th>" +
            "<th>HORÁRIO</th>" +
            "<th style=\"text-align:right\">VALOR</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {

        string stringselect = "select ID_Abastecimento, format(DataOperacao ,'dd/MM/yyyy') as DataOper, format(DataOperacao ,'HH:mm:ss') as HoraOper," +
                " Valor " +
                " from Tbl_Abastecimento_Planilha" +
                " order by DataOperacao ";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        int ordem = 1;

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(ordem);
            string Coluna1 = Convert.ToString(dados[1]);  //data
            string Coluna2 = Convert.ToString(dados[2]);  //horario
            string valorSTR = Convert.ToString(dados[3]); //valor - auxiliar
            string Coluna7 = "";                          //valor - formatada

            decimal valor = Convert.ToDecimal(valorSTR);
            Coluna7 = "<td style=\"text-align:right\"> <strong>" + valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>";

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna0 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                Coluna7 +
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


}