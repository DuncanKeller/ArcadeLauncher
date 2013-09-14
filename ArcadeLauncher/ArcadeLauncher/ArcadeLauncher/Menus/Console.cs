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
        string filename;

        public string Name
        {
            get { return name; }
        }

        public string FilePath
        {
            get { return filepath; }
        }

        public string FileName
        {
            get { return filename; }
        }

        public Console(string name, string filepath, string filename)
        {
            this.name = name;
            this.filepath = filepath;
            this.filename = filename;
        }
    }
}
