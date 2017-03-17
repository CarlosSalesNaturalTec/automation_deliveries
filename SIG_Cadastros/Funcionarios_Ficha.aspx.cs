using System;
using System.Text;


public partial class Funcionarios_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        string operacao = Request.QueryString["p1"];
        if (operacao == "1")
        {
            NovoRegistro();
        }
        else
        {
            PreencheCampos(Request.QueryString["p2"]);
        }

        Literal1.Text = str.ToString();
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
                "document.getElementById('inputCli').value = \"" + Convert.ToString(rcrdset[5]) + "\";" +
                "document.getElementById('Hidden1').value = \"" + Convert.ToString(rcrdset[6]) + "\";" +
                "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[6]) + "\"/>'; " +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);
    }

    private void NovoRegistro()
    {
        string ScriptNovoReg;

        ScriptNovoReg = "<script type=\"text/javascript\">" +
                "document.getElementById('btExcluir').style.visibility = 'hidden';" +
                "document.getElementById('inputNome').focus();" +
                "</script>";
        str.Clear();
        str.Append(ScriptNovoReg);

    }


}