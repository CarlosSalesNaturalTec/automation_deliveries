using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace automation_deliveries_client
{
    public partial class Cad_Funcionarios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    totalderegistros();
                    atualiza_grid();
                }
            }
            catch { }
        }

        public void totalderegistros()
        {
            // total de registros cadastrados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(@"SELECT COUNT(*) AS totalderegistros FROM Tbl_Motoboys where " +
                "[ID_Cliente]=" + Session["ID_Cliente"].ToString() +  ";");
            String totalderegistros = "";
            try
            {
                while (dados.Read())
                {
                    totalderegistros = Convert.ToString(dados[0]);
                    lbl_total_motoboys.Text = totalderegistros;
                }
            }
            catch (Exception)
            {
                throw;
            }
            ConexaoBancoSQL.fecharConexao();
        }

        public void atualiza_grid()
        {
            // listagem de funcionarios por cliente
            OperacaoBanco operacao = new OperacaoBanco();
            string stringSelect = "select * from Tbl_Motoboys where ID_Cliente = " + Session["ID_Cliente"].ToString() + " order by Nome";
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            GridView2.DataSource = rcrdset;
            GridView2.DataBind();
            ConexaoBancoSQL.fecharConexao();
        }

        protected void bt_novo_salvar_click(object sender, EventArgs e)
        {
           
            try
            {   
                OperacaoBanco operacao = new OperacaoBanco();
                bool inserir = operacao.Insert(@"INSERT INTO Tbl_Motoboys (ID_Cliente, Nome, email, Telefone, " +
                    "WhatsApp, Veiculo, Modelo, Placa) VALUES (" + Session["ID_Cliente"].ToString() + 
                    ",'" + txt_nome.Text + "', '" + txt_email.Text + "', '" + txt_telefone.Text + 
                    "', '" + txt_whatsapp.Text + "', '" + txt_veiculo.Text + "', '" + txt_modelo.Text + 
                    "', '" + txt_placa.Text + "')");
                ConexaoBancoSQL.fecharConexao();

                txt_nome.Text = "";
                txt_email.Text = "";
                txt_telefone.Text = "";
                txt_whatsapp.Text = "";
                txt_veiculo.Text = "";
                txt_modelo.Text = "";
                txt_placa.Text = "";

                if (inserir == true)
                {
                    atualiza_grid();
                    totalderegistros();
                }
            }
            catch
            {
            }
        }

        protected void bt_editar_salvar_click(object sender, EventArgs e)
        {
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean update = operacao.Update(@"UPDATE Tbl_Motoboys SET Nome='" + txt_edit_nome.Text + "', " + 
                    "email = '" + txt_edit_email.Text + "', telefone = '" + txt_edit_telefone.Text + "', " +
                    "WhatsApp = '" + txt_edit_whatsapp.Text + "', Veiculo = '" + txt_edit_veiculo.Text + "', " +
                    "Modelo = '" + txt_edit_modelo.Text + "', Placa = '" + txt_edit_placa.Text + "' WHERE ID_Motoboy=" + lbl_id.Text + ";");
                ConexaoBancoSQL.fecharConexao();
                if (update == true)
                {
                    atualiza_grid();
                }
            }
            catch
            {
            }
        }

        protected void bt_excluir_click(object sender, EventArgs e)
        {
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean deletar = operacao.Delete("delete from Tbl_Motoboys where ID_Motoboy =" + lbl_id.Text);
                ConexaoBancoSQL.fecharConexao();
                if (deletar == true)
                {
                    atualiza_grid();
                    totalderegistros();
                }
            }
            catch
            {
            }
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
            //modal edit delete  - preenche campos
            txt_edit_nome.Text = GridView2.SelectedRow.Cells[0].Text;
            txt_edit_email.Text = GridView2.SelectedRow.Cells[1].Text;
            txt_edit_telefone.Text = GridView2.SelectedRow.Cells[2].Text;
            txt_edit_whatsapp.Text = GridView2.SelectedRow.Cells[3].Text;
            txt_edit_veiculo.Text = GridView2.SelectedRow.Cells[4].Text;
            txt_edit_modelo.Text = GridView2.SelectedRow.Cells[5].Text;
            txt_edit_placa.Text = GridView2.SelectedRow.Cells[6].Text;
            lbl_id.Text = GridView2.SelectedRow.Cells[7].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}