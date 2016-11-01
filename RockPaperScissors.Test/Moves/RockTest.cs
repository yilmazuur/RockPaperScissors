using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Test.Moves
{
    [TestClass]
    public class RockTest
    {
        private IMove _rock;

        [TestInitialize]
        public void Setup()
        {
            _rock = new Rock();
        }

        [TestMethod]
        public void RockMoveTypeIsRock()
        {
            Assert.IsTrue(_rock.TypeOfMove == MoveType.Rock);
        }

        [TestMethod]
        public void RockLoseAgainstPaper()
        {
            Assert.IsTrue(_rock.LoseAgainst.Contains(MoveType.Paper));
        }

        [TestMethod]
        public void RockWinAgainstScissors()
        {
            Assert.IsTrue(_rock.WinAgainst.Contains(MoveType.Scissors));
        }

        [TestMethod]
        public void RockTiesWithRock()
        {
            Assert.IsTrue(!_rock.WinAgainst.Contains(MoveType.Rock) && !_rock.LoseAgainst.Contains(MoveType.Rock));
        }
    }
}
