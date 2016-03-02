namespace RobotWars.Abstract
{
    public interface ICommander
    {
        void ExecuteCommand(IRobot robot, IBattleArena arena, string command);
        void ExecuteCommand(IBattleArena arena, string command);
    }
}
