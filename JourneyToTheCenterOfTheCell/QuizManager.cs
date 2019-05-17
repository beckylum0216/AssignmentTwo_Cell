using GeonBit.UI;
using GeonBit.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    class QuizManager:GameState
    {
        //private int screenX;
        //private int screenY;
        int numOfQuestions = 8;
        int totalCorrect;
        int currentQuestionNumber;
        double finalPercentage = 0.00;
        bool questionComplete = false;
        QuizAnswers questions = new QuizAnswers();
        QuizFinishedView final = new QuizFinishedView(); 
        Panel testPanel = new Panel();
        
        public void QuestionComplete()
        {
            questionComplete = true;
        }
        public void CalculateQuizResult()
        {
            finalPercentage = totalCorrect / numOfQuestions;
        }
        public void DisplayQuizResult()
        {
            //need to make a quizFinalView to load a panel showing quiz stats after completion
        }
        //probably need a saveQuizResultToFile function if we have time so players can check their scores from a panel in menu
        public void AddToQuestionNumber()
        {
            
                currentQuestionNumber = currentQuestionNumber + 1;
            
        }

        public void AddToTotalCorrect()
        {
            
                totalCorrect = totalCorrect + 1;
            
        }

        public override void Initialise(GameContext gameCtx)
        {
            
            questions.Init(gameCtx,this);
            totalCorrect = 0;
            currentQuestionNumber = 1;



            //screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            //screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;

            UserInterface.Initialize(gameCtx.GetGameInstance().Content, BuiltinThemes.hd);

            //List<String> tempAns = new List<String>();
            //tempAns.Add("lorem ipsum");
            //tempAns.Add("blah");

            //Quiz testQuiz = new Quiz("Lorem ipsum dolor sit amet," +
            //   " consectetur adipiscing elit, sed do eiusmod " +
            //   "tempor incididunt ut labore et " +
            //    "dolore magna aliqua.", tempAns, "blah");
            // QuizView newQuiz = new QuizView(testQuiz, screenX, screenY);

            //Panel testPanel = newQuiz.GetQuizPanel();
            

            
            
            
            
            

            testPanel = questions.GetQuizView1().GetQuizPanel();
            UserInterface.Active.AddEntity(testPanel);
        }
       
        public override void Update(GameContext gameCtx)
        {
           
            
            if (currentQuestionNumber == 2 & questionComplete==true)
            {
                UserInterface.Active.RemoveEntity(testPanel);
                testPanel = questions.GetQuizView2().GetQuizPanel();
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;// this boolean is to avoid redrawing the quiz unless a change has beem started by a completed quiz panel
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
                testPanel = final.GetPanel(gameCtx.GetGameInstance().Content, (currentQuestionNumber-1),totalCorrect);
                UserInterface.Active.AddEntity(testPanel);
                questionComplete = false;
            }

            UserInterface.Active.Update(gameCtx.GetGameTime());
        }

        public override void Draw(GameContext gameCtx)
        {
            UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
        }
    }
}
