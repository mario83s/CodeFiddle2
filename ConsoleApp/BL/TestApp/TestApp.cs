namespace ConsoleApp.BL.TestApp;

internal class TestApp : IApp
{
    bool IApp.InitApp()
    {
        ConsoleConfigurationHelper.ConfigeConsole();
        Console.WriteLine($"starting ... {ConstantsWithInterplolation.AppNameWithVersion}");
        return true;
    }

    void IApp.RunApp()
    {
        ConsoleTextHelper.Warn(I18nMessages.CannotReadFile.T7e, "xyz.zip");
        ConsoleTextHelper.Error(I18nMessages.FileNotFound.T7e, "xyz.zip");
        Console.WriteLine("Please enter your name:");
        string? forename = Console.ReadLine();
        Console.WriteLine("Hello " + forename);
    }

    void IApp.ExitApp()
    {
        StandardAppExitRoutine.ExitApp();
    }
}