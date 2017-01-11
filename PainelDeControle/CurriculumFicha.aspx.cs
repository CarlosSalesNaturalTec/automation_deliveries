using System;
using System.Text;

public partial class CurriculumFicha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PreencheCampos(Request.QueryString["IDCurric"]);
            Literal1.Text = str.ToString();
        }
    }

    private void PreencheCampos(string IDCur)
    {
        string ScriptDados = "";
        string stringSelect = @"select Nome,RG,CPF,Endereco,CEP,TelResid, TelCelular,email,  " +
            "Pai, Mae, EstCivil ,Filhos ,HabilitacaoCat , HabilitacaoNum , HabilitacaoEmissao , VeiculoProprio , AnoModelo ," +
            "Renavan ,AreaDesejada ,Empresa1,Periodo1 ,Cargo1 ,Atividades1 , Empresa2 ,Periodo2, Cargo2, Atividades2, " +
            "Empresa3,Periodo3,Cargo3,Atividades3, Escolaridade1 ,Conclusao1, Escolaridade2 ,Conclusao2, " +
            "Escolaridade3 ,Conclusao3, indicacao, Comentarios ,FotoDataURI ,DataCad " +
            "from Tbl_Curriculum where ID_Curric = " + IDCur;

        OperacaoBanco operacaocURRIC = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetCURRIC = operacaocURRIC.Select(stringSelect);
        while (rcrdsetCURRIC.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('inputNome').value = \"" + Convert.ToString(rcrdsetCURRIC[0]) + "\";" +
                "document.getElementById('inputRG').value = \"" + Convert.ToString(rcrdsetCURRIC[1]) + "\";" +
                "document.getElementById('inputCPF').value = \"" + Convert.ToString(rcrdsetCURRIC[2]) + "\";" +
                "document.getElementById('inputEnd').value = \"" + Convert.ToString(rcrdsetCURRIC[3]) + "\";" +
                "document.getElementById('inputCEP').value = \"" + Convert.ToString(rcrdsetCURRIC[4]) + "\";" +
                "document.getElementById('inputResid').value = \"" + Convert.ToString(rcrdsetCURRIC[5]) + "\";" +
                "document.getElementById('inputCel').value = \"" + Convert.ToString(rcrdsetCURRIC[6]) + "\";" +
                "document.getElementById('inputemail').value = \"" + Convert.ToString(rcrdsetCURRIC[7]) + "\";" +
                "document.getElementById('inputPai').value = \"" + Convert.ToString(rcrdsetCURRIC[8]) + "\";" +
                "document.getElementById('inputMae').value = \"" + Convert.ToString(rcrdsetCURRIC[9]) + "\";" +
                "document.getElementById('selectEstCivil').value = \"" + Convert.ToString(rcrdsetCURRIC[10]) + "\";" +
                "document.getElementById('selectFilhos').value = \"" + Convert.ToString(rcrdsetCURRIC[11]) + "\";" +
                "document.getElementById('selecthabilita').value = \"" + Convert.ToString(rcrdsetCURRIC[12]) + "\";" +
                "document.getElementById('habilitaNum').value = \"" + Convert.ToString(rcrdsetCURRIC[13]) + "\";" +
                "document.getElementById('habilitaEmiss').value = \"" + Convert.ToString(rcrdsetCURRIC[14]) + "\";" +
                "document.getElementById('selectVeiculo').value = \"" + Convert.ToString(rcrdsetCURRIC[15]) + "\";" +
                "document.getElementById('inputAnoModelo').value = \"" + Convert.ToString(rcrdsetCURRIC[16]) + "\";" +
                "document.getElementById('inputRenavam').value = \"" + Convert.ToString(rcrdsetCURRIC[17]) + "\";" +
                "document.getElementById('selectArea').value = \"" + Convert.ToString(rcrdsetCURRIC[18]) + "\";" +
                "document.getElementById('inputExperiencia1').value = \"" + Convert.ToString(rcrdsetCURRIC[19]) + "\";" +
                "document.getElementById('inputPeriodo1').value = \"" + Convert.ToString(rcrdsetCURRIC[20]) + "\";" +
                "document.getElementById('inputCargo1').value = \"" + Convert.ToString(rcrdsetCURRIC[21]) + "\";" +
                "document.getElementById('inputAtividades1').value = \"" + Convert.ToString(rcrdsetCURRIC[22]) + "\";" +
                "document.getElementById('inputExperiencia2').value = \"" + Convert.ToString(rcrdsetCURRIC[23]) + "\";" +
                "document.getElementById('inputPeriodo2').value = \"" + Convert.ToString(rcrdsetCURRIC[24]) + "\";" +
                "document.getElementById('inputCargo2').value = \"" + Convert.ToString(rcrdsetCURRIC[25]) + "\";" +
                "document.getElementById('inputAtividades2').value = \"" + Convert.ToString(rcrdsetCURRIC[26]) + "\";" +
                "document.getElementById('inputExperiencia3').value = \"" + Convert.ToString(rcrdsetCURRIC[27]) + "\";" +
                "document.getElementById('inputPeriodo3').value = \"" + Convert.ToString(rcrdsetCURRIC[28]) + "\";" +
                "document.getElementById('inputCargo3').value = \"" + Convert.ToString(rcrdsetCURRIC[29]) + "\";" +
                "document.getElementById('inputAtividades3').value = \"" + Convert.ToString(rcrdsetCURRIC[30]) + "\";" +
                "document.getElementById('inputEscolaridade1').value = \"" + Convert.ToString(rcrdsetCURRIC[31]) + "\";" +
                "document.getElementById('inputConclusao1').value = \"" + Convert.ToString(rcrdsetCURRIC[32]) + "\";" +
                "document.getElementById('inputEscolaridade2').value = \"" + Convert.ToString(rcrdsetCURRIC[33]) + "\";" +
                "document.getElementById('inputConclusao2').value = \"" + Convert.ToString(rcrdsetCURRIC[34]) + "\";" +
                "document.getElementById('inputEscolaridade3').value = \"" + Convert.ToString(rcrdsetCURRIC[35]) + "\";" +
                "document.getElementById('inputConclusao3').value = \"" + Convert.ToString(rcrdsetCURRIC[36]) + "\";" +
                "document.getElementById('inputIndicacao').value = \"" + Convert.ToString(rcrdsetCURRIC[37]) + "\";" +
                "document.getElementById('inputComentarios').value = \"" + Convert.ToString(rcrdsetCURRIC[38]) + "\";" +
                "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdsetCURRIC[39]) + "\"/>'; " +
                "document.getElementById('inputDataCad').value = \"" + Convert.ToString(rcrdsetCURRIC[40]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);

    }

}