using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    class LinksGenerator
    {
        private static readonly string DailyExchangeRatesUrl = "http://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_devizoveho_trhu/denni_kurz.txt?date={0}";
        private static readonly string MonthlyExchangeRatesUrl = "http://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_ostatnich_men/kurzy.txt?mesic={0}&rok={1}";

        //Determine necessary days for daily rates
        public DateTime[] GetDays(DateTime from, DateTime to)
        {
            List<DateTime> days = new List<DateTime>();
            DateTime newday = from;
            int daysCount = (from-to).Days;
           
            for (var i = 0; i <= daysCount; i++)
            {
                newday = newday.AddDays(-1);
                days.Add(newday);
            }
            DateTime[] daysDates = days.ToArray();
            return daysDates;
        }
        
        //Determine necessary dates for geting months for monthly rates
        public DateTime[] GetMonths(DateTime from)
        {
            List<DateTime> month = new List<DateTime>();
            for (int i=1; i<3; i++)
            {
                var to = from.AddMonths(-i);
                month.Add(to);
            }

            DateTime[] monthsDates = month.ToArray();
            return monthsDates;
        }

        //Generate all links according to the defined days and months
        public string[] ReturnLinks(DateTime[] daysDates, DateTime[] monthsDates)
        {
            List<string> links = new List<string>();
            foreach (var day in daysDates)
            {
               links.Add(string.Format(DailyExchangeRatesUrl, day.ToString("dd.MM.yyyy")));
            }
            foreach (var date in monthsDates)
            {
                links.Add(string.Format(MonthlyExchangeRatesUrl, date.Month, date.Year));
            }
            string[] listOfLinks = links.ToArray();
            return listOfLinks;
        }

    }
}
