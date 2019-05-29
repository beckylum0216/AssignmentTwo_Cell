using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    /**
     * @brief finite state machine context class used to control the states of the game 
     */
    public class GameContext
    {
        private Game gameInstance;
        private GameState gameState;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameTime gameTime;
        private GraphicsDevice gameGraphicsDevice;


        /** 
        *   @brief constructor for GameContext
        *   @see
        *	@param inputGame the game object from monogame 
        *	@param inputGraphics the graphics device maanager
        *	@param inputSpritBatch
        *	@param inputDevice
        *	@return 
        *	@pre 
        *	@post 
        */
        public GameContext(Game inputGame, GraphicsDeviceManager inputGraphics, SpriteBatch inputSpriteBatch, GraphicsDevice inputDevice)
        {
            this.gameInstance = inputGame;
            this.graphics = inputGraphics;
            this.spriteBatch = inputSpriteBatch;
            this.gameGraphicsDevice = inputDevice;
            gameState = new GameOneManager();
        }

        /** 
        *   @brief mutator to te game instance
        *   @see
        *	@param inputGame instance of the monogame
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre game must exist
        *	@post 
        */
        public void SetGameInstance(Game inputGame)
        {
            this.gameInstance = inputGame;
        }

        /** 
        *   @brief accessor to te game instance
        *   @see
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return gameInstance accesses the game loop 
        *	@pre game must exist
        *	@post 
        */
        public Game GetGameInstance()
        {
            return this.gameInstance;
        }

        /** 
        *   @brief mutator to the game state 
        *   @see
        *	@param inputState the class the represents the state of the game
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre game must exist
        *	@post 
        */
        public void SetGameState(GameState inputState)
        {
            this.gameState = inputState;
        }

        /** 
        *   @brief accessor to the game state 
        *   @see
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return gameState the current state of the game
        *	@pre game must exist
        *	@post 
        */
        public GameState GetGameState()
        {
            return this.gameState;
        }

        /** 
        *   @brief mutator to the graphic device manager 
        *   @see
        *	@param inputGraphics
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre game must exist
        *	@post 
        */
        public void SetGraphics(GraphicsDeviceManager inputGraphics)
        {
            this.graphics = inputGraphics;
        }

        /** 
        *   @brief accessor to the graphic device manager 
        *   @see
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return graphics 
        *	@pre game must exist
        *	@post 
        */
        public GraphicsDeviceManager GetGraphics()
        {
            return this.graphics;
        }

        /** 
        *   @brief mutator to the graphic device 
        *   @see
        *	@param inputDevice
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre game must exist
        *	@post 
        */
        public void SetGraphicsDevice(GraphicsDevice inputDevice)
        {
            this.gameGraphicsDevice = inputDevice;
        }

        /** 
        *   @brief accessor to the graphic device 
        *   @see
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return gameGraphicsDevice 
        *	@pre game must exist
        *	@post 
        */
        public GraphicsDevice GetGraphicsDevice()
        {
            return this.gameGraphicsDevice;
        }

        /** 
        *   @brief mutator to the spritebatch from game
        *   @see
        *	@param inputSpriteBatch target sprite batch
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetSpriteBatch(SpriteBatch inputSpriteBatch)
        {
            this.spriteBatch = inputSpriteBatch;
                 
        }

        /** 
        *   @brief accessor to the spritebatch from game
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return spriteBatch
        *	@pre must exist
        *	@post 
        */
        public SpriteBatch GetSpriteBatch()
        {
            return this.spriteBatch;
        }


        /** 
        *   @brief mutator to the game time from game
        *   @see
        *	@param inputTime the expried game time
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetGameTime(GameTime inputTime)
        {
            this.gameTime = inputTime;
        }

        /** 
        *   @brief accessor to the game time from game
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return gameTime expired game time 
        *	@pre 
        *	@post 
        */
        public GameTime GetGameTime()
        {
            return this.gameTime;
        }

        /** 
        *   @brief finite state that initialises the state
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void Initialise()
        {
            gameState.Initialise(this);
        }

        /** 
        *   @brief finite state update function for updating the game state
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void Update()
        {
            gameState.Update(this);
        }

        /** 
        *   @brief finite state function to draw the objects of the state
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void Draw()
        {
            gameState.Draw(this);
        }


    }
}
