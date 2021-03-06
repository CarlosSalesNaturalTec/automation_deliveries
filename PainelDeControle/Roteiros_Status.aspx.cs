﻿using System;
using System.Text;

public partial class Roteiros_Status : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Grid_Roteiros();
    }

    private void Grid_Roteiros()
    {

        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");

        string stringSelect = "SELECT Tbl_Entregas.ID_Entrega, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.Bairro , Tbl_Entregas.Cidade , Tbl_Entregas.Status_Entrega, " +
            "Tbl_Clientes.Nome, Tbl_Motoboys.Nome, Tbl_Entregas.Endereco " +
            "FROM ((Tbl_Entregas " +
            "INNER JOIN Tbl_Clientes ON Tbl_Entregas.ID_Cliente = Tbl_Clientes.ID_Cliente) " +
            "INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy) " +
            "where encerrada = 0 " +
            "order by Tbl_Clientes.Nome, Tbl_Motoboys.Nome  ;";

        OperacaoBanco operacaoUsers = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetUsers = operacaoUsers.Select(stringSelect);

        str.Clear();
        string ScriptDados;
        string corStatus = "";

        while (rcrdsetUsers.Read())
        {

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

            ScriptDados = "<tr>";
            str.Append(ScriptDados);

            ScriptDados = "<td>" + Convert.ToString(rcrdsetUsers[5]) + "</td>";
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