// c#10 global using in any calss ... e.g. System
global using System;
global using ConsoleApp.I18n;
global using ConsoleApp.ConsoleHelpers;
global using ConsoleApp.CSharp10;

using ConsoleApp.BL;
using ConsoleApp.BL.TestApp;
using ConsoleApp.BL.DirWalker;
using ConsoleApp.BL.BartenderApp;

// file-wide namespace without indention
namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // RunDirWalkerApp();
        // RunTestApp();
        RunBartenderApp();
    }

    static void RunTestApp()
    {
        IApp testapp = new TestApp();
        testapp.Run();
    }

    static void RunDirWalkerApp()
    {
        DirWalkerSetup setup = new(@"E:\", "*.iso", 5, true);
        IApp dirwalker = new DirWalkerApp(setup);
        dirwalker.Run();
    }

    static void RunBartenderApp()
    {
        IApp bartender = new BartenderApp();
        bartender.Run();
    }
}