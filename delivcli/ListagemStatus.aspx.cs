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
                ColetaDados();
                Literal1.Text = str.ToString();
            }
        }

        private void ColetaDados()
        {
            // seleção do usuário: ativo, inativo ou todos
            string escolha = Session["LocTipo"].ToString();  

            str.Clear();
            string stringComAspas = "<div class=\"panel panel-" + TipoHeader(escolha) + "\"><div class=\"panel-heading\"><h3 class=\"panel-title\"> " + 
                   Session["LocTipo"].ToString().ToUpper() + "</h3></div><div class=\"panel-body\">";
            str.Append(stringComAspas);

            // Listagem de Entregadores e intevalo desde a ultima atualização
            string stringselect = "";
            stringselect = @"select usuario, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo, ID_Motoboy   " +
                    " from Tbl_Motoboys where ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " order by usuario";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                int min1 = Convert.ToInt16(dados[1]);  // diferença em minutos (180 de fuso hrário + 5 minutos de tolerância desde a ultima atualização)
                if (escolha == "On-Line") { if (min1 > 185) { continue; } }
                if (escolha == "Off-Line") { if (min1 < 185) { continue; } }

                //nome do Entregador
                stringComAspas = "<a class=\"list-group-item\"><h4 class=\"list-group-item-heading\">" + Convert.ToString(dados[0]) + "</h4>";
                str.Append(stringComAspas);

                if (min1 > 185) {
                    stringComAspas = "<p class=\"list-group-item-text\">Off-Line à: " + TempoOff(min1) + "</p></a>";
                }
                else {
                    stringComAspas = "<p class=\"list-group-item-text\">Status: " + StatusDirecao(Convert.ToString(dados[2])) + "</p></a>";
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
                    tipoheader = "danger";
                    break;
                default:
                    tipoheader = "info";
                    break;
            }

            return tipoheader;
        }

        public string StatusDirecao(string identregador)
        {
            string stringselect = "", status = "xxx";

            stringselect = @"select ID_Entrega from Tbl_Entregas where ID_Motoboy = " + identregador + " and Entregue=0";
            OperacaoBanco operacao2 = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao2.Select(stringselect);
            ConexaoBancoSQL.fecharConexao();

           

            return status;

        }

        public string TempoOff (int tempominutos)
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