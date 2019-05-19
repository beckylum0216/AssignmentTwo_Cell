using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MonoGame.Extended.Gui;
//using MonoGame.Extended.Gui.Controls;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;

namespace JourneyToTheCenterOfTheCell
{
    class MenuView
    {
        public enum GameState {Menu, Game, Save, Load, Quiz, Statistics, Exit}
        private List<String> buttonName;
        private GameContext gameContext;

        public MenuView(GameContext gameCtx)
        {
            this.gameContext = gameCtx;
        }

        public Panel GetPanel(int inputX, int inputY)
        {

            List<Button> buttonList = new List<Button>();
            buttonName = new List<string>();


            buttonName.Add("New Game");
            buttonName.Add("Save Game");
            buttonName.Add("Load Game");
            buttonName.Add("Quiz");
            buttonName.Add("User Statistics");
            buttonName.Add("Exit");


            Vector2 panelSize = new Vector2(inputX, inputY);
            Vector2 panelOffSet = new Vector2(0, 0);

            Panel newPanel = new Panel(panelSize);
            
            // add title and text
            newPanel.AddChild(new Header("Journey to the Centre of the Cell"));
            newPanel.AddChild(new HorizontalLine());
           
            for(int ii = 0; ii < buttonName.Count; ii += 1)
            {
                Button newButton = new Button(buttonName[ii], ButtonSkin.Default, Anchor.AutoCenter);
                newButton.Identifier = buttonName[ii];
                Vector2 buttonSize = new Vector2(500, 50);
                newButton.MaxSize = buttonSize;
                newButton.OnClick = (Entity btn) => MenuEvent(newButton);
                newPanel.AddChild(newButton);
            }
            

            return newPanel;
        }


        private void MenuEvent(Entity btn)
        {
            Debug.WriteLine("ID: " + btn.Identifier);
            Debug.WriteLine("Button Pressed!!!");



            switch (btn.Identifier)
            {
                case "New Game":
                    GameOneManager newGame = new GameOneManager(gameContext);
                    gameContext.SetGameState(newGame);
                    break;
                case "Save Game":

                    break;
                case "Load Game":

                    break;
                case "Quiz":
                    QuizManager newQuiz = new QuizManager();
                    gameContext.SetGameState(newQuiz);
                    gameContext.Initialise();
                    break;
                case "User Statistics":
                    break;
                case "Exit":
                    break;
                default:
                    Debug.WriteLine("Error invalid choice!!!");
                    break;
               
            }
        }

    }
}
