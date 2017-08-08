using System;
using System.Text;

namespace delivcli
{
    public partial class Mapa2 : System.Web.UI.Page
    {

        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                montaScript();
                Literal1.Text = str.ToString();
            }
        }

        private void montaScript()
        {
            string Vlat, Vlng;

            try
            {
                Vlat = Session["Busca_Latitude"].ToString();
                Vlng = Session["Busca_Longitude"].ToString();
            }
            catch
            {
                Vlat = "-12.9525123";
                Vlng = "-38.4535139";
            };

            string markerPosition = "{ lat: " + Vlat + ", lng:" + Vlng + " }";
            
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

                var map;
                var marcador;
                var markers = [];

                marcador = ");

            str.Append(markerPosition);

            str.Append(@"
                function initMap() {
                    map = new google.maps.Map(document.getElementById('map'), {
                        zoom: 18,
                        mapTypeId: 'satellite',
                        center: ");

            str.Append(markerPosition);

            str.Append(@"
                    });
                    addMarkerWithTimeout(marcador, 200);
                }

                function addMarkerWithTimeout(position, timeout) {
                    window.setTimeout(function () {
                        markers.push(new google.maps.Marker({
                            position: position,
                            map: map,
                            animation: google.maps.Animation.DROP
                        }));
                    }, timeout);
                }
                </script>");
        }
    }
}