using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Scissors : IMove
    {
        public MoveType TypeOfMove { get; set; }
        public List<MoveType> WinAgainst { get; set; }
        public List<MoveType> LoseAgainst { get; set; }

        public Scissors()
        {
            TypeOfMove = MoveType.Scissors;
            WinAgainst = new List<MoveType>() { MoveType.Paper };
            LoseAgainst = new List<MoveType>() { MoveType.Rock };
        }
    }
}
