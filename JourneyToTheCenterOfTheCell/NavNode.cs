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
        Vector3 currentPosition;

        NavNode(Vector3 inputPosition)
        {
            this.currentPosition = inputPosition;
        }

    }
}
