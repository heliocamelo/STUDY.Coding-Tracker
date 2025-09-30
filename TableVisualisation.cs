using ConsoleTableExt;

namespace coding_tracker;

public class TableVisualisation
{
    internal static void ShowTable<T>(List<T> tableData) where T : class
    {
        Console.WriteLine("\n\n");
        
        ConsoleTableBuilder
            .From(tableData)
            .WithTitle("Coding")
            .ExportAndWriteLine();
        Console.WriteLine("\n\n");
    }
}