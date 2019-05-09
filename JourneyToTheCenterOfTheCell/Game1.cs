using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using MonoGame.Extended.Gui;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.ViewportAdapters;
using GeonBit.UI;
using GeonBit.UI.Entities;
using System.Collections.Generic;

namespace JourneyToTheCenterOfTheCell
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private SpriteFont arial24;



        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Matrix theWorld = Matrix.CreateTranslation(new Vector3(0, 0, 0));
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
        TextBox t = new TextBox();

        //DefaultViewportAdapter viewportAdapter;
        //GuiSpriteBatchRenderer guiRenderer;
        //GuiSystem guiSystem;

        private List<string> ModelFileNames = new List<string>();
        private List<Vector3> ModelTranslations = new List<Vector3>();
        private List<float> ModelRotations = new List<float>();

        UserInterface userInt;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            screenX = GraphicsDevice.Viewport.Width;
            screenY = GraphicsDevice.Viewport.Height;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), screenX / screenY, 0.1f, 15000f);

            int centerX = (int)(screenX / 2);
            int centerY = (int)(screenY / 2);

            this.IsMouseVisible = true;
            Mouse.SetPosition((int)centerX, (int)centerY);
            gamePadInput = GamePad.GetState(PlayerIndex.One);

            Vector3 camEyeVector = new Vector3(0, 0, 0);
            Vector3 camPositionVector = Vector3.Add(new Vector3(0, 0, 0), new Vector3(0, 1.6f, 0));
            Vector3 deltaVector = new Vector3(0, 0, 0.001f);
            Vector3 AABBOffsetCamera = new Vector3(0.5f, 0.25f, 0.5f);
            camera = new Camera(theCamera, camPositionVector, camEyeVector, deltaVector, AABBOffsetCamera);
            cameraSpeed = 5f;
            fps = 90f;

            //===========Model Handling===========================
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

            //===================================================

            mapClient = new ModelHandler(Content, 1, 1, 1.0f, ModelFileNames, ModelTranslations, ModelRotations);
            mapClient.SetPlotDictionary();
            mapClient.SetPlotList();
            mapClient.PrintPlotList();

            //viewportAdapter = new DefaultViewportAdapter(GraphicsDevice);
            //guiRenderer = new GuiSpriteBatchRenderer(GraphicsDevice, () => Matrix.Identity);
            //guiSystem = new GuiSystem(viewportAdapter, guiRenderer);
            //testGui gui = new testGui();
            //GuiScreen newScreen = gui.GetScreen();
            //guiSystem.Screens.Add(newScreen);

            
            UserInterface.Initialize(Content, BuiltinThemes.hd);

            testGui gui = new testGui();

            Panel testPanel = gui.GetPanel();

            UserInterface.Active.AddEntity(testPanel);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            arial24 = this.Content.Load<SpriteFont>("Fonts/arialFont");
            t.Initialise(arial24);

            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            screenX = GraphicsDevice.Viewport.Width;
            screenY = GraphicsDevice.Viewport.Height;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            inputHandlers = new InputHandler(screenX, screenY);
            mouseInputDelta = inputHandlers.MouseHandler(screenX, screenY, 1.00f);

            if (!gamePadInput.IsConnected)
            {
                Debug.WriteLine("gamePadInput: " + gamePadInput.IsConnected);
                keyboardInput = inputHandlers.KeyboardHandler();
            }
            else
            {
                keyboardInput = inputHandlers.LeftGamePadHandler();
            }

            camera.SubjectMove(keyboardInput, cameraSpeed, deltaTime, fps);
            //setting up collisions

            theCamera = camera.SubjectUpdate(mouseInputDelta, deltaTime, fps);

            //guiSystem.Update(gameTime);

            UserInterface.Active.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            for (int ii = 0; ii < mapClient.GetPlotList().Count; ii++)
            {
                mapClient.GetPlotList()[ii].ActorDraw(theWorld, theCamera, projection);
            }

            

            t.DisplayFont();//display
            // out textbox is ready to draw at all times will only actually draw if its boolean is set to true using textboxvariable.DisplayFont() method 
            //this way triggers or events that need a textbox can set the texbox parameters and switch the textbox to display for duration of event
            

            mapClient.DrawModels(theCamera, projection);
            //t.Draw(spriteBatch, graphics);

            //guiSystem.Draw(gameTime);


            //UserInterface.Active.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
