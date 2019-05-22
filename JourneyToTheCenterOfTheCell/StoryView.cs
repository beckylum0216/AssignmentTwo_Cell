//Author:Bruno Neto
//StoryView: this class forms the basic ui for the the story page menu
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace JourneyToTheCenterOfTheCell
{
    class StoryView
    {
        int m_screenX;
        int m_screenY;
        GameContext m_gtx;
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
        public void StoryFinishedEvent(Entity btn)
        {
            GameOneManager newGame = new GameOneManager(m_gtx);//need this code to execute on begin game of my new view class
            m_gtx.SetGameState(newGame);

        }

    }
 }



