using System;
using System.Text;

namespace delivcli
{
    public partial class Mapa1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();
        string tipoMapa = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // verifica se mapa com (T)odos os funcionários ou (I)ndividual
                if (Session["CLI_ID_FUNC"].ToString() == "0") { tipoMapa = "T"; } else { tipoMapa = "I"; }

                obtemcoordenadas();
                if (tipoMapa == "T") { montaScript(); } else { montaScriptindividual(); }

                
                Literal1.Text = str.ToString();
            }
        }

        private void obtemcoordenadas()
        {
            try
            {
                string stringselect = "";

                // Motoboys e respectivas coordenadas de localização
                if (tipoMapa == "T")
                {
                    stringselect = "select usuario, GeoLatitude, GeoLongitude , GeoDataLoc from Tbl_Motoboys order by usuario";
                }else
                {
                    stringselect = "select usuario, GeoLatitude, GeoLongitude , GeoDataLoc, ID_Motoboy from Tbl_Motoboys where ID_Motoboy=" + Session["CLI_ID_FUNC"].ToString();
                }
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

                coordenadas.Clear();

                string coord = "";
                while (dados.Read())
                {
                    coord = Convert.ToString(dados[2]);
                    if (coord =="")
                    {
                    }else
                    {
                        coordenadas.Append("{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " },");
                    }
                }
                ConexaoBancoSQL.fecharConexao();
                coordenadas.Length--;  //remove ultimo caracter ","
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void montaScript()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

                   var neighborhoods = [");

            str.Append(coordenadas.ToString());

            str.Append(@"];

        var markers = [];
        var map;

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 11,
                center: { lat: -12.8730, lng: -38.3598 }
            });
            drop();
        }

        function drop() {
            clearMarkers();
            for (var i = 0; i < neighborhoods.length; i++) {
                addMarkerWithTimeout(neighborhoods[i], i * 200);
            }
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

        function clearMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
            markers = [];
        }
                </script>");
        }

        private void montaScriptindividual()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

                   var neighborhoods = [");

            str.Append(coordenadas.ToString());

            str.Append(@"];

        var markers = [];
        var map;

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 16,
                center: ");

            str.Append(coordenadas.ToString());

            str.Append(@"
            });
            drop();
        }

        function drop() {
            clearMarkers();
            for (var i = 0; i < neighborhoods.length; i++) {
                addMarkerWithTimeout(neighborhoods[i], i * 200);
            }
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

        function clearMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
            markers = [];
        }
                </script>");
        }

    }
}