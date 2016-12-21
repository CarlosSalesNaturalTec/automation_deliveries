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

        [WebMethod]
        public string Bem_Vindo()
        {
            return "Olá, Bem Vindo. Jesus Cristo tem sido minha companhia, fonte de proteção, provisão e prosperidade!";
        }

        [WebMethod]
        public string Historico(int IdMotoboy, int IdEntrega, string latitude, string longitude, string dataLeitura)
        {
            string Resultado = "";

            // lança dados em tabela temporária de localização
            OperacaoBanco operacao = new OperacaoBanco();
            Boolean inserir = operacao.Insert(@"insert into Tbl_Historico_Temp (ID_Motoboy, Id_Entrega, Data_Coleta, Latitude, Longitude)
	                                                values (" + IdMotoboy + ", " + IdEntrega + ", '" + dataLeitura + "', '" + latitude + "','" + longitude + "')");
            ConexaoBancoSQL.fecharConexao();

            // atualiza dados de localização em tabela de motoboy
            operacao = new OperacaoBanco();
            Boolean atualizar = operacao.Update(@"update Tbl_Motoboys set GeoLatitude = '" + latitude + "', GeoLongitude = '" + longitude + "', GeoDataLoc = '" + dataLeitura + "' where ID_motoboy = " + IdMotoboy);
            ConexaoBancoSQL.fecharConexao();
            if (atualizar == true) { Resultado = "OK"; } else { Resultado = "NÃO FOI POSSIVEL INSERIR REGISTRO"; }

            // verifica se valor de Latitude se repete mais de 1 vez nos ultimos 10 lançamentos
            operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("select top 10 Latitude, Data_Coleta from Tbl_Historico_Temp " +
                    "where ID_Motoboy = " + IdMotoboy + " order by Data_Coleta desc");

            int repeticoes = 1;
            int registros = 0;
            string ultimoregistro = "";
            while (dados.Read())
            {
                if (latitude == Convert.ToString(dados[0])) { repeticoes++; }
                ultimoregistro = Convert.ToString(dados[1]);
                registros++;
            }
            ConexaoBancoSQL.fecharConexao();

            //Caso o valor de Latitude não se repita, significa que está em movimento. neste caso grava posição em tabela de histórico
            if (repeticoes == 1)
            {
                operacao = new OperacaoBanco();
                inserir = operacao.Insert(@"insert into Tbl_Historico (ID_Motoboy, Id_Entrega, Data_Coleta, Latitude, Longitude)
	                                                values (" + IdMotoboy + ", " + IdEntrega + ", '" + dataLeitura + "', '" + latitude + "','" + longitude + "')");
                ConexaoBancoSQL.fecharConexao();
            }


            //mantem em tabela temporaria apenas ultimos 10 registros. apaga os demais
            if (registros > 9)
            {
                operacao = new OperacaoBanco();
                Boolean deletar = operacao.Delete("delete from Tbl_Historico_Temp " +
                    "where ID_Motoboy = " + IdMotoboy +
                    "and Data_Coleta < '" + ultimoregistro + "'");
                ConexaoBancoSQL.fecharConexao();
            }

            return Resultado;
        }

        [WebMethod]
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
                        ID_Entrega = dados[0].ToString(),
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string DetalhesEntrega(int IdEntrega)
        {
            string Resultado = "";
            List<Object> resultado = new List<object>();
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT ID_Entrega,Nome_Destinatario,Bairro,Endereco,Ponto_Ref,"
                        + "Cidade,Telefone,Observacoes,Latitude,Longitude,Partida_Data "
                        + "FROM Tbl_Entregas "
                        + "where ID_Entrega  = " + IdEntrega);
                while (dados.Read())
                {
                    resultado.Add(new
                    {
                        ID_Entrega = dados[0].ToString(),
                        Nome_Destinatario = dados[1].ToString(),
                        Bairro = dados[2].ToString(),
                        Endereco = dados[3].ToString(),
                        Ponto_Ref = dados[4].ToString(),
                        Cidade = dados[5].ToString(),
                        Telefone = dados[6].ToString(),
                        Observacoes = dados[7].ToString(),
                        Latitude = dados[8].ToString(),
                        Longitude = dados[9].ToString(),
                        Partida_Data = dados[10].ToString()
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string StartTravel(int IdEntrega, string latitude, string longitude, string dataLeitura)
        {
            string Resultado = "";

            try
            {
                // atualiza status da entrega : VIAGEM INICIADA
                OperacaoBanco operacao = new OperacaoBanco();
                operacao = new OperacaoBanco();
                Boolean atualizar = operacao.Update(@"update Tbl_Entregas set Partida_Data = '" + dataLeitura + "', Partida_Latitude = '" +
                    latitude + "', Partida_Longitude = '" + longitude + "', Partida_Iniciada = 1, Status_Entrega = 'EM ANDAMENTO'  where ID_Entrega = " + IdEntrega);
                ConexaoBancoSQL.fecharConexao();

                if (atualizar == true) { Resultado = "OK"; } else { Resultado = "NÃO FOI POSSIVEL ATUALIZAR STATUS"; }

            }
            catch (Exception)
            {
                Resultado = "FALHA CONEXÃO BANCO DE DADOS";
            }

            return Resultado;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string EndTravel(int IdEntrega, string latitude, string longitude, string dataLeitura, string Status)
        {
            string Resultado = "";
            string mStatus = "";

            switch (Status)
            {
                case "01": { mStatus = "ENTREGA REALIZADA"; break; }
                case "02": { mStatus = "MUDOU-SE"; break; }
                case "03": { mStatus = "AUSENTE"; break; }
                case "04": { mStatus = "NÃO QUIZ RECEBER"; break; }
                case "05": { mStatus = "ÁREA DE RISCO"; break; }
                case "06": { mStatus = "END. INSUFICIENTE"; break; }
            }

            try
            {
                // atualiza status da entrega : VIAGEM CONCLUIDA
                OperacaoBanco operacao = new OperacaoBanco();
                operacao = new OperacaoBanco();
                Boolean atualizar = operacao.Update(@"update Tbl_Entregas set Chegada_Data = '" + dataLeitura + "', Chegada_Latitude = '" +
                    latitude + "', Chegada_Longitude = '" + longitude + "', Status_Entrega ='" + mStatus + "', Entregue =1  where ID_Entrega = " + IdEntrega);
                ConexaoBancoSQL.fecharConexao();

                if (atualizar == true) { Resultado = "OK"; } else { Resultado = "NÃO FOI POSSIVEL ATUALIZAR STATUS"; }

            }
            catch (Exception)
            {
                Resultado = "FALHA CONEXÃO BANCO DE DADOS";
            }

            return Resultado;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListaCoordenadas(int IdMotoboy)
        {
            string Resultado = "";
            List<Object> resultado = new List<object>();
            try
            {
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT ID_Entrega,ID_Motoboy,Latitude,Longitude,Entregue "
                        + "FROM Tbl_Entregas "
                        + "where (Entregue<>1 and ID_Motoboy = " + IdMotoboy + " and Latitude<>'')");
                while (dados.Read())
                {
                    resultado.Add(new
                    {
                        ID_Entrega = dados[0].ToString(),
                        Latitude = dados[2].ToString(),
                        Longitude = dados[3].ToString()
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