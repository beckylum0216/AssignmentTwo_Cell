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

        public Panel GetPanel(ContentManager Content)
        {
            Panel newPanel = new Panel();
            Header pageHead = new Header("Codex", Anchor.TopCenter,new Vector2(0,-18));
            pageHead.AddChild(new HorizontalLine(Anchor.BottomCenter));
            // add title and text
            newPanel.AddChild(pageHead);

            // newPanel.AddChild(new Paragraph("This is a simple panel for testing codex."));
            //  public Paragraph(
            //       string text,
            //      Anchor anchor = Anchor.Auto,
            //      Nullable<Vector2> size = null,
            //     Nullable<Vector2> offset = null,
            //     Nullable<float> scale = null
            // )

            string filePath = "Pics/lockedInfoCodex";
            Image i1 = new Image(Content.Load<Texture2D>(filePath),new Vector2(120, 120),ImageDrawMode.Stretch, Anchor.TopLeft,new Vector2(0,10));// first pic
            i1.AddChild(new Paragraph("Cell",Anchor.Auto,null,null,0.8f));//pic description
            newPanel.AddChild(i1);
            Image i2 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.TopCenter, new Vector2(0, 10));// first pic
            i2.AddChild(new Paragraph("Lysosome", Anchor.Auto, null, null, 0.8f));//pic description
            newPanel.AddChild(i2);
            Image i3 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.TopRight, new Vector2(0, 10));// first pic
            i3.AddChild(new Paragraph("Peroxisome", Anchor.Auto, null, null, 0.8f));//pic description
            newPanel.AddChild(i3);
            Image i4 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.CenterLeft);// first pic
            i4.AddChild(new Paragraph("Endoplasmic Reticulum", Anchor.Auto, null, null, 0.8f));//pic description
            newPanel.AddChild(i4);
            Image i5 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.Center);// first pic
            i5.AddChild(new Paragraph("Golgi Apparatus", Anchor.Auto, null, null, 0.8f));//pic description
            newPanel.AddChild(i5);
            Image i6 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.CenterRight);// first pic
            i6.AddChild(new Paragraph("Mitochondria", Anchor.Auto, null, null, 0.8f));//pic description
            newPanel.AddChild(i6);
            Image i7 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.BottomLeft);// first pic
            i7.AddChild(new Paragraph("nucleus", Anchor.Auto, null, null, 0.8f));//pic description
            newPanel.AddChild(i7);
            Image i8 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.BottomCenter);// first pic
            i8.AddChild(new Paragraph("cytoskeleton", Anchor.Auto, null, null, 0.8f));//pic description
            newPanel.AddChild(i8);
            Image i9 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.BottomRight);// first pic
            i9.AddChild(new Paragraph("Selenocysteine", Anchor.Auto, null, null, 0.8f));//pic description
            newPanel.AddChild(i9);




            return newPanel;
        }
    }
}
