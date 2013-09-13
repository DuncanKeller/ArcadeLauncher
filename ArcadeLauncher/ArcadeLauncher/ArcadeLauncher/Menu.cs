using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeLauncher
{
    public class Menu
    {
        bool current = false;
        protected List<MenuItem> items = new List<MenuItem>();

        public bool Current
        {
            get { return current; }
            set { current = value; }
        }

        public Menu()
        {

        }

        public void Update(float dt)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            foreach (MenuItem i in items)
            {
                i.Draw(sb);
            }
        }
    }
}
