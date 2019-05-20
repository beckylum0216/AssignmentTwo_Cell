using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    class NavManager
    {
        List<NavNode> obstacleList;

        NavManager()
        {
            this.obstacleList = new List<NavNode>();
        }

        public void AddObstacleList(NavNode inputNode)
        {
            this.obstacleList.Add(inputNode);
        }
    }
}
