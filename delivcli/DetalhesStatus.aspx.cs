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
                montaScript();
                Literal1.Text = str.ToString();
            }

        }

        public void dadosDaEntrega()
        {
            string ident = "";
            string stringselect = @"select Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Status_Entrega," +
                    " Tbl_Motoboys.Nome, Tbl_Entregas.Endereco, Tbl_Entregas.Bairro, Tbl_Motoboys.ID_Motoboy, Tbl_Entregas.Latitude, Tbl_Entregas.Longitude " +
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
            }
            ConexaoBancoSQL.fecharConexao();
            posicaoEntrega = Lat + "," + Lng;

            ObtemDistancia(ident);

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
            posicaoEntregador = Lat + "," + Lng;
        }

        private void montaScript()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'>

            var origem = new google.maps.LatLng(");
            str.Append(posicaoEntregador);
            str.Append(@");

            var destino = new google.maps.LatLng(");
            str.Append(posicaoEntrega);
            str.Append(@");

            var geocoder = new google.maps.Geocoder;
            var service = new google.maps.DistanceMatrixService();
            
            service.getDistanceMatrix(
            {
               origins: [origem],
               destinations: [destino],
               travelMode: google.maps.TravelMode.DRIVING,
               unitSystem: google.maps.UnitSystem.METRIC,
               avoidHighways: false,
               avoidTolls: false
            }, callback);

            function callback(response, status) {
              
                if (status !== google.maps.DistanceMatrixStatus.OK) {
                      alert('Error was: ' + status);
                    } else {

                      var outputDiv = document.getElementById('output');
                      outputDiv.innerHTML = '';

                      for (var i = 0; i < originList.length; i++) {   
                        var results = response.rows[i].elements;
                        for (var j = 0; j < results.length; j++) {
                          outputDiv.innerHTML += results[j].distance.text + ' in ' +
                              results[j].duration.text + '<br>';
                        }
                      }
                    }
            }

            </script>");
        }

    }
}