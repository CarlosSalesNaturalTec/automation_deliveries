using System;
using System.Globalization;
using System.Text;

public partial class Home : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

        string link, textolink;

        // Monta Blocos
        //===========================================
        link = "Abastecimento_Planilha.aspx";
        textolink = "Detalhes";
        Bloco1_MontaInfo();
        Bloco1_MontaLink(link, textolink);

        link = "Abastecimento_Local_Listagem.aspx";
        textolink = "Detalhes";
        Bloco2_MontaInfo();
        Bloco2_MontaLink(link, textolink);


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

        Bloco1_Info.Text = "<span class=\"small\"> R$ " + Saldo.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</span>";

    }

    private void Bloco1_MontaLink(string url, string txtLink)
    {
        Bloco1_Link.Text = "<i class=\"fa fa-plus-square-o\"></i>&nbsp;&nbsp;<a href='" + url + "'>" + txtLink + "</a>";
    }



    private void Bloco2_MontaInfo()
    {
        // Total de Abastecimentos
        decimal ValorTotal = 0;
        string mesAtual = DateTime.Now.ToString("MM-yyyy");

        string stringselect = "SELECT format(Data_Abastecimento,'MM-yyyy') as d1, sum(valor) as t1 " +
            "from Tbl_Abastecimento_Local  " +
            "where format(Data_Abastecimento ,'MM-yyyy') = '" + mesAtual +"' " +
            "group by format(Data_Abastecimento ,'MM-yyyy')";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
        while (dados.Read())
        {
            ValorTotal = Convert.ToDecimal(dados[1]);
        }
        ConexaoBancoSQL.fecharConexao();

        Bloco2_Info.Text = "<span class=\"small\"> R$ " + ValorTotal.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</span>";

    }

    private void Bloco2_MontaLink(string url, string txtLink)
    {
        Bloco2_Link.Text = "<i class=\"fa fa-plus-square-o\"></i>&nbsp;&nbsp;<a href='" + url + "'>" + txtLink + "</a>";
    }

}