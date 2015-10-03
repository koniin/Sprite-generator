using System;

namespace SpriteGenerators {
    public abstract class GeneratorBase {
        private int _midLine;
        protected int[,] _grid;
        public int[,] Grid {
            get { return _grid; }
        }
        protected readonly Random _random;

        protected readonly int Rows;
        protected readonly int Columns;

        public GeneratorBase(int rows, int columns, int midLine) {
            Rows = rows;
            Columns = columns;
            _grid = new int[Rows, Columns];
            _random = new Random();
            _midLine = midLine;
        }

        protected void ClearGrid() {
            for(int y = 0; y < _grid.GetLength(0); y++) {
                for(int x = 0; x < _grid.GetLength(1); x++) {
                    _grid[y, x] = 0;
                }
            }
        }

        protected static int ToInt(bool v) {
            return v ? 1 : 0;
        }

        protected static int ToInt(bool v, int val) {
            return v ? val : 0;
        }
        
        protected void Outline() {
            for(int y = 0; y < _grid.GetLength(0); y++) {
                for(int x = 0; x < _midLine; x++) {
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

        protected void Mirror() {
            for(int y = 0; y < _grid.GetLength(0); y++) {
                for(int x = 0, x2 = Columns - 1; x < _midLine; x++, x2--) {
                    _grid[y, x2] = _grid[y, x];
                }
            }
        }

        protected bool isValidOnGrid(int x, int y) {
            return x >= 0 && y >= 0 && x < _midLine && y < Rows && _grid[y, x] != 1;
        }
    }
}
