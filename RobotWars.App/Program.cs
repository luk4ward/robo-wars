using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using RobotWars.Abstract;
using RobotWars.Types;

namespace RobotWars.App
{
    public static class Program
    {
        private static void Main()
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            var lines = new List<string>();

            for (var i = 0; i < 5; i++)
            {
                lines.Add(Console.ReadLine());
            }

            foreach (var output in RobotWarsBegin(lines))
            {
                Console.WriteLine(output);
            }
            
            Console.ReadKey();

        }

        public static List<string> RobotWarsBegin(List<string> lines)
        {
            var output = new List<string>();
            var parser = new CommandParser();
            var arena = new BattleArena();
            var robotOne = new Robot();
            var robotTwo = new Robot();
            var commander = new Commander();
            var scene = new Scene(arena, robotOne, robotTwo, commander);

            if (parser.ParseCommands(lines))
            {
                scene.Prepare(lines);
                var name = Enum.GetName(typeof(Direction), scene.RobotOne.Facing);
                if (name != null)
                    output.Add($"{scene.RobotOne.PosX} {scene.RobotOne.PosY} {name[0]}");
                name = Enum.GetName(typeof(Direction), scene.RobotTwo.Facing);
                if (name != null)
                    output.Add($"{scene.RobotTwo.PosX} {scene.RobotTwo.PosY} {name[0]}");
            }
            else
            {
                output.Add("Wrong input data!");
            }
            return output;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IRobot, Robot>();
            container.RegisterType<IBattleArena, BattleArena>();
            container.RegisterType<ICommandParser, CommandParser>();
            container.RegisterType<ICommander, Commander>();
            container.RegisterType<IScene, Scene>();
        }
    }
}
