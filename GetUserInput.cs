using System.Globalization;

namespace coding_tracker;

internal class GetUserInput
{
    CodingController codingController = new();
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
                    codingController.Get();
                    break;
                case "2":
                    ProcessAdd();
                    break;
                case "3":
                    ProcessDelete();
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
        var duration = GetDurationInput();
        Coding coding = new();
        coding.Date = date;
        coding.Duration = duration;
        codingController.Post(coding);
    }

    private void ProcessDelete()
    {
        codingController.Get();
        Console.WriteLine("Please add id of the category you want to delete (or 0 to return to Main menu).");

        string commandInput = Console.ReadLine();

        while (!Int32.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) ||
               Int32.Parse(commandInput) < 0)
        {
            Console.WriteLine("\nYou have to type a valid Id (or 0 to return to Main Menu).\n");
            commandInput = Console.ReadLine();
        }

        var id = Int32.Parse(commandInput);
        if (id == 0) MainMenu();
        var coding = codingController.GetById(id);
        while (coding.Id == 0)
        {
            Console.WriteLine($"\nRecord with id {id} doesn't exist\n");
            ProcessDelete();
        }

        codingController.Delete(id);
        MainMenu();
    }

    private void ProcessUpdate()
    {
        codingController.Get();
        Console.WriteLine("Please add id of the category you want to update (or 0 to return to Main Menu).");
        string commandInput = Console.ReadLine();
        while (!Int32.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || Int32.Parse(commandInput) < 0)
        {
            Console.WriteLine("\nYou have to type an Id (or 0 to return to Main Menu).\n");
            commandInput = Console.ReadLine();
        }
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

    internal string GetDurationInput()
    {
        Console.WriteLine("\n\nPlease insert the duration: (Format: hh:mm). Type 0 " +
                          "to return to main menu\n\n");
        string durationInput = Console.ReadLine();

        if (durationInput == "0") MainMenu();

        while (!TimeSpan.TryParseExact(durationInput, "h\\:mm", CultureInfo.InvariantCulture, out _)) ;
        {
            Console.WriteLine("\n\nDuration invalid. Please insert the duration: (Format: hh:mm " +
                              "or type 0 to return to main menu.\n\n");
            durationInput = Console.ReadLine();
            if (durationInput == "0") MainMenu();
        }
        return durationInput;
    }
}