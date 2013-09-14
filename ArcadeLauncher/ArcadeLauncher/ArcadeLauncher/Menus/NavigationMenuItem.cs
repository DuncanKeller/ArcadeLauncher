using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeLauncher
{
    class NavigationMenuItem : MenuItem
    {
        NavAction action;
        public Menu toGoTo;
        Menu parent;

        public NavigationMenuItem(string t, Vector2 p, Vector2 s, NavAction navMethod, Menu toGoTo, Menu parent) 
            : base(t, p, s)
        {
            pos = p;
            size = s;
            text = t;
            action = navMethod;
            this.parent = parent;
            this.toGoTo = toGoTo;
        }

        public override void Update(float dt)
        {
            if (parent.Current && Selected)
            {
                if (Input.GamePad.Buttons.A == ButtonState.Pressed &&
                    Input.OldGamePad.Buttons.A == ButtonState.Released)
                {
                    Activate();
                }
            }

            base.Update(dt);
        }

        public void Activate()
        {
            action(toGoTo);
        }
    }
}
