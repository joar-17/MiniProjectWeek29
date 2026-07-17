using Azure.Core.GeoJson;
using NanoidDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace MiniProjectWeek29
{
    abstract class Asset
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PriceDollar { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public string SerialNumber { get; set; } = Nanoid.Generate(size: 4);


        [NotMapped]
        public DateTime ExpirationDate => PurchaseDate.AddYears(3);

        [NotMapped]
        public TimeSpan AssetAge => DateTime.Now - PurchaseDate;

        [NotMapped]
        public string AssetType => GetType().Name;

        [NotMapped]
        public string Status => AssetAge.Days switch
        {
            > 1095 => "EXPIRED",
            > 1005 => "RED",
            > 915 => "YELLOW",
            _ => "NORMAL"
        };

        [NotMapped]
        public Currency Currency => CurrencyData.currencies.FirstOrDefault(c => c.CurrencyCode == Office.CurrencyCode);

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

            if (Status == "RED")
            {
                statusOutput = "\u001b[31m" + Status.PadRight(7) + "\u001b[0m";
            }
            else if (Status == "YELLOW")
            {
                statusOutput = "\u001b[33m" + Status.PadRight(7) + "\u001b[0m";
            }
            else
            {
                statusOutput = Status.PadRight(7);
            }

            Console.WriteLine($"| {Id.ToString().PadRight(3)} | {SerialNumber.PadRight(9)} | {Office.Name.PadRight(10)} | {AssetType.PadRight(10)} | {Brand.PadRight(10)} | {Model.PadRight(25)} | {PriceDollar.ToString().PadRight(9)} | {PriceLocalCurrency.ToString("0.00").PadRight(10)} {Currency.CurrencySymbol.PadRight(3)} | {PurchaseDate.ToString("yyyy-MM-dd").PadRight(13)} | {ExpirationDate.ToString("yyyy-MM-dd").PadRight(12)} | {statusOutput} |");

        }
    }
}
