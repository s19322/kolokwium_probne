using kolokwium_probne.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_probne.Context
{
    public class BakeryContext: DbContext
    {
        public DbSet<Zamowienie> BakeryOrders { get; set; }
        public DbSet<Klient> BakeryClient { get; set; }
        public DbSet<Pracownik> BakeryPracownik { get; set; }
        public DbSet<WyrobCukierniczy> BakeryProduct { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> BakeryProduct_Order { get; set; }
        public BakeryContext() { }

        public BakeryContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Klient>().HasKey(e => e.IdKlient);
            modelBuilder.Entity<Klient>().Property(e => e.IdKlient).ValueGeneratedOnAdd();

            modelBuilder.Entity<Pracownik>().HasKey(e => e.IdPracownik);
            modelBuilder.Entity<Pracownik>().Property(e => e.IdPracownik).ValueGeneratedOnAdd();

            modelBuilder.Entity<Zamowienie>().HasKey(e => e.IdZamowienie);
            modelBuilder.Entity<Zamowienie>().Property(e => e.IdZamowienie).ValueGeneratedOnAdd();
            modelBuilder.Entity<WyrobCukierniczy>().HasKey(e => e.IdWyrobCukierniczy);
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>().HasNoKey();

        }
    }
}
