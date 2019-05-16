
//author: Bruno Neto 
// class for handling unlocking of codex entries and other proccesses handles the game logic of sampling 
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace JourneyToTheCenterOfTheCell
{
    class Sampler
    {
        Actor target;
        int targetId;
        Vector3 position;
        bool samplePressed = false;

        public void UnlockCodexEntry(int id, CodexManager codex)
        {
            switch (id)
            {
                case 1:
                    codex.Unlock1();
                    break;
                case 2:
                    codex.Unlock2();
                    break;
                case 3:
                    codex.Unlock3();
                    break;
                case 4:
                    codex.Unlock4();
                    break;
                case 5:
                    codex.Unlock5();
                    break;
                case 6:
                    codex.Unlock6();
                    break;
                case 7:
                    codex.Unlock7();
                    break;
                case 8:
                    codex.Unlock8();
                    break;
                case 9:
                    codex.Unlock9();
                    break;
                default:
                    break;

            }
            
        }

        void IncreaseShieldEnergy() { }
        void TriggerEndGame() { }
        Vector3 GetPosition(GameManager gm)
        {
            
            position = gm.GetCamera().GetCameraPosition();
            return position;
        }
        
       
        public int GetTargetActorID(Actor targetActor)
        {
            int id = targetActor.GetId();//thoretical get id for now will have to modify to be able to return what object type it is assigned should return1 by default
            return id;

        }
        public void CheckForTarget(GameManager gm)
        {
            Vector3 maxRng = new Vector3(position.X+1,position.Y+1,position.Z+1);//need to basically check for every nearby unit only a few provided here as example
            Vector3 minRng = new Vector3(position.X-1, position.Y-1, position.Z-1);
            List<Actor> potTargets = gm.GetActorList();

            for (int i = 0; i < potTargets.Count; i++)
            {
                if (potTargets[i].actorPosition == position)
                {
                    target = potTargets[i];
                    potTargets.RemoveAt(i);
                }
                else if (potTargets[i].actorPosition == minRng)
                {
                    target = potTargets[i];
                    potTargets.RemoveAt(i);
                }
                else if (potTargets[i].actorPosition == maxRng)
                {
                    target = potTargets[i];
                    potTargets.RemoveAt(i);
                }
                else
                { target = null; }
            }
                                      
        }
        public void Update(GameManager gm, CodexManager codex)
        {
            GetPosition(gm);
            CheckForTarget(gm);
            if (target != null)
            {
                targetId = GetTargetActorID(target);
                UnlockCodexEntry(targetId, codex);
                if (targetId == 7)
                {
                    IncreaseShieldEnergy();
                }

                else if (targetId == 9)
                {
                    TriggerEndGame();
                }
                
                
            }
            

        }


    }
}
