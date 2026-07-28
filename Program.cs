using Microsoft.EntityFrameworkCore;
using MiniProjectWeek29;
using System.Diagnostics;

Console.WriteLine("Welcome to Asset Tracker \n");
Console.WriteLine("Please read introduction carefully. \n");
Console.WriteLine("This application holds the information of the company assets.");
Console.WriteLine("It enables the user to search for, add, uppdate and delete assets \n");
Console.WriteLine("The company has six offices:");
Console.WriteLine("Austin, USA");
Console.WriteLine("Raleigh, USA");
Console.WriteLine("Görlitz, Germany");
Console.WriteLine("Sharjah, UAE");
Console.WriteLine("Sendai, Japan");
Console.WriteLine("Sundsvall, Sweden");

while (true)
{
    Console.WriteLine("\n0 - Exit");
    Console.WriteLine("1 - Add asset");
    Console.WriteLine("2 - Uppdate asset");
    Console.WriteLine("3 - Delete asset");
    Console.WriteLine("4 - Show all assets");
    Console.WriteLine("5 - Search for assets");
    Console.WriteLine("6 - Generate report \n");
    Console.Write("Choose option: ");
    string? userInput = Console.ReadLine();

    if (userInput == "0")
    {
        Console.WriteLine("Thank you for using Asset tracker");
        break;
    }

    switch (userInput)
    {
        case "1":
            MenuCRUD.AddAsset();
            break;
        case "2":
            MenuCRUD.UpdateAsset();
            break;
        case "3":
            MenuCRUD.DeleteAsset();
            break;
        case "4":
            MenuFunctions.PrintAll();
            break;
        case "5":
            MenuFunctions.Search();
            break;
        case "6":
            MenuFunctions.Report();
            break;
        default:
            Console.WriteLine("\u001b[31mInvalid input\u001b[0m \n");
            break;
    }
}
