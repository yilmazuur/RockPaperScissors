using DataModels.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Test.Players
{
    [TestClass]
    public class TacticalComputerPlayerTest : MoveMockBase
    {
        private IPlayer tcp;

        [TestInitialize]
        public void Setup()
        {
            tcp = new TacticalComputerPlayer();
        }

        [TestMethod]
        public void TacticalComputerPlayerNameIsCorrect()
        {
            Assert.IsTrue(tcp.Name == "TacticCP");
        }

        [TestMethod]
        public void TCPFirstMoveIsRandom()
        {
            var move = tcp.Move();

            Assert.IsTrue(move.TypeOfMove.GetHashCode() < 3 && move.TypeOfMove.GetHashCode() >= 0);
        }

        [TestMethod]
        public void TCPMoveCountIsCorrect()
        {
            var oldCount = tcp.PlayedMoves.Count;
            var move = tcp.Move();

            Assert.IsTrue((oldCount + 1) == tcp.PlayedMoves.Count);
        }

        [TestMethod]
        public void TCPMoveTextIsCorrect()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var move = tcp.Move();

                var resultText = sw.ToString();
                Assert.IsTrue(resultText.Trim() == string.Format("{0}{1}{2}", tcp.Name, Constants.COMPUTER_MOVE, move.TypeOfMove));
            }
        }

        [TestMethod]
        public void TCPMoveToBeatLastMove()
        {
            var oldCount = tcp.PlayedMoves.Count;
            var move1 = tcp.Move();
            var move2 = tcp.Move();
            Assert.IsTrue(move1.LoseAgainst.Contains(move2.TypeOfMove));
        }
    }
}
