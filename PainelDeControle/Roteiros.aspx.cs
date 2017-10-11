using System;
using System.Text;


public partial class Roteiros : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    string id_Mot, id_Cli;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id_Cli = Request.QueryString["v1"];  // id do cliente
            id_Mot = Request.QueryString["v2"];  // id do motoboy
            string nome_cli = Request.QueryString["v3"];  // nome cliente
            string nome_mot = Request.QueryString["v4"];  // nome motoboy

            Carrega_Cidades(id_Cli);
            Preenche_dados(id_Cli, nome_cli, id_Mot, nome_mot);
            Grid_Roteiros();
        }
    }

    private void Carrega_Cidades(string idaux)
    {
        string stringSelect = "select Cidade, Valor from Tbl_Clientes_Cidade_Custos" +
            " where ID_Cliente = " + idaux +
            " order by Cidade";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        str.Clear();
        string scrNome = "<select class=\"form-control\" id=\"select_Cidade\">";
        str.Append(scrNome);

        scrNome = "<option value=\"0\">Selecione uma Cidade</option>";
        str.Append(scrNome);


        while (rcrdset.Read())
        {
            scrNome = "<option value=\"" + Convert.ToString(rcrdset[1]) + "\">" + Convert.ToString(rcrdset[0]) + "</option>";
            str.Append(scrNome);
        }
        ConexaoBancoSQL.fecharConexao();

        scrNome = "</select>";
        str.Append(scrNome);
        Literal_Cidade.Text = str.ToString();
    }

    private void Preenche_dados(string param1, string param2, string param3, string param4)
    {
        str.Clear();
        string scrAux = "<script type=\"text/javascript\">";
        str.Append(scrAux);

        scrAux = "document.getElementById('ID_Cli_Hidden').value = \"" + param1 + "\";";
        str.Append(scrAux);

        scrAux = "document.getElementById('lbl_cliente').value = \"" + param2 + "\";";
        str.Append(scrAux);

        scrAux = "document.getElementById('ID_Mot_Hidden').value = \"" + param3 + "\";";
        str.Append(scrAux);

        scrAux = "document.getElementById('lbl_motoboy').value = \"" + param4 + "\";";
        str.Append(scrAux);

        scrAux = "</script>";
        str.Append(scrAux);
        Literal_aux.Text = str.ToString();

    }

    private void Grid_Roteiros()
    {
        string stringSelect = "select ID_Entrega, Nome_Destinatario, Endereco, Bairro , Cidade, Latitude , Longitude " +
          " from Tbl_Entregas " +
          " where ID_Motoboy  = " + id_Mot +
          " and Status_Entrega = 'EM ABERTO'" +
          " order by Bairro, Nome_Destinatario";
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

            ScriptDados = "<td>" + bt1 + Convert.ToString(rcrdsetUsers[1]) + "</td>";
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