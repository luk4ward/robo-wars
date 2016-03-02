using RobotWars.Abstract;

namespace RobotWars
{
    public class BattleArena : IBattleArena
    {
        public int Width { get; private set; }
        public int Hight { get; private set; }

        public void SetSize(int width, int hight)
        {
            Width = width;
            Hight = hight;
        }
    }
}
