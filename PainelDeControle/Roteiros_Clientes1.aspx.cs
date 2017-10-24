using System;
using System.Globalization;
using System.Text;

public partial class Roteiros_Clientes1 : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    StringBuilder str_2 = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Preenche_Empresas();
            Entregas_Bairro();
            Entregas_Realizar();
            Entregas_Pcontas();
        }
    }

    private void Preenche_Empresas()
    {
        string stringSelect = @"select ID_Cliente, Nome from Tbl_Clientes order by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        str.Clear();
        str_2.Clear();

        string scrNome = "<select class=\"form-control\" id=\"select_empresa\">";
        str.Append(scrNome);
        scrNome = "<select class=\"form-control\" id=\"select_empresa2\">";
        str_2.Append(scrNome);

        scrNome = "<option value=\"0\">Selecione um Cliente</option>";
        str.Append(scrNome);
        str_2.Append(scrNome);

        while (rcrdset.Read())
        {
            scrNome = "<option value=\"" + Convert.ToString(rcrdset[0]) + "\">" + Convert.ToString(rcrdset[1]) + "</option>";
            str.Append(scrNome);
            str_2.Append(scrNome);
        }
        ConexaoBancoSQL.fecharConexao();

        scrNome = "</select>";
        str.Append(scrNome);
        str_2.Append(scrNome);

        Literal_Empresa.Text = str.ToString();
        Literal_Empresa1.Text = str_2.ToString();

    }

    private void Entregas_Bairro()
    {
        string stringSelect = "select count(ID_Entrega) as quant from Tbl_Entregas where ID_Motoboy = 0 ";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        string quantTotal = "0";

        while (rcrdset.Read())
        {
            quantTotal = Convert.ToString(rcrdset[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_quadro1.Text = "(" + quantTotal + ")";

    }

    private void Entregas_Realizar()
    {
        string stringSelect = "select count(ID_Entrega) as quant from Tbl_Entregas where Status_Entrega = 'EM ABERTO' and Encerrada = 0 and ID_Motoboy <> 0 ";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        string quantTotal = "0";

        while (rcrdset.Read())
        {
            quantTotal = Convert.ToString(rcrdset[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_quadro2.Text = "(" + quantTotal + ")";

    }

    private void Entregas_Pcontas()
    {
        string stringSelect = "select sum(valor_Cliente) as valorT from Tbl_Entregas where Pcontas = 0 and Status_Entrega = 'ENTREGA REALIZADA'";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        string valortotal = "0";

        while (rcrdset.Read())
        {
            valortotal = Convert.ToString(rcrdset[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_quadro3.Text = "(R$ " + valortotal + ")";

    }

}