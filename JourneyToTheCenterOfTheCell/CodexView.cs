//Author:Bruno Neto
//CodexGui: this class forms the basic ui for the codex page to be loaded by the codex class
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JourneyToTheCenterOfTheCell
{
    class CodexView
    {

        public Panel GetPanel(ContentManager Content, bool o1,bool o2,bool o3, bool o4, bool o5, bool o6, bool o7, bool o8, bool o9)
        {
            Panel newPanel = new Panel();
            Header pageHead = new Header("Codex", Anchor.TopCenter,new Vector2(0,-18));
            pageHead.AddChild(new HorizontalLine(Anchor.BottomCenter));
            // add title and text
            newPanel.AddChild(pageHead);
            string filePath;

            if (o1) { filePath = "Pics/cells-from-pixabay"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i1 = new Image(Content.Load<Texture2D>(filePath),new Vector2(120, 120),ImageDrawMode.Stretch, Anchor.TopLeft,new Vector2(0,10));// first pic
            i1.AddChild(new Paragraph("Cell 1.",Anchor.TopLeft,null,null,0.8f));//pic description
            newPanel.AddChild(i1);

            if (o2) { filePath = "Pics/cells-from-pixabay"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i2 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.TopCenter, new Vector2(0, 10));// 2nd pic
            i2.AddChild(new Paragraph("Nucleus 2.", Anchor.TopCenter, null, null, 0.8f));//pic description
            newPanel.AddChild(i2);

            if (o3) { filePath = "Pics/ER-thecellimagelibrary"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i3 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.TopRight, new Vector2(0, 10));// 3rd pic
            i3.AddChild(new Paragraph("Endoplasmic Reticulum 3.", Anchor.TopRight, null, null, 0.8f));//pic description
            newPanel.AddChild(i3);

            if (o4) { filePath = "Pics/Lysosome-wikimedia"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i4 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.CenterLeft, new Vector2(0, 10));// first pic
            i4.AddChild(new Paragraph("Lysosome 4.", Anchor.CenterLeft, null, null, 0.8f));//pic description
            newPanel.AddChild(i4);

            if (o5) { filePath = "Pics/782px-Peroxisome-wikimedia"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i5 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.Center, new Vector2(0, 10));// first pic
            i5.AddChild(new Paragraph("Peroxisome 5.", Anchor.Center, null, null, 0.8f));//pic description
            newPanel.AddChild(i5);

            if (o6) { filePath = "Pics/Golgi"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i6 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.CenterRight, new Vector2(0, 10));// first pic
            i6.AddChild(new Paragraph("Golgi Apparatus 6.", Anchor.CenterRight, null, null, 0.8f));//pic description
            newPanel.AddChild(i6);

            if (o7) { filePath = "Pics/mitochondrion-cell image library"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i7 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.BottomLeft);// first pic
            i7.AddChild(new Paragraph("Mitochondria 7.", Anchor.BottomLeft, null, null, 0.8f));//pic description
            newPanel.AddChild(i7);

            if (o8) { filePath = "Pics/cytoskeleton-thecellimagelibrary"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i8 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.BottomCenter);// first pic
            i8.AddChild(new Paragraph("Cytoskeleton 8.", Anchor.BottomCenter, null, null, 0.8f));//pic description
            newPanel.AddChild(i8);

            if (o9) { filePath = "Pics/Seleno"; }
            else { filePath = "Pics/lockedInfoCodex"; }
            Image i9 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.BottomRight);// first pic
            i9.AddChild(new Paragraph("Selenocysteine 9.", Anchor.BottomRight, null, null, 0.8f));//pic description
            newPanel.AddChild(i9);




            return newPanel;
        }
    }
}
