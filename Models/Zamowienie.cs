using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_probne.Models
{
    public class Zamowienie
    {
       
         public int IdZamowienie { get; set; }
         public DateTime DataPrzyjecia { get; set; }
         public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        [ForeignKey("klient")]
        public int IdKlient { get; set; }
        public Klient klient { get; set; }

        [ForeignKey("pracownik")]
        public int IdPracownik { get; set; }

        public Pracownik pracownik { get; set; }
    
    }
}
