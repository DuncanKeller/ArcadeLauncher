using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeLauncher
{
    class ConsoleMenu : Menu
    {
        public ConsoleMenu(NavAction action) : base()
        {
            Vector2 pos = new Vector2(25, 25);
            Vector2 size = new Vector2(300, 100);
            foreach (Console c in Config.consoles)
            {
                NavigationMenuItem item = new NavigationMenuItem(
                    c.Name, pos, size, action);
                items.Add(item);
                pos.Y += size.Y + 15;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
