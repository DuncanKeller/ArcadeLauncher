using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ArcadeLauncher
{
    public class MenuItem
    {
        protected Vector2 pos;
        protected Vector2 size;
        protected string text;

        public Vector2 Pos  { get { return pos;  } set { pos = value; } }
        public Vector2 Size { get { return size; } }
        public string  Text { get { return text; } set { text = value; } }

        public MenuItem(string t, Vector2 p, Vector2 s)
        {
            pos = p;
            size = s;
            text = t;
        }

        public void Draw(SpriteBatch sb)
        {
            Rectangle r = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
            Vector2 v = new Vector2(pos.X + 10, 
                (pos.Y + (size.Y / 2)) - (Config.defaultFont.MeasureString("|").Y / 2));

            sb.Draw(Config.blank, r, new Color(100, 100, 255, 100));
            sb.DrawString(Config.defaultFont, text, v, Color.White);
        }

    }
}
