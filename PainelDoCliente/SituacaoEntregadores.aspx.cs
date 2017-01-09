using System;
using System.Text;
using System.Web.UI;

public partial class SituacaoEntregadores : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ColetaDados("On-Line");
            Literal1.Text = str.ToString();

            ColetaDados("Off-Line");
            Literal2.Text = str.ToString();
        }
    }

    private void ColetaDados(string escolha)
    {

        str.Clear();
        string stringComAspas = "<div class=\"panel panel-" + TipoHeader(escolha) + "\"><div class=\"panel-heading\"><h3 class=\"panel-title\"> " +
               escolha.ToUpper() + "</h3></div><div class=\"panel-body\">";
        str.Append(stringComAspas);

        // Listagem de Entregadores e intevalo desde a ultima atualização
        string stringselectSit1 = "";
        stringselectSit1 = @"select usuario, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo, ID_Motoboy   " +
                " from Tbl_Motoboys where ID_Cliente = 5 " +
                " order by usuario";
        OperacaoBanco operacaoSit1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dadosSit1 = operacaoSit1.Select(stringselectSit1);

        int min1 = 0;

        while (dadosSit1.Read())
        {   
            try
            {
                min1 = Convert.ToInt32(dadosSit1[1]);  // diferença em minutos (180 de fuso hrário + 5 minutos de tolerância desde a ultima atualização)
            }
            catch (Exception)
            {
                min1 = 186;
            }
            
            if (escolha == "On-Line") { if (min1 > 185) { continue; } }
            if (escolha == "Off-Line") { if (min1 < 185) { continue; } }

            //nome do Entregador + Total de Entregas do Dia + Total de Entregas Realizadas
            stringComAspas = "<a href=\"FichaEntregador.aspx?ID=" + Convert.ToString(dadosSit1[2]) + "\" target=\"_parent\" class=\"list-group-item\"><h4 class=\"list-group-item-heading\">" + Convert.ToString(dadosSit1[0]) +
                ". " + TotaldeEntregas(Convert.ToString(dadosSit1[2])) + "</h4>";
            str.Append(stringComAspas);

            if (min1 > 185)
            {
                stringComAspas = "<p class=\"list-group-item-text\">Off-Line à: " + TempoOff(min1) + "</p></a>";
            }
            else
            {
                stringComAspas = "<p class=\"list-group-item-text\">" + StatusDirecao(Convert.ToString(dadosSit1[2])) + "</p></a>";
            }
            str.Append(stringComAspas);
        }
        ConexaoBancoSQL.fecharConexao();

        stringComAspas = "</div></div>";
        str.Append(stringComAspas);

    }

    public string TipoHeader(string Escolha)
    {
        //  cor do cabeçãlho

        string tipoheader = "";
        switch (Escolha)
        {
            case "On-Line":
                tipoheader = "success";
                break;
            case "Off-Line":
                tipoheader = "default";
                break;
            default:
                tipoheader = "info";
                break;
        }

        return tipoheader;
    }

    public string StatusDirecao(string identregador)
    {
        string stringselectSit2 = "", status = "Próx.Dest.: Não Especificado";

        //  verifica se está em direção a uma entrega específica.
        stringselectSit2 = @"select Nome_Destinatario from Tbl_Entregas where ID_Motoboy = " + identregador + " and Entregue =0 and Partida_Iniciada=1";
        OperacaoBanco operacaoSit2 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader recordsetSit2 = operacaoSit2.Select(stringselectSit2);
        while (recordsetSit2.Read())
        {
            status = "Próx.Dest.: " + Convert.ToString(recordsetSit2[0]);
        }
        ConexaoBancoSQL.fecharConexao();
        return status;
    }

    public string TotaldeEntregas(string identregador)
    {
        string stringselectSit4 = "";
        int totaldeentregas = 0, realizadas = 0;
        string datastatus = DateTime.Today.ToString("yyyy-MM-dd");

        // total de entregas do entregador no dia
        stringselectSit4 = @"select ID_Entrega, Entregue from Tbl_Entregas where ID_Motoboy = " + identregador +
            " and format(Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'";
        OperacaoBanco operacaoSit4 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader recordsetSit4 = operacaoSit4.Select(stringselectSit4);
        while (recordsetSit4.Read())
        {
            totaldeentregas++;
            if (Convert.ToString(recordsetSit4[1]) == "True") { realizadas++; }
        }
        ConexaoBancoSQL.fecharConexao();
        return realizadas.ToString() + " de " + totaldeentregas.ToString();

    }

    public string TempoOff(int tempominutos)
    {
        string tempo = "xxx";
        int minutos = tempominutos - 180;  // 180 = diferença fuso horario
        if (minutos < 60) { tempo = minutos.ToString() + "min"; }
        if (minutos > 60)
        {
            if (minutos < 1440)
            {
                int horas = minutos / 60;
                tempo = horas.ToString() + "hs";
            }
            else
            {
                tempo = "Mais de 24hs";
            }
        }
        return tempo;
    }
}