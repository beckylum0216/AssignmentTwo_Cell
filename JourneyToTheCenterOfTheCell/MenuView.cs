﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;



namespace JourneyToTheCenterOfTheCell
{
    /// @author Rebecca Lim
    /// <summary>
    /// The view of the menu
    /// </summary>
    class MenuView
    {
        public enum GameState {Menu, Game, Save, Load, Quiz, Statistics, Exit}
        private List<String> buttonName;
        private GameContext gameContext;
        UserInterface m_interface;
        StoryView gui= new StoryView();
        int x;
        int y;

        /** 
        *   @brief parameterised constructor to the view 
        *   @brief 
        *   @see 
        *	@param gameCtx the game context
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public MenuView(GameContext gameCtx)
        {
            this.gameContext = gameCtx;
        }

        /** 
        *   @brief function to set and get child entity to the menu view
        *   @brief 
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public Panel GetPanel(int inputX, int inputY,UserInterface a)
        {
            x = inputX;
            y = inputY;
            m_interface = a;
            List<Button> buttonList = new List<Button>();
            buttonName = new List<string>();


            buttonName.Add("New Game");
            //buttonName.Add("Save Game");
            //buttonName.Add("Load Game");
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

        /** 
        *   @brief event handler for the menu view buttons
        *   @brief 
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        private void MenuEvent(Entity btn)
        {
            Debug.WriteLine("ID: " + btn.Identifier);
            Debug.WriteLine("Button Pressed!!!");



            switch (btn.Identifier)
            {
                case "New Game":
                    m_interface.Clear();//clear the menu panel from the user interface
                    Panel test = gui.GetPanel(gameContext,x, y);//load the story panel in the interface
                                        
                    m_interface.AddEntity(test);
                    
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
                    gameContext.GetGameInstance().Exit();
                    break;
                default:
                    Debug.WriteLine("Error invalid choice!!!");
                    break;
               
            }
        }

    }
}
