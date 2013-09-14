using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeLauncher
{
    static class MenuManager
    {
        static Menu current;
        static List<Menu> menus = new List<Menu>();

        public static FavoritesMenu favorites;
        public static Dictionary<Console, RomMenu> consoleMenus = new Dictionary<Console, RomMenu>();
        public static ConsoleMenu main;

        public static Menu Current
        {
            get { return current; }
        }

        public static void Init()
        {
            foreach (Console c in Config.consoles)
            {
                RomMenu menu = new RomMenu(Navigate, c);
                consoleMenus.Add(c, menu);
            } 
            
            favorites = new FavoritesMenu(Navigate);
            menus.Add(favorites);

            main = new ConsoleMenu(Navigate);
            main.Current = true;
            current = main;
            menus.Add(main);

            
        }

        public static void Navigate(Menu goTo)
        {
            if (goTo == favorites &&
                favorites.Items.Count == 0)
            {
                return;
            }

            current = goTo;
            foreach (Menu m in menus)
            {
                m.Current = false;
            }

            foreach (Menu m in consoleMenus.Values)
            {
                m.Current = false;
            }
            current.Current = true;

            Input.Reset();
        }

        public static void Update(float dt)
        {
            foreach (Menu menu in menus)
            {
                menu.Update(dt);
            }

            foreach (Menu m in consoleMenus.Values)
            {
                m.Update(dt);
            }
        }

        public static void Draw(SpriteBatch sb)
        {
            foreach (Menu menu in menus)
            {
                menu.Draw(sb);
            }

            foreach (Menu m in consoleMenus.Values)
            {
                m.Draw(sb);
            }
        }
    }
}
