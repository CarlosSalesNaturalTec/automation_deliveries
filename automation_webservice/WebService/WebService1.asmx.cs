using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Web Service SOAP retornando XML. 
    /// Desenvolvido por : Carlos Sales - Natural Tecnologia - 2016
    /// </summary>
    [WebService(Namespace = "http://webserverone.azurewebsites.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod(Description = "Mensagem aos visitantes. Retorno em XML")]
        public string Bem_Vindo()
        {
            return "Sejam Bem Vindos. Jesus Cristo tem sido nossa companhia. Nossa Fonte de proteção, provisão e prosperidade!";
        }

        [WebMethod(Description = "Receber Coordenadas de Geolocalização e armazenar em base de dados. Retorno em XML")]
        public string Coordenadas(int IdMotoboy, string latitude, string longitude)
        {
            string Resultado = "XX";

            OperacaoBanco operacao = new OperacaoBanco();
            Boolean update = operacao.Update(@"update Tbl_Motoboys set GeoLatitude = '" + latitude + "',  GeoLongitude ='" + longitude + "'" 
                                               + " where ID_Motoboy = " + IdMotoboy );
            if (update == true)
            {
                Resultado = "OK";
            }


            return Resultado;
        }

    }
}
