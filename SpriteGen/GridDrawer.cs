using System;
namespace SpriteGen {
    public class GridDrawer {
        public void Draw(int[,] grid) {
            for(int y = 0; y < grid.GetLength(0); y++) {
                for(int x = 0; x < grid.GetLength(1); x++) {
                    WriteGridPiece(grid, y, x);
                }
                Console.WriteLine();
            }
        }

        private static void WriteGridPiece(int[,] grid, int y, int x) {
            var defaultColor = Console.ForegroundColor;
            if(grid[y, x] == 2) {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if(grid[y, x] == 4) {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            if(grid[y, x] == 1) {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(grid[y, x]);

            Console.ForegroundColor = defaultColor;
        }
    }
}
