using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
//author: Bruno Neto

namespace JourneyToTheCenterOfTheCell
{
    class TextBox
    {
        private Vector2 screenPosition = new Vector2(100,200);//initial screen position of the textbox can be set to different position
        private int height =100;//initial default height value for textbox will need to write a method which rezises the box depending on the length of the string it contains
        private int width = 300;//initial default width value for textbox will need to write a method which rezises the box depending on the length of the string it contains
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
                //need to add a check in here which makes sure the string can be contained inside the box and if not must use two methods  
                //a method to add in endlines at maximum string length
                //and a box resizing method that changes the height of the textbox to contain all the new lines
                //uses spritebatch variable from game1
                spriteBatch.Begin();

                

                
                // draw outline rectanlgle
                //create 1*1(pixel) colour data to be used for a texture 
                Color[] data2 = new Color[1 * 1];
                //create single pixel texture
                Texture2D t = new Texture2D(g.GraphicsDevice, 1, 1);
                //set the colour data as the textures colour
                for (int i = 0; i < data2.Length; ++i)
                    data2[i] = Color.White;
                t.SetData(data2);
                //create a rectangle 2 pixels higher in width and length for drawing
                Rectangle r = new Rectangle((int)screenPosition.X,(int)screenPosition.Y,width+2,height+2);
                //draw the outline rectangle using the texture created
                spriteBatch.Draw(t,new Vector2(screenPosition.X-1, screenPosition.Y-1),r, Color.White);

                //draw the inner rectangle to contain the text 
                //create texture size of the required textbox using same method as outline rectangle
                Color[] data = new Color[width * height];
                Texture2D rectTexture = new Texture2D(g.GraphicsDevice, width, height);

                for (int i = 0; i < data.Length; ++i)
                    data[i] = Color.Blue;
                //set the inner rectangle textures colour to blue
                rectTexture.SetData(data);
                
                var position = screenPosition;
                //draw the texbox in the required position
                spriteBatch.Draw(rectTexture, position, Color.Blue);
                SpriteEffects ef=new SpriteEffects();
                //draw the text inside the box 
                spriteBatch.DrawString(arial, theString, screenPosition, Color.White,0.0f,new Vector2(0,0),scale,ef,0.0f );


                spriteBatch.End();
            }
        }
        protected void Update() { }
    }
}
