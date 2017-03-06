using System;
using System.Net.Mail;

public partial class CurriculoOK : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Define os dados do e-mail
        string nomeRemetente = "LOG - Painel de Controle";
        string emailRemetente = "paineldecontrole@loglogistica.com.br";
        string senha = "ss040470";

        //Host da porta SMTP
        string SMTP = "smtp.terra.com.br";

        string emailDestinatario = "rh@loglogistica.com.br";
        //string emailDestinatario = "naturalbahia@gmail.com";
        //string emailComCopia        = "email@comcopia.com.br";
        //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

        string assuntoMensagem = "Novo Curriculum Cadastrado";
        string conteudoMensagem = "<h2>Novo Curriculum Cadastrado no Site</h2>"
            + "<p><b>Nome: </b>" + Request.QueryString["p1"] + "</p>"
            + "<p><b>Endereço:</b> " + Request.QueryString["p2"] + "</p>"
            + "<p><b>Cat. Habilitação:</b> " + Request.QueryString["p3"] + "</p>"
            + "<p><b>Veículo Próprio:</b> " + Request.QueryString["p4"] + "</p>"
            + "<p><b>Ano/Modelo:</b> " + Request.QueryString["p5"] + "</p>"
            + "<p><b>Função desejada:</b> " + Request.QueryString["p6"] + "</p>"
            + "<p><b>Empresa1:</b> " + Request.QueryString["p7"] + "</p>"
            + "<p><b>Cargo:</b> " + Request.QueryString["p8"] + "</p>"
            + "<p><b>Empresa2:</b> " + Request.QueryString["p9"] + "</p>"
            + "<p><b>Cargo:</b> " + Request.QueryString["p10"] + "</p>"
            + "<p><b>Empresa3:</b> " + Request.QueryString["p11"] + "</p>"
            + "<p><b>Cargo:</b> " + Request.QueryString["p12"] + "</p>"
            + "<p><b>Indicação:</b> " + Request.QueryString["p13"] + "</p>"
            + "<p><b>Pretensão Salarial:</b> " + Request.QueryString["p14"] + "</p>"
            ;

        //Cria objeto com dados do e-mail.
        MailMessage objEmail = new MailMessage();

        //Define o Campo From e ReplyTo do e-mail.
        objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

        //Define os destinatários do e-mail.
        objEmail.To.Add(emailDestinatario);

        //Enviar cópia para.
        //objEmail.CC.Add(emailComCopia);

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
            //Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
        }
        finally
        {
            //excluímos o objeto de e-mail da memória
            objEmail.Dispose();
            //anexo.Dispose();
        }
    }
}