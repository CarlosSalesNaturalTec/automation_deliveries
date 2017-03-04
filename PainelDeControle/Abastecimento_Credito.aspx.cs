using System;
using System.Globalization;

public partial class Abastecimento_Credito : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string ScriptDados = "";      
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('inputData').value = \"" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "\";" +
                "</script>";
            Literal1.Text = ScriptDados;
        }
    }
}