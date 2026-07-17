using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MiniProjectWeek29
{
    internal class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string CurrencyCode { get; set; }

        public Office()
        {

        }

        public Office(string name, string country, string currencycode) 
        {
            Name = name;
            Country = country;
            CurrencyCode = currencycode;
        }
    }
}
