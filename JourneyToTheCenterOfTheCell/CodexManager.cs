//Author: Bruno Neto
//Version:1.0
using Microsoft.Xna.Framework;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace JourneyToTheCenterOfTheCell
{
    public class CodexManager
    {
        private SpriteBatch spritebatch;
        private ContentManager content;
        private Panel test;
        private CodexView codexGui;
        private InfoView infoGui;
        private bool codexActivate = false;
        private List <string> infoList;
        private List<string> picList;
        private List<InputHandler.keyStates> keyList;
        private List<Anchor> anchorList;
        private List<string> titleList;
        private List<Codex> codexList;

        public void Initialize(GraphicsDeviceManager g, ContentManager Content)
        {
            content = Content;
            spritebatch = new SpriteBatch(g.GraphicsDevice);
            UserInterface.Initialize(content, BuiltinThemes.hd);

            // could be better - but this is slightly more maintainable
            infoList = new List<string>();
            infoList.Add("Cells consist of cytoplasm enclosed within a membrane, which contains many biomolecules such as proteins and nucleic acids. Organisms can be classified as unicellular ,consisting of a single cell; including bacteria, or multicellular ,including plants and animals. The number of cells in plants and animals varies from species to species, it has been estimated that humans contain somewhere around 40 trillion cells. Most plant and animal cells are visible only under a microscope, with dimensions between 1 and 100 micrometres.");
            infoList.Add("The cell nucleus contains all of the cell's genome, except for a small fraction of mitochondrial DNA, organized as multiple long linear DNA molecules in a complex with a large variety of proteins, such as histones, to form chromosomes. The genes within these chromosomes are structured in such a way to promote cell function. The nucleus maintains the integrity of genes and controls the activities of the cell by regulating gene expression. The nucleus is, therefore, the control center of the cell.");
            infoList.Add("The largest organelle in many cells, the endoplasmic reticulum (ER) is a network of interconnected membranous tubes and sacs that serve as locations for protein and lipid synthesis. The rough ER is covered with ribosomes where the information carried in messenger RNA molecules is translated into proteins. These newly-synthesized amino acid chains enter the lumen of the rough ER, where the proteins are modified by folding and the addition of molecules that can help target them for trafficking to different locations.");
            infoList.Add("A lysosome is a membrane-bound organelle found in many animal cells. They are spherical vesicles that contain hydrolytic enzymes that can break down many kinds of biomolecules. A lysosome has a specific composition, of both its membrane proteins, and its lumenal proteins. The lumen's pH  is optimal for the enzymes involved in hydrolysis, analogous to the activity of the stomach. Besides degradation of polymers, the lysosome is involved in various cell processes, including secretion, plasma membrane repair, cell signaling, and energy metabolism.");
            infoList.Add("A peroxisome is a type of organelle known as a microbody, found in virtually all eukaryotic cells. They are involved in catabolism of very long chain fatty acids, branched chain fatty acids, D-amino acids, and polyamines, reduction of reactive oxygen species, specifically hydrogen peroxide, and biosynthesis of plasmalogens, i.e., ether phospholipids critical for the normal function of mammalian brains and lungs. They also contain approximately 10% of the total activity of two enzymes in the pentose phosphate pathway, which is important for energy metabolism.");
            infoList.Add("Part of the endomembrane system in the cytoplasm, the Golgi apparatus packages proteins into membrane-bound vesicles inside the cell before the vesicles are sent to their destination. The Golgi apparatus resides at the intersection of the secretory, lysosomal, and endocytic pathways. It is of particular importance in processing proteins for secretion, containing a set of glycosylation enzymes that attach various sugar monomers to proteins as the proteins move through the apparatus.");
            infoList.Add("Mitochondria are organelles found in every complex organism. They produce arount ninety percent of the chemical energy that cells need to survive.They also produce chemicals that your body needs for other purposes, break down waste products so they are less harmful, and recycle some of those waste products to save energy. Mitochondria also have a special role in making cells die.");
            infoList.Add("A cytoskeleton is present in the cytoplasm of all cells, including bacteria, and archaea. It is a complex, dynamic network of interlinking protein filaments that extends from the cell nucleus to the cell membrane. The cytoskeletal systems of different organisms are composed of similar proteins. In eukaryotes, the cytoskeletal matrix is a dynamic structure composed of three main proteins, which are capable of rapid growth or disassembly dependent on the cell's requirements. Its primary function is to give the cell its shape and mechanical resistance to deformation.");
            infoList.Add("Selenocysteine is an unusual amino acid of proteins, the selenium analogue of cysteine, in which a selenium atom replaces sulphur. Involved in the catalytic mechanism of seleno enzymes such as formate dehydrogenase of E. coli and mammalian glutathione peroxidase.");

            picList = new List<string>();
            picList.Add("Pics/cells-from-pixabay");
            picList.Add("Pics/cells-from-pixabay");
            picList.Add("Pics/ER-thecellimagelibrary");
            picList.Add("Pics/Lysosome-wikimedia");
            picList.Add("Pics/782px-Peroxisome-wikimedia");
            picList.Add("Pics/Golgi");
            picList.Add("Pics/mitochondrion-cell image library");
            picList.Add("Pics/cytoskeleton-thecellimagelibrary");
            picList.Add("Pics/Seleno");

            keyList = new List<InputHandler.keyStates>();
            keyList.Add(InputHandler.keyStates.Cell);
            keyList.Add(InputHandler.keyStates.Nucleus);
            keyList.Add(InputHandler.keyStates.ER);
            keyList.Add(InputHandler.keyStates.Lysosome);
            keyList.Add(InputHandler.keyStates.Peroxisome);
            keyList.Add(InputHandler.keyStates.Golgi);
            keyList.Add(InputHandler.keyStates.Mitochondria);
            keyList.Add(InputHandler.keyStates.Cytoskeleton);
            keyList.Add(InputHandler.keyStates.Selenocysteine);

            anchorList = new List<Anchor>();
            anchorList.Add(Anchor.TopLeft);
            anchorList.Add(Anchor.TopCenter);
            anchorList.Add(Anchor.TopRight);
            anchorList.Add(Anchor.CenterLeft);
            anchorList.Add(Anchor.Center);
            anchorList.Add(Anchor.CenterRight);
            anchorList.Add(Anchor.BottomLeft);
            anchorList.Add(Anchor.BottomCenter);
            anchorList.Add(Anchor.BottomRight);

            titleList = new List<string>();
            titleList.Add("The Cell");
            titleList.Add("Nucleus");
            titleList.Add("Endoplasmic Reticulum");
            titleList.Add("Lysosome");
            titleList.Add("Peroxisome");
            titleList.Add("Golgi Apparatus");
            titleList.Add("Mitochondria");
            titleList.Add("Cytoskeleton");
            titleList.Add("Selenocysteine");

            codexList = new List<Codex>();
            for(int ii = 0; ii < infoList.Count; ii += 1)
            {
                Codex newCodex = new Codex(picList[ii], infoList[ii], keyList[ii], anchorList[ii], titleList[ii]);
                codexList.Add(newCodex);
            }

            codexGui = new CodexView(codexList);
            infoGui = new InfoView();
            test = new Panel();

            codexGui.SetPanel(content);
            test = codexGui.GetPanel();
            
            test.Draggable = false;
           
            UserInterface.Active.AddEntity(test);
            
        }

        /** 
        *   @brief sets the boolean if the codex panel has been opened/activated 
        *   @see 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void Activate()
        {
            codexActivate = true;
        }

        /** 
        *   @brief deactivates the codex panel
        *   @see 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public void Deactivate()
        {
            codexActivate = false;
        }

        public void Draw()
        {           
            //turns off the geonbit cursor
            UserInterface.Active.ShowCursor = false;
            //draws the panels stored in active ui
            UserInterface.Active.Draw(spritebatch);                 
        }

        private void CodexDown(bool inputActivation)
        {
            // if the codex has been activated
            if (inputActivation)
            {
                //and the panel has not reached the desired offset
                if (test.Offset != new Vector2(0, 0))
                {
                    //increment the offset each update
                    test.Offset = new Vector2(0, test.Offset.Y + 10);
                }

            }
        }

        private void CodexUp(bool inputActivation)
        {
            if(inputActivation==false)
            {
                //remove whatever panel was last stored 
                UserInterface.Active.RemoveEntity(test);
                codexGui.SetPanel(content);
                //reset panel to content start page
                test = codexGui.GetPanel();
                //send the panel to ui
                UserInterface.Active.AddEntity(test);
                //initial ofset variable
                test.Offset = new Vector2(0, -540);
                //if the panel has not reached the deactive position
                if (test.Offset != new Vector2(0, -540))
                {
                    //increment till we reach that position , 
                    //this animation of the panel returning no longer works 
                    //because we need to clear the old panels every cycle or the program locks up
                    test.Offset = new Vector2(0, test.Offset.Y - 10);
                }
            }
        }

        public void Update(GameTime gameTime, InputHandler.keyStates inputState)
        {
            // if the codex has been activated
            if (inputState == InputHandler.keyStates.CodexDown)
            {
                Activate();
            }

            CodexDown(codexActivate);
            //if the codex has been deactivated
            if (inputState == InputHandler.keyStates.CodexUp)
            {
                Deactivate();
            }

            CodexUp(codexActivate);

            for(int ii = 0; ii < codexList.Count; ii += 1)
            {
                if(inputState == codexList[ii].GetKeyBoardState())
                {
                    if(codexActivate)
                    {
                        UserInterface.Active.RemoveEntity(test);
                        infoGui.SetPanel(content, codexList[ii].GetItemTitle(), codexList[ii].GetItemInfo(), codexList[ii].GetFinalTexture());
                        test = infoGui.GetPanel();
                        UserInterface.Active.AddEntity(test);
                    }
                }
                codexList[ii].SetItemActive(false);
            }

            UserInterface.Active.Update(gameTime);
        }
        
    }
}
