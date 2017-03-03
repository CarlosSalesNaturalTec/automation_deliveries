﻿using System;
using System.Web.Services;

[WebService(Namespace = "http://logmaster.azurewebsites.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class wspainel : System.Web.Services.WebService
{
    public wspainel()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        // ALELUIA ! LOUVADO SEJA O SENHOR JESUS . ELE ME TEM AJUDADO E ME TORNADO SEU PRINCIPE
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
        } else
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
            "veiculo = '" +  param2 + "', " +
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
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 + "', '" + param6 + "', '" + param7 + "', getdate(),'EM ABERTO')");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Orcamento_Concluido.aspx?Empresa=" + param1;
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
    public string AbastecimentoNovo(string param1, string param2, string param3, string param4, string param5)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Abastecimentos (Modelo, Placa, Nome, Valor, Kilometragem , DataAutoriza, Posto ) " +
           "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', " + param4 + ", '" + param5 + "', getdate(), 'POSTO TREVO')");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../Abastecimento_Concluido.aspx?modelo=" + param1 + "&placa="+param2 + "&nome=" + param3 + "&valor=" + param4 + "&Km=" + param5;
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string AbastecimentoCredito(string param1, string param2)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Abastecimentos_Creditos (DataCredito , Valor, Posto ) " +
           "VALUES ('" + param1 + "', " + param2 + ", 'POSTO TREVO')");
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

}
