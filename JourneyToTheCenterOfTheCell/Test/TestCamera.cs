using Microsoft.Xna.Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell.Test
{
    class TestCamera
    {
        [Test]
        public void Test_000_Camera()
        {
            try
            {
                Game1 testGame = new Game1();
                ModelHandler tempHandler = new ModelHandler(testGame.Content, 1,1,1,1,1);
                Vector3 camEyeVector = new Vector3(0, 0, 0);
                Vector3 camPositionVector = Vector3.Add(new Vector3(0, 0, 0), new Vector3(0, 1.6f, 0));
                Vector3 deltaVector = new Vector3(0, 0, 0.001f);
                Vector3 AABBOffsetCamera = new Vector3(0.5f, 0.25f, 0.5f);
                Matrix theCamera = Matrix.CreateLookAt(camPositionVector, camEyeVector, Vector3.Up);
                Camera testCam = new Camera(testGame.Content, theCamera, camPositionVector, camEyeVector, deltaVector, AABBOffsetCamera, tempHandler);
                //Assert.Pass();
            }
            catch (Exception e)
            {
                //Assert.Fail();
            }
        }
    }
}
