using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        INPCState npcState;

        Vector3 stateOffset;
        Vector3 stateMinPoint;
        Vector3 stateMaxPoint;
        //Subject camera;

        public NPC(ContentManager Content, int inputID , String modelFile, String textureFile,
                        Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset,
                        float inputSpeed, List<Vector3> inputWaypoints)
        {

            this.modelPath = modelFile;
            this.texturePath = textureFile;
            this.actorModel = Content.Load<Model>(modelPath);
            this.actorTexture = Content.Load<Texture2D>(texturePath);
            this.futurePosition = inputPosition;
            this.actorPosition = inputPosition;
            this.actorRotation = inputRotation;
            this.actorScale = inputScale;
            this.actorSpeed = inputSpeed;
            this.AABBOffset = inputAABBOffset;
            this.maxPoint = this.actorPosition + this.AABBOffset;
            this.minPoint = this.actorPosition - this.AABBOffset;

            this.stateOffset = new Vector3(10, 10, 10);
            this.stateMaxPoint = this.maxPoint + stateOffset;
            this.stateMinPoint = this.minPoint - stateOffset;

            this.npcID = inputID;
            this.npcWaypoints = inputWaypoints;
            //Debug.WriteLine("Waypoint Size: " + this.npcWaypoints.Count);
            this.PrintNPCWaypoints();

            //this.npcWaypointIndex = 0;
            //this.tempIndex = 0;
            //resultVector = new Vector3(0, 0, 0);
            //tempDirection = new Vector3(0, 0, 0);
            this.npcState = new NPCWander(this);

        }

        public override Actor ActorClone(ContentManager Content, string modelFile, string textureFile, Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset)
        {
            return this.MemberwiseClone() as Actor;
        }

        public override void ActorUpdate(float deltaTime, float fps)
        {
            this.maxPoint = this.actorPosition + this.AABBOffset;
            this.minPoint = this.actorPosition - this.AABBOffset;



            this.stateOffset = new Vector3(500, 500, 500);
            this.stateMaxPoint = this.maxPoint + stateOffset;
            this.stateMinPoint = this.minPoint - stateOffset;

            this.actorPosition += AnimateNPC(deltaTime, fps);
        }

        public void SetNPCState(INPCState inputState)
        {
            this.npcState = inputState;
        }

        public INPCState GetNPCState()
        {
            return this.npcState;
        }

        public Vector3 AnimateNPC(float deltaTime, float fps)
        {
            return this.npcState.Animate(this, deltaTime, fps);
        }

        public int GetNPCID()
        {
            return this.npcID;
        }

        

        public void SetNPCWaypoints(List<Vector3> inputWaypoints)
        {
            this.npcWaypoints = inputWaypoints;
        }

        public List<Vector3> GetNPCWaypoints()
        {
            return this.npcWaypoints;
        }

        public void PrintNPCWaypoints()
        {
            for(int ii = 0; ii < npcWaypoints.Count; ii +=1)
            {
                Debug.WriteLine("Waypoint index: " + ii + " vector: " + npcWaypoints[ii]);
            }
        }

        public Boolean StateAABB(Subject inputSubject)
        {
            //Debug.WriteLine("camera maxpoint: " + inputSubject.maxPoint);

            return (this.stateMaxPoint.X > inputSubject.minPoint.X &&
                    this.stateMinPoint.X < inputSubject.maxPoint.X &&
                    this.stateMaxPoint.Y > inputSubject.minPoint.Y &&
                    this.stateMinPoint.Y < inputSubject.maxPoint.Y &&
                    this.stateMaxPoint.Z > inputSubject.minPoint.Z &&
                    this.stateMinPoint.Z < inputSubject.maxPoint.Z);
        }

    }
}
