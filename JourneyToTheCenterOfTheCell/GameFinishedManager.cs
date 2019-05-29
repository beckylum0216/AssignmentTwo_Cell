using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//author Bruno Neto
namespace JourneyToTheCenterOfTheCell
{
	/// @brief class for GameFinishedManager state trigered from finishing game by collecting selenocysteine
    class GameFinishedManager : GameState
    {
        private int screenX;
        private int screenY;
        SpriteBatch sb;

        /** 
        *   @brief default constructor makes space in memory for data  
        *   @see
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public GameFinishedManager()
        {
            
        }

        /** 
        *   @brief initialise the function that initialises the finished state  
        *   @see
        *	@param gameCtx the current game context
        *	@return void
        *	@pre gameCtx must be initialised
        *	@post 
        */
        public override void Initialise(GameContext gameCtx)
        {
            sb = new SpriteBatch(gameCtx.GetGraphics().GraphicsDevice);
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;


            UserInterface.Initialize(gameCtx.GetGameInstance().Content, BuiltinThemes.hd);
            UserInterface.Active.Clear();

            GameFinishedView gui = new GameFinishedView();

            Panel testPanel = gui.GetPanel(gameCtx);

            UserInterface.Active.AddEntity(testPanel);

        }

        /** 
        *   @brief Update the function that updates the ui  
        *   @see
        *	@param gameCtx the current game context
        *	@return void
        *	@pre gameCtx must be initialised
        *	@post 
        */
        public override void Update(GameContext gameCtx)
        {
            
            UserInterface.Active.Update(gameCtx.GetGameTime());
        }

        /** 
        *   @brief Draw the function that draws the states components
        *   @see
        *	@param gameCtx the current game context
        *	@return void
        *	@pre gameCtx must be initialised
        *	@post 
        */
        public override void Draw(GameContext gameCtx)
        {
            // draw cursor outside the render target
            //UserInterface.Active.IncludeCursorInRenderTarget = true;
            gameCtx.GetGraphicsDevice().Clear(Color.CornflowerBlue);
            UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
            // clear buffer
           

            // finalize ui rendering
            UserInterface.Active.DrawMainRenderTarget(gameCtx.GetSpriteBatch());
            

        }
    }
}
