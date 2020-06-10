using kolokwium_probne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_probne.Services
{
    interface IBakeryDbService 
    {
        public IEnumerable<Klient> GetKlients();
        public IEnumerable<Zamowienie> GetZamowienia();
        public IEnumerable<WyrobCukierniczy> GetWyrobyCukiernicze();
    }
}
