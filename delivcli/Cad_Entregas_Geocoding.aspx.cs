using Newtonsoft.Json;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace delivcli
{
    public partial class Cad_Entregas_Geocoding : Page
    {
        string ID_Cli = "0";  // ID do cliente

        protected void Page_Load(object sender, EventArgs e)
        {
            // tenta identificar se houve login. caso contrário vai para página de erro
            ID_Cli = Session["Cli_ID"].ToString();

            if (!IsPostBack)
            {
                Session["Busca_Latitude"] = "0";
                Session["Busca_Longitude"] = "0";
                Preenche_Combo();
            }
        }

        protected void bt_buscar_click(object sender, EventArgs e)
        {
            //monta url para consulta de geolocalização
            string txtEnd = txtEndereco.Text + " " + txtNumero.Text + " " + txtBairro.Text + " " + txtCidade.Text;
            string Address = txtEnd.Replace(" ", "+");
            string AddressURL = "https://maps.googleapis.com/maps/api/geocode/json?address=" + Address + "&key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc";

            //Faz a requisição das coordenadas
            var result = new System.Net.WebClient().DownloadString(AddressURL);

            //parsing JSON
            var root = JsonConvert.DeserializeObject<RootObject>(result);
            foreach (var singleResult in root.results)
            {
                var location = singleResult.geometry.location;
                var latitude = location.lat;
                var longitude = location.lng;

                lblLat.Text = latitude.ToString();
                lblLong.Text = longitude.ToString();

                Session["Busca_Latitude"] = latitude.ToString();
                Session["Busca_Longitude"] = longitude.ToString();

            }

        }

        protected void Preenche_Combo()
        {
            // combo funcionarios - filtro
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados1 = operacao.Select(@"select ID_Motoboy, Nome from Tbl_Motoboys where " +
                "ID_Cliente=" + ID_Cli + " order by Nome");

            cmb_funcionario.DataSource = dados1;
            cmb_funcionario.DataTextField = "Nome";
            cmb_funcionario.DataValueField = "ID_Motoboy";
            cmb_funcionario.DataBind();
            ConexaoBancoSQL.fecharConexao();

            cmb_funcionario.Items.Insert(0, new ListItem("SELECIONE", "-1"));
            cmb_funcionario.SelectedIndex = Convert.ToInt32("-1");

        }

    }
       
}