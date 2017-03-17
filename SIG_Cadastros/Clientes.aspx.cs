using System;
using System.Text;

public partial class Clientes : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    int TotalRegistros = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Quant total de registros
            ContagemRegistros();
            Literal_Quant.Text = TotalRegistros.ToString();
        }
    }

    
    private void ContagemRegistros()
    {
        //atenção mudar select para COunt
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = @"select ID_Cliente " +
                " from Tbl_Clientes where nivel = 2" +
                " order by Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            TotalRegistros++;
        }
        ConexaoBancoSQL.fecharConexao();
        
    }


}