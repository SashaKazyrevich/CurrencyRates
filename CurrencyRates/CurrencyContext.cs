using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    class CurrencyContext :DbContext
    {
        public CurrencyContext():base("name=CurrencyDBConnectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>()
                        .Property(p => p.RatePerOne)
                        .HasPrecision(12, 5); 
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
