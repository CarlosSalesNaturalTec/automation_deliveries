using System;

namespace delivcli
{
    public partial class Registro_Simplif_Novo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDCli = Session["Cli_ID"].ToString();

            string ScriptAux = "<script type=\"text/javascript\">" +
                            "document.getElementById('IDAuxHidden').value = \"" + IDCli + "\";" +
                            "document.getElementById('input_data').value = \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\";" +
                            "</script>";
            Literal_Aux.Text = ScriptAux;
        }
    }
}