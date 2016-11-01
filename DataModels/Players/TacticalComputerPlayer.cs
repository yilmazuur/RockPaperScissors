using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class TacticalComputerPlayer : PlayerBase
    {
        public TacticalComputerPlayer()
            : base() 
        {
            Name = "TacticCP";
        }
        public override IMove Move()
        {
            if (PlayedMoves.Count == 0)
            {
                return generateRandomMove();
            }
            else
            {
                IMove lastMove = PlayedMoves.Last();
                //If we add lizard, spock etc, then we have to pick a random movetype among defeaters of last move.
                //We won't have to edit this code, when we add new movetypes in later.
                MoveType beatLast = lastMove.LoseAgainst[new Random().Next(lastMove.LoseAgainst.Count)]; 
                return createMoveFromType(beatLast);
            }
        }
    }
}
