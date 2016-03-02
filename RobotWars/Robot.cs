using RobotWars.Abstract;
using RobotWars.Types;
using static RobotWars.Types.Direction;

namespace RobotWars
{
    public class Robot : IRobot 
    {
        public IBattleArena Arena { get; set; }
        public Direction Facing { get; set; }
        public bool Valid { get; set; }
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public void Locate(IBattleArena arena, int x, int y)
        {
            if (x > arena.Width || y > arena.Hight || x < 0 || y < 0)
            {
                Valid = false;
                return;
            }

            Arena = arena;
            PosX = x;
            PosY = y;
            Facing = North;
            Valid = true;
        }

        public void Move()
        {
            if (!Valid)
                return;

            switch (Facing)
            {
                case North:
                    if (PosY < Arena.Hight)
                        PosY++;
                    break;
                case East:
                    if (PosX < Arena.Width)
                        PosX++;
                    break;
                case South:
                    if (PosY > 0)
                        PosY--;
                    break;
                case West:
                    if (PosX > 0)
                        PosX--;
                    break;
            }
        }

        public void TurnRight()
        {
            if (Valid)
                Facing = (Direction)(((int)Facing + 1) % 4);
        }

        public void TurnLeft()
        {
            if (Valid)
                Facing = (Direction)(((int)Facing + 3) % 4);
        }
    }
}
