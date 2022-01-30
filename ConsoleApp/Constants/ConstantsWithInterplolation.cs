namespace ConsoleApp.CSharp10;

internal class ConstantsWithInterplolation
{
    private const string APPVERSION = "0.2";
    private const string APPNAME = "FunTasTic";
    private const string COMPANYNAME = "Fun Company";

    internal const string Company = $"{COMPANYNAME}";
    internal const string Appname = $"{COMPANYNAME} • {APPNAME}";
    internal const string AppNameWithVersion = $"{APPNAME} • {APPVERSION}";

    internal const ConsoleColor Background = ConsoleColor.Black;

    internal const ConsoleColor Foreground = ConsoleColor.Green;
    internal const ConsoleColor ForegroundHighlighted = ConsoleColor.White;
    internal const ConsoleColor ForegroundWarning = ConsoleColor.Yellow;
    internal const ConsoleColor ForegroundError = ConsoleColor.Red;
}