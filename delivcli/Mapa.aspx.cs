using System;
using System.Web.UI.WebControls;

namespace delivcli
{
    public partial class Mapa : System.Web.UI.Page
    {
        // Id do cliente
        string v_id_user = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            // tenta identificar se houve login. caso contrário vai para página de erro
            v_id_user = Session["Cli_ID"].ToString();
            try
            {
                if (!IsPostBack)
                {
                    Session["CLI_ID_FUNC"] = "0";
                    Preenche_Combo();
                }
            }
            catch { }
        }

        private void Preenche_Combo()
        {
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados1 = operacao.Select("select ID_Motoboy,Nome from Tbl_Motoboys order by Nome");
            cmb_func.DataSource = dados1;
            cmb_func.DataTextField = "Nome";
            cmb_func.DataValueField = "ID_Motoboy";
            cmb_func.DataBind();

            cmb_func.Items.Insert(0, new ListItem("Todos os Funcionarios", "-1"));
            cmb_func.SelectedIndex = Convert.ToInt32("-1");
        }

        protected void cmb_func_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_func.SelectedItem.Value == "-1")
            {
                Session["CLI_ID_FUNC"] = "0";
            }else
            {
                Session["CLI_ID_FUNC"] = cmb_func.SelectedItem.Value;
            }

        }
    }
}