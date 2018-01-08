using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    class ExchangeRate
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Ammount { get; set; }
        public decimal Rate { get; set; } 
        public decimal RatePerOne { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
