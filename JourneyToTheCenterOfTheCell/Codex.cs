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

        public void SetInitTexture(String inputTexture)
        {
            this.initTexture = inputTexture;
        }

        public String GetInitTexture()
        {
            return this.initTexture;
        }

        public void SetItemActivate(Boolean inputState)
        {
            this.itemActivate = inputState;
        }

        public Boolean GetItemActivate()
        {
            return this.itemActivate;
        }

        public void SetItemInfo(String inputInfo)
        {
            this.itemInfo = inputInfo;
        }

        public String GetItemInfo()
        {
            return this.itemInfo;
        }

        public void SetItemActive(Boolean inputActive)
        {
            this.itemActive = inputActive;
        }

        public void SetItemUnlocked(Boolean inputUnlocked)
        {
            this.itemUnlocked = inputUnlocked;
        }

        public Boolean GetItemUnlocked()
        {
            return this.itemUnlocked;
        }

        public void SetFinalTexture(String inputPath)
        {
            this.finalTexture = inputPath;
        }

        public String GetFinalTexture()
        {
            return this.finalTexture;
        }

        public void SetKeyboardState(InputHandler.keyStates inputState)
        {
            this.keyBoardState = inputState;
        }

        public InputHandler.keyStates GetKeyBoardState()
        {
            return this.keyBoardState;
        }

        public void SetItemAnchor(Anchor inputAnchor)
        {
            this.itemAnchor = inputAnchor;
        }

        public Anchor GetItemAnchor()
        {
            return this.itemAnchor;
        }

        public void SetItemTitle(String inputTitle)
        {
            this.itemTitle = inputTitle;
        }

        public String GetItemTitle()
        {
            return this.itemTitle;
        }

    }
}
