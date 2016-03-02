using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotWars.Abstract;

namespace RobotWars.Tests.RobotTests
{
    [TestClass]
    public class LocateTests
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
        public void Locate_LocationWithinArena_RobotIsValid()
        {
            Robot.Locate(Arena.Object, StartingPoint, StartingPoint);

            Assert.IsTrue(Robot.Valid);
        }

        [TestMethod]
        public void Locate_LocationOutsideArenaXToBig_RobotIsNotValid()
        {
            Robot.Locate(Arena.Object, Size + 2, StartingPoint);

            Assert.IsFalse(Robot.Valid);
        }

        [TestMethod]
        public void Locate_LocationOutsideArenaYToBig_RobotIsNotValid()
        {
            Robot.Locate(Arena.Object, StartingPoint, Size + 2);

            Assert.IsFalse(Robot.Valid);
        }
    }
}
