using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace delivcli
{
    public partial class ImportClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // tabela de clientes copiada e colada do excel
            string stringSelect = "select contrato,responsavel,tlefone,email from TEste";
            OperacaoBanco operacao4 = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados4 = operacao4.Select(stringSelect);

            while (dados4.Read())
            {
                InserirRegistro(Convert.ToString(dados4[0]), Convert.ToString(dados4[1]), Convert.ToString(dados4[2]),
                    Convert.ToString(dados4[3])); 
            }
            ConexaoBancoSQL.fecharConexao();
            Response.Write("<script>alert('Aleluia');</script>");

        }

        private void InserirRegistro(string param1, string param2, string param3, string param4 )
        {
            string stringinsert = "insert into Tbl_Clientes (Nome,Responsavel,Telefone ,email,senha,nivel) values (" +
                "'" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '123456',1)";
            OperacaoBanco operacao = new OperacaoBanco();
            bool inserir = operacao.Insert(stringinsert);
            ConexaoBancoSQL.fecharConexao();
            
        }
    }
}