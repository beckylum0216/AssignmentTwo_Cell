//Author:Bruno Neto
//DeathView: this class forms the basic ui for when the player dies
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace JourneyToTheCenterOfTheCell
{
    class DeathView
    {
        GameContext newGame;

        public Panel GetPanel(GameContext gTX)
        {
            newGame = gTX;
            Panel newPanel = new Panel();
            Header pageHead = new Header("You have lost your nanobot!!", Anchor.TopCenter, new Vector2(0, -18));

            // add title and text
            newPanel.AddChild(pageHead);
            Paragraph finishedText = new Paragraph("The bodies defense mechanisms proved too strong, remember to use your cloak shield to avoid pursuing organelles!");
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
