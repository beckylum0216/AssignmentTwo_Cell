﻿using GeonBit.UI;
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
    /// @author Rebecca Lim
    /// <summary>
    /// Game state for creating the game level two
    /// </summary>
    /// 
    class GameTwoManager :GameState
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
        List<NPCWander> npcStateList;

        /** 
        *   @brief default constructor for level two
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post level exists
        */
        public GameTwoManager()
        {

        }

        /** 
        *   @brief parameterised constructor for level two
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post level exists
        */
        public GameTwoManager(GameContext gameCtx)
        {
            Debug.WriteLine("Level 2 Initialised!!!");

            theWorld = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            screenX = gameCtx.GetGraphics().GraphicsDevice.Viewport.Width;
            screenY = gameCtx.GetGraphics().GraphicsDevice.Viewport.Height;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), screenX / screenY, 0.1f, 30000f);

            int centerX = (int)(screenX / 2);
            int centerY = (int)(screenY / 2);

            gameCtx.GetGameInstance().IsMouseVisible = true;
            Mouse.SetPosition((int)centerX, (int)centerY);
            gamePadInput = GamePad.GetState(PlayerIndex.One);

            gameLevel = 1;
            mapClient = new ModelHandler(gameCtx.GetGameInstance().Content, 200, 200, 200, 1.0f, gameLevel);
            //mapClient.SetPlotDictionary();
            mapClient.SetPlotList();
            //mapClient.PrintPlotList();

            mapClient.SetItemHash();

            mapClient.SetNPCHash();

            Vector3 camEyeVector = new Vector3(0, 0, 0);
            Vector3 camPositionVector = Vector3.Add(new Vector3(0, 0, 0), new Vector3(0, 1.6f, 0));
            Vector3 deltaVector = new Vector3(0, 0, 0.001f);
            Vector3 AABBOffsetCamera = new Vector3(0.5f, 0.25f, 0.5f);
            camera = new Camera(gameCtx, gameCtx.GetGameInstance().Content, theCamera, camPositionVector, camEyeVector, deltaVector, AABBOffsetCamera, mapClient, gameLevel);
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

            foreach (var npc in mapClient.GetNPCHash())
            {
                //Debug.WriteLine("npc typey: " + npc.Value.GetCodexType());
                camera.SetNPCs(npc.Value);
            }

            npcStateList = new List<NPCWander>();

            foreach (var npc in mapClient.GetNPCHash())
            {
                NPCWander newWander = new NPCWander(npc.Value);
                npcStateList.Add(newWander);
            }

            camera.SetWanderList(npcStateList);

            //initialise font for timer display
            font = gameCtx.GetGameInstance().Content.Load<SpriteFont>("Fonts/arialFont");
            text.Initialise(font);
            text.SetPosition(new Vector2((this.GetScreenX() / 2) - (this.GetScreenX() / 18), this.GetScreenY() / 52));
            stopWatch.Start();
            hud.Initialise(gameCtx,screenX,screenY);
            
        }

        /** 
        *   @brief accessor to the width of the game viewport width
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return screenX the width of the game screen
        *	@pre game exists
        *	@post 
        */
        public int GetScreenX()
        {
            return this.screenX;
        }

        /** 
        *   @brief accessor to the width of the game viewport height
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return screenY the height of the game screen
        *	@pre game exists
        *	@post 
        */
        public int GetScreenY()
        {
            return this.screenY;
        }


        /** 
        *   @brief accessor to the game's camera
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return camera the player camera
        *	@pre camera exists
        *	@post 
        */
        public Camera GetCamera()
        {
            return camera;
        }

        /** 
        *   @brief accessor to the list of active structures in the game
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return screenX the width of the game screen
        *	@pre game exists
        *	@post 
        */
        public List<Actor> GetStructureList()
        {
            return mapClient.GetPlotList();
        }

        /** 
        *   @brief accessor to the active items of the game
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return mapclient
        *	@pre game exists
        *	@post 
        */
        public List<Actor> GetItemList()
        {
            return mapClient.GetItemList();
        }

        /** 
        *   @brief concrete function of the abstract class game state
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public override void Initialise(GameContext gameCtx)
        {
            
           
        }

        /** 
        *   @brief concrete update function of the abstract class game state
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
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
                mouseInputDelta = inputHandlers.RightGamePadHandler(screenX, screenY, 1.00f);
            }



            camera.SubjectMove(keyboardInput, cameraSpeed, deltaTime, fps);
            //setting up collisions

            theCamera = camera.SubjectUpdate(gameCtx, mouseInputDelta, deltaTime, fps);

            foreach (Actor index in mapClient.GetNPCHash().Values)
            {
                index.ActorUpdate(deltaTime, fps);
            }

            //this update animates the codex drop down
            CodexManager.GetCodexInstance().Update(gameCtx.GetGameTime(), keyboardInput, camera.GetCodexHash());

            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            seconds = ts.Seconds;
            minutes = ts.Minutes;

            text.SetString("Time: " + minutes + ":" + seconds + "");
            stopWatch.Start();
            hud.Update(camera.GetCamPlayer());

            if (camera.GetCamPlayer().GetHealth() < 1)
            {
                DeathManager newGame = new DeathManager();
                gameCtx.SetGameState(newGame);
                newGame.Initialise(gameCtx);
            }

            if (camera.SelenoAquired())
            {
                GameFinishedManager newGame = new GameFinishedManager();
                gameCtx.SetGameState(newGame);
                newGame.Initialise(gameCtx);
            }

        }

        /** 
        *   @brief concrete draw function of the abstract class game state
        *   @see
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
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

            foreach (Actor index in mapClient.GetNPCHash().Values)
            {
                index.ActorDraw(theWorld, theCamera, projection);
            }

            
            hud.Draw(gameCtx.GetSpriteBatch(), gameCtx.GetGraphics());
            text.Draw(gameCtx.GetSpriteBatch(), gameCtx.GetGraphics());

            //draw the codex (should be drawn in deactivated state i.e. top of the screen)
            CodexManager.GetCodexInstance().Draw();
            
            //if(CodexManager.GetCodexInstance().)

        }

        /** 
        *   @brief function to invoke the end game state
        *   @see
        *	@param gameCtx the game context
        *	@param  
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post game ends
        */
        public void EndGame(GameContext gameCtx)
        {
            GameFinishedManager endGame = new GameFinishedManager();
            endGame.Initialise(gameCtx);
            gameCtx.SetGameState(endGame);

        }
    }
}
