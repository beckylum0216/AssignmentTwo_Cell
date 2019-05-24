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
    public class Structure : Actor
    {

        

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
        public Structure(ContentManager Content,  String modelFile, String textureFile,
                        Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset, InputHandler.keyStates inputCodex)
        {
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
            this.codexType = inputCodex;

        }

        

        /** 
        *   @brief function to update the state of the actor. For plot this is not implmented
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return actorScale
        *	@pre 
        *	@post 
        */
        public override void ActorUpdate(float deltaTime, float fps)
        {
            throw new NotImplementedException();
        }

        /** 
        *   @brief Function that implement the prototype pattern clone functionality 
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return new plot object
        *	@pre 
        *	@post 
        */
        public override Actor ActorClone(ContentManager Content, String modelFile, String textureFile, Vector3 inputPosition,
                                    Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset, InputHandler.keyStates inputType)
        {
            return new Structure(Content, modelPath, texturePath, actorPosition, actorRotation, actorScale, AABBOffset, inputType);
        }

        

        
    }
}
