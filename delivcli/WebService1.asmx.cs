using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data.SqlClient;

namespace delivcli
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://http://logcliente.azurewebsites.net")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string MotoboysOnLine(string param1)
        {

            string Resultado = "";
            List<Object> resultado = new List<object>();

            try
            {
                OperacaoBanco operacao1 = new OperacaoBanco();
                SqlDataReader dados1 = operacao1.Select("select ID_Motoboy, Nome ,GeoLatitude  ,GeoLongitude, " +
                "DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo, format(GeoDataLoc,'dd/MM hh:mm:ss') as DataFormatada " +
                "FROM Tbl_Motoboys " +
                "where ID_Cliente =" + param1 );

                while (dados1.Read())
                {
                    //validações diversas
                    int min1 = Convert.ToInt32(dados1[4]);  // diferença em minutos
                    if (min1 > 185) { continue; } // verifica se diferença é maior que 5minutos (+dif+3horas getdate not brazilian server)

                    resultado.Add(new
                    {
                        ID_Motoboy = dados1[0].ToString(),
                        Nome = dados1[1].ToString() +  " - " + dados1[5].ToString() ,
                        Latitude = dados1[2].ToString(),
                        Longitude = dados1[3].ToString()
                    });
                }
                ConexaoBancoSQL.fecharConexao();

                //O JavaScriptSerializer vai fazer o web service retornar JSON
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(resultado);

            }
            catch (Exception)
            {
                Resultado = "FALHA";
            }

            return Resultado;
        }


    }

}
