using System;
using System.Text;

namespace delivcli
{
    public partial class EntregadorMapa : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();
        string infoWindowEntregador = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idEntregador = Session["IDEntregador"].ToString();
                string centro = CentroDoMapa(idEntregador);

                caminhoPercorrido(idEntregador);
                montaScript(centro);
                Literal1.Text = str.ToString();
            }
        }

        private void caminhoPercorrido(string id)
        {
            coordenadas.Clear();
            string stringselect = "select Latitude, Longitude from Tbl_Historico " +
                                    "where ID_Motoboy =  " + id + " " +
                                    "and format(Data_Coleta,'dd/MM/yyyy') >='" + Session["per1"].ToString() + "' " +
                                    "and format(Data_Coleta,'dd/MM/yyyy') <='" + Session["per2"].ToString() + "' " +
                                    "order by Data_Coleta";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                coordenadas.Append("{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " },");
            }
            ConexaoBancoSQL.fecharConexao();

            //remove ultimo caracter "," 
            if (coordenadas.Length == 0) { coordenadas.Append("0"); } else { coordenadas.Length--; }
        }

        private string CentroDoMapa(string id)
        {
            string centromapa = "";
            string stringselect = "select GeoLatitude, GeoLongitude, Nome from Tbl_Motoboys where ID_Motoboy  = " + id;
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                centromapa = "{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " }";
                infoWindowEntregador = Convert.ToString(dados[2]);
            }
            return centromapa;
        }

        private void montaScript(string centroMapa)
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

            var CentroDoMapa = ");
            str.Append(centroMapa);
            str.Append(@";

            var CaminhoPercorrido = [");
            str.Append(coordenadas);
            str.Append(@"];

            var coordEntregador = ");
            str.Append(centroMapa);
            str.Append(@";

            var InfowindowEntregador = '");
            str.Append(infoWindowEntregador);
            str.Append(@"';

            var map;
            var image = 'images/motorbike24.png';
            var poly;

            function initMap() {

                map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 12,
                    center: CentroDoMapa
                });

                var flightPath = new google.maps.Polyline({
                    path: CaminhoPercorrido,
                    geodesic: true,
                    strokeColor: '#4D4DFF',
                    strokeOpacity: 0.6,
                    strokeWeight: 3
                    });

                var lengthInMeters = google.maps.geometry.spherical.computeLength(flightPath.getPath());
                document.getElementById('distanc').value = lengthInMeters

                flightPath.setMap(map); 

                MarcadorEntregador(coordEntregador,InfowindowEntregador);

                alert('Distância Percorrida em metros: ' + lengthInMeters );
                
            }

            function MarcadorEntregador(position,dadosc) {
                 var marker = new google.maps.Marker({
                 position: position,
                 icon: image,
                 map: map
                 });
            }

            </script>");
        }
    }
}