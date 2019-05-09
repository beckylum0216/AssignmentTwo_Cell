//Author: Bruno Neto
//Version:1.0
using Microsoft.Xna.Framework;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace JourneyToTheCenterOfTheCell
{
    public class Codex
    {
        SpriteBatch spritebatch;
        //UserInterface userInt;
        Panel test;
        //UserInterface userInt;
        CodexGui gui;
        public bool codexActivate = false;
        
        

        public void Initialize(GraphicsDeviceManager g, ContentManager Content)
        {
            spritebatch = new SpriteBatch(g.GraphicsDevice);
            UserInterface.Initialize(Content, BuiltinThemes.hd);
            gui = new CodexGui();
            test = new Panel();
            
            test = gui.GetPanel(Content);
            test.Offset = new Vector2(0, -540);
            test.Draggable = false;
            
           
            UserInterface.Active.AddEntity(test);
            
        }
        public void Activate()
        {
            codexActivate = true;//sets the boolean for wether the codex panel has been opened/activated 
        }

        public void Deactivate()
        {
            codexActivate = false;//deactivates the codex panel 
        }
        public void Draw()
        {           
            //turns of the geonbit cursor
            UserInterface.Active.ShowCursor = false;
            //draws the panels stored in active ui
            UserInterface.Active.Draw(spritebatch);                 
        }
        public void Update(GameTime gameTime)
        {
            if (codexActivate)// if the codex hass been activated
            {
                if (test.Offset != new Vector2(0, 0))//and the panel has not reached the desired offset
                { test.Offset = new Vector2(0, test.Offset.Y + 10); }//increment the offset each update
            }
            if (codexActivate == false)//if the codex has been deactivated
            {
                if (test.Offset != new Vector2(0, -540))//and the panel has not reached the deactive position
                { test.Offset = new Vector2(0, test.Offset.Y - 10); }//increment till we reach that position
            }
            UserInterface.Active.Update(gameTime);
        }
        

    }
}
