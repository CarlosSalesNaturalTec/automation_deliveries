using System;
using System.Text;


public partial class Orcamento_Ficha : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PreencheCampos(Request.QueryString["IDorc"]);
            Literal1.Text = str.ToString();
        }
    }

    private void PreencheCampos(string IDOrc)
    {
        string ScriptDados = "";
        string stringSelect = "select ID_Solicitacao, Empresa, Contato, Telefone, email, Necessidade, Disponibilidade,Observacoes, " +
            "format(Data_Solicitacao,'dd/MM/yyyy') as DataOrc, StatusORC, Roteiro , Periodo , Funcionario ,Horario ,Franquia ,Valor1 ,Detalhes1 , " +
            "Valor2 ,Detalhes2, Valor3 ,Detalhes3 , ObsGerais  " +
            "from Tbl_Orcamentos where ID_Solicitacao = " + IDOrc;

        OperacaoBanco operacaoOrc = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdsetORC = operacaoOrc.Select(stringSelect);
        while (rcrdsetORC.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('inputEmpresa').value = \"" + Convert.ToString(rcrdsetORC[1]) + "\";" +
                "document.getElementById('inputContato').value = \"" + Convert.ToString(rcrdsetORC[2]) + "\";" +
                "document.getElementById('inputTelefone').value = \"" + Convert.ToString(rcrdsetORC[3]) + "\";" +
                "document.getElementById('inputEmail').value = \"" + Convert.ToString(rcrdsetORC[4]) + "\";" +
                "document.getElementById('inputNecessidade').value = \"" + Convert.ToString(rcrdsetORC[5]) + "\";" +
                "document.getElementById('inputDisponibilidade').value = \"" + Convert.ToString(rcrdsetORC[6]) + "\";" +
                "document.getElementById('inputPerfil').value = \"" + Convert.ToString(rcrdsetORC[7]) + "\";" +
                "document.getElementById('inputData').value = \"" + Convert.ToString(rcrdsetORC[8]) + "\";" +
                "document.getElementById('inputStatus').value = \"" + Convert.ToString(rcrdsetORC[9]) + "\";" +
                "document.getElementById('inputRoteiro').value = \"" + Convert.ToString(rcrdsetORC[10]) + "\";" +
                "document.getElementById('inputPeriodo').value = \"" + Convert.ToString(rcrdsetORC[11]) + "\";" +
                "document.getElementById('inputFuncionario').value = \"" + Convert.ToString(rcrdsetORC[12]) + "\";" +
                "document.getElementById('inputHorario').value = \"" + Convert.ToString(rcrdsetORC[13]) + "\";" +
                "document.getElementById('inputFranquia').value = \"" + Convert.ToString(rcrdsetORC[14]) + "\";" +
                "document.getElementById('inputValor1').value = \"" + Convert.ToString(rcrdsetORC[15]) + "\";" +
                "document.getElementById('inputDescricao1').value = \"" + Convert.ToString(rcrdsetORC[16]) + "\";" +
                "document.getElementById('inputValor2').value = \"" + Convert.ToString(rcrdsetORC[17]) + "\";" +
                "document.getElementById('inputDescricao2').value = \"" + Convert.ToString(rcrdsetORC[18]) + "\";" +
                "document.getElementById('inputValor3').value = \"" + Convert.ToString(rcrdsetORC[19]) + "\";" +
                "document.getElementById('inputDescricao3').value = \"" + Convert.ToString(rcrdsetORC[20]) + "\";" +
                "document.getElementById('inputObsGerais').value = \"" + Convert.ToString(rcrdsetORC[21]) + "\";" +
                "document.getElementById('IDHidden').value = \"" + IDOrc + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);

    }
}