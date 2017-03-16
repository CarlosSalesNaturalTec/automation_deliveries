using System;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://sigcad.azurewebsites.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string SalvarCliente(string param1, string param2, string param3, string param4, string param5, string param6)
    {
        string url = "Sorry.aspx";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Clientes (Nome, Responsavel , email, Telefone, usuario , Senha, nivel) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 + "', '" + param6 + "',2)");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "Clientes.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string ExcluirCliente(string param1)
    {
        string url = "Sorry.aspx";
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("delete from Tbl_Clientes where ID_Cliente  =" + param1);
        ConexaoBancoSQL.fecharConexao();
        if (deletar == true)
        {
            url = "Clientes.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string EditarCliente(string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url = "Sorry.aspx";
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
            url = "Clientes.aspx";
        }
        else
        {
            url = "Sorry.aspx";
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
}

public class ConexaoBancoSQL
{
    private static SqlConnection objConexao = null;
    private string stringconnection1;

    public void tentarAbrirConexaoRemota()
    {
        objConexao = new SqlConnection();
        objConexao.ConnectionString = stringconnection1;
        objConexao.Open();
    }

    public ConexaoBancoSQL()
    {
        // *** STRING DE CONEXÃO COM BANCO DE DADOS - Atenção! Alterar dados conforme seu servidor
        stringconnection1 = "Server=tcp:serverlog.database.windows.net,1433;Initial Catalog=dblog;Persist Security Info=False;User ID=admserver;Password=Pwd@2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        try
        {
            tentarAbrirConexaoRemota();
        }
        catch
        {
            Console.WriteLine("Atenção! Não foi possível Conectar ao Servidor de Banco de Dados.");
        }
    }

    public static SqlConnection getConexao()
    {
        new ConexaoBancoSQL();
        return objConexao;
    }
    public static void fecharConexao()
    {
        objConexao.Close();
    }
}

public class OperacaoBanco
{
    private SqlCommand TemplateMethod(String query)
    {
        SqlConnection Conexao = ConexaoBancoSQL.getConexao();
        SqlCommand Commando = new SqlCommand(query, Conexao);
        try
        {
            Commando.ExecuteNonQuery();
            return Commando;
        }
        catch
        {
            return Commando;
        }
    }

    public SqlDataReader Select(String query)
    {
        SqlDataReader dadosObtidos = TemplateMethod(query).ExecuteReader();
        return dadosObtidos;
    }

    public Boolean Insert(String query)
    {
        SqlConnection Conexao = ConexaoBancoSQL.getConexao();
        SqlCommand Commando = new SqlCommand(query, Conexao);
        try
        {
            Commando.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Boolean Update(String query)
    {
        SqlConnection Conexao = ConexaoBancoSQL.getConexao();
        SqlCommand Commando = new SqlCommand(query, Conexao);
        try
        {
            Commando.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Boolean Delete(String query)
    {
        SqlConnection Conexao = ConexaoBancoSQL.getConexao();
        SqlCommand Commando = new SqlCommand(query, Conexao);
        try
        {
            Commando.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
    }

}
