using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Game : IGame
    {
        /// <summary>
        /// Best of 3, Best of 5 etc
        /// </summary>
        private readonly int _maxTurnCount;

        public int CurrentTurnCount { get; set; }
        public GameType TypeOfGame { get; set; }

        /// <summary>
        /// We can increase the player count we wish in the later
        /// In that case, we will use the key value of this dictionary as identifier(as peerID) of the player.
        /// </summary>
        public Dictionary<int, IPlayer> Players { get; set; }

        public Game(GameType typeOfGame)
        {
            _maxTurnCount = Convert.ToInt32(ConfigurationManager.AppSettings["MaxTurnCount"]);
            TypeOfGame = typeOfGame;
            setupForTwoPlayers();
        }

        public void Play()
        {
            while (CurrentTurnCount < _maxTurnCount)
            {
                Console.WriteLine(Constants.NEW_ROUND);
                swingHands();
                checkWhoWonTheTurnForTwoPlayers();
                if (getMaxWinCount() > (_maxTurnCount / 2)) //somebody reach best of 3, best of 5 etc.
                    break;

                CurrentTurnCount++;
            }
            printWinnerOfTheGame();
        }

        private void setupForTwoPlayers()
        {
            CurrentTurnCount = 0;
            Players = new Dictionary<int, IPlayer>();
            IPlayer firstPlayer = new HumanPlayer(0);
            Players.Add(0, firstPlayer);
            IPlayer secondPlayer = null;
            if (TypeOfGame == GameType.AgainstHuman)
            {
                secondPlayer = new HumanPlayer(1);
            }
            else if (TypeOfGame == GameType.AgainstRandomComputer)
            {
                secondPlayer = new RandomComputerPlayer();
            }
            else if (TypeOfGame == GameType.AgainstTacticalComputer)
            {
                secondPlayer = new TacticalComputerPlayer();
            }
            Players.Add(1, secondPlayer);
        }

        private void swingHands()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Move();
            }
        }

        private void checkWhoWonTheTurnForTwoPlayers()
        {
            //if moveType is not in winAgainst or loseAgainst, then it is a tie and players replay the round.
            if (!Players[0].PlayedMoves.Last().WinAgainst.Contains(Players[1].PlayedMoves.Last().TypeOfMove)
                && !Players[0].PlayedMoves.Last().LoseAgainst.Contains(Players[1].PlayedMoves.Last().TypeOfMove))
            {
                Console.WriteLine(Constants.IT_IS_A_TIE);
                swingHands();
                checkWhoWonTheTurnForTwoPlayers();
            }
            else
            {
                if (Players[0].PlayedMoves.Last().WinAgainst.Contains(Players[1].PlayedMoves.Last().TypeOfMove))
                {
                    printTheWinnerOfTurn(Players[0]);
                }
                else
                {
                    //When it is a game with two players, if you didn't win and it is not a tie, it means you lost.
                    printTheWinnerOfTurn(Players[1]);
                }
            }
        }

        private void printTheWinnerOfTurn(IPlayer player)
        {
            player.WinCount++;
            Console.WriteLine("{0}{1}", Constants.ROUND_WINNER_IS, player.Name);
        }
        private void printWinnerOfTheGame() 
        {
            int maxWin = getMaxWinCount();
            IEnumerable<KeyValuePair<int, IPlayer>> winners = Players.Where(p=> p.Value.WinCount == maxWin);
            if (Players.Count == 2 && winners.Count() == 2) //it happens when game has even count of turns.
            {
                Console.WriteLine(Constants.GAME_IS_TIE);
            }
            else
            {
                Console.WriteLine("\n{0} {1}", string.Join(",", winners.Select(x=> x.Value.Name)), Constants.WON);
            }
        }

        private int getMaxWinCount() 
        {
            return Players.Max(x => x.Value.WinCount);
        }
    }
}
