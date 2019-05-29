using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell.Test
{
    class TestCodex
    {
        [Test]
        public void Test_000_Codex()
        {
            try
            {
                String testTexture = "blah";
                String testInfo = "blah";
                InputHandler.keyStates testState = InputHandler.keyStates.Cytoskeleton;
                Anchor testAnchor = Anchor.Auto;
                String testTitle = "blah";

                Codex testCode = new Codex(testTexture, testInfo, testState, testAnchor, testTitle);

            }
            catch (Exception e)
            {

            }
        }

    }
}
