﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    /// @author Rebecca Lim
    /// <summary>
    /// Concrete class for creating the Skybox
    /// </summary>
    class SkyBox:Actor
    {
        public SkyBox(ContentManager Content, String modelFile, String textureFile,
                        Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset)
        {
            this.modelPath = modelFile;
            this.texturePath = textureFile;
            this.actorModel = Content.Load<Model>(modelPath);
            this.actorTexture = Content.Load<Texture2D>(texturePath);
            this.actorPosition = inputPosition;
            this.actorRotation = inputRotation;
            this.actorScale = inputScale;
            this.AABBOffset = inputAABBOffset;
        }

        /** 
        *   @brief abstract method for updating actor. not implemented as not required
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return landPlot the whole dictionary
        *	@pre 
        *	@post 
        */
        public override void ActorUpdate(float deltaTime, float fps)
        {
            throw new NotImplementedException();
        }

        /** 
        *   @brief implemented abstract method for cloning a prototype
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return new skybox actor
        *	@pre 
        *	@post 
        */
        public override Actor ActorClone(ContentManager Content, String modelFile, String textureFile, Vector3 inputPosition,
                                    Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset, InputHandler.keyStates inputType)
        {
            return new SkyBox(Content, modelPath, texturePath, actorPosition, actorRotation, actorScale, AABBOffset);
        }
    }
}
