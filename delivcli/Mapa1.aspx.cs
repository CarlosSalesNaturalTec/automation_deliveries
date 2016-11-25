using System;
using System.Text;

namespace delivcli
{
    public partial class Mapa1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();
        StringBuilder coordenadasDados = new StringBuilder();
        StringBuilder coordenadasDados2 = new StringBuilder();
        StringBuilder cood_Markers = new StringBuilder();
        string tipoMapa = "";
        string centromapa = "";
        int contagem = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // verifica se mapa com (T)odos os funcionários ou (I)ndividual
                if (Session["CLI_ID_FUNC"].ToString() == "0") { tipoMapa = "T"; } else { tipoMapa = "I"; }

                obtemcoordenadas();

                if (tipoMapa == "T")
                {
                    montaScript();
                }
                else
                {
                    MarcadoresEntregas();
                    montaScriptindividual();
                }

                Literal1.Text = str.ToString();
            }
        }

        private void obtemcoordenadas()
        {
            try
            {
                string stringselect = "";
                string dataformatada = Session["date_formated"].ToString();

                if (tipoMapa == "T")
                {
                    // Motoboys e respectivas coordenadas de localização
                    stringselect = @"select usuario, GeoLatitude, GeoLongitude , format(GeoDataLoc,'dd-MM-yyyy') as UltimaData," +
                        " format(GeoDataLoc,'HH:mm:ss') as UltimaHora, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo " +
                        " from Tbl_Motoboys where ID_Cliente = " + Session["Cli_ID"].ToString() +
                        " order by usuario";
                }
                else
                {
                    // Histórico localização do Motoboy (no dia)
                    stringselect = "select ID_Motoboy, Latitude, Longitude, Data_Coleta from Tbl_Historico"
                                    + " where ID_Motoboy = " + Session["CLI_ID_FUNC"].ToString()
                                    + " and format(data_coleta,'yyyy-MM-dd')= '" + dataformatada + "' order by data_coleta desc";
                }
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

                coordenadas.Clear();
                coordenadasDados.Clear();
                coordenadasDados2.Clear();

                string coord = "";
                while (dados.Read())
                {
                    coord = Convert.ToString(dados[2]);
                    if (coord == "")
                    {
                    }
                    else
                    {
                        // pega somente o primeiro valor para servir como centro do mapa
                        if (contagem == 1) { centromapa = "{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " }"; contagem++; }

                        //obtem dados da ultima leitura
                        coordenadas.Append("{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " },");


                        string dadosCoordenadas = Convert.ToString(dados[0]);
                        string dadosCoordenadas2 = "";

                        if (tipoMapa == "T")
                        {
                            string status = "", tagIni = "", tagFim = "";
                            int minutos = Convert.ToInt16(dados[5]);
                            if (minutos > 185) {
                                tagIni = "<p style=\"color: red;\"><b>";
                                status = "Off-Line";
                                tagFim = "</b></p>";
                                dadosCoordenadas2 = Convert.ToString(dados[3]) + " " + Convert.ToString(dados[4]);
                            }
                            else {
                                tagIni = "<p style=\"color: green;\"><b>";
                                status = "On-Line";
                                tagFim = "</b></p>";
                                dadosCoordenadas2 = Convert.ToString(dados[4]);
                            }

                            coordenadasDados.Append("'" + tagIni + dadosCoordenadas + "  " + status + tagFim + "',");
                            coordenadasDados2.Append("'<p>" + dadosCoordenadas2 + "</p>',");
                        }

                    }
                }

                ConexaoBancoSQL.fecharConexao();

                if (coordenadas.Length == 0) { }
                else
                {
                    coordenadas.Length--; //remove ultimo caracter "," 
                }

                if (coordenadasDados.Length == 0) { }
                else
                {
                    coordenadasDados.Length--; //remove ultimo caracter "," 
                }

                if (coordenadasDados2.Length == 0) { }
                else
                {
                    coordenadasDados2.Length--; //remove ultimo caracter "," 
                }


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

            var NomeMotoboy = [");
            str.Append(coordenadasDados.ToString());
            str.Append(@"];

            var DataHoraCoord = [");
            str.Append(coordenadasDados2.ToString());
            str.Append(@"];

            var CentroDoMapa = ");
            str.Append(centromapa);
            str.Append(@";

        var markers = [];
        var map;
        var image = 'images/motorbike24.png';

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: CentroDoMapa
            });
            drop();
        }

        function drop() {
            clearMarkers();
            for (var i = 0; i < neighborhoods.length; i++) {
                var contentString = NomeMotoboy[i] + DataHoraCoord[i];
                MarcadorComInfoWindow(neighborhoods[i],contentString);
            }
        }

        function MarcadorComInfoWindow(position,dadosc) {
            var infowindow = new google.maps.InfoWindow({
                content: dadosc
            });

            var marker = new google.maps.Marker({
            position: position,
            icon: image,
            map: map
            });

            infowindow.open(map, marker);
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
            str.Append(cood_Markers.ToString());
            str.Append(@"];

            var CentroDoMapa = ");
            str.Append(centromapa);
            str.Append(@";

        var markers = [];
        var map;

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: CentroDoMapa
            });
            drop();

            var flightPlanCoordinates = [");
            str.Append(coordenadas.ToString());
            str.Append(@"];

            var flightPath = new google.maps.Polyline({
                    path: flightPlanCoordinates,
                    geodesic: true,
                    strokeColor: '#4D4DFF',
                    strokeOpacity: 0.6,
                    strokeWeight: 3
                    });

            flightPath.setMap(map); 

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

        private void MarcadoresEntregas()
        {
            string stringselect = "";
            string dataformatada = Session["date_formated"].ToString();
            cood_Markers.Clear();
            string coord = "";

            // seleciona Coordenadas de todas as entregas a realizar na data
            stringselect = "select ID_Entrega,ID_Motoboy,Latitude,Longitude, Data_Encomenda from Tbl_Entregas"
                            + " where ID_Motoboy = " + Session["CLI_ID_FUNC"].ToString()
                            + " and format(Data_Encomenda,'yyyy-MM-dd')= '" + dataformatada + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                coord = Convert.ToString(dados[2]);
                if (coord == "") { }
                else
                {
                    cood_Markers.Append("{ lat: " + Convert.ToString(dados[2]) + ", lng: " + Convert.ToString(dados[3]) + " },");
                }
            }

            ConexaoBancoSQL.fecharConexao();

            if (cood_Markers.Length == 0) { }
            else
            {
                //remove ultimo caracter ","    
                cood_Markers.Length--;
            }

        }

    }
}