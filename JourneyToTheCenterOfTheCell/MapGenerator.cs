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
        private int sizeZ = 0;
        private int sizeY = 0;
        private Map[,,] gridMap;

        /**
	    *	@brief parameterised constructor for the MapGenerator object. Create a complete MapGenerator object.
	    *	@param inputX grid size
        *	@param inputZ grid size
	    *	@return 
	    *	@pre 
	    *	@post MapGenerator will exist
	    */
        public MapGenerator(int inputX,int inputY, int inputZ)
        {
            sizeX = inputX;
            sizeY = inputY;
            sizeZ = inputZ;
            
            gridMap = new Map[sizeX,sizeY, sizeZ];
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
        public void SetMap()
        {


            // sets the initial "block consisting of building and adjacent road
            for(int ii = 0; ii < sizeX; ii++)
            {
                for(int jj = 0; jj < sizeY; jj++)
                {
                    for(int ee = 0; ee < sizeZ; ee++ )
                    { 
                        if (ii % 2 == 1 && jj % 2 == 1)
                        {
                            string modelPath = "Models/Cube";
                            string texturePath = "Textures/skybox_diffuse";
                            Vector3 Rotation = new Vector3(0, 0, 0);
                            Map tempBlock = new Map(ii, jj, ee, Map.buildType.Building, modelPath, texturePath, 1f, Rotation);
                            gridMap[ii, jj,ee] = tempBlock;


                            if ((ii - 1) >= 0)
                            {
                                string modelFile = "Models/Cubic";
                                string textureFile = "Textures/skybox_diffuse";
                                Vector3 Rotation2 = new Vector3(0, 0, 0);
                                Map roadWest = new Map(ii - 1, jj, ee, Map.buildType.RoadVertical, modelFile, textureFile, 1f, Rotation2);
                                gridMap[ii - 1, jj,ee] = roadWest;
                            }

                            if ((jj - 1) >= 0)
                            {
                                string modelFile = "Cube";
                                string textureFile = "Textures/skybox_diffuse";
                                Vector3 Rotation3 = new Vector3(0, 90, 00);
                                Map roadNorth = new Map(ii, jj, ee - 1, Map.buildType.RoadHorizontal, modelFile, textureFile, 1f, Rotation3);
                                gridMap[ii, jj - 1,ee] = roadNorth;
                            }

                            if ((ii + 1) < sizeX)
                            {
                                string modelFile = "Models/Cubix";
                                string textureFile = "Textures/skybox_diffuse";
                                Vector3 Rotation4 = new Vector3(0, 0, 0);
                                Map roadEast = new Map(ii + 1, jj, ee, Map.buildType.RoadVertical, modelFile, textureFile, 1f, Rotation4);
                                gridMap[ii + 1, jj,ee] = roadEast;
                            }

                            if ((jj + 1) < sizeZ)
                            {
                                string modelFile = "Models/Cube";
                                string textureFile = "Textures/skybox_diffuse";
                                Vector3 Rotation5 = new Vector3(0, 90, 00);
                                Map roadSouth = new Map(ii, jj, ee + 1, Map.buildType.RoadHorizontal, modelFile, textureFile, 1f, Rotation5);
                                gridMap[ii, jj + 1,ee] = roadSouth;
                            }
                        } 
                    }
                }
            }

            // searches for empty grid spaces and populates it with a suitable asset
           /* for (int ii = 0; ii < sizeX; ii++)
            {
                for (int jj = 0; jj < sizeZ; jj++)
                {
                    if (gridMap[ii, jj] == null)
                    {
                        int junctions = FindNeighbours(ii, jj, gridMap);

                        Debug.WriteLine("Junctions: " + junctions);

                        if (junctions == 2)
                        {
                            string modelFile = "Models/city_road_03";
                            string textureFile = "Maya/sourceimages/city_road_03_dif";
                            Vector3 cornerRotation = new Vector3(0, 0, 0);
                            gridMap[ii, jj] = new Map(ii, 0, jj, Map.buildType.RoadCorner, modelFile, textureFile, 1f, cornerRotation);
                        }
                        else if(junctions == 3)
                        {
                            string modelFile = "Models/city_road_03";
                            string textureFile = "Maya/sourceimages/city_road_03_dif";
                            Vector3 TRotation = new Vector3(0, 0, 0);
                            gridMap[ii, jj] = new Map(ii, 0, jj, Map.buildType.RoadT, modelFile, textureFile, 1f, TRotation);
                        }
                        else
                        {
                            string modelFile = "Models/city_road_03";
                            string textureFile = "Maya/sourceimages/city_road_03_dif";
                            Vector3 crossRotation = new Vector3(0, 0, 0);
                            gridMap[ii, jj] = new Map(ii, 0, jj, Map.buildType.RoadCross, modelFile, textureFile, 1f, crossRotation);
                        }
                    }
                }
            }*/
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
/*
        private int FindNeighbours(int gridX, int gridY, Map[,] inputGrid)
        {
            int junction = 0;

            if((gridX - 1) >= 0)
            {
                if (inputGrid[gridX - 1, gridY].GetBlockType() == Map.buildType.RoadHorizontal)
                {
                    junction += 1;
                }
            }
            
            if((gridY - 1) >= 0)
            {
                if (inputGrid[gridX, gridY - 1].GetBlockType() == Map.buildType.RoadVertical)
                {
                    junction += 1;
                }
            }

            if((gridX + 1) < sizeX)
            {
                if(inputGrid[gridX + 1, gridY].GetBlockType() == Map.buildType.RoadHorizontal)
                {
                    junction += 1;
                }
            }
            
            if((gridY + 1) < sizeZ)
            {
                if (inputGrid[gridX, gridY + 1].GetBlockType() == Map.buildType.RoadVertical)
                {
                    junction += 1;
                }
            }
            
            return junction;
           
        }
*/
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
        public void SetCoords()
        {
            for(int ii = 0; ii < sizeX; ii++)
            {
                for(int jj = 0; jj < sizeY; jj++)
                {
                    for(int ee = 0; ee< sizeZ; ee++)
                    { 
                        int tempX = gridMap[ii, jj, ee].GetPositionX() * 22;
                        int tempY = gridMap[ii, jj, ee].GetPositionY() * 22;
                        int tempZ = gridMap[ii, jj, ee].GetPositionZ() * 22;

                        gridMap[ii, jj, ee].SetCoordX(tempX);
                        gridMap[ii, jj, ee].SetCoordY(tempY);
                        gridMap[ii, jj, ee].SetCoordZ(tempZ);
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
        public Map[,,] GetGridMap()
        {
            return gridMap;
        }
        
        // output function for debugging
        public void PrintGrid()
        {
            for(int ii = 0; ii < sizeX; ii++)
            {
                for(int jj = 0; jj < sizeY; jj++)
                {
                    for(int ee = 0; ee< sizeZ; ee++)
                    { 
                        Debug.Write(gridMap[jj, ii,ee].GetBlockType() + " ");
                    }
                }

                Debug.Write("\n");
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
                for (int jj = 0; jj < sizeY; jj++)
                {
                    for (int ee = 0; ee < sizeZ; ee++)
                    {
                        Debug.WriteLine("Coord X: " + gridMap[ii, jj, ee].GetCoordX() + " Y: " + gridMap[ii, jj, ee].GetCoordY() + " Z: " + gridMap[ii, jj, ee].GetCoordZ());
                    }
                }
            }
        }



    }

    
}
