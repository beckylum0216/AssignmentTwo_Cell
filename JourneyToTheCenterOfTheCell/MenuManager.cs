using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    class MenuManager:GameState
    {
        private int screenX;
        private int screenY;
        Texture2D titleS;
        SpriteBatch sb;
        int titleCount = 0;
        public override void Initialise(GameContext gameCtx)
        {
            sb = new SpriteBatch(gameCtx.GetGraphics().GraphicsDevice);
            titleS =  gameCtx.GetGameInstance().Content.Load<Texture2D>("Pics/wikimedia_Cells-base2");

            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;
            
            UserInterface.Initialize(gameCtx.GetGameInstance().Content, BuiltinThemes.hd);
            MenuView gui = new MenuView(gameCtx);
            Panel testPanel = gui.GetPanel(screenX, screenY, UserInterface.Active);


            UserInterface.Active.AddEntity(testPanel);
        }

        public override void Update(GameContext gameCtx)
        {
            UserInterface.Active.Update(gameCtx.GetGameTime());
            if (titleCount < 301)
            {
                titleCount += 1;
            }
        }

        public override void Draw(GameContext gameCtx)
        {
            UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
            if (titleCount < 300)
            {
                sb.Begin();
                sb.Draw(titleS, null,gameCtx.GetGraphics().GraphicsDevice.Viewport.Bounds);
                sb.End();
            }
        }

    }
}
