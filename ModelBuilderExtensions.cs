using Microsoft.EntityFrameworkCore;

namespace MiniProjectWeek29
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Office>().HasData(

                new Office
                {
                    Id = 1,
                    Name = "Austin",
                    Country = "USA",
                    CurrencyCode = "USD"
                },

                new Office
                {
                    Id = 2,
                    Name = "Sundsvall",
                    Country = "Sweden",
                    CurrencyCode = "SEK"
                },

                new Office
                {
                    Id = 3,
                    Name = "Görlitz",
                    Country = "Germany",
                    CurrencyCode = "EUR"
                },

                new Office
                {
                    Id = 4,
                    Name = "Raleigh",
                    Country = "USA",
                    CurrencyCode = "USD"
                },

                new Office
                {
                    Id = 5,
                    Name = "Sharjah",
                    Country = "UAE",
                    CurrencyCode = "AED"
                },

                new Office
                {
                    Id = 6,
                    Name = "Sendai",
                    Country = "Japan",
                    CurrencyCode = "JPY"
                }
                );

            modelBuilder.Entity<Computer>().HasData(
                new Computer
                {
                    Id = 1,
                    Brand = "Lenovo",
                    Model = "ThinkPad T14 Gen 5",
                    PriceDollar = 1399,
                    PurchaseDate = new DateTime(2025, 9, 12),
                    OfficeId = 1,
                    SerialNumber = "C001"
                },

                new Computer
                {
                    Id = 2,
                    Brand = "Apple",
                    Model = "MacBook Air M3 13-inch",
                    PriceDollar = 1099,
                    PurchaseDate = new DateTime(2025, 4, 8),
                    OfficeId = 2,
                    SerialNumber = "C002"
                },

                new Computer
                {
                    Id = 3,
                    Brand = "HP",
                    Model = "EliteBook 840 G11",
                    PriceDollar = 1499,
                    PurchaseDate = new DateTime(2026, 1, 19),
                    OfficeId = 3,
                    SerialNumber = "C003"
                },

                new Computer
                {
                    Id = 4,
                    Brand = "Dell",
                    Model = "Latitude 5450",
                    PriceDollar = 1249,
                    PurchaseDate = new DateTime(2024, 11, 25),
                    OfficeId = 4,
                    SerialNumber = "C004"
                },

                new Computer
                {
                    Id = 5,
                    Brand = "Microsoft",
                    Model = "Surface Laptop 7",
                    PriceDollar = 1299,
                    PurchaseDate = new DateTime(2025, 6, 14),
                    OfficeId = 5,
                    SerialNumber = "C005"
                },

                new Computer
                {
                    Id = 6,
                    Brand = "ASUS",
                    Model = "Zenbook 14 OLED",
                    PriceDollar = 1199,
                    PurchaseDate = new DateTime(2024, 8, 3),
                    OfficeId = 6,
                    SerialNumber = "C006"
                },

                new Computer
                {
                    Id = 7,
                    Brand = "Acer",
                    Model = "TravelMate P4",
                    PriceDollar = 999,
                    PurchaseDate = new DateTime(2023, 10, 17),
                    OfficeId = 1,
                    SerialNumber = "C007"
                },

                new Computer
                {
                    Id = 8,
                    Brand = "Lenovo",
                    Model = "ThinkPad X1 Carbon Gen 12",
                    PriceDollar = 1799,
                    PurchaseDate = new DateTime(2025, 2, 22),
                    OfficeId = 2,
                    SerialNumber = "C008"
                },

                new Computer
                {
                    Id = 9,
                    Brand = "Apple",
                    Model = "MacBook Pro M4 14-inch",
                    PriceDollar = 1599,
                    PurchaseDate = new DateTime(2026, 3, 6),
                    OfficeId = 3,
                    SerialNumber = "C009"
                },

                new Computer
                {
                    Id = 10,
                    Brand = "HP",
                    Model = "ProBook 450 G10",
                    PriceDollar = 949,
                    PurchaseDate = new DateTime(2023, 8, 21),
                    OfficeId = 4,
                    SerialNumber = "C010"
                },

                new Computer
                {
                    Id = 11,
                    Brand = "Dell",
                    Model = "XPS 13 9340",
                    PriceDollar = 1399,
                    PurchaseDate = new DateTime(2024, 5, 16),
                    OfficeId = 5,
                    SerialNumber = "C011"
                },

                new Computer
                {
                    Id = 12,
                    Brand = "ASUS",
                    Model = "ExpertBook B5",
                    PriceDollar = 1099,
                    PurchaseDate = new DateTime(2025, 11, 3),
                    OfficeId = 6,
                    SerialNumber = "C012"
                },

                new Computer
                {
                    Id = 13,
                    Brand = "Microsoft",
                    Model = "Surface Pro 11",
                    PriceDollar = 1199,
                    PurchaseDate = new DateTime(2025, 7, 29),
                    OfficeId = 1,
                    SerialNumber = "C013"
                },

                new Computer
                {
                    Id = 14,
                    Brand = "Acer",
                    Model = "Swift Go 14",
                    PriceDollar = 899,
                    PurchaseDate = new DateTime(2024, 2, 12),
                    OfficeId = 2,
                    SerialNumber = "C014"
                },

                new Computer
                {
                    Id = 15,
                    Brand = "Lenovo",
                    Model = "ThinkCentre M90q Gen 5",
                    PriceDollar = 1049,
                    PurchaseDate = new DateTime(2026, 5, 18),
                    OfficeId = 3,
                    SerialNumber = "C015"
                },

                new Computer
                {
                    Id = 16,
                    Brand = "Apple",
                    Model = "Mac mini M4",
                    PriceDollar = 599,
                    PurchaseDate = new DateTime(2025, 12, 9),
                    OfficeId = 4,
                    SerialNumber = "C016"
                },

                new Computer
                {
                    Id = 17,
                    Brand = "HP",
                    Model = "ZBook Firefly 14 G11",
                    PriceDollar = 1699,
                    PurchaseDate = new DateTime(2024, 9, 27),
                    OfficeId = 5,
                    SerialNumber = "C017"
                },

                new Computer
                {
                    Id = 18,
                    Brand = "Dell",
                    Model = "Precision 3590",
                    PriceDollar = 1549,
                    PurchaseDate = new DateTime(2025, 3, 11),
                    OfficeId = 6,
                    SerialNumber = "C018"
                },

                new Computer
                {
                    Id = 19,
                    Brand = "ASUS",
                    Model = "ROG Zephyrus G14",
                    PriceDollar = 1599,
                    PurchaseDate = new DateTime(2023, 12, 4),
                    OfficeId = 1,
                    SerialNumber = "C019"
                },

                new Computer
                {
                    Id = 20,
                    Brand = "Lenovo",
                    Model = "ThinkPad E14 Gen 5",
                    PriceDollar = 849,
                    PurchaseDate = new DateTime(2024, 6, 20),
                    OfficeId = 2,
                    SerialNumber = "C020"
                },

                new Computer
                {
                    Id = 21,
                    Brand = "Dell",
                    Model = "OptiPlex 7010",
                    PriceDollar = 899,
                    PurchaseDate = new DateTime(2022, 11, 15),
                    OfficeId = 3,
                    SerialNumber = "C021"
                },

                new Computer
                {
                    Id = 22,
                    Brand = "HP",
                    Model = "EliteDesk 800 G6",
                    PriceDollar = 1099,
                    PurchaseDate = new DateTime(2021, 8, 9),
                    OfficeId = 4,
                    SerialNumber = "C022"
                },

                new Computer
                {
                    Id = 23,
                    Brand = "Apple",
                    Model = "MacBook Pro M1 13-inch",
                    PriceDollar = 1299,
                    PurchaseDate = new DateTime(2022, 3, 28),
                    OfficeId = 5,
                    SerialNumber = "C023"
                },

                new Computer
                {
                    Id = 24,
                    Brand = "Acer",
                    Model = "Aspire 5",
                    PriceDollar = 699,
                    PurchaseDate = new DateTime(2023, 7, 18),
                    OfficeId = 6,
                    SerialNumber = "C024"
                },

                new Computer
                {
                    Id = 25,
                    Brand = "Microsoft",
                    Model = "Surface Laptop Studio 2",
                    PriceDollar = 1999,
                    PurchaseDate = new DateTime(2026, 6, 30),
                    OfficeId = 1,
                    SerialNumber = "C025"
                }
            );

            modelBuilder.Entity<Smartphone>().HasData(
                new Smartphone
                {
                    Id = 26,
                    Brand = "Apple",
                    Model = "iPhone 16",
                    PriceDollar = 799,
                    PurchaseDate = new DateTime(2025, 10, 4),
                    OfficeId = 1,
                    SerialNumber = "S001"
                },

                new Smartphone
                {
                    Id = 27,
                    Brand = "Samsung",
                    Model = "Galaxy S25",
                    PriceDollar = 799,
                    PurchaseDate = new DateTime(2026, 2, 16),
                    OfficeId = 2,
                    SerialNumber = "S002"
                },

                new Smartphone
                {
                    Id = 28,
                    Brand = "Google",
                    Model = "Pixel 8",
                    PriceDollar = 699,
                    PurchaseDate = new DateTime(2024, 3, 7),
                    OfficeId = 3,
                    SerialNumber = "S003"
                },

                new Smartphone
                {
                    Id = 29,
                    Brand = "OnePlus",
                    Model = "OnePlus 13",
                    PriceDollar = 899,
                    PurchaseDate = new DateTime(2025, 8, 21),
                    OfficeId = 4,
                    SerialNumber = "S004"
                },

                new Smartphone
                {
                    Id = 30,
                    Brand = "Sony",
                    Model = "Xperia 1 VI",
                    PriceDollar = 1299,
                    PurchaseDate = new DateTime(2024, 10, 12),
                    OfficeId = 5,
                    SerialNumber = "S005"
                },

                new Smartphone
                {
                    Id = 31,
                    Brand = "Samsung",
                    Model = "Galaxy A55",
                    PriceDollar = 449,
                    PurchaseDate = new DateTime(2025, 1, 15),
                    OfficeId = 6,
                    SerialNumber = "S006"
                },

                new Smartphone
                {
                    Id = 32,
                    Brand = "Apple",
                    Model = "iPhone 15",
                    PriceDollar = 699,
                    PurchaseDate = new DateTime(2024, 7, 26),
                    OfficeId = 1,
                    SerialNumber = "S007"
                },

                new Smartphone
                {
                    Id = 33,
                    Brand = "Google",
                    Model = "Pixel 8a",
                    PriceDollar = 499,
                    PurchaseDate = new DateTime(2025, 5, 9),
                    OfficeId = 2,
                    SerialNumber = "S008"
                },

                new Smartphone
                {
                    Id = 34,
                    Brand = "Motorola",
                    Model = "Edge 50 Pro",
                    PriceDollar = 649,
                    PurchaseDate = new DateTime(2023, 11, 18),
                    OfficeId = 3,
                    SerialNumber = "S009"
                },

                new Smartphone
                {
                    Id = 35,
                    Brand = "Samsung",
                    Model = "Galaxy Z Flip6",
                    PriceDollar = 1099,
                    PurchaseDate = new DateTime(2025, 3, 24),
                    OfficeId = 4,
                    SerialNumber = "S010"
                },

                new Smartphone
                {
                    Id = 36,
                    Brand = "Apple",
                    Model = "iPhone 16 Pro",
                    PriceDollar = 999,
                    PurchaseDate = new DateTime(2026, 4, 13),
                    OfficeId = 5,
                    SerialNumber = "S011"
                },

                new Smartphone
                {
                    Id = 37,
                    Brand = "OnePlus",
                    Model = "OnePlus 12",
                    PriceDollar = 799,
                    PurchaseDate = new DateTime(2024, 4, 30),
                    OfficeId = 6,
                    SerialNumber = "S012"
                },

                new Smartphone
                {
                    Id = 38,
                    Brand = "Sony",
                    Model = "Xperia 5 V",
                    PriceDollar = 999,
                    PurchaseDate = new DateTime(2023, 9, 6),
                    OfficeId = 1,
                    SerialNumber = "S013"
                },

                new Smartphone
                {
                    Id = 39,
                    Brand = "Google",
                    Model = "Pixel 7 Pro",
                    PriceDollar = 899,
                    PurchaseDate = new DateTime(2022, 12, 14),
                    OfficeId = 2,
                    SerialNumber = "S014"
                },

                new Smartphone
                {
                    Id = 40,
                    Brand = "Samsung",
                    Model = "Galaxy S23",
                    PriceDollar = 799,
                    PurchaseDate = new DateTime(2023, 7, 19),
                    OfficeId = 3,
                    SerialNumber = "S015"
                },

                new Smartphone
                {
                    Id = 41,
                    Brand = "Motorola",
                    Model = "Moto G85",
                    PriceDollar = 399,
                    PurchaseDate = new DateTime(2025, 6, 2),
                    OfficeId = 4,
                    SerialNumber = "S016"
                },

                new Smartphone
                {
                    Id = 42,
                    Brand = "Apple",
                    Model = "iPhone 14",
                    PriceDollar = 699,
                    PurchaseDate = new DateTime(2021, 10, 8),
                    OfficeId = 5,
                    SerialNumber = "S017"
                }
            );

        }
    }
}
