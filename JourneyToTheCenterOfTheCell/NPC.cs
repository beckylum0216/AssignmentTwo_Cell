using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JourneyToTheCenterOfTheCell
{
    class NPC : Actor
    {
        List<Vector3> npcWaypoints;

        NPC(ContentManager content, Actor inputActor, List<Vector3> inputWaypoints)
        {
            this.npcWaypoints = inputWaypoints;
        }

        public override Actor ActorClone(ContentManager Content, string modelFile, string textureFile, Vector3 inputPosition, Vector3 inputRotation, float inputScale, Vector3 inputAABBOffset)
        {
            return this.MemberwiseClone() as Actor;
        }

        public override Matrix ActorUpdate(Vector3 inputVector)
        {
            throw new NotImplementedException();
        }
    }
}
