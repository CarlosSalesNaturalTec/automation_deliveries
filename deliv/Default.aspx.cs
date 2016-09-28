using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace deliv
{
    public partial class _Default : Page
    {
        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inputUser.Focus();
            }
        }

        protected void bt_conectar_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = Request.Form["txtlat"];
            lbl_msg2.Text = Request.Form["txtlng"];
        }

    }
}