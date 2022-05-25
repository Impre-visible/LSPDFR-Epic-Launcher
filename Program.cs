using System.Diagnostics;

namespace Launcher
{

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            string startGTA, startRPH;
            startGTA = "/C start com.epicgames.launcher://apps/0584d2013f0149a791e7b9bad0eec102%3A6e563a2c0f5f46e3b4e88b5f4ed50cca%3A9d2d0eb64d5c44529cece33fe2a46482?action=launch&silent=true";
            startRPH = "RAGEPluginHook.exe";
            Process.Start("CMD.exe", startGTA);
            Directory.SetCurrentDirectory(@"F:/Epic Games/GTAV/");
            
            while(!IsExecuting("GTA5"))
            {
                Task.Delay(1);
            }
            Process.Start(startRPH);
            Application.Exit();
        }

        static bool IsExecuting(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0) return false;
            foreach (Process p in processes) if (p.HasExited) return false;
            return true;
        }
    }
}