﻿using System;
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
    public string SalvarCurric(string param1, string param2, string param3, string param4, string param5, string param6, string param7)
    {
        string url = "";
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(@"INSERT INTO Tbl_Curriculum (Nome, RG , CPF, Endereco, CEP, TelResid, TelCelular ) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 + "', '" + param6 + "', '" + param7 + "')");
        ConexaoBancoSQL.fecharConexao();
        if (inserir == true)
        {
            url = "../CurriculoOK.aspx";
        }
        else
        {
            url = "../Sorry.aspx";
        }

        return url;
    }

}
