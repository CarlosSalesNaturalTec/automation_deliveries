using System;
using System.Text;
using System.Web.UI;

namespace delivcli
{
    public partial class DetalhesStatus : Page
    {
        StringBuilder str = new StringBuilder();
        string posicaoEntregador = "";
        string posicaoEntrega = "";
        string Lat = "", Lng = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dadosDaEntrega();
            }

        }

        public void dadosDaEntrega()
        {
            string ident = "";
            string horaentrega = "";
            string stringselect = @"select Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Status_Entrega," +
                    " Tbl_Motoboys.Nome, Tbl_Entregas.Endereco, Tbl_Entregas.Bairro, Tbl_Motoboys.ID_Motoboy, " +
                    " Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, format(Chegada_Data,'dd/MM/yyyy hh:mm:ss') as dataentrega " +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Entrega = " + Session["IDDetalhes"].ToString();
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                lblDestinatario.Text = Convert.ToString(dados[0]);
                lblStatus.Text = Convert.ToString(dados[1]);
                lblEntregador.Text = Convert.ToString(dados[2]);

                lblEnd.Text = Convert.ToString(dados[3]);
                lblBairro.Text = Convert.ToString(dados[4]);

                ident = Convert.ToString(dados[5]);
                Lat = Convert.ToString(dados[6]);
                Lng = Convert.ToString(dados[7]);
               
                horaentrega = Convert.ToString(dados[8]);
            }
            ConexaoBancoSQL.fecharConexao();
            posicaoEntrega = "{lat: " + Lat + ", lng: " + Lng + "}";

            switch (lblStatus.Text)
            {
                case "EM ABERTO":
                    ObtemDistancia(ident);
                    break;
                case "EM ANDAMENTO":
                    ObtemDistancia(ident);
                    break;
                default:
                    lblHoraEntrega.Text = horaentrega;
                    break;
            }

        }

        public void ObtemDistancia(string identregador)
        {
            //obtem localização atual do Entregador
            string stringselect = @"select GeoLatitude, GeoLongitude , format(GeoDataLoc,'dd-MM-yyyy') as UltimaData," +
                   " format(GeoDataLoc,'HH:mm:ss') as UltimaHora, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo " +
                   " from Tbl_Motoboys " + 
                   " where ID_Motoboy  = " + identregador;
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                Lat = Convert.ToString(dados[0]);
                Lng = Convert.ToString(dados[1]);
            }
            ConexaoBancoSQL.fecharConexao();
            posicaoEntregador = "{lat: " + Lat + ", lng: " + Lng + "}";

            ScriptDistancia();
            Literal1.Text = str.ToString();

        }

        private void ScriptDistancia()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'>

            function initMap() {

              var origin1 = ");
            str.Append(posicaoEntregador);
            str.Append(@";

              var destinationB = ");
            str.Append(posicaoEntrega);
            str.Append(@";

              var service = new google.maps.DistanceMatrixService;
              service.getDistanceMatrix({
                origins: [origin1],
                destinations: [destinationB],
                travelMode: google.maps.TravelMode.TRANSIT,
                unitSystem: google.maps.UnitSystem.METRIC
              }, function(response, status) {
                if (status !== google.maps.DistanceMatrixStatus.OK) {
                  alert('Error was: ' + status);
                } else {
                  var originList = response.originAddresses;
                  var destinationList = response.destinationAddresses;
                  var outputDiv = document.getElementById('output');
                  outputDiv.innerHTML = '';

                  for (var i = 0; i < originList.length; i++) {
                    var results = response.rows[i].elements;
                    for (var j = 0; j < results.length; j++) {
                      outputDiv.innerHTML += 'Distancia:<b>' + results[j].distance.text + '</b><br>' +
                        'Tempo Estimado:<b>' + results[j].duration.text + '</b>';
                    }
                  }
                }
              });
            }    

            </script>");
        }

    }
}