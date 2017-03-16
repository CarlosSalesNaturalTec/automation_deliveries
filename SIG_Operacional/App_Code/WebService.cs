using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
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

}
