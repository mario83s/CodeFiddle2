using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.BL.BartenderApp;

internal class BartenderApp : IApp
{
    public bool InitApp()
    {
        return true;
    }

    public void RunApp()
    {

    }

    public void ExitApp()
    {
        StandardAppExitRoutine.ExitApp();
    }
}