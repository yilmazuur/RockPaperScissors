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
    public class RandomComputerPlayerTest
    {
        private IPlayer rcp;

        [TestInitialize]
        public void Setup()
        {
            rcp = new RandomComputerPlayer();
        }

        [TestMethod]
        public void RandomComputerPlayerNameIsCorrect()
        {
            Assert.IsTrue(rcp.Name == "RandCP");
        }

        [TestMethod]
        public void RCPMoveIsRandom()
        {
            var move = rcp.Move();

            Assert.IsTrue(move.TypeOfMove.GetHashCode() < 3 && move.TypeOfMove.GetHashCode() >= 0);
        }

        [TestMethod]
        public void RCPMoveCountIsCorrect()
        {
            var oldCount = rcp.PlayedMoves.Count;
            var move = rcp.Move();

            Assert.IsTrue((oldCount + 1) == rcp.PlayedMoves.Count);
        }

        [TestMethod]
        public void RCPMoveTextIsCorrect()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var move = rcp.Move();

                var resultText = sw.ToString();
                Assert.IsTrue(resultText.Trim() == string.Format("{0}{1}{2}", rcp.Name, Constants.COMPUTER_MOVE, move.TypeOfMove));
            }
        }
    }
}
