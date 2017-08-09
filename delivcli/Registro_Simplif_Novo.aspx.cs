using System;
using System.Text;

namespace delivcli
{
    public partial class Registro_Simplif_Novo : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            string IDCli = Session["Cli_ID"].ToString();

            dadosiniciais(IDCli);
            Preenche_AutoComplete(IDCli);

        }

        private void dadosiniciais(string ID)
        {
            string ScriptAux = "<script type=\"text/javascript\">" +
                            "document.getElementById('IDAuxHidden').value = \"" + ID + "\";" +
                            "document.getElementById('input_data').value = \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\";" +
                            "</script>";
            Literal_Aux.Text = ScriptAux;
        }

        private void Preenche_AutoComplete(string ID)
        {
            string TagIni = "", TagFim = "", TagNomes = "", TagAutocompNome = "";
            str.Clear();

            //nomes
            string stringselect = "select Nome from Tbl_Motoboys where ID_Cliente =" + ID;
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

            Literal_AutoComplete.Text = TagIni + TagNomes + TagAutocompNome +  TagFim;

        }
    }
}