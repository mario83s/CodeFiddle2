namespace ConsoleApp.BL;

internal class StandardAppExitRoutine
{
    internal static void ExitApp()
    {
        Console.WriteLine();
        Console.WriteLine("app is about to exit. press any key to exit ...");
        Console.ReadKey();
    }
}