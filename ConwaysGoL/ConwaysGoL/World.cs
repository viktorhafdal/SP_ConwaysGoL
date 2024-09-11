using System;
using System.Text;

namespace ConwaysGoL {
    internal class World {
        private int[,] map { get; set; }
        private int width, height;

        public World() {
            this.width = 15;
            this.height = 15;
            map = new int[width, height];
        }

        public World(int width, int height) {
            this.width = width;
            this.height = height;
            map = new int[width, height];
        }

        private bool LegalX(int x) {
            return x >= 0 && x < width;
        }

        private bool LegalY(int y) {
            return y >= 0 && y < height;
        }

        private int this[int x, int y] {
            get {
                return LegalX(x) && LegalY(y) ? map[x, y] : 0;
            }
        }

        private static Random rnd = new Random();

        public void Randomize(double frequency = 0.5) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    map[x, y] = rnd.NextDouble() < frequency ? 1 : 0;
                }
            }
        }

        private static int[] deltaX = { +1, +1, 0, -1, -1, -1, 0, +1 };
        private static int[] deltaY = { 0, +1, +1, +1, 0, -1, -1, -1 };

        public int Neighbours(int x, int y) {
            int count = 0;

            for (int i = 0; i < 8; i++) {
                int nx = x + deltaX[i];
                int ny = y + deltaY[i];
                if (LegalX(nx) && LegalY(ny)) {
                    count += map[nx, ny];
                }
            }

            return count;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    sb.Append(map[x, y] == 1 ? "X" : ".");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
