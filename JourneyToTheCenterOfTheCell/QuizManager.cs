using GeonBit.UI;
using GeonBit.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
	///   @brief  QuizManager class game state for quiz
    class QuizManager:GameState
    {
        
        //int numOfQuestions = 8;
        int totalCorrect;
        int currentQuestionNumber;
        //double finalPercentage = 0.00;
        bool questionComplete = false;
        QuizAnswers questions = new QuizAnswers();
        QuizFinishedView final = new QuizFinishedView(); 
        Panel testPanel = new Panel();
/** 
*   @brief mutator for the questionComplete boolean used to update the quiz to next question 
*   @see
*	@param 
*	@return void
*	@pre 
*	@post 
*/        
        public void QuestionComplete()
        {
            questionComplete = true;
        }
        
/** 
*   @brief mutator for the currentQuestionNumber int used to keep track of when to end quiz 
*   @see
*	@param 
*	@return void
*	@pre 
*	@post 
*/       
        //probably need a saveQuizResultToFile function if we have time so players can check their scores from a panel in menu
        public void AddToQuestionNumber()
        {
            
                currentQuestionNumber = currentQuestionNumber + 1;
            
        }
/** 
*   @brief mutator for the totalCorrect int used to track how many correct answers have been entered 
*   @see
*	@param 
*	@return void
*	@pre 
*	@post 
*/
        public void AddToTotalCorrect()
        {
            
                totalCorrect = totalCorrect + 1;
            
        }
/** 
*   @brief initialise for the QuizManager state  
*   @see
*	@param gameCtx the current game context
*	@return void
*	@pre 
*	@post 
*/
        public override void Initialise(GameContext gameCtx)
        {

            
            questions.Init(gameCtx,this);
            totalCorrect = 0;
            currentQuestionNumber = 1;



            //screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            //screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;

            UserInterface.Initialize(gameCtx.GetGameInstance().Content, BuiltinThemes.hd);

            
            testPanel = questions.GetQuizView1().GetQuizPanel();
            UserInterface.Active.AddEntity(testPanel);
        }
/** 
*   @brief update for the QuizManager state  
*   @see
*	@param gameCtx the current game context
*	@return void
*	@pre 
*	@post 
*/       
        public override void Update(GameContext gameCtx)
        {
           
            
            if (currentQuestionNumber == 2 & questionComplete==true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = questions.GetQuizView2().GetQuizPanel();
                UserInterface.Active.AddEntity(testPanel);
                // this boolean is to avoid redrawing the quiz unless a change has beem started by a completed quiz panel
                questionComplete = false;
            }
            if (currentQuestionNumber == 3 & questionComplete == true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = questions.GetQuizView3().GetQuizPanel();
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;
            }
            if (currentQuestionNumber == 4 & questionComplete == true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = questions.GetQuizView4().GetQuizPanel();
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;
            }
            if (currentQuestionNumber == 5 & questionComplete == true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = questions.GetQuizView5().GetQuizPanel();
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;
            }
            if (currentQuestionNumber == 6 & questionComplete == true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = questions.GetQuizView6().GetQuizPanel();
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;
            }
            if (currentQuestionNumber == 7 & questionComplete == true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = questions.GetQuizView7().GetQuizPanel();
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;
            }
            if (currentQuestionNumber == 8 & questionComplete == true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = questions.GetQuizView8().GetQuizPanel();
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;
            }
            if (currentQuestionNumber == 9 & questionComplete == true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = final.GetPanel(gameCtx, (currentQuestionNumber-1),totalCorrect);
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;
            }

            UserInterface.Active.Update(gameCtx.GetGameTime());
        }
/** 
*   @brief draw for the QuizManager state  draws the quiz
*   @see
*	@param gameCtx the current game context
*	@return void
*	@pre 
*	@post 
*/
        public override void Draw(GameContext gameCtx)
        {
            UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
        }
    }
}
