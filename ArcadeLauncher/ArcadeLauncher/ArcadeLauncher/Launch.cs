using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ArcadeLauncher
{
    public delegate void LaunchAction(string name, string emulator);
    public delegate void NavAction(Menu m);

    static class Launch
    {     
        public static void LaunchGame(string filename, string emulator)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = filename;
            start.FileName = emulator;
            start.WindowStyle = ProcessWindowStyle.Maximized;
            start.CreateNoWindow = false;
            using (Process p = Process.Start(start))
            {
                p.WaitForExit();
            }
        }
    }
}
