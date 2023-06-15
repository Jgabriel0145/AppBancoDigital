using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Correntista
    {
        public int? id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime data_nasc { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public DateTime data_cadastro { get; set; }
    }
}
