using System;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace EnvioEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            EnviarEmailViaGmail();

            Console.ReadKey();
        }

        public static void EnviarEmailViaGmail()
        {

            MailMessage email = new MailMessage();

            //obj responsável pelo o envio de email
            SmtpClient smtClient = new SmtpClient();
            smtClient.Host = "smtp.gmail.com";
            smtClient.EnableSsl = true;

            //passando as credenciais para o cliente smtp
            smtClient.Credentials = new NetworkCredential("sua conta do gmail", "sua senha");

            //email remetente
            email.From = new MailAddress("email do rementente");

            //destinatário
            email.To.Add("email do destinatário");

            //copiar o email para alguém
            email.Bcc.Add("email para ser copiado");

            //prioridade do email
            email.Priority = MailPriority.Normal;

            //utilizar ou não utilizar conteudo html (true utiliza e fase utiliza apenas texto)
            email.IsBodyHtml = true;

            // assunto do email
            email.Subject = "Assunto do email";

            //corpo do email
            email.Body = "Esse aqui é o conteúdo do email... pode ser utilizado tags html e style css";

            //ecoding do assunto do email... para a centuação ser reconhecida
            email.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            try
            {
                smtClient.Send(email);
                Console.WriteLine("Email enviado com sucesso!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar o email ====>>> " + ex.Message);
            }
        }
    }
}
