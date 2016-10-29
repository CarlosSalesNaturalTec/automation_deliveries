using System;
using System.Data.SqlClient;

namespace WebService2
{
    public class ConexaoBancoSQL

      /*Classe para Conexão com Banco de Dados SQL
      Criação    : Carlos Sales / 2016's
      Recursos   : ASP.NET / C# / SQL / Windows Azure */

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
           stringconnection1 = @"Server=tcp:servermodels.database.windows.net,1433;Initial Catalog=dblog;Persist Security Info=False;User ID=admservermodel;Password=Pwd@2016;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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