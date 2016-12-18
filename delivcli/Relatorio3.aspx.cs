using System;
using System.Text;
using System.Web.UI;

namespace delivcli
{
    public partial class Relatorio3 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder str1 = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                switch (Request.QueryString["Per"])
                {
                    case "1":
                        txtPer1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                        TxtPer2.Text = DateTime.Today.ToString("dd/MM/yyyy");
                        break;

                    case "2":
                        txtPer1.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
                        TxtPer2.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
                        break;

                    case "3":

                        DateTime dt = DateTime.Today;
                        DateTime dt1, dt2;

                        var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                        var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
                        if (diff < 0)
                            diff += 7;
                        dt1 = dt.AddDays(-diff).Date;
                        dt2 = dt1.AddDays(1);  // para adequar a brasil

                        txtPer1.Text = dt2.ToString("dd/MM/yyyy");
                        TxtPer2.Text = DateTime.Today.ToString("dd/MM/yyyy");
                        break;

                    case "4":

                        int d1 = DateTime.Today.Day - 1;
                        DateTime d2 = DateTime.Today.AddDays(-d1);

                        txtPer1.Text = d2.ToString("dd/MM/yyyy");
                        TxtPer2.Text = DateTime.Today.ToString("dd/MM/yyyy");
                        break;

                    default:
                        txtPer1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                        TxtPer2.Text = DateTime.Today.ToString("dd/MM/yyyy");
                        break;
                }

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
                        "<th>Distancia Percorrida (Km)</th>" +
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
                string idEntregador = Convert.ToString(dados[1]);
                string stringcomaspas = "<tr>" +
                                           "<td>" + Entregador + "</td>" +
                                           "<td>" + TotalKm("1") + "</td>" +
                                        "</tr>";
                str.Append(stringcomaspas);
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private string TotalKm(string id)
        {
            
            caminhoPercorrido(id);
            
            //executa javascript para calculo de distanciA
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "calcdist", ScriptDistancia(), true);

            string resultado = "000";
            
            return resultado;
        }

        private void caminhoPercorrido(string id)
        {
            coordenadas.Clear();
            string stringselect = "select Latitude, Longitude from Tbl_Historico " +
                                    "where ID_Motoboy =  " + id + " " +
                                    "and format(Data_Coleta,'dd/MM/yyyy') >='" + txtPer1.Text + "' " +
                                    "and format(Data_Coleta,'dd/MM/yyyy') <='" + TxtPer2.Text + "' " +
                                    "order by Data_Coleta";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                coordenadas.Append("{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " },");
            }
            ConexaoBancoSQL.fecharConexao();

            //remove ultimo caracter "," 
            if (coordenadas.Length == 0) { coordenadas.Append("{ lat: 0, lng: 0}"); } else { coordenadas.Length--; }
        }

        private string ScriptDistancia()
        {
            str1.Clear();
            str1.Append(@"var CaminhoPercorrido = [");
            str1.Append(coordenadas);
            str1.Append(@"];            

                var flightPath = new google.maps.Polyline({
                    path: CaminhoPercorrido,
                    geodesic: true
                    });

                var lengthInMeters = google.maps.geometry.spherical.computeLength(flightPath.getPath());

                document.getElementById('Hidden1').value = lengthInMeters;");

            return str1.ToString();
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