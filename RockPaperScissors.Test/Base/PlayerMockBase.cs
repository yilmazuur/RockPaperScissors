using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Test.Base
{
    public class PlayerMockBase : MoveMockBase
    {
        protected Mock<IPlayer> _firstHumanPlayerMock;
        protected Mock<IPlayer> _secondHumanPlayerMock;
        protected Mock<IPlayer> _randomComputerPlayerMock;
        protected Mock<IPlayer> _tacticalComputerPlayerMock;

        public PlayerMockBase()
        {
            _firstHumanPlayerMock = new Mock<IPlayer>();
            //setup all properties to activate all properties as stub and use/store values.
            _firstHumanPlayerMock.SetupAllProperties(); 
            _firstHumanPlayerMock.Object.Name = "Human 0";
            _secondHumanPlayerMock = new Mock<IPlayer>();
            _secondHumanPlayerMock.SetupAllProperties();
            _secondHumanPlayerMock.Object.Name = "Human 1";
            _randomComputerPlayerMock = new Mock<IPlayer>();
            _randomComputerPlayerMock.SetupAllProperties();
            _randomComputerPlayerMock.Object.Name = "RandCP";
            _tacticalComputerPlayerMock = new Mock<IPlayer>();
            _tacticalComputerPlayerMock.SetupAllProperties();
            _tacticalComputerPlayerMock.Object.Name = "TacticCP";
        }
    }
}
