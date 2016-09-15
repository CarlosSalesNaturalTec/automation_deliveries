using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace automation_deliveries
{
    public partial class Realizadas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_data.Text = DateTime.Today.ToString("dd/MM/yyyy");                
                id_Funcionario();
                atualiza_grid();
            }
        }

        private void id_Funcionario()
        {
            //email utilizado no login
            string str1 = Context.User.Identity.Name;
            string str2 = str1.Substring(9);   // email do funcionário

            //Busca ID do funcionário em banco de dados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("select ID_Motoboy, Nome from Tbl_Motoboys where email = '" + str2 + "'");

            string str3 = "", str4 = "";

            while (dados.Read())
            {
                str3 = Convert.ToString(dados[0]);  // ID
                str4 = Convert.ToString(dados[1]);  // nome do funcionário
            }
            ConexaoBancoSQL.fecharConexao();

            // nome do funcionário
            lbl_ID_Funcionario.Text = str4;

            //armazena id em variável de seção que irá se persistir entre as janelas do browser
            Session["ID_Funcionario"] = str3;
        }

        public void atualiza_grid()
        {
            // string com data selecionada - máscara padrão SQL
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            // string SELECT
            string stringSelect = @"select Bairro, Endereco, Ponto_Ref, Id_Entrega, ID_Motoboy, Data_Encomenda, Entregue, Status_Entrega, Data_Entrega from Tbl_Entregas " +
                    " where ID_Motoboy = " + Session["ID_Funcionario"].ToString() +
                    " and Data_Encomenda = '" + date_formated + "'" +
                    " and Entregue = 1" +
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
            string stringupdate = "";
            if (RadioButtonList1.SelectedItem.ToString()== "CANCELAR")
            {
                stringupdate = "update Tbl_Entregas set Entregue = 0, Status_Entrega = Null, " +
                    " Data_Entrega = Null" +
                    " where ID_Entrega = " + Session["ID_Entrega"].ToString();
            }
            else
            {
                stringupdate = "update Tbl_Entregas set Entregue = 1, Status_Entrega = '" + RadioButtonList1.SelectedItem.ToString() + "', " +
                    " Data_Entrega = '" + date_formated + "'" +
                    " where ID_Entrega = " + Session["ID_Entrega"].ToString();
            }
            

            // atualiza
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
                " Cod_Encomenda, Telefone, Observacoes, Status_Entrega" +
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
                lbl_status_registrado.Text = "Status: " + Convert.ToString(dados[8]);

            }
            ConexaoBancoSQL.fecharConexao();
        }

    }
}