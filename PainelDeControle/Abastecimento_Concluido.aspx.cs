using System;
using System.Net.Mail;
using System.Globalization;

public partial class Abastecimento_Concluido : System.Web.UI.Page
{
    string autID = "";
    string autNome = "";
    string autPlaca = "";
    string autKM = "";
    string autValor = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //dados da autorização
        IDAutoriza();

        decimal valor = Convert.ToDecimal(autValor);
        string valorFormatado = valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR"));

        //Define os dados do e-mail
        string nomeRemetente = "LOG Transportes";
        string emailRemetente = "sergiosuarez@loglogistica.com.br";
        string senha = "ss040470";

        //Host da porta SMTP
        string SMTP = "smtp.terra.com.br";

        //destinatarios - emails
        string emailDestinatario = "trevo03@redetrevo.com.br";
        string emailComCopia = "emilia@redetrevo.com.br";
        string emailComCopia1 = "anderson.amorin@postotrevo.com.br";
        string emailComCopia2 = "sergiosuarez@loglogistica.com.br";
        string emailComCopia3 = "regiscorreia@loglogistica.com.br";

        //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

        string assuntoMensagem = "Autorização de Abastecimento - LOG TRANSPORTES";

        string l1 = "<b><p>AUTORIZAÇÃO DE ABASTECIMENTO - Nº : " + autID + "</p></b>";
        string l2 = "<br/>";
        string l3 = "<p>De: LOG TRANSPORTES</p>";
        string l4 = "<p>Para: POSTO TREVO</p>";
        string l5 = "<p>Data:" + DateTime.Now.ToString("dd/MM/yyyy") + "</p>";
        string l6 = "<br/>";
        string l7 = "<p><b>Autorizamos o abastecimento do veículo:</p></b><br/>";
        string l9 = "<p><b>Placa :</b>" + autPlaca + "</p>";
        string l10 = "<p><b>Motorista:</b>" + autNome + "</p>";
        string l11 = "<p><b>Valor:</b> R$ " + valorFormatado + "</p>";
        string l12 = "<br/>";
        string l13 = "<p>Atencionamente</p>";
        string l14 = "<br/>";
        string l15 = "<p><b>Sergio Suarez y Martins</b></p>";
        string l16 = "<p><i>Diretor</i></p>";

        string conteudoMensagem = l1 + l2 + l3 + l4 + l5 + l6 + l7 + l9 + l10 + l11 + l12 + l13 + l14 + l15 + l16;

        //Cria objeto com dados do e-mail.
        MailMessage objEmail = new MailMessage();

        //Define o Campo From e ReplyTo do e-mail.
        objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

        //Define os destinatários do e-mail.
        objEmail.To.Add(emailDestinatario);

        //Enviar cópia para.
        objEmail.CC.Add(emailComCopia);
        objEmail.CC.Add(emailComCopia1);
        objEmail.CC.Add(emailComCopia2);
        objEmail.CC.Add(emailComCopia3);

        //Enviar cópia oculta para.
        //objEmail.Bcc.Add(emailComCopiaOculta);

        //Define a prioridade do e-mail.
        objEmail.Priority = System.Net.Mail.MailPriority.Normal;

        //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
        objEmail.IsBodyHtml = true;

        //Define título do e-mail.
        objEmail.Subject = assuntoMensagem;

        //Define o corpo do e-mail.
        objEmail.Body = conteudoMensagem;

        //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
        objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
        objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


        // Caso queira enviar um arquivo anexo
        //Caminho do arquivo a ser enviado como anexo
        //string arquivo = Server.MapPath("arquivo.jpg");

        // Ou especifique o caminho manualmente
        //string arquivo = @"e:\home\LoginFTP\Web\arquivo.jpg";

        // Cria o anexo para o e-mail
        //Attachment anexo = new Attachment(arquivo, System.Net.Mime.MediaTypeNames.Application.Octet);

        // Anexa o arquivo a mensagem
        //objEmail.Attachments.Add(anexo);

        //Cria objeto com os dados do SMTP
        System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

        //Alocamos o endereço do host para enviar os e-mails  
        objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, senha);
        objSmtp.Host = SMTP;
        objSmtp.Port = 587;
        //Caso utilize conta de email do exchange da locaweb deve habilitar o SSL
        //objEmail.EnableSsl = true;

        //Enviamos o e-mail através do método .send()
        try
        {
            objSmtp.Send(objEmail);
            //Response.Write("E-mail enviado com sucesso !");

        }
        catch (Exception ex)
        {
            Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
        }
        finally
        {
            //excluímos o objeto de e-mail da memória
            objEmail.Dispose();
            //anexo.Dispose();
        }
    }

    public void IDAutoriza()
    {

        string stringselect = "select ID_Abastecimento, Nome , Placa, Kilometragem, Valor from Tbl_Abastecimentos order by ID_Abastecimento desc";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            autID = Convert.ToString(dados[0]);
            autNome = Convert.ToString(dados[1]);
            autPlaca = Convert.ToString(dados[2]);
            autKM = Convert.ToString(dados[3]);
            autValor = Convert.ToString(dados[4]);
            break;
        }
        ConexaoBancoSQL.fecharConexao();

        //apresenta dados na tela
        literal_ID.Text = "Número  : " + autID;
        literal_nome.Text = "Nome  : " + autNome;
        literal_placa.Text = "Placa : " + autPlaca;
        literal_Km.Text = "Kilometragem : " + autKM;
        literal_valor.Text = "Valor : R$ " + autValor;

    }
}