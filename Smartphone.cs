namespace MiniProjectWeek29
{
    internal class Smartphone : Asset
    {
        public Smartphone()
        {

        }

        public Smartphone(int priceDollar, DateTime purchaseDate, string brand, string model, Office office) : base(priceDollar, purchaseDate, brand, model, office)
        {

        }
    }
}
