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

        public void SetItemID(int inputID)
        {
            this.itemID = inputID;
        }

        public int GetItemID()
        {
            return this.itemID;
        }

        public void SetCodexType(InputHandler.keyStates inputType)
        {
            this.codexType = inputType;
        }

        public InputHandler.keyStates GetCodexType()
        {
            return  this.codexType;
        }


        public override Actor ActorClone(ContentManager Content, string modelFile, string textureFile, Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset)
        {
            throw new NotImplementedException();
        }

        public override Matrix ActorUpdate(Vector3 inputVector)
        {
            throw new NotImplementedException();
        }
    }
}
