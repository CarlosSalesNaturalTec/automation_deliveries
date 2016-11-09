﻿using System;
using System.Text;

namespace delivcli
{
    public partial class Mapa1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();
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
                if (tipoMapa == "T") { montaScript(); } else { montaScriptindividual2(); }
                
                Literal1.Text = str.ToString();
            }
        }

        private void obtemcoordenadas()
        {
            try
            {
                string stringselect = "";
                //string dataformatada = DateTime.Today.ToString("yyyy-MM-dd");
                string dataformatada = Session["date_formated"].ToString();

                if (tipoMapa == "T")
                {
                    // Motoboys e respectivas coordenadas de localização
                    stringselect = "select usuario, GeoLatitude, GeoLongitude , GeoDataLoc from Tbl_Motoboys order by usuario";
                }else
                {
                    // Histórico localização do Motoboy (no dia)
                    stringselect = "select ID_Motoboy, Latitude, Longitude, Data_Coleta from Tbl_Historico"
                                    + " where ID_Motoboy = " + Session["CLI_ID_FUNC"].ToString()
                                    + " and format(data_coleta,'yyyy-MM-dd')= '" + dataformatada + "' order by data_coleta desc";
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
                        // pega somente o primeiro valor para servir como centro do mapa
                        if (contagem == 1) { centromapa = "{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " }"; }

                        //obtem coordenadas
                        coordenadas.Append("{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " },");
                    }
                }
                ConexaoBancoSQL.fecharConexao();
                if (coordenadas.Length == 0) {}else {
                    //remove ultimo caracter ","    
                    coordenadas.Length--;  
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
            // desativado. método antigo que só mostrava posição do motoboy. sem histórico

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

        private void montaScriptindividual2()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 
                   function initMap() {
                    var map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 14,
                    center: ");

            str.Append(centromapa);

            str.Append(@",
                    mapTypeId: google.maps.MapTypeId.TERRAIN 
                    });

                    var flightPlanCoordinates = [");

            str.Append(coordenadas.ToString());

            str.Append(@"];

                    var flightPath = new google.maps.Polyline({
                    path: flightPlanCoordinates,
                    geodesic: true,
                    strokeColor: '#4D4DFF',
                    strokeOpacity: 1.0,
                    strokeWeight: 5
                    });

                    flightPath.setMap(map); }

                </script>");
        }

    }
}