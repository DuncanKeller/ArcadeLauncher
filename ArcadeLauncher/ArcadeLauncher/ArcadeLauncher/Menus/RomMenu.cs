using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeLauncher
{
    class RomMenu : Menu
    {
        public RomMenu(NavAction action, Console c)
            : base()
        {
            offsetX = -100 - Config.screenW;
            Vector2 pos = new Vector2(Config.leftMargin, Config.topMargin);
            Vector2 size = new Vector2(Config.screenW - 75, MenuItem.height);
            if (Config.roms.ContainsKey(c))
            {
                foreach (Rom r in Config.roms[c])
                {
                    RomMenuItem item = new RomMenuItem(r, pos, size, this);
                    items.Add(item);
                    pos.Y += size.Y + MenuItem.spacing;
                }
            }
            if (items.Count > 0)
            {
                items[0].Selected = true;
            }
        }
    }
}
