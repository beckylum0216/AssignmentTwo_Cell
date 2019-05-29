//Author:Bruno Neto
//Player: this class forms the interface for resolving attacks from enemies, death,and getters for other classes to update(HUD) setting shield on or of and handling shield logic
//Version 1.0

using GeonBit.UI;
using GeonBit.UI.Entities;

namespace JourneyToTheCenterOfTheCell
{
	///   @brief  Player class container for game logic things like shield health etc 
    public class Player
    {
        private GameContext gtx;
        private float health;
        private float shield;
        private bool shieldActive;

        /** 
        *   @brief constructor for Player class 
        *   @see
        *	@param GTX the current game context
        *	@return 
        *	@pre 
        *	@post 
        */
        public Player(GameContext GTX)
        {
            
            gtx = GTX;
            health = 100;
            shield = 100;
            shieldActive = false;
        }

        /** 
        *   @brief mutator for reducing health by set amounts 
        *   @see
        *	@param dmg the value to reduce health by
        *	@return void
        *	@pre 
        *	@post 
        */
        public void SetHealthByReductionAmount(float dmg)// can use these setters to test hud
        {
            health = health - dmg;
        }

        /** 
        *   @brief mutator for boolean that tracks if shield is active
        *   @see
        *	@param 
        *	@return void
        *	@pre toggles between active and inactive when called
        *	@post 
        */
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

        /** 
        *   @brief mutator for reducing shield by set amount 
        *   @see
        *	@param shieldUseAmount the value to reduce the shield by
        *	@return void
        *	@pre 
        *	@post 
        */      
        public void SetShieldAmount(float shieldUseAmount)
        {
            shield = shield - shieldUseAmount;
            if (shield > 100) { shield = 100; }
        }

        /** 
        *   @brief accessor for health variable 
        *   @see
        *	@param 
        *	@return health the health of the player
        *	@pre 
        *	@post 
        */ 
        public float GetHealth()
        {
            return health;
        }

        /** 
        *   @brief accessor for shield variable 
        *   @see
        *	@param 
        *	@return shield the shield of the player
        *	@pre 
        *	@post 
        */
        public float GetShield()
        {
            return shield;
        }


        /** 
        *   @brief accessor for shieldActive variable 
        *   @see
        *	@param 
        *	@return shieldActive wether the shield is active or not
        *	@pre 
        *	@post 
        */
        public bool GetShieldIsActive()
        {
            return shieldActive;
        } 

        /** 
        *   @brief update for player counts down shield energy if shield is active
        *   @see
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void Update()
        {
            if (shieldActive == true)
            {
                shield = shield - 0.07f;
            }
            if (shield < 1)
            {
                shieldActive = false;
            }
            
        }
    }
}
