﻿using System;
using System.Text;

namespace delivcli
{
    public partial class Mapa1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();
        StringBuilder coordenadasDados = new StringBuilder();

        StringBuilder tituloMarcador = new StringBuilder();
        StringBuilder cood_Markers = new StringBuilder();

        StringBuilder EntregasCoord = new StringBuilder();
        StringBuilder EntregasInfo = new StringBuilder();

        string centromapa = "{ lat: -12.9886458, lng: -38.4715624 }";
        int contagem = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // tenta identificar se houve login. caso contrário vai para página de erro
                string v_id_cli = Session["Cli_ID"].ToString();

                obtemcoordenadas("On-Line");
                EntregasEmAberto();

                montaScript();
                Literal1.Text = str.ToString();
            }
        }

        private void obtemcoordenadas(string escolha)
        {
            try
            {
                string stringselect = "";

                // Motoboys e respectivas coordenadas de localização
                stringselect = @"select usuario, GeoLatitude, GeoLongitude , format(GeoDataLoc,'dd-MM-yyyy') as UltimaData," +
                        " format(GeoDataLoc,'HH:mm:ss') as UltimaHora, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo " +
                        " from Tbl_Motoboys where ID_Cliente = " + Session["Cli_ID"].ToString() +
                        " order by usuario";

                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

                coordenadas.Clear();
                coordenadasDados.Clear();
                tituloMarcador.Clear();

                string coord = "";

                while (dados.Read())
                {

                    int min1 = Convert.ToInt16(dados[5]);  // diferença em minutos

                    if (escolha == "On-Line") { if (min1 > 185) { continue; } }
                    if (escolha == "Off-Line") { if (min1 < 185) { continue; } }

                    coord = Convert.ToString(dados[2]);
                    if (coord == "") { continue; }
                    else
                    {
                        // pega somente o primeiro valor para servir como centro do mapa
                        if (contagem == 1) { centromapa = "{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " }"; contagem++; }

                        //obtem dados da ultima leitura
                        coordenadas.Append("{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " },");

                        string dadosCoordenadas = Convert.ToString(dados[0]);

                        string tagIni = "", tagFim = "";
                        int minutos = Convert.ToInt16(dados[5]);
                        if (minutos > 185)
                        {
                            tagIni = "<p style=\"color: red;\"><b>";
                            tagFim = "</b></p>";
                        }
                        else
                        {
                            tagIni = "<p style=\"color: green;\"><b>";
                            tagFim = "</b></p>";
                        }

                        coordenadasDados.Append("'" + tagIni + dadosCoordenadas + tagFim + "',");
                        tituloMarcador.Append("'" + dadosCoordenadas + "',");
                    }
                }
                ConexaoBancoSQL.fecharConexao();

                //remove ultimo caracter "," 
                if (coordenadas.Length == 0) { } else { coordenadas.Length--; }
                if (coordenadasDados.Length == 0) { } else { coordenadasDados.Length--; }
                if (tituloMarcador.Length == 0) { } else { tituloMarcador.Length--; }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EntregasEmAberto()
        {
            EntregasCoord.Clear();
            EntregasInfo.Clear();
           
            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome " +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " and Tbl_Entregas.Status_Entrega ='EM ABERTO'";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }
                EntregasCoord.Append("{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " },");
                EntregasInfo.Append("'" + Convert.ToString(dados[2]) + "',");
            }
            ConexaoBancoSQL.fecharConexao();

            //remove ultimo caracter "," 
            if (EntregasCoord.Length == 0) { } else { EntregasCoord.Length--; }
            if (EntregasInfo.Length == 0) { } else { EntregasInfo.Length--; }

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

            var TituloMarcador = [");
            str.Append(tituloMarcador.ToString());
            str.Append(@"];

            var EntregasEmAberto = [");
            str.Append(EntregasCoord.ToString());
            str.Append(@"];

            var EntregasTitle = [");
            str.Append(EntregasInfo.ToString());
            str.Append(@"];

            var CentroDoMapa = ");
            str.Append(centromapa);
            str.Append(@";

        var markers = [];
        var markersEntregas = [];
        var map;
        var image = 'images/motorbike24.png';

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: CentroDoMapa
            });
            entregadoresOnLine();
            entregasemAberto();
        }

        function entregadoresOnLine() {
            clearMarkers();
            for (var i = 0; i < neighborhoods.length; i++) {
                var contentString = NomeMotoboy[i];
                MarcadorComInfoWindow(neighborhoods[i],contentString,TituloMarcador[i]);
            }
        }

        function entregasemAberto() {
            clearMarkersEntregas();
            for (var i = 0; i < EntregasEmAberto.length; i++) {
                MarcadorEntrega(EntregasEmAberto[i],EntregasTitle[i]);
            }
        }

        function MarcadorComInfoWindow(position,dadosc,titulo) {
            var marker = new google.maps.Marker({
            position: position,
            icon: image,
            title: titulo,
            map: map
            });
            var infowindow = new google.maps.InfoWindow({
                content: dadosc
            });
            infowindow.open(map, marker);
        }

        function MarcadorEntrega(position,titulo) {
            var markersEntregas = new google.maps.Marker({
            position: position,
            title: titulo,
            map: map
            });
        }

        function clearMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
            markers = [];
        }

        function clearMarkersEntregas() {
            for (var i = 0; i < markersEntregas.length; i++) {
                markersEntregas[i].setMap(null);
            }
            markersEntregas = [];
        }

                </script>");
        }
    }
}