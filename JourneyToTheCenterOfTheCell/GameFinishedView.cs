//Author:Bruno Neto
//GameFinishedView: this class forms the basic ui for the the finished page of game 
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace JourneyToTheCenterOfTheCell
{
    class GameFinishedView
    {
        GameContext newGame;

        public Panel GetPanel(GameContext gTX)
        {
            newGame = gTX;
            Panel newPanel = new Panel();
            Header pageHead = new Header("Game Finished", Anchor.TopCenter, new Vector2(0, -18));
           
            // add title and text
            newPanel.AddChild(pageHead);
            Paragraph finishedText = new Paragraph("You completed the game congratulations now have a try at the quiz with the knowledge you have learned from the codex entries");
            newPanel.AddChild(finishedText);
            Button returnToMenuButton = new Button("Return To Main Menu", ButtonSkin.Default, Anchor.BottomCenter);
            returnToMenuButton.OnClick = (Entity btn) => QuizFinishedEvent(returnToMenuButton);
            newPanel.AddChild(returnToMenuButton);
            return newPanel;
        }

        public void QuizFinishedEvent(Entity btn)
        {
            MenuManager menuManager = new MenuManager();
            menuManager.Initialise(newGame);
            newGame.SetGameState(menuManager);


        }

    }
}
