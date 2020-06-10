using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_probne.Models
{
    public class Klient
    {
        
        public int IdKlient { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
    }
}
