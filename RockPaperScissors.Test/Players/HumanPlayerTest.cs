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
    public class HumanPlayerTest : MoveMockBase
    {
        private IPlayer human;

        [TestInitialize]
        public void Setup() 
        {
            human = new HumanPlayer(0);
        }

        [TestMethod]
        public void HumanNameIsCorrect() 
        {
            Assert.IsTrue(human.Name == "Human 0");
        }

        
        [TestMethod]
        public void HumanMoveRock() 
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("Rock"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    var oldCount = human.PlayedMoves.Count;
                    var move = human.Move();
                    
                    IMove rock = _rockMock.Object;
                    Assert.IsTrue(move.TypeOfMove == rock.TypeOfMove
                        && (oldCount + 1) == human.PlayedMoves.Count
                        && move.WinAgainst[0] == rock.WinAgainst[0] && move.LoseAgainst[0] == rock.LoseAgainst[0]);

                }
            }
        }

        [TestMethod]
        public void HumanMovePaper()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("Paper"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    var oldCount = human.PlayedMoves.Count;
                    var move = human.Move();

                    IMove paper = _paperMock.Object;
                    Assert.IsTrue(move.TypeOfMove == paper.TypeOfMove
                        && (oldCount + 1) == human.PlayedMoves.Count
                        && move.WinAgainst[0] == paper.WinAgainst[0] && move.LoseAgainst[0] == paper.LoseAgainst[0]);
                }
            }
        }

        [TestMethod]
        public void HumanMoveScissors()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("Scissors"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    var oldCount = human.PlayedMoves.Count;
                    var move = human.Move();

                    IMove _scissors = _scissorsMock.Object;
                    Assert.IsTrue(move.TypeOfMove == _scissors.TypeOfMove
                        && (oldCount + 1) == human.PlayedMoves.Count
                        && move.WinAgainst[0] == _scissors.WinAgainst[0] && move.LoseAgainst[0] == _scissors.LoseAgainst[0]);
                }
            }
        }

    }
}
