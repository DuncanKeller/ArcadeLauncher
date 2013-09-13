using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ArcadeLauncher
{
    class MenuItem
    {
        Vector2 pos;
        Vector2 size;
        string text;



        public MenuItem(string t, Vector2 p, Vector2 s)
        {
            pos = p;
            size = s;
            text = t;
        }

    }
}
