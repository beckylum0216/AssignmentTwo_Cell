using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


//author: Bruno Neto
//hud class holder for two text objects and our hud texture for hud
namespace JourneyToTheCenterOfTheCell
{
	///   @brief  HUD class container for two text objects and our hud texture for hud
    class HUD
    {
        int health;
        int shield;
        Text m_health = new Text();
        Text m_shield = new Text();
        Texture2D hudImage ;
        private SpriteFont font;
/** 
*   @brief mutator for health the health of the player 
*   @see
*	@param h the value to set the hud health display to
*	@return void
*	@pre 
*	@post 
*/
        public void SetHealth(int h)//method to set the health parameter
        {
            health = h;
        }
/** 
*   @brief mutator for shield the shield of the player 
*   @see
*	@param s the value to set the hud shield display to
*	@return void
*	@pre 
*	@post 
*/
        public void SetShield(int s)//method to set the shield parameter
        {
            shield = s;
        }
/** 
*   @brief Initialise for the hud  
*   @see
*	@param gameCtx the current game context
*	@param screenX the max x of current viewport
*	@param screenY the max y of current viewport
*	@return void
*	@pre 
*	@post 
*/
        public void Initialise(GameContext gameCtx, int screenX, int screenY)//method for loading the loaded spritefont from game1 into the textboxes spritefont variable
        {
            font = gameCtx.GetGameInstance().Content.Load<SpriteFont>("Fonts/arialFont");//initialise font
            
            m_shield.Initialise(font);//for each text
            m_shield.SetPosition(new Vector2((screenX/2)+(screenX/52), screenY-(screenY/6)));
            m_health.Initialise(font);
            m_health.SetPosition(new Vector2((screenX/2)-(screenX/7.5f), screenY- (screenY / 6)));
            health = 100;
            shield = 100;
            m_health.SetString("Health:" + health);
            m_shield.SetString("Shield:" + shield);
            hudImage = gameCtx.GetGameInstance().Content.Load<Texture2D>("Textures/HUD");
        }
/** 
*   @brief mutator for m_health text object position 
*   @see
*	@param pos the value to set the hud health position to
*	@return void
*	@pre 
*	@post 
*/
        public void SetHealthPosition(Vector2 pos)//set the position for the health text on screen
        {
            m_health.SetPosition(pos);
        }
/** 
*   @brief mutator for m_shield text object position 
*   @see
*	@param pos the value to set the hud shield position to
*	@return void
*	@pre 
*	@post 
*/
        public void SetShieldPosition(Vector2 pos)//set the position for the shield texbox on screen
        {
            m_shield.SetPosition(pos);
        }
 /** 
*   @brief draw for hud object draws all hud parts in set locations 
*   @see
*	@param spriteBatch the games spriteBatch for drawing with
*	@param g the games GraphicsDeviceManager for drawing with
*	@return void
*	@pre 
*	@post 
*/       
        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager g)//draw method for the textbox only draws if the texboxes boolean for displaying is set to true
        {
            spriteBatch.Begin();
            spriteBatch.Draw(hudImage, null, g.GraphicsDevice.Viewport.Bounds);
            spriteBatch.End();

            m_health.Draw(spriteBatch, g);
            m_shield.Draw(spriteBatch, g);


        }
 /** 
*   @brief update for hud object updates all hud parts based on the cameras player object 
*   @see
*	@param p1 the player object for updating hud variables to match player
*	@return void
*	@pre 
*	@post 
*/
        public void Update(Player p1)
        {
            //will need to pass a player object in here 
            //need to check if local ints for health and shield are the same as the players if not use the setters to update to the players actual current hp and shield
            if (health != (int)p1.GetHealth())
            {
                health = (int)p1.GetHealth();
                m_health.SetString("Health: " + health);
            }
            if (shield != (int)p1.GetShield())
            {
                shield = (int)p1.GetShield();
                m_shield.SetString("Shield: " + shield);
            }
            


        }
    }
}

