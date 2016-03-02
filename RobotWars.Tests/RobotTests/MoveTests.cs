using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Abstract;
using static RobotWars.Types.Direction;

namespace RobotWars.Tests.RobotTests
{
    [TestClass]
    public class MoveTests
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
        public void Move_RobotNotLocated_NoLocation()
        {
            Robot.Move();

            Assert.IsNull(Robot.Arena);
        }

        [TestMethod]
        public void Move_RobotFacingNorth_PosYIncreased()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);

            Robot.Move();

            Assert.AreEqual(StartingPoint + 1, Robot.PosY);
        }

        [TestMethod]
        public void Move_RobotFacingSouth_PosYDecreased()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);
            Robot.Facing = South;

            Robot.Move();

            Assert.AreEqual(StartingPoint - 1, Robot.PosY);
        }

        [TestMethod]
        public void Move_RobotFacingEast_PosXIncreased()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);
            Robot.Facing = East;

            Robot.Move();

            Assert.AreEqual(StartingPoint + 1, Robot.PosX);
        }

        [TestMethod]
        public void Move_RobotFacingWest_PosXDecreased()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);
            Robot.Facing = West;

            Robot.Move();

            Assert.AreEqual(StartingPoint - 1, Robot.PosX);
        }

        [TestMethod]
        public void Move_RobotFacingNorthOnBorder_NotMoving()
        {
            Robot.Locate(Arena.Object, Size, Size);

            Robot.Move();

            Assert.AreEqual(Size, Robot.PosY);
        }

        [TestMethod]
        public void Move_RobotFacingSouthOnBorder_NotMoving()
        {
            Robot.Locate(Arena.Object, 0, 0);
            Robot.Facing = South;

            Robot.Move();

            Assert.AreEqual(0, Robot.PosY);
        }

        [TestMethod]
        public void Move_RobotFacingEastOnBorder_NotMoving()
        {
            Robot.Locate(Arena.Object, Size, Size);
            Robot.Facing = East;

            Robot.Move();

            Assert.AreEqual(Size, Robot.PosX);
        }

        [TestMethod]
        public void Move_RobotFacingWestOnBorder_NotMoving()
        {
            Robot.Locate(Arena.Object, 0, 0);
            Robot.Facing = West;

            Robot.Move();

            Assert.AreEqual(0, Robot.PosX);
        }

    }
}
