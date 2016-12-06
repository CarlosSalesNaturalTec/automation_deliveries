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
                Session["IDDetalhes"] = Request.QueryString["IDEnt"];
            }
        }
    }
}