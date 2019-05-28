using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    /** 
    *   @author Rebecca Lim 
    *   @brief interface for the NPC state machine
    *   @see
    *	@param 
    *	@param  
    *	@param 
    *	@param 
    *	@return 
    *	@pre 
    *	@post 
    */
    public interface INPCState
    {
        Vector3 Animate(NPC npcContext, float deltaTime, float fps);
    }
}
