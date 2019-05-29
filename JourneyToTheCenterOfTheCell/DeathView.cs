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
	/// @brief class for DeathView the panels and layout of Death state
    class DeathView
    {
        GameContext newGame;

        /** 
        *   @brief accesor for deathview panel 
        *   @see
        *	@param gTX the current game context
        *	@return newPanel the actual panel to represnt the view
        *	@pre gTX must be initialised and valid
        *	@post 
        */
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

        /** 
        *   @brief mutator for game state variable 
        *   @see
        *	@param btn the button of the panel 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void QuizFinishedEvent(Entity btn)
        {
            MenuManager menuManager = new MenuManager();
            menuManager.Initialise(newGame);
            newGame.SetGameState(menuManager);


        }

    }
}
