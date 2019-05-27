using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

//author: Bruno Neto

namespace JourneyToTheCenterOfTheCell
{

	///   @brief  text class object for holding strings to draw to the set string and the  set position 
    class Text
    {
        private Vector2 screenPosition = new Vector2(100,200);//initial screen position of the textbox can be set to different position
        //private int height =100;//initial default height value for textbox will need to write a method which rezises the box depending on the length of the string it contains
        //private int width = 300;//initial default width value for textbox will need to write a method which rezises the box depending on the length of the string it contains
        private SpriteFont arial;//spritefont which will hold the font loaded in game1
        private string theString = "some texts";//initial default textbox string value can be set to anny string value
        bool drawnow = false;//boolean for determining wether the loaded texbox should be drawn or not
        private Vector2 scale = new Vector2(1.0f,1.0f);//scale of the text can be used in the resize method 
/** 
*   @brief mutator for the theString string of text 
*   @see
*	@param s the string to assign to theString
*	@return void
*	@pre 
*	@post 
*/
        public void SetString(string s)//method to set the string parameter
        {
            theString = s;
        }
        //public void DisplayFont()//sets the boolean to true so the textbox is drawn 
        //{
        //    drawnow = true;
        //}
       // public void RemoveDisplayFont()//sets the boolean to false to not fraw the set textbox
       // {
       //     drawnow = false;
       // }
/** 
*   @brief acessor for the theString string of text 
*   @see
*	@param 
*	@return theString the texts string variable
*	@pre 
*	@post 
*/
        public string GetString()//method for determining contents of string for a textbox
        {
            return theString;
        }
/** 
*   @brief Mutator for the screenPosition  of text  
*   @see
*	@param pos the vector to set screenPosition to
*	@return void
*	@pre 
*	@post 
*/
        public void SetPosition(Vector2 pos)//set the position for the texbox on screen
        {
            screenPosition = pos;
        }
/** 
*   @brief acessor for the screenPosition  of text  
*   @see
*	@param 
*	@return screenPosition the screen position of text
*	@pre 
*	@post 
*/
        public Vector2 GetPosition()//method for determining the set position of a textbox
        {
            return screenPosition;
        }
/** 
*   @brief Initialise for text class sets the sprite font to the spritefont given text must be initialized before draw 
*   @see
*	@param f the games spritefont variable to initialie the texts font to
*	@return void
*	@pre f must be initialized before being used to initialise a text
*	@post 
*/
        public void Initialise(SpriteFont f)//method for loading the loaded spritefont from game1 into the textboxes spritefont variable
        {
           
            arial = f;
        }
/** 
*   @brief draw for text class draws the set string in the the set position 
*   @see
*	@param spriteBatch the games spritebatch variable for drawing the text with
*	@param g the games graphics device manager
*	@return void
*	@pre 
*	@post 
*/
        public void Draw(SpriteBatch spriteBatch,GraphicsDeviceManager g)//draw method for the textbox only draws if the texboxes boolean for displaying is set to true
        {
            
            //uses spritebatch variable from game1
            spriteBatch.Begin();


            //draw the text at the required positionx
            spriteBatch.DrawString(arial, theString, screenPosition, Color.Blue);


            spriteBatch.End();
           

            

            
        }
/** 
*   @brief Update for text class unused as updating the text happens in classes using the text class in this implementation 
*   @see
*	@param 
*	@return void
*	@pre 
*	@post 
*/
        public void Update()
        {
            

        }
    }
}
