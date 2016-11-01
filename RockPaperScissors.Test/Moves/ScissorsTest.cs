using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Test.Moves
{
    [TestClass]
    public class ScissorsTest
    {
        private IMove _scissors;

        [TestInitialize]
        public void Setup()
        {
            _scissors = new Scissors();
        }

        [TestMethod]
        public void ScissorsMoveTypeIsScissors()
        {
            Assert.IsTrue(_scissors.TypeOfMove == MoveType.Scissors);
        }

        [TestMethod]
        public void ScissorsLoseAgainstRock()
        {
            Assert.IsTrue(_scissors.LoseAgainst.Contains(MoveType.Rock));
        }

        [TestMethod]
        public void ScissorsWinAgainstPaper()
        {
            Assert.IsTrue(_scissors.WinAgainst.Contains(MoveType.Paper));
        }

        [TestMethod]
        public void ScissorsTiesWithScissors()
        {
            Assert.IsTrue(!_scissors.WinAgainst.Contains(MoveType.Scissors) && !_scissors.LoseAgainst.Contains(MoveType.Scissors));
        }
    }
}
