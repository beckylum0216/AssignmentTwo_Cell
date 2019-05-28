using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    /// <summary>base clase for map generation smallest unit is a "Map"</summary> 

    public class Map
    {

        //the abstracted grid position
        private int positionX; // oopsie
        private int positionY; // oopsie
        private int positionZ; // oopsie
        private Vector3 positionMap;
        private float coordX;
        private float coordY;
        private float coordZ;
        private float blockScale;
        private Vector3 blockRotation;
        private InputHandler.keyStates codexType;

        // enum of building types
        public enum buildType {NullMap, RoadHorizontal, RoadVertical, RoadCorner, Building, RoadT, RoadCross, SkyBox};
        private InputHandler.keyStates blockType;
        private String modelPath;
        private String texturePath;

        private int modelLevel;

        /**
	    *	@brief default constructor to the block object
	    *	@param 
	    *	@return 
	    *	@pre 
	    *	@post Map will exist
	    */
        public Map()
        {
            this.positionMap = new Vector3();
            this.blockType = InputHandler.keyStates.NULL;
        }

        /**
	    *	@brief parameterised constructor to the block object. Creates a complete block object.
	    *	@param 
	    *	@return 
	    *	@pre 
	    *	@post Map will exist
	    */
        public Map(Vector3 gridPosition, InputHandler.keyStates gridType, string modelFile, 
                        string textureFile, float gridScale, Vector3 gridRotation, 
                        InputHandler.keyStates codexInput, int inputLevel)
        {
            this.positionMap = gridPosition;
            this.blockType = gridType;
            this.modelPath = modelFile;
            this.texturePath = textureFile;
            this.blockScale = gridScale;
            this.blockRotation = gridRotation;
            this.codexType = codexInput;
            this.modelLevel = inputLevel;
        }

        /** 
        *   @brief mutator to the map position
        *   @see
        *	@param inputPosition the position of the map item
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetPositionMap(Vector3 inputPosition)
        {
            this.positionMap = inputPosition;
        }

        /** 
        *   @brief accessor to the map position
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return positionMap the position of the map item
        *	@pre 
        *	@post 
        */
        public Vector3 GetPositionMap()
        {
            return this.positionMap;
        }

        /// <summary> Mutator to the abstracted grid position.</summary>
        /// <param> inputX grid position to be assigned</param> 
        /// <return></return>        
        /// <pre></pre> 
        /// <post> grid position will exist </post> 
        public void SetPositionX(int inputX)
        {
            this.positionX = inputX;
        }


        /**
	    *	@brief accessor to abstract block position
	    *	@param 
	    *	@return positionX the abstract grid position
	    *	@pre grid position must exist
	    *	@post 
	    */
        public int GetPositionX()
        {
            return positionX;
        }


        /**
        * @brief Mutator to the abstracted grid position.
        * @param inputY grid position to be assigned
        * @return 
        * @pre 
        * @post grid position will exist
        */
        public void SetPositionY(int inputY)
        {
            this.positionY = inputY;
        }

        /**
         *	@brief accessor to abstract block position
         *	@param 
         *	@return positionY the abstract grid position
         *	@pre grid position must exist
         *	@post 
         */
        public int GetPositionY()
        {
            return this.positionY;
        }

        /**
        * @brief Mutator to the abstracted grid position.
        * @param inputZ grid position to be assigned
        * @return 
        * @pre 
        * @post grid position will exist
        */
        public void SetPositionZ(int inputZ)
        {
            this.positionZ = inputZ;
        }

        /**
        *	@brief accessor to abstract block position
        *	@param 
        *	@return positionZ the abstract grid position
        *	@pre grid position must exist
        *	@post 
        */
        public int GetPositionZ()
        {
            return this.positionZ;
        }

        /**
        * @brief Mutator to the block type.
        * @param intputType type of block
        * @return 
        * @pre 
        * @post block type will exist
        */
        public void SetMapType(InputHandler.keyStates inputType)
        {
            this.blockType = inputType;
        }

        /**
        *	@brief accessor to the block type
        *	@param 
        *	@return blockType the type of block
        *	@pre block type must exist
        *	@post 
        */
        public InputHandler.keyStates GetMapType()
        {
            return this.blockType;
        }

        /**
        *	@brief mutator to literal block position
        *	@param 
        *	@return positionX the literal grid position
        *	@pre grid position does not exist
        *	@post grid position will exist
        */
        public void SetCoordX(float inputX)
        {
            this.coordX = inputX;
        }

        /**
        *	@brief accessor to the literal block position
        *	@param 
        *	@return coordX the literal positon in game world
        *	@pre does not exist
        *	@post will exist
        */
        public float GetCoordX()
        {
            return this.coordX;
        }

        /**
        *	@brief mutator to literal block position
        *	@param 
        *	@return positionY the literal grid position
        *	@pre grid position does not exist
        *	@post grid position will exist
        */
        public void SetCoordY(float inputY)
        {
            this.coordY = inputY;
        }

        /**
        *	@brief accessor to the literal block position
        *	@param 
        *	@return coordY the literal positon in game world
        *	@pre does not exist
        *	@post will exist
        */
        public float GetCoordY()
        {
            return this.coordY;
        }

        /**
        *	@brief mutator to literal block position
        *	@param 
        *	@return positionZ the literal grid position
        *	@pre grid position does not exist
        *	@post grid position will exist
        */
        public void SetCoordZ(float inputZ)
        {
            this.coordZ = inputZ;
        }

        /**
        *	@brief accessor to the literal block position
        *	@param 
        *	@return coordZ the literal positon in game world
        *	@pre does not exist
        *	@post will exist
        */
        public float GetCoordZ()
        {
            return this.coordZ;
        }

        /**
        *	@brief mutator to the path of the model asset
        *	@param modelFile the path
        *	@return void
        *	@pre path does not exist
        *	@post path will exist
        */
        public void SetModelPath(string modelFile)
        {
            this.modelPath = modelFile;
        }

        /**
        *	@brief accessor to the model path
        *	@param 
        *	@return modelPath
        *	@pre must exist
        *	@post 
        */
        public string GetModelPath()
        {
            return this.modelPath;
        }

        /**
        *	@brief mutator to the path of the texture asset
        *	@param textureFile the path
        *	@return void
        *	@pre path does not exist
        *	@post path will exist
        */
        public void SetTexturePath(string textureFile)
        {
            this.texturePath = textureFile;
        }

        /**
        *	@brief accessor to the texture path
        *	@param 
        *	@return texturePath
        *	@pre must exist
        *	@post 
        */
        public string GetTexturePath()
        {
            return this.texturePath;
        }

        /**
        *	@brief mutator to the scale of the asset
        *	@param gridScale specifies the scale in units? to size the asset
        *	@return void
        *	@pre scale does not exist
        *	@post scale will exist
        */
        public void SetMapScale(float gridScale)
        {
            this.blockScale = gridScale;
        }

        /**
        *	@brief accessor to the scale
        *	@param 
        *	@return blockScale the size which the asset being scaled to 
        *	@pre must exist
        *	@post 
        */
        public float GetMapScale()
        {
            return this.blockScale;
        }

        /**
        *	@brief mutator to the initial rotation of the asset
        *	@param gridRotation specifies the rotation in vectors 
        *	@return void
        *	@pre scale does not exist
        *	@post scale will exist
        */
        public void SetMapRotation(Vector3 gridRotation)
        {
            this.blockRotation = gridRotation;
        }

        
        /** 
         *  @brief accessor to the rotation
         *	@param
         *	@return blockRotation the rotation which the asset being rotated to 
         *	@pre must exist
         *	@post
         */
        public Vector3 GetMapRotation()
        {
            return this.blockRotation;
        }


        /** 
         *  @brief mutator to the codexType
         *	@param inputCodexType codexType to be assigned 
         *	@return 
         *	@pre 
         *	@post
         */
        public void SetCodexType(InputHandler.keyStates inputCodexType)
        {
            this.codexType = inputCodexType;
        }

        /** 
         *  @brief accessor to the codexType
         *	@param
         *	@return codexType assigned 
         *	@pre must exist
         *	@post
         */
        public InputHandler.keyStates GetCodexType()
        {
            return this.codexType;
        }
    }
}
