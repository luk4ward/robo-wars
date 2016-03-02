using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Abstract;
using static RobotWars.Types.Direction;

namespace RobotWars.Tests.RobotTests
{
    [TestClass]
    public class TurnLeftTests
    {
        public IRobot Robot;
        public Mock<IBattleArena> Arena;
        private const int Size = 10;
        private const int StartingPoint = 2;

        [TestInitialize]
        public void Initialize()
        {
            Robot = new Robot();
            Arena = new Mock<IBattleArena>();
            Arena.SetupGet(x => x.Hight).Returns(Size);
            Arena.SetupGet(x => x.Width).Returns(Size);
        }

        [TestMethod]
        public void TurnLeft_RobotNotLocated_FacingNorth()
        {
            Robot.TurnLeft();

            Assert.AreEqual(North, Robot.Facing);
        }

        [TestMethod]
        public void TurnLeft_FacingWest_FacingSouth()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);
            Robot.Facing = West;

            Robot.TurnLeft();

            Assert.AreEqual(South, Robot.Facing);
        }

        [TestMethod]
        public void TurnLeft_FacingNorth_FacingWest()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);
            Robot.Facing = North;

            Robot.TurnLeft();

            Assert.AreEqual(West, Robot.Facing);
        }
    }
}
