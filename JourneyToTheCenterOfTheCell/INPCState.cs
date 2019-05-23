using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    public interface INPCState
    {
        Vector3 Animate(NPC npcContext, float deltaTime, float fps);
    }
}
