using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Abstract;
using static RobotWars.Types.Direction;

namespace RobotWars.Tests.RobotTests
{
    [TestClass]
    public class TurnRightTests
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
        public void TurnRight_RobotNotLocated_FacingNorth()
        {
            Robot.TurnRight();

            Assert.AreEqual(North, Robot.Facing);
        }

        [TestMethod]
        public void TurnRight_FacingNorth_FacingEast()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);
            Robot.Facing = North;

            Robot.TurnRight();

            Assert.AreEqual(East, Robot.Facing);
        }

        [TestMethod]
        public void TurnRight_FacingWest_FacingNorth()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);
            Robot.Facing = West;

            Robot.TurnRight();

            Assert.AreEqual(North, Robot.Facing);
        }
    }
}
