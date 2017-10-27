using System;
using System.Globalization;
using System.Text;

public partial class Home : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Bloco1_MontaInfo();
        Bloco2_MontaInfo();
        Bloco3_MontaInfo();
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


    private void Bloco3_MontaInfo()
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

        Bloco3_Info.Text = "<span class=\"small\">(" + quantTotal + ")</span>";

    }


}