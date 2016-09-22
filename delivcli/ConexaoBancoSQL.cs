using System;
using System.Data.SqlClient;

namespace delivcli
{
    public class ConexaoBancoSQL

      /*Classe para Conexão com Banco de Dados SQL
      Autor      : Carlos Sales Natural Tecnologia https://github.com/CarlosSalesNaturalTec 
      Ano        : 2016
      Recursos   : ASP.NET / C# / SQL  */

    {
        private static SqlConnection objConexao = null;

        private string stringconnection1;

        public void tentarAbrirConexaoRemota()
        {
            objConexao = new SqlConnection();
            objConexao.ConnectionString = stringconnection1;
            objConexao.Open();
        }

        public ConexaoBancoSQL()
        {
            // *** STRING DE CONEXÃO COM BANCO DE DADOS - Atenção! Alterar dados conforme seu servidor
           stringconnection1 = @"Server=tcp:logtransportesserver.database.windows.net,1433;Initial Catalog=logtransportes;Persist Security Info=False;User ID=admlogtransporte;Password=pwd@1973;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                tentarAbrirConexaoRemota();
            }
            catch
            {
                Console.WriteLine("Atenção! Não foi possível Conectar ao Servidor de Banco de Dados.");
            }
            }

        public static SqlConnection getConexao()
        {
            new ConexaoBancoSQL();
            return objConexao;
        }
        public static void fecharConexao()
        {
            objConexao.Close();
        }
    }
}