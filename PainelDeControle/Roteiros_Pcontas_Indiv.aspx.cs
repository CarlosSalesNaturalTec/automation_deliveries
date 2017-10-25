using System;
using System.Globalization;
using System.Text;

public partial class Roteiros_Pcontas_Indiv : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string idAux = Request.QueryString["p1"];
            string nomeAux = Request.QueryString["p2"];
            PreencheCampos(idAux, nomeAux);

            grid_realizadas(idAux);
            grid_nao_realizadas(idAux);
            lbl_motoboy.Text = "Motoboy: " + nomeAux;

        }
    }

    private void grid_realizadas(string param1)
    {
        string stringselect = "select Tbl_Clientes.Nome, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Endereco, " +
                "Tbl_Entregas.Bairro , Tbl_Entregas.Cidade, Tbl_Entregas.valor_Cliente, Tbl_Entregas.ID_Entrega " +
                "from Tbl_Entregas " +
                "inner join Tbl_Clientes ON Tbl_Entregas.ID_Cliente = Tbl_Clientes.ID_Cliente " +
                "where Tbl_Entregas.ID_Motoboy = " + param1 + " and " +
                "Tbl_Entregas.Status_Entrega = 'ENTREGA REALIZADA' and Pcontas = 0 " +
                "order by Tbl_Entregas.Bairro , Tbl_Entregas.Endereco";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        decimal totalPconta = 0;

        while (dados.Read())
        {
            // <!--*******Customização*******-->
            string Coluna1 = Convert.ToString(dados[0]);
            string Coluna2 = Convert.ToString(dados[1]);
            string Coluna3 = Convert.ToString(dados[2]);
            string Coluna4 = Convert.ToString(dados[3]);
            string Coluna5 = Convert.ToString(dados[4]);

            string Coluna6 = Convert.ToString(dados[5]);
            decimal Coluna6a = Convert.ToDecimal(dados[5]);

            totalPconta = totalPconta + Convert.ToDecimal(dados[5]);

            string bt1 = "<input type='checkbox'class='w3-check' name='chkselecao' value='" + Convert.ToString(dados[6]) + "' />&nbsp;&nbsp;&nbsp;";

            // <!--*******Customização*******-->
            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6a.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();

        literal_realizadas.Text = str.ToString();

        lbl_totalPconta.Text = "Valor Total : R$ " + totalPconta.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
    }

    private void grid_nao_realizadas(string param1)
    {
        string stringselect = "select Tbl_Clientes.Nome, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Endereco, Tbl_Entregas.Bairro , " +
                "Tbl_Entregas.Cidade, Tbl_Entregas.valor_Cliente, Tbl_Entregas.Status_Entrega " +
                "from Tbl_Entregas " +
                "inner join Tbl_Clientes ON Tbl_Entregas.ID_Cliente = Tbl_Clientes.ID_Cliente " +
                "where Tbl_Entregas.ID_Motoboy = " + param1 + " and " +
                "Tbl_Entregas.Status_Entrega <> 'ENTREGA REALIZADA' and Pcontas = 0 " +
                "order by Tbl_Entregas.Bairro , Tbl_Entregas.Endereco";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        str.Clear();

        while (dados.Read())
        {
            // <!--*******Customização*******-->
            string Coluna1 = Convert.ToString(dados[0]);
            string Coluna2 = Convert.ToString(dados[1]);
            string Coluna3 = Convert.ToString(dados[2]);
            string Coluna4 = Convert.ToString(dados[3]);
            string Coluna5 = Convert.ToString(dados[4]);
            string Coluna6 = Convert.ToString(dados[5]);
            string Coluna7 = Convert.ToString(dados[6]);

            // <!--*******Customização*******-->
            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();

        literal_nao_Realizadas.Text = str.ToString();

    }

    private void PreencheCampos(string ID, string AuxNome)
    {
        string ScriptDados = "<script type=\"text/javascript\">" +
            "document.getElementById('idAuxHidden').value = \"" + ID + "\";" +
            "document.getElementById('nomeAuxHidden').value = \"" + AuxNome + "\";" +
            "</script>";

        Literal_Aux.Text = ScriptDados;
    }
}