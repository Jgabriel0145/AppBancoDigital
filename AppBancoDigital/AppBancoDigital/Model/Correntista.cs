using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Correntista
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime Data_Nasc { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int Id_conta { get; set; }
    }
}
