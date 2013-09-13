using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcadeLauncher
{
    class Console
    {
        string name;
        string filepath;

        public string Name
        {
            get { return name; }
        }

        public string FilePath
        {
            get { return filepath; }
        }

        public Console(string name, string filepath)
        {
            this.name = name;
            this.filepath = filepath;
        }
    }
}
