//Author: Bruno Neto
//Version:1.0
using Microsoft.Xna.Framework;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace JourneyToTheCenterOfTheCell
{
    public class Codex
    {
        SpriteBatch spritebatch;
        ContentManager content;
        //UserInterface userInt;
        Panel test;
        //UserInterface userInt;
        CodexGui cgui;
        InfoPanel gui;
        public bool codexActivate = false;
        string lysosomeInfo = "A lysosome is a membrane-bound organelle found in many animal cells. They are spherical vesicles that contain hydrolytic enzymes that can break down many kinds of biomolecules. A lysosome has a specific composition, of both its membrane proteins, and its lumenal proteins. The lumen's pH  is optimal for the enzymes involved in hydrolysis, analogous to the activity of the stomach. Besides degradation of polymers, the lysosome is involved in various cell processes, including secretion, plasma membrane repair, cell signaling, and energy metabolism.";
        string lysosomePic = "Pics/Lysosome-wikimedia";

        string peroxisomeInfo= "A peroxisome is a type of organelle known as a microbody, found in virtually all eukaryotic cells. They are involved in catabolism of very long chain fatty acids, branched chain fatty acids, D-amino acids, and polyamines, reduction of reactive oxygen species, specifically hydrogen peroxide, and biosynthesis of plasmalogens, i.e., ether phospholipids critical for the normal function of mammalian brains and lungs. They also contain approximately 10% of the total activity of two enzymes in the pentose phosphate pathway, which is important for energy metabolism.";
        string peroxisomePic= "Pics/782px-Peroxisome-wikimedia";

        string cellInfo = "Cells consist of cytoplasm enclosed within a membrane, which contains many biomolecules such as proteins and nucleic acids. Organisms can be classified as unicellular ,consisting of a single cell; including bacteria, or multicellular ,including plants and animals. The number of cells in plants and animals varies from species to species, it has been estimated that humans contain somewhere around 40 trillion cells. Most plant and animal cells are visible only under a microscope, with dimensions between 1 and 100 micrometres.";
        string cellPic = "Pics/cells-from-pixabay";

        string ERInfo = "The largest organelle in many cells, the endoplasmic reticulum (ER) is a network of interconnected membranous tubes and sacs that serve as locations for protein and lipid synthesis. The rough ER is covered with ribosomes where the information carried in messenger RNA molecules is translated into proteins. These newly-synthesized amino acid chains enter the lumen of the rough ER, where the proteins are modified by folding and the addition of molecules that can help target them for trafficking to different locations. ";
        string ERPic = "Pics/ER-thecellimagelibrary";
        string golgiInfo = "Part of the endomembrane system in the cytoplasm, the Golgi apparatus packages proteins into membrane-bound vesicles inside the cell before the vesicles are sent to their destination. The Golgi apparatus resides at the intersection of the secretory, lysosomal, and endocytic pathways. It is of particular importance in processing proteins for secretion, containing a set of glycosylation enzymes that attach various sugar monomers to proteins as the proteins move through the apparatus.";
        string golgiPic = "Pics/Golgi";

        string mitoInfo = "Mitochondria are organelles found in every complex organism. They produce arount ninety percent of the chemical energy that cells need to survive.They also produce chemicals that your body needs for other purposes, break down waste products so they are less harmful, and recycle some of those waste products to save energy. Mitochondria also have a special role in making cells die.";
        string mitoPic = "Pics/mitochondrion-cell image library";
        string nucleusInfo = "The cell nucleus contains all of the cell's genome, except for a small fraction of mitochondrial DNA, organized as multiple long linear DNA molecules in a complex with a large variety of proteins, such as histones, to form chromosomes. The genes within these chromosomes are structured in such a way to promote cell function. The nucleus maintains the integrity of genes and controls the activities of the cell by regulating gene expression. The nucleus is, therefore, the control center of the cell.";
        string nucleusPic = "Pics/cells-from-pixabay";

        string cytoskeletonInfo = "A cytoskeleton is present in the cytoplasm of all cells, including bacteria, and archaea. It is a complex, dynamic network of interlinking protein filaments that extends from the cell nucleus to the cell membrane. The cytoskeletal systems of different organisms are composed of similar proteins. In eukaryotes, the cytoskeletal matrix is a dynamic structure composed of three main proteins, which are capable of rapid growth or disassembly dependent on the cell's requirements. Its primary function is to give the cell its shape and mechanical resistance to deformation.";
        string cytoskeletonPic = "Pics/cytoskeleton-thecellimagelibrary";

        string SelenocysteineInfo = "Selenocysteine is an unusual amino acid of proteins, the selenium analogue of cysteine, in which a selenium atom replaces sulphur. Involved in the catalytic mechanism of seleno enzymes such as formate dehydrogenase of E. coli and mammalian glutathione peroxidase.";
        string SelenocysteinePic = "Pics/Seleno";
        bool active1 = false;
        bool active2 = false;
        bool active3 = false;
        bool active4 = false;
        bool active5 = false;
        bool active6 = false;
        bool active7 = false;
        bool active8 = false;
        bool active9 = false;

        public void Initialize(GraphicsDeviceManager g, ContentManager Content)
        {
            content = Content;
            spritebatch = new SpriteBatch(g.GraphicsDevice);
            UserInterface.Initialize(content, BuiltinThemes.hd);
            cgui = new CodexGui();
            gui = new InfoPanel();
            test = new Panel();
            test = cgui.GetPanel(content);
            
            test.Draggable = false;
            
           
            UserInterface.Active.AddEntity(test);
            
        }
        public void Activate()
        {
            codexActivate = true;//sets the boolean for wether the codex panel has been opened/activated 
        }
        public void Activate1()
        {
            if (codexActivate)//only activate info panels if the codex is already open
                                //once i have completed sampler will have to add additional if statement here checking if the specific codex info page is unlocked
                active1 = true;//activate info panel
        }
        public void Activate2()
        {
            if (codexActivate)
                active2 = true;
        }
        public void Activate3()
        {
            if (codexActivate)
                active3 = true;
        }
        public void Activate4()
        {
            if (codexActivate)
                active4 = true;
        }
        public void Activate5()
        {
            if (codexActivate)
                active5 = true;
        }
        public void Activate6()
        {
            if (codexActivate)
                active6 = true;
        }
        public void Activate7()
        {
            if (codexActivate)
                active7 = true;
        }
        public void Activate8()
        {
            if (codexActivate)
                active8 = true;
        }
        public void Activate9()
        {
            if (codexActivate)
                active9 = true;
        }

        public void Deactivate()
        {
            codexActivate = false;//deactivates the codex panel
            
            active1 = false;
            active2 = false;
            active3 = false;
            active4 = false;
            active5 = false;
            active6 = false;
            active7 = false;
            active8 = false;
            active9 = false;
        }
        public void Draw()
        {           
            //turns of the geonbit cursor
            UserInterface.Active.ShowCursor = false;
            //draws the panels stored in active ui
            UserInterface.Active.Draw(spritebatch);                 
        }
        public void Update(GameTime gameTime)
        {
            if (codexActivate)// if the codex has been activated
            {
                
                    if (test.Offset != new Vector2(0, 0))//and the panel has not reached the desired offset
                    { test.Offset = new Vector2(0, test.Offset.Y + 10); }//increment the offset each update
                
            }
            if (codexActivate == false)//if the codex has been deactivated
            {
                UserInterface.Active.RemoveEntity(test);//remove whatever panel was last stored 
                
                test = cgui.GetPanel(content);//reset panel to content start page
                
                UserInterface.Active.AddEntity(test);//send the panel to ui
                test.Offset = new Vector2(0, -540);//initial ofset variable
                if (test.Offset != new Vector2(0, -540))//if the panel has not reached the deactive position
                    { test.Offset = new Vector2(0, test.Offset.Y - 10); }//increment till we reach that position , this animation of the panel returning no longer works because we need to clear the old panels every cycle or the program locks up
               
            }
            if (active1)//if panel 1 active
            {
                
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);//load panel one into the codex user interface
                    test = gui.GetPanel(content, "The Cell", cellInfo, cellPic);
                    UserInterface.Active.AddEntity(test);
                }
                active1 = false;// after displaying panel set to false to allow the page to be reloaded(for instances of browsing back and forth through the info pages)
                
            }
            
            
            if (active2)
            {
                
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);
                    test = gui.GetPanel(content, "Nucleus", nucleusInfo, nucleusPic);
                    UserInterface.Active.AddEntity(test);
                }
                active2 = false;
            }
            if (active3)
            {
                
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);
                    test = gui.GetPanel(content, "Endoplasmic Reticulum", ERInfo, ERPic);
                    UserInterface.Active.AddEntity(test);
                }
                active3 = false;

            }
            if (active4)
            {
               
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);
                    test = gui.GetPanel(content, "Lysosome", lysosomeInfo, lysosomePic);
                    UserInterface.Active.AddEntity(test);
                }
                active4 = false;
            }
            if (active5)
            {
                
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);
                    test = gui.GetPanel(content, "Peroxisome", peroxisomeInfo, peroxisomePic);
                    UserInterface.Active.AddEntity(test);
                }
                active5 = false;

            }
            if (active6)
            {
                
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);
                    test = gui.GetPanel(content, "Golgi Apparatus", golgiInfo, golgiPic);
                    UserInterface.Active.AddEntity(test);
                }
                active6 = false;
            }
            if (active7)
            {
                
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);
                    test = gui.GetPanel(content, "Mitochondria", mitoInfo, mitoPic);
                    UserInterface.Active.AddEntity(test);
                }
                active7 = false;
            }
            if (active8)
            {
               
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);
                    test = gui.GetPanel(content, "Cytoskeleton", cytoskeletonInfo, cytoskeletonPic);
                    UserInterface.Active.AddEntity(test);
                }
                active8 = false;

            }
            if (active9)
            {
               
                if (codexActivate)// if the codex has been activated
                {
                    UserInterface.Active.RemoveEntity(test);
                    test = gui.GetPanel(content, "Selenocysteine", SelenocysteineInfo, SelenocysteinePic);
                    UserInterface.Active.AddEntity(test);
                }
                active9 = false;
            }

            UserInterface.Active.Update(gameTime);
        }
        

    }
}
