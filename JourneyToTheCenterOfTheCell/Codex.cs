using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JourneyToTheCenterOfTheCell
{
/// @brief class for codex
    class Codex
    {
        private String initTexture;
        private String finalTexture;
        private Boolean itemActivate; //only activate info panels if the codex is already open
        private String itemInfo;
        private Boolean itemActive; //activate info panel
        private Boolean itemUnlocked;
        private InputHandler.keyStates keyBoardState;
        private Anchor itemAnchor;
        private String itemTitle;

        /** 
        *	@brief constuctor for codex with a given codex 
        *   @see
        *	@param inputCodex the new codex  
        *	@return 
        *	@pre must be given a codex object
        *	@post 
        */
        public Codex(Codex inputCodex)
        {
            this.initTexture = "Pics/lockedInfoCodex";
            this.finalTexture = inputCodex.GetFinalTexture();
            this.itemActivate = false;
            this.itemInfo = inputCodex.GetItemInfo();
            this.itemActive = false;
            this.itemUnlocked = false;
            this.keyBoardState = inputCodex.GetKeyBoardState();
            this.itemAnchor = inputCodex.GetItemAnchor();
            this.itemTitle = inputCodex.GetItemTitle();
        }

        /** 
        *   @brief default constructor for codex 
        *   @see
        *	@param inputFinalTexture the texture for the new codex
        *	@param inputInfo the new codex info
        *	@param inputState the new codex input
        *	@param inputAnchor the new codex anchor
        *	@param inputTitle the new codex title
        *	@return
        *	@pre parameters must be initialised
        *	@post 
        */
        public Codex(String inputFinalTexture, String inputInfo, InputHandler.keyStates inputState, Anchor inputAnchor, String inputTitle)
        {
            this.initTexture = "Pics/lockedInfoCodex";
            this.finalTexture = inputFinalTexture;
            this.itemActivate = false;
            this.itemInfo = inputInfo;
            this.itemActive = false;
            this.itemUnlocked = false;
            this.keyBoardState = inputState;
            this.itemAnchor = inputAnchor;
            this.itemTitle = inputTitle;
        }

        /** 
        *   @brief mutator for the initTexture filename for codex
        *   @see
        *	@param inputTexture the string texture filename 
        *	@return void 
        *	@pre inputTexture must correlate with a file in texture 
        *	folder
        *	@post 
        */
        public void SetInitTexture(String inputTexture)
        {
            this.initTexture = inputTexture;
        }

        /** 
        *   @brief accessor for initTexture in codex 
        *   @see
        *	@param
        *	@return initTexture the texure in codex 
        *	@pre 
        *	@post 
        */
        public String GetInitTexture()
        {
            return this.initTexture;
        }

        /** 
        *   @brief mutator for itemActivate boolean to determine what *	codex page is active is diplayed in codex
        *   @see
        *	@param inputState the state to set the boolean
        *	@return 
        *	@pre input state must be true or false
        *	@post 
        */
        public void SetItemActivate(Boolean inputState)
        {
            this.itemActivate = inputState;
        }

        /** 
        *   @brief Accessor for codex itemActivated boolean  
        *   @see
        *	@param 
        *	@return itemActivate the boolean for tracking if item is activated
        *	@pre  
        *	@post 
        */
        public Boolean GetItemActivate()
        {
            return this.itemActivate;
        }

        /** 
        *   @brief mutator for itemInfo string  
        *   @see
        *	@param inputInfo the input string to set local var to 
        *	@return 
        *	@pre inputInfo must be a valid string 
        *	@post 
        */
        public void SetItemInfo(String inputInfo)
        {
            this.itemInfo = inputInfo;
        }

        /** 
        *   @brief Accessor for itemInfo string
        *   @see
        *	@param 
        *	@return itemInfo the item info string
        *	@pre  
        *	@post 
        */
        public String GetItemInfo()
        {
            return this.itemInfo;
        }

        /** 
        *   @brief mutator for itemActive boolean 
        *   @see
        *	@param inputActive the variable to set local boolean to 
        *	@return 
        *	@pre inputActive must be true or false 
        *	@post 
        */
        public void SetItemActive(Boolean inputActive)
        {
            this.itemActive = inputActive;
        }

        /** 
        *   @brief mutator for itemUnlocked boolean 
        *   @see
        *	@param inputUnlocked the variable to set local boolean to 
        *	@return 
        *	@pre inputUnlocked must be true or false 
        *	@post 
        */
        public void SetItemUnlocked(Boolean inputUnlocked)
        {
            this.itemUnlocked = inputUnlocked;
        }

        /** 
        *   @brief Accessor for itemUnlocked boolean
        *   @see
        *	@param 
        *	@return itemUnlocked the item unlocked boolean
        *	@pre  
        *	@post 
        */
        public Boolean GetItemUnlocked()
        {
            return this.itemUnlocked;
        }

        /** 
        *   @brief mutator for finalTexture string 
        *   @see
        *	@param inputPath the variable to set local string to 
        *	@return 
        *	@pre inputPath must filename of a texture in texture folder 
        *	@post 
        */
        public void SetFinalTexture(String inputPath)
        {
            this.finalTexture = inputPath;
        }

        /** 
        *   @brief Accessor finalTexture 
        *   @see
        *	@param 
        *	@return finalTexture the final texture
        *	@pre  
        *	@post 
        */
        public String GetFinalTexture()
        {
            return this.finalTexture;
        }

        /** 
        *   @brief mutator for keyboardState variable 
        *   @see
        *	@param inputState the variable to set local keyboard state to 
        *	@return 
        *	@pre inputState must a valid keystate folder
        *	@post 
        */
        public void SetKeyboardState(InputHandler.keyStates inputState)
        {
            this.keyBoardState = inputState;
        }

        /** 
        *   @brief Accessor for keyboardState value
        *   @see
        *	@param 
        *	@return keyBoardState the keyboard state value
        *	@pre  
        *	@post 
        */
        public InputHandler.keyStates GetKeyBoardState()
        {
            return this.keyBoardState;
        }

        /** 
        *   @brief mutator for itemAnchor value 
        *   @see
        *	@param inputAnchor the variable to set local anchor to
        *	@return 
        *	@pre inputAnchor must valid geonbit anchor value folder 
        *	@post 
        */
        public void SetItemAnchor(Anchor inputAnchor)
        {
            this.itemAnchor = inputAnchor;
        }

        /** 
        *   @brief Accessor for itemAnchor value
        *   @see
        *	@param 
        *	@return itemAnchor the item anchor value
        *	@pre  
        *	@post 
        */
        public Anchor GetItemAnchor()
        {
            return this.itemAnchor;
        }

        /** 
        *   @brief mutator for itemTitle value 
        *   @see
        *	@param inputTitle the variable to set local itemTitle to
        *	@return 
        *	@pre inputTitle must valid string folder 
        *	@post 
        */
        public void SetItemTitle(String inputTitle)
        {
            this.itemTitle = inputTitle;
        }

        /** 
        *   @brief Accessor for itemTitle string
        *   @see
        *	@param 
        *	@return itemTitle the item Title string
        *	@pre  
        *	@post 
        */
        public String GetItemTitle()
        {
            return this.itemTitle;
        }

    }
}
