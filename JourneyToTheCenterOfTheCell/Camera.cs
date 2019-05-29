using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    public class Camera: Subject
    {

        private Matrix theCamera;
        private Vector3 cameraEye;
        private Vector3 zoomVector;
        private Quaternion deltaQuaternion;
        private ModelHandler itemHandler;
        //private Dictionary<InputHandler.keyStates, Actor> codexHash;
        //setting up persistence 
        private CodexHash codexHash;
        private SoundEffect itemSound;
        private List<NPCWander> wanderList;
        private Player p1;
        private int gameLevel;
        private bool selenoAquired = false;
        private string filePath = "codex.dat";
        private bool msgState = false;
        /** 
        *   @brief default camera constructor 
        *   @return 
        *	@pre 
        *	@post creates a camera instance
        */
        public Camera(){ }

        /** 
        *   @brief parameterised camera constructor
        *	@return 
        *	@pre 
        *	@post creates a camera instance
        */
        public Camera(GameContext gtx, ContentManager Content, Matrix inputCamera, Vector3 initPosition, Vector3 eyePosition, Vector3 deltaVector, Vector3 inputOffset, ModelHandler inputHandler, int inputLevel)
        {
            this.theCamera = inputCamera;
            this.futurePosition = initPosition;
            this.subjectPosition = initPosition;
            this.cameraEye = eyePosition;
            this.subjectRotation = deltaVector;
            this.deltaQuaternion = Quaternion.Identity;
            this.AABBOffset = new Vector3(1f, 1f, 1f);
            this.maxPoint = this.subjectPosition + this.AABBOffset;
            this.minPoint = this.subjectPosition - this.AABBOffset;
            zoomVector = new Vector3(0, 0, 0);
            this.itemHandler = inputHandler;
            //this.codexHash = new Dictionary<InputHandler.keyStates, Actor>();
            this.gameLevel = inputLevel;
            if(gameLevel == 0)
            {
                this.codexHash = new CodexHash();
            }
            else
            {
                if (File.Exists("codex.dat"))
                {
                    Stream codexStream = new FileStream("codex.dat", FileMode.Open, FileAccess.Read);
                    BinaryFormatter deserialiser = new BinaryFormatter();
                    codexHash = (CodexHash)deserialiser.Deserialize(codexStream);
                    codexStream.Close();
                }
            }
            
            
            

            itemSound = Content.Load<SoundEffect>("Sound/Power_Up_Ray-Mike_Koenig-800933783");
            p1 = new Player(gtx);
            
            //this.endGameState = false;
            
        }

        /** 
        *   @brief parameterised camera constructor
        *	@return 
        *	@pre 
        *	@post creates a camera instance
        */
        public Camera(GameContext gtx, ContentManager Content, String modelFile, String textureFile, Vector3 predictedPosition, Vector3 inputPosition, 
                        Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset, Camera inputCamera, ModelHandler inputHandler, int inputLevel)
        {
            this.modelPath = modelFile;
            this.texturePath = textureFile;
            this.subjectModel = Content.Load<Model>(modelPath);
            this.subjectTexture = Content.Load<Texture2D>(texturePath);
            this.futurePosition = predictedPosition;
            this.subjectPosition = inputPosition;
            this.subjectRotation = inputRotation;
            this.subjectScale = inputScale;
            this.AABBOffset = inputAABBOffset;
            this.maxPoint = this.subjectPosition + this.AABBOffset;
            this.minPoint = this.subjectPosition - this.AABBOffset;
            this.itemHandler = inputHandler;
            //this.codexHash = new Dictionary<InputHandler.keyStates, Actor>();
            this.gameLevel = inputLevel;
            if (gameLevel == 0)
            {
                this.codexHash = new CodexHash();
            }
            else
            {
                if (File.Exists("codex.dat"))
                {
                    Stream codexStream = new FileStream("codex.dat", FileMode.Open, FileAccess.Read);
                    BinaryFormatter deserialiser = new BinaryFormatter();
                    codexHash = (CodexHash)deserialiser.Deserialize(codexStream);
                    codexStream.Close();
                }
            }
            itemSound = Content.Load<SoundEffect>("Sound/Power_Up_Ray-Mike_Koenig-800933783");
            p1 = new Player(gtx);
            

        }


        /** 
         *  @brief gets the player object of camera giving access to any object that accesses camera already 
         *	@return p1 the player object in camera
         *	@pre 
         *	@post returns the cameras player class
         */
        public Player GetCamPlayer()
        {
            return this.p1;
        }




        /** 
         *  @brief update the position state of the camera 
         *	@param inputVector the mouse inputs in vector form
         *	@param deltaTime the time the game has elapsed
         *	@param fps the frame rate
         *	@return tempCameraObj the position of the camera in matrix form
         *	@pre 
         *	@post position update of the camera object
         */
        public override Matrix SubjectUpdate(GameContext gameCtx, Vector3 inputVector, float deltaTime, float fps)
        {
            msgState = false;
            /// calculate pitch axis for rotating, therefore the orthogonal between the forward and up 
            /// assuming righthandedness
            Vector3 pitchAxis = Vector3.Cross(subjectRotation, Vector3.Up);
            pitchAxis.Normalize();
            p1.Update();
            subjectRotation = CameraUpdate(subjectRotation, pitchAxis, inputVector.Y, inputVector);
            subjectRotation = CameraUpdate(subjectRotation, Vector3.Up, -inputVector.X, -inputVector);

            cameraEye = subjectPosition + subjectRotation; // this is the correct 

            subjectPosition = FloorCheck();
            subjectPosition = RoofCheck();
            subjectPosition = FrontCheck();
            subjectPosition = BackCheck();
            subjectPosition = LeftCheck();
            subjectPosition = RightCheck();
            for (int ii = 0; ii < this.GetObservers().Count; ii += 1)
            {

                if (this.GetObservers()[ii].AABBtoAABB(this))
                {
                    if(this.GetObservers()[ii].GetCodexType() == InputHandler.keyStates.Cell)
                    {
                        //Debug.WriteLine("Codex Type: " + this.GetObservers()[ii].GetCodexType());
                        if (!this.codexHash.GetCodexDictionary().ContainsKey(this.GetObservers()[ii].GetCodexType()))
                        {
                            itemSound.Play();
                            this.codexHash.GetCodexDictionary().Add(this.GetObservers()[ii].GetCodexType(), this.GetObservers()[ii].GetCodexType().ToString());
                            this.codexHash.GetCodexDictionary().Add(InputHandler.keyStates.Cytoskeleton, InputHandler.keyStates.Cytoskeleton.ToString());
                        }

                        Stream codexStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        BinaryFormatter serialiser = new BinaryFormatter();
                        serialiser.Serialize(codexStream, codexHash);
                        codexStream.Close();

                        GameTwoManager newGame = new GameTwoManager(gameCtx);
                        gameCtx.SetGameState(newGame);
                    }
                    else
                    {
                        //Debug.WriteLine("Codex Type: " + this.GetObservers()[ii].GetCodexType());
                        
                        if (!this.codexHash.GetCodexDictionary().ContainsKey(this.GetObservers()[ii].GetCodexType()))
                        {
                            itemSound.Play();
                            this.codexHash.GetCodexDictionary().Add(this.GetObservers()[ii].GetCodexType(), this.GetObservers()[ii].GetCodexType().ToString());
                        }

                        if (this.subjectPosition.Y > 200f)
                        {
                            this.AABBResolution(this.GetObservers()[ii], deltaTime, fps);
                        }
                        else
                        {
                            this.AABBCollider(this.GetObservers()[ii]);
                        }
                    }
                }
            }


            // checking for item collisions
            for(int ii = 0; ii < this.GetItems().Count; ii += 1)
            {
                if(this.GetItems()[ii].AABBtoAABB(this))
                {
                    Debug.WriteLine("collided ID:" + this.GetItems()[ii].GetItemID());
                    //itemSound.Play();
                    if (this.GetItems()[ii].GetCodexType() == InputHandler.keyStates.Selenocysteine)
                    {
                        if(!(this.codexHash.GetCodexDictionary().Count < 8))
                        {
                            // add to codex ticked list if not on list
                            if (!this.codexHash.GetCodexDictionary().ContainsKey(this.GetItems()[ii].GetCodexType()))
                            {
                                itemSound.Play();
                                this.codexHash.GetCodexDictionary().Add(this.GetItems()[ii].GetCodexType(), this.GetItems()[ii].GetCodexType().ToString());
                            }

                            // removes sprite from screen
                            this.itemHandler.RemoveItemHash(this.GetItems()[ii].GetItemID());
                            this.GetItems().Remove(this.GetItems()[ii]);
                            selenoAquired = true;
                            //File.Delete(filePath);
                        }
                        else
                        {
                            Debug.WriteLine("You have not sampled all the organelles in the cell!!!");
                            msgState = true;
                        }
                    }
                    //else
                    //{
                    //    // add to codex ticked list if not on list
                    //    if (!this.codexHash.GetCodexDictionary().ContainsKey(this.GetItems()[ii].GetCodexType()))
                    //    {
                    //        itemSound.Play();
                    //        this.codexHash.GetCodexDictionary().Add(this.GetItems()[ii].GetCodexType(), this.GetItems()[ii].GetCodexType().ToString());
                    //    }
                    //}
                    

                    if (this.GetItems()[ii].GetCodexType() == InputHandler.keyStates.Mitochondria)
                    {
                        // removes sprite from screen
                        itemSound.Play();
                        this.itemHandler.RemoveItemHash(this.GetItems()[ii].GetItemID());
                        this.GetItems().Remove(this.GetItems()[ii]);
                        this.GetCamPlayer().SetShieldAmount(-50);
                        

                    }                  
                   
                    
                    
                }
            }

            for(int ii = 0; ii < this.GetNPCs().Count; ii += 1)
            {
                if(this.GetNPCs()[ii].StateAABB(this))
                {
                    if(this.GetNPCs()[ii].GetNPCType() == InputHandler.keyStates.RedBlood)
                    {
                        this.GetNPCs()[ii].SetNPCState(wanderList[ii]);
                    }
                    else
                    {
                        
                        if (this.GetCamPlayer().GetShieldIsActive() == false)
                        {
                            Debug.WriteLine("Attack State!!! codex type: " + this.GetNPCs()[ii].GetNPCType());

                            if (gameLevel == 1)
                            {
                                if (!this.codexHash.GetCodexDictionary().ContainsKey(this.GetNPCs()[ii].GetNPCType()))
                                {
                                    itemSound.Play();
                                    this.codexHash.GetCodexDictionary().Add(this.GetNPCs()[ii].GetNPCType(), this.GetNPCs()[ii].GetCodexType().ToString());
                                }
                            }

                            NPCAttack attackState = new NPCAttack(this);
                            this.GetNPCs()[ii].SetNPCState(attackState);
                            p1.SetHealthByReductionAmount(0.01f);
                        }
                        else if (this.GetCamPlayer().GetShieldIsActive() == true)
                        {
                            this.GetNPCs()[ii].SetNPCState(wanderList[ii]);
                        }
                    }
                    
                }
                else
                {
                    //Debug.WriteLine("Attack state!!!");
                   
                    this.GetNPCs()[ii].SetNPCState(wanderList[ii]);
                }
            }



            Matrix tempCameraObj = Matrix.CreateLookAt(subjectPosition, cameraEye, Vector3.Up);

            return tempCameraObj;
        }

        /** 
        *   @brief mutator to the NPC wander waypoints
        *	@return 
        *	@pre 
        *	@post sets NPC waypoints
        */
        public void SetWanderList(List <NPCWander> inputList)
        {
            this.wanderList = inputList;
        }

        /** 
        *   @brief accessor to the NPC wander waypoints
        *   @return wanderList the NPC waypoints 
        *	@pre 
        *	@post 
        */
        public List<NPCWander> GetWanderList()
        {
            return this.wanderList;
        }


        /** 
         *  @brief mutator for the camera position
         *	@param inputVector the new position 
         *	@return 
         *	@pre 
         *	@post position update of the camera object
         */
        public void SetCameraPosition(Vector3 inputVector)
        {
            this.subjectPosition = inputVector;
        }


        /** 
        *   @brief accessor for the camera position
        *	@param 
        *	@return subjectPosition 
        *	@pre position must exist
        *	@post 
        */
        public Vector3 GetCameraPosition()
        {
            return this.subjectPosition;
        }

        /** 
        *   @brief mutator for the camera viewport 
        *	@param inputVector the new camera viewport position
        *	@return 
        *	@pre 
        *	@post position must exist 
        */
        public void SetCameraEye(Vector3 inputVector)
        {
            this.cameraEye = inputVector;
        }
       
        /** 
        *   @brief accessor for the "front" vector. This function also translates a quaternion to a vector 
        *	@param 
        *	@return deltaVector  
        *	@pre vector must exist
        *	@post  
        */
        public Vector3 GetDeltaVector()
        {
            Vector3 deltaVector = new Vector3(deltaQuaternion.X, deltaQuaternion.Y, deltaQuaternion.Z);

            return deltaVector;
        }

        /** 
        *   @brief This is actually the camera rotation function. Calculates the new rotated position using quaternion rotation
        *	@param deltaVector the front vector
        *	@param targetAxis the axis to rotate on
        *	@param inputDegrees the amount of rotation in degrees
        *	@param inputVector the mouse input. used to check if there is movement
        *	@return deltaVector, subjectRotation   
        *	@pre deltaVector must not be zero
        *	@post  
        */
        public Vector3 CameraUpdate(Vector3 deltaVector, Vector3 targetAxis, float inputDegrees, Vector3 inputVector)
        {
            
            if (inputVector.Length() > 0)
            {
                float radianInput = SubjectRadians(inputDegrees);
               
                deltaQuaternion = new Quaternion(deltaVector.X, deltaVector.Y, deltaVector.Z, 0);

                Quaternion resultQuaternion = RotateCamera(radianInput, targetAxis, deltaQuaternion);
                
                subjectRotation = new Vector3(resultQuaternion.X, resultQuaternion.Y, resultQuaternion.Z);
                
                radianInput = 0;

                return subjectRotation;
               
            }
            else
            {

                return subjectRotation;

            }
            
            
        }

        /** 
        *   @brief This function updates the location of the camera. 
        *	@param direction the direction the camera is travelling
        *	@param cameraSpeed the velocity of the camera
        *	@param deltaTime the slice of time the game has elapsed
        *	@param fps the framerate
        *	@return subjectPosition the new camera position    
        *	@pre 
        *	@post subjectPosition will be updated
        */
        public void SubjectMove(InputHandler.keyStates direction, float cameraSpeed, float deltaTime, float fps)
        {
           
            subjectRotation.Normalize();

            if (direction == InputHandler.keyStates.ShieldToggle)
            {
                this.p1.SetShieldActiveToggle();
            }

            if (direction == InputHandler.keyStates.Forwards)
            {
               
                subjectPosition += cameraSpeed * subjectRotation * deltaTime * fps;
                
                Debug.WriteLine("position Vector: " + subjectPosition.X + " " + subjectPosition.Y + " " + subjectPosition.Z);
            }

            if (direction == InputHandler.keyStates.Backwards)
            {

                subjectPosition -= cameraSpeed * subjectRotation * deltaTime * fps;

                Debug.WriteLine("position Vector: " + subjectPosition.X + " " + subjectPosition.Y + " " + subjectPosition.Z);
            }

            if (direction == InputHandler.keyStates.Left)
            {
                Vector3 tempDeltaVector = Vector3.Cross(Vector3.Up, subjectRotation);
                tempDeltaVector.Normalize();
                //futurePosition += cameraSpeed * tempDeltaVector * deltaTime * fps;
                subjectPosition += cameraSpeed * tempDeltaVector * deltaTime * fps;
                
                Debug.WriteLine("position Vector: " + subjectPosition.X + " " + subjectPosition.Y + " " + subjectPosition.Z);
            }

            if (direction == InputHandler.keyStates.Right)
            {
                Vector3 tempDeltaVector = Vector3.Cross(Vector3.Up, subjectRotation);
                tempDeltaVector.Normalize();
                //futurePosition -= cameraSpeed * tempDeltaVector * deltaTime * fps;
                subjectPosition -= cameraSpeed * tempDeltaVector * deltaTime * fps;
               
                Debug.WriteLine("position Vector: " + subjectPosition.X + " " + subjectPosition.Y + " " + subjectPosition.Z);
            }

            

            // calculates the new camera bounding box
            this.maxPoint = this.subjectPosition + this.AABBOffset;
            this.minPoint = this.subjectPosition - this.AABBOffset;
        }

        


        /** 
        *   @brief This function implements the quaternion rotation. qpq'
        *   @see http://in2gpu.com/2016/03/14/opengl-fps-camera-quaternion/
        *	@param inputAngle the angle to rotate on 
        *	@param inputAxis the axis to rotate on 
        *	@param pQuat the starting position
        *	@param 
        *	@return resultQuat the final position of the rotation   
        *	@pre 
        *	@post 
        */
        private Quaternion RotateCamera(float inputAngle, Vector3 inputAxis, Quaternion pQuat)
        {
            
            Quaternion qQuat = AxisAngle(inputAngle, inputAxis);
            
            Quaternion pqQuat = Quaternion.Multiply(qQuat, pQuat);
            
            Quaternion resultQuat =  Quaternion.Multiply(pqQuat, Quaternion.Inverse(qQuat));
            
            deltaQuaternion = resultQuat;

            return resultQuat;
        }

        /** 
        *   @brief This function creates a quaternion from an angle and axis
        *   @see
        *	@param theTheta the angle in radians
        *	@param inputAxis the axis to rotate on 
        *	@param 
        *	@param 
        *	@return rotationQuat the quaternion calculated from axis and angle
        *	@pre 
        *	@post 
        */
        private Quaternion AxisAngle(float theTheta, Vector3 inputAxis)
        {
            Quaternion rotationQuart;
            double sinTheta;

            // Normalise rotation axis to have unit length
            inputAxis.Normalize();
           
            sinTheta = Math.Sin(theTheta / 2);
            
            // Convert to rotation quaternion
            rotationQuart.X = (float)(inputAxis.X * sinTheta);  // theTheta should be in radians
            rotationQuart.Y = (float)(inputAxis.Y * sinTheta);
            rotationQuart.Z = (float)(inputAxis.Z * sinTheta);
            rotationQuart.W = (float)(Math.Cos(theTheta / 2));
            
            return rotationQuart;
        }


        /** 
        *   @brief This function creates a ground plane
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return tempVector the ground position
        *	@pre 
        *	@post 
        */
        private Vector3 FloorCheck()
        {
            if(subjectPosition.Y <= 1)
            {
                Vector3 tempVector = new Vector3(subjectPosition.X, 1, subjectPosition.Z);

                return tempVector;
            }
            else
            {
                return subjectPosition;
            }
        }

        /** 
        *   @brief This function creates a roof plane
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return tempVector the roof position
        *	@pre 
        *	@post 
        */
        private Vector3 RoofCheck()
        {
            if(subjectPosition.Y >= 10000)
            {
                Vector3 tempVector = new Vector3(subjectPosition.X, 10000, subjectPosition.Z);
                return tempVector;
            }
            else
            {
                return subjectPosition;
            }
        }

        /** 
        *   @brief This function creates a front plane
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return tempVector the front position
        *	@pre 
        *	@post 
        */
        private Vector3 FrontCheck()
        {
            if (subjectPosition.Z >= 10000)
            {
                Vector3 tempVector = new Vector3(subjectPosition.X, subjectPosition.Y, 10000);

                return tempVector;
            }
            else
            {
                return subjectPosition;
            }
        }

        /** 
        *   @brief This function creates a back plane
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return tempVector the back position
        *	@pre 
        *	@post 
        */
        private Vector3 BackCheck()
        {
            if (subjectPosition.Z <= -10000)
            {
                Vector3 tempVector = new Vector3(subjectPosition.X, subjectPosition.Y, -10000);

                return tempVector;
            }
            else
            {
                return subjectPosition;
            }
        }

        /** 
        *   @brief This function creates a left plane
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return tempVector the left position
        *	@pre 
        *	@post 
        */
        private Vector3 LeftCheck()
        {
            if (subjectPosition.X >= 10000)
            {
                Vector3 tempVector = new Vector3(10000, subjectPosition.Y, subjectPosition.Z);

                return tempVector;
            }
            else
            {
                return subjectPosition;
            }
        }

        /** 
        *   @brief This function creates a right plane
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return tempVector the right position
        *	@pre 
        *	@post 
        */
        private Vector3 RightCheck()
        {
            if (subjectPosition.X <= -10000)
            {
                Vector3 tempVector = new Vector3(-10000, subjectPosition.Y, subjectPosition.Z);

                return tempVector;
            }
            else
            {
                return subjectPosition;
            }
        }

        /** 
        *   @brief accessor to the active codex list
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return codexHash the dictionary contained in the codexHash class
        *	@pre 
        *	@post 
        */
        public Dictionary<InputHandler.keyStates, String> GetCodexHash()
        {
            return this.codexHash.GetCodexDictionary();
        }

        /** 
        *   @brief accessor to the end game state
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return selenoAcquired the end game state
        *	@pre 
        *	@post 
        */
        public bool SelenoAquired()
        {
            return selenoAquired;
        }

        /** 
        *   @brief accessor to the message state
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return selenoAcquired the end game state
        *	@pre 
        *	@post 
        */
        public bool GetMessageState()
        {
            return msgState;
        }
    }
}
