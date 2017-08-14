using System;
using System.Text;

public partial class Abastecimento_Local_Relatorios : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Preenche_AutoComplete();
    }

    private void Preenche_AutoComplete()
    {
        string TagIni = "", TagFim = "", TagNomes = "", TagAutocompNome = "";
        str.Clear();
        
        //nomes
        string stringselect = "select Nome from Tbl_Abastecimento_Local group by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            str.Append("\"" + Convert.ToString(dados[0]) + "\",");
        }
        ConexaoBancoSQL.fecharConexao();

        TagIni = "<script> $(function() {";

        TagNomes = "var TagsNomes = [" + str.ToString() + "];";
        TagAutocompNome = "$(\"#input1\").autocomplete({source: TagsNomes}); ";
        
        TagFim = "});</script> ";

        Literal_AutoComplete.Text = TagIni + TagNomes + TagAutocompNome + TagFim;

    }

}