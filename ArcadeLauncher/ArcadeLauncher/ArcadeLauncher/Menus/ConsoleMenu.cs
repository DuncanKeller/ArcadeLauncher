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
        public ConsoleMenu(NavAction action)
            : base()
        {
            Vector2 pos = new Vector2(Config.leftMargin, Config.topMargin);
            Vector2 size = new Vector2(Config.screenW - 75, MenuItem.height);

            NavigationMenuItem favItem = new NavigationMenuItem(
                   "Favorites", pos, size, action, MenuManager.favorites, this);
            items.Add(favItem);
            pos.Y += size.Y + MenuItem.spacing;

            foreach (Console c in Config.consoles)
            {
                NavigationMenuItem item = new NavigationMenuItem(
                    c.Name, pos, size, action, MenuManager.consoleMenus[c], this);
                items.Add(item);
                pos.Y += size.Y + MenuItem.spacing;
            }

           

            if (items.Count > 0)
            {
                items[0].Selected = true;
            }
        }

        
    }
}
