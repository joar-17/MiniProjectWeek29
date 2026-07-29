using Microsoft.EntityFrameworkCore;


namespace MiniProjectWeek29
{
    internal class MenuFunctions
    {
        public static void Print(List<Asset> assetList)
        {
            Console.WriteLine();
            Console.WriteLine("============================================================================================================================================================");
            Console.WriteLine("|     |           |            |            |            |                           |           |                |               |              |         |");
            Console.WriteLine($"| {"ID".PadRight(3)} | {"Serialnr".PadRight(9)} | {"Office".PadRight(10)} | {"Type".PadRight(10)} | {"Brand".PadRight(10)} | {"Model".PadRight(25)} | {"Price USD".PadRight(9)} | {"Local price".PadRight(14)} | {"Purchase date".PadRight(13)} | {"Warranty EX".PadRight(12)} | {"Status".PadRight(7)} |");
            Console.WriteLine("|     |           |            |            |            |                           |           |                |               |              |         |");

            foreach (Asset asset in assetList)
            {
                asset.Display();
            }

            Console.WriteLine("============================================================================================================================================================");
        }

        public static void Search()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("User can search for Brand, Model, Office, Status, Asset type, Purchase year or Country");
                Console.Write("Enter search keyword: ");
                string? searchInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(searchInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No search keyword entered");
                    Console.ResetColor();
                    return;
                }

                MyDbContext Context = new MyDbContext();
                List<Asset> searchResult = Context.Assets.Include(a => a.Office).AsEnumerable().Where(a => 
                a.Brand.Equals(searchInput, StringComparison.OrdinalIgnoreCase) || 
                a.Model.Equals(searchInput, StringComparison.OrdinalIgnoreCase) || 
                a.Office.Name.Equals(searchInput, StringComparison.OrdinalIgnoreCase) || 
                a.PurchaseDate.Year.ToString() == searchInput || 
                a.Status.Equals(searchInput, StringComparison.OrdinalIgnoreCase) || 
                a.AssetType.Equals(searchInput, StringComparison.OrdinalIgnoreCase) || 
                a.Office.Country.Equals(searchInput, StringComparison.OrdinalIgnoreCase)).ToList();

                if (searchResult.Count != 0)
                {
                    Print(searchResult);

                    Console.Write("\nDo you wish to save the data? [y/N]: ");
                    string? response = Console.ReadLine();
                    if (response?.ToLower() == "y")
                    {
                    ResultsExport.Export(searchResult);
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
                    Console.WriteLine($"Total value in local currency: {totalValueLocal.ToString("0.00")} {currency.CurrencySymbol}");
                }

                int numberOfAssets = temporaryList.Count();
                Console.WriteLine($"Total assets: {numberOfAssets}");

                List<Asset> nearExp = temporaryList.Where(a => DateTime.Today >= a.ExpirationDate.AddMonths(-6)).ToList();

                if (nearExp.Count > 0)
                {
                    Console.WriteLine("Expired or near expiration date:");

                    foreach (Asset asset in nearExp)
                    {
                        Console.WriteLine($"- {asset.Model}");
                    }
                }

                int maxPrice = temporaryList.Max(a => a.PriceDollar);
                List<Asset> mostExpensive = temporaryList.Where(a => a.PriceDollar == maxPrice).ToList();

                Console.WriteLine("Most expensive assets:");

                foreach (Asset asset in mostExpensive)
                {
                    
                    Console.WriteLine($"- {asset.Model}");
                }

                Console.WriteLine();
            }
        }
    }
}
