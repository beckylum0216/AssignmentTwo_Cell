using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    enum EnemyStates { Wander, Attack };
    class EFSM : FSM<EnemyStates>
    {
        public EFSM() : base(EnemyStates.Wander) { }

            void WanderState()
            {
                Console.Out.WriteLine("Wandering... \n");
                if (true /*Enemy Position is near player, switch to attack*/)
                    Transition(EnemyStates.Attack);
                /*else
                 *  Compute new position based on wandering
                 */
            }
            
            void AttackState()
            {
                Console.Out.WriteLine("Attacking...\n");
                if (true/*Player is out of range, switch to wander*/)
                    Transition(EnemyStates.Wander);
                /*else
                *  Compute new position based on attacking
                */

        }



    }
}