using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebService2
{
    /// <summary>
    /// Summary description for wservice
    /// </summary>
    [WebService(Namespace = "return")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wservice : System.Web.Services.WebService
    {

        [WebMethod(Description = "Mensagem aos visitantes. Retorno em XML")]
        public string Bem_Vindo()
        {
            return "Olá, Bem Vindo. Jesus Cristo tem sido minha companhia, fonte de proteção, provisão e prosperidade!";
        }

        [WebMethod(Description = "Receber Coordenadas de Geolocalização e armazenar em base de dados. Retorno em XML")]
        public string Historico(int IdMotoboy, int IdEntrega, string latitude, string longitude, string dataLeitura)
        {
            string Resultado = "";

            try
            {
                // lança dados em tabela de histórico de localização
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean inserir = operacao.Insert(@"insert into Tbl_Historico (ID_Motoboy, Id_Entrega, Data_Coleta, Latitude, Longitude)
	                                                values (" + IdMotoboy + ", " + IdEntrega + ", '" + dataLeitura + "', '" + latitude + "','" + longitude + "')");                
                ConexaoBancoSQL.fecharConexao();

                // lança dados em tabela de motoboy
                operacao = new OperacaoBanco();
                Boolean atualizar = operacao.Update(@"update Tbl_Motoboys set GeoLatitude = '" + latitude + "', GeoLongitude = '" + longitude + "', GeoDataLoc = '" + dataLeitura + "' where ID_motoboy = " + IdMotoboy);
                ConexaoBancoSQL.fecharConexao();

                if (atualizar == true) { Resultado = "OK"; } else { Resultado = "NÃO FOI POSSIVEL INSERIR REGISTRO"; }

            }
            catch (Exception)
            {
                Resultado = "FALHA CONEXÃO BANCO DE DADOS";
            }

            return Resultado;
        }

        [WebMethod(Description = "Receber Id do Motoboy e retornar JSON com lista de Entregas a realizar.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListaEntregas(int IdMotoboy)
        {
            string Resultado = "";
            List<Object> resultado = new List<object>();
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT ID_Entrega,Bairro,Endereco,Id_Motoboy,Entregue "
                        + "FROM Tbl_Entregas "
                        + "where (Entregue<>1 and ID_Motoboy = " + IdMotoboy 
                        + ") order by Bairro");
                while (dados.Read())
                {
                    resultado.Add(new
                    {
                        ID_Entrega= dados[0].ToString(),
                        Bairro = dados[1].ToString(),
                        Endereco = dados[2].ToString()
                    });
                }
                ConexaoBancoSQL.fecharConexao();

                //O JavaScriptSerializer vai fazer o web service retornar JSON
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(resultado);

            }
            catch (Exception)
            {
                Resultado = "FALHA CONEXÃO BANCO DE DADOS";
            }

            return Resultado;
        }

    }
}