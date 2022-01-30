namespace ConsoleApp.ConsoleHelpers;

internal class ConsoleConfigurationHelper
{
    internal static void ConfigeConsole()
    {
        Console.Title = ConstantsWithInterplolation.AppNameWithVersion;
        Console.BackgroundColor = ConstantsWithInterplolation.Background;
        Console.ForegroundColor = ConstantsWithInterplolation.Foreground;
    }
}