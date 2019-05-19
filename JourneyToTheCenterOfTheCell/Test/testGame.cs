using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace JourneyToTheCenterOfTheCell.Test
{
    class testGame
    {
        [Test]
        public void TransferFunds()
        {
            Game1 testGame = new Game1();

            GameContext gameContext = new GameContext(testGame, testGame.graphics, testGame.spriteBatch);

            gameContext.GetGameInstance();

            GameOneManager testNewGame = new GameOneManager(gameContext);

            InputHandler testHandler = new InputHandler(testNewGame.GetScreenX(), testNewGame.GetScreenY());

            Assert.IsNotNull(testHandler.KeyboardHandler());
        }
        
    }
}
