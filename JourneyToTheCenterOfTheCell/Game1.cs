using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

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
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), screenX / screenY, 0.1f, 8000f);

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
            cameraSpeed = 10f;
            fps = 90f;

            mapClient = new ModelHandler(Content, 1, 1, 1.0f);
            mapClient.SetPlotDictionary();
            mapClient.SetPlotList();
            mapClient.PrintPlotList();
            
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
            //t.DisplayFont();//displa
            // out textbox is ready to draw at all times will only actually draw if its boolean is set to true using textboxvariable.DisplayFont() method 
            //this way triggers or events that need a textbox can set the texbox parameters and switch the textbox to display for duration of event
            t.Draw(spriteBatch,graphics);

            mapClient.DrawModel(theCamera, projection);

            base.Draw(gameTime);
        }
    }
}
