using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    public class GameContext
    {
        private Game gameInstance;
        private GameState gameState;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameTime gameTime;

        public GameContext(Game inputGame, GraphicsDeviceManager inputGraphics, SpriteBatch inputSpriteBatch)
        {
            this.gameInstance = inputGame;
            this.graphics = inputGraphics;
            this.spriteBatch = inputSpriteBatch;
            gameState = new GameOneManager();

        }

        public void SetGameInstance(Game inputGame)
        {
            this.gameInstance = inputGame;
        }

        public Game GetGameInstance()
        {
            return this.gameInstance;
        }

        public void SetGameState(GameState inputState)
        {
            this.gameState = inputState;
        }

        public GameState GetGameState()
        {
            return this.gameState;
        }

        public void SetGraphics(GraphicsDeviceManager inputGraphics)
        {
            this.graphics = inputGraphics;
        }

        public GraphicsDeviceManager GetGraphics()
        {
            return this.graphics;
        }

        public void SetSpriteBatch(SpriteBatch inputSpriteBatch)
        {
            this.spriteBatch = inputSpriteBatch;
                 
        }

        public SpriteBatch GetSpriteBatch()
        {
            return this.spriteBatch;
        }

        public void SetGameTime(GameTime inputTime)
        {
            this.gameTime = inputTime;
        }

        public GameTime GetGameTime()
        {
            return this.gameTime;
        }

        public void Initialise()
        {
            gameState.Initialise(this);
        }

        public void Update()
        {
            gameState.Update(this);
        }

        public void Draw()
        {
            gameState.Draw(this);
        }
    }
}
