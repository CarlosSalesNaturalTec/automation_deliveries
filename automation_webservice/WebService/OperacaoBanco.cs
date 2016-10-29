using System;
using System.Data.SqlClient;

namespace WebService
{
    public class OperacaoBanco
    {
        /*Classe para Operações com Banco de Dados SQL (select, insert, update e delete)
        Criação    : Carlos Sales / 2016's
        Recursos   : ASP.NET / C# / SQL / Windows Azure */

        private SqlCommand TemplateMethod(String query)
        {
            SqlConnection Conexao = ConexaoBancoSQL.getConexao();
            SqlCommand Commando = new SqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return Commando;
            }
            catch
            {
                return Commando;
            }
        }

        public SqlDataReader Select(String query)
        {
            SqlDataReader dadosObtidos = TemplateMethod(query).ExecuteReader();
            return dadosObtidos;
        }

        public Boolean Insert(String query)
        {
            SqlConnection Conexao = ConexaoBancoSQL.getConexao();
            SqlCommand Commando = new SqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Update(String query)
        {
            SqlConnection Conexao = ConexaoBancoSQL.getConexao();
            SqlCommand Commando = new SqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Delete(String query)
        {
            SqlConnection Conexao = ConexaoBancoSQL.getConexao();
            SqlCommand Commando = new SqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}