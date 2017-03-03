using System;
using System.Net.Mail;

public partial class Abastecimento_Concluido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string idaut = IDAutoriza();

        literal_ID.Text = "Número  : " + idaut;
        literal_nome.Text =  "Nome  : " + Request.QueryString["nome"];
        literal_modelo.Text = "Modelo  : " + Request.QueryString["modelo"];
        literal_placa.Text = "Placa : " +  Request.QueryString["placa"];
        literal_Km.Text = "Kilometragem : " + Request.QueryString["Km"];
        literal_valor.Text = "Valor : R$ " + Request.QueryString["valor"];


        //Define os dados do e-mail
        string nomeRemetente = "Painel de Controle";
        string emailRemetente = "paineldecontrole@loglogistica.com.br";
        string senha = "ss040470";

        //Host da porta SMTP
        string SMTP = "smtp.terra.com.br";

        //string emailDestinatario = "sergiosuarez@loglogistica.com.br";
        string emailDestinatario = "naturalbahia@gmail.com";
        //string emailComCopia        = "email@comcopia.com.br";
        //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

        string assuntoMensagem = "Autorização de Abastecimento - LOG TRANSPORTES";

        string l0 = "<img alt=\"LOG-Transportes\" src=\"http://logmaster.azurewebsites.net/images/logologt.png\"/>";
        string l1 = "<b><p>AUTORIZAÇÃO DE ABASTECIMENTO</p></b>";
        string l2 = "<br/>";
        string l3 = "<p>De: LOG TRANSPORTES</p>";
        string l4 = "<p>Para: POSTO TREVO</p>";
        string l5 = "<p>Data:" + DateTime.Now.ToString("dd/MM/yyyy") + " - Número Autorização: " + idaut + "</p>";
        string l6 = "<br/>";
        string l7 = "<p>Autorizamos o abastecimento do veículo:</p><br/>";
        string l8 = "<p>Modelo:" + Request.QueryString["modelo"] + "</p>";
        string l9 = "<p>Placa :" + Request.QueryString["placa"] + "</p>";
        string l10 = "<p>Motorista:" + Request.QueryString["nome"] + "</p>";
        string l11 = "<p>Valor: R$ " + Request.QueryString["valor"] + "</p>";
        string l12 = "<br/>";
        string l13 = "<p>Atencionamente</p>";
        string l14 = "<br/>";
        string l15 = "<p><b>Sergio Suarez y Martis</b></p>";
        string l16 = "<p><i>Diretor</i></p>";

        string conteudoMensagem = l0 + l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8 + l9 + l10 + l11 + l12 + l13 + l14 + l15 + l16;

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

    public string IDAutoriza()
    {
        string idaut = "";
        string stringselect = @"select ID_Abastecimento from Tbl_Abastecimentos order by ID_Abastecimento desc";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            idaut= Convert.ToString(dados[0]);
            break;
        }
        ConexaoBancoSQL.fecharConexao();

        return idaut;
    }
}