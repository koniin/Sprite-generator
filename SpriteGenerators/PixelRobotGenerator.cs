using System;
using System.Collections;

namespace SpriteGenerators {
    public class PixelRobotGenerator : GeneratorBase {
        private int midLine = 4;

        public PixelRobotGenerator() : base(11, 7, 4) {}

        public void GenerateRobot(byte head, byte body, byte feet) {
            ClearGrid();
            GenerateHead(head);
            GenerateBody(body);
            GenerateFeet(feet);
            Outline();
            Mirror();
        }

        public void GenerateRandomRobot() {
            ClearGrid();
            GenerateHead((byte)_random.Next(255));
            GenerateBody((byte)_random.Next(255));
            GenerateFeet((byte)_random.Next(255));
            Outline();
            Mirror();
        }

        private void GenerateHead(byte head) {
            BitArray b = new BitArray(BitConverter.GetBytes(head));
            _grid[1, 1] = ToInt(b[0]);
            _grid[1, 2] = ToInt(b[1]);
            _grid[1, 3] = ToInt(b[2]);
            _grid[2, 1] = ToInt(b[3]);
            _grid[2, 2] = ToInt(b[4]);
            _grid[2, 3] = ToInt(b[5]);
            _grid[3, 2] = ToInt(b[6]);
            _grid[3, 3] = ToInt(b[7]);
        }

        private void GenerateBody(byte body) {
            BitArray b = new BitArray(BitConverter.GetBytes(body));
            _grid[4, 3] = ToInt(b[0]);
            _grid[5, 1] = ToInt(b[1]);
            _grid[5, 2] = ToInt(b[2]);
            _grid[5, 3] = ToInt(b[3]);
            _grid[6, 1] = ToInt(b[4]);
            _grid[6, 2] = ToInt(b[5]);
            _grid[6, 3] = ToInt(b[6]);
            _grid[7, 3] = ToInt(b[7]);
        }

        private void GenerateFeet(byte feet) {
            BitArray b = new BitArray(BitConverter.GetBytes(feet));
            _grid[8, 3] = ToInt(b[0]);
            _grid[9, 1] = ToInt(b[1]);
            _grid[9, 2] = ToInt(b[2]);
            _grid[9, 3] = ToInt(b[3]);
            _grid[10, 0] = ToInt(b[4]);
            _grid[10, 1] = ToInt(b[5]);
            _grid[10, 2] = ToInt(b[6]);
            _grid[10, 3] = ToInt(b[7]);
        }
    }
}
