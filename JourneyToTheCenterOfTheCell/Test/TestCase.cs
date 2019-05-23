using JourneyToTheCenterOfTheCell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[TestFixture]
public class TestCase
{
    [Test]
    public void QuizTest1()
    {
        try
        {
            Game1 testGame = new Game1();

            GameContext gameContext = new GameContext(testGame, testGame.graphics, testGame.spriteBatch);

            gameContext.GetGameInstance();

            QuizManager testNewGame = new QuizManager();
            testNewGame.Initialise(gameContext);

            List<String> inputOptions = new List<String>();
            inputOptions.Add("With human eyes, with dimensions between 1 and 100 centimeters. ");
            inputOptions.Add("Only under a microscope, with dimensions between 1 and 100 micrometres. ");
            inputOptions.Add("With Insect eyes, with dimensions between 1 and 10 millimeters. ");
            Quiz testq = new Quiz("blah", inputOptions, "blah");
            testq.GetQuizQuestion();
            Assert.Pass();
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);
            Assert.Fail();
        }

        


    }

    [Test]
    public void QuizTest002()
    {
        List<String> inputOptions = new List<String>();
        inputOptions.Add("With human eyes, with dimensions between 1 and 100 centimeters. ");
        inputOptions.Add("Only under a microscope, with dimensions between 1 and 100 micrometres. ");
        inputOptions.Add("With Insect eyes, with dimensions between 1 and 10 millimeters. ");
        //Quiz testq = new Quiz("blah", inputOptions, "blah");
        testq.GetQuizQuestion();
    }

        

}


