using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
	                                                values (" + IdMotoboy + ", " + IdEntrega + ", GETDATE(), '" + latitude + "','" + longitude + "')");
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

    }
}
