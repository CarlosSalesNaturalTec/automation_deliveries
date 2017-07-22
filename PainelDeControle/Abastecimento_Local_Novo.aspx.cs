using System;
using System.Text;

public partial class Abastecimento_Local_Novo : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    int TotaldeRegistros = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Placas_Listagem();
        Nomes_Listagem();
        Numero_Controle();
    }

    private void Placas_Listagem()
    {

        string stringselect = "select placa from Tbl_Abastecimento_Local group by placa";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        string Coluna0;
        string stringcomaspas;
        string tagIni="", tagFim="";
        str.Clear();

        while (dados.Read())
        {
            Coluna0 =  Convert.ToString(dados[0]);
            stringcomaspas = "<option value='" + Coluna0 + "'>" + Coluna0 + "</option>";
            str.Append(stringcomaspas);
            TotaldeRegistros++;
        }

        ConexaoBancoSQL.fecharConexao();

        if (TotaldeRegistros == 0)
        {
            stringcomaspas = "<input type=\"text\" class=\"form-control\" id=\"input_placa\">";
            str.Append(stringcomaspas);
        } else
        {
            tagIni = "<select id=\"select_placa\" class=\"form-control w3-select w3-border\">";
            tagFim = "</select>";
        }

        literal_Placa.Text = tagIni + str.ToString() + tagFim;

    }

    private void Nomes_Listagem()
    {

        string stringselect = "select Nome from Tbl_Abastecimento_Local group by Nome";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        string Coluna0;
        string stringcomaspas;
        string tagIni = "", tagFim = "";
        int totalReg = 0;
        str.Clear();

        while (dados.Read())
        {
            Coluna0 = Convert.ToString(dados[0]);
            stringcomaspas = "<option value='" + Coluna0 + "'>" + Coluna0 + "</option>";
            str.Append(stringcomaspas);
            totalReg++;
        }

        ConexaoBancoSQL.fecharConexao();

        if (totalReg == 0)
        {
            stringcomaspas = "<input type=\"text\" class=\"form-control\" id=\"input1\">";
            str.Append(stringcomaspas);
        }
        else
        {
            tagIni = "<select id=\"input1\" class=\"form-control w3-select w3-border\">";
            tagFim = "</select>";
        }

        literal_Nome.Text = tagIni + str.ToString() + tagFim;
    }

    private void Numero_Controle()
    {

        string stringcomaspas;
        str.Clear();

        if (TotaldeRegistros == 0)
        {
            stringcomaspas = "<input type='number' class='form-control' id='input_talao' value=1>";
            str.Append(stringcomaspas);
        }
        else
        {
            string stringselect = "select MAX(Talao) as controle from Tbl_Abastecimento_Local";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            Int32 Coluna0;
            while (dados.Read())
            {
                Coluna0 = Convert.ToInt32(dados[0]) + 1;
                stringcomaspas = "<input type='number' class='form-control' id='input_talao' value=" + Coluna0 + ">";
                str.Append(stringcomaspas);
            }
            ConexaoBancoSQL.fecharConexao();
        }

        Literal_Talao.Text = str.ToString();
    }
}