using NanoidDotNet;
using System.ComponentModel.DataAnnotations.Schema;


namespace MiniProjectWeek29
{
    abstract class Asset
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }
        public int PriceDollar { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; } = null!;
        public string SerialNumber { get; init; } = Nanoid.Generate(size: 4);


        [NotMapped]
        public DateTime ExpirationDate => PurchaseDate.AddYears(3);

        [NotMapped]
        public string AssetType => GetType().Name;

        [NotMapped]
        public string Status
        {
            get
            {
                if (DateTime.Today > ExpirationDate)
                {
                    return "EXPIRED";
                }
                else if (DateTime.Today >= ExpirationDate.AddMonths(-3))
                {
                    return "Red";
                }
                else if (DateTime.Today >= ExpirationDate.AddMonths(-6))
                {
                    return "Yellow";
                }
                else
                {
                    return "Green";
                }
            }
        }

        [NotMapped]
        public Currency Currency => CurrencyData.currencies.First(c => c.CurrencyCode == Office.CurrencyCode);

        [NotMapped]
        public double PriceLocalCurrency => PriceDollar * Currency.ConversionRate;




        public Asset()
        {

        }

        public Asset(int priceDollar, DateTime purchaseDate, string brand, string model, Office office)
        {
            PriceDollar = priceDollar;
            PurchaseDate = purchaseDate;
            Brand = brand;
            Model = model;
            Office = office;

        }

        public void Display()
        {
            string statusOutput;

            if (Status == "EXPIRED")
            {
                statusOutput = Status.PadRight(7);
            }
            else if (Status == "Red")
            {
                statusOutput = "\u001b[31m" + Status.PadRight(7) + "\u001b[0m";
            }
            else if (Status == "Yellow")
            {
                statusOutput = "\u001b[33m" + Status.PadRight(7) + "\u001b[0m";
            }
            else
            {
                statusOutput = "\u001b[32m" + Status.PadRight(7) + "\u001b[0m";
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| {Id.ToString().PadRight(3)} | {SerialNumber.PadRight(9)} | {Office.Name.PadRight(10)} | {AssetType.PadRight(10)} | {Brand.PadRight(10)} | {Model.PadRight(25)} | {PriceDollar.ToString().PadRight(9)} | {PriceLocalCurrency.ToString("0.00").PadRight(10)} {Currency.CurrencySymbol.PadRight(3)} | {PurchaseDate.ToString("yyyy-MM-dd").PadRight(13)} | {ExpirationDate.ToString("yyyy-MM-dd").PadRight(12)} | {statusOutput} |");
        }
    }
}
