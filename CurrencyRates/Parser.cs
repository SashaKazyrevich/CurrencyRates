using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CurrencyRates
{
    internal class Parser
    {
        public List<ParsedRates> Parse(string data)
        {
            List<ParsedRates> result = new List<ParsedRates>();

            //Split data on lines
            string[] lines = data.Split('\n');

            //Get the date from the first line
            var regex = new Regex(@"\b\d{2}\.\d{2}.\d{4}\b");
            Match matchResult = regex.Match(lines[0]);
            var date = matchResult.Value;

            //Go through all lines and fill list of Parsed Rates
            for (var i = 2; i<=lines.Length-1;i++)
            {
                string[] currencyData =lines[i].Split('|');

                //Check, if there where blank lines in data
                if (currencyData.Length!=5)
                { continue;}

                string countryOfOrigin = currencyData[0];
                string currencyName = currencyData[1];
                int ammount = int.Parse(currencyData[2]);
                string code = currencyData[3];
                decimal exchangeRate = decimal.Parse(currencyData[4], new NumberFormatInfo() { NumberDecimalSeparator = "," });

                var item = new ParsedRates();
                item.Date = date;
                item.CountryOfOrigin = countryOfOrigin;
                item.CurrencyName = currencyName;
                item.Code = code;
                item.Ammount = ammount;
                item.Rate = exchangeRate;
                result.Add(item);
            }

            return result; 
           
        }
    }
}
