using System;

public partial class Abastecimento_Local_Novo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string iduser = Session["UserID"].ToString();

        /* <!--*******Customização somente se for usar um "ID Auxiliar" para o novo registro *******-->
        string ScriptAux = "<script type=\"text/javascript\">" +
                        "document.getElementById('IDAuxHidden').value = \"" + Session["InstID"].ToString() + "\";" +
                        "</script>";        
        Literal1.Text = ScriptAux;
        */
    }
}