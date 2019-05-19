//Author:Bruno Neto
//QuizFinishedView: this class forms the basic ui for the the finished page of quiz
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace JourneyToTheCenterOfTheCell
{

    class QuizFinishedView
    {
        GameContext newGame;

        public Panel GetPanel(GameContext gTX, int totalQuestion, int totalCorrect)
        {
            newGame = gTX;
            Panel newPanel = new Panel();
            Header pageHead = new Header("Quiz Finished", Anchor.TopCenter, new Vector2(0, -18));
            pageHead.AddChild(new HorizontalLine(Anchor.BottomCenter));
            // add title and text
            newPanel.AddChild(pageHead);
            Paragraph finishedText = new Paragraph("You completed the quiz "+Environment.NewLine+"You got " + totalCorrect + " out of " + totalQuestion + " questions correct");
            newPanel.AddChild(finishedText);
            Button returnToMenuButton = new Button("Return To Main Menu", ButtonSkin.Default, Anchor.BottomCenter);
            returnToMenuButton.OnClick = (Entity btn) => QuizFinishedEvent(returnToMenuButton);
            newPanel.AddChild(returnToMenuButton);
            return newPanel;
        }
        public void QuizFinishedEvent(Entity btn)
        {
            MenuManager menuManager = new MenuManager();
            newGame = new GameContext(newGame.GetGameInstance(), newGame.GetGraphics(), newGame.GetSpriteBatch());
            newGame.SetGameState(menuManager);
            newGame.Initialise();

        }

    }
} 



