using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace deliv
{
    public partial class Realizar : Page
    {
        string ID_Func = "0";  // ID do Funcionário

        protected void Page_Load(object sender, EventArgs e)
        {
            // tenta identificar se houve login. caso contrário vai para página de erro
            ID_Func = Session["Func_ID"].ToString();

            if (!IsPostBack)
            {
                lbl_data.Text = DateTime.Today.ToString("dd/MM/yyyy");

                atualiza_grid();               
            }
        }

        public void atualiza_grid()
        {
            // string com data selecionada - máscara padrão SQL
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            // string SELECT
            string stringSelect = @"select Bairro, Endereco, Ponto_Ref, Id_Entrega, ID_Motoboy, " +
                    " Data_Encomenda, Entregue, Status_Entrega, Data_Entrega " +
                    " from Tbl_Entregas " +
                    " where ID_Motoboy = " + ID_Func +
                    " and Data_Encomenda = '" + date_formated + "'" +
                    " and Entregue <> 1" +
                    " order by Bairro";

            // atualiza grid com listagem de ENTREGAS 
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            GridView2.DataSource = rcrdset;
            GridView2.DataBind();
            ConexaoBancoSQL.fecharConexao();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //muda o ponteiro do mouse
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Id da Entrega
            Session["ID_Entrega"] = GridView2.SelectedRow.Cells[3].Text;

            // recupera dados da entrega com base no ID_Entrega
            dadosdaEntrega(Session["ID_Entrega"].ToString());

            // abre modal
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void bt_atualizar_click(object sender, EventArgs e)
        {
            // string com data atual - máscara padrão SQL
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            //string update
            string stringupdate = "update Tbl_Entregas set Entregue = 1, Status_Entrega = '" + RadioButtonList1.SelectedItem.ToString() + "', " +
                " Data_Entrega = '" + date_formated + "'" +
                " where ID_Entrega = " + Session["ID_Entrega"].ToString();

            OperacaoBanco operacao = new OperacaoBanco();
            Boolean update = operacao.Update(stringupdate);
            ConexaoBancoSQL.fecharConexao();
            if (update == true)
            {
                atualiza_grid();
            }

        }

        private void dadosdaEntrega(string IDEntrega)
        {
            //detalhes da entrega
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("select ID_Entrega, Nome_Destinatario, Endereco, Ponto_Ref, Bairro, " +
                " Cod_Encomenda, Telefone, Observacoes" +
                " from Tbl_Entregas where Id_Entrega = " + IDEntrega);
            while (dados.Read())
            {
                lbl_nome.Text = Convert.ToString(dados[1]);
                lbl_endereco.Text = Convert.ToString(dados[2]);
                lbl_ref.Text = Convert.ToString(dados[3]);
                lbl_bairro.Text = Convert.ToString(dados[4]);
                lbl_cod.Text = Convert.ToString(dados[5]);
                lbl_telefone.Text = Convert.ToString(dados[6]);
                lbl_obs.Text = Convert.ToString(dados[7]);
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private void salvaGeoLocalizacao()
        {

        }
    }
}