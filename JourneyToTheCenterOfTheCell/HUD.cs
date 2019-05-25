using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


//author: Bruno Neto
//hud class holder for two text objects and our hud texture for hud
namespace JourneyToTheCenterOfTheCell
{
    class HUD
    {
        int health;
        int shield;
        Text m_health = new Text();
        Text m_shield = new Text();
        Texture2D hudImage ;
        private SpriteFont font;
        
        public void SetHealth(int h)//method to set the health parameter
        {
            health = h;
        }
        public void SetShield(int s)//method to set the shield parameter
        {
            shield = s;
        }
        public void Initialise(GameContext gameCtx, int screenX, int screenY)//method for loading the loaded spritefont from game1 into the textboxes spritefont variable
        {
            font = gameCtx.GetGameInstance().Content.Load<SpriteFont>("Fonts/arialFont");//initialise font
            
            m_shield.Initialise(font);//for each text
            m_shield.SetPosition(new Vector2(screenX-390, screenY-80));
            m_health.Initialise(font);
            m_health.SetPosition(new Vector2(290, screenY-80));
            health = 100;
            shield = 100;
            m_health.SetString("Health:" + health);
            m_shield.SetString("Shield:" + shield);
            hudImage = gameCtx.GetGameInstance().Content.Load<Texture2D>("Textures/HUD");
        }

        public void SetHealthPosition(Vector2 pos)//set the position for the health text on screen
        {
            m_health.SetPosition(pos);
        }
        public void SetShieldPosition(Vector2 pos)//set the position for the shield texbox on screen
        {
            m_shield.SetPosition(pos);
        }
        
        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager g)//draw method for the textbox only draws if the texboxes boolean for displaying is set to true
        {
            spriteBatch.Begin();
            spriteBatch.Draw(hudImage, null, g.GraphicsDevice.Viewport.Bounds);
            spriteBatch.End();

            m_health.Draw(spriteBatch, g);
            m_shield.Draw(spriteBatch, g);


        }

        public void Update(Player p1)
        {
            //will need to pass a player object in here 
            //need to check if local ints for health and shield are the same as the players if not use the setters to update to the players actual current hp and shield
            if (health != p1.GetHealth())
            {
                health = p1.GetHealth();
                m_health.SetString("Health: " + health);
            }
            if (shield != p1.GetShield())
            {
                shield = p1.GetShield();
                m_shield.SetString("Shield: " + shield);
            }
            


        }
    }
}

