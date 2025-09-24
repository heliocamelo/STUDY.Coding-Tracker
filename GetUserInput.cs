using System.Globalization;

namespace coding_tracker;

internal class GetUserInput
{
    internal void MainMenu()
    {
        bool closeApp = false;
        while (closeApp == false)
        {
            Console.WriteLine("\n\nMAIN MENU");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("\nType 0 to Close Application.");
            Console.WriteLine("\n\nType 1 to View Record");
            Console.WriteLine("\n\nType 2 to Add record");
            Console.WriteLine("\n\nType 3 to Delete record");
            Console.WriteLine("\n\nType 4 to Update record");

            string commandInput = Console.ReadLine();

            while (string.IsNullOrEmpty(commandInput))
            {
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                commandInput = Console.ReadLine();
            }

            switch (commandInput)
            {
                case "0":
                    closeApp = true;
                    Environment.Exit(0);
                    break;
                case "1":
                    //codingController.Get();
                    break;
                case "2":
                    ProcessAdd();
                    break;
                case "3":
                    //ProcessDelete();
                    break;
                case "4":
                    //ProcessUpdate();
                    break;
                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    break;
            }
        }
    }

    private void ProcessAdd()
    {
        var date = GetDateInput();
    }

    internal string GetDateInput()
    {
        Console.WriteLine("\n\nPlease insert the date (Format: dd-mm-yy). Type 0 to return to main menu.\n\n");
        string dateInput = Console.ReadLine();
        if (dateInput == "0") MainMenu();
        while (!DateTime.TryParseExact(dateInput, "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            Console.WriteLine("\n\nNot a valid date. Please insert the date with the format: dd-mm-yy.\n\n");
            dateInput = Console.ReadLine();
        }

        return dateInput;
    }
}