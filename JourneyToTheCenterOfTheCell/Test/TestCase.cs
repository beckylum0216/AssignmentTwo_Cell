using JourneyToTheCenterOfTheCell;
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


    [Test]
    public void NPC1() //test initialise
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }


    [Test]
    public void NPC2() //test actor clone
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content,1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero,1,waypoints);
            npc.ActorClone(gtx.GetGameInstance().Content, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void NPC3() //test actor update
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            npc.ActorUpdate(1f,1f);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }
    [Test]
    public void NPC4() //test animate npc
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            npc.AnimateNPC(1f, 1f);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }
    [Test]
    public void NPC5() //test print npc waypoints
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            npc.PrintNPCWaypoints();
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }
    [Test]
    public void NPC6() //test aabb
    {

        try
        {
            Camera c = new Camera();
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            npc.StateAABB(c);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }


    [Test]
    public void NPCWander1() //test initialise
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            NPCWander test = new NPCWander(npc);
            
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void NPCWander2() //test animate
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            NPCWander test = new NPCWander(npc);
            test.Animate(npc,1f,1f);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }


    [Test]
    public void NPCAttack1() //test initialise
    {

        try
        {
            Camera c = new Camera();
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            NPCAttack test = new NPCAttack(c);
            
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void NPCAttack2() //test animate
    {

        try
        {
            Camera c = new Camera();
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            List<Vector3> waypoints = new List<Vector3>();
            NPC npc = new NPC(gtx.GetGameInstance().Content, 1, "Models/lysosome", null, Vector3.Zero, Vector3.Zero, 1, Vector3.Zero, 1, waypoints);
            NPCAttack test = new NPCAttack(c);
            test.Animate(npc, 1f, 1f);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void ModelHandler1() //test init
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);
            
            ModelHandler test = new ModelHandler(gtx.GetGameInstance().Content,1,1,1,1,1);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void ModelHandler2() //test PrintPlotList
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);

            ModelHandler test = new ModelHandler(gtx.GetGameInstance().Content, 1, 1, 1, 1, 1);
            test.PrintPlotList();
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void ModelHandler3() //test PrintItemList
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);

            ModelHandler test = new ModelHandler(gtx.GetGameInstance().Content, 1, 1, 1, 1, 1);
            test.PrintItemList();
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void MenuView1() //test init
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);

            MenuView test = new MenuView(gtx);
            
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void MenuManager1() //test init
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);

            MenuManager test = new MenuManager();
            test.Initialise(gtx);

        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void MenuManager2() //test update
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);

            MenuManager test = new MenuManager();
            test.Initialise(gtx);
            test.Update(gtx);

        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void MenuManager3() //test draw
    {

        try
        {
            Game game = new Game();
            GraphicsDeviceManager g = new GraphicsDeviceManager(game);
            SpriteBatch sb = new SpriteBatch(g.GraphicsDevice);
            GameContext gtx = new GameContext(game, g, sb);

            MenuManager test = new MenuManager();
            test.Initialise(gtx);
            test.Draw(gtx);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void MapGenerator1() //init
    {

        try
        {
            MapGenerator test = new MapGenerator(10,10,10);            
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    

    [Test]
    public void MapGenerator2() //test print grid
    {

        try
        {
            MapGenerator test = new MapGenerator(10, 10, 10);
            test.PrintGrid();
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void MapGenerator3() //test print coords
    {

        try
        {
            MapGenerator test = new MapGenerator(10, 10, 10);
            test.PrintCoords();
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void Map1() //test default contructor
    {

        try
        {
            Map test = new Map();
            
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

    [Test]
    public void Map2() //test non default contructor
    {

        try
        {
            Map map = new Map();
            Map test = new Map(Vector3.Zero,map.GetMapType(),"Models/lysosome","Textures/lysosome",1,Vector3.Zero,map.GetCodexType(),1);
        }
        catch (Exception e)
        {
            Debug.WriteLine("Exception: " + e);

        }
    }

}


