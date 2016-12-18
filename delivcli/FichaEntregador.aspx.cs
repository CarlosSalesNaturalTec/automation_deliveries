using System;
using System.Text;

namespace delivcli
{
    public partial class FichaEntregador : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               txtPer1.Text = DateTime.Today.ToString("dd/MM/yyyy");
               TxtPer2.Text = DateTime.Today.ToString("dd/MM/yyyy");
                  
               Session["per1"] = txtPer1.Text;
               Session["per2"] = TxtPer2.Text;
               Session["IDEntregador"] = Request.QueryString["ID"];
            }
        }

        
        protected void txtPer1_TextChanged(object sender, EventArgs e)
        {
            Session["per1"] = txtPer1.Text;
            Session["per2"] = TxtPer2.Text;
            Session["IDEntregador"] = Request.QueryString["ID"];
        }

        protected void TxtPer2_TextChanged(object sender, EventArgs e)
        {
            Session["per1"] = txtPer1.Text;
            Session["per2"] = TxtPer2.Text;
            Session["IDEntregador"] = Request.QueryString["ID"];
        }


    }

}