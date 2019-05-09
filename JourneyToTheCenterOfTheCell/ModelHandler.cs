using Microsoft.Xna.Framework;
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
    class ModelHandler
    {
        private List <Actor> plotList = new List<Actor>();
        private Dictionary<string, Actor> landPlots = new Dictionary<string, Actor>();
        //private Map[,,] gridMap;
        //MapGenerator mapCreate;
        private ContentManager Content;
        private int sizeX;
        private int sizeY;
        private int sizeZ;
        private float plotScale;


        //=======Not needed once Models are added that hold textures
        private const int NumOfModels = 3;
        string[] ModelNameMatrix = new string[NumOfModels] { "Models/Cube", "Models/Cubic", "Models/Cube" };
        Vector3[] ModelTranslations = new Vector3[NumOfModels]
        {
            new Vector3(100, 200, 100),
            new Vector3(50, 50, 50),
            new Vector3(100, 50, 100)
        };
        private float[] ModelRotations = new float[NumOfModels] { 0.0f, 0.75f, 0.0f };

        Model[] Models = new Model[NumOfModels]; //Not needed once PlotList is working


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
        public ModelHandler(ContentManager inputContent,  int inputX, int inputY, int inputZ, float inputScale)
        {
            Content = inputContent;
            sizeX = inputX;
            sizeY = inputY;
            sizeZ = inputZ;
            this.plotScale = inputScale;

            // initialise map
            //MapGenerator mapCreate = new MapGenerator(sizeX, sizeY, sizeZ);
            //mapCreate.SetMap();
            //mapCreate.PrintGrid();
            //mapCreate.SetCoords();
            //mapCreate.PrintCoords();
           
            //gridMap = mapCreate.GetGridMap();
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

            for (int i = 0; i < NumOfModels; i++)
            {
                Models[i] = Content.Load<Model>(ModelNameMatrix[i]);
                //Structure plotModel = new Structure()

                //Add dictionary element to landPlots
            }

            //modelFile = "Models/city_residential_03";
            //textureFile = "Maya/sourceimages/city_residential_03_dif";
            //Vector3 positionBuilding = new Vector3(0, 0, 0);
            //Vector3 rotationBuilding = new Vector3(0, 0, 0);
            //Vector3 AABBOffsetBuilding = new Vector3(15, 20, 15);
            //float scaleBuilding = 2.5f;
            //Plot plotBuilding = new Plot(Content, modelFile, textureFile, positionBuilding, rotationBuilding, scaleBuilding, AABBOffsetBuilding);
            //landPlots.Add(Block.buildType.Building.ToString(), plotBuilding);

            //set up roads and tiles
            //for (int ii = 0; ii < sizeX; ii++)
            //{
            //    for(int jj = 0; jj < sizeY; jj++)
            //    {
            //        try
            //        {
            //            Vector3 tempPosition = new Vector3(gridMap[ii, jj].GetCoordX(), gridMap[ii, jj].GetCoordY(), gridMap[ii, jj].GetCoordZ());
            //            Vector3 tempOffset = new Vector3(0, 0, 0);
            //            Plot tempPlot = new Plot(Content, gridMap[ii, jj].GetModelPath(), gridMap[ii, jj].GetTexturePath(),
            //                                        tempPosition, gridMap[ii, jj].GetBlockRotation(), plotScale, tempOffset);
            //            landPlots.Add(gridMap[ii, jj].GetBlockType().ToString(), tempPlot);
            //        }
            //        catch( System.ArgumentException e)
            //        {
            //            Debug.WriteLine("Item Already Added! " + e);
            //        }
            //    }
            //}
        }

        // bad bad code 
        public void SetPlotList()
        {
            string modelFile = "Models/skybox_cube";
            string textureFile = "Textures/InnerBody2";
            // move the centre of the skybox to the centre of the "city"
            float centerOrigin = 1;
            Vector3 positionSkyBox = new Vector3(centerOrigin, 0f, centerOrigin);
            Vector3 rotationSkyBox = new Vector3(0, 0, 0);
            Vector3 AABBOffset = new Vector3(0, 0, 0);
            float scaleSkyBox = 100f;
            //Actor plotSkyBox = landPlots["SkyBox"].ActorClone(Content, modelFile, textureFile, positionSkyBox, rotationSkyBox, scaleSkyBox, AABBOffset);
            SkyBox skyBoxObj = new SkyBox(Content, modelFile, textureFile, positionSkyBox, rotationSkyBox, scaleSkyBox, AABBOffset);
            plotList.Add(skyBoxObj);

            Debug.WriteLine("list size:" + plotList.Count);
            // adds to the list the land and road tiles
            //for (int ii = 0; ii < sizeX; ii++)
            //{
            //    for (int jj = 0; jj < sizeY; jj++)
            //    {
            //        Vector3 tempPosition = new Vector3(gridMap[ii, jj].GetCoordX(), gridMap[ii, jj].GetCoordY(), gridMap[ii, jj].GetCoordZ());
                    
            //        Vector3 tempOffset = new Vector3(10, 1, 10);
            //        // prototyping map tiles not working as planned 
            //        // Actor tempPlot = landPlots[gridMap[ii, jj].GetBlockType().ToString()].ActorClone(Content, gridMap[ii, jj].GetModelPath(), gridMap[ii, jj].GetTexturePath(), tempPosition, gridMap[ii, jj].GetBlockRotation(), gridMap[ii, jj].GetBlockScale(), tempOffset);
            //        Plot tempPlot = new Plot(Content, gridMap[ii, jj].GetModelPath(), gridMap[ii, jj].GetTexturePath(), tempPosition, gridMap[ii, jj].GetBlockRotation(), gridMap[ii, jj].GetBlockScale(), tempOffset);
            //        plotList.Add(tempPlot);
            //    }
            //}

            //for(int ii = 0; ii < sizeX; ii++)
            //{
            //    for(int jj = 0; jj < sizeY; jj++)
            //    {
            //        if(gridMap[ii,jj].GetBlockType() == Block.buildType.Building)
            //        {
            //            modelFile = "Models/city_residential_03";
            //            textureFile = "Maya/sourceimages/city_residential_03_dif";
            //            Vector3 positionBuilding = new Vector3(gridMap[ii,jj].GetCoordX(), 0, gridMap[ii, jj].GetCoordZ());
            //            Vector3 rotationBuilding = new Vector3(0, 0, 0);
            //            Vector3 AABBOffsetBuilding = new Vector3(17, 25, 17);
            //            float scaleBuilding = 3f;
            //            //Actor plotBuilding = landPlots["Building"].ActorClone(Content, modelFile, textureFile, positionBuilding, rotationBuilding, scaleBuilding, AABBOffsetBuilding);
            //            Plot plotBuilding = new Plot(Content, modelFile, textureFile, positionBuilding, rotationBuilding, scaleBuilding, AABBOffsetBuilding);
            //            plotList.Add(plotBuilding);
            //        }
            //    }
            //}
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

        public void DrawModel(Matrix view, Matrix projection)
        {
            for (int i = 0; i < NumOfModels; i++)
            {
                Model model = Models[i];
                Matrix[] transforms = new Matrix[model.Bones.Count];
                model.CopyAbsoluteBoneTransformsTo(transforms);

                foreach (ModelMesh mesh in model.Meshes) //for each mesh in the model
                {
                    foreach (BasicEffect effect in mesh.Effects) //and for each effect in the model
                    {
                        effect.EnableDefaultLighting();
                        effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationY(ModelRotations[i]) * Matrix.CreateTranslation(ModelTranslations[i]);
                        effect.View = view;
                        effect.Projection = projection;
                    }

                    mesh.Draw(); //draw the model

                }
            }
        }
    }
}
