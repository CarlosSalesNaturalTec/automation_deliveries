using System;

public partial class Orcamento_printer : System.Web.UI.Page
{

    string dados_Cliente, dados_Contato, dados_Roteiro;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Dados_Orcamento(Request.QueryString["IDOrc"]);

            Local_e_Data();
            Literal_Cliente.Text = dados_Cliente;
            Literal_Contato.Text = dados_Contato;
            Literal_Cidades.Text = dados_Roteiro;
            Literal_Roteiro.Text = dados_Roteiro;


        }
    }

    public void Local_e_Data()
    {
        string local = "Salvador(Ba)";
        string dia = DateTime.Now.ToString("dd");
        string mes = DateTime.Now.ToString("MM");
        string ano = DateTime.Now.ToString("yyyy");

        Literal_Local_Data.Text = local + "," + dia + " de " + mes_formated(Convert.ToInt16(mes)) + " de " + ano;
    }

    public string mes_formated(int mesnum)
    {
        string mes = "";

        switch (mesnum)
        {
            case 1:
                mes = "Janeiro";
                break;
            case 2:
                mes = "Fevereiro";
                break;
            case 3:
                mes = "Março";
                break;
            case 4:
                mes = "Abril";
                break;
            case 5:
                mes = "Maio";
                break;
            case 6:
                mes = "Junho";
                break;
            case 7:
                mes = "Julho";
                break;
            case 8:
                mes = "Agosto";
                break;
            case 9:
                mes = "Setembro";
                break;
            case 10:
                mes = "Outubro";
                break;
            case 11:
                mes = "Novembro";
                break;
            case 12:
                mes = "Dezembro";
                break;
        }

        return mes;

    }

    public void Dados_Orcamento(string IDOrc)
    {
        string stringSelect = "select Empresa, Contato, Roteiro  " +
            "from Tbl_Orcamentos where ID_Solicitacao = " + IDOrc;

        OperacaoBanco operacaoOrc = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetORC = operacaoOrc.Select(stringSelect);
        while (rcrdsetORC.Read())
        {
            dados_Cliente = Convert.ToString(rcrdsetORC[0]);
            dados_Contato = Convert.ToString(rcrdsetORC[1]);
            dados_Roteiro= Convert.ToString(rcrdsetORC[2]);


        }
        ConexaoBancoSQL.fecharConexao();
       
    }
}