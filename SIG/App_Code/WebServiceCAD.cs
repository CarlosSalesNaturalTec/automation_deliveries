using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceCAD
/// </summary>
[WebService(Namespace = "http://siglog.azurewebsites.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebServiceCAD : System.Web.Services.WebService
{

    public WebServiceCAD()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
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
            url = "Clientes.aspx";
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
            url = "Clientes.aspx";
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
            url = "Clientes.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

}
