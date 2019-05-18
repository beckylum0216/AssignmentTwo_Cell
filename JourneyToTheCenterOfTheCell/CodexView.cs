//Author:Bruno Neto
//CodexGui: this class forms the basic ui for the codex page to be loaded by the codex class
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace JourneyToTheCenterOfTheCell
{
    class CodexView
    {
        private List<Codex> codexList;
        private Panel newPanel;

        public CodexView(List <Codex> inputList)
        {
            this.codexList = inputList;
        }

        public void SetCodexList(List<Codex> inputList)
        {
            this.codexList = inputList;
        }
        
        public List<Codex> GetCodexList()
        {
            return this.codexList;
        }

        public void SetPanel(ContentManager Content, Dictionary<InputHandler.keyStates, Item> activeStateHash)
        {
            newPanel = new Panel();
            Header pageHead = new Header("Codex", Anchor.TopCenter, new Vector2(0, -18));
            pageHead.AddChild(new HorizontalLine(Anchor.BottomCenter));
            // add title and text
            newPanel.AddChild(pageHead);
            
            for(int ii = 0; ii < codexList.Count; ii += 1)
            {
                Image codexImage;
                if(activeStateHash.ContainsKey(codexList[ii].GetKeyBoardState()))
                {
                    codexImage = new Image(Content.Load<Texture2D>(codexList[ii].GetFinalTexture()), new Vector2(120, 120), ImageDrawMode.Stretch, codexList[ii].GetItemAnchor(), new Vector2(0, 10));
                }
                else
                {
                    codexImage = new Image(Content.Load<Texture2D>(codexList[ii].GetInitTexture()), new Vector2(120, 120), ImageDrawMode.Stretch, codexList[ii].GetItemAnchor(), new Vector2(0, 10));
                }

                codexImage.AddChild(new Paragraph(codexList[ii].GetItemTitle(), codexList[ii].GetItemAnchor(), null, null, 0.8f));
                newPanel.AddChild(codexImage);
            }
        }

        public Panel GetPanel()
        {
            return newPanel;
        }
    }
}
