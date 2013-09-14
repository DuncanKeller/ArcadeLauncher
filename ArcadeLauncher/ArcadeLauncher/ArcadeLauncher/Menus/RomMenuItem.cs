using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ArcadeLauncher
{

    class RomMenuItem : MenuItem
    {
        Rom rom;
        Menu parent;

        public RomMenuItem(Rom r, Vector2 p, Vector2 s, Menu parent)
            : base(r.Name, p, s)
        {
            rom = r;
            this.parent = parent;
        }

        public Rom Rom
        {
            get { return rom; }
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (parent.Current && Selected)
            {
                if (Input.GamePad.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                    Input.OldGamePad.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Released)
                {
                    Activate();
                }

                if (Input.GamePad.Buttons.B == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                    Input.OldGamePad.Buttons.B == Microsoft.Xna.Framework.Input.ButtonState.Released)
                {
                    Back();
                }

                if (Input.GamePad.Buttons.Y == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                    Input.OldGamePad.Buttons.Y == Microsoft.Xna.Framework.Input.ButtonState.Released)
                {
                    if (MenuManager.favorites != MenuManager.Current)
                    {
                        if (Config.favs.Contains(rom))
                        {
                            MenuManager.favorites.RemoveFav(rom);
                        }
                        else
                        {
                            MenuManager.favorites.AddFav(rom);
                        }
                    }
                }
            }
        }

        public void Back()
        {
            MenuManager.Navigate(MenuManager.main);
        }

        public void Activate()
        {
            Launch.LaunchGame(rom.FilePath, rom.Console.FilePath + rom.Console.FileName);
        }
    }
}
