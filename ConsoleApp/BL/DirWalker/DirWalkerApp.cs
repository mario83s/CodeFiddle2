using System.IO;

namespace ConsoleApp.BL.DirWalker;

internal class DirWalkerApp : IApp
{
    public DirWalkerApp(DirWalkerSetup setup)
    {
        _setup = setup;
    }
    private DirWalkerSetup _setup;
    private DirectoryInfo _dirinfo;

    public bool InitApp()
    {
        _dirinfo = new(_setup.Directory);
        if (!_dirinfo.Exists)
        {
            ConsoleTextHelper.Warn(I18nMessages.DirectoryDoesNotExist.T7e, _dirinfo.FullName);
            return false;
        }
        return true;
    }

    public void RunApp()
    {
        DirWalkerJob job = new DirWalkerJob(_setup, _dirinfo);
        job.Execute();
    }

    public void ExitApp()
    {
        StandardAppExitRoutine.ExitApp();
    }
}