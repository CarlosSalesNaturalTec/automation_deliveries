using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace automation_deliveries_client
{
    public partial class Cad_Entregas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtData.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    txt_data.Text = DateTime.Today.ToString("dd/MM/yyyy");

                    Preenche_Combo();                    
                    atualiza_grid();
                    totalderegistros();
                }
            }
            catch { }
        }

        public void totalderegistros()
        {
            // validações
            if (!ValidaData(txtData.Text) == true)
            {
                lbl_mensagem.Text = "ATENÇÃO! DATA INVÁLIDA";
                return;
            }

            // string data da encomenda
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(txtData.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            // filtro funcionário
            string stringSelect = "";
            if (cmb_funcionario.SelectedItem.Value == "-1")
            {
                stringSelect = @"SELECT COUNT(*) AS totalderegistros FROM Tbl_Entregas where " +
                "ID_Cliente= " + Session["ID_Cliente"].ToString() + " and Data_Encomenda='" + date_formated + "'";
            }
            else
            {
                stringSelect = @"SELECT COUNT(*) AS totalderegistros FROM Tbl_Entregas where " +
                "ID_Motoboy= " + cmb_funcionario.SelectedItem.Value + " and Data_Encomenda='" + date_formated + "'";
            }

            // total de registros cadastrados
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringSelect);
            String totalderegistros = "";
            try
            {
                while (dados.Read())
                {
                    totalderegistros = Convert.ToString(dados[0]);
                    lbl_total_entregas.Text = totalderegistros;
                }
            }
            catch (Exception)
            {
                throw;
            }
            ConexaoBancoSQL.fecharConexao();
        }

        private void Preenche_Combo()
        {
            // combo funcionarios - filtro
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados1 = operacao.Select(@"select ID_Motoboy, Nome from Tbl_Motoboys where " +
                "ID_Cliente=" +  Session["ID_Cliente"].ToString() + " order by Nome");
            cmb_funcionario.DataSource = dados1;
            cmb_funcionario.DataTextField = "Nome";
            cmb_funcionario.DataValueField = "ID_Motoboy";
            cmb_funcionario.DataBind();
            ConexaoBancoSQL.fecharConexao();
            cmb_funcionario.Items.Insert(0, new ListItem("TODOS OS FUNCIONÁRIOS", "-1"));
            cmb_funcionario.SelectedIndex = Convert.ToInt32("-1");

            // combo funcionarios - modal NOVO
            operacao = new OperacaoBanco();
            dados1 = operacao.Select(@"select ID_Motoboy, Nome from Tbl_Motoboys where " +
                "ID_Cliente=" + Session["ID_Cliente"].ToString() + " order by Nome");
            cmb_func_modal.DataSource = dados1;
            cmb_func_modal.DataTextField = "Nome";
            cmb_func_modal.DataValueField = "ID_Motoboy";
            cmb_func_modal.DataBind();
            ConexaoBancoSQL.fecharConexao();
            cmb_func_modal.Items.Insert(0, new ListItem("SELECIONE FUNCIONÁRIO", "-1"));
            cmb_func_modal.SelectedIndex = Convert.ToInt32("-1");


            // combo funcionarios - Modal EDIT
            operacao = new OperacaoBanco();
            dados1 = operacao.Select(@"select ID_Motoboy, Nome from Tbl_Motoboys where " +
                "ID_Cliente=" + Session["ID_Cliente"].ToString() + " order by Nome");
            cmb_edit_func.DataSource = dados1;
            cmb_edit_func.DataTextField = "Nome";
            cmb_edit_func.DataValueField = "ID_Motoboy";
            cmb_edit_func.DataBind();
            ConexaoBancoSQL.fecharConexao();
            cmb_edit_func.Items.Insert(0, new ListItem("SELECIONE FUNCIONÁRIO", "-1"));
            cmb_edit_func.SelectedIndex = Convert.ToInt32("-1");
        }

        protected bool ValidaData(String date)
        {
            try
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
                DateTime dt2 = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void atualiza_grid()
        {
            // validações
            if (!ValidaData(txtData.Text) == true)
            {
                lbl_mensagem.Text = "ATENÇÃO! DATA INVÁLIDA";
                return;
            }

            // string com data selecionada - máscara padrão SQL
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(txtData.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            // filtro funcionário
            string stringSelect = "";
            if (cmb_funcionario.SelectedItem.Value == "-1")
            {
                stringSelect = @"select Tbl_Entregas.ID_Motoboy, Tbl_Motoboys.Nome, Tbl_Entregas.Id_Entrega, Tbl_Entregas.Nome_Destinatario, " +
                    " Tbl_Entregas.Endereco, Tbl_Entregas.Bairro, Tbl_Entregas.Cidade, " +
                    " Tbl_Entregas.Telefone, Tbl_Entregas.Data_Encomenda, Tbl_Entregas.Cod_Encomenda, Tbl_Entregas.Status_Entrega from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["ID_Cliente"].ToString() +
                    " and Tbl_Entregas.Data_Encomenda = '" + date_formated + "'" +
                    " order by Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario";
            }
            else
            {
                stringSelect = @"select Tbl_Entregas.ID_Motoboy, Tbl_Motoboys.Nome, Tbl_Entregas.Id_Entrega, Tbl_Entregas.Nome_Destinatario, " +
                    " Tbl_Entregas.Endereco, Tbl_Entregas.Bairro, Tbl_Entregas.Cidade, " +
                    " Tbl_Entregas.Telefone, Tbl_Entregas.Data_Encomenda, Tbl_Entregas.Cod_Encomenda, Tbl_Entregas.Status_Entrega from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Motoboy = " + cmb_funcionario.SelectedItem.Value +
                    " and Tbl_Entregas.Data_Encomenda = '" + date_formated + "'" +
                    " order by Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario";
            }

            // listagem de ENTREGAS 
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            GridView2.DataSource = rcrdset;
            GridView2.DataBind();
            ConexaoBancoSQL.fecharConexao();
        }

        protected void bt_novo_salvar_click(object sender, EventArgs e)
        {
            // verifica ID do FUncionário
            string id_selecionada = cmb_func_modal.SelectedItem.Value;
            lbl_mensagem.Text = "";
            if (id_selecionada == "-1")
            {
                lbl_mensagem.Text = "ATENÇÃO! Selecione um Funcionário para adicionar uma Entrega";
                return;
            }

            // string data da encomenda
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(txt_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            // string INSERT
            string stringinsert = @"INSERT INTO Tbl_Entregas (ID_Cliente, ID_Motoboy, Nome_Destinatario, Endereco, Ponto_Ref, " +
                    "Bairro, Cidade, Cod_Encomenda, Data_Encomenda, Telefone, Entregue, Observacoes) VALUES (" + Session["ID_Cliente"].ToString() +
                    "," + id_selecionada + ", '" + txt_nome.Text + "', '" + txt_end.Text + "', '" + txt_ref.Text +
                    "', '" + txt_bairro.Text + "', '" + txt_cidade.Text + "', '" + txt_encom.Text +
                    "', '" + date_formated + "', '" + txt_telefone.Text + "', 0, '" + txt_obs.Text + "')";
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                bool inserir = operacao.Insert(stringinsert);
                ConexaoBancoSQL.fecharConexao();

                txt_nome.Text = "";
                txt_end.Text = "";
                txt_ref.Text = "";
                txt_bairro.Text = "";
                txt_encom.Text = "";
                txt_telefone.Text = "";
                txt_obs.Text = "";

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
            // verifica ID do FUncionário
            string id_selecionada = cmb_edit_func.SelectedItem.Value;
            lbl_mensagem.Text = "";
            if (id_selecionada == "-1")
            {
                lbl_mensagem.Text = "ATENÇÃO! Selecione um Funcionário";
                return;
            }

            // string data da encomenda
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(txt_edit_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            //string update
            string stringupdate = @"update Tbl_Entregas set ID_Motoboy = " + id_selecionada + ", Nome_Destinatario = '" + txt_edit_nome.Text + "'," +
                " Endereco = '" + txt_edit_end.Text + "', Ponto_Ref = '" + txt_edit_ref.Text + "', Bairro = '" + txt_edit_bairro.Text + "', " +
                " Cidade = '" + txt_edit_cidade.Text + "', telefone = '" + txt_edit_tel.Text + "', Data_Encomenda = '" + date_formated + "', " +
                " Cod_Encomenda = '" + txt_edit_encom.Text + "', Observacoes = '" + txt_edit_obs.Text + "'" +
                " where ID_Entrega =" + lbl_id.Text ;

            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean update = operacao.Update(stringupdate);
                ConexaoBancoSQL.fecharConexao();
                if (update == true)
                {
                    atualiza_grid();
                }
            }
            catch
            {
                lbl_mensagem.Text = "ATENÇÃO! Não foi possível atualizar";
            }
        }

        protected void bt_excluir_click(object sender, EventArgs e)
        {
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean deletar = operacao.Delete("delete from Tbl_Entregas where ID_Entrega =" + lbl_id.Text);
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
            txt_edit_nome.Text = GridView2.SelectedRow.Cells[1].Text;
            txt_edit_end.Text = GridView2.SelectedRow.Cells[2].Text;
            txt_edit_bairro.Text = GridView2.SelectedRow.Cells[3].Text;
            txt_edit_cidade.Text = GridView2.SelectedRow.Cells[4].Text;
            txt_edit_tel.Text = GridView2.SelectedRow.Cells[5].Text;
            txt_edit_data.Text = GridView2.SelectedRow.Cells[6].Text;
            txt_edit_encom.Text = GridView2.SelectedRow.Cells[7].Text;
            lbl_id.Text = GridView2.SelectedRow.Cells[9].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void cmb_funcionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualiza_grid();
            totalderegistros();
        }

        protected void txtData_TextChanged(object sender, EventArgs e)
        {
            atualiza_grid();
            totalderegistros();
        }
    }
}