using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace automation_deliveries_client
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Id_Cliente();
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            // Redirect to ~/Account/SignOut after signing out.
            string callbackUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Response.ApplyAppPathModifier("~/Account/SignOut");

            HttpContext.Current.GetOwinContext().Authentication.SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        private void Id_Cliente()
        {
            //email utilizado no login
            string str1 = Context.User.Identity.Name;
            string str2 = str1.Substring(9);

            //Busca ID do cliente em banco de dados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("select ID_Cliente from tbl_clientes where email = '" + str2 + "'" );
            string str3="";
            while (dados.Read()) { str3 = Convert.ToString(dados[0]); }

            lbl_id_cliente.Text = "Usuário: " + str3 + " - " + str2;

            //armazena id em variável de seção que irá se persistir entre as janelas do browser
            Session["ID_Cliente"] = str3;
            
        }

    }
}