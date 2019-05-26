using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//author Bruno Neto
namespace JourneyToTheCenterOfTheCell
{
    class DeathManager:GameState
    {
        private int screenX;
        private int screenY;
        
        SpriteBatch sb;
        
        public override void Initialise(GameContext gameCtx)
        {
            
            sb = new SpriteBatch(gameCtx.GetGraphics().GraphicsDevice);
            

            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;

            //UserInterface.Initialize(gameCtx.GetGameInstance().Content, BuiltinThemes.hd);
            UserInterface.Active.Clear();
            DeathView gui = new DeathView();

            Panel testPanel = gui.GetPanel(gameCtx);

            UserInterface.Active.AddEntity(testPanel);
        }

        public override void Update(GameContext gameCtx)
        {
            UserInterface.Active.Update(gameCtx.GetGameTime());
           
        }

        public override void Draw(GameContext gameCtx)
        {
            gameCtx.GetGraphics().GraphicsDevice.Clear(Color.Red);
            // draw cursor outside the render target
            UserInterface.Active.IncludeCursorInRenderTarget = true;

            UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
            
        }
    }
}


