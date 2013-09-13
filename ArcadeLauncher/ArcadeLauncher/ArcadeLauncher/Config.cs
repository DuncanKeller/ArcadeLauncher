using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ArcadeLauncher
{
    class Config
    {
        public static Texture2D blank;
        public static SpriteFont defaultFont;

        public static List<Console> consoles = new List<Console>();

        public static void Init(ContentManager c)
        {
            blank = c.Load<Texture2D>("blank");
            defaultFont = c.Load<SpriteFont>("defaultFont");

            consoles.Add(new Console("Corkus 64", "dsfsdfds"));
            consoles.Add(new Console("F-BUTT", "dsfsdfds"));
            consoles.Add(new Console("Pocket Plup", "dsfsdfds"));
        }
    }
}
