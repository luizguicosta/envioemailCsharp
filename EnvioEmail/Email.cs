using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioEmail
{
    public class Email
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Usuario { get; set; }
        public string EmailCopy { get; set; }
        public string Senha { get; set; }
    }
}
