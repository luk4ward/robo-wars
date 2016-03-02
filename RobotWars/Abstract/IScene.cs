using System.Collections.Generic;

namespace RobotWars.Abstract
{
    public interface IScene
    {
        bool Valid { get; set; }
        void Prepare(List<string> commands);
    }
}
