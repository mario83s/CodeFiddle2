using ConsoleApp.Tools.Extensions;
using System.IO;
using System.Linq;

namespace ConsoleApp.BL.DirWalker
{
    internal class DirWalkerJob
    {
        private DirWalkerSetup _setup;
        private DirectoryInfo _dirinfo;

        internal DirWalkerJob(DirWalkerSetup setup, DirectoryInfo directory)
        {                
            _setup = setup;
            _dirinfo = directory;
        }

        internal void Execute()
        {
            WalkDirectory(_dirinfo, 0);
        }

        private void WalkDirectory(DirectoryInfo dir, int currentDepth)
        {
            if (currentDepth == _setup.MaxFolderDepth)
            {
                return;
            }

            FileInfo[] files;
            try
            {
                files = dir.GetFiles(_setup.Filter);
            }
            catch (UnauthorizedAccessException)
            {
                ConsoleTextHelper.Warn(I18nMessages.CannotAccessDirectory.T7e, dir.Name);
                return; // cannot access directory
            }
            LogFiles(dir, files, currentDepth);

            var subdirs = dir.GetDirectories();
            WalkSubdirectories(subdirs, currentDepth);
        }

        private void WalkSubdirectories(DirectoryInfo[] subdirs, int currentDepth)
        {
            if (subdirs == null || subdirs.Length == 0)
            {
                return;
            }

            subdirs.ToList().ForEach(d => WalkDirectory(d, currentDepth + 1));
        }

        private void LogFiles(DirectoryInfo dirInfo, FileInfo[] files, int currentDepth)
        {
            if (files == null || files.Length == 0)
            {
                return;
            }

            IndentDirectory(dirInfo, currentDepth);

            files.ToList().ForEach(f => LogFiles(f, currentDepth));
        }

        private void IndentDirectory(DirectoryInfo dirInfo, int pad)
        {
            string str = "".PadLeft(pad) + $"{dirInfo.Name}  :: in {dirInfo.Parent?.FullName}";
            ConsoleTextHelper.WriteWithColor(str, ConsoleColor.Blue);
        }

        private void IndentFile(string text, int pad)
        {
            string str = "".PadLeft(pad) + text;
            ConsoleTextHelper.WriteWithColor(str, ConsoleColor.Cyan);
        }

        private void LogFiles(FileInfo f, int currentDepth)
        {
            string text = _setup.ShowFileSize ?
                $"  file: {f.Name} [{f.GetFileSizeKBMBGBetc()}]" :
                $"  file: {f.Name}";
            IndentFile(text, currentDepth);
        }
    }
}