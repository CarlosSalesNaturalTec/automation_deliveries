using System;
using System.Text;

namespace delivcli
{
    public partial class DetalhesMapa : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        string marcadorEntrega = "";
        string marcadorEntregador = "";

        string infowindowEntregador = "";
        string infowindowEntrega = "";

        string imagemMarcadorEntrega = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcadorLocalDaEntrega();
                montaScript();
                Literal1.Text = str.ToString();
            }
        }

        private void MarcadorLocalDaEntrega()
        {
            string stringselect = @"select Latitude,Longitude,Status_Entrega, ID_Motoboy  " +
                   "from Tbl_Entregas where ID_Entrega = " + Session["IDDetalhes"].ToString();         
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                marcadorEntrega = "{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " }";

                switch (Convert.ToString(dados[2]))
                {
                    case "EM ABERTO":
                        imagemMarcadorEntrega = "'images/flagEmAberto.png'";
                        infowindowEntrega = "'<b>EM ABERTO</b>'";
                        break;
                    case "ENTREGA REALIZADA":
                        imagemMarcadorEntrega = "'images/flagOk.png'";
                        infowindowEntrega = "'<b>ENTREGA REALIZADA</b>'";
                        break;
                    case "EM ANDAMENTO":
                        imagemMarcadorEntrega = "'images/flagEmAndamento.png'";
                        infowindowEntrega = "'<b>EM ANDAMENTO</b>'";
                        break;
                    default:
                        imagemMarcadorEntrega = "'images/flagRetorno.png'";
                        infowindowEntrega = "'<b>" + Convert.ToString(dados[2]) + "</b>'";
                        break;
                }

                PosicaoEntregador(Convert.ToString(dados[3]));
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private void PosicaoEntregador(string identregador)
        {
            string stringselect = "";
            stringselect = @"select usuario, GeoLatitude, GeoLongitude , format(GeoDataLoc,'dd-MM-yyyy') as UltimaData," +
                    " format(GeoDataLoc,'HH:mm:ss') as UltimaHora, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo " +
                    " from Tbl_Motoboys where ID_Motoboy  = " + identregador;
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados1 = operacao.Select(stringselect);
            while (dados1.Read())
            {
                int minutos = Convert.ToInt16(dados1[5]);
                if (minutos > 185)
                {
                    marcadorEntregador = "{ }";
                    infowindowEntregador = "'Entregaor OFF-LINE'";
                }
                else
                {
                    marcadorEntregador = "{ lat: " + Convert.ToString(dados1[1]) + ", lng: " + Convert.ToString(dados1[2]) + " }";
                    infowindowEntregador = "'Entregador está Aqui'";
                }
            }
            ConexaoBancoSQL.fecharConexao();
        }
 
        private void montaScript()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

            var CentroDoMapa = ");
            str.Append(marcadorEntrega);
            str.Append(@";

            var MarcadorEntrega = ");
            str.Append(marcadorEntrega);
            str.Append(@";

            var MarcadorEntregador = ");
            str.Append(marcadorEntregador);
            str.Append(@";

            var imagem = ");
            str.Append(imagemMarcadorEntrega);
            str.Append(@";

            var infoWEntregador = ");
            str.Append(infowindowEntregador);
            str.Append(@";

            var infoWEntrega = ");
            str.Append(infowindowEntrega);
            str.Append(@";


        var map;
        var markerEntrega;
        var markerEntregador;
        var iconEntregador = 'images/motorbike24.png';

        function initMap() {

            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: CentroDoMapa
            });

            var markerEntrega = new google.maps.Marker({
            position: MarcadorEntrega,
            map: map
            });

            var markerEntregador = new google.maps.Marker({
            position: MarcadorEntregador,
            icon: iconEntregador,
            map: map
            });

            var infowindow1 = new google.maps.InfoWindow({
                content: infoWEntrega
            });
            infowindow1.open(map, markerEntrega);

            var infowindow = new google.maps.InfoWindow({
                content: infoWEntregador
            });

            infowindow.open(map, markerEntregador);

        }

        </script>");
        }
    }
}