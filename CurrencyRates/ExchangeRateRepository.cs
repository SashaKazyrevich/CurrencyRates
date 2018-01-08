using System.Collections.Generic;
using System.Linq;

namespace CurrencyRates
{
    class ExchangeRateRepository
    {
        public void SaveRates(List<ParsedRates> parsedRates)
        {
            using (var ctx = new CurrencyContext())
            {
                //Create dictionary to check if the currency is already in the table
                var codeList = ctx.Currencies.ToDictionary(r => r.Code, r => r.Id);
                
                foreach (var rate in parsedRates)
                {
                    int currencyId;

                    //If the currency is already in the table Currencies, just add information to ExchangeRates table
                    if (codeList.TryGetValue(rate.Code, out currencyId))
                    {
                        ExchangeRate exchRate = new ExchangeRate() { Date = rate.Date, Ammount = rate.Ammount, Rate = rate.Rate, RatePerOne = rate.Rate / rate.Ammount, CurrencyId = currencyId };
                        ctx.ExchangeRates.Add(exchRate);
                        ctx.SaveChanges();
                    }

                    //If the currency is not already in the table Currencies, add information to Currencies table, ExchangeRates table and to the dictionary
                    else
                    {
                        Currency curr = new Currency() { CurrencyName = rate.CurrencyName, CountryOfOrigin = rate.CountryOfOrigin, Code = rate.Code };
                        ExchangeRate exchRate = new ExchangeRate() { Date = rate.Date, Ammount = rate.Ammount, Rate = rate.Rate, RatePerOne = rate.Rate / rate.Ammount };

                        ctx.Currencies.Add(curr);
                        ctx.ExchangeRates.Add(exchRate);
                        ctx.SaveChanges();
                        codeList.Add(rate.Code, curr.Id);
                    }
                }

            }
        }

         
    }
}
