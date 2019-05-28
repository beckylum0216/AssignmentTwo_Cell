using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    [Serializable]
    /// @brief class for the serialisation of the active codex items
    class CodexHash
    {
        private Dictionary<InputHandler.keyStates, string> codexDictionary;

        /** 
        *   @brief default contructor for the codexhash class
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public CodexHash()
        {
            codexDictionary = new Dictionary<InputHandler.keyStates, string>();
        }

        /** 
        *   @brief Mutator to the codex dictionary
        *   @see
        *	@param inputDictionary targt dictionary to add to the class
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetCodexDictionary(Dictionary<InputHandler.keyStates, string> inputDictionary)
        {
            this.codexDictionary = inputDictionary;
        }

        /** 
        *   @brief accessor to the codexDictionary
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return codexDictionary
        *	@pre 
        *	@post 
        */
        public Dictionary<InputHandler.keyStates, string> GetCodexDictionary()
        {
            return this.codexDictionary;
        }

    }
}
