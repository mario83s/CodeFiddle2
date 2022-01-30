namespace ConsoleApp.BL.DirWalker;

internal class DirWalkerSetup
{
    internal string Directory { get; private set; }
    internal string Filter { get; private set; }
    internal int MaxFolderDepth { get; private set; }
    internal bool ShowFileSize { get; private set; } = false;

    public DirWalkerSetup(string directory, string filter, int maxFolderDepth)
    {
        Directory = directory;
        Filter = filter;
        MaxFolderDepth = maxFolderDepth;
    }

    public DirWalkerSetup(string directory, string filter, int maxFolderDepth, bool showFileSize)
        : this(directory, filter, maxFolderDepth)
    {
        ShowFileSize = showFileSize;
    }
}