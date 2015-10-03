using SpriteGenerators;
using System;

namespace SpriteGen {
    class Program {
        static void Main(string[] args) {
            var gridDrawer = new GridDrawer();
            var generator = new PixelRobotGenerator();
            generator.GenerateRobot(1, 1, 1);
            gridDrawer.Draw(generator.Grid);
            Console.WriteLine();
            generator.GenerateRobot(6, 6, 6);
            gridDrawer.Draw(generator.Grid);
            Console.WriteLine();
            generator.GenerateRobot(255, 255, 255);
            gridDrawer.Draw(generator.Grid);
            Console.WriteLine();
            generator.GenerateRandomRobot();
            gridDrawer.Draw(generator.Grid);
            Console.WriteLine();

            Console.Read();
        }
    }
}
