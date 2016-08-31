using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace automation_deliveries_master
{
    public partial class Cad_Clientes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               total_clientes();
               atualiza_grid();
            }
            catch {
            }
        }

        public void total_clientes()
        {
            // total de Clientes cadastrados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT COUNT(*) AS totaldeclientes FROM Tbl_Clientes;");
            String totaldeclientes = "";
            while (dados.Read())
            {
                totaldeclientes = Convert.ToString(dados[0]);
                lbl_total_clientes.Text = totaldeclientes;
            }
            ConexaoBancoSQL.fecharConexao();
        }

        public void atualiza_grid()
        {
            // listagem de Clientes
            OperacaoBanco operacao = new OperacaoBanco();
            string stringSelect = "select * from Tbl_Clientes order by Nome";
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
                Boolean inserir = operacao.Insert(@"INSERT INTO Tbl_Clientes (Nome, email, Telefone, Responsavel, Area_Unidade) " +
                    "VALUES ('"+ txt_nome.Text + "', '" + txt_email.Text + "', '" + txt_telefone.Text 
                    + "', '"+ txt_responsavel.Text + "', '" + txt_area_und.Text + "');");
                ConexaoBancoSQL.fecharConexao();

                txt_nome.Text = "";
                txt_email.Text = "";
                txt_telefone.Text = "";
                txt_responsavel.Text = "";
                txt_area_und.Text = "";

                if (inserir == true)
                {
                    total_clientes();
                    atualiza_grid();
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
                Boolean update = operacao.Update(@"UPDATE Tbl_Clientes SET Nome='" + txt_edit_nome.Text + "', Responsavel='" + 
                    txt_edit_responsavel.Text + "', email = '" + txt_edit_email.Text + "', telefone = '" + txt_edit_telefone.Text + 
                    "', Area_Unidade = '" + txt_edit_area_und.Text + "' WHERE ID_Cliente=" + lbl_id.Text + ";");
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
                Boolean deletar = operacao.Delete("delete from Tbl_Clientes where ID_Cliente =" + lbl_id.Text);
                ConexaoBancoSQL.fecharConexao();
                if (deletar == true)
                {
                    total_clientes();
                    atualiza_grid();
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
            txt_edit_responsavel.Text = GridView2.SelectedRow.Cells[3].Text;
            txt_edit_area_und.Text = GridView2.SelectedRow.Cells[4].Text;
            lbl_id.Text = GridView2.SelectedRow.Cells[5].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}