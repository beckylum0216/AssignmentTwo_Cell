using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JourneyToTheCenterOfTheCell
{ 
    class MapGenerator
    {
        private ContentManager Content;
        private List<Model> Models = new List<Model>();
        private List<Vector3> ModelTranslations = new List<Vector3>();
        private List<float> ModelRotations = new List<float>();


        int LevelID = 0; //0 = test level
        LevelManager Level;

        public MapGenerator(ContentManager inputContent, List<Model> LoadedModels, List<Vector3> ModelPositions, List<float> ModelRots) 
        {
            this.Content = inputContent;
            this.Models = LoadedModels;
            this.ModelTranslations = ModelPositions;
            this.ModelRotations = ModelRots;
            Level = new LevelManager(inputContent, LoadedModels, ModelPositions, ModelRots);
        }


        
        public void DrawModels(Matrix view, Matrix projection)
        {
            Level.BuildModels(view, projection);
        }
    }
}