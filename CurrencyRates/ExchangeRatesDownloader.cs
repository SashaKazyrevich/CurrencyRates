using System;
using System.IO;
using System.Net;

namespace CurrencyRates
{
    class ExchangeRatesDownloader
    {
        //Data downloader can be activated a number of times
        //if an error has occurred during downloading 

        private static readonly int maxAttempts = 4;

        public string DownloadData(string link)
        {
            for(var i=0; i<maxAttempts; i++)
            {
                string data = DownloadRates(link);
                if (data!=null)
                {
                    return data;
                }
            }

            return null;
        }
        private string DownloadRates(string link)
        {
            try
            {
                WebClient webClient = new WebClient();
                using (Stream stream = webClient.OpenRead(link))
                {
                    Console.WriteLine($"Downloading from {link}");
                    string request;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        request = reader.ReadToEnd();
                    }

                    return request;
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }
    }
}
