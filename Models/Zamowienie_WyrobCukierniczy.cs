using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace kolokwium_probne.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        
        [ForeignKey("wyrob")]
        public int IdWyrobCukierniczy { get; set; }
       
        [ForeignKey("zamowienie")]
        public int IdZamowienie { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }

        public WyrobCukierniczy wyrob { get; set; }
        public Zamowienie zamowienie { get; set; }


    }
}
