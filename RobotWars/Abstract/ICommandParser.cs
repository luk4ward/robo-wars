using System.Collections.Generic;

namespace RobotWars.Abstract
{
    public interface ICommandParser
    {
        bool ParseCommands(List<string> commands);
    }
}
