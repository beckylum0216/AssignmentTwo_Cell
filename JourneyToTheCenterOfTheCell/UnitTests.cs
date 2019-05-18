using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
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

        //public Structure test;
    


        public UnitTests()
        { }

        [Test]
        public void InitialiseGame1()
        {
            Game1 testgame = new Game1();

            Assert.IsNotNull(testgame);
        }

        [Test]
        public void InitialiseGameContext()
        {
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            Assert.IsNotNull(gtx);
        }

        [Test]
        public void InitialiseGameManager()
        {
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            GameManager testNewGame = new GameManager();

            Assert.IsNotNull(testNewGame);
        }

        [Test]
        public void InitialiseModelHandler()
        {
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            ModelHandler MH = new ModelHandler(gtx.GetGameInstance().Content, 20, 20, 20, 1.0f);

            Assert.IsNotNull(MH);
        }

        [Test]
        public void InitialiseMapGenerator()
        {
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            MapGenerator MG = new MapGenerator(200, 200, 200);

            Assert.IsNotNull(MG);
        }

        [Test]
        public void InitialiseInputHandler()
        {
            
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            GameManager testNewGame = new GameManager();

            InputHandler testHandler = new InputHandler(testNewGame.GetScreenX(), testNewGame.GetScreenY(), testNewGame.GetCodex());
            Assert.IsNotNull(testHandler.KeyboardHandler());
        }

        [Test]
        public void InitialiseCodexView()
            {

            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            //GameManager testNewGame = new GameManager();

            CodexView CD = new CodexView();

            Assert.IsNotNull(CD);
        }

        [Test]
        public void InitialiseCodexManager()
        {
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            CodexManager CM = new CodexManager();

            Assert.IsNotNull(CM);
        }

        [Test]
        public void InitialiseStructure()
        {
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();
            
            //Structure S = new Structure(gtx.GetGameInstance().Content, )

            //Assert.IsNotNull(S);
        }

        [Test]
        public void InitialiseTextBox()
        {
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            TextBox TB = new TextBox();

            Assert.IsNotNull(TB);
        }

        [Test]
        public void InitialiseQuizManager()
        {
            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            QuizManager QM = new QuizManager();

            Assert.IsNotNull(QM);
        }

        [Test]
        public void InitialiseQuiz()
        {
            List<String> tempAns = new List<String>();
            tempAns.Add("lorem ipsum");
            tempAns.Add("blah");

            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            Quiz Q = new Quiz("Test Input", tempAns, "blah");

            Assert.IsNotNull(Q);
        }

        //Additional tests are requried to initialise the remaining classes

        //Classes Remaining:
        //  items
        //  enemies
        //  EFSM
        //  QuizView and QuizPanel


        /*[Test]
        public void InitialiseQuizView()
        {
            List<String> tempAns = new List<String>();
            tempAns.Add("lorem ipsum");
            tempAns.Add("blah");

            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            Quiz Q = new Quiz("Test Input", tempAns, "blah");

            QuizView QV = new QuizView(Q, 50, 50);

            Assert.IsNotNull(QV);
        }*/

        /*[Test]
        public void InitialisePanel()
        {
            List<String> tempAns = new List<String>();
            tempAns.Add("lorem ipsum");
            tempAns.Add("blah");

            Game1 testgame = new Game1();

            GameContext gtx = new GameContext(testgame, testgame.graphics, testgame.spriteBatch);

            gtx.GetGameInstance();

            Quiz Q = new Quiz("Test Input", tempAns, "blah");

            QuizView QV = new QuizView(Q, 50, 50);

            Panel testPanel = QV.GetQuizPanel();

            Assert.IsNotNull(testPanel);
        }*/
    }

}

/*
//Arrage/Act
var actual = TestTypes.IntegrationTesting.ToString();

//Assert
Assert.That(actual, Is.EqualTo("IntegrationTesting"));
*/

/*
* Asserts List:
* Assert.That(actual, Is.Not.Null.And.EqualTo(..)
* Assert.NotNull(actual)
* Assert.AreEqual(*expected outcome*, actual)
*/
