using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    public class Quiz
    {
        
        private String quizQuestion;
        private List<String> quizOptions;
        private String quizAnswer;
        

        public Quiz(Quiz inputQuiz)
        {
            this.quizQuestion = inputQuiz.quizQuestion;
            this.quizOptions = inputQuiz.quizOptions;
            
        }

        public Quiz(String inputQuestion, List<String> inputOptions, String inputAnswer)
        {
            this.quizQuestion = inputQuestion;
            this.quizOptions = inputOptions;
            this.quizAnswer = inputAnswer;
        }


        public void SetQuizQuestion(String inputQuestion)
        {
            this.quizQuestion = inputQuestion;
        }

        public String GetQuizQuestion()
        {
            return this.quizQuestion;
        }

        public void SetQuizOptions(List<String> inputAnswers)
        {
            this.quizOptions = inputAnswers;
        }

        public List<String> GetQuizOptions()
        {
            return this.quizOptions;
        }

        public void SetQuizAnswer(String inputAnswer)
        {
            this.quizAnswer = inputAnswer;
        }

        public String GetQuizAnswer()
        {
            return this.quizAnswer;
        }
    }
}
