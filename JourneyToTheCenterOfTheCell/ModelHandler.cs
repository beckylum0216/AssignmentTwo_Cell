﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace JourneyToTheCenterOfTheCell
{
    /// @author Rebecca Lim
    /// <summary>
    /// Class for the drawing and handling of map structures, items and NPCs
    /// </summary>
    public class ModelHandler
    {
        private List<Actor> itemList = new List<Actor>();
        private List <Actor> plotList = new List<Actor>();
        private Dictionary<int, Item> itemHash;
        private Dictionary<int, NPC> npcHash;
        private Dictionary<string, Actor> landPlots = new Dictionary<string, Actor>();
        private Map[,] npcMap;
        private Map[,] itemMap;
        private Map[,] gridMap;
        private MapGenerator mapCreate;
        private ContentManager Content;
        private int sizeX;
        private int sizeY;
        private int sizeZ;
        private float plotScale;
        private int gameLevel;



        /**
	    *	@brief parameterised constructor to the PlotClient object. Create a complete PlotClient object.
	    *	@param inputContent 
        *	@param inputX grid size
        *	@param inputY grid size
        *	@param inputScale initial scale of the Plots
	    *	@return 
	    *	@pre 
	    *	@post Camera will exist
	    */
        public ModelHandler(ContentManager inputContent,  int inputX, int inputY, int inputZ, float inputScale, int inputLevel)
        {
            this.gameLevel = inputLevel;
            Content = inputContent;
            sizeX = inputX;
            sizeY = inputY;
            sizeZ = inputZ;
            this.plotScale = inputScale;

            itemHash = new Dictionary<int, Item>();
            npcHash = new Dictionary<int, NPC>();

            // initialise map
            mapCreate = new MapGenerator(sizeX, sizeY, sizeZ);

            if(gameLevel ==  0)
            {
                mapCreate.SetNPCMapLevel1();
                mapCreate.SetNPCCoords();
                npcMap = mapCreate.GetNPCMap();
            }
            else 
            {
                mapCreate.SetStructureMap();

                //mapCreate.PrintGrid();
                mapCreate.SetStructureCoords();
                mapCreate.PrintCoords();

                mapCreate.SetItemMap();
                mapCreate.SetItemCoords();

                mapCreate.SetNPCMapLevel2();
                mapCreate.SetNPCCoords();
                //mapCreate.PrintNPCCoords();

                gridMap = mapCreate.GetGridMap();
                itemMap = mapCreate.GetItemMap();
                Debug.WriteLine("NPC map size: " + mapCreate.GetNPCMap().Length);
                npcMap = mapCreate.GetNPCMap();

            }
            

            
        }

        /** 
        *   @brief mutator to the landplot dictionary. adds plots to the dictionary
        *   @see
        *	@param plotName the key
        *	@param  plotObj the object
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void SetPlot(string plotName, Actor plotObj)
        {
            landPlots.Add(plotName, plotObj);
        }

        /** 
        *   @brief accessor to the landplot dictionary. 
        *   @see
        *	@param plotName the key
        *	@param  
        *	@param 
        *	@param 
        *	@return landPlots element based on key
        *	@pre 
        *	@post 
        */
        public Actor GetPlot(string plotName)
        {
            return landPlots[plotName];
        }

        /** 
        *   @brief accessor to the landplot dictionary. 
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return landPlot the whole dictionary
        *	@pre 
        *	@post 
        */
        public Dictionary<string, Actor> GetLandPlots()
        {
            return landPlots;
        }

        /** 
        *   @brief accessor to the plot list. 
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return plotList the whole list
        *	@pre 
        *	@post 
        */
        public List<Actor> GetPlotList()
        {
            return plotList;
        }

        /** 
        *   @brief accessor to the plot list. 
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return plotList the whole list
        *	@pre 
        *	@post 
        */
        public List<Actor> GetItemList()
        {
            return itemList;
        }

        /** 
        *   @brief accessor to the plot list. 
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return plotList the whole list
        *	@pre 
        *	@post 
        */
        public Dictionary<int, Item> GetItemHash()
        {
            return itemHash;
        }

        /** 
        *   @brief accessor to the plot list. 
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return plotList the whole list
        *	@pre 
        *	@post 
        */
        public Dictionary<int, NPC> GetNPCHash()
        {
            return npcHash;
        }


        /** 
        *   @brief mutator to the game level field
        *   @see
        *	@param inputLevel
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre game must exist
        *	@post 
        */
        public void SetGameLevel(int inputLevel)
        {
            this.gameLevel = inputLevel;
        }

        /** 
        *   @brief mutator to the game level field
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return gameLevel the level of the game
        *	@pre game must exist
        *	@post 
        */
        public int GetGameLevel()
        {
            return this.gameLevel;
        }

        /** 
        *   @brief function creates all the prototypes for the game. not used as  
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void SetPlotDictionary()
        {
            string modelFile = "Models/skybox_cube";
            string textureFile = "Textures/skybox_diffuse";
            float centerOrigin = (23 * 22) / 2;
            Vector3 positionSkyBox = new Vector3(centerOrigin, 0f, centerOrigin);
            Vector3 rotationSkyBox = new Vector3(0, 0, 0);
            Vector3 AABBOffset = new Vector3(0, 0, 0);
            float scaleSkyBox = 15f;
            SkyBox plotSkyBox = new SkyBox(Content, modelFile, textureFile, positionSkyBox, rotationSkyBox, scaleSkyBox, AABBOffset);
            landPlots.Add(Map.buildType.SkyBox.ToString(), plotSkyBox);

            
        }

        /** 
        *   @brief mutator to an arrayList data structure for drawing 
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return gameLevel the level of the game
        *	@pre game must exist
        *	@post 
        */
        public void SetPlotList()
        {
            if(gameLevel == 0)
            {
                string modelFile = "Models/manualskybox_obj";
                string textureFile = "Textures/blood_cubemap";
                // move the centre of the skybox to the centre of the "city"
                float centerOrigin = 1;
                Vector3 positionSkyBox = new Vector3(centerOrigin, 0f, centerOrigin);
                Vector3 rotationSkyBox = new Vector3(0, 0, 0);
                Vector3 AABBOffset = new Vector3(0, 0, 0);
                float scaleSkyBox = 2000f;
                //Actor plotSkyBox = landPlots["SkyBox"].ActorClone(Content, modelFile, textureFile, positionSkyBox, rotationSkyBox, scaleSkyBox, AABBOffset);
                SkyBox skyBoxObj = new SkyBox(Content, modelFile, textureFile, positionSkyBox, rotationSkyBox, scaleSkyBox, AABBOffset);
                plotList.Add(skyBoxObj);
            }
            else
            {
                string modelFile = "Models/manualskybox_obj";
                string textureFile = "Textures/aliencell_cubemap";
                // move the centre of the skybox to the centre of the "city"
                float centerOrigin = 1;
                Vector3 positionSkyBox = new Vector3(centerOrigin, 0f, centerOrigin);
                Vector3 rotationSkyBox = new Vector3(0, 0, 0);
                Vector3 AABBOffset = new Vector3(0, 0, 0);
                float scaleSkyBox = 2000f;
                //Actor plotSkyBox = landPlots["SkyBox"].ActorClone(Content, modelFile, textureFile, positionSkyBox, rotationSkyBox, scaleSkyBox, AABBOffset);
                SkyBox skyBoxObj = new SkyBox(Content, modelFile, textureFile, positionSkyBox, rotationSkyBox, scaleSkyBox, AABBOffset);
                plotList.Add(skyBoxObj);
            }


            if(gameLevel == 0)
            {
                string modelCell = "Models/cell_obj";
                string textureCell = "Textures/cell_diff";
                Vector3 positionCell = new Vector3(100, 100, 100) * 20;
                Vector3 rotationCell = new Vector3(0, 0, 0);
                float scaleCell = 100f;
                Vector3 AABBCell = new Vector3(2, 2, 2) * scaleCell;
                
                //Actor plotSkyBox = landPlots["SkyBox"].ActorClone(Content, modelFile, textureFile, positionSkyBox, rotationSkyBox, scaleSkyBox, AABBOffset);
                Structure cellObj = new Structure(Content, modelCell, textureCell, positionCell, rotationCell, scaleCell, AABBCell, InputHandler.keyStates.Cell);
                plotList.Add(cellObj);
            }
            

            if(gameLevel == 1)
            {
                Debug.WriteLine("list size:" + plotList.Count);

                string modelNucleus = "Models/nucleus";
                string textureNucleus = "Textures/nucleus_diff";
                Vector3 positionNucleus = new Vector3(200, 200, 200) * 20;
                Vector3 rotationNucleus = new Vector3(0, 0, 0);
                float scaleNucleus = 100f;
                Vector3 AABBNucleus = new Vector3(20, 20, 20) * scaleNucleus;
                Structure nucleusObj = new Structure(Content, modelNucleus, textureNucleus, positionNucleus, rotationNucleus, scaleNucleus, AABBNucleus, InputHandler.keyStates.Nucleus);
                plotList.Add(nucleusObj);

                string modelReticulum = "Models/Riticulum";
                string textureReticulum = "Textures/Riticulum_diff";
                Vector3 positionReticulum = new Vector3(200, 200, 200) * 20;
                Vector3 rotationReticulum = new Vector3(0, 0, 0);
                float scaleReticulum = 100f;
                Vector3 AABBReticulum = new Vector3(20, 20, 20) * scaleReticulum;
                Structure reticulumObj = new Structure(Content, modelReticulum, textureReticulum, positionReticulum, rotationReticulum, scaleReticulum, AABBReticulum, InputHandler.keyStates.ER);
                plotList.Add(reticulumObj);

                string modelGolgi = "Models/golgi";
                string textureGolgi = "Textures/golgi_diff";
                Vector3 positionGolgi = new Vector3(100, 200, 100) * 20;
                Vector3 rotationGolgi = new Vector3(0, 0, 0);
                float scaleGolgi = 100f;
                Vector3 AABBGolgi = new Vector3(10, 10, 10) * scaleGolgi;
                Structure golgiObj = new Structure(Content, modelGolgi, textureGolgi, positionGolgi, rotationGolgi, scaleGolgi, AABBGolgi, InputHandler.keyStates.Golgi);
                plotList.Add(golgiObj);

                Debug.WriteLine("list size:" + plotList.Count);
            }
            
        }

        /** 
        *   @brief mutator to set the list of items to draw
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
        public void SetItemHash()
        {
            Debug.WriteLine("item size:" + itemHash.Count);

            string modelSelenocysteine = "Models/selenocystine_obj";
            string textureSelenocysteine = "Textures/selenocystine_diff";
            Vector3 positionSelenocysteine = new Vector3(30, 0, 30) * 20;
            Vector3 rotationSelenocysteine = new Vector3(0, 0, 0);
            float scaleSelenocysteine = 10f;
            Vector3 AABBSelenocysteine = new Vector3(1, 1, 1) * scaleSelenocysteine;
            int selenocysteineID = (int)Math.Round((positionSelenocysteine.X * positionSelenocysteine.Y * positionSelenocysteine.Z));
            Item selenocysteineObj = new Item(Content, selenocysteineID, modelSelenocysteine, textureSelenocysteine, positionSelenocysteine, rotationSelenocysteine, scaleSelenocysteine, AABBSelenocysteine, InputHandler.keyStates.Selenocysteine);
            itemHash.Add(selenocysteineID, selenocysteineObj);

            // creating random mitochondria
            for (int ii = 0; ii < sizeX; ii++)
            {
                for (int jj = 0; jj < sizeY; jj++)
                {
                    if (!(itemMap[ii, jj] == null))
                    {
                        Vector3 tempPosition = new Vector3(itemMap[ii, jj].GetCoordX(), itemMap[ii, jj].GetCoordY(), itemMap[ii, jj].GetCoordZ());
                        Vector3 tempOffset = new Vector3(20, 20, 20);
                        
                        int tempID = (int) Math.Round( (itemMap[ii, jj].GetCoordX() * itemMap[ii, jj].GetCoordY() * itemMap[ii, jj].GetCoordZ())) ;
                        Item tempPlot = new Item(Content, tempID, itemMap[ii, jj].GetModelPath(), itemMap[ii, jj].GetTexturePath(), tempPosition, itemMap[ii, jj].GetMapRotation(),itemMap[ii, jj].GetMapScale(), tempOffset, itemMap[ii,jj].GetCodexType());
                        if(!itemHash.ContainsKey(tempPlot.GetItemID()))
                        {
                            itemHash.Add(tempPlot.GetItemID(), tempPlot);
                        }
                    }

                }
            }
            Debug.WriteLine("item size:" + itemHash.Count);

        }

        /** 
        *   @brief function to remove items from the game world
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
        public void RemoveItemHash(int targetID)
        {
            itemHash.Remove(targetID);
        }

        /** 
        *   @brief mutator function for creating the NPC list
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
        public void SetNPCHash()
        {
            //adds to the list the land and road tiles
            for (int ii = 0; ii < sizeX; ii++)
            {
                for (int jj = 0; jj < sizeY; jj++)
                {
                    if (!(npcMap[ii, jj] == null))
                    {
                        Vector3 tempPosition = new Vector3(npcMap[ii, jj].GetCoordX(), npcMap[ii, jj].GetCoordY(), npcMap[ii, jj].GetCoordZ());
                        Vector3 tempOffset = new Vector3(20, 20, 20);
                        float tempSpeed = 1;
                        int tempID = (int)Math.Round((npcMap[ii, jj].GetCoordX() * npcMap[ii, jj].GetCoordY() * npcMap[ii, jj].GetCoordZ()));
                        List<Vector3> newWayPoints = new List<Vector3>();
                        Random randomNum = new Random();
                        int npcWaypointSize = 50;
                        int npcWaypointRange = 200;
                        int npcRealWorld = 20;
                        for (int aa = 0; aa < npcWaypointSize; aa += 1)
                        {
                            int randomX = randomNum.Next(npcWaypointRange) * npcRealWorld;
                            int randomY = randomNum.Next(npcWaypointRange) * npcRealWorld;
                            int randomZ = randomNum.Next(npcWaypointRange) * npcRealWorld;

                            Vector3 newPosition = new Vector3(randomX, randomY, randomZ);
                            newWayPoints.Add(newPosition);
                        }

                        //Debug.WriteLine("npc codex type: " + npcMap[ii, jj].GetCodexType());

                        NPC tempPlot = new NPC(Content, tempID, npcMap[ii, jj].GetModelPath(), 
                                                npcMap[ii, jj].GetTexturePath(), tempPosition, 
                                                    npcMap[ii, jj].GetMapRotation(), npcMap[ii, jj].GetMapScale(), 
                                                        tempOffset, tempSpeed, newWayPoints, npcMap[ii, jj].GetCodexType());
                        if (!npcHash.ContainsKey(tempPlot.GetNPCID()))
                        {
                            npcHash.Add(tempPlot.GetNPCID(), tempPlot);
                        }
                    }

                }
            }
            Debug.WriteLine("npc size:" + npcHash.Count);

        }

        /** 
        *   @brief Utilty function to print the plot list for debugging
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void PrintPlotList()
        {
            for(int ii = 0; ii < plotList.Count; ii++)
            {
                Debug.WriteLine("plot x: " + plotList[ii].actorPosition.X + " y: " + plotList[ii].actorPosition.Y + " Z: " + plotList[ii].actorPosition.Z);
            }
        }

        /** 
        *   @brief Utilty function to print the plot list for debugging
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return void
        *	@pre 
        *	@post 
        */
        public void PrintItemList()
        {
            for (int ii = 0; ii < itemList.Count; ii++)
            {
                Debug.WriteLine("item x: " + itemList[ii].actorPosition.X + " y: " + itemList[ii].actorPosition.Y + " Z: " + itemList[ii].actorPosition.Z);
            }
        }

        



    }
}
