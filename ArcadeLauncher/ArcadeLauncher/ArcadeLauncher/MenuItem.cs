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
        bool selected = false;
        Vector2 veloc = new Vector2();

        public Vector2 Pos      { get { return pos;  }     set { pos = value; } }
        public Vector2 Size     { get { return size; } }
        public string  Text     { get { return text; }     set { text = value; } }
        public bool    Selected { get { return selected; } set { selected = value; } }

        public MenuItem(string t, Vector2 p, Vector2 s)
        {
            pos = p;
            size = s;
            text = t;
        }

        public virtual void Update(float dt)
        {
            float destX;
            if (selected)
            {
                destX = Config.selectedMargin;
            }
            else
            {
                destX = Config.leftMargin;
            }

            float dist = destX - pos.X;
            veloc.X += (dist * 0.5f) - (0.4f * veloc.X);
            
            if (Math.Abs(veloc.X) < 1 &&
                Math.Abs(dist) < 1)
            {
                veloc.X = 0;
            }
            pos.X += veloc.X;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Rectangle r = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
            Vector2 v = new Vector2(pos.X + 10, 
                (pos.Y + (size.Y / 2)) - (Config.defaultFont.MeasureString("|").Y / 2));

            sb.Draw(Config.blank, r, new Color(100, 100, 255, 100));
            sb.DrawString(Config.defaultFont, text, v, Color.White);
        }

    }
}
