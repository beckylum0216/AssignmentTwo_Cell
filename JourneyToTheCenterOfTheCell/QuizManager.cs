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
        private int screenX;
        private int screenY;



        public override void Initialise(GameContext gameCtx)
        {
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;

            UserInterface.Initialize(gameCtx.GetGameInstance().Content, BuiltinThemes.hd);

            List<String> tempAns = new List<String>();
            tempAns.Add("lorem ipsum");
            tempAns.Add("blah");
            Quiz testQuiz = new Quiz("Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit, sed do eiusmod " +
                "tempor incididunt ut labore et " +
                "dolore magna aliqua.", tempAns, "blah");
            QuizView newQuiz = new QuizView(testQuiz, screenX, screenY);

            Panel testPanel = newQuiz.GetQuizPanel();


            UserInterface.Active.AddEntity(testPanel);
        }

        public override void Update(GameContext gameCtx)
        {
            UserInterface.Active.Update(gameCtx.GetGameTime());
        }

        public override void Draw(GameContext gameCtx)
        {
            UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
        }
    }
}
