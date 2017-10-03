using System;
using System.Text;


public partial class Roteiros : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id_Cli = Request.QueryString["v1"];  // id do cliente
            string id_Mot = Request.QueryString["v2"];  // id do motoboy
            string nome_cli = Request.QueryString["v3"];  // nome cliente
            string nome_mot = Request.QueryString["v4"];  // nome motoboy

            Carrega_Cidades(id_Cli);
            Preenche_dados(id_Cli, nome_cli, id_Mot, nome_mot);

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

}