using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CurrencyRates.Tests
{
    [TestFixture]
    public class ParserTests
    {
        private readonly Parser _parser = new Parser();

        [Test]
        public void ReturnParsedData()
        {
            var data =
                "30.11.2017 #11\r\nzemě|měna|množství|kód|kurz\r\nAfghánistán|afghani|100|AFN|31,369";
            List<ParsedRates> actual = _parser.Parse(data);
            List<ParsedRates> expected = new List<ParsedRates> {new ParsedRates {Ammount = 100, Code = "AFN", CountryOfOrigin = "Afghánistán", CurrencyName = "afghani", Date = "30.11.2017", Rate = Decimal.Parse("31.369") } };

            Assert.That(actual.Count, Is.EqualTo(expected.Count));
            Assert.That(actual[0].Date, Is.EqualTo(expected[0].Date));
        }

}
}
