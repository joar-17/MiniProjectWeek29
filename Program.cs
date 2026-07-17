using Microsoft.EntityFrameworkCore;
using MiniProjectWeek29;
using System.Diagnostics;

Console.WriteLine("Welcome to Asset Tracker\n");
Console.WriteLine("Please read introduction carefully.");
Console.WriteLine("This application enables the user to see, search for and sort assets belonging to the company as well as adding new ones.\n");
Console.WriteLine("The company has six offices:");
Console.WriteLine("Austin, USA");
Console.WriteLine("Raleigh, USA");
Console.WriteLine("Görlitz, Germany");
Console.WriteLine("Sharjah, UAE");
Console.WriteLine("Sendai, Japan");
Console.WriteLine("Sundsvall, Sweden\n");
Console.WriteLine("When adding or sorting assets, enter the options provided in the instructions.");
Console.WriteLine("If no options are given, the user can enter any text.");
Console.WriteLine("Remember that the system is case sensitive! \n");


while (true)
{
    Console.WriteLine("\n0 - Exit \n1 - Add asset \n2 - Uppdate asset \n3 - Show all assets \n4 - Search for assets \n5 - Generate report \n\n");
    Console.Write("Choose option: ");
    string userInput = Console.ReadLine();

    if (userInput == "0")
    {
        Console.WriteLine("Thank you for using Asset tracker");
        break;
    }

    switch (userInput)
    {
        case "1":
            Menu.AddAsset();
            break;
        case "2":
            Menu.UpdateAsset();
            break;
        case "3":
            Menu.PrintAll();
            break;
        case "4":
            Menu.Search();
            break;
        case "5":
            Menu.Report();
            break;
        default:
            Console.WriteLine("\u001b[31mInvalid input\u001b[0m \n");
            break;
    }
}


