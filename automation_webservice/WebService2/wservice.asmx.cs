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
    [WebService(Namespace = "http://webservice21214.azurewebsites.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wservice : System.Web.Services.WebService
    {

        [WebMethod(Description = "Mensagem aos visitantes. Retorno em XML")]
        public string Bem_Vindo()
        {
            return "Olá, Sejam Bem Vindos. Jesus Cristo tem sido nossa companhia, fonte de proteção, provisão e prosperidade!";
        }

        [WebMethod(Description = "Receber Coordenadas de Geolocalização e armazenar em base de dados. Retorno em XML")]
        public string Historico(int IdMotoboy, int IdEntrega, string latitude, string longitude, string dataLeitura)
        {
            string Resultado = "";

            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                Boolean inserir = operacao.Insert(@"insert into Tbl_Historico (ID_Motoboy, Id_Entrega, Data_Coleta, Latitude, Longitude)
	                                                values (" + IdMotoboy + ", " + IdEntrega + ", '" + dataLeitura + "', '" + latitude + "','" + longitude + "')");
                if (inserir == true)
                {
                    Resultado = "OK";
                }
                else
                {
                    Resultado = "NÃO FOI POSSIVEL INSERIR REGISTRO";
                }

                ConexaoBancoSQL.fecharConexao();
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
                System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT Nome_Destinatario,Endereco,Ponto_Ref,Bairro,Cidade,Telefone," 
                        + "Observacoes,Latitude,Longitude,Id_Motoboy "
                        + "FROM Tbl_Entregas " 
                        + "where Entregue<>1 and ID_Motoboy = " + IdMotoboy);
                while (dados.Read())
                {
                    resultado.Add(new
                    {
                        Nome = dados[0].ToString(),
                        Endereco = dados[1].ToString(),
                        Ponto_Ref = dados[2].ToString(),
                        Bairro = dados[3].ToString(),
                        Cidade = dados[4].ToString(),
                        Telefone = dados[5].ToString(),
                        Observacoes = dados[6].ToString(),
                        Latitude = dados[7].ToString(),
                        Longitude = dados[8].ToString(),
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
