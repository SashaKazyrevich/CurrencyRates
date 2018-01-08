using System;

namespace CurrencyRates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define actual date and period of requested days
            DateTime from = DateTime.Today;
            DateTime to = from.AddMonths(-2);
            
            //Create the array of all necessary links
            var links = new LinksGenerator();
            DateTime[] daysDates= links.GetDays(from, to);
            DateTime[] monthsDates = links.GetMonths(from);
            string[] listOfLinks = links.ReturnLinks(daysDates, monthsDates);

            var rawData = new ExchangeRatesDownloader();
            var parser = new Parser();
            var rateRepository = new ExchangeRateRepository(); 

            //Go through links, take all data from each link, parse it and save it to database.
            foreach (var link in listOfLinks)
            {
                string data = rawData.DownloadData(link);
                var parsedData = parser.Parse(data);
                rateRepository.SaveRates(parsedData);
            }
        }
    }
}
