//Author:Bruno Neto
//Player: this class forms the interface for resolving attacks from enemies, death,and getters for other classes to update(HUD) 
//Version 1.0

using GeonBit.UI;
using GeonBit.UI.Entities;

namespace JourneyToTheCenterOfTheCell
{
    public class Player
    {
        GameContext gtx;
        int health;
        int shield;
        
        bool shieldActive;
        public Player(GameContext GTX)
        {
            
            gtx = GTX;
            health = 100;
            shield = 100;
            shieldActive = false;
        }
        public void SetHealthByReductionAmount(int dmg)// can use these setters to test hud
        {
            health = health - dmg;
        }
        public void SetShieldActiveToggle()
        {
            if (shieldActive == true)
            {
                shieldActive = false;
            }
            else
            {
                shieldActive = true;
            }
        }
       
        public void SetShieldAmount(int shieldUseAmount)
        {
            shield = shield - shieldUseAmount;
        }
        public int GetHealth()
        {
            return health;
        }
        public int GetShield()
        {
            return shield;
        }
        public bool GetShieldIsActive()
        {
            return shieldActive;
        } 

        public void Update()
        {
            
        }
    }
}
