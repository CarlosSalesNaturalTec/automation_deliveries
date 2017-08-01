using System;
using System.Text;

public partial class Abastecimento_Local_Novo : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder strPlaca = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Preenche_AutoComplete();
        Numero_Controle();
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

        
        Literal_AutoComplete.Text = TagIni + TagNomes + TagPlacas + TagAutocompNome + TagAutocompPlaca + TagFim ;

    }

    private void Numero_Controle()
    {

        string stringcomaspas;
        str.Clear();

        string stringselect = "select Abast_Sequencia from Tbl_Parametros ";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        Int32 Coluna0;

        while (dados.Read())
        {
            Coluna0 = Convert.ToInt32(dados[0]);
            stringcomaspas = "<input type='number' class='form-control' id='input_talao' value=" + Coluna0 + ">";
            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_Talao.Text = str.ToString();
    }
}