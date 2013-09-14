using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ArcadeLauncher
{
    class Config
    {
        public static Texture2D blank;
        public static SpriteFont defaultFont;

        public static List<Console> consoles = new List<Console>();
        public static Dictionary<Console, List<Rom>> roms = new Dictionary<Console, List<Rom>>();
        public static Dictionary<Console, string[]> filetypes = new Dictionary<Console, string[]>();
        public static List<Rom> favs = new List<Rom>();

        public static int screenW;
        public static int screenH;
        public static int topMargin = 25;
        public static int leftMargin = 50;
        public static int selectedMargin = 100;

        public static void Save()
        {
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\emulators\\";
            StreamWriter sw = new StreamWriter(docs + "poops.dat");
            foreach (Rom r in favs)
            {
                sw.WriteLine(r.Name);
            }
            sw.Flush();
            sw.Close();
        }

        public static void Init(ContentManager c, GraphicsDevice g)
        {
            blank = c.Load<Texture2D>("blank");
            defaultFont = c.Load<SpriteFont>("defaultFont");

            screenW = g.Viewport.Width;
            screenH = g.Viewport.Height;

            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\emulators\\";
            List<string> favText = new List<string>();

            if (File.Exists(docs + "poops.dat"))
            {
                StreamReader sr = new StreamReader(docs + "poops.dat");
                while (!sr.EndOfStream)
                {
                    favText.Add(sr.ReadLine());
                }
                sr.Close();
            }

            consoles.Add(new Console("Nintendo 64", docs + "N64\\", "N64.exe"));
            consoles.Add(new Console("NES", docs + "NES\\", "NES.exe"));
            consoles.Add(new Console("SNES", docs + "SNES\\", "SNES.exe"));
            consoles.Add(new Console("Gameboy", docs + "VBA\\", "VBA.exe"));
            consoles.Add(new Console("Genesis", docs + "Genesis\\", "Genesis.exe"));
            consoles.Add(new Console("Gamecube", docs + "GameCube\\", "GameCube.exe"));

            filetypes.Add(consoles[0], new string[] { "goofus" });
            filetypes.Add(consoles[1], new string[] { "goofus" });
            filetypes.Add(consoles[2], new string[] { "smc" });
            filetypes.Add(consoles[3], new string[] { "goofus" });
            filetypes.Add(consoles[4], new string[] { "bin", "smd", "gen" });
            filetypes.Add(consoles[5], new string[] { "goofus" });

            foreach (Console con in consoles)
            {
                string path = con.FilePath + "ROMS\\";
                string[] files = Directory.GetFiles(path);
                List<Rom> romList = new List<Rom>();

                foreach (string f in files)
                {
                    string romPath = f;
                    int indexOfPath = f.LastIndexOf("\\");
                    int indexOfExtension = f.LastIndexOf(".");
                    string name = romPath.Substring(indexOfPath + 1, indexOfExtension - indexOfPath - 1);
                    string extension = romPath.Substring(indexOfExtension + 1, romPath.Length - (indexOfExtension + 1));

                    foreach (string e in filetypes[con])
                    {
                        if (e.Equals(extension, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Rom r = new Rom(name, romPath, con);
                            romList.Add(r);

                            string toRemove = "";
                            foreach (string s in favText)
                            {
                                if (s == r.Name)
                                {
                                    favs.Add(r);
                                    toRemove = s;
                                }
                            }
                            if (toRemove != "")
                            {
                                favText.Remove(toRemove);
                            }

                            break;
                        }
                    }
                }

                roms.Add(con, romList);
            }


        }
    }
}
