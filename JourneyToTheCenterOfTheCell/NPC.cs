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
    public class NPC : Actor
    {
        List<Vector3> npcWaypoints;
        private int npcID;

        public NPC(ContentManager Content, int inputID , String modelFile, String textureFile,
                        Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset,
                        List<Vector3> inputWaypoints)
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

            this.npcID = inputID;
            this.npcWaypoints = inputWaypoints;
        }

        public override Actor ActorClone(ContentManager Content, string modelFile, string textureFile, Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset)
        {
            return this.MemberwiseClone() as Actor;
        }

        public override void ActorUpdate(Vector3 inputVector, float deltaTime, float fps)
        {
            this.actorPosition += AnimateNPC(deltaTime, fps);
        }

        public Vector3 AnimateNPC(float deltaTime, float fps)
        {
            Vector3 tempDirection = this.actorPosition - new Vector3(1, 1, 1);
            tempDirection.Normalize();
            Vector3 resultVector = tempDirection * this.actorSpeed * deltaTime * fps;

            return resultVector;
        }

        public int GetNPCID()
        {
            return this.npcID;
        }
    }
}
