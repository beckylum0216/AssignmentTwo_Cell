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
	/// @brief class for DeathManager our game state for the death event
    class DeathManager:GameState
    {
        private int screenX;
        private int screenY;
        
        SpriteBatch sb;
/** 
*	@brief initialiser for DeathManager state with a given game context
*   @see
*	@param gameCtx the game context variable  
*	@return void
*	@pre must be given valid initialised gameCtx
*	@post 
*/
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
/** 
*	@brief update for DeathManager game state with a given game context, updates the user interface for death
*   @see
*	@param gameCtx the game context variable  
*	@return void
*	@pre must be given valid initialised gameCtx
*	@post 
*/
        public override void Update(GameContext gameCtx)
        {
            UserInterface.Active.Update(gameCtx.GetGameTime());
           
        }
/** 
*	@brief Draw for DeathManager game state with a given game context, draws the panel associated with death
*   @see
*	@param gameCtx the game context variable  
*	@return void
*	@pre must be given valid initialised gameCtx
*	@post 
*/
        public override void Draw(GameContext gameCtx)
        {
            gameCtx.GetGraphics().GraphicsDevice.Clear(Color.Red);
            // draw cursor outside the render target
            UserInterface.Active.IncludeCursorInRenderTarget = true;

            UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
            
        }
    }
}


