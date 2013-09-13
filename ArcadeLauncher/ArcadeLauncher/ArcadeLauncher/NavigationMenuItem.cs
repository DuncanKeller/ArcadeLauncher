using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeLauncher
{
    class NavigationMenuItem : MenuItem
    {
        NavAction action;

        public NavigationMenuItem(string t, Vector2 p, Vector2 s, NavAction navMethod) 
            : base(t, p, s)
        {
            pos = p;
            size = s;
            text = t;
            action = navMethod;
        }

        public void Activate()
        {
            throw new NotImplementedException();
            //action(goTo);
        }
    }
}
