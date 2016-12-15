using System;
using System.Text;

namespace delivcli
{
    public partial class Relatorio1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();

        string posicao1 = "", posicao2 = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtPer1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                TxtPer2.Text = DateTime.Today.ToString("dd/MM/yyyy");

                montaCabecalho();
                dadosCorpo();
                montaRodape();
                Literal1.Text = str.ToString();
            }
        }

        private void montaCabecalho()
        {
            string stringcomaspas = "<table class=\"table table-striped table-hover \">" +
                "<thead>" +
                    "<tr>" +
                        "<th>Entregador</th>" +
                        "<th>Total de Entregas</th>" +
                        "<th>Total em Km</th>" +
                        "<th>Tempo Gasto (min)</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>";
            str.Clear();
            str.Append(stringcomaspas);
        }

        private void dadosCorpo()
        {
            string stringselect = "select Nome, ID_Motoboy from Tbl_Motoboys where ID_Cliente = " + Session["Cli_ID"].ToString() + " order by Nome";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                string Entregador = Convert.ToString(dados[0]);
                string T1 = TotalEntregues(Convert.ToString(dados[1]));
                if (T1 == "0") { continue; }

                string T2 = Viagens(Convert.ToString(dados[1]));
                string T3 = TempoTotal(Convert.ToString(dados[1]));

                string stringcomaspas = "<tr>" +
                                           "<td>" + Entregador + "</td>" +
                                           "<td>" + T1 + "</td>" +
                                           "<td>" + T2 + "</td>" +
                                           "<td>" + T3 + "</td>" +
                                        "</tr>";
                str.Append(stringcomaspas);
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private string TotalEntregues(string id)
        {
            string TotalGeralEntregues = "1";
            string stringselect = "select COUNT(Tbl_Entregas.ID_Entrega) as TotalGeralEntregas " +
                                "from Tbl_Entregas  " +
                                "where Tbl_Entregas.ID_Motoboy = " + id + " and " +
                                "Tbl_Entregas.Entregue = 1 and " +
                                "format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') >='" + txtPer1.Text + "' " +
                                "and format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') <='" + TxtPer2.Text + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                TotalGeralEntregues = Convert.ToString(dados[0]);
            }
            ConexaoBancoSQL.fecharConexao();

            return TotalGeralEntregues;
        }

        private string Viagens(string id)
        {
            string totalKm = "0";
            string stringselect = "select Partida_Data , Chegada_Data " +
                                "from Tbl_Entregas  " +
                                "where Tbl_Entregas.ID_Motoboy = " + id + " and " +
                                "Tbl_Entregas.Entregue = 1 and " +
                                "format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') >='" + txtPer1.Text + "' " +
                                "and format(Tbl_Entregas.Data_Encomenda,'dd/MM/yyyy') <='" + TxtPer2.Text + "' " +
                                "order by Partida_Data";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            string partida, chegada = "";

            while (dados.Read())
            {
                partida = Convert.ToString(dados[0]);
                chegada = Convert.ToString(dados[1]);

                TotalKmPorViagem(id, partida, chegada);

            }
            ConexaoBancoSQL.fecharConexao();

            return totalKm;

        }

        private string TotalKmPorViagem (string id, string start, string finish)
        {
            string kmTotal = "0";
            coordenadas.Clear();

            string stringselect = "select Latitude, Longitude from Tbl_Historico " +
                                    "where ID_Motoboy =  " + id + " " +
                                    "and Data_Coleta >= '" + start + "' " +
                                    "and Data_Coleta <= '" + finish + "' " +
                                    "order by Data_Coleta";        
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                coordenadas.Append("{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " },");
            }
            ConexaoBancoSQL.fecharConexao();

            //remove ultimo caracter "," 
            if (coordenadas.Length == 0) { } else { coordenadas.Length--; }

            return kmTotal;
        }

        private void ScriptDistancia()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'>

            function initMap() {

              var origin1 = ");
            str.Append(posicao1);
            str.Append(@";

              var destinationB = ");
            str.Append(posicao2);
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

        private string TempoTotal(string id)
        {
            string tempo = "0";
            string stringselect = "select sum(DATEDIFF(MINUTE, Partida_data, Chegada_Data)) AS TempoTotal " +
                                    "from Tbl_Entregas " +
                                    "where entregue = 1 and ID_Motoboy = " + id + " " +
                                    "and format(Tbl_Entregas.Data_Encomenda, 'dd/MM/yyyy') >= '" + txtPer1.Text + "' " +
                                    "and format(Tbl_Entregas.Data_Encomenda, 'dd/MM/yyyy') <= '" + TxtPer2.Text + "'";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                tempo = Convert.ToString(dados[0]);
            }
            ConexaoBancoSQL.fecharConexao();
            return tempo;
        }

        private void montaRodape()
        {
            string footer = "</tbody></table>";
            str.Append(footer);
        }

        protected void txtPer1_TextChanged(object sender, EventArgs e)
        {
            montaCabecalho();
            dadosCorpo();
            montaRodape();
            Literal1.Text = str.ToString();
        }

        protected void TxtPer2_TextChanged(object sender, EventArgs e)
        {
            montaCabecalho();
            dadosCorpo();
            montaRodape();
            Literal1.Text = str.ToString();
        }
    }

}