using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    class GameTwoManager:GameState
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
        private int screenX;
        private int screenY;

        private int gameLevel;
        private SpriteFont font;
        private Text text = new Text();
        private int seconds = 0;
        private int minutes = 0;
        Stopwatch stopWatch = new Stopwatch();
        TimeSpan ts = new TimeSpan();
        HUD hud = new HUD(); 
        public GameTwoManager()
        {

        }

        public GameTwoManager(GameContext gameCtx)
        {
            Debug.WriteLine("Level 2 Initialised!!!");
            theWorld = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), screenX / screenY, 0.1f, 20000f);

            int centerX = (int)(screenX / 2);
            int centerY = (int)(screenY / 2);

            gameCtx.GetGameInstance().IsMouseVisible = true;
            Mouse.SetPosition((int)centerX, (int)centerY);
            gamePadInput = GamePad.GetState(PlayerIndex.One);

            gameLevel = 1;
            mapClient = new ModelHandler(gameCtx.GetGameInstance().Content, 20, 20, 20, 1.0f, gameLevel);
            mapClient.SetPlotDictionary();
            mapClient.SetPlotList(gameLevel);
            mapClient.PrintPlotList();

            mapClient.SetItemHash();
            //mapClient.PrintItemList();

            

            Vector3 camEyeVector = new Vector3(0, 0, 0);
            Vector3 camPositionVector = Vector3.Add(new Vector3(0, 0, 0), new Vector3(0, 1.6f, 0));
            Vector3 deltaVector = new Vector3(0, 0, 0.001f);
            Vector3 AABBOffsetCamera = new Vector3(0.5f, 0.25f, 0.5f);
            camera = new Camera( gameCtx.GetGameInstance().Content, theCamera, camPositionVector, camEyeVector, deltaVector, AABBOffsetCamera, mapClient);
            cameraSpeed = 3f;
            fps = 60f;

            
            //initialize the basic codex(no samples taken)
            CodexManager.GetCodexInstance().Initialize(gameCtx.GetGraphics(), gameCtx.GetGameInstance().Content, camera.GetCodexHash());

            for (int ii = 0; ii < mapClient.GetPlotList().Count; ii += 1)
            {
                camera.SetObservers(mapClient.GetPlotList()[ii]);
            }

            foreach(var item in mapClient.GetItemHash())
            {
                camera.SetItems(item.Value);
            }

            //initialise font for timer display
            font = gameCtx.GetGameInstance().Content.Load<SpriteFont>("Fonts/arialFont");
            text.Initialise(font);
            text.SetPosition(new Vector2((this.GetScreenX() / 2) - 30, 10));
            stopWatch.Start();
            hud.Initialise(gameCtx,screenX,screenY);
        }
        
        public int GetScreenX()
        {
            return this.screenX;
        }

        public int GetScreenY()
        {
            return this.screenY;
        }

        public Camera GetCamera()
        {
            return camera;
        }

        //getter for the plotlist in mapclient
        public List<Actor> GetStructureList()
        {
            return mapClient.GetPlotList();
        }

        //getter for the plotlist in mapclient
        public List<Actor> GetItemList()
        {
            return mapClient.GetItemList();
        }

        public override void Initialise(GameContext gameCtx)
        {
            
           
        }


        public override void Update(GameContext gameCtx)
        {
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;

            float deltaTime = (float)gameCtx.GetGameTime().ElapsedGameTime.TotalSeconds;

            inputHandlers = new InputHandler(screenX, screenY);
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

            theCamera = camera.SubjectUpdate(gameCtx, mouseInputDelta, deltaTime, fps);
            //this update animates the codex drop down
            CodexManager.GetCodexInstance().Update(gameCtx.GetGameTime(), keyboardInput, camera.GetCodexHash());

            stopWatch.Stop();
            ts = stopWatch.Elapsed;



            seconds = ts.Seconds;
            minutes = ts.Minutes;

            text.SetString("Time : " + minutes + ":" + seconds + "");
            stopWatch.Start();
            hud.Update();
        }

        public override void Draw(GameContext gameCtx)
        {
            for (int ii = 0; ii < mapClient.GetPlotList().Count; ii++)
            {
                mapClient.GetPlotList()[ii].ActorDraw(theWorld, theCamera, projection);
            }
            
            foreach(Actor index in mapClient.GetItemHash().Values)
            {
                index.ActorDraw(theWorld, theCamera, projection);
            }

            
            //draw the codex (should be drawn in deactivated state i.e. top of the screen)
            CodexManager.GetCodexInstance().Draw();

            text.Draw(gameCtx.GetSpriteBatch(), gameCtx.GetGraphics());
            hud.Draw(gameCtx.GetSpriteBatch(), gameCtx.GetGraphics());
        }
    }
}
