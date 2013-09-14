using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeLauncher
{
    class GameMenuItem : MenuItem
    {
        LaunchAction action;

        string filename;
        string emulator;

        public GameMenuItem(string t, Vector2 p, Vector2 s, LaunchAction a, string filename, string emulator) 
            : base(t, p, s)
        {
            pos = p;
            size = s;
            text = t;
            action = a;
            this.emulator = emulator;
            this.filename = filename;
        }

        public void Activate()
        {
            action(filename, emulator);
        }

        
    }
}
