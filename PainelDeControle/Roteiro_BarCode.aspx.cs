using System;
using System.Text;

public partial class Roteiro_BarCode : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        string idAux = Request.QueryString["p1"];
        Carrega_Cidades(idAux);
        Grid_Roteiros(idAux);
        Preenche_dados(idAux);
        Preenche_AutoComplete();
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

    private void Preenche_dados(string param1)
    {
        str.Clear();
        string scrAux = "<script type=\"text/javascript\">";
        str.Append(scrAux);

        scrAux = "document.getElementById('ID_Cli_Hidden').value = \"" + param1 + "\";";
        str.Append(scrAux);

        scrAux = "</script>";
        str.Append(scrAux);
        Literal_aux.Text = str.ToString();

    }

    private void Grid_Roteiros(string idaux)
    {
        string stringSelect = "select ID_Entrega, Endereco, Bairro , Cidade, valor_Encomenda " +
          " from Tbl_Entregas " +
          " where ID_Cliente = " + idaux +
          " and Status_Entrega = 'EM ABERTO'" +
          " order by Bairro, Endereco";
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

    private void Preenche_AutoComplete()
    {
        string TagIni = "", TagFim = "", TagNomes = "", TagAutocompNome = "";
        str.Clear();

        //bairro
        string stringselect = "select Bairro from Tbl_Entregas group by Bairro";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            str.Append("\"" + Convert.ToString(dados[0]) + "\",");
        }
        ConexaoBancoSQL.fecharConexao();

        TagIni = "<script> $(function() {";
        TagNomes = "var TagsNomes = [" + str.ToString() + "];";
        TagAutocompNome = "$(\"#input1\").autocomplete({source: TagsNomes}); ";
        TagFim = "});</script> ";

        Literal_AutoComplete.Text = TagIni + TagNomes + TagAutocompNome + TagFim;

    }
}
