//Author:Bruno Neto
//infoview: this class forms the basic ui for the detailed codex page to be loaded by the codex class
//Version 1.0
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JourneyToTheCenterOfTheCell
{
	/// @brief class for InfoView the panel and layout of an individual codex detail page entry
    class InfoView
    {
        Panel infoPanel;

/** 
*   @brief mutator for codex detail page entry 
*   @see
*	@param Content the current game content manager 
*	@param title the detail page title string
*	@param info the detail page info string
*	@param infoImage the filepath for the detail page
*	@return void
*	@pre Content must be initialised and valid, the info image string must point to an image file
*	@post 
*/
        public void SetPanel(ContentManager Content, string title, string info, string infoImage)
        {
            infoPanel = new Panel();

            Header pageHead = new Header(title, Anchor.TopLeft, new Vector2(0, 0));
            //pageHead.AddChild(new HorizontalLine(Anchor.Auto));
            // add title and text


            //newPanel.AddChild(new Paragraph(info));

            //  public Paragraph(
            //       string text,
            //      Anchor anchor = Anchor.Auto,
            //      Nullable<Vector2> size = null,
            //     Nullable<Vector2> offset = null,
            //     Nullable<float> scale = null
            // )

            string filePath = infoImage;

            Image i1 = new Image(Content.Load<Texture2D>(filePath), new Vector2(320, 210), ImageDrawMode.Stretch, Anchor.TopCenter, new Vector2(0, 30));// info pic
            infoPanel.AddChild(pageHead);
            infoPanel.AddChild(i1);
            infoPanel.AddChild(new Paragraph(info, Anchor.CenterLeft, null, new Vector2(0, 130), 0.8f));//pic description



        }
/** 
*   @brief accesor for infoview panel 
*   @see
*	@param 
*	@return infoPanel the actual panel to represent the view
*	@pre 
*	@post 
*/
        public Panel GetPanel()
        {
            return infoPanel;
        }
    }
}

