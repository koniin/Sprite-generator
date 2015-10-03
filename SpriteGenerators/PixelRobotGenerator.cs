using System;
using System.Collections;

namespace SpriteGenerators
{
    public class PixelRobotGenerator {
        private int[,] _grid;
        public int[,] Grid {
            get { return _grid; }
        }
        private readonly Random _random;

        private const int Rows = 11;
        private const int Columns = 7;
        private static readonly Point[] Neighbours = new Point[] { new Point(0, -1), new Point(0, 1), new Point(1, 0), new Point(-1, 0) };

        public PixelRobotGenerator() {
            _random = new Random();
            _grid = new int[Rows, Columns];
        }

        public void GenerateRobot(int head, int body, int feet) {
            ClearGrid();
            GenerateHead(head);
            GenerateBody(body);
            GenerateFeet(feet);
            Outline();
            Mirror();
        }

        public void GenerateRandomRobot() {
            ClearGrid();
            GenerateHead(_random.Next(255));
            GenerateBody(_random.Next(255));
            GenerateFeet(_random.Next(255));
            Outline();
            Mirror();
        }

        private void ClearGrid() {
            for(int y = 0; y < _grid.GetLength(0); y++) {
                for(int x = 0; x < _grid.GetLength(1); x++) {
                    _grid[y, x] = 0;
                }
            }
        }

        private void GenerateHead(int head) {
            BitArray b = new BitArray(new[] { head });
            _grid[1, 1] = ToInt(b[0]);
            _grid[1, 2] = ToInt(b[1]);
            _grid[1, 3] = ToInt(b[2]);
            _grid[2, 1] = ToInt(b[3]);
            _grid[2, 2] = ToInt(b[4]);
            _grid[2, 3] = ToInt(b[5]);
            _grid[3, 2] = ToInt(b[6]);
            _grid[3, 3] = ToInt(b[7]);
        }

        private void GenerateBody(int body) {
            BitArray b = new BitArray(new[] { body });
            _grid[4, 3] = ToInt(b[0]);
            _grid[5, 1] = ToInt(b[1]);
            _grid[5, 2] = ToInt(b[2]);
            _grid[5, 3] = ToInt(b[3]);
            _grid[6, 1] = ToInt(b[4]);
            _grid[6, 2] = ToInt(b[5]);
            _grid[6, 3] = ToInt(b[6]);
            _grid[7, 3] = ToInt(b[7]);
        }

        private void GenerateFeet(int feet) {
            BitArray b = new BitArray(new[] { feet });
            _grid[8, 3] = ToInt(b[0]);
            _grid[9, 1] = ToInt(b[1]);
            _grid[9, 2] = ToInt(b[2]);
            _grid[9, 3] = ToInt(b[3]);
            _grid[10, 0] = ToInt(b[4]);
            _grid[10, 1] = ToInt(b[5]);
            _grid[10, 2] = ToInt(b[6]);
            _grid[10, 3] = ToInt(b[7]);
        }
        
        private struct Point {
            public int X;
            public int Y;
            public Point(int x, int y) {
                X = x;
                Y = y;
            }
        }

        private void Outline() {
            for(int y = 0; y < _grid.GetLength(0); y++) {
                for(int x = 0; x < 4; x++) {
                    if(_grid[y, x] == 1 && isValidOnGrid(x - 1, y)) {
                        _grid[y, x - 1] = 2;
                    }
                    if(_grid[y, x] == 1 && isValidOnGrid(x + 1, y)) {
                        _grid[y, x + 1] = 2;
                    }
                    if(_grid[y, x] == 1 && isValidOnGrid(x, y - 1)) {
                        _grid[y - 1, x] = 2;
                    }
                    if(_grid[y, x] == 1 && isValidOnGrid(x, y + 1)) {
                        _grid[y + 1, x] = 2;
                    }
                }
            }
        }

        private void Mirror() {
            for(int y = 0; y < _grid.GetLength(0); y++) {
                for(int x = 0, x2 = 6; x < 4; x++, x2--) {
                    _grid[y, x2] = _grid[y, x];
                }
            }
        }

        private static int ToInt(bool v) {
            return v ? 1 : 0;
        }

        private bool isValidOnGrid(int x, int y) {
            return x >= 0 && y >= 0 && x < 4 && y < Rows && _grid[y, x] != 1;
        }
    }
}
