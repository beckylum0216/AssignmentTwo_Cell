using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace JourneyToTheCenterOfTheCell
{
    class NPCAttack : INPCState
    {
        Subject camera;

        public NPCAttack(Subject inputSubject)
        {
            this.camera = inputSubject;
        }

        public Vector3 Animate(NPC npcContext, float deltaTime, float fps)
        {
            Vector3 tempDirection = npcContext.actorPosition - this.camera.subjectPosition;
            tempDirection.Normalize();

            Vector3 resultVector = -tempDirection * npcContext.actorSpeed * deltaTime * fps;

            return resultVector;
        }
    }
}
