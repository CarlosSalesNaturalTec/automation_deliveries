using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_Planilha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LimpaTabela();
            InsereDebitos();
            InsereCreditos();

            CalculaTotais();
        }
    }

    private void LimpaTabela()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("DELETE FROM Tbl_Abastecimento_Planilha");
    }

    private void InsereDebitos()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        string stringinsert = @"INSERT INTO Tbl_Abastecimento_Planilha (DataOperacao,Valor,Motorista ,Placa ,Kilometragem ,  Evento )
                            SELECT DataAutoriza, Valor,Nome , Placa, Kilometragem, 'ABASTECIMENTO'
                            FROM Tbl_Abastecimentos";
        Boolean inserir = operacao.Insert(stringinsert);
    }

    private void InsereCreditos()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        string stringinsert = @"INSERT INTO Tbl_Abastecimento_Planilha (DataOperacao,Valor,Evento )
                            SELECT DataCredito , Valor, 'DEPOSITO'
                            FROM Tbl_Abastecimentos_Creditos;";
        Boolean inserir = operacao.Insert(stringinsert);
    }

    private void CalculaTotais()
    {
        string stringselect = "select Evento , Valor " +
                " from Tbl_Abastecimento_Planilha" +
                " order by DataOperacao";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        decimal saldo = 0, totalCR = 0, TotalDB = 0;

        while (dados.Read())
        {
            string Coluna3 = Convert.ToString(dados[0]);  //evento
            string valorSTR = Convert.ToString(dados[1]); //valor - auxiliar

            decimal valor = Convert.ToDecimal(valorSTR);
            string evento = Coluna3;

            if (evento == "DEPOSITO")
            {
                saldo = saldo + valor;
                totalCR = totalCR + valor;
            }
            else
            {
                saldo = saldo - valor;
                TotalDB = TotalDB + valor;
            }
        }
        ConexaoBancoSQL.fecharConexao();

        Literal_Saldo.Text = "R$ " + saldo.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
        Literal_TotalCR.Text = "R$ " + totalCR.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
        Literal_TotalDB.Text = "R$ " + TotalDB.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));
        Literal_Rel.Text = " ";

    }


}