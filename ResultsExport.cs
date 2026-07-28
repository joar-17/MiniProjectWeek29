using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MiniProjectWeek29
{
    internal class ResultsExport
    {
        public static void ExportAsCsv(List<Asset> assets, string fileName)
        {
            using StreamWriter writer = new StreamWriter(fileName, false, UTF8Encoding.UTF8);

            writer.WriteLine("Id,Brand,Model,PurchaseDate,PriceDollar,OfficeId,SerialNumber,ExpirationDate,AssetType,Currency");

            foreach (Asset asset in assets)
            {
                writer.WriteLine($"{asset.Id},{asset.Brand},{asset.Model},{asset.PurchaseDate},{asset.PriceDollar},{asset.OfficeId},{asset.SerialNumber},{asset.ExpirationDate},{asset.AssetType},{asset.Currency.CurrencyCode}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("csv created");
            Console.ResetColor();
        }

        public static void ExportAsJson(List<Asset> assets, string fileName)
        {
            string jsonProducts = JsonSerializer.Serialize<List<Asset>>(assets);

            File.WriteAllText(fileName, jsonProducts);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("json created");
            Console.ResetColor();
        }

        public static void ExportAsTxt(List<Asset> assets, string fileName)
        {
            using StreamWriter writer = new StreamWriter(fileName, false, UTF8Encoding.UTF8);

            foreach (Asset asset in assets)
            {
                writer.WriteLine($"Id: {asset.Id}\n" +
                                 $"Brand: {asset.Brand}\n" +
                                 $"Model: {asset.Model}\n" +
                                 $"PurchaseDate: {asset.PurchaseDate}\n" +
                                 $"PriceDollar: {asset.PriceDollar}\n" +
                                 $"OfficeId: {asset.OfficeId}\n" +
                                 $"SerialNumber: {asset.SerialNumber}\n" +
                                 $"ExpirationDate: {asset.ExpirationDate}\n" +
                                 $"AssetType: {asset.AssetType}\n" +
                                 $"Currency: {asset.Currency.CurrencyCode}\n");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("txt created");
            Console.ResetColor();
        }

        public static void Export(List<Asset> assets)
        {
            Console.WriteLine("Result can be saved as .json, .csv, or .txt");
            Console.Write("Please enter file name: ");
            string? fileName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A file-name must be entered");
                Console.ResetColor();
                return;
            }

            char[] invalidCharacters = Path.GetInvalidFileNameChars();

            string[] fileType = fileName.Split('.');

            if (fileType.Length == 2 && fileType[1] == "csv" && !string.IsNullOrWhiteSpace(fileType[0]) && !fileName.ContainsAny(invalidCharacters))
            {
                ExportAsCsv(assets, fileName);
            }
            else if (fileType.Length == 2 && fileType[1] == "json" && !string.IsNullOrWhiteSpace(fileType[0]) && !fileName.ContainsAny(invalidCharacters))
            {
                ExportAsJson(assets, fileName);
            }
            else if (fileType.Length == 2 && fileType[1] == "txt" && !string.IsNullOrWhiteSpace(fileType[0]) && !fileName.ContainsAny(invalidCharacters))
            {
                ExportAsTxt(assets, fileName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid file-name");
                Console.ResetColor();
            }
        }
    }
}
