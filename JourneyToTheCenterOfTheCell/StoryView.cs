﻿//Author:Bruno Neto
//StoryView: this class forms the basic ui for the the story page menu
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace JourneyToTheCenterOfTheCell
{
	/// @brief class for StoryView the panels and layout of story panel that displays on newgame button bress in main menu
    class StoryView
    {
        int m_screenX;
        int m_screenY;
        GameContext m_gtx;
/** 
*   @brief accesor for storyview panel 
*   @see
*	@param gtx the current game context
*	@param screenX the current max x of viewport
*	@param screenY the current max y of viewport
*	@return newPanel the actual panel to represnt the view
*	@pre gTX must be initialised and valid
*	@post 
*/
        public Panel GetPanel(GameContext gtx,int screenX, int screenY)
        {
            m_screenX = screenX;
            m_gtx = gtx;
                
                Panel newPanel = new Panel(new Vector2(m_screenX,m_screenY));
                Image story = new Image(gtx.GetGameInstance().Content.Load<Texture2D>("Pics/pixabay-pharmaceutials"),new Vector2(screenX-50,screenY-50), ImageDrawMode.Stretch,Anchor.TopCenter);
                newPanel.AddChild(story);
                
                Button startLvl1Button = new Button("Start Game", ButtonSkin.Default, Anchor.BottomCenter,new Vector2(300,30),new Vector2(0,-20));
                startLvl1Button.OnClick = (Entity btn) => StoryFinishedEvent(startLvl1Button);
                newPanel.AddChild(startLvl1Button);
                return newPanel;
        }
/** 
*   @brief mutator for game state variable 
*   @see
*	@param btn the button of the panel 
*	@return void
*	@pre 
*	@post 
*/
        public void StoryFinishedEvent(Entity btn)
        {
            //need this code to execute on begin game of my new view class
            GameOneManager newGame = new GameOneManager(m_gtx);
            m_gtx.SetGameState(newGame);
            //GameTwoManager testGame = new GameTwoManager(m_gtx);
            //m_gtx.SetGameState(testGame);


        }

    }
 }



