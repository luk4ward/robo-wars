using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Abstract;
using static RobotWars.Types.Direction;

namespace RobotWars.Tests.CommanderTests
{
    [TestClass]
    public class ExecuteCommandTests
    {
        public IBattleArena Arena;
        public IRobot Robot;
        public ICommander Commander;

        [TestInitialize]
        public void Initialize()
        {
            Arena = new BattleArena();
            Robot = new Robot();
            Commander = new Commander();
        }

        [TestMethod]
        public void ExecuteCommandArena_CommandIsValid_SetArenaSize()
        {
            string command = "5 3";

            Commander.ExecuteCommand(Arena, command);

            Assert.AreEqual(5, Arena.Width);
            Assert.AreEqual(3, Arena.Hight);
        }

        [TestMethod]
        public void ExecuteCommandArena_CommandIsTooLong_ArenaSizeIsZero()
        {
            string command = "5 3 6";

            Commander.ExecuteCommand(Arena, command);

            Assert.AreEqual(0, Arena.Width);
            Assert.AreEqual(0, Arena.Hight);
        }

        [TestMethod]
        public void ExecuteCommandArena_CommandIsTooShort_ArenaSizeIsZero()
        {
            string command = "536";

            Commander.ExecuteCommand(Arena, command);

            Assert.AreEqual(0, Arena.Width);
            Assert.AreEqual(0, Arena.Hight);
        }

        [TestMethod]
        public void ExecuteCommandArena_CommandIsInvalid_ArenaHightIsZero()
        {
            string command = "3 NULL";

            Commander.ExecuteCommand(Arena, command);

            Assert.AreEqual(0, Arena.Hight);
        }

        [TestMethod]
        public void ExecuteCommandArena_CommandIsInvalid_ArenaWidthIsZero()
        {
            string command = "Easd 5";

            Commander.ExecuteCommand(Arena, command);

            Assert.AreEqual(0, Arena.Width);
        }

        [TestMethod]
        public void ExecuteCommandRobot_OneCommand_RobotMoved()
        {
            Arena.SetSize(5, 5);
            Robot.Locate(Arena, 1, 2);
            string command = "LMLMLMLMM";

            Commander.ExecuteCommand(Robot, Arena, command);

            Assert.AreEqual(1, Robot.PosX);
            Assert.AreEqual(3, Robot.PosY);
            Assert.AreEqual(North, Robot.Facing);
        }

        [TestMethod]
        public void ExecuteCommandRobot_ThreeCommand_RobotLocated()
        {
            Arena.SetSize(5, 5);
            Robot.Locate(Arena, 1, 2);
            string command = "2 2 N";

            Commander.ExecuteCommand(Robot, Arena, command);

            Assert.AreEqual(2, Robot.PosX);
            Assert.AreEqual(2, Robot.PosY);
            Assert.AreEqual(North, Robot.Facing);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidDataException))]
        public void ExecuteCommandRobot_InvalidCommand_ThrowsException()
        {
            string command = "3 3";

            Commander.ExecuteCommand(Robot, Arena, command);
        }
    }
}
