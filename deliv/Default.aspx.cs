using System;
using System.Text;
using System.Web.UI;

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
            string Vid = "";

            // localiza usuario
            string stringSelect = "select ID_Motoboy, usuario , senha from Tbl_Motoboys where usuario = '" + inputUser.Text + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

            while (rcrdset.Read())
            {
                if (inputSenha.Text == Convert.ToString(rcrdset[2]))
                {
                    Vid = Convert.ToString(rcrdset[0]);
                    salvaGeoLocalizacao(Vid);  // após salvar localização, prossegue com carregamento dá página de entregas à realizar
                }
                else
                {
                    lbl_msg.Text = "USUÁRIO OU SENHA INVÁLIDOS";
                }
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private void salvaGeoLocalizacao(string idfunc)
        {
            //string update
            string stringupdate = "update Tbl_Motoboys set " +
                " GeoLatitude = '" + Request.Form["txtlat"] + "' , " +
                " GeoLongitude = '" + Request.Form["txtlng"] + "' , " +
                " GeoAccuracy = '" + Request.Form["txtacrcy"] + "' , " +
                " GeoDataLoc = '" + DateTime.Now.ToString() + "'" +
                " where ID_Motoboy = " + idfunc;

            OperacaoBanco operacao = new OperacaoBanco();
            Boolean update = operacao.Update(stringupdate);
            ConexaoBancoSQL.fecharConexao();
            if (update == true)
            {
                Session["Func_ID"] = idfunc;
                Response.Redirect("Realizar.aspx");
            }
        }
    }
}