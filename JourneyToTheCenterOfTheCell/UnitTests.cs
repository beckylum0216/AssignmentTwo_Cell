using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace JourneyToTheCenterOfTheCell.Test
{

    public enum TestTypes
    {
        None,
        UnitTesting,
        IntegrationTesting
        //FlyByTheSeatOfYourPantsTesting
    }

    [TestFixture]
    public class UnitTests
    {
        //This file is set up to conduct Unit tests on classes quickly and effectively based on classes - Abstracts cannot be unit tested

        public Structure test;
    


        public UnitTests()
        {

        }


        [Test]
        public void TestingInputHandler()
        {
            
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            GameManager testNewGame = new GameManager();

            InputHandler testHandler = new InputHandler(testNewGame.GetScreenX(), testNewGame.GetScreenY(), testNewGame.GetCodex());
            Assert.IsNotNull(testHandler.KeyboardHandler());



            /*
            //Arrage/Act
            var actual = TestTypes.IntegrationTesting.ToString();

            //Assert
            Assert.That(actual, Is.EqualTo("IntegrationTesting"));
            */
        }

        [Test]
        public void TestingCodexView()
            {

            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            GameManager testNewGame = new GameManager();

            CodexView CD = new CodexView();

            Assert.IsNotNull(CD);
        }

    }
}

/*
* Asserts List:
* Assert.That(actual, Is.Not.Null.And.EqualTo(..)
* Assert.NotNull(actual)
* Assert.AreEqual(*expected outcome*, actual)
*/
