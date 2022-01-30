namespace ConsoleApp.BL;

internal class StandardAppExitRoutine
{
    internal static void ExitApp(string exitmessage = "app is about to exit. press any key to exit ...")
    {
        Console.WriteLine();
        Console.WriteLine(exitmessage);
        Console.ReadKey();
    }
}