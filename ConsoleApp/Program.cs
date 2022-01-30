// c#10 global using in any calss ... e.g. System
global using System;
global using ConsoleApp.I18n;
global using ConsoleApp.ConsoleHelpers;
global using ConsoleApp.CSharp10;

using ConsoleApp.BL;
using ConsoleApp.BL.TestApp;
using ConsoleApp.BL.DirWalker;

// file-wide namespace without indention
namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        RunDirWalkerApp();
    }

    static void RunTestApp()
    {
        IApp app = new TestApp();
        app.Run();
    }

    static void RunDirWalkerApp()
    {
        DirWalkerSetup setup = new(@"E:\", "*.iso", 5, true);
        IApp app = new DirWalkerApp(setup);
        app.Run();
    }
}