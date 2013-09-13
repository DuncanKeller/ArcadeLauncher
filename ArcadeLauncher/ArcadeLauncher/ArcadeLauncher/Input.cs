using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ArcadeLauncher
{
    static class Input
    {
        static GamePadState gps;
        static GamePadState oldGps;

        public static GamePadState GamePad
        {
            get { return gps; }
        }

        public static GamePadState OldGamePad
        {
            get { return oldGps; }
        }

        public static void Update()
        {
            gps = Microsoft.Xna.Framework.Input.GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);
        }

        public static void LateUpdate()
        {
            oldGps = gps;
        }
    }
}
