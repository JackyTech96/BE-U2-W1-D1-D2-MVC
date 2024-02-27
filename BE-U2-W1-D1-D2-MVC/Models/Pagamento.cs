using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE_U2_W1_D1_D2_MVC.Models
{
    public class Pagamento
    {
       public int IDDipendente { get; set; }
        public DateTime Data_Pagamento { get; set; }
        public decimal Ammontare { get; set; }
        public string Tipo_Pagamento { get; set; }

        public Pagamento() { }

        public Pagamento(int iDDipendente, DateTime data_Pagamento, decimal ammontare, string tipo_Pagamento)
        {
            IDDipendente = iDDipendente;
            Data_Pagamento = data_Pagamento;
            Ammontare = ammontare;
            Tipo_Pagamento = tipo_Pagamento;
        }
    }
}