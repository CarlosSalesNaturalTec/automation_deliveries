using System;
using System.Text;

namespace delivcli
{
    public partial class Relatorio1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();
        
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

                string T2 = TotalKM(Convert.ToString(dados[1]));  // atenção incompleto
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

        private string TotalKM (string id)
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
            if (coordenadas.Length == 0) { } else { coordenadas.Length--; }
            ScriptDistancia();

            string DistanciaViagem = "0";  //Request["dist"].ToString();

            return DistanciaViagem;
        }

        private void ScriptDistancia()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'>
            function calcDist() {

            var dist = google.maps.geometry.spherical.computeLength(");
            str.Append(coordenadas.ToString());
            str.Append(@");

            document.getElementById('Hidden1').value = dist;
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