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
    class QuizView:Quiz
    {
        Panel newPanel;
        List<RadioButton> answerButtons;

        public QuizView(Quiz inputQuiz, int inputX, int inputY) :base(inputQuiz)
        {
            Vector2 panelSize = new Vector2(inputX, inputY);
            newPanel = new Panel(panelSize);
            answerButtons = new List<RadioButton>();
            this.SetQuizPanel();
        }

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

        public void QuizEvent(Entity btn)
        {
            
            for(int ii = 0; ii < this.answerButtons.Count; ii += 1)
            {
                if (answerButtons[ii].Checked == true)
                {
                    if (answerButtons[ii].Identifier == this.GetQuizAnswer())
                    {
                        Paragraph answerText = new Paragraph();
                        answerText.Text = this.GetQuizAnswer();
                        this.newPanel.AddChild(answerText);
                    }
                }
            }
        }

        public Panel GetQuizPanel()
        {
            return this.newPanel;
        }

    }
}
