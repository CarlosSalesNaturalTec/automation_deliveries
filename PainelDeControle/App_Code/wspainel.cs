using System;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Collections.Generic;

[WebService(Namespace = "http://logmaster.azurewebsites.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class wspainel : System.Web.Services.WebService
{
    public wspainel()
    {

    }

    [WebMethod]
    public string SalvarEntregador(string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Motoboys (Nome, Veiculo, Modelo, Placa, ID_Cliente, Cliente, FotoDataURI, usuario,GeoLatitude,Geolongitude,GeoDataLoc) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', " + param5 + ", '" + param6 + "', '" + param7 + "','','','','')");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Entregadores.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ExcluirEntregador(string param1)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("delete from Tbl_Motoboys where ID_Motoboy =" + param1);
        ConexaoBancoSQL.fecharConexao();
        if (deletar == true)
        {
            url = "../Entregadores.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string EditarEntregador(string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"update Tbl_Motoboys set nome = '" + param1 + "', " +
            "veiculo = '" + param2 + "', " +
            "modelo = '" + param3 + "', " +
            "placa = '" + param4 + "', " +
            "ID_Cliente = " + param5 + ", " +
            "Cliente = '" + param6 + "', " +
            "FotoDataURI  = '" + param7 + "' " +
            "where ID_Motoboy =" + param8);

        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Entregadores.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string SalvarCliente(string param1, string param2, string param3, string param4, string param5, string param6)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Clientes (Nome, Responsavel , email, Telefone, usuario , Senha, nivel) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 + "', '" + param6 + "',2)");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Clientes.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ClienteNovaCidade(string param1, string param2, string param3)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("INSERT INTO Tbl_Clientes_Cidade_Custos (ID_Cliente , Cidade , Valor ) " +
            "VALUES (" + param1 + ", '" + param2 + "', " + param3 + ")");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Clientes.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ClienteDELCidade(string param1)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("delete from Tbl_Clientes_Cidade_Custos where ID_Cidade =" + param1);
        ConexaoBancoSQL.fecharConexao();
        if (deletar == true)
        {
            url = "../Clientes.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string ExcluirCliente(string param1)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("delete from Tbl_Clientes where ID_Cliente  =" + param1);
        ConexaoBancoSQL.fecharConexao();
        if (deletar == true)
        {
            url = "../Clientes.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string EditarCliente(string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"update Tbl_Clientes set nome = '" + param1 + "', " +
            "Responsavel  = '" + param2 + "', " +
            "email = '" + param3 + "', " +
            "Telefone = '" + param4 + "', " +
            "Usuario = '" + param6 + "', " +
            "Senha = '" + param7 + "' " +
            "where ID_Cliente =" + param5);

        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Clientes.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ExcluirCurric(string param1)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool excluir = operacao.Delete("delete from Tbl_Curriculum where ID_Curric =" + param1);
        ConexaoBancoSQL.fecharConexao();
        if (excluir == true)
        {
            url = "../Curriculuns.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string SalvarOrcamento(string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("INSERT INTO Tbl_Orcamentos (Empresa, Contato, email,Telefone, Observacoes, Necessidade, Disponibilidade, Data_Solicitacao,StatusORC ) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 + "', '" + param6 + "', '" + param7 + "', getdate()-'03:00:00','EM ABERTO')");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Orcamento_Concluido.aspx?p1=" + param1 + "&p2=" + param2 + "&p3=" + param3 + "&p4=" + param4 + "&p5=" + param5 + "&p6=" + param6 + "&p7=" + param7;
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ExcluirOrcamento(string param1)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("delete from Tbl_Orcamentos where ID_Solicitacao =" + param1);
        ConexaoBancoSQL.fecharConexao();
        if (deletar == true)
        {
            url = "../Orcamento_lista.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string GerarProposta(string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9, string param10,
        string param11, string param12, string param13)
    {
        string url = "";

        OperacaoBanco operacao = new OperacaoBanco();
        Boolean alterar = operacao.Delete("update Tbl_Orcamentos set Roteiro='" + param2 + "', Periodo= '" + param3 + "', Funcionario = '" + param4 +
            "', Horario='" + param5 + "', Franquia='" + param6 + "', Valor1=" + param7 + ", Detalhes1='" + param8 + "', Valor2=" + param9 + ", Detalhes2='" + param10 +
            "', Valor3=" + param11 + ", Detalhes3='" + param12 + "', ObsGerais='" + param13 + "', StatusORC='GERADO' " +
            "where ID_Solicitacao =" + param1);
        ConexaoBancoSQL.fecharConexao();
        if (alterar == true)
        {
            url = "../Orcamento_printer.aspx?IDOrc=" + param1;
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }





    [WebMethod]
    public string AbastecimentoNovo(string param1, string param2, string param3, string param4)
    {
        int Posto_ID = 1;
        string Posto_Nome = "POSTO TREVO";
        string PostoLTGasolina = "3.52";

        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Abastecimentos (Placa, Nome, Valor, Kilometragem , DataAutoriza, Posto, ID_Posto, LTGasolina  ) " +
           "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', " + param4 + ",  getdate()-'03:00:00', '" + Posto_Nome + "'," + Posto_ID + "," + PostoLTGasolina + ")");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Abastecimento_Concluido.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AbastecimentoCredito(string param1)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Abastecimentos_Creditos (DataCredito , Valor, Posto ) " +
           "VALUES (getdate()-'03:00:00', " + param1 + ", 'POSTO TREVO')");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Abastecimento_Planilha.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string SalvarVeiculo(string param1, string param2)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Veiculos  (Placa , Modelo) " +
            "VALUES ('" + param1 + "', '" + param2 + "')");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Veiculos_Lista.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string EditarVeiculo(string param1, string param2, string param3)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"update Tbl_Veiculos set Placa = '" + param1 + "', " +
            "Modelo  = '" + param2 + "' " +
            "where ID_Veiculo = " + param3);

        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Veiculos_Lista.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ExcluirVeiculo(string param1)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("delete from Tbl_Veiculos where ID_Veiculo =" + param1);
        ConexaoBancoSQL.fecharConexao();
        if (deletar == true)
        {
            url = "../Veiculos_Lista.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string AbastLocalExcluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Abastecimento_Local where ID_Abast =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Abastecimento_Local_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AbastLocalSalvar(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("INSERT INTO Tbl_Abastecimento_Local (Nome, Placa,Data_Abastecimento,Talao,valor,Bonificado , Obs ) " +
            "VALUES (" +
            "'" + param0 + "'," +
            "'" + param1 + "'," +
            "'" + param2 + "'," +
            "'" + param3 + "'," +
            param4 + "," +
            "'" + param5 + "'," +
            "'" + param6 + "'" +
            ")");
        ConexaoBancoSQL.fecharConexao();
        if (inserir)
        {

            int talaonew = Convert.ToInt16(param7) + 1;

            OperacaoBanco operacao1 = new OperacaoBanco();
            bool alterar = operacao1.Update("update Tbl_Parametros set Abast_Sequencia = " + talaonew);
            ConexaoBancoSQL.fecharConexao();

            if (alterar)
            {
                url = "../Abastecimento_Local_Listagem.aspx";
            }
            else
            {
                url = "../Sorry.aspx";
            }

        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AbastLocalEditar(string param0, string param1, string param2, string param3, string param4, string param5)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool alterar = operacao.Update("update Tbl_Abastecimento_Local set " +
            "nome = '" + param0 + "', " +
            "Placa  = '" + param1 + "', " +
            "Data_Abastecimento = '" + param2 + "', " +
            "Talao = '" + param3 + "', " +
            "valor = " + param4 +
            " where ID_Abast =" + param5);

        ConexaoBancoSQL.fecharConexao();
        if (alterar == true)
        {
            url = "../Abastecimento_Local_Listagem.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }



    [WebMethod]
    public string ParametrosAlterar(string param0)
    {
        string msg = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool alterar = operacao.Update("update Tbl_Parametros set Abast_Sequencia = " + param0);

        ConexaoBancoSQL.fecharConexao();
        if (alterar == true)
        {
            msg = "Ok! Parâmetros Alterados";
        }
        else
        {
            msg = "NÃO FOI POSSÍVEL ALTERAR PARÂMETROS";
        }

        return msg;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Carrega_Cidades(string param1)
    {

        List<Object> resultado = new List<object>();
        int totaldeRegistros = 0;

        string stringSelect = "select Cidade, valor" +
            " from Tbl_Clientes_Cidade_Custos" +
            " where ID_Cliente = " + param1 +
            " order by Cidade";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            resultado.Add(new
            {
                nome = rcrdset[0].ToString(),
                valor = rcrdset[1].ToString()
            });
            totaldeRegistros += 1;
        }
        ConexaoBancoSQL.fecharConexao();

        if (totaldeRegistros == 0)
        {
            resultado.Add(new
            {
                nome = "X",
                valor = "0"
            });
        }

        //O JavaScriptSerializer vai fazer o web service retornar JSON
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(resultado);

    }



    [WebMethod]
    public string Roteiro_Salvar(string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11)
    {
        string url = "";
        string stringinsert = "INSERT INTO Tbl_Entregas (" +
                    "ID_Cliente, " +
                    "ID_Motoboy, " +
                    "Nome_Destinatario, " +
                    "Endereco, " +
                    "Bairro, " +
                    "Cidade, " +
                    "Valor_Encomenda, " +
                    "Ponto_Ref, " +
                    "Telefone, " +
                    "Data_Encomenda, " +
                    "Latitude, " +
                    "Longitude " +
                    ") VALUES (" +
                    param1 + "," +
                    param2 + "," +
                    "'" + param3 + "'," +
                    "'" + param4 + "'," +
                    "'" + param5 + "'," +
                    "'" + param6 + "'," +
                    param7 + "," +
                    "'" + param8 + "'," +
                    "'" + param9 + "'," +
                    "getdate()," +
                    "'" + param10 + "'," +
                    "'" + param11 + "'" +
                    ")";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(stringinsert);
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            string stringSelect = "select ID_Entrega " +
           " from Tbl_Entregas " +
           " where ( ID_Cliente = " + param1 +
           " and ID_Motoboy = " + param2 +
           " and Endereco = '" + param4 + "'" +
           " and Bairro = '" + param5 + "')";

            operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            while (rcrdset.Read())
            {
                url = rcrdset[0].ToString();
            }
            ConexaoBancoSQL.fecharConexao();
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string Roteiro_Excluir(string param1)
    {
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Entregas where ID_Entrega =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "OK";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Roteiro_Marcadores_Exibir(string param1, string param2)
    {
        List<Object> resultado = new List<object>();
        int totaldeRegistros = 0;

        string stringSelect = "select Endereco, latitude, Longitude " +
                  " from Tbl_Entregas " +
                  " where ID_Cliente = " + param1 +
                  " and ID_Motoboy = " + param2 +
                  " and Status_Entrega = 'EM ABERTO'";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            resultado.Add(new
            {
                titulo = rcrdset[0].ToString(),
                lat = rcrdset[1].ToString(),
                lng = rcrdset[2].ToString()
            });
            totaldeRegistros += 1;
        }
        ConexaoBancoSQL.fecharConexao();

        if (totaldeRegistros == 0)
        {
            resultado.Add(new
            {
                titulo = "X",
                lat = "0",
                lng = "0"
            });
        }

        //O JavaScriptSerializer vai fazer o web service retornar JSON
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(resultado);
    }

    [WebMethod]
    public string Roteiro_Salvar_2(string param1, string param2, string param3, string param4, string param5, string param6)
    {
        string url = "";
        string stringinsert = "INSERT INTO Tbl_Entregas (" +
                    "ID_Cliente, " +
                    "Endereco, " +
                    "Bairro, " +
                    "Cidade, " +
                    "valor_Encomenda , " +
                    "valor_Cliente , " +
                    "Data_Encomenda " +
                    ") VALUES (" +
                    param1 + "," +
                    "'" + param2 + "'," +
                    "'" + param3 + "'," +
                    "'" + param4 + "'," +
                    param5 + " ," +
                    param6 + " ," +
                    "getdate()" +
                    ")";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(stringinsert);
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            string stringSelect = "select ID_Entrega " +
           " from Tbl_Entregas " +
           " where ( ID_Cliente = " + param1 +
           " and Endereco = '" + param2 + "'" +
           " and Bairro = '" + param3 + "')";

            operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
            while (rcrdset.Read())
            {
                url = rcrdset[0].ToString();
            }
            ConexaoBancoSQL.fecharConexao();
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string Roteiro_Motoboy_Setting(string[] param0)
    {
        string msg = "Aleluia";
        string[] a = param0;

        /*
        OperacaoBanco operacao = new OperacaoBanco();
        bool alterar = operacao.Update("update Tbl_Parametros set Abast_Sequencia = " + param0);

        ConexaoBancoSQL.fecharConexao();
        if (alterar == true)
        {
            msg = "Ok! Parâmetros Alterados";
        }
        else
        {
            msg = "NÃO FOI POSSÍVEL ALTERAR PARÂMETROS";
        }
        */

        return msg;
    }


}
