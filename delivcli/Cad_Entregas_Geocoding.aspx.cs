using Newtonsoft.Json;
using System;
using System.Web.UI;

namespace delivcli
{
    public partial class Cad_Entregas_Geocoding : Page
    {
        string ID_Cli = "0";  // ID do cliente

        protected void Page_Load(object sender, EventArgs e)
        {
            // tenta identificar se houve login. caso contrário vai para página de erro
            //ID_Cli = Session["Cli_ID"].ToString();

            if (!IsPostBack)
            {

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

            }


        }
    }
       
}