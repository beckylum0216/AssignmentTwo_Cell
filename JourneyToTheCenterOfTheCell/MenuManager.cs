using GeonBit.UI;
using GeonBit.UI.Entities;
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

        public override void Initialise(GameContext gameCtx)
        {
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;

            UserInterface.Initialize(gameCtx.GetGameInstance().Content, BuiltinThemes.hd);
            MenuView gui = new MenuView();
            Panel testPanel = gui.GetPanel(screenX, screenY);


            UserInterface.Active.AddEntity(testPanel);
        }

        public override void Update(GameContext gameCtx)
        {
            UserInterface.Active.Update(gameCtx.GetGameTime());
        }

        public override void Draw(GameContext gameCtx)
        {
            UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
        }

    }
}
