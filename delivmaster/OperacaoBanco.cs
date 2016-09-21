using System;
using System.Data.SqlClient;

namespace delivmaster
{
    public class OperacaoBanco
    {
        /*Classe para Operações com Banco de Dados SQL (select, insert, update e delete)
        Autor    : Carlos Sales Natural Tecnologia https://github.com/CarlosSalesNaturalTec 
        Ano      : 2016
        Recursos : ASP.NET / C# / SQL */

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