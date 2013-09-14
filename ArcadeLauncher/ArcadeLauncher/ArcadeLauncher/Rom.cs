using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcadeLauncher
{
    class Rom
    {
        string name;
        string filepath;
        Console console;

        public string Name
        {
            get { return name; }
        }

        public string FilePath
        {
            get { return filepath; }
        }

        public Console Console
        {
            get { return console; }
        }

        public Rom(string name, string filepath, Console console)
        {
            this.name = name;
            this.filepath = filepath;
            this.console = console;
        }
    }
}
