using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Paper : IMove
    {
        public MoveType TypeOfMove { get; set; }
        public List<MoveType> WinAgainst { get; set; }
        public List<MoveType> LoseAgainst { get; set; }

        public Paper()
        {
            TypeOfMove = MoveType.Paper;
            WinAgainst = new List<MoveType>() { MoveType.Rock };
            LoseAgainst = new List<MoveType>() { MoveType.Scissors };
        }
    }
}
