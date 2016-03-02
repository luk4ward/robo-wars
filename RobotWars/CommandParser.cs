using System.Collections.Generic;
using System.Linq;
using RobotWars.Abstract;

namespace RobotWars
{
    public class CommandParser : ICommandParser
    {
        private readonly string[] _pattern =
        {
            @"^[0-9]+\s+[0-9]+\s*$",
            @"^[0-9]+\s+[0-9]+\s+[NESW]\s*$",
            @"^[LRM]+$",
            @"^[0-9]+\s+[0-9]+\s+[NESW]\s*$",
            @"^[LRM]+$"

        };

        public bool ParseCommands(List<string> commands)
        {
            if (commands.Count != _pattern.Length)
                return false;
            return !commands.Where((t, i) => !VerifyCommand(_pattern[i], t)).Any();
        }

        private static bool VerifyCommand(string pattern, string command)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(command, pattern);
        }
    }
}
