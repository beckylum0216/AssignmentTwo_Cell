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
    /// @author Rebecca Lim
    /// <summary>
    /// Concrete actor class thaqt implements the contextual class of a finite state machine
    /// </summary>
    public class NPC : Actor
    {
        List<Vector3> npcWaypoints;
        private int npcID;
        INPCState npcState;

        Vector3 stateOffset;
        Vector3 stateMinPoint;
        Vector3 stateMaxPoint;
        InputHandler.keyStates npcType;

        /** 
        *   @brief parameterised constructor for NPCs 
        *   @brief 
        *   @see 
        *	@param Content
        *	@param inputID
        *	@param modelFile
        *	@param textureFile
        *	@param inputPosition
        *	@param inputrotation
        *	@param inputScale
        *	@param inputAABBOffset
        *	@param inputSpeed
        *	@param inputWaypoints
        *	@param inputtype
        *	@return 
        *	@pre 
        *	@post 
        */
        public NPC(ContentManager Content, int inputID , String modelFile, String textureFile,
                        Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset,
                        float inputSpeed, List<Vector3> inputWaypoints, InputHandler.keyStates inputType)
        {

            this.modelPath = modelFile;
            this.texturePath = textureFile;
            this.actorModel = Content.Load<Model>(modelPath);
            if(!(texturePath == null))
            {
                this.actorTexture = Content.Load<Texture2D>(texturePath);
            }
            
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
            //this.PrintNPCWaypoints();
            
            this.npcState = new NPCWander(this);

            this.npcType = inputType;

        }

        /** 
        *   @brief concrete function for the actor class
        *   @brief 
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public override Actor ActorClone(ContentManager Content, string modelFile, 
                                            string textureFile, Vector3 inputPosition, 
                                                Vector3 inputRotation, float inputScale, 
                                                    Vector3 inputAABBOffset, InputHandler.keyStates inputType)
        {
            return this.MemberwiseClone() as Actor;
        }

        /** 
        *   @brief concrete function for updating the NPC state
        *   @brief 
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public override void ActorUpdate(float deltaTime, float fps)
        {
            this.maxPoint = this.actorPosition + this.AABBOffset;
            this.minPoint = this.actorPosition - this.AABBOffset;



            this.stateOffset = new Vector3(500, 500, 500);
            this.stateMaxPoint = this.maxPoint + stateOffset;
            this.stateMinPoint = this.minPoint - stateOffset;

            this.actorPosition += AnimateNPC(deltaTime, fps);
        }

        /** 
        *   @brief mutator method implementing the contextual class of the fsm
        *   @brief 
        *   @see 
        *	@param inputState
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void SetNPCState(INPCState inputState)
        {
            this.npcState = inputState;
        }

        /** 
        *   @brief acceessor method implementing the contextual class of the fsm
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return npcState
        *	@pre 
        *	@post 
        */
        public INPCState GetNPCState()
        {
            return this.npcState;
        }


        /** 
        *   @brief mutator method implementing the contextual class of the fsm
        *   @see 
        *	@param inputType
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetNPCType(InputHandler.keyStates inputType)
        {
            this.npcType = inputType;
        }

        /** 
        *   @brief accessor method 
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return npcType
        *	@pre 
        *	@post 
        */
        public InputHandler.keyStates GetNPCType()
        {
            return this.npcType;
        }

        /** 
        *   @brief concrete method implementing the contextual class of the fsm
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return vector 3
        *	@pre 
        *	@post 
        */
        public Vector3 AnimateNPC(float deltaTime, float fps)
        {
            return this.npcState.Animate(this, deltaTime, fps);
        }

        /** 
        *   @brief accessor to the NPC ID
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return npcID
        *	@pre 
        *	@post 
        */
        public int GetNPCID()
        {
            return this.npcID;
        }


        /** 
        *   @brief mutator method for setting the waypoints of the NPC
        *   @see 
        *	@param inputWaypoints target waypoints
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetNPCWaypoints(List<Vector3> inputWaypoints)
        {
            this.npcWaypoints = inputWaypoints;
        }

        /** 
        *   @brief accessor method for the NPC waypoints
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return npcWaypoints
        *	@pre 
        *	@post 
        */
        public List<Vector3> GetNPCWaypoints()
        {
            return this.npcWaypoints;
        }

        /** 
        *   @brief utility function for debugging the waypoints
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return npcState
        *	@pre 
        *	@post 
        */
        public void PrintNPCWaypoints()
        {
            for(int ii = 0; ii < npcWaypoints.Count; ii +=1)
            {
                Debug.WriteLine("Waypoint index: " + ii + " vector: " + npcWaypoints[ii]);
            }
        }

        /** 
        *   @brief function for checking when the player comes into attack range
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return npcState
        *	@pre 
        *	@post 
        */
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
