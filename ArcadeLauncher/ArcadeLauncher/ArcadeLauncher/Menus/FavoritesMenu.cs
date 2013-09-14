using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ArcadeLauncher
{
    class FavoritesMenu : Menu
    {

        public List<MenuItem> Items
        {
            get { return items; }
        }

        public FavoritesMenu(NavAction action)
            : base()
        {
            offsetX = -100 - Config.screenW;
            Vector2 pos = new Vector2(Config.leftMargin, Config.topMargin);
            Vector2 size = new Vector2(Config.screenW - 75, MenuItem.height);
           
            foreach (Rom r in Config.favs)
            {
                RomMenuItem item = new RomMenuItem(r, pos, size, this);
                items.Add(item);
                pos.Y += size.Y + MenuItem.spacing;
            }
            
            if (items.Count > 0)
            {
                items[0].Selected = true;
            }
        }

        public void AddFav(Rom r)
        {
            Vector2 size = new Vector2(Config.screenW - 75, MenuItem.height);
            Vector2 pos = new Vector2(Config.leftMargin, Config.topMargin);

            if (items.Count > 0)
            {
                pos = new Vector2(Config.leftMargin, items[items.Count - 1].Pos.Y + size.Y + MenuItem.spacing);
            }

            RomMenuItem item = new RomMenuItem(r, pos, size, this);
            items.Add(item);
            Config.favs.Add(r);

            if (items.Count == 1)
            {
                items[0].Selected = true;
            }

        }

        public void RemoveFav(Rom r)
        {
            MenuItem toRemove = null;
            bool moveUp = false;

            for (int i = 0; i < items.Count; i++)
            {
                 if (moveUp)
                {
                    items[i].Pos = new Vector2(items[i].Pos.X,
                        items[i].Pos.Y - MenuItem.height - MenuItem.spacing);
                }

                if ((items[i] as RomMenuItem).Rom == r)
                {
                    toRemove = items[i];
                    moveUp = true;
                    Config.favs.Remove(r);
                }
            }

            if (toRemove != null)
            {
                items.Remove(toRemove);
                
            }
        }
    }
}
