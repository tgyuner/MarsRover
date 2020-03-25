using System.Collections.Generic;
using System.Linq;
using MarsRover.Enums;
using MarsRover.Facade;
using MarsRover.Models;
using NUnit.Framework;

namespace MarsRover.Test.Test
{
    [TestFixture]
    public class TestMarsRover
    {
        private RoverRequest _roverRequest;
        private RoverFacade _roverFacade;
        private RoverRequest _squarerRequest;

        [SetUp]
        public void SetUp()
        {
            _roverRequest = new RoverRequest();
            _roverFacade = RoverFacade.GetInstance();

            _squarerRequest = new RoverRequest
            {
                Square = new SquareModel
                {
                    PositionX = 5,
                    PositionY = 5
                },
                RoverModels = new List<RoverModel>
                {
                    new RoverModel
                    {
                        StartPosition = new StartPosition
                        {
                            PositionX = 1,
                            PositionY = 2,
                            Compass = Compass.North
                        },
                        CommandList = new List<Command>{(Command.L), (Command.M) , (Command.L) , (Command.M), (Command.L), (Command.M), (Command.L), (Command.M), (Command.M) }
                    },
                    new RoverModel
                    {
                        StartPosition = new StartPosition
                        {
                            PositionX = 3,
                            PositionY = 3,
                            Compass = Compass.East
                        },
                        CommandList = new List<Command>{(Command.M), (Command.M) , (Command.R) , (Command.M), (Command.M), (Command.R), (Command.M), (Command.R), (Command.R), (Command.M) }
                    }
                }
            };
        }

        [Test]
        public void RoverMoveIt()
        {
            // North -> YPositive
            var square = new List<int>() { _squarerRequest.Square.PositionX, _squarerRequest.Square.PositionY };

            Assert.AreEqual(_roverFacade.RoverMoveIt(_squarerRequest.RoverModels.FirstOrDefault(), square), "1 3 North");
            Assert.AreEqual(_roverFacade.RoverMoveIt(_squarerRequest.RoverModels.LastOrDefault(), square), "5 1 East");
        }

        [Test]
        public void RoverStartValueControl()
        {
            // 1.Rover Start  Value
            Assert.AreEqual(_squarerRequest.RoverModels.FirstOrDefault().StartPosition.PositionX, 1);
            Assert.AreEqual(_squarerRequest.RoverModels.FirstOrDefault().StartPosition.PositionY, 2);
            Assert.AreEqual(_squarerRequest.RoverModels.FirstOrDefault().StartPosition.Compass, Compass.North);

            // 2.Rover Start  Value
            Assert.AreEqual(_squarerRequest.RoverModels.LastOrDefault().StartPosition.PositionX, 3);
            Assert.AreEqual(_squarerRequest.RoverModels.LastOrDefault().StartPosition.PositionY, 3);
            Assert.AreEqual(_squarerRequest.RoverModels.LastOrDefault().StartPosition.Compass, Compass.East);
        }

        #region private methods
        //[Test]
        //public void FindDirection()
        //{
        //    // YPositive -> North
        //    Assert.AreEqual(_roverFacade.FindDirection(CommandDetailConstant.YPositive), Compass.North);
        //}

        //[Test]
        //public void CommandRuleOperator()
        //{
        //    // YPositive + Right -> XPositive
        //    Assert.AreEqual(_roverFacade.CommandRuleOperator(CommandDetailConstant.YPositive, Command.R), CommandDetailConstant.XPositive);

        //    // XPositive + Left -> YPositive
        //    Assert.AreEqual(_roverFacade.CommandRuleOperator(CommandDetailConstant.XPositive, Command.L), CommandDetailConstant.YPositive);
        //}

        //[Test]
        //public void FindAxis()
        //{
        //    int procces = 0;

        //    // North -> YPositive
        //    Assert.AreEqual(_roverFacade.FindAxis(Compass.North, out procces), CommandDetailConstant.YPositive);

        //    // East -> XPositive
        //    Assert.AreEqual(_roverFacade.FindAxis(Compass.East, out procces), CommandDetailConstant.XPositive);
        //}

        #endregion
    }
}