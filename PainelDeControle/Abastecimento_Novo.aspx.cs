using System;
using System.Text;

public partial class Abastecimento_Novo : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PreeencheEntregadores();
            LIteral_Colaborador.Text = str.ToString();

            PreencheVeiculos();
            LIteral_Veiculos.Text = str.ToString();
        }
    }

    private void PreeencheEntregadores() {

        str.Clear();
        str.Append("<div class=\"form-group\">");
        str.Append("<label for=\"inputNome\" class=\"col-md-1 control-label\">Nome</label>");
        str.Append("<div class=\"col-md-8\">");
        str.Append("<select class=\"form-control\" id=\"inputNome\" name=\"inputNome\">");
        str.Append("<option></option>");

        string stringSelect = "select Nome from Tbl_Motoboys where ID_Cliente = 222 order by nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            str.Append("<option>" + Convert.ToString(rcrdset[0]) + "</option>");
        }
        ConexaoBancoSQL.fecharConexao();
        str.Append("</select></div></div>");

    }

    private void PreencheVeiculos()
    {
        str.Clear();
        str.Append("<div class=\"form-group\">");
        str.Append("<label for=\"inputPlaca\" class=\"col-md-1 control-label\">Placa</label>");
        str.Append("<div class=\"col-md-8\">");
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
        str.Append("</select></div></div>");
    }

}