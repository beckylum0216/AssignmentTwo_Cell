using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JourneyToTheCenterOfTheCell
{
    public class Item : Actor
    {
        private int itemID;
        private InputHandler.keyStates codexType;

        /**
	    *	@brief parameterised constructor to the plot object. Create a complete plot object.
	    *	@param Content 
        *	@param modelFile model file path
        *	@param textureFile texture file path
        *	@param predictedPosition predicitve collision method position. Not used
        *	@param inputPosition initial position of the pigeon
        *	@param inputRotation initial rotation of the pigeon
        *	@param inputScale initial scale of the pigeon
        *	@param inputAABBOffset the bounding box offsets
	    *	@return 
	    *	@pre 
	    *	@post Camera will exist
	    */
        public Item(ContentManager Content, int inputID,String modelFile, String textureFile,
                        Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset, 
                        InputHandler.keyStates inputType)
        {
            this.itemID = inputID;
            this.modelPath = modelFile;
            this.texturePath = textureFile;
            this.actorModel = Content.Load<Model>(modelPath);
            this.actorTexture = Content.Load<Texture2D>(texturePath);
            this.futurePosition = inputPosition;
            this.actorPosition = inputPosition;
            this.actorRotation = inputRotation;
            this.actorScale = inputScale;
            this.AABBOffset = inputAABBOffset;
            this.maxPoint = this.actorPosition + this.AABBOffset;
            this.minPoint = this.actorPosition - this.AABBOffset;
            this.codexType = inputType;
        }

        /** 
        *   @brief mutator to the itemID
        *   @see
        *	@param inputID unique identifier for codex
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetItemID(int inputID)
        {
            this.itemID = inputID;
        }

        /** 
        *   @brief accessor to the itemID
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return itemID unique identifier for codex
        *	@pre 
        *	@post 
        */
        public int GetItemID()
        {
            return this.itemID;
        }

        /** 
        *   @brief mutator to the codexType
        *   @see
        *	@param inputType the type of the Item in relation to the codex 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetCodexType(InputHandler.keyStates inputType)
        {
            this.codexType = inputType;
        }

        /** 
        *   @brief accessor to the codexType
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return codextype the type of the Item in relation to the codex 
        *	@pre 
        *	@post 
        */
        public InputHandler.keyStates GetCodexType()
        {
            return  this.codexType;
        }

        /** 
        *   @brief concrete functions to the actor abstraact class
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public override Actor ActorClone(ContentManager Content, string modelFile, string textureFile, Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset, InputHandler.keyStates inputType)
        {
            throw new NotImplementedException();
        }

        /** 
        *   @brief concrete functions to the actor abstraact class
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public override void ActorUpdate(float deltaTime, float fps)
        {
            throw new NotImplementedException();
        }


    }
}
