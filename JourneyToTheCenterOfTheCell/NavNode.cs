using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    class NavNode
    {
        public Vector3 currentPosition;
        public float fScore;
        public float gScore;
        public float hScore;

        public NavNode(Vector3 inputPosition, float inputGScore, float inputHScore)
        {
            this.currentPosition = inputPosition;
            this.gScore = inputGScore;
            this.hScore = inputHScore;
            this.fScore = gScore + hScore;
        }

    }
}
