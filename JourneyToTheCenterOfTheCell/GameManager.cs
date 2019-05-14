using GeonBit.UI;
using GeonBit.UI.Entities;
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
<<<<<<< HEAD
        CodexManager codex;//the codex class
        InfoPanel infoPane;
        Panel testPane;

=======
        Codex codex;//the codex class
       
>>>>>>> 07cdbec38e39a719bf9bb63c71cf7cb0d0798ce4

        public GameManager()
        {

        }

        public GameManager(GameContext gameCtx)
        {
            theWorld = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), screenX / screenY, 0.1f, 20000f);

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

            mapClient = new ModelHandler(gameCtx.GetGameInstance().Content, 20, 20, 20, 1.0f);
            mapClient.SetPlotDictionary();
            mapClient.SetPlotList();
            mapClient.PrintPlotList();

            codex = new CodexManager();
            codex.Initialize(gameCtx.GetGraphics(), gameCtx.GetGameInstance().Content);//initialize the basic codex(no samples taken)
<<<<<<< HEAD
            //UserInterface.Initialize(gameCtx.GetGameInstance().Content, BuiltinThemes.hd);
            infoPane = new InfoPanel();
            testPane = infoPane.GetPanel(gameCtx.GetGameInstance().Content, "blah" , "blah blah", "Pics/placeHolderCodex");

            //UserInterface.Active.AddEntity(testPane);

=======
            
            
>>>>>>> 07cdbec38e39a719bf9bb63c71cf7cb0d0798ce4
        }


        public void Initialise()
        {
            

        }
         
        public override void Initialise(GameContext gameCtx)
        {
            
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
            //UserInterface.Active.Update(gameCtx.GetGameTime());
        }

        public override void Draw(GameContext gameCtx)
        {
            for (int ii = 0; ii < mapClient.GetPlotList().Count; ii++)
            {
                mapClient.GetPlotList()[ii].ActorDraw(theWorld, theCamera, projection);
            }
            
            mapClient.DrawModel(theCamera, projection);
            codex.Draw();//draw the codex (should be drawn in deactivated state i.e. top of the screen)
            
            //UserInterface.Active.Draw(gameCtx.GetSpriteBatch());
        }
    }
}
