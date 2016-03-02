using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.App;

namespace RobotWars.Acceptance
{
    [TestClass]
    public class RoboWarsTests
    {
        public List<string> Output;

        [TestMethod]
        public void Acceptance_InputDataIsValid_RobotsLocations()
        {
            var expectedOutput = new List<string>
            {
                "1 3 N",
                "5 1 E"
            };

            var commands = new List<string>
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            Output = Program.RobotWarsBegin(commands);
            CollectionAssert.AreEqual(expectedOutput, Output);
        }

        [TestMethod]
        public void Acceptance_InputDataIsInvalid_ErrorMsg()
        {
            var expectedOutput = new List<string>
            {
                "Wrong input data!"
            };

            var commands = new List<string>
            {
                "5 5 NULL",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            Output = Program.RobotWarsBegin(commands);
            CollectionAssert.AreEqual(expectedOutput, Output);
        }

        [TestMethod]
        public void Acceptance_InputDataIsToShort_ErrorMsg()
        {
            var expectedOutput = new List<string>
            {
                "Wrong input data!"
            };

            var commands = new List<string>
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM"
            };

            Output = Program.RobotWarsBegin(commands);
            CollectionAssert.AreEqual(expectedOutput, Output);
        }

        [TestMethod]
        public void Acceptance_InputDataIsToLong_ErrorMsg()
        {
            var expectedOutput = new List<string>
            {
                "Wrong input data!"
            };

            var commands = new List<string>
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM",
                "2 2"
            };

            Output = Program.RobotWarsBegin(commands);
            CollectionAssert.AreEqual(expectedOutput, Output);
        }

        [TestMethod]
        public void Acceptance_InputDataIsEmpty_ErrorMsg()
        {
            var expectedOutput = new List<string>
            {
                "Wrong input data!"
            };

            var commands = new List<string>();

            Output = Program.RobotWarsBegin(commands);
            CollectionAssert.AreEqual(expectedOutput, Output);
        }
    }
}
