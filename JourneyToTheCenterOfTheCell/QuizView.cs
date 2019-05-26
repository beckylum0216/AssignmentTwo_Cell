using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;


namespace JourneyToTheCenterOfTheCell
{
	/// @brief class for QuizView the panels and layout of quiz state
    class QuizView:Quiz
    {
        Panel newPanel;
        List<RadioButton> answerButtons;
        QuizManager qm;
        Quiz q;
        public QuizView(QuizManager QM,Quiz inputQuiz, int inputX, int inputY) :base(inputQuiz)
        {
            q = inputQuiz;
            qm = QM;
            Vector2 panelSize = new Vector2(inputX, inputY);
            newPanel = new Panel(panelSize);
            answerButtons = new List<RadioButton>();
            this.SetQuizPanel();
        }
/** 
*   @brief mutator for newPanel the panel that stores the view for the current quiz question  
*   @see
*	@param 
*	@return void
*	@pre 
*	@post 
*/
        private void SetQuizPanel()
        {
            Paragraph questionField = new Paragraph(this.GetQuizQuestion(), Anchor.AutoCenter);
            this.newPanel.AddChild(questionField);
            this.newPanel.AddChild(new HorizontalLine());

            for (int ii = 0; ii < this.GetQuizOptions().Count; ii += 1)
            {
                RadioButton answerBtn = new RadioButton(this.GetQuizOptions()[ii], Anchor.AutoCenter);
                answerBtn.Identifier = this.GetQuizOptions()[ii];
                answerButtons.Add(answerBtn);
                this.newPanel.AddChild(answerBtn);
            }

            Button submitButton = new Button("Submit", ButtonSkin.Default, Anchor.BottomCenter);
            submitButton.OnClick = (Entity btn) => QuizEvent(submitButton);
            this.newPanel.AddChild(submitButton);
        }
/** 
*   @brief function for determining user input on a quiz view and adding to questions correct tally if correct answer selected then trigers the next quiz question to generate 
*   @see
*	@param btn the submit button of the panel 
*	@return void
*	@pre 
*	@post 
*/
        public void QuizEvent(Entity btn)
        {
            
            for(int ii = 0; ii < this.answerButtons.Count; ii += 1)
            {
                if (answerButtons[ii].Checked == true)
                {
                    //if true need to send some data back to quizmanager
                    if (answerButtons[ii].Identifier.ToString() == q.GetQuizAnswer())
                    {
                        
                        qm.AddToQuestionNumber();
                        qm.AddToTotalCorrect();
                        qm.QuestionComplete();
                      
                    }
                    else
                    {
                        qm.AddToQuestionNumber();//this works
                        qm.QuestionComplete();//this works
                        
                    }
                }
            }
        }
/** 
*   @brief acessor for newPanel  
*   @see
*	@param 
*	@return newPanel the curent panel of quizview
*	@pre 
*	@post 
*/
        public Panel GetQuizPanel()
        {
            return this.newPanel;
        }

    }
}
