using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Conta
    {
        public string Tipo { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public DateTime Data_Abertura { get; set; }
        public int Id_Cliente { get; set; }
    }
}
