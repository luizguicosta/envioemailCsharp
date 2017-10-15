using SendGrid;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EnvioEmail
{
    public class EnvioEmail
    {
        public static void EnviarEmailViaGmail(Email email)
        {
            var msg = new MailMessage();

            //obj responsável pelo o envio de email
            SmtpClient smtClient = new SmtpClient();
            smtClient.Host = "smtp.gmail.com";
            smtClient.EnableSsl = true;

            //passando as credenciais para o cliente smtp
            smtClient.Credentials = new NetworkCredential(email.Usuario, email.Senha);

            //email remetente
            msg.From = new MailAddress(email.Origem);

            //destinatário
            msg.To.Add(email.Destino);

            //copiar o email para alguém
            msg.Bcc.Add(email.EmailCopy);

            //prioridade do email
            msg.Priority = MailPriority.Normal;

            //utilizar ou não utilizar conteudo html (true utiliza e fase utiliza apenas texto)
            msg.IsBodyHtml = true;

            // assunto do email
            msg.Subject = email.Assunto;

            //corpo do email
            msg.Body = email.Mensagem;

            //ecoding do assunto do email... para a centuação ser reconhecida
            msg.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            try
            {
                smtClient.Send(msg);
                Console.WriteLine("Email enviado com sucesso!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar o email ====>>> " + ex.Message);
            }
        }

        public static void EnviarEmailViaSendGrid(Email email)
        {
            var msg = new SendGridMessage();
            try
            {
                msg.AddTo(email.Destino);
                msg.From = new MailAddress(email.Origem);
                msg.Subject = email.Assunto;
                msg.Text = email.Mensagem;
                var credentials = new NetworkCredential(email.Usuario, email.Senha);
                var transportWeb = new Web(credentials);
                transportWeb.DeliverAsync(msg);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
