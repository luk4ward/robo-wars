using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Abstract;

namespace RobotWars.Tests.CommandParserTests
{
    [TestClass]
    public class ParseCommandsTests
    {
        public ICommandParser CommandParser;

        [TestInitialize]
        public void Initialize()
        {
            CommandParser = new CommandParser();
        }

        [TestMethod]
        public void ParseCommands_CommandMatchPattern_ReturnsTrue()
        {
            var commands = new List<string> 
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"

            };

            var success = CommandParser.ParseCommands(commands);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void ParseCommands_CommandNotMatchPattern_ReturnsFalse()
        {
            var commands = new List<string>
            {
                "5 2 2",
                "1 2 F",
                "LMLEMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"

            };

            var success = CommandParser.ParseCommands(commands);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void ParseCommands_PatternLongerThanCommands_ReturnsFalse()
        {
            var commands = new List<string>
            {
                "5 2 2",
                "1 2 F",
                "LMLEMLMLMM",
                "3 3 E"

            };

            var success = CommandParser.ParseCommands(commands);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void ParseCommands_PatternShorterThanCommands_ReturnsFalse()
        {
            var commands = new List<string>
            {
                "5 2 2",
                "1 2 F",
                "LMLEMLMLMM",
                "3 3 E",
                "MMRMMRMRRM",
                "3 3 3 3 3"

            };

            var success = CommandParser.ParseCommands(commands);
            Assert.IsFalse(success);
        }
    }
}