using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    /// @author Bruno Neto
	/// @brief  QuizAnswers class container for all the quiz questions and answers
    class QuizAnswers
    {
        private int screenX;
        private int screenY;
        List<String> choiceAnsQuestion1 = new List<String>();
        List<String> choiceAnsQuestion2 = new List<String>();
        List<String> choiceAnsQuestion3 = new List<String>();
        List<String> choiceAnsQuestion4 = new List<String>();
        List<String> choiceAnsQuestion5 = new List<String>();
        List<String> choiceAnsQuestion6 = new List<String>();
        List<String> choiceAnsQuestion7 = new List<String>();
        List<String> choiceAnsQuestion8 = new List<String>();
        List<String> choiceAnsQuestion9 = new List<String>();
        Quiz question1;
        Quiz question2;
        Quiz question3;
        Quiz question4;
        Quiz question5;
        Quiz question6;
        Quiz question7;
        Quiz question8;
        QuizView Quiz1; 
        QuizView Quiz2; 
        QuizView Quiz3; 
        QuizView Quiz4; 
        QuizView Quiz5;
        QuizView Quiz6; 
        QuizView Quiz7; 
        QuizView Quiz8;
        QuizManager qm;

        /** 
        *   @brief initialise for the QuizAnwers container  
        *   @see
        *	@param gameCtx the current game context
        *	@param QM the current QuizManager state
        *	@return void
        *	@pre 
        *	@post 
        */       
        public void Init(GameContext gameCtx, QuizManager QM)
        {
            qm = QM;
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;
            choiceAnsQuestion1.Add("With human eyes, with dimensions between 1 and 100 centimeters. ");
            choiceAnsQuestion1.Add("Only under a microscope, with dimensions between 1 and 100 micrometres. ");
            choiceAnsQuestion1.Add("With Insect eyes, with dimensions between 1 and 10 millimeters. ");

            choiceAnsQuestion2.Add("The control center of the cell. ");
            choiceAnsQuestion2.Add("The power generator of the cell. ");
            choiceAnsQuestion2.Add("Nuclear powered ");

            choiceAnsQuestion3.Add("A good holiday destination. ");
            choiceAnsQuestion3.Add("The chromasomes stored within the cell. ");
            choiceAnsQuestion3.Add("Locations for protein and lipid synthesis. ");

            choiceAnsQuestion4.Add("Hydrolytic enzymes that can break down many kinds of biomolecules. ");
            choiceAnsQuestion4.Add("Genome information. ");
            choiceAnsQuestion4.Add("the reducing enzyme catalase and usually some oxidases. ");

            choiceAnsQuestion5.Add("Hydrolytic enzymes that can break down many kinds of biomolecules. ");
            choiceAnsQuestion5.Add("Catabolism of very long chain fatty acids. ");
            choiceAnsQuestion5.Add("Dissolving dead cells. ");

            choiceAnsQuestion6.Add("Proteins into membrane - bound vesicles inside the cell. ");
            choiceAnsQuestion6.Add("Christmas cards for all the good subcellular organelles. ");
            choiceAnsQuestion6.Add("The chromasomes stored within the cell. ");

            choiceAnsQuestion7.Add("Hydrolytic enzymes that can break down many kinds of biomolecules. ");
            choiceAnsQuestion7.Add("Around ninety percent of the chromasomes stored within the cell. ");
            choiceAnsQuestion7.Add("Around ninety percent of the chemical energy that cells need to survive. ");

            choiceAnsQuestion8.Add("Dynamic network of interlinking protein filaments that extends from the cell nucleus to the cell membrane. ");
            choiceAnsQuestion8.Add("Semipermeable membrane surrounding the cytoplasm of a cell. ");
            choiceAnsQuestion8.Add("Hard structure that protects the internal organs of a living thing. ");

            question1 = new Quiz("Most plant and animal cells are visible :", choiceAnsQuestion1, "Only under a microscope, with dimensions between 1 and 100 micrometres. ");
            question2 = new Quiz("The nucleus is :", choiceAnsQuestion2, "The control center of the cell. ");
            question3 = new Quiz("The endoplasmic reticulum(ER) is a network of interconnected membranous tubes and sacs that serve as :", choiceAnsQuestion3, "Locations for protein and lipid synthesis. ");
            question4 = new Quiz("Lysosomes Contain :", choiceAnsQuestion4, "Hydrolytic enzymes that can break down many kinds of biomolecules. ");
            question5 = new Quiz("Peroxisomes are involved in :", choiceAnsQuestion5, "Catabolism of very long chain fatty acids. ");
            question6 = new Quiz("the Golgi apparatus packages: ", choiceAnsQuestion6, "Proteins into membrane - bound vesicles inside the cell. ");
            question7 = new Quiz("Mitochondria produce: ", choiceAnsQuestion7, "Around ninety percent of the chemical energy that cells need to survive. ");
            question8 = new Quiz("The CytoSkeleton is a: ", choiceAnsQuestion8, "Dynamic network of interlinking protein filaments that extends from the cell nucleus to the cell membrane. ");
            Quiz1 = new QuizView(qm, question1, screenX, screenY);
            Quiz2 = new QuizView(qm, question2, screenX, screenY);
            Quiz3 = new QuizView(qm, question3, screenX, screenY);
            Quiz4 = new QuizView(qm, question4, screenX, screenY);
            Quiz5 = new QuizView(qm, question5, screenX, screenY);
            Quiz6 = new QuizView(qm, question6, screenX, screenY);
            Quiz7 = new QuizView(qm, question7, screenX, screenY);
            Quiz8 = new QuizView(qm, question8, screenX, screenY);
        }
/** 
*   @brief accessor for Quiz1 the first quiz question 
*   @see
*	@param 
*	@return Quiz1
*	@pre 
*	@post 
*/
        public QuizView GetQuizView1()
        {
            return Quiz1;
        }
/** 
*   @brief accessor for Quiz2 the 2nd quiz question 
*   @see
*	@param 
*	@return Quiz2
*	@pre 
*	@post 
*/
        public QuizView GetQuizView2()
        {
            return Quiz2;
        }
/** 
*   @brief accessor for Quiz3 the 3rd quiz question 
*   @see
*	@param 
*	@return Quiz7
*	@pre 
*	@post 
*/
        public QuizView GetQuizView3()
        {
            return Quiz3;
        }
/** 
*   @brief accessor for Quiz4 the 4th quiz question 
*   @see
*	@param 
*	@return Quiz4
*	@pre 
*	@post 
*/
        public QuizView GetQuizView4()
        {
            return Quiz4;
        }
/** 
*   @brief accessor for Quiz5 the 5th quiz question 
*   @see
*	@param 
*	@return Quiz5
*	@pre 
*	@post 
*/
        public QuizView GetQuizView5()
        {
            return Quiz5;
        }
/** 
*   @brief accessor for Quiz6 the 6th quiz question 
*   @see
*	@param 
*	@return Quiz6
*	@pre 
*	@post 
*/
        public QuizView GetQuizView6()
        {
            return Quiz6;
        }
/** 
*   @brief accessor for Quiz7 the 7th quiz question 
*   @see
*	@param 
*	@return Quiz7
*	@pre 
*	@post 
*/
        public QuizView GetQuizView7()
        {
            return Quiz7;
        }
/** 
*   @brief accessor for Quiz8 the 8th quiz question 
*   @see
*	@param 
*	@return Quiz8
*	@pre 
*	@post 
*/
        public QuizView GetQuizView8()
        {
            return Quiz8;
        }
        
    }
}
