using System;
using System.Text;

public partial class Roteiros_Listagem : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Preenche_Motoboys();
        Grid_Roteiros();
    }

    private void Preenche_Motoboys()
    {
        string stringSelect = "select ID_Motoboy , Nome from Tbl_Motoboys order by Nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);

        str.Clear();
        string scrNome = "<select class=\"form-control\" id=\"select_motoboy\">";
        str.Append(scrNome);

        scrNome = "<option value=\"0\">Selecione um Motoboy</option>";
        str.Append(scrNome);

        while (rcrdset.Read())
        {
            scrNome = "<option value=\"" + Convert.ToString(rcrdset[0]) + "\">" + Convert.ToString(rcrdset[1]) + "</option>";
            str.Append(scrNome);
        }
        ConexaoBancoSQL.fecharConexao();

        scrNome = "</select>";
        str.Append(scrNome);
        Literal_Motoboy.Text = str.ToString();

    }


    private void Grid_Roteiros()
    {

        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");

        string stringSelect = "SELECT Tbl_Entregas.ID_Entrega, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Bairro , Tbl_Entregas.Cidade , Tbl_Entregas.Status_Entrega, " +
            "Tbl_Clientes.Nome, Tbl_Motoboys.Nome, Tbl_Entregas.Endereco " +
            "FROM ((Tbl_Entregas " +
            "INNER JOIN Tbl_Clientes ON Tbl_Entregas.ID_Cliente = Tbl_Clientes.ID_Cliente) " +
            "INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy) " +
            "where Status_Entrega = 'EM ABERTO' " +
            "order by Tbl_Clientes.Nome, Tbl_Motoboys.Nome  ;";

        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;
        string corStatus = "";
        string idaux = "";
        string bt1 = "", bt2 = "";

        while (rcrdsetUsers.Read())
        {
            // cor do status
            switch (Convert.ToString(rcrdsetUsers[4]))
            {
                case "EM ABERTO":
                    corStatus = "w3-text-black";
                    break;

                case "EM ANDAMENTO":
                    corStatus = "w3-text-blue";
                    break;

                case "ENTREGA REALIZADA":
                    corStatus = "w3-text-green";
                    break;

                default:
                    corStatus = "w3-text-red";
                    break;
            }

            // botões de controle
            idaux = Convert.ToString(rcrdsetUsers[0]);
            //bt1 = "<a class='w3-btn w3-round w3-hover-blue w3-text-green' href=''><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            bt1 = "<input type='checkbox'class='w3-check' name='chkselecao' value='" + idaux + "' />&nbsp;&nbsp;&nbsp;";
            bt2 = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Excluir(this," + idaux + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + bt1 + bt2 + Convert.ToString(rcrdsetUsers[5]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[6]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[1]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[7]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[2]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[3]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "<td class='" + corStatus + "'>" + Convert.ToString(rcrdsetUsers[4]) + "</td>";
            str.Append(ScriptDados);

            ScriptDados = "</tr>";
            str.Append(ScriptDados);
        }
        ConexaoBancoSQL.fecharConexao();

        Literal2.Text = str.ToString();
    }
}