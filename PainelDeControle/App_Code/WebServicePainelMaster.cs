using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebServicePainelMaster : System.Web.Services.WebService
{

    public WebServicePainelMaster()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string EntregadorSalvar(string nome, string veiculo, string modelo, string placa, string idCliente, string cliente, string fotoDataUri)
    {
        string status = "";
        string stringinsert = @"INSERT INTO Tbl_Motoboys (Nome,Veiculo,Modelo,Placa, ID_Cliente , Cliente, FotoDataURI ) values ('" +
            nome + "' , '" + veiculo + "' , '" + modelo + "' , '" + placa + "' , " + idCliente + " , '" + cliente + "' , '" + fotoDataUri + "')";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(stringinsert);
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            status = "Registro Salvo com Sucesso";
        }
        else
        {
            status = "Problemas ao Salvar. Verifique os Dados";
        }

        return status;
    }

}
