﻿using JourneyToTheCenterOfTheCell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[TestFixture]
public class TestCase
{
    [Test]
    public void QuizTest1() //test initialisation with strings and list of strings
    {
        try 
        {
            List<String> inputOptions = new List<String>();
            inputOptions.Add("With human eyes, with dimensions between 1 and 100 centimeters. ");
            inputOptions.Add("Only under a microscope, with dimensions between 1 and 100 micrometres. ");
            inputOptions.Add("With Insect eyes, with dimensions between 1 and 10 millimeters. ");
            Quiz testq = new Quiz("blah", inputOptions, "blah");
                
                
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);
                
        }
        }
    [Test]
    public void QuizTest2() //test initialisation with a quiz
    {
        try
        {
            List<String> inputOptions = new List<String>();
            inputOptions.Add("With human eyes, with dimensions between 1 and 100 centimeters. ");
            inputOptions.Add("Only under a microscope, with dimensions between 1 and 100 micrometres. ");
            inputOptions.Add("With Insect eyes, with dimensions between 1 and 10 millimeters. ");
            Quiz q = new Quiz("blah", inputOptions, "blah");
            Quiz testq = new Quiz(q);

        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }
    [Test]
    public void QuizAnswers1() //test initialisation 
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch s = new SpriteBatch(g.GraphicsDevice);
            QuizManager qm = new QuizManager();
            GameContext gtx = new GameContext(game,g,s);
            QuizAnswers test = new QuizAnswers();
            test.Init(gtx,qm);

        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void QuizView1() //test initialisation 
    {

        try
        {
            int x = 3, y = 3;
            QuizManager qm = new QuizManager();
            List<String> inputOptions = new List<String>();
            inputOptions.Add("With human eyes, with dimensions between 1 and 100 centimeters. ");
            inputOptions.Add("Only under a microscope, with dimensions between 1 and 100 micrometres. ");
            inputOptions.Add("With Insect eyes, with dimensions between 1 and 10 millimeters. ");
            Quiz q = new Quiz("blah", inputOptions, "blah");
            QuizView test = new QuizView(qm,q,x,y);

        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void QuizFinishedView1() //test initialisation 
    {

        try
        {
            QuizFinishedView qfv = new QuizFinishedView();

        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void QuizManager1() //test initialisation 
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch s = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game,g,s);
            QuizManager qm = new QuizManager();
            qm.Initialise(gtx);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void QuizManager2() //test update 
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch s = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, s);
            QuizManager qm = new QuizManager();
            qm.Initialise(gtx);
            qm.Update(gtx);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void QuizManager3() //test draw
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch s = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, s);
            QuizManager qm = new QuizManager();
            qm.Initialise(gtx);
            qm.Draw(gtx);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void Text1() //test initialise
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            Texture2D t = new Texture2D(g.GraphicsDevice,2,2);
            SpriteFont s = gtx.GetGameInstance().Content.Load<SpriteFont>("Fonts/arialFont");
            Text test = new Text();
            test.Initialise(s);

        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }
    [Test]
    public void Text2() //test draw
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            Texture2D t = new Texture2D(g.GraphicsDevice, 2, 2);
            SpriteFont s = gtx.GetGameInstance().Content.Load<SpriteFont>("Fonts/arialFont");
            Text test = new Text();
            test.Initialise(s);
            test.Draw(sb,g);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }


    [Test]
    public void StoryView1() //test innit
    {

        try
        {
            StoryView test = new StoryView();
            
            
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void Structure1() //test innit
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            Structure test = new Structure(gtx.GetGameInstance().Content,"Models/lysosome",null, Vector3.Zero, Vector3.Zero, 1,Vector3.Zero);

        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }
    
    [Test]
    public void Structure2() //test clone
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            Structure test = new Structure(gtx.GetGameInstance().Content, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero);
            test.ActorClone(gtx.GetGameInstance().Content, "Models/peroxisome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void SkyBox1() //test init
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            SkyBox test = new SkyBox(gtx.GetGameInstance().Content, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }
    [Test]
    public void SkyBox2() //test update
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            SkyBox test = new SkyBox(gtx.GetGameInstance().Content, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero);
            float delta = 1, fps =1;
            test.ActorUpdate(delta,fps);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }
    [Test]
    public void SkyBox3() //test clone
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            g.ApplyChanges();
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            SkyBox test = new SkyBox(gtx.GetGameInstance().Content, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero);
            test.ActorClone(gtx.GetGameInstance().Content, "Models/peroxisome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

}


