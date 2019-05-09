using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace JourneyToTheCenterOfTheCell
{
    internal class LevelManager
    {
        private ContentManager Content;
        private List<Model> Models = new List<Model>();
        private List<Vector3> ModelTranslations = new List<Vector3>();
        private List<float> ModelRotations = new List<float>();


        int LevelID = 0;
        public LevelManager(ContentManager inputContent, List<Model> LoadedModels, List<Vector3> ModelPositions, List<float> ModelRots)
        {
            this.Content = inputContent;
            this.Models = LoadedModels;
            this.ModelTranslations = ModelPositions;
            this.ModelRotations = ModelRots;
        }

        public void BuildLevel()
        {

        }

        public void BuildModels(Matrix view, Matrix projection)
        {
            for (int i = 0; i < Models.Count; i++)
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

        public void SetLevelID(int ID)
        {
            this.LevelID = ID;
        }

    }
}