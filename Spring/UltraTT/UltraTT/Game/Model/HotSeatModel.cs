using System;
using GameLogic;
using UltraTT.Model;

namespace UltraTT.Game.Model
{
    public class HotSeatModel : GameModel
    {
        public override void Step(int bigCell, int position)
        {
            if (CurrentCell != -1 && CurrentCell != bigCell)
            {
                return;
            }

            base.Step(bigCell, position);
        }
    }
}
