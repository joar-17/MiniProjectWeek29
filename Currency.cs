namespace MiniProjectWeek29
{
    internal class Currency
    {
        public string CurrencyCode { get; }
        public string CurrencySymbol { get; }
        public double ConversionRate { get; }


        public Currency(string currencycode, string currencySymbol, double conversionRate)
        {
            CurrencyCode = currencycode;
            CurrencySymbol = currencySymbol;
            ConversionRate = conversionRate;
        }
    }
}
