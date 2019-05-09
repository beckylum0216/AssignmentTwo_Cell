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
using System;

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
        GameContext newGame;



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
            GameManager gameManager = new GameManager();
            MenuManager menuManager = new MenuManager();
            newGame = new GameContext(this, graphics, spriteBatch);
            newGame.SetGameState(menuManager);
            newGame.Initialise();

            

            MenuView gui = new MenuView();
            List<String> tempAns = new List<String>();
            tempAns.Add("lorem ipsum");
            tempAns.Add("blah");
            Quiz testQuiz = new Quiz("Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit, sed do eiusmod " +
                "tempor incididunt ut labore et " +
                "dolore magna aliqua.", tempAns, "blah");
            //QuizView quiz = new QuizView(testQuiz, screenX, screenY);
            //Panel testPanel = quiz.GetQuizPanel();

           
            //UserInterface.Active.AddEntity(testPanel);

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
            newGame.SetSpriteBatch(spriteBatch);

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

            newGame.SetGameTime(gameTime);
            newGame.Update();

           

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            newGame.Draw();

            

            //t.DisplayFont();//display
            // out textbox is ready to draw at all times will only actually draw if its boolean is set to true using textboxvariable.DisplayFont() method 
            //this way triggers or events that need a textbox can set the texbox parameters and switch the textbox to display for duration of event
            t.Draw(spriteBatch,graphics);

            
            
            

            base.Draw(gameTime);
        }
    }
}
