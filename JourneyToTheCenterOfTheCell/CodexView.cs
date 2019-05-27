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
	/// @brief class for CodexView the panels and layout of codex
    class CodexView
    {
        private List<Codex> codexList;
        private Panel newPanel;
/** 
*	@brief constuctor for codexView with a given list of codex entries
*   @see
*	@param inputCodex the new codex  
*	@return 
*	@pre must be given a codex object
*	@post 
*/
        public CodexView(List <Codex> inputList)
        {
            this.codexList = inputList;
        }
/** 
*   @brief mutator for codexList variable 
*   @see
*	@param inputList the variable to set local list to 
*	@return 
*	@pre inputList must be valid list of codex
*	@post 
*/
        public void SetCodexList(List<Codex> inputList)
        {
            this.codexList = inputList;
        }
/** 
*   @brief Accessor for codexList variable
*   @see
*	@param 
*	@return codexList list of codexes variable
*	@pre  
*	@post 
*/        
        public List<Codex> GetCodexList()
        {
            return this.codexList;
        }
/** 
*   @brief mutator for newPanel variable 
*   @see
*	@param Content the games content manager for access to the files needed for panel
*	@param  activeSateHash hashmap keeping track of what has been sampled
*	@return 
*	@pre content manage must be initialised, dictionary/hashmap also
*	@post 
*/
        public void SetPanel(ContentManager Content, Dictionary<InputHandler.keyStates, Actor> activeStateHash)
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
/** 
*   @brief Accessor for newPanel variable
*   @see
*	@param 
*	@return newPanel the local panel variable
*	@pre  newpanel must be set before using it from this accessor
*	@post 
*/ 
        public Panel GetPanel()
        {
            return newPanel;
        }
    }
}
