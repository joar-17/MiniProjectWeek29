namespace MiniProjectWeek29
{
    internal class MenuCRUD
    {
        public static void AddAsset()
        {
            try
            {
                Console.Write("Enter type (Smartphone, Computer): ");
                string? typeOfAsset = Console.ReadLine();

                Asset newObject;

                if (string.IsNullOrWhiteSpace(typeOfAsset))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Type must be added");
                    Console.ResetColor();
                    return;
                }
                else if (typeOfAsset.ToLower() == "computer")
                {
                    newObject = new Computer();
                }
                else if (typeOfAsset.ToLower() == "smartphone")
                {
                    newObject = new Smartphone();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No such Type");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Enter brand: ");
                string? brand = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(brand))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Brand must be added");
                    Console.ResetColor();
                    return;
                }
                newObject.Brand = brand;

                Console.Write("Enter model: ");
                string? model = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(model))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Model must be added");
                    Console.ResetColor();
                    return;
                }
                newObject.Model = model;

                Console.Write("Enter cost ($): ");
                string? priceInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(priceInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price must be added");
                    Console.ResetColor();
                    return;
                }
                bool isConvertable = int.TryParse(priceInput, out int priceDollar);
                if (isConvertable)
                {
                    newObject.PriceDollar = priceDollar;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price must be written in digits 0-9");
                    Console.ResetColor();
                    return;
                }

                MyDbContext Context = new MyDbContext();

                Console.Write("Enter office (Austin, Sundsvall, Görlitz, Raleigh, Sharjah, Sendai): ");
                string? enteredOffice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(enteredOffice))
                {
                    Console.WriteLine("Office must be added");
                    return;
                }
                Office? office = Context.Offices.FirstOrDefault(o => o.Name == enteredOffice);
                if (office == null)
                {
                    Console.WriteLine($"\u001b[31mNo office in {enteredOffice}\u001b[0m");
                    return;
                }
                newObject.Office = office;

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

                Console.Write("Do you want to confirm creation of asset [Y/n]: ");
                string? confirmation = Console.ReadLine();

                if (confirmation?.ToLower() != "n")
                {
                    Context.Assets.Add(newObject);
                    Context.SaveChanges();
                    Console.WriteLine("\u001b[32mProduct added\u001b[0m");
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
            }
        }

        public static void DeleteAsset()
        {
            try
            {
                Console.Write("Write ID: ");
                string? inputId = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No ID entered");
                    Console.ResetColor();
                    return;
                }

                bool isConvertable = int.TryParse(inputId, out int id);

                if (!isConvertable)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input");
                    Console.ResetColor();
                    return;
                }

                MyDbContext Context = new MyDbContext();
                Asset? objectForRemoval = Context.Assets.FirstOrDefault(a => a.Id == id);

                if (objectForRemoval == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Asset with this ID doesn't exist");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Are you sure you want to delete asset? [Y/n]: ");
                string? confirmation = Console.ReadLine();

                if (confirmation?.ToLower() != "n")
                {
                    Context.Assets.Remove(objectForRemoval);
                    Context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Product removed");
                    Console.ResetColor();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
            }
        }

        public static void UpdateAsset()
        {
            try
            {
                Console.Write("Write ID: ");
                string? idInput = Console.ReadLine();

                bool idIsConvertable = int.TryParse(idInput, out int idInputInt);
                
                if (!idIsConvertable)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("ID consists of numbers");
                    Console.ResetColor();
                    return;
                }

                MyDbContext Context = new MyDbContext();
                Asset? objectForUpdate = Context.Assets.FirstOrDefault(a => a.Id == idInputInt);

                if (objectForUpdate == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ID not found");
                    Console.ResetColor();
                    return;
                }

                Console.WriteLine("Enter new value to fields you want to change. If you wish to keep the value, leave field empty.\n");
                Console.Write("Enter brand: ");
                string? brand = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(brand))
                {
                    objectForUpdate.Brand = brand;
                }

                Console.Write("Enter model: ");
                string? model = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(model))
                {
                    objectForUpdate.Model = model;
                }

                Console.Write("Enter cost ($): ");
                string? priceInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(priceInput))
                {
                    bool priceIsConvertable = int.TryParse(priceInput, out int priceDollar);

                    if (!priceIsConvertable)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Price must be written in digits 0-9");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        objectForUpdate.PriceDollar = priceDollar;
                    }
                }

                Console.Write("Enter office (Austin, Sundsvall, Görlitz, Raleigh, Sharjah, Sendai): ");
                string? enteredOffice = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(enteredOffice))
                {
                    Office? office = Context.Offices.FirstOrDefault(o => o.Name == enteredOffice);

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

                Console.Write("Do you want to chance the purchase date [y/N]: ");
                string? answer = Console.ReadLine();

                if (answer?.ToLower() == "y")
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

                Console.Write("Do you want to confirm changes [Y/n]: ");
                string? confirmation = Console.ReadLine();

                if (confirmation?.ToLower() != "n")
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
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
