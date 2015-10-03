using System;
using System.Collections;

namespace SpriteGenerators {
    public class SpaceShipGenerator : GeneratorBase {
        private int midLine = 6;

        public SpaceShipGenerator() : base(12,12, 6) {
            _grid = new int[Rows, Columns];
        }

        public void GenerateRandom() {
            // .Net has no built in function to generate random uint
            // Generate two sets instead and combine them
            uint thirtyBits = (uint) _random.Next(1 << 30);
            uint twoBits = (uint) _random.Next(1 << 2);
            uint randomNumber = (thirtyBits << 2) | twoBits;
            Generate(randomNumber);
        }

        public void Generate(uint seed) {
            ClearGrid();
            SetMidLineSolids();
            BitArray b = new BitArray(BitConverter.GetBytes(seed));
            GenerateBody(b);
            GenerateCockpit(b);
            Outline();
            Mirror();
        }

        private void SetMidLineSolids() {
            _grid[2,5] = 1;
            _grid[3,5] = 1;
            _grid[4,5] = 1;
            _grid[5,5] = 1;
            _grid[9,5] = 1;
        }

        private void GenerateBody(BitArray b) {
            _grid[1, 4] = ToInt(b[0]);
            _grid[1, 5] = ToInt(b[1]);
            _grid[2, 4] = ToInt(b[2]);
            _grid[3, 3] = ToInt(b[3]);
            _grid[3, 4] = ToInt(b[4]);
            _grid[4, 3] = ToInt(b[5]);
            _grid[4, 4] = ToInt(b[6]);
            _grid[5, 2] = ToInt(b[7]);
            _grid[5, 3] = ToInt(b[8]);
            _grid[5, 4] = ToInt(b[9]);
            _grid[6, 1] = ToInt(b[10]);
            _grid[6, 2] = ToInt(b[11]);
            _grid[6, 3] = ToInt(b[12]);
            _grid[7, 1] = ToInt(b[13]);
            _grid[7, 2] = ToInt(b[14]);
            _grid[7, 3] = ToInt(b[15]);
            _grid[8, 1] = ToInt(b[16]);
            _grid[8, 2] = ToInt(b[17]);
            _grid[8, 3] = ToInt(b[18]);
            _grid[9, 1] = ToInt(b[19]);
            _grid[9, 2] = ToInt(b[20]);
            _grid[9, 3] = ToInt(b[21]);
            _grid[9, 4] = ToInt(b[22]);
            _grid[10, 3] = ToInt(b[23]);
            _grid[10, 4] = ToInt(b[24]);
            _grid[10, 5] = ToInt(b[25]);
        }

        private void GenerateCockpit(BitArray b) {
            //_grid[6, 4] = ToInt(b[26], 4);
            //_grid[6, 5] = ToInt(b[27], 4);
            //_grid[7, 4] = ToInt(b[28], 4);
            //_grid[7, 5] = ToInt(b[29], 4);
            //_grid[8, 4] = ToInt(b[30], 4);
            //_grid[8, 5] = ToInt(b[31], 4);
            
            _grid[6, 4] = ToInt(b[26], 1);
            _grid[6, 5] = ToInt(b[27], 1);
            _grid[7, 4] = ToInt(b[28], 1);
            _grid[7, 5] = ToInt(b[29], 1);
            _grid[8, 4] = ToInt(b[30], 1);
            _grid[8, 5] = ToInt(b[31], 1);
        }
    }
}
