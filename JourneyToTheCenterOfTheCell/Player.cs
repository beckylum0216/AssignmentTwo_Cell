﻿//Author:Bruno Neto
//Player: this class forms the interface for resolving attacks from enemies, death,and getters for other classes to update(HUD) setting shield on or of and handling shield logic
//Version 1.0

using GeonBit.UI;
using GeonBit.UI.Entities;

namespace JourneyToTheCenterOfTheCell
{
    public class Player
    {
        private GameContext gtx;
        private float health;
        private float shield;
        private bool shieldActive;

        public Player(GameContext GTX)
        {
            
            gtx = GTX;
            health = 100;
            shield = 100;
            shieldActive = false;
        }
        public void SetHealthByReductionAmount(float dmg)// can use these setters to test hud
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
       
        public void SetShieldAmount(float shieldUseAmount)
        {
            shield = shield - shieldUseAmount;
        }

        public float GetHealth()
        {
            return health;
        }

        public float GetShield()
        {
            return shield;
        }

        public bool GetShieldIsActive()
        {
            return shieldActive;
        } 

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