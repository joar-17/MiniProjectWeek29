namespace MiniProjectWeek29
{
    internal static class CurrencyData
    {
        public static List<Currency> currencies = new List<Currency>
        {
            new Currency("EUR", "€", 0.87),
            new Currency("SEK", "kr", 9.61),
            new Currency("USD", "$", 1.0),
            new Currency("AED", "د.إ", 3.67),
            new Currency("JPY", "¥", 162.30)
        };
    }
}
