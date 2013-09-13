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
        int index = 0;

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
            if (Input.GamePad.ThumbSticks.Left.Y < -0.75 &&
                Input.OldGamePad.ThumbSticks.Left.Y >= -0.75)
            {
                if (index < items.Count - 1)
                {
                    items[index].Selected = false;
                    index++;
                    items[index].Selected = true;
                }
            }
            else if (Input.GamePad.ThumbSticks.Left.Y > 0.75 &&
                Input.OldGamePad.ThumbSticks.Left.Y <= 0.75)
            {
                if (index > 0)
                {
                    items[index].Selected = false;
                    index--;
                    items[index].Selected = true;
                }
            }

            foreach (MenuItem i in items)
            {
                i.Update(dt);
            }

            CamUpdate();
        }

        public void CamUpdate()
        {
            float pos = items[index].Pos.Y;
            float distFromTop = items[index].Pos.Y - Config.topMargin;

            if (distFromTop > Config.screenH / 4)
            {
                foreach (MenuItem i in items)
                {
                    i.Pos = new Vector2(i.Pos.X,
                        i.Pos.Y - (distFromTop / 100));
                }
            }
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
