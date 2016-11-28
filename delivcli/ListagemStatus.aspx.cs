using System;
using System.Text;
using System.Web.UI;

namespace delivcli
{
    public partial class ListagemStatus : Page
    {

        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ColetaDados();
                Literal1.Text = str.ToString();
            }
        }

        private void ColetaDados()
        {

            str.Clear();
            string stringComAspas = "<a class=\"list-group-item active\">" + Session["LocTipo"].ToString().ToUpper() + " </a>";
            str.Append(stringComAspas);

            string stringselect = "";
            stringselect = @"select usuario, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo " +
                    " from Tbl_Motoboys where ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " order by usuario";
            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

            while (dados.Read())
            {
                int min1 = Convert.ToInt16(dados[1]);  // diferença em minutos
                string escolha = Session["LocTipo"].ToString();  // seleção do usuário: ativo, inativo ou todos

                if (escolha == "On-Line") { if (min1 > 185) { continue; } }
                if (escolha == "Off-Line") { if (min1 < 185) { continue; } }

                stringComAspas = "<a class=\"list-group-item\">" + Convert.ToString(dados[0]) + "</a>";
                str.Append(stringComAspas);
            }

        }

    }
}