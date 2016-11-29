using System;
using System.Text;

namespace delivcli
{
    public partial class Mapa1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();
        StringBuilder coordenadasDados = new StringBuilder();
        StringBuilder cood_Markers = new StringBuilder();
        string centromapa = "{ lat: -12.9886458, lng: -38.4715624 }";
        int contagem = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // tenta identificar se houve login. caso contrário vai para página de erro
                string v_id_cli = Session["Cli_ID"].ToString();

                obtemcoordenadas();
                montaScript();

                Literal1.Text = str.ToString();
            }
        }

        private void obtemcoordenadas()
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

                string coord = "";

                while (dados.Read())
                {

                    int min1 = Convert.ToInt16(dados[5]);  // diferença em minutos
                    string escolha = Session["LocTipo"].ToString();  // seleção do usuário: ativo, inativo ou todos

                    if (escolha == "On-Line") { if (min1 > 185) { continue; } }
                    if (escolha == "Off-Line") { if (min1 < 185) { continue; } }

                    coord = Convert.ToString(dados[2]);
                    if (coord == "") { }
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
                    }

                }

                ConexaoBancoSQL.fecharConexao();

                if (coordenadas.Length == 0) { }
                else {
                    coordenadas.Length--; //remove ultimo caracter "," 
                }

                if (coordenadasDados.Length == 0) { }
                else {
                    coordenadasDados.Length--; //remove ultimo caracter "," 
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
                var contentString = NomeMotoboy[i];
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

        
    }
}