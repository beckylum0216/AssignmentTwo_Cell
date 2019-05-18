using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace JourneyToTheCenterOfTheCell
{
    class FSM<T> where T : struct, IConvertible
    {
        public T State { get; private set; }

        private const BindingFlags FLAGS = BindingFlags.NonPublic | BindingFlags.Instance;

        private IDictionary<T, MethodInfo> states = new Dictionary<T, MethodInfo>();
        private IDictionary<T, MethodInfo> transitions = new Dictionary<T, MethodInfo>();


        public FSM(T Wander)
        {
            if(!typeof(T).IsEnum) //if T is not of type Enum throw and exception
             {
                throw new ArgumentException("T must be an enumeration");
            }


            //adding states to cache
            foreach(T value in typeof(T).GetEnumValues())
            {
                var s = GetType().GetMethod(value.ToString() + "State", FLAGS);
                if(s != null)
                {
                    states.Add(value, s);
                }

                var t = GetType().GetMethod(value.ToString() + "Transistion", FLAGS);
                if(t != null)
                {
                    transitions.Add(value, t);
                }
            }

            State = Wander;

        }

        public void Transition(T next)
        {
            if (transitions.TryGetValue(next, out MethodInfo method))
            {
                method.Invoke(this, new Object[] { State });
            }
           State = next;
        }

        public void Update(/*pass in players position*/)
        {
            if(states.TryGetValue(State, out MethodInfo method))
            {
                method.Invoke(this, null /*change to player position when ready*/);
            }
        }

        /*
        bool moveTo(Vector3 currentPos, Vector3 targetPos, Vector3 currentVel, double timeElapsed, double offset)
        {
            Vector3 toTarget = targetPos - currentPos;
            toTarget.Normalize();
            if(toTarget == Vector3.Zero)
            {
                return true;
            }

            currentVel = toTarget * currentVel.Length();
            Vector3 displacement = currentVel * (float)timeElapsed;
            Vector3 newPos = currentPos + displacement;

            Vector3 realTargetPosition = targetPos - toTarget * (float)offset;

            Vector3 toRealTarget = realTargetPosition - newPos;
            toRealTarget.Normalize();
            if(toRealTarget == Vector3.Zero)
            {
                currentPos = realTargetPosition;
                return true;
            }

            float dp = Vector3.Dot(toRealTarget, toTarget);
            if(dp<0.0)//enemy has passed the player
            {
                currentPos = realTargetPosition;
                return true;
            }

            currentPos = newPos;
            return false;
        }
        */

        
    }
}