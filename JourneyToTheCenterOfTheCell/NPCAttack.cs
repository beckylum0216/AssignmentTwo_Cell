using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace JourneyToTheCenterOfTheCell
{
    /// @author
    /// <summary>
    /// Concrete class for the NPC attack state
    /// </summary>
    class NPCAttack : INPCState
    {
        Subject camera;

        /** 
        *   @brief parameterised constructor for observing the subject
        *   @see 
        *	@param inputSubject the camera
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return 
        *	@pre 
        *	@post 
        */
        public NPCAttack(Subject inputSubject)
        {
            this.camera = inputSubject;
        }

        /** 
        *   @brief concrete class of the fsm animating the attack
        *   @see 
        *	@param 
        *	@param 
        *	@param  
        *	@param 
        *	@param 
        *	@param 
        *	@param 
        *	@return resultVector the attack vector
        *	@pre 
        *	@post 
        */
        public Vector3 Animate(NPC npcContext, float deltaTime, float fps)
        {
            Vector3 tempDirection = npcContext.actorPosition - this.camera.subjectPosition;
            tempDirection.Normalize();

            Vector3 resultVector = -tempDirection * npcContext.actorSpeed * deltaTime * fps;

            return resultVector;
        }
    }
}
