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
///@brief QuizFinishedView class the view for when quiz is finished 
    class QuizFinishedView
    {
        GameContext newGame;
/** 
*   @brief accesor for quizfinishedview panel 
*   @see
*	@param gTX the current game context
*	@param totalQuestion the total number of quiz questions
*	@param totalCorrect the total number of quiz questions correct
*	@return newPanel the actual panel to represnt the view
*	@pre gTX must be initialised and valid
*	@post 
*/
        public Panel GetPanel(GameContext gTX, int totalQuestion, int totalCorrect)
        {
            newGame = gTX;
            Panel newPanel = new Panel();
            Header pageHead = new Header("Quiz Finished", Anchor.TopCenter, new Vector2(0, -18));
            
            // add title and text
            newPanel.AddChild(pageHead);
            Paragraph finishedText = new Paragraph("You completed the quiz "+Environment.NewLine+"You got " + totalCorrect + " out of " + totalQuestion + " questions correct");
            newPanel.AddChild(finishedText);
            Button returnToMenuButton = new Button("Return To Main Menu", ButtonSkin.Default, Anchor.BottomCenter);
            returnToMenuButton.OnClick = (Entity btn) => QuizFinishedEvent(returnToMenuButton);
            newPanel.AddChild(returnToMenuButton);
            return newPanel;
        }
/** 
*   @brief mutator for game state variable returns to menu on button press
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



