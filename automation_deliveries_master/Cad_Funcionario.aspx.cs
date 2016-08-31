using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace automation_deliveries_master
{
    public partial class Cad_Funcionario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Preenche_Combo();
                    totalderegistros();
                }
            }
            catch { }
        }

        private void Preenche_Combo()
        {
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados1 = operacao.Select("select ID_Cliente,Nome from Tbl_Clientes order by Nome");
            cmb_cliente.DataSource = dados1;
            cmb_cliente.DataTextField = "Nome";
            cmb_cliente.DataValueField = "ID_Cliente";
            cmb_cliente.DataBind();

            cmb_cliente.Items.Insert(0, new ListItem("Selecione um Cliente", "-1"));
            cmb_cliente.SelectedIndex = Convert.ToInt32("-1");

        }

        public void totalderegistros()
        {
            // total de registros cadastrados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT COUNT(*) AS totalderegistros FROM Tbl_Motoboys;");
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

        public void totalderegistros_selecao()
        {
            // total de registros do item selecionado
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT COUNT(*) AS totalderegistros FROM Tbl_Motoboys where ID_Cliente = " + cmb_cliente.SelectedItem.Value );
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

        public void atualiza_grid_selecao()
        {
            // listagem de funcionarios por cliente
            OperacaoBanco operacao = new OperacaoBanco();
            string stringSelect = "select * from Tbl_Motoboys where ID_Cliente = " + cmb_cliente.SelectedItem.Value + " order by Nome";
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            GridView2.DataSource = rcrdset;
            GridView2.DataBind();
            ConexaoBancoSQL.fecharConexao();
        }

        protected void bt_novo_salvar_click(object sender, EventArgs e)
        {
            string id_selecionada = cmb_cliente.SelectedItem.Value;
            if (id_selecionada == "-1") 
            {
                lbl_cliente.Text = "ATENÇÃO! Selecione um Cliente para adicionar Funcionário";
                return;
            }

            try
            {   
                OperacaoBanco operacao = new OperacaoBanco();
                bool inserir = operacao.Insert(@"INSERT INTO Tbl_Motoboys (ID_Cliente, Nome, email, Telefone, " +
                    "WhatsApp, Veiculo, Modelo, Placa) VALUES (" + cmb_cliente.SelectedItem.Value + 
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
                    atualiza_grid_selecao();
                    totalderegistros_selecao();
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
                    atualiza_grid_selecao();
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
                    atualiza_grid_selecao();
                    totalderegistros_selecao();
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

        protected void cmb_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cliente selecionado   
            lbl_cliente.Text = "Funcionários de : " + cmb_cliente.SelectedItem.Text;
            txt_cliente_modal_novo.Text = cmb_cliente.SelectedItem.Text;

            atualiza_grid_selecao();
            totalderegistros_selecao();

        }
    }
}