using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace JourneyToTheCenterOfTheCell
{
    public class NPCWander : INPCState
    {
        List<Vector3> npcWaypoints;
        int npcWaypointIndex;
        int tempIndex;
        Vector3 resultVector;
        Vector3 tempDirection;

        public NPCWander(NPC npcContext)
        {
            this.npcWaypoints = npcContext.GetNPCWaypoints();
            this.npcWaypointIndex = 0;
            this.tempIndex = 0;
            resultVector = new Vector3(0, 0, 0);
            tempDirection = new Vector3(0, 0, 0);

        }

        public Vector3 Animate(NPC npcContext, float deltaTime, float fps)
        {
            
            tempIndex = this.npcWaypointIndex % this.npcWaypoints.Count;
            //Debug.WriteLine("tempIndex: " + tempIndex);


            this.npcWaypoints[tempIndex].Normalize();

            if (npcContext.actorPosition.Length() > this.npcWaypoints[tempIndex].Length())
            {
                tempDirection = npcContext.actorPosition - this.npcWaypoints[tempIndex];
                tempDirection.Normalize();
                this.npcWaypointIndex++;
                //Debug.WriteLine("Index: " + this.npcWaypointIndex);
            }
            else
            {
                tempDirection = npcContext.actorPosition - this.npcWaypoints[tempIndex];
                tempDirection.Normalize();
            }

            //tempDirection = npcContext.actorPosition - this.npcWaypoints[tempIndex];
            //tempDirection.Normalize();
            //this.npcWaypointIndex++;

            resultVector = -tempDirection * npcContext.actorSpeed * deltaTime * fps;

            return resultVector;
        }
    }
}
