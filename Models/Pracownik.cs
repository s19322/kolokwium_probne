using System.ComponentModel.DataAnnotations;

namespace kolokwium_probne.Models
{
    public class Pracownik
    {
        
        public int IdPracownik { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
    }
}