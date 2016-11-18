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

            string markerPosition = "{ lat: " + Session["Busca_Latitude"].ToString() +", lng:" + Session["Busca_Longitude"].ToString() + " }";
            
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
                        zoom: 14,
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