using System;
using System.Globalization;
using System.Text;

public partial class Home : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        // Personalizáveis
        //===========================================
        string link1 = "Abastecimento_Planilha.aspx";
        string textolink1 = "Detalhes";


        // Monta Blocos
        //===========================================
        Bloco1_MontaInfo();
        Bloco1_MontaLink(link1, textolink1);

        
    }

    private void Bloco1_MontaLink(string url, string txtLink)
    {
        Bloco1_Link.Text = "<a href='" + url + "'>" + txtLink + "&nbsp;<i class=\"fa fa-arrow-circle-right\"></i></a>&nbsp;&nbsp;";
    }

    private void Bloco1_MontaInfo()
    {
        // Total de Abastecimentos
        decimal TotalDB = 0;
        string stringselect = "select sum(Valor) as ValorTotal from Tbl_Abastecimentos";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            TotalDB = Convert.ToDecimal(dados[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        // Total de créditos
        decimal TotalCR = 0;
        stringselect = "select sum(Valor) as ValorTotal from Tbl_Abastecimentos_Creditos";
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados1 = operacao1.Select(stringselect);
        while (dados1.Read())
        {
            TotalCR = Convert.ToDecimal(dados1[0]);
        }
        ConexaoBancoSQL.fecharConexao();

        Decimal Saldo = TotalCR - TotalDB;

        Bloco1_Info.Text = "R$ " + Saldo.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
        
    }

    
}