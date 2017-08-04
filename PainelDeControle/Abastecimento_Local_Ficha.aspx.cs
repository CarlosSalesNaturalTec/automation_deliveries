using System;
using System.Text;

public partial class Abastecimento_Local_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strPlaca = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        PreencheCampos(Request.QueryString["v1"]);
        Preenche_AutoComplete();

    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        str.Clear();

        ScriptDados = "<script type=\"text/javascript\">";
        str.Append(ScriptDados);
        ScriptDados = "var x = document.getElementsByClassName('form-control');";
        str.Append(ScriptDados);

        string stringSelect = "select " +
            "Nome," +
            "Placa, " +
            "format(Data_Abastecimento,'yyyy-MM-dd') as d1, " +
            "Talao, " +
            "Valor " +
            "from Tbl_Abastecimento_Local   " +
            "where ID_Abast = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            for (int i = 0; i < 5; i++)  
            {
                ScriptDados = "x[" + i + "].value = \"" + Convert.ToString(rcrdset[i]) + "\";";
                str.Append(ScriptDados);
            }

            ScriptDados = "document.getElementById('IDAuxHidden').value = \"" + ID + "\";";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        ScriptDados = "</script>";      
        str.Append(ScriptDados);

        Literal1.Text = str.ToString();

    }

    private void Preenche_AutoComplete()
    {
        string TagIni = "", TagFim = "", TagNomes = "", TagPlacas = "", TagAutocompNome = "", TagAutocompPlaca = "";
        str.Clear();
        strPlaca.Clear();

        //nomes
        string stringselect = "select Nome from Tbl_Abastecimento_Local group by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            str.Append("\"" + Convert.ToString(dados[0]) + "\",");
        }
        ConexaoBancoSQL.fecharConexao();

        //placas
        stringselect = "select Placa from Tbl_Abastecimento_Local group by Placa";
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados1 = operacao.Select(stringselect);
        while (dados1.Read())
        {
            strPlaca.Append("\"" + Convert.ToString(dados1[0]) + "\",");
        }
        ConexaoBancoSQL.fecharConexao();

        TagIni = "<script> $(function() {";

        TagNomes = "var TagsNomes = [" + str.ToString() + "];";
        TagPlacas = "var TagsPlacas = [" + strPlaca.ToString() + "];";

        TagAutocompNome = "$(\"#input1\").autocomplete({source: TagsNomes}); ";
        TagAutocompPlaca = "$(\"#input_placa\").autocomplete({source: TagsPlacas}); ";

        TagFim = "});</script> ";

        Literal_AutoComplete.Text = TagIni + TagNomes + TagPlacas + TagAutocompNome + TagAutocompPlaca + TagFim;

    }
}