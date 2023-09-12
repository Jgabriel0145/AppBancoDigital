using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Conta
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public double saldo { get; set; }
        public double limite { get; set; }
        public DateTime data_cadastro { get; set; }
        public int id_correntista { get; set; }
    }
}
