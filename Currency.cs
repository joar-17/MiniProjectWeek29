using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProjectWeek29
{
    internal class Currency
    {
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public double ConversionRate { get; set; }

        public Currency() 
        {

        }

        public Currency(string currencycode, string currencySymbol, double conversionRate)
        {
            CurrencyCode = currencycode;
            CurrencySymbol = currencySymbol;
            ConversionRate = conversionRate;
        }
    }
}
