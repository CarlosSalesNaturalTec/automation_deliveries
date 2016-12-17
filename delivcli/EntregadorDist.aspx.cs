using System;
using System.Text;

namespace delivcli
{
    public partial class EntregadorDist : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idEntregador = Session["IDEntregador"].ToString();

                caminhoPercorrido(idEntregador);
                montaScript();
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

       private void montaScript()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

            var CaminhoPercorrido = [");
            str.Append(coordenadas);
            str.Append(@"];            

            function initMap() {

                var flightPath = new google.maps.Polyline({
                    path: CaminhoPercorrido,
                    geodesic: true,
                    strokeColor: '#4D4DFF',
                    strokeOpacity: 0.6,
                    strokeWeight: 3
                    });

                var lengthInMeters = google.maps.geometry.spherical.computeLength(flightPath.getPath());
                document.getElementById('distanc').value = lengthInMeters.toPrecision(4);

            }

            </script>");
        }
    }
}