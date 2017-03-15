using System;
using System.Text;

public partial class Abastecimento_Relatorios : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PreencheVeiculos();
            Literal_Veiculos.Text = str.ToString();
        }
    }

    private void PreencheVeiculos()
    {
        str.Clear();
        str.Append("<select class=\"form-control\" id=\"inputPlaca\" name=\"inputPlaca\">");
        str.Append("<option></option>");

        string stringSelect = "select Placa from Tbl_Veiculos order by Placa";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            str.Append("<option>" + Convert.ToString(rcrdset[0]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();
        str.Append("</select>");
    }
}