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

        public static void Init()
        {
            current = new ConsoleMenu(Naviagate);
            menus.Add(current);
        }

        public static void Naviagate(Menu goTo)
        {
            current = goTo;
            foreach (Menu m in menus)
            {
                m.Current = false;
            }
            current.Current = true;
        }

        public static void Update(float dt)
        {
            foreach (Menu menu in menus)
            {
                menu.Update(dt);
            }
        }

        public static void Draw(SpriteBatch sb)
        {
            foreach (Menu menu in menus)
            {
                menu.Draw(sb);
            }
        }
    }
}
