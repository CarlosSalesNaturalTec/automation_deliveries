using System;
using System.Text;

namespace delivcli
{
    public partial class Registro_Simplif_Ficha1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder strPlaca = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            PreencheCampos(Request.QueryString["v1"]);

            string IDCli = Session["Cli_ID"].ToString();
            Preenche_AutoComplete(IDCli);


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
                "Motoboy," +
                "format(DataEntrega,'yyyy-MM-dd') as d1, " +
                "Quantidade , " +
                "Entregues, " +
                "Devolvidas, " +
                "Observacoes, " +
                "ID_Entrega  " +
                "from Tbl_Entrega_Simplficada " +
                "where ID_Entrega = " + ID;

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            while (rcrdset.Read())
            {
                for (int i = 0; i < 6; i++)
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

            Literal_Aux.Text = str.ToString();

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

            Literal_AutoComplete.Text = TagIni + TagNomes + TagAutocompNome + TagFim;

        }


    }
}