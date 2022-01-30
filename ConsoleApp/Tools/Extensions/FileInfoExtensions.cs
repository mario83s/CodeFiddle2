using System.IO;

namespace ConsoleApp.Tools.Extensions;

internal static class FileInfoExtensions
{
    // TODO: instead of 2845 MB return 2.845 GB ... 1023 MB | 1 GB 1.001 GB, 1.002 GB, ...
    internal static string GetFileSizeKBMBGBetc(this FileInfo fi)
    {
        var bytes = fi.Length;

        if (bytes < 1024 * 10)
        {
            return $"{bytes} B";
        }
        var kb = bytes / 1024;
        if (kb < 1024 * 10)
        {
            return $"{kb} KB";
        }
        var mb = kb / 1024;
        if (mb < 1024 * 10)
        {
            return $"{mb} MB";
        }
        var gb = mb / 1024;
        return $"{gb} GB";
    }
}