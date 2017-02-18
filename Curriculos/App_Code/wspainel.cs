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
    public string SalvarCurric(string param1, string param2, string param3, string param4, 
        string param5, string param6, string param7, string param8, string param9, string param10,
        string param11, string param12, string param13, string param14, string param15, 
        string param16, string param17, string param18, string param19, string param20, 
        string param21, string param22, string param23, string param24, string param25,
        string param26, string param27, string param28, string param29, string param30,
        string param31, string param32, string param33, string param34, string param35,
        string param36, string param37, string param38, string param39, string param40,
        string param41, string param42, string param43)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Curriculum (Nome, RG , CPF, Endereco, CEP, TelResid, TelCelular, email,  " +
            "Pai, Mae, EstCivil ,Filhos ,HabilitacaoCat , HabilitacaoNum , HabilitacaoEmissao , VeiculoProprio , AnoModelo ," +
            "Renavan ,AreaDesejada ,Empresa1,Periodo1 ,Cargo1 ,Atividades1 , Empresa2 ,Periodo2, Cargo2, Atividades2, " +
            "Empresa3,Periodo3,Cargo3,Atividades3, Escolaridade1 ,Conclusao1, Escolaridade2 ,Conclusao2, " +
            "Escolaridade3 ,Conclusao3, indicacao, Comentarios ,FotoDataURI ,DataCad, Bairro, AnoNascimento,PretensaoSalarial ) " +
            "VALUES " +
            "('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 + "', '" + 
            param6 + "', '" + param7 + "', '" + param8 + "', '" + param9 + "', '" + param10 + "', '" +
            param11 + "', '" + param12 + "', '" + param13 + "', '" + param14 + "', '" + param15 + "', '" +
            param16 + "', '" + param17 + "', '" + param18 + "', '" + param19 + "', '" + param20 + "', '" +
            param21 + "', '" + param22 + "', '" + param23 + "', '" + param24 + "', '" + param25 + "', '" +
            param26 + "', '" + param27 + "', '" + param28 + "', '" + param29 + "', '" + param30 + "', '" +
            param31 + "', '" + param32 + "', '" + param33 + "', '" + param34 + "', '" + param35 + "', '" +
            param36 + "', '" + param37 + "', '" + param38 + "', '" + param39 + "', '" + param40 + "', getdate(), '" + 
            param41 + "', '" + param42 + "', " + param43 + " )");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../CurriculoOK.aspx?Nome=" + param1 + "&Funcao=" + param19;
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

}
