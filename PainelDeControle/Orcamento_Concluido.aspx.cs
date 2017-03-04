using System;
using System.Net.Mail;

public partial class Orcamento_Concluido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Define os dados do e-mail
        string nomeRemetente = "Painel de Controle";
        string emailRemetente = "paineldecontrole@loglogistica.com.br";
        string senha = "ss040470";

        //Host da porta SMTP
        string SMTP = "smtp.terra.com.br";

        //string emailDestinatario = "naturalbahia@gmail.com";
        string emailDestinatario = "sergiosuarez@loglogistica.com.br";
        //string emailComCopia        = "email@comcopia.com.br";
        //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

        string assuntoMensagem = "Novo Orçamento Solicitado pelo Site";
        string conteudoMensagem = "<p><b>Empresa:</b> " + Request.QueryString["p1"] + "</p>";
        conteudoMensagem = conteudoMensagem + "<p><b>Contato:</b> " + Request.QueryString["p2"] + "</p>";
        conteudoMensagem = conteudoMensagem + "<p><b>E-mail:</b> " + Request.QueryString["p3"] + "</p>";
        conteudoMensagem = conteudoMensagem + "<p><b>Telefone:</b> " + Request.QueryString["p4"] + "</p>";
        conteudoMensagem = conteudoMensagem + "<p><b>Necessidade:</b> " + Request.QueryString["p6"] + "</p>";
        conteudoMensagem = conteudoMensagem + "<p><b>Disponibilidade:</b> " + Request.QueryString["p7"] + "</p>";
        conteudoMensagem = conteudoMensagem + "<p><b>Perfil:</b> " + Request.QueryString["p5"] + "</p>";

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
            Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
        }
        finally
        {
            //excluímos o objeto de e-mail da memória
            objEmail.Dispose();
            //anexo.Dispose();
        }
    }

}