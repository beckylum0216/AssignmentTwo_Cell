using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    class GameManager:GameState
    {
        private Matrix theWorld;
        private Matrix theCamera;
        private Matrix projection;
        private Camera camera;
        private float cameraSpeed;
        private float fps;
        private ModelHandler mapClient;
        private Vector3 mouseInputDelta;
        private InputHandler inputHandlers;
        private InputHandler.keyStates keyboardInput;
        private GamePadState gamePadInput;
        int screenX;
        int screenY;
        Codex codex;//the codex class

        private List<string> ModelFileNames = new List<string>();
        private List<Vector3> ModelTranslations = new List<Vector3>();
        private List<float> ModelRotations = new List<float>();

        public void Initialise()
        {
            

        }
         


        public override void Initialise(GameContext gameCtx)
        {
            theWorld = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), screenX / screenY, 0.1f, 8000f);

            int centerX = (int)(screenX / 2);
            int centerY = (int)(screenY / 2);

            gameCtx.GetGameInstance().IsMouseVisible = true;
            Mouse.SetPosition((int)centerX, (int)centerY);
            gamePadInput = GamePad.GetState(PlayerIndex.One);

            Vector3 camEyeVector = new Vector3(0, 0, 0);
            Vector3 camPositionVector = Vector3.Add(new Vector3(0, 0, 0), new Vector3(0, 1.6f, 0));
            Vector3 deltaVector = new Vector3(0, 0, 0.001f);
            Vector3 AABBOffsetCamera = new Vector3(0.5f, 0.25f, 0.5f);
            camera = new Camera(theCamera, camPositionVector, camEyeVector, deltaVector, AABBOffsetCamera);
            cameraSpeed = 5f;
            fps = 90f;

            //========================================================
            ModelFileNames.Add("Models/Cube");
            ModelFileNames.Add("Models/Cubic");
            ModelFileNames.Add("Models/BloodVessel");
            ModelFileNames.Add("Models/WhiteBloodCell");

            ModelTranslations.Add(new Vector3(100, 200, 100));
            ModelTranslations.Add(new Vector3(50, 50, 50));
            ModelTranslations.Add(new Vector3(200, 200, -100));
            ModelTranslations.Add(new Vector3(200, 200, -200));

            ModelRotations.Add(0.0f);
            ModelRotations.Add(0.75f);
            ModelRotations.Add(0.0f);
            ModelRotations.Add(0.0f);
            //=======================================================

            mapClient = new ModelHandler(gameCtx.GetGameInstance().Content, 1, 1, 1.0f, ModelFileNames, ModelTranslations, ModelRotations);
            mapClient.SetPlotDictionary();
            mapClient.SetPlotList();
            mapClient.PrintPlotList();
            codex = new Codex();
            codex.Initialize(gameCtx.GetGraphics(), gameCtx.GetGameInstance().Content);//initialize the basic codex(no samples taken)


            codex = new Codex();
            codex.Initialize(gameCtx.GetGraphics(), gameCtx.GetGameInstance().Content);//initialize the basic codex(no samples taken)
        }


        public override void Update(GameContext gameCtx)
        {
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;

            float deltaTime = (float)gameCtx.GetGameTime().ElapsedGameTime.TotalSeconds;

            inputHandlers = new InputHandler(screenX, screenY,codex);
            mouseInputDelta = inputHandlers.MouseHandler(screenX, screenY, 1.00f);

            if (!gamePadInput.IsConnected)
            {

                keyboardInput = inputHandlers.KeyboardHandler();
            }
            else
            {
                keyboardInput = inputHandlers.LeftGamePadHandler();
            }

            camera.SubjectMove(keyboardInput, cameraSpeed, deltaTime, fps);
            //setting up collisions

            theCamera = camera.SubjectUpdate(mouseInputDelta, deltaTime, fps);
            codex.Update(gameCtx.GetGameTime());//this update animates the codex drop down
        }

        public override void Draw(GameContext gameCtx)
        {

            for (int ii = 0; ii < mapClient.GetPlotList().Count; ii++)
            {
                mapClient.GetPlotList()[ii].ActorDraw(theWorld, theCamera, projection);
            }

            mapClient.DrawModels(theCamera, projection);
            codex.Draw();//draw the codex (should be drawn in deactivated state i.e. top of the screen)
        }
    }
}
