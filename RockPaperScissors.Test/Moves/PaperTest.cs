using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Test.Moves
{
    [TestClass]
    public class PaperTest
    {
        private IMove _paper;

        [TestInitialize]
        public void Setup()
        {
            _paper = new Paper();
        }

        [TestMethod]
        public void PaperMoveTypeIsPaper()
        {
            Assert.IsTrue(_paper.TypeOfMove == MoveType.Paper);
        }

        [TestMethod]
        public void PaperLoseAgainstScissors()
        {
            Assert.IsTrue(_paper.LoseAgainst.Contains(MoveType.Scissors));
        }

        [TestMethod]
        public void PaperWinAgainstRock()
        {
            Assert.IsTrue(_paper.WinAgainst.Contains(MoveType.Rock));
        }

        [TestMethod]
        public void PaperTiesWithPaper()
        {
            Assert.IsTrue(!_paper.WinAgainst.Contains(MoveType.Paper) && !_paper.LoseAgainst.Contains(MoveType.Paper));
        }
    }
}
