using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace JourneyToTheCenterOfTheCell
{
    class MapGenerator
    {
        private int sizeX = 0;
        private int sizeY = 0;
        private int sizeZ = 0;
        private Map[,] gridMap;
        private Map[,] itemMap;
        private Map[,] npcMap;
        private List<Vector3> randomList;
        int structureCount;
        int itemSize;
        int structureSize;
        int npcSize;

        /**
	    *	@brief parameterised constructor for the MapGenerator object. Create a complete MapGenerator object.
	    *	@param inputX grid size
        *	@param inputZ grid size
	    *	@return 
	    *	@pre 
	    *	@post MapGenerator will exist
	    */
        public MapGenerator(int inputX, int inputY, int inputZ)
        {
            sizeX = inputX;
            sizeY = inputY;
            sizeZ = inputZ;
            gridMap = new Map[sizeX, sizeZ];
            itemMap = new Map[sizeX, sizeZ];
            npcMap = new Map[sizeX, sizeZ];
            randomList = new List<Vector3>();
            structureCount = 50;
            structureSize = 200;
            itemSize = 200;
            npcSize = 200;
        }

        /** 
        *   @brief generates the map based on a typical chequerboard pattern
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
        public void SetStructureMap()
        {

            // sets the initial "Map consisting of building and adjacent road
            Random randomNum = new Random();
            for(int ii = 0; ii < structureSize; ii += 1)
            {
                int randomX = randomNum.Next(structureSize);
                int randomY = randomNum.Next(structureSize);
                int randomZ = randomNum.Next(structureSize);

                Vector3 newPosition = new Vector3(randomX, randomY, randomZ);
                randomList.Add(newPosition);
            }

            // number of times a structure appears
            for(int aa = 0; aa < structureCount; aa += 1)
            {
                for (int ii = 0; ii < this.sizeX; ii += 1)
                {
                    for (int jj = 0; jj < this.sizeZ; jj += 1)
                    {
                        if((ii == randomList[aa].X) && (jj == randomList[aa].Z))
                        {
                            string modelPath = "Models/golgi";
                            string texturePath = "Textures/golgi_diff";
                            float mapScale = 10.0f;
                            Vector3 buildingRotation = new Vector3(0, 0, 0);
                            int modelLevel = 1;
                            Map tempMap = new Map(randomList[aa], InputHandler.keyStates.Golgi, modelPath, texturePath, mapScale, buildingRotation, InputHandler.keyStates.Golgi, modelLevel);
                            gridMap[ii, jj] = tempMap;
                        }
                    }
                }
            }
            
        }

        /** 
        *   @brief randomly places items in a 3d space
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
        public void SetItemMap()
        {

            
            Random randomNum = new Random();
            List<Vector3> randomItemList = new List<Vector3>();
            for (int ii = 0; ii < itemSize; ii += 1)
            {
                int randomX = randomNum.Next(itemSize);
                int randomY = randomNum.Next(itemSize);
                int randomZ = randomNum.Next(itemSize);

                Vector3 newPosition = new Vector3(randomX, randomY, randomZ);
                randomItemList.Add(newPosition);
            }

            for (int aa = 0; aa < itemSize; aa += 1)
            {
                for (int ii = 0; ii < this.sizeX; ii += 1)
                {
                    for (int jj = 0; jj < this.sizeZ; jj += 1)
                    {
                        if ((ii == randomItemList[aa].X) && (jj == randomItemList[aa].Z))
                        {
                            //int randomItem = randomNum.Next(5);

                            string modelPath = "Models/mitochondria";
                            string texturePath = "Textures/Mitochondrion_diff";
                            float mapScale = 11f;
                            Vector3 buildingRotation = new Vector3(0, 0, 0);
                            int modelLevel = 1;
                            Map tempMap = new Map(randomItemList[aa], InputHandler.keyStates.Mitochondria, modelPath, texturePath, mapScale, buildingRotation, InputHandler.keyStates.Mitochondria, modelLevel);
                            itemMap[ii, jj] = tempMap;
                        }
                    }
                }
            }

        }

        /** 
        *   @brief randomly places items in a 3d space
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
        public void SetNPCMapLevel1()
        {

            // sets the initial "Map consisting of building and adjacent road
            Random randomNum = new Random();
            List<Vector3> randomItemList = new List<Vector3>();
            for (int ii = 0; ii <npcSize; ii += 1)
            {
                int randomX = randomNum.Next(itemSize);
                int randomY = randomNum.Next(itemSize);
                int randomZ = randomNum.Next(itemSize);

                Vector3 newPosition = new Vector3(randomX, randomY, randomZ);
                randomItemList.Add(newPosition);
            }

            for (int aa = 0; aa < npcSize; aa += 1)
            {
                for (int ii = 0; ii < this.sizeX; ii += 1)
                {
                    for (int jj = 0; jj < this.sizeZ; jj += 1)
                    {
                        if ((ii == randomItemList[aa].X) && (jj == randomItemList[aa].Z))
                        {
                            int randomItem = randomNum.Next(2);

                            string modelPath = FindModelTypeLevel1(randomItem);
                            //string texturePath = "Textures/Lysosome_AlbedoTransparency";
                            string texturePath = null;
                            float mapScale = 11.0f;
                            Vector3 buildingRotation = new Vector3(0, 0, 0);
                            int modelLevel = 0;
                            InputHandler.keyStates modelType = FindCodexTypeLevel1(randomItem);
                            Map tempMap = new Map(randomItemList[aa], modelType, modelPath, texturePath, mapScale, buildingRotation, FindCodexTypeLevel1(randomItem), modelLevel);
                            npcMap[ii, jj] = tempMap;
                        }
                    }
                }
            }

        }

        /** 
        *   @brief randomly places items in a 3d space
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
        public void SetNPCMapLevel2()
        {

            // sets the initial "Map consisting of building and adjacent road
            Random randomNum = new Random();
            List<Vector3> randomItemList = new List<Vector3>();
            for (int ii = 0; ii < npcSize; ii += 1)
            {
                int randomX = randomNum.Next(itemSize);
                int randomY = randomNum.Next(itemSize);
                int randomZ = randomNum.Next(itemSize);

                Vector3 newPosition = new Vector3(randomX, randomY, randomZ);
                randomItemList.Add(newPosition);
            }

            for (int aa = 0; aa < npcSize; aa += 1)
            {
                for (int ii = 0; ii < this.sizeX; ii += 1)
                {
                    for (int jj = 0; jj < this.sizeZ; jj += 1)
                    {
                        if ((ii == randomItemList[aa].X) && (jj == randomItemList[aa].Z))
                        {
                            int randomItem = randomNum.Next(2);

                            string modelPath = FindNPCModelTypeLevel2(randomItem);
                            string texturePath = FindNPCTextureTypeLevel2(randomItem);
                            float mapScale = 11.0f;
                            Vector3 buildingRotation = new Vector3(0, 0, 0);
                            int modelLevel = 1;
                            InputHandler.keyStates modelType = FindNPCCodexTypeLevel2(randomItem);
                            //Debug.WriteLine("npc type: " + modelType);
                            Map tempMap = new Map(randomItemList[aa], modelType, modelPath, texturePath, mapScale, buildingRotation, FindNPCCodexTypeLevel2(randomItem), modelLevel);
                            npcMap[ii, jj] = tempMap;
                        }
                    }
                }
            }

        }


        /** 
        *   @brief this functions helps the program to find the right junction for each empty space.
        *   @brief does not take into account orientation
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return junction the number of junctions
        *	@pre 
        *	@post 
        */
        private InputHandler.keyStates FindCodexTypeLevel1(int inputRandom)
        {
            InputHandler.keyStates codexType = InputHandler.keyStates.NULL;

            switch (inputRandom)
            {
                //case 0:
                //    codexType = InputHandler.keyStates.Cell;
                //    break;
                case 0:
                    codexType = InputHandler.keyStates.RedBlood;
                    break;
                case 1:
                    codexType = InputHandler.keyStates.WhiteBlood;
                    break;
                
            }

            return codexType;

        }

        /** 
        *   @brief this functions helps the program to find the right junction for each empty space.
        *   @brief does not take into account orientation
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return junction the number of junctions
        *	@pre 
        *	@post 
        */
        private string FindModelTypeLevel1(int inputRandom)
        {
            string modelType = null;

            switch (inputRandom)
            {
                //case 0:
                //    modelType = "Models/cell_obj";
                //    break;
                case 0:
                    modelType = "Models/Red blood cell";
                    break;
                case 1:
                    modelType = "Models/human cell";
                    break;
                
            }

            return modelType;

        }

        /** 
        *   @brief this functions helps the program to find the right junction for each empty space.
        *   @brief does not take into account orientation
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return junction the number of junctions
        *	@pre 
        *	@post 
        */
        private InputHandler.keyStates FindNPCCodexTypeLevel2(int inputRandom)
        {
            InputHandler.keyStates codexType = InputHandler.keyStates.NULL;

            switch (inputRandom)
            {
                case 0:
                    codexType = InputHandler.keyStates.Lysosome;
                    break;
                case 1:
                    codexType = InputHandler.keyStates.Peroxisome;
                    break;
                    
            }

            return codexType;

        }

        /** 
        *   @brief this functions helps the program to find the right junction for each empty space.
        *   @brief does not take into account orientation
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return junction the number of junctions
        *	@pre 
        *	@post 
        */
        private string FindNPCModelTypeLevel2(int inputRandom)
        {
            string modelType = null;

            switch (inputRandom)
            {
                case 0:
                    modelType = "Models/Lysosome";
                    break;
                case 1:
                    modelType = "Models/Ball_type00";
                    break;
                    
            }

            return modelType;

        }

        /** 
        *   @brief this functions helps the program to find the right junction for each empty space.
        *   @brief does not take into account orientation
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return junction the number of junctions
        *	@pre 
        *	@post 
        */

        private string FindNPCTextureTypeLevel2(int inputRandom)
        {
            string textureType = null;

            switch (inputRandom)
            {
                case 0:
                    textureType = "Textures/Lysosome_diff";
                    break;
                case 1:
                    textureType = "Textures/Balls_diff";
                    break;
                    
            }

            return textureType;

        }


        /** 
        *   @brief mutator to set the exact coordinates of the model assets
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
        public void SetStructureCoords()
        {
            for(int aa = 0; aa < structureCount; aa += 1)
            {
                for (int ii = 0; ii < sizeX; ii++)
                {
                    for (int jj = 0; jj < sizeZ; jj++)
                    {
                        if ((ii == randomList[aa].X) && (jj == randomList[aa].Z))
                        {
                            float tempX = gridMap[ii, jj].GetPositionMap().X * 20;
                            float tempY = gridMap[ii, jj].GetPositionMap().Y * 20;
                            float tempZ = gridMap[ii, jj].GetPositionMap().Z * 20;

                            gridMap[ii, jj].SetCoordX(tempX);
                            gridMap[ii, jj].SetCoordZ(tempZ);
                            gridMap[ii, jj].SetCoordY(tempY);

                        }

                    }
                }
            }
           
        }

        /** 
        *   @brief mutator to set the exact coordinates of the model assets
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
        public void SetItemCoords()
        {
            for (int aa = 0; aa < itemSize; aa += 1)
            {
                for (int ii = 0; ii < sizeX; ii++)
                {
                    for (int jj = 0; jj < sizeZ; jj++)
                    {
                        if (!(itemMap[ii, jj] == null))
                        {
                            float tempX = itemMap[ii, jj].GetPositionMap().X * 20;
                            float tempY = itemMap[ii, jj].GetPositionMap().Y * 20;
                            float tempZ = itemMap[ii, jj].GetPositionMap().Z * 20;

                            itemMap[ii, jj].SetCoordX(tempX);
                            itemMap[ii, jj].SetCoordZ(tempZ);
                            itemMap[ii, jj].SetCoordY(tempY);

                        }

                    }
                }
            }

        }

        /** 
        *   @brief mutator to set the exact coordinates of the model assets
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
        public void SetNPCCoords()
        {
            for (int aa = 0; aa < npcSize; aa += 1)
            {
                for (int ii = 0; ii < sizeX; ii++)
                {
                    for (int jj = 0; jj < sizeZ; jj++)
                    {
                        if (!(npcMap[ii, jj] == null))
                        {
                            float tempX = npcMap[ii, jj].GetPositionMap().X * 20;
                            float tempY = npcMap[ii, jj].GetPositionMap().Y * 20;
                            float tempZ = npcMap[ii, jj].GetPositionMap().Z * 20;

                            npcMap[ii, jj].SetCoordX(tempX);
                            npcMap[ii, jj].SetCoordZ(tempZ);
                            npcMap[ii, jj].SetCoordY(tempY);

                        }

                    }
                }
            }

        }

        /** 
        *   @brief accessor to the exact coordinates of the model assets
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
        public Map[,] GetGridMap()
        {
            return gridMap;
        }

        /** 
        *   @brief accessor to the exact coordinates of the model assets
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
        public Map[,] GetItemMap()
        {
            return itemMap;
        }

        /** 
        *   @brief accessor to the exact coordinates of the model assets
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
        public Map[,] GetNPCMap()
        {
            return npcMap;
        }

        // output function for debugging
        public void PrintGrid()
        {
            for(int aa = 0; aa < structureCount; aa += 1)
            {
                for (int ii = 0; ii < sizeX; ii++)
                {
                    for (int jj = 0; jj < sizeZ; jj++)
                    {
                        if ((ii == randomList[aa].X) && (jj == randomList[aa].Z))
                        {
                            Debug.Write(gridMap[ii, jj].GetMapType() + " ");
                        }

                    }

                    Debug.Write("\n");
                }
            }
            
        }

        /** 
        *   @brief utility function to print out the coordinates of the grid for debugging
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
        public void PrintCoords()
        {
            
            for (int ii = 0; ii < sizeX; ii++)
            {
                for (int jj = 0; jj < sizeZ; jj++)
                {
                    if (!(gridMap[ii,jj] == null))
                    {
                        Debug.WriteLine("Coord X: " + gridMap[ii, jj].GetCoordX() + " Y: " + gridMap[ii, jj].GetCoordY() + " Z: " + gridMap[ii, jj].GetCoordZ());
                    }

                }
            }
            
            
        }

        /** 
        *   @brief utility function to print out the coordinates of the grid for debugging
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
        public void PrintNPCCoords()
        {
     
            for (int ii = 0; ii < sizeX; ii++)
            {
                for (int jj = 0; jj < sizeZ; jj++)
                {
                    if (!(npcMap[ii,jj] == null))
                    {
                        Debug.WriteLine("Coord X: " + npcMap[ii, jj].GetCoordX() + " Y: " + npcMap[ii, jj].GetCoordY() + " Z: " + npcMap[ii, jj].GetCoordZ());
                    }

                }
            }
            

        }



    }
}
