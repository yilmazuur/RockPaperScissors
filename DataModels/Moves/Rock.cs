using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Rock : IMove
    {
        public MoveType TypeOfMove { get; set; }
        public List<MoveType> WinAgainst { get; set; }
        public List<MoveType> LoseAgainst { get; set; }

        public Rock() 
        {
            TypeOfMove = MoveType.Rock;
            WinAgainst = new List<MoveType>() { MoveType.Scissors };
            LoseAgainst = new List<MoveType>() { MoveType.Paper};
        }
    }
}
