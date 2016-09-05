using System;

namespace automation_deliveries_client.Account
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                // Redirect to home page if the user is authenticated.
                Response.Redirect("~/");
            }
        }
    }
}