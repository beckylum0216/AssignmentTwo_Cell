using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    /// @author Rebecca Lim
    /// <summary>
    /// Dta container class for encapsulating quiz objects
    /// </summary>
    public class Quiz
    {
        
        private String quizQuestion;
        private List<String> quizOptions;
        private String quizAnswer;

        /** 
        *   @brief parameterised copy constructor 
        *   @see 
        *	@param inputQuiz target quiz
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public Quiz(Quiz inputQuiz)
        {
            this.quizQuestion = inputQuiz.quizQuestion;
            this.quizOptions = inputQuiz.quizOptions;
        }

        /** 
        *   @brief parameterised quiz constructor
        *   @see 
        *	@param inputQuestion the question being asked
        *	@param inputOptions the possible answers to the questions
        *	@param inputAnswer the answer to the question
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post quiz object exists
        */
        public Quiz(String inputQuestion, List<String> inputOptions, String inputAnswer)
        {
            this.quizQuestion = inputQuestion;
            this.quizOptions = inputOptions;
            this.quizAnswer = inputAnswer;
        }

        /** 
        *   @brief mutator to the quiz question
        *   @see 
        *	@param inputQuestion the question being asked
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post quiz object exists
        */
        public void SetQuizQuestion(String inputQuestion)
        {
            this.quizQuestion = inputQuestion;
        }

        /** 
        *   @brief accessor to the quiz questions
        *   @see 
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return quizQuestion
        *	@pre quiz object exists
        *	@post 
        */
        public String GetQuizQuestion()
        {
            return this.quizQuestion;
        }

        /** 
        *   @brief mutator to the quiz options
        *   @see 
        *	@param inputAnswers
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre quiz object exists
        *	@post 
        */
        public void SetQuizOptions(List<String> inputAnswers)
        {
            this.quizOptions = inputAnswers;
        }

        /** 
        *   @brief accessor to the quiz options
        *   @see 
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return quizOptions
        *	@pre quiz object exists
        *	@post 
        */
        public List<String> GetQuizOptions()
        {
            return this.quizOptions;
        }

        /** 
        *   @brief mutator to the quiz answer
        *   @see 
        *	@param inputAnswer
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre quiz object exists
        *	@post 
        */
        public void SetQuizAnswer(String inputAnswer)
        {
            this.quizAnswer = inputAnswer;
        }

        /** 
        *   @brief mutator to the quiz answer
        *   @see 
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return quizanswer
        *	@pre quiz object exists
        *	@post 
        */
        public String GetQuizAnswer()
        {
            return this.quizAnswer;
        }
    }
}
