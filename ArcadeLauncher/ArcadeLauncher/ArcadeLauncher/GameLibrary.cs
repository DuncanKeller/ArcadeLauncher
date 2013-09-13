using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ArcadeLauncher
{
    class GameLibrary
    {
        List<string> files = new List<string>();
        string emulator;

        public void SetEmulator(string e)
        {
            emulator = e;
        }

        public void AddFilesFromDir(string path)
        {
            foreach (string s in Directory.GetFiles(path))
            {
                files.Add(s);
            }
        }
    }
}
