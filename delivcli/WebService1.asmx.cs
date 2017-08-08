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

        [WebMethod]
        public string Registro_Simplif_Excluir(string param1)
        {
            string url = "";
            OperacaoBanco operacao = new OperacaoBanco();
            Boolean deletar = operacao.Delete("delete from Tbl_Entrega_Simplficada  where ID_Entrega  =" + param1);
            ConexaoBancoSQL.fecharConexao();
            if (deletar == true)
            {
                url = "../Registro_Simplif_Listagem.aspx";
            }
            else
            {
                url = "../Sorry.aspx";
            }

            return url;
        }


        [WebMethod]
        public string Registro_Simplif_Novo(string param0, string param1, string param2, string param3, string param4, string param5, string param6)
        {
            string url = "";
            OperacaoBanco operacao = new OperacaoBanco();
            bool inserir = operacao.Insert(@"INSERT INTO Tbl_Entrega_Simplficada (Motoboy, DataEntrega , Quatidade , Entregues , Realizadas , Observacoes, ID_Cliente) " +
                "VALUES ('" + param0 + "', '" +param1 +"', '" +  param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 + "', " + param6 + ")");
            ConexaoBancoSQL.fecharConexao();
            if (inserir == true)
            {
                url = "../Registro_Simplif_Listagem.aspx";
            }
            else
            {
                url = "../ErroDefault.aspx";
            }

            return url;
        }


        [WebMethod]
        public string Registro_Simplif_Alterar(string param0, string param1, string param2, string param3, string param4, string param5, string param6)
        {
            string url = "";
            OperacaoBanco operacao = new OperacaoBanco();
            bool inserir = operacao.Insert("update Tbl_Entrega_Simplficada set " +
                "Motoboy = '" + param0 + "', " +
                "DataEntrega = '" + param0 + "', " +
                "Quatidade = '" + param0 + "', " +
                "Entregues = '" + param0 + "', " +
                "Realizadas = '" + param0 + "', " +
                "Observacoes = '" + param0 + "' " +
                "where ID_Entrega = "  + param6 );

            ConexaoBancoSQL.fecharConexao();
            if (inserir == true)
            {
                url = "../Registro_Simplif_Listagem.aspx";
            }
            else
            {
                url = "../ErroDefault.aspx";
            }

            return url;
        }

    }

}
