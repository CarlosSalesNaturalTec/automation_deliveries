using System;
using System.Text;

public partial class Funcionarios_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Combo_Clientes();
        PreencheCampos(Request.QueryString["p1"]);
    }

    private void PreencheCampos(string idEntregador)
    {
        string ScriptDados = "";
        string stringSelect = @"select Nome, Veiculo, Modelo, Placa, Id_Cliente, Cliente, FotoDataURI " +
            "from Tbl_Motoboys " +
            "where ID_Motoboy = " + idEntregador;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + idEntregador + "\";" +
                "document.getElementById('inputNome').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('selectVeiculo').value = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('inputModelo').value = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('inputPlaca').value = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('inputIDCli').value = \"" + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('inputCliente').value = \"" + Convert.ToString(rcrdset[5]) + "\";" +
                "document.getElementById('Hidden1').value = \"" + Convert.ToString(rcrdset[6]) + "\";" +
                "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[6]) + "\"/>'; " +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();
    }

    private void Combo_Clientes()
    {
        string stringselect = "select Nome, ID_CLiente from Tbl_Clientes order by Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        str.Clear();
        string dadosCLiente;

        dadosCLiente = "<option selected disabled value=\"0\">Alterar Cliente</option>";
        str.Append(dadosCLiente);

        while (dados.Read())
        {
            dadosCLiente = "<option value=\"" + Convert.ToString(dados[1]) + "\">" + Convert.ToString(dados[0]) + "</option>";
            str.Append(dadosCLiente);
        }
        ConexaoBancoSQL.fecharConexao();
        literal_clientes.Text = str.ToString();
    }
}