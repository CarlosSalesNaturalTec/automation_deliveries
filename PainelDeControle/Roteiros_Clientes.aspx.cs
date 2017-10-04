using System;
using System.Text;

public partial class Roteiros_Clientes : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Preenche_Empresas();
            Preenche_Motoboy();
            Grid_Roteiros();
        }
    }

    private void Preenche_Empresas()
    {
        string stringSelect = @"select ID_Cliente, Nome from Tbl_Clientes order by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        str.Clear();
        string scrNome = "<select class=\"form-control\" id=\"select_empresa\">";
        str.Append(scrNome);

        scrNome = "<option value=\"0\">Selecione um Cliente</option>";
        str.Append(scrNome);

        while (rcrdset.Read())
        {
            scrNome = "<option value=\"" + Convert.ToString(rcrdset[0]) + "\">" + Convert.ToString(rcrdset[1]) + "</option>";
            str.Append(scrNome);
        }
        ConexaoBancoSQL.fecharConexao();

        scrNome = "</select>";
        str.Append(scrNome);
        Literal_Empresa.Text = str.ToString();

    }

    private void Preenche_Motoboy()
    {
        string stringSelect = @"select ID_Motoboy, Nome from Tbl_Motoboys order by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        str.Clear();
        string scrNome = "<select class=\"form-control\" id=\"select_motoboy\">";
        str.Append(scrNome);

        scrNome = "<option value=\"0\">Selecione um Motoboy</option>";
        str.Append(scrNome);

        while (rcrdset.Read())
        {
            scrNome = "<option value=\"" + Convert.ToString(rcrdset[0]) + "\">" + Convert.ToString(rcrdset[1]) + "</option>";
            str.Append(scrNome);
        }
        ConexaoBancoSQL.fecharConexao();

        scrNome = "</select>";
        str.Append(scrNome);
        Literal_Motoboy.Text = str.ToString();

    }

    private void Grid_Roteiros()
    {
        string stringSelect = "SELECT Tbl_Entregas.ID_Entrega, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Bairro , Tbl_Entregas.Cidade , Tbl_Entregas.valor_Encomenda, " +
            "Tbl_Clientes.Nome, Tbl_Motoboys.Nome " +
            "FROM ((Tbl_Entregas " +
            "INNER JOIN Tbl_Clientes ON Tbl_Entregas.ID_Cliente = Tbl_Clientes.ID_Cliente) " +
            "INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy) " +
            "where Tbl_Entregas.Status_Entrega='EM ABERTO' " +
            "order by Tbl_Clientes.Nome, Tbl_Motoboys.Nome  ;";
        
        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;

        while (rcrdsetUsers.Read())
        {
            string bt1 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Roteiro_Excluir(this," +
                Convert.ToString(rcrdsetUsers[0]) +
                ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[5]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[6]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[2]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[3]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[4]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal2.Text = str.ToString();
    }

}