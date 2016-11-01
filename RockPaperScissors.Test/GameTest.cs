using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModels.Test.Base;
using System.Collections.Generic;
using System.IO;
using Moq;

namespace DataModels.Test
{
    [TestClass]
    public class GameTest : PlayerMockBase
    {
        private IGame gameAgainstHuman;
        private IGame gameAgainstRandomComputerPlayer;
        private IGame gameAgainstTacticalComputerPlayer;

        [TestInitialize]
        public void SetUp()
        {
            gameAgainstHuman = new Game(GameType.AgainstHuman);
            LoadMockedUsers(gameAgainstHuman);
            gameAgainstRandomComputerPlayer = new Game(GameType.AgainstRandomComputer);
            LoadMockedUsers(gameAgainstRandomComputerPlayer);
            gameAgainstTacticalComputerPlayer = new Game(GameType.AgainstTacticalComputer);
            LoadMockedUsers(gameAgainstTacticalComputerPlayer);
        }

        private void LoadMockedUsers(IGame game)
        {
            for (int i = 0; i < game.Players.Count; i++)
            {
                if (i == 0)
                {
                    game.Players[i] = _firstHumanPlayerMock.Object;
                }
                else
                {
                    if (game.Players[i] is HumanPlayer)
                        game.Players[i] = _secondHumanPlayerMock.Object;
                    else if (game.Players[i] is RandomComputerPlayer)
                        game.Players[i] = _randomComputerPlayerMock.Object;
                    else if (game.Players[i] is TacticalComputerPlayer)
                        game.Players[i] = _tacticalComputerPlayerMock.Object;
                }
            }
        }

        /// <summary>
        /// Sets sequential mocked moves of a mocked player to create a scenario
        /// </summary>
        /// <param name="playerMock"></param>
        /// <param name="moves"></param>
        private void SetupMoveSequence(Mock<IPlayer> playerMock, params Mock<IMove>[] moves)
        {
            List<IMove> playedMoves = new List<IMove>();
            playerMock.Setup(x => x.PlayedMoves).Returns(playedMoves);
            playerMock.Setup(x => x.Move()).Returns(() =>
            {
                IMove move;
                if (moves.Length > playerMock.Object.PlayedMoves.Count)
                    move = moves[playerMock.Object.PlayedMoves.Count].Object;
                else
                    move = moves[moves.Length - 1].Object;

                playerMock.Object.PlayedMoves.Add(move);
                return move;
            });
        }

        [TestMethod]
        public void AgainstHumanGameTypeIsCorrect()
        {
            Assert.IsTrue(gameAgainstHuman.TypeOfGame == GameType.AgainstHuman);
        }

        [TestMethod]
        public void AgainstRCPGameTypeIsCorrect()
        {
            Assert.IsTrue(gameAgainstRandomComputerPlayer.TypeOfGame == GameType.AgainstRandomComputer);
        }

        [TestMethod]
        public void AgainstTCPnGameTypeIsCorrect()
        {
            Assert.IsTrue(gameAgainstTacticalComputerPlayer.TypeOfGame == GameType.AgainstTacticalComputer);
        }

        [TestMethod]
        public void GameScenarioAgainstHumanAndFirstHumanWins()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                //Three times same move with each other and then first human wins 2-0
                SetupMoveSequence(_firstHumanPlayerMock, _paperMock, _paperMock, _rockMock,
                    _rockMock, _scissorsMock);

                SetupMoveSequence(_secondHumanPlayerMock, _paperMock, _paperMock, _rockMock,
                    _scissorsMock, _paperMock);

                gameAgainstHuman.Play();
                var resultText = sw.ToString();
                Assert.IsTrue(resultText.Trim().Contains(string.Format("{0} {1}",
                    _firstHumanPlayerMock.Object.Name, Constants.WON)));
            }
        }

        [TestMethod]
        public void GameScenarioAgainstHumanAndSecondHumanWins()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                SetupMoveSequence(_firstHumanPlayerMock, _rockMock, _paperMock, _scissorsMock);

                SetupMoveSequence(_secondHumanPlayerMock, _paperMock, _paperMock, _rockMock);

                gameAgainstHuman.Play();
                var resultText = sw.ToString();
                Assert.IsTrue(resultText.Trim().Contains(string.Format("{0} {1}",
                    _secondHumanPlayerMock.Object.Name, Constants.WON)));
            }
        }


        [TestMethod]
        public void GameScenarioAgainstRandomComputerPlayerAndComputerWins()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                SetupMoveSequence(_firstHumanPlayerMock, _paperMock, _paperMock, _rockMock);

                SetupMoveSequence(_randomComputerPlayerMock, _scissorsMock, _paperMock, _paperMock);

                gameAgainstRandomComputerPlayer.Play();
                var resultText = sw.ToString();
                Assert.IsTrue(resultText.Trim().Contains(string.Format("{0} {1}",
                    _randomComputerPlayerMock.Object.Name, Constants.WON)));
            }
        }

        [TestMethod]
        public void GameScenarioAgainstTacticalComputerPlayerAndWinsTacticalComputerPlayer()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                SetupMoveSequence(_firstHumanPlayerMock, _paperMock, _scissorsMock, _rockMock);

                SetupMoveSequence(_tacticalComputerPlayerMock, _scissorsMock, _paperMock, _paperMock);

                gameAgainstTacticalComputerPlayer.Play();
                var resultText = sw.ToString();
                Assert.IsTrue(resultText.Trim().Contains(string.Format("{0} {1}",
                    _tacticalComputerPlayerMock.Object.Name, Constants.WON)));
            }
        }
    }
}
