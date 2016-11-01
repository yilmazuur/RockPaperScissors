using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Test.Base
{
    public class MoveMockBase
    {
        protected Mock<IMove> _rockMock;
        protected Mock<IMove> _paperMock;
        protected Mock<IMove> _scissorsMock;

        public MoveMockBase()
        {
            _rockMock = new Mock<IMove>();
            _rockMock.Setup(x => x.TypeOfMove).Returns(MoveType.Rock);
            _rockMock.Setup(x => x.LoseAgainst).Returns(new List<MoveType>() { MoveType.Paper });
            _rockMock.Setup(x => x.WinAgainst).Returns(new List<MoveType>() { MoveType.Scissors });

            _paperMock = new Mock<IMove>();
            _paperMock.Setup(x => x.TypeOfMove).Returns(MoveType.Paper);
            _paperMock.Setup(x => x.LoseAgainst).Returns(new List<MoveType>() { MoveType.Scissors });
            _paperMock.Setup(x => x.WinAgainst).Returns(new List<MoveType>() { MoveType.Rock });

            _scissorsMock = new Mock<IMove>();
            _scissorsMock.Setup(x => x.TypeOfMove).Returns(MoveType.Scissors);
            _scissorsMock.Setup(x => x.LoseAgainst).Returns(new List<MoveType>() { MoveType.Rock });
            _scissorsMock.Setup(x => x.WinAgainst).Returns(new List<MoveType>() { MoveType.Paper });
        }
    }
}
