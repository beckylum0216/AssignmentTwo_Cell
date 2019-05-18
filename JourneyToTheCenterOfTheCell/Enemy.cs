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
    class Enemy : Actor
    {

        //FINITE STATE MACHINE YET TO BE ADDED - CODING IN PROGRESS
        int ID;

        public Enemy(ContentManager Content, String modelFile, String textureFile,
        Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset, int id)
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
            this.ID = id;
        }

        //Positions=====================================
        public void SetPosition(Vector3 inputPosition)
        {
            this.actorPosition = inputPosition;

            /**
             * //Build movement vector in state machine
             */ //pass vector into ActorUpdate...
            this.ActorUpdate(actorPosition);
             
        }

        public Vector3 GetPosition()
        {
            return this.actorPosition;
        }

        //Rotations=====================================
        public void SetRotation(Vector3 inputRotation)
        {
            this.actorRotation = inputRotation;
        }

        public Vector3 GetRotation()
        {
            return this.actorRotation;
        }

        //Scalars=======================================
        public void SetScale(float inputScale)
        {
            this.actorScale = inputScale;
        }

        public float GetScale()
        {
            return this.actorScale;
        }

        //Min and Max Points=============================
        public void SetMinPoint()
        {
            this.minPoint = actorPosition - AABBOffset;
        }

        public Vector3 GetMinPoint()
        {
            return this.minPoint;
        }

        public void SetMaxPoint()
        {
            this.maxPoint = actorPosition + AABBOffset;
        }

        public Vector3 GetMaxPoint()
        {
            return this.minPoint;
        }


        public int GetID()
        {
            return(ID);
        }

        //Overridden from Actor================================
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
