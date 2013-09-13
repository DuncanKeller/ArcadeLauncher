﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeLauncher
{
    class ConsoleMenu : Menu
    {
        public ConsoleMenu(NavAction action)
            : base()
        {
            Vector2 pos = new Vector2(Config.leftMargin, Config.topMargin);
            Vector2 size = new Vector2(300, 100);
            foreach (Console c in Config.consoles)
            {
                NavigationMenuItem item = new NavigationMenuItem(
                    c.Name, pos, size, action);
                items.Add(item);
                pos.Y += size.Y + 15;
            }
            if (items.Count > 0)
            {
                items[0].Selected = true;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
