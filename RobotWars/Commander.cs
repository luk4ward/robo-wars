using System.IO;
using RobotWars.Abstract;
using RobotWars.Types;

namespace RobotWars
{
    public class Commander : ICommander
    {
        public void ExecuteCommand(IRobot robot, IBattleArena arena, string command)
        {
            var pos = command.Split(' ');
            if (pos.Length == 1)
            {
                MoveRobot(robot, command);
            }
            else if (pos.Length == 3)
            {
                int posX;
                int posY;
                int.TryParse(pos[0], out posX);
                int.TryParse(pos[1], out posY);
                LocateRobot(robot, arena, posX, posY, pos[2]);
            }
            else throw new InvalidDataException();
        }

        public void ExecuteCommand(IBattleArena arena, string command)
        {
            var width = 0;
            var hight = 0;
            var pos = command.Split(' ');
            if (pos.Length == 2)
            {
                int.TryParse(pos[0], out width);
                int.TryParse(pos[1], out hight);
            }
            arena.SetSize(width, hight);
        }

        private static void LocateRobot(IRobot robot, IBattleArena arena, int x, int y, string facing)
        {
            robot.Locate(arena, x, y);
            switch (facing)
            {
                case "N":
                    robot.Facing = Direction.North;
                    break;
                case "E":
                    robot.Facing = Direction.East;
                    break;
                case "S":
                    robot.Facing = Direction.South;
                    break;
                case "W":
                    robot.Facing = Direction.West;
                    break;
            }


        }

        private static void MoveRobot(IRobot robot, string command)
        {
            foreach (var c in command)
            {
                switch (c)
                {
                    case 'M':
                        robot.Move();
                        break;
                    case 'R':
                        robot.TurnRight();
                        break;
                    case 'L':
                        robot.TurnLeft();
                        break;
                }
            }
        }
    }
}
