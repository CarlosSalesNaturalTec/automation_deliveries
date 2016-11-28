using System;

namespace delivcli
{
    public partial class Mapa : System.Web.UI.Page
    {
        string v_id_user = "0"; // Id do cliente
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // tenta identificar se houve login. caso contrário vai para página de erro
            v_id_user = Session["Cli_ID"].ToString();
        }

        protected void BtAtivos_Click(object sender, EventArgs e)
        {
            Session["LocTipo"] = "On-Line";
        }

        protected void BtInativos_Click(object sender, EventArgs e)
        {
            Session["LocTipo"] = "Off-Line";
        }

        protected void BtTodos_Click(object sender, EventArgs e)
        {
            Session["LocTipo"] = "Todos";
        }

    }

}