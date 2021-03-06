﻿using Microsoft.Xna.Framework;
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
using Microsoft.Xna.Framework.Media;

namespace JourneyToTheCenterOfTheCell
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        

        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        GameContext newGame;
        
       
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.ApplyChanges();
            this.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            graphics.HardwareModeSwitch = false;
            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            MenuManager menuManager = new MenuManager();
            
            newGame = new GameContext(this, graphics, spriteBatch, GraphicsDevice);
          
            newGame.SetGameState(menuManager);
            
            newGame.Initialise();
            
            Song cellSong = Content.Load<Song>("Music/JourneyToTheCentreOfTheCell");
            MediaPlayer.Play(cellSong);
            MediaPlayer.IsRepeating = true;

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

            
           

            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            //TEST FOR DEVELOPEMENT BRANCH

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
            

            // out textbox is ready to draw at all times will only actually draw if its boolean is set to true using textboxvariable.DisplayFont() method 
            //this way triggers or events that need a textbox can set the texbox parameters and switch the textbox to display for duration of event
            

            base.Draw(gameTime);
        }
    }
}
