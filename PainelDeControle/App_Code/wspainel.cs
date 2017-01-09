using System;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
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
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Motoboys (Nome, Veiculo, Modelo, Placa, ID_Cliente, Cliente, FotoDataURI) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', " + param5 + ", '" + param6 + "', '" + param7 + "')");
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
    public string SalvarCliente(string param1, string param2, string param3, string param4)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Clientes (Nome, Responsavel , email, Telefone) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "')");
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
    public string EditarCliente(string param1, string param2, string param3, string param4, string param5)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"update Tbl_Clientes set nome = '" + param1 + "', " +
            "Responsavel  = '" + param2 + "', " +
            "email = '" + param3 + "', " +
            "Telefone = '" + param4 + "' " +
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
}
