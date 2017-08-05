using System;
using System.Web.Services;

[WebService(Namespace = "http://logmaster.azurewebsites.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
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

}
