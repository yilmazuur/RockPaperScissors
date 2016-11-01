using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public interface IGame
    {
        int CurrentTurnCount { get; set; }
        GameType TypeOfGame { get; set; }
        /// <summary>
        /// We can increase the player count we wish in the later
        /// In that case, we will use the key value of this dictionary as identifier(as peerID) of the player.
        /// </summary>
        Dictionary<int, IPlayer> Players { get; set; }
        void Play();
    }
}
