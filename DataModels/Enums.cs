using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public enum MoveType
    {
        Rock = 0,
        Paper = 1,
        Scissors = 2
    }

    //public enum PlayerType
    //{ 
    //    Human = 0,
    //    RandomComputerPlayer = 1,
    //    TacticalComputerPlayer = 2
    //}

    public enum GameType
    {
        AgainstHuman = 1,
        AgainstRandomComputer = 2,
        AgainstTacticalComputer = 3
    }
}
