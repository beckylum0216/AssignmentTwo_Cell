using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

//author: Bruno Neto

namespace JourneyToTheCenterOfTheCell
{
    class Text
    {
        private Vector2 screenPosition = new Vector2(100,200);//initial screen position of the textbox can be set to different position
        //private int height =100;//initial default height value for textbox will need to write a method which rezises the box depending on the length of the string it contains
        //private int width = 300;//initial default width value for textbox will need to write a method which rezises the box depending on the length of the string it contains
        private SpriteFont arial;//spritefont which will hold the font loaded in game1
        private string theString = "some texts";//initial default textbox string value can be set to anny string value
        bool drawnow = false;//boolean for determining wether the loaded texbox should be drawn or not
        private Vector2 scale = new Vector2(1.0f,1.0f);//scale of the text can be used in the resize method 

        public void SetString(string s)//method to set the string parameter
        {
            theString = s;
        }
        public void DisplayFont()//sets the boolean to true so the textbox is drawn 
        {
            drawnow = true;
        }
        public void RemoveDisplayFont()//sets the boolean to false to not fraw the set textbox
        {
            drawnow = false;
        }

        public string GetString()//method for determining contents of string for a textbox
        {
            return theString;
        }
        public void SetPosition(Vector2 pos)//set the position for the texbox on screen
        {
            screenPosition = pos;
        }
        public Vector2 GetPosition()//method for determining the set position of a textbox
        {
            return screenPosition;
        }
        public void Initialise(SpriteFont f)//method for loading the loaded spritefont from game1 into the textboxes spritefont variable
        {
           
            arial = f;
        }
        public void Draw(SpriteBatch spriteBatch,GraphicsDeviceManager g)//draw method for the textbox only draws if the texboxes boolean for displaying is set to true
        {
            if (drawnow == true)
            {
                //uses spritebatch variable from game1
                spriteBatch.Begin();

                SpriteEffects ef=new SpriteEffects();
                //draw the text at the required positionx
                spriteBatch.DrawString(arial, theString, screenPosition, Color.White,0.0f,new Vector2(0,0),scale,ef,0.0f );


                spriteBatch.End();
            }
        }
        public void Update(SpriteBatch spriteBatch, GraphicsDeviceManager  GDM)
        {
             this.Draw(spriteBatch,GDM); 
            
        }
    }
}
