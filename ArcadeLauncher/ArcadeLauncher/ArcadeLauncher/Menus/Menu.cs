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
        protected float offsetX = 0;

        float scrollTimer;
        float maxScrollTimer = 0.5f;

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
            if (current)
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

                if (Input.GamePad.ThumbSticks.Left.Y < -0.75)
                {
                    if (scrollTimer > maxScrollTimer)
                    {
                        scrollTimer = maxScrollTimer - (maxScrollTimer / 10);
                        if (index < items.Count - 1)
                        {
                            items[index].Selected = false;
                            index++;
                            items[index].Selected = true;
                        }
                    }
                    else
                    {
                        scrollTimer += dt / 1000;
                    }
                }
                else if (Input.GamePad.ThumbSticks.Left.Y > 0.75)
                {
                    if (scrollTimer > maxScrollTimer)
                    {
                        scrollTimer = maxScrollTimer - (maxScrollTimer / 10);
                        if (index > 0)
                        {
                            items[index].Selected = false;
                            index--;
                            items[index].Selected = true;
                        }
                    }
                    else
                    {
                        scrollTimer += dt / 1000;
                    }
                }
                else
                {
                    scrollTimer = 0;
                }
            }

            foreach (MenuItem i in items)
            {
                i.Update(dt);
            }

            CamUpdate();
            UpdateSelected();
        }

        public void UpdateSelected()
        {
            if (current)
            {
                offsetX += -offsetX * 0.08f;
            }
            else
            {
                offsetX -= (offsetX - -(Config.screenW + 100)) * 0.08f;
            }
        }

        public void CamUpdate()
        {
            if (items.Count > 0)
            {
                float pos = items[index].Pos.Y;
                float distFromCenter = items[index].Pos.Y - ((Config.screenH / 2) - (MenuItem.height / 2));
                float spaceAbove = (index * MenuItem.height) + (index * MenuItem.spacing);
                float spaceBelow = ((items.Count - (index + 1)) * MenuItem.height) +
                    ((items.Count - (index + 1)) * MenuItem.spacing);
                float speed = 0.07f;

                if (spaceAbove > Config.screenH / 2 &&
                    spaceBelow > Config.screenH / 2)
                {
                    foreach (MenuItem i in items)
                    {
                        i.Pos = new Vector2(i.Pos.X,
                            i.Pos.Y - (distFromCenter * speed));
                    }
                }
                else if (spaceAbove < Config.screenH / 2)
                {
                    float distFromTop = items[0].Pos.Y - Config.topMargin;
                    foreach (MenuItem i in items)
                    {
                        i.Pos = new Vector2(i.Pos.X,
                            i.Pos.Y - (distFromTop * speed));
                    }
                }
                else if (spaceBelow < Config.screenH / 2)
                {
                    float distFromBottom = (items[items.Count - 1].Pos.Y + MenuItem.height) - (Config.screenH - Config.topMargin);
                    foreach (MenuItem i in items)
                    {
                        i.Pos = new Vector2(i.Pos.X,
                            i.Pos.Y - (distFromBottom * speed));
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (MenuItem i in items)
            {
                i.Draw(sb, offsetX);
            }
        }
    }
}
