using RobotWars.Types;

namespace RobotWars.Abstract
{
    public interface IRobot
    {
        Direction Facing { get; set; }
        IBattleArena Arena { get; set; }
        bool Valid { get; }
        int PosX { get; }
        int PosY { get; }

        void Locate(IBattleArena arena, int x, int y);
        void Move();
        void TurnLeft();
        void TurnRight();
    }
}
