using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_probne.Models
{
    public class NoweZamowienie
    {
        
        [Required]
        public DateTime DataPrzyjecia { get; set; }
       
        [Required]
        public int Ilosc { get; set; }
        [Required]
        public string UwagiDoZamowienia { get; set; }
        public string UwagiDoWypieku { get; set; }
        [Required]
        public List<WyrobCukierniczy> ListaWyrobow { get; set; }
        public string typ { get; set; }



    }
}
