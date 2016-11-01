using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    /// <summary>
    /// This is the interface of all moves have to implement
    /// </summary>
    public interface IMove
    {
        /// <summary>
        /// That is the type of move
        /// </summary>
        MoveType TypeOfMove { get; set; }
        /// <summary>
        /// This will help us to detect which move won
        /// Even when we extend the game with new type of moves like spock, lizard etc
        /// </summary>
        List<MoveType> WinAgainst { get; set; }
        /// <summary>
        /// This will help us to detect which move lost
        /// Even when we extend the game with new type of moves like spock, lizard etc
        /// 
        /// WinAgainst and LoseAgainst are seperated, 
        /// so if we want, we can add some logic like: a move doesn't have to lose, if it doesn't win
        /// For example we can score tie with spock and lizard if we wish
        /// </summary>
        List<MoveType> LoseAgainst { get; set; }
    }
}
