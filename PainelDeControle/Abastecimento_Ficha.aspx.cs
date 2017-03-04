using System;
using System.Text;


public partial class Abastecimento_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PreencheCampos(Request.QueryString["IDAbast"]);
            Literal1.Text = str.ToString();
        }
    }

    private void PreencheCampos(string IDOrc)
    {
        string ScriptDados = "";
        string stringSelect = "select Placa , Nome, Valor, format(DataAutoriza,'dd/MM/yyyy') as DataAbast, modelo, Kilometragem   " +
            "from Tbl_Abastecimentos where ID_Abastecimento = " + IDOrc;

        OperacaoBanco operacaoOrc = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetORC = operacaoOrc.Select(stringSelect);
        while (rcrdsetORC.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('inputPlaca').value = \"" + Convert.ToString(rcrdsetORC[0]) + "\";" +
                "document.getElementById('inputNome').value = \"" + Convert.ToString(rcrdsetORC[1]) + "\";" +
                "document.getElementById('inputValor').value = \"" + Convert.ToString(rcrdsetORC[2]) + "\";" +
                "document.getElementById('inputData').value = \"" + Convert.ToString(rcrdsetORC[3]) + "\";" +
                "document.getElementById('inputModelo').value = \"" + Convert.ToString(rcrdsetORC[4]) + "\";" +
                "document.getElementById('inputKm').value = \"" + Convert.ToString(rcrdsetORC[5]) + "\";" +
                "document.getElementById('IDHidden').value = \"" + IDOrc + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);

    }
}