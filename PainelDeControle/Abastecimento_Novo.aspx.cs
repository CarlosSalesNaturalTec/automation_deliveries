using System;
using System.Globalization;
using System.Text;

public partial class Abastecimento_Novo : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //preenche combos
            PreeencheEntregadores();
            PreencheVeiculos();         

            //Monta Tabela
            //======================================
            LimpaTabela();
            InsereDebitos();
            montaCabecalho();
            dadosCorpo();
            montaRodape();

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

        LIteral_Colaborador.Text = str.ToString();

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
        LIteral_Veiculos.Text = str.ToString();
    }


    private void LimpaTabela()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("DELETE FROM Tbl_Abastecimento_Planilha");
    }

    private void InsereDebitos()
    {
        OperacaoBanco operacao = new OperacaoBanco();
        string stringinsert = @"INSERT INTO Tbl_Abastecimento_Planilha (DataOperacao,Valor,Motorista ,Placa ,Kilometragem ,  Evento, ID_Abastecimento )
                            SELECT DataAutoriza, Valor,Nome , Placa, Kilometragem, 'ABASTECIMENTO', ID_Abastecimento 
                            FROM Tbl_Abastecimentos";
        Boolean inserir = operacao.Insert(stringinsert);
    }


    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover table-bordered \">" +
            "<thead>" +
            "<tr>" +
            "<th>RE-ENVIO</th>" +
            "<th>DATA</th>" +
            "<th>HORÁRIO</th>" +
            "<th>MOTORISTA</th>" +
            "<th>PLACA</th>" +
            "<th>KM</th>" +
            "<th style=\"text-align:right\">VALOR</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {

        string stringselect = "select ID_Abastecimento, format(DataOperacao ,'dd/MM/yyyy') as DataOper, format(DataOperacao ,'HH:mm:ss') as HoraOper," +
                " Motorista , Placa , Kilometragem , Valor " +
                " from Tbl_Abastecimento_Planilha" +
                " order by DataOperacao ";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]);  //ID do abastecimento
            string Coluna1 = Convert.ToString(dados[1]);  //data
            string Coluna2 = Convert.ToString(dados[2]);  //horario
            string Coluna4 = Convert.ToString(dados[3]);  //motorista
            string Coluna5 = Convert.ToString(dados[4]);  //placa
            string Coluna6 = Convert.ToString(dados[5]);  //Km
            string valorSTR = Convert.ToString(dados[6]); //valor - auxiliar
            string Coluna7 = "";                          //valor - formatada

            decimal valor = Convert.ToDecimal(valorSTR);
            Coluna7 = "<td style=\"text-align:right\"> <strong>" + valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")) + "</strong></td>";

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href='Abastecimento_Reenvio.aspx?v1=" + Coluna0 + "'><i class='fa fa-envelope-o' aria-hidden='true'></i></a>";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + " " + Coluna0 + "</td>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                Coluna7 +
                "</tr>";

            str.Append(stringcomaspas);
           
        }
        ConexaoBancoSQL.fecharConexao();
    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);

        Literal_Tabela.Text = str.ToString();
    }
}