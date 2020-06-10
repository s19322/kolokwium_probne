using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_probne.Models
{
    public class WyrobCukierniczy
    {
        
        public int IdWyrobCukierniczy { get; set; }
        public string Nazwa { get; set; }
        public float CenaZaSztuke { get; set; }

        public string typ { get; set; }
    }
}
