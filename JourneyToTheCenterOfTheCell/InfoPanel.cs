//Author:Bruno Neto
//CodexGui: this class forms the basic ui for the detailed codex page to be loaded by the codex class
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JourneyToTheCenterOfTheCell
{
    class InfoPanel
    {

        public Panel GetPanel(ContentManager Content,string title, string info, string infoImage)
        {
            Panel newPanel = new Panel();
            Header pageHead = new Header(title, Anchor.TopCenter, new Vector2(0, 0));
            pageHead.AddChild(new HorizontalLine(Anchor.Auto));
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

            string filePath = infoImage;
            Image i1 = new Image(Content.Load<Texture2D>(filePath), new Vector2(120, 120), ImageDrawMode.Stretch, Anchor.TopLeft, new Vector2(0, 0));// info pic
            i1.AddChild(new Paragraph(info, Anchor.CenterLeft, null, new Vector2(400,400), 0.8f));//pic description
            newPanel.AddChild(i1);           

            return newPanel;
        }
    }
}

