using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE_U2_W1_D1_D2_MVC.Models
{
    public class Dipendente
    {
       
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string CF { get; set; }
        public bool Sposato { get; set; }
        public int Numero_Figli { get; set; }
        public string Mansione { get; set; }
        public Dipendente() { }

        public Dipendente( string nome, string cognome, string indirizzo, string cF, bool sposato, int numero_Figli, string mansione)
        {
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            CF = cF;
            Sposato = sposato;
            Numero_Figli = numero_Figli;
            Mansione = mansione;
        }
    }

    
}