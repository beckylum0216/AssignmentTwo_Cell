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
        private List<Vector3> randomList;
        int itemSize;

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
            randomList = new List<Vector3>();
            itemSize = 200;
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
            for(int ii = 0; ii < 100; ii += 1)
            {
                int randomX = randomNum.Next(100);
                int randomY = randomNum.Next(100);
                int randomZ = randomNum.Next(100);

                Vector3 newPosition = new Vector3(randomX, randomY, randomZ);
                randomList.Add(newPosition);
            }

            for(int aa = 0; aa < 100; aa += 1)
            {
                for (int ii = 0; ii < this.sizeX; ii += 1)
                {
                    for (int jj = 0; jj < this.sizeZ; jj += 1)
                    {
                        if((ii == randomList[aa].X) && (jj == randomList[aa].Z))
                        {
                            string modelPath = "Models/Fireninja_blueninja";
                            string texturePath = "Textures/Skin1";
                            float mapScale = 1.0f;
                            Vector3 buildingRotation = new Vector3(0, 0, 0);
                            int modelLevel = 1;
                            Map tempMap = new Map(randomList[aa], Map.buildType.Building, modelPath, texturePath, mapScale, buildingRotation, InputHandler.keyStates.NULL, modelLevel);
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

            // sets the initial "Map consisting of building and adjacent road
            Random randomNum = new Random();
            List<Vector3> randomItemList = new List<Vector3>();
            for (int ii = 0; ii < itemSize; ii += 1)
            {
                int randomX = randomNum.Next(10);
                int randomY = randomNum.Next(10);
                int randomZ = randomNum.Next(10);

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
                            int randomItem = randomNum.Next(9);

                            string modelPath = "Models/city_residential_03";
                            string texturePath = "Textures/city_residential_03_dif";
                            float mapScale = 1.0f;
                            Vector3 buildingRotation = new Vector3(0, 0, 0);
                            int modelLevel = 1;
                            Map tempMap = new Map(randomItemList[aa], Map.buildType.Building, modelPath, texturePath, mapScale, buildingRotation, FindCodexType(randomItem), modelLevel);
                            itemMap[ii, jj] = tempMap;
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

        private InputHandler.keyStates FindCodexType(int inputRandom)
        {
            InputHandler.keyStates codexType = InputHandler.keyStates.NULL;

            switch (inputRandom)
            {
                case 0:
                    codexType = InputHandler.keyStates.Cell;
                    break;
                case 1:
                    codexType = InputHandler.keyStates.Nucleus;
                    break;
                case 2:
                    codexType = InputHandler.keyStates.ER;
                    break;
                case 3:
                    codexType = InputHandler.keyStates.Lysosome;
                    break;
                case 4:
                    codexType = InputHandler.keyStates.Peroxisome;
                    break;
                case 5:
                    codexType = InputHandler.keyStates.Golgi;
                    break;
                case 6:
                    codexType = InputHandler.keyStates.Mitochondria;
                    break;
                case 7:
                    codexType = InputHandler.keyStates.Cytoskeleton;
                    break;
                case 8:
                    codexType = InputHandler.keyStates.Selenocysteine;
                    break;
            }

            return codexType;        
           
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
            for(int aa = 0; aa < 100; aa += 1)
            {
                for (int ii = 0; ii < sizeX; ii++)
                {
                    for (int jj = 0; jj < sizeZ; jj++)
                    {
                        if ((ii == randomList[aa].X) && (jj == randomList[aa].Z))
                        {
                            float tempX = gridMap[ii, jj].GetPositionMap().X * 22;
                            float tempY = gridMap[ii, jj].GetPositionMap().Y * 22;
                            float tempZ = gridMap[ii, jj].GetPositionMap().Z * 22;

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

        // output function for debugging
        public void PrintGrid()
        {
            for(int aa = 0; aa < 100; aa += 1)
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
            for(int aa = 0; aa < 100; aa += 1)
            {
                for (int ii = 0; ii < sizeX; ii++)
                {
                    for (int jj = 0; jj < sizeZ; jj++)
                    {
                        if ((ii == randomList[aa].X) && (jj == randomList[aa].Z))
                        {
                            Debug.WriteLine("Coord X: " + gridMap[ii, jj].GetCoordX() + " Y: " + gridMap[ii, jj].GetCoordY() + " Z: " + gridMap[ii, jj].GetCoordZ());
                        }

                    }
                }
            }
            
        }



    }

    
}
