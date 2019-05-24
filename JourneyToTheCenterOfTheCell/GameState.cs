using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheCenterOfTheCell
{
    /**
     * @brief
     * @see https://gamedevelopment.tutsplus.com/tutorials/finite-state-machines-theory-and-implementation--gamedev-11867
     * 
     */
    public abstract class GameState
    {
        public abstract void Initialise(GameContext gameCtx);
        public abstract void Update(GameContext gameCtx);
        public abstract void Draw(GameContext gameCtx);
    }
}
