using System;
using System.Text;
using System.Web.UI;

namespace delivcli
{
    public partial class DetalhesStatus : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dadosDaEntrega();           
            }

        }

        public void dadosDaEntrega()
        {
            string stringselect = @"select Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Status_Entrega," +
                    " Tbl_Motoboys.Nome, Tbl_Entregas.Endereco, Tbl_Entregas.Bairro " +
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
            }
            ConexaoBancoSQL.fecharConexao();

        }

    }
}