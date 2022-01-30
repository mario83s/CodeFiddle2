using System.IO;

namespace ConsoleApp.Tools.Extensions;

internal static class FileInfoExtensions
{
    static readonly double sizeKb = 1024.0d;
    static readonly double sizeMb = sizeKb * sizeKb;
    static readonly double sizeGb = sizeMb * sizeKb;
    static readonly double sizeTerra = sizeGb * sizeKb;
    static readonly double sizePeta = sizeTerra * sizeKb;

    internal static string GetHumanReadableSize(this FileInfo fi)
    {
        var bytes = fi.Length;

        if (bytes < sizeMb)
            return (bytes / sizeKb).ToString("F") + " Kb";
        if (bytes < sizeGb)
            return (bytes / sizeMb).ToString("F") + " Mb";
        if (bytes < sizeTerra)
            return (bytes / sizeGb).ToString("F") + " Gb";
        if (bytes < sizePeta)
            return (bytes / sizePeta).ToString("F") + " Pb";

        return $"{bytes} B";
    }
}