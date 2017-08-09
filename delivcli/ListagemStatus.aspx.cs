using System;
using System.Text;
using System.Web.UI;

namespace delivcli
{
    public partial class ListagemStatus : Page
    {

        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ColetaDados("On-Line");
                Literal1.Text = str.ToString();

                ColetaDados("Off-Line");
                Literal2.Text = str.ToString();
            }
        }

        private void ColetaDados(string escolha)
        {

            str.Clear();
            string stringComAspas = "<div class=\"panel panel-" + TipoHeader(escolha) + "\"><div class=\"panel-heading\"><h5 class=\"panel-title\"> " +
                   escolha.ToUpper() + "</h5></div><div class=\"panel-body\">";
            str.Append(stringComAspas);

            // Listagem de Entregadores e intevalo desde a ultima atualização
            string stringselect = "";
            stringselect = @"select Nome, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo, ID_Motoboy   " +
                    " from Tbl_Motoboys where ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " order by usuario";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                int min1 = Convert.ToInt32(dados[1]);  // diferença em minutos (180 de fuso hrário + 5 minutos de tolerância desde a ultima atualização)
                if (escolha == "On-Line") { if (min1 > 185) { continue; } }
                if (escolha == "Off-Line") { if (min1 < 185) { continue; } }

                //nome do Entregador + Total de Entregas do Dia + Total de Entregas Realizadas
                stringComAspas = "<a href=\"FichaEntregador.aspx?ID=" + Convert.ToString(dados[2]) + "\" target=\"_parent\" class=\"list-group-item\"><h6 class=\"list-group-item-heading\">" + Convert.ToString(dados[0]) + 
                    ". " + TotaldeEntregas(Convert.ToString(dados[2])) + "</h6>";
                str.Append(stringComAspas);

                if (min1 > 185)
                {
                    stringComAspas = "<p class=\"list-group-item-text\">Off-Line à: " + TempoOff(min1) + "</p></a>";
                }
                else
                {
                    stringComAspas = "<p class=\"list-group-item-text\">" + StatusDirecao(Convert.ToString(dados[2])) + "</p></a>";
                }
                str.Append(stringComAspas);
            }
            ConexaoBancoSQL.fecharConexao();

            stringComAspas = "</div></div>";
            str.Append(stringComAspas);

        }

        public string TipoHeader(string Escolha)
        {
            //  cor do cabeçãlho

            string tipoheader = "";
            switch (Escolha)
            {
                case "On-Line":
                    tipoheader = "success";
                    break;
                case "Off-Line":
                    tipoheader = "default";
                    break;
                default:
                    tipoheader = "info";
                    break;
            }

            return tipoheader;
        }

        public string StatusDirecao(string identregador)
        {
            string stringselect = "", status = "Próx.Dest.: Não Especificado";

            //  verifica se está em direção a uma entrega específica.
            stringselect = @"select Nome_Destinatario from Tbl_Entregas where ID_Motoboy = " + identregador + " and Entregue =0 and Partida_Iniciada=1";
            OperacaoBanco operacao2 = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader recordset = operacao2.Select(stringselect);
            while (recordset.Read())
            {
                status = "Próx.Dest.: " + Convert.ToString(recordset[0]);
            }
            ConexaoBancoSQL.fecharConexao();
            return status;
        }

        public string TotaldeEntregas(string identregador)
        {
            string stringselect = "";
            int totaldeentregas = 0, realizadas = 0;
            string datastatus = DateTime.Today.ToString("yyyy-MM-dd");

            // total de entregas do entregador no dia
            stringselect = @"select ID_Entrega, Entregue from Tbl_Entregas where ID_Motoboy = " + identregador +
                " and format(Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'";
            OperacaoBanco operacao4 = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader recordset = operacao4.Select(stringselect);
            while (recordset.Read())
            {
                totaldeentregas++;
                if ( Convert.ToString(recordset[1]) == "True") { realizadas++; }
            }
            ConexaoBancoSQL.fecharConexao();
            return realizadas.ToString() + " de " + totaldeentregas.ToString() ;
            
        }

        public string TempoOff(int tempominutos)
        {
            string tempo = "xxx";
            int minutos = tempominutos - 180;  // 180 = diferença fuso horario
            if (minutos < 60) { tempo = minutos.ToString() + "min"; }
            if (minutos > 60)
            {
                if (minutos < 1440)
                {
                    int horas = minutos / 60;
                    tempo = horas.ToString() + "hs";
                }
                else
                {
                    tempo = "Mais de 24hs";
                }
            }
            return tempo;
        }

    }
}