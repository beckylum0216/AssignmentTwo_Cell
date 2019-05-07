using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MonoGame.Extended.Gui;
//using MonoGame.Extended.Gui.Controls;
using GeonBit.UI;
using GeonBit.UI.Entities;

namespace JourneyToTheCenterOfTheCell
{
    class testGui
    {
        /*
        public GuiScreen GetScreen()
        {
            GuiSkin guiSkin = new GuiSkin();
            GuiScreen guiScreen = new GuiScreen(guiSkin);
            GuiStackPanel newPanel = TestStackPanel();

            guiScreen.Controls.Add(newPanel);

            return guiScreen;
        }

        public GuiStackPanel TestStackPanel()
        {
            GuiStackPanel testStack = new GuiStackPanel();

            GuiButton testButton = new GuiButton();
            testButton.Text = "Eat me!";

            testStack.Controls.Add(testButton);

            return testStack;
        }
        */

        public Panel GetPanel()
        {
            Panel newPanel = new Panel();
            // add title and text
            newPanel.AddChild(new Header("Example Panel"));
            newPanel.AddChild(new HorizontalLine());
            newPanel.AddChild(new Paragraph("This is a simple panel with a button."));

            // add a button at the bottom
            newPanel.AddChild(new Button("Click Me!", ButtonSkin.Default, Anchor.BottomCenter));
            return newPanel;
        }

    }
}
