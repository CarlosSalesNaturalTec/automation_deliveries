using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidaAcesso();
    }

    private void ValidaAcesso()
    {
        string vSec;
        string vValida1, vValida2;

        vSec = Request.QueryString["p1"];

        vValida1 = DateTime.Now.ToString("dd");
        vValida2 = DateTime.Now.ToString("MM");

        int vValida4 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
        string vValida5 = vValida4.ToString();

        if (vSec != vValida5)
        {
            Response.Redirect("Default.aspx");
        }

        lblUsuario.Text = Request.QueryString["p2"];
        lblUsuario2.Text = Request.QueryString["p2"];


    }
}