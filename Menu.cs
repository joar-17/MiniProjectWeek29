using Azure.Core.GeoJson;
using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Security;
using System.Text;
using System.IO;
using Azure;

namespace MiniProjectWeek29
{
    internal class Menu
    {
        public static void AddAsset()
        {
            try
            {
                Console.Write("Enter type (Smartphone, Computer): ");
                string typeOfAsset = Console.ReadLine();

                Asset newObject;

                if (typeOfAsset == "Smartphone")
                {
                    newObject = new Smartphone();
                }
                else if (typeOfAsset == "Computer")
                {
                    newObject = new Computer();
                }
                else
                {
                    Console.WriteLine("No such type");
                    return;
                }

                Console.Write("Enter brand: ");
                newObject.Brand = Console.ReadLine();

                Console.Write("Enter model: ");
                newObject.Model = Console.ReadLine();

                Console.Write("Enter cost ($): ");
                newObject.PriceDollar = int.Parse(Console.ReadLine());

                MyDbContext Context = new MyDbContext();

                Console.Write("Enter office (Austin, Sundsvall, Görlitz, Raleigh, Sharjah, Sendai): ");
                string enteredOffice = Console.ReadLine();
                
                newObject.Office = Context.Offices.FirstOrDefault(o => o.Name == enteredOffice);
                
                if (newObject.Office is null)
                {
                    Console.WriteLine($"\u001b[31mNo office in {enteredOffice}\u001b[0m");
                    return;
                }

                Console.Write("Enter purcase year (yyyy): ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter purcase month (mm): ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Enter purcase day (dd): ");
                int day = int.Parse(Console.ReadLine());

                newObject.PurchaseDate = new DateTime(year, month, day);

                if ((DateTime.Now - newObject.PurchaseDate).Days < 0)
                {
                    Console.WriteLine("\u001b[31mCannot enter a future date\u001b[0m");
                    return;
                }

                Context.Assets.Add(newObject);
                Context.SaveChanges();

                Console.WriteLine("\u001b[32mProduct added\u001b[0m");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void Print(List<Asset> assetList)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| {"ID".PadRight(3)} | {"Serialnr".PadRight(9)} | {"Office".PadRight(10)} | {"Type".PadRight(10)} | {"Brand".PadRight(10)} | {"Model".PadRight(25)} | {"Price USD".PadRight(9)} | {"Local price".PadRight(14)} | {"Purchase date".PadRight(13)} | {"Warranty EX".PadRight(12)} | {"Status".PadRight(7)} |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (Asset asset in assetList)
            {
                asset.Display();
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public static void Search()
        {
            try
            {
                Console.WriteLine();
                Console.Write("Enter the product you want to search for: ");
                string searchInput = Console.ReadLine();

                MyDbContext Context = new MyDbContext();
                List<Asset> searchResult = Context.Assets.Include(a => a.Office).Where(a => a.Brand == searchInput || a.Model == searchInput || a.Office.Name == searchInput || a.PurchaseDate.Year.ToString() == searchInput).ToList();

                if (searchResult.Count != 0)
                {
                    Print(searchResult);

                    Console.Write("Do you wish to save the data? enter 'yes' ");
                    string response = Console.ReadLine();
                    if (response == "yes")
                    {
                        ExportToCsv(searchResult);
                    }
                }
                else
                {
                    Console.WriteLine("\u001b[31mNo data found\u001b[0m");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public static void PrintAll()
        {
            MyDbContext Context = new MyDbContext();
            List<Asset> rawList = Context.Assets.Include(a => a.Office).ToList();
            List<Asset> sortedList = rawList.OrderBy(a => a.AssetType).ThenBy(a => a.PurchaseDate).ToList();

            Print(sortedList);
        }

        public static void Report()
        {
            MyDbContext Context = new MyDbContext();
            List<Office> officeList = Context.Offices.ToList();

            foreach (Office office in officeList)
            {
                List<Asset> temporaryList = Context.Assets.Include(a => a.Office).Where(a => a.Office == office).ToList();

                Console.WriteLine();
                Console.WriteLine(office.Name);

                double totalValue = 0;

                foreach (Asset asset in temporaryList)
                {
                    totalValue += asset.PriceDollar;
                }

                Console.WriteLine($"Total value: {totalValue} $");

                if (office.CurrencyCode != "USD")
                {
                    Currency currency = temporaryList.First().Currency;
                    double totalValueLocal = totalValue * currency.ConversionRate;
                    Console.WriteLine($"Total value in local currency: {totalValueLocal} {currency.CurrencySymbol}");
                }

                int numberOfAssets = temporaryList.Count();
                Console.WriteLine($"Total assets: {numberOfAssets}");

                List<Asset> nearExp = temporaryList.Where(a => a.AssetAge.Days > 915).ToList();

                if (nearExp.Count > 0)
                {
                    Console.WriteLine("Assets near expiration date:");

                    foreach (Asset asset in nearExp)
                    {
                        Console.WriteLine($"- {asset.Model}");
                    }
                }

                Asset mostExpensive = temporaryList.MaxBy(a => a.PriceDollar);
                Console.WriteLine($"Most expensive asset: {mostExpensive.Model}");
                
            }
        }

        public static void DeleteAsset()
        {
            try
            {
                Console.Write("Write ID: ");
                string inputID = Console.ReadLine();

                int inputIDint = int.Parse(inputID);

                MyDbContext Context = new MyDbContext();
                Asset objectForRemoval = Context.Assets.FirstOrDefault(a => a.Id == inputIDint);
                Context.Assets.Remove(objectForRemoval);
                Context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Product removed");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void UpdateAsset()
        {
            try
            {
                Console.Write("Write ID: ");
                string inputID = Console.ReadLine();

                int inputIDint = int.Parse(inputID);

                MyDbContext Context = new MyDbContext();
                Asset objectForUpdate = Context.Assets.FirstOrDefault(a => a.Id == inputIDint);

                if (objectForUpdate == null)
                {
                    return;
                }

                Console.Write("Enter brand: ");
                string brand = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(brand))
                {
                    objectForUpdate.Brand = brand;
                }

                Console.Write("Enter model: ");
                string model = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(model))
                {
                    objectForUpdate.Model = model;
                }

                Console.Write("Enter cost ($): ");
                string priceDollar = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(priceDollar))
                {
                    objectForUpdate.PriceDollar = int.Parse(priceDollar);
                }

                Console.Write("Enter office (Austin, Sundsvall, Görlitz): ");
                string enteredOffice = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(enteredOffice))
                {
                    Office office = Context.Offices.FirstOrDefault(o => o.Name == enteredOffice);

                    if (office is null)
                    {
                        Console.WriteLine($"\u001b[31mNo office in {enteredOffice}\u001b[0m");
                        return;
                    }
                    else
                    {
                        objectForUpdate.Office = office;
                    }
                }

                Console.Write("Do you want to chance the purchase date, enter 'yes' of press any other key to skip: ");
                string answer = Console.ReadLine();

                if (answer == "yes")
                {
                    Console.Write("Enter purcase year (yyyy): ");
                    int year = int.Parse(Console.ReadLine());

                    Console.Write("Enter purcase month (mm): ");
                    int month = int.Parse(Console.ReadLine());

                    Console.Write("Enter purcase day (dd): ");
                    int day = int.Parse(Console.ReadLine());

                    objectForUpdate.PurchaseDate = new DateTime(year, month, day);

                    if ((DateTime.Now - objectForUpdate.PurchaseDate).Days < 0)
                    {
                        Console.WriteLine("\u001b[31mCannot enter a future date\u001b[0m");
                        return;
                    }
                }

                Console.Write("Do you want to confirm changes, press enter to confirm or enter 'cancel':");
                string confirmation = Console.ReadLine();

                if (confirmation != "cancel")
                {
                    Context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Updates confirmed");
                    Console.ResetColor();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExportToCsv(List<Asset> assets)
        {
            using StreamWriter writer = new StreamWriter("assets.csv", false, UTF8Encoding.UTF8);

            writer.WriteLine("Id,Brand,Model,PurchaseDate,PriceDollar,OfficeId,SerialNumber,ExpirationDate,AssetType,Currency");

            foreach (Asset asset in assets)
            {
                writer.WriteLine($"{asset.Id},{asset.Brand},{asset.Model},{asset.PurchaseDate},{asset.PriceDollar},{asset.OfficeId},{asset.SerialNumber},{asset.ExpirationDate},{asset.AssetType},{asset.Currency.CurrencyCode}");
            }

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("CSV created");
            Console.ResetColor();
        }
    }
}
