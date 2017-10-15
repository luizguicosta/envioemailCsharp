using System;
using System.Text;
using System.Net.Mail;
using System.Net;
using EnvioEmail;

namespace EnvioEmail
{
    class Program
    {
        private static Email email = null;
        static void Main(string[] args)
        {
            email = new Email
            {
                Origem = "email de origem",
                Destino = "email de destino",
                Assunto = "Assunto do email",
                Mensagem = "mensagem do email",
                EmailCopy = "email para ser copiada o email",
                Usuario = "usuário do sendgrid ou do gmail",
                Senha = "senha do sendgrid ou do gmail"
            };

            //envio via conta gmail
            EnvioEmail.EnviarEmailViaGmail(email);
            //envio via SendGrid
            EnvioEmail.EnviarEmailViaSendGrid(email);

            Console.ReadKey();
        }
    }
}
