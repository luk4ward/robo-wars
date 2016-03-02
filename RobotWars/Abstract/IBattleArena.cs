namespace RobotWars.Abstract
{
    public interface IBattleArena
    {
        int Width { get; }
        int Hight { get; }
        void SetSize(int width, int hight);
    }
}
