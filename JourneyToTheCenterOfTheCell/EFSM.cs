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

            void WanderState(/*give player and this enemies positions*/)
            {
                Console.Out.WriteLine("Wandering... \n");
                if (true /*  Vector3.Distance(enemyPosition, playerPosition) < 50.0f  */)
                    Transition(EnemyStates.Attack);
                /*else
                    *  Compute new position based on wandering
                    */
            }
            
            void AttackState(/*give player and this enemies positions*/)
            {
                Console.Out.WriteLine("Attacking...\n");
                if (true/*  Vector3.Distance(enemyPosition, playerPosition) > 50.0f */)
                    Transition(EnemyStates.Wander);
                /*else
                    *  Compute new position based on attacking
                    */
                    /*test*/
        }



    }
}