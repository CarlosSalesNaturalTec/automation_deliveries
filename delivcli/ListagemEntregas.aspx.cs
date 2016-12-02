using System;
using System.Text;
using System.Web.UI;

namespace delivcli
{
    public partial class ListagemEntregas : Page
    {

        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // tenta identificar se houve login. caso contrário vai para página de erro
                string v_id_cli = Session["Cli_ID"].ToString();

                EmAndamento();
                Literal1.Text = str.ToString();

                EmAberto();
                Literal2.Text = str.ToString();

                Entregues();
                Literal3.Text = str.ToString();

                Retornos();
                Literal4.Text = str.ToString();

            }
        }

        private void EmAberto()
        {

            str.Clear();
            string stringComAspas = "<div class=\"panel panel-warning\"><div class=\"panel-heading\"><h3 class=\"panel-title\"> " +
                   "ENTREGAS EM ABERTO</h3></div><div class=\"panel-body\">";
            str.Append(stringComAspas);

            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario" +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " and Tbl_Entregas.Status_Entrega ='EM ABERTO'" +
                    " and Tbl_Entregas.Partida_Iniciada =0";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }

                //Linha 1 Cabeçalho 
                stringComAspas = "<a class=\"list-group-item\"><h4 class=\"list-group-item-heading\">" + Convert.ToString(dados[3]) + "</h4>";
                str.Append(stringComAspas);
                //Linha 2 Corpo 
                stringComAspas = "<p class=\"list-group-item-text\">Entregador: " + Convert.ToString(dados[2]) + "</p></a>";
                str.Append(stringComAspas);
            }
            ConexaoBancoSQL.fecharConexao();

            stringComAspas = "</div></div>";
            str.Append(stringComAspas);

        }

        private void EmAndamento()
        {
            str.Clear();
            string stringComAspas = "<div class=\"panel panel-info\"><div class=\"panel-heading\"><h3 class=\"panel-title\"> " +
                   "ENTREGAS EM ANDAMENTO</h3></div><div class=\"panel-body\">";
            str.Append(stringComAspas);

            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario" +
                " from Tbl_Entregas " +
                " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                " and Tbl_Entregas.Partida_Iniciada = 1" +
                " and Tbl_Entregas.Entregue = 0";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }

                //Linha 1 Cabeçalho 
                stringComAspas = "<a class=\"list-group-item\"><h4 class=\"list-group-item-heading\">" + Convert.ToString(dados[3]) + "</h4>";
                str.Append(stringComAspas);
                //Linha 2 Corpo 
                stringComAspas = "<p class=\"list-group-item-text\">Entregador: " + Convert.ToString(dados[2]) + "</p></a>";
                str.Append(stringComAspas);
            }
            ConexaoBancoSQL.fecharConexao();

            stringComAspas = "</div></div>";
            str.Append(stringComAspas);

        }

        private void Entregues()
        {
            str.Clear();
            string stringComAspas = "<div class=\"panel panel-success\"><div class=\"panel-heading\"><h3 class=\"panel-title\"> " +
                   "ENTREGAS REALIZADAS</h3></div><div class=\"panel-body\">";
            str.Append(stringComAspas);

            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario" +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and Tbl_Entregas.Entregue = 1" +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " and Tbl_Entregas.Status_Entrega='ENTREGA REALIZADA'";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }

                //Linha 1 Cabeçalho 
                stringComAspas = "<a class=\"list-group-item\"><h4 class=\"list-group-item-heading\">" + Convert.ToString(dados[3]) + "</h4>";
                str.Append(stringComAspas);
                //Linha 2 Corpo 
                stringComAspas = "<p class=\"list-group-item-text\">Entregador: " + Convert.ToString(dados[2]) + "</p></a>";
                str.Append(stringComAspas);
            }
            ConexaoBancoSQL.fecharConexao();

            stringComAspas = "</div></div>";
            str.Append(stringComAspas);

        }

        private void Retornos()
        {
            str.Clear();
            string stringComAspas = "<div class=\"panel panel-danger\"><div class=\"panel-heading\"><h3 class=\"panel-title\"> " +
                   "RETORNOS</h3></div><div class=\"panel-body\">";
            str.Append(stringComAspas);

            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario" +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " and Tbl_Entregas.Entregue = 1" +
                    " and Tbl_Entregas.Status_Entrega<>'ENTREGA REALIZADA'";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }

                //Linha 1 Cabeçalho 
                stringComAspas = "<a class=\"list-group-item\"><h4 class=\"list-group-item-heading\">" + Convert.ToString(dados[3]) + "</h4>";
                str.Append(stringComAspas);
                //Linha 2 Corpo 
                stringComAspas = "<p class=\"list-group-item-text\">Entregador: " + Convert.ToString(dados[2]) + "</p></a>";
                str.Append(stringComAspas);
            }
            ConexaoBancoSQL.fecharConexao();

            stringComAspas = "</div></div>";
            str.Append(stringComAspas);

        }

    }
}