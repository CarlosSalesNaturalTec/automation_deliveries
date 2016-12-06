using System;
using System.Text;

namespace delivcli
{
    public partial class DetalhesEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // tenta identificar se houve login. caso contrário vai para página de erro
                string v_id_cli = Session["Cli_ID"].ToString();
                string IDEntrega = Request.QueryString["IDEnt"];

            }
        }
    }
}