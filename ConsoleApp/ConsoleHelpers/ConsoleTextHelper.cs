namespace ConsoleApp.ConsoleHelpers;

internal class ConsoleTextHelper
{
    internal static void Write(string line, string appendix)
    {
        Write($"{line}: {appendix}");
    }

    internal static void Write(string line)
    {
        Console.WriteLine(line);
    }

    internal static void WriteWithColor(string line, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(line);
        Console.ForegroundColor = ConstantsWithInterplolation.Foreground;
    }

    internal static void Warn(string line, string appendix)
    {
        Warn($"{line}: {appendix}");
    }

    internal static void Warn(string line)
    {
        WriteTextWithColor($"{I18nWords.WordWarning.T7e}: ", ConstantsWithInterplolation.ForegroundWarning);
        WriteLineWithColor(line, ConstantsWithInterplolation.ForegroundHighlighted);
    }

    internal static void Error(string line, string appendix)
    {
        Error($"{line}: {appendix}");
    }

    internal static void Error(string line)
    {
        WriteTextWithColor("Error: ", ConstantsWithInterplolation.ForegroundError);
        WriteLineWithColor(line, ConstantsWithInterplolation.ForegroundHighlighted);
    }

    private static void WriteTextWithColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = ConstantsWithInterplolation.Foreground;
    }

    private static void WriteLineWithColor(string line, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(line);
        Console.ForegroundColor = ConstantsWithInterplolation.Foreground;
    }
}