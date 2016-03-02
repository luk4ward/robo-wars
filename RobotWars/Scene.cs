using System.Collections.Generic;
using RobotWars.Abstract;

namespace RobotWars
{
    public class Scene : IScene
    {
        public IBattleArena Arena;
        public IRobot RobotOne;
        public IRobot RobotTwo;
        private readonly ICommander _commander;
        public bool Valid { get; set; }

        public Scene(IBattleArena arena, IRobot robotOne, IRobot robotTwo, ICommander commander)
        {
            Arena = arena;
            RobotOne = robotOne;
            RobotTwo = robotTwo;
            _commander = commander;
        }


        public void Prepare(List<string> commands)
        {
            _commander.ExecuteCommand(Arena, commands[0]);
            _commander.ExecuteCommand(RobotOne, Arena, commands[1]);
            _commander.ExecuteCommand(RobotOne, Arena, commands[2]);
            _commander.ExecuteCommand(RobotTwo, Arena, commands[3]);
            _commander.ExecuteCommand(RobotTwo, Arena, commands[4]);
            Valid = true;
        }
    }
}
