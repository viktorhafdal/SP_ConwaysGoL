using System;
using System.Text;

namespace ConwaysGoL {
    internal class World {
        private int[,] map { get; set; }
        private int width, height;

        public World() { //Initialises the world with a width and height of 15.
            this.width = 15;
            this.height = 15;
            map = new int[width, height];
        }

        public World(int width, int height) { //Initialises the world with width and height.
            this.width = width;
            this.height = height;
            map = new int[width, height];
        }

        private bool LegalX(int x) { //Returns true if line passes.
            return x >= 0 && x < width;
        }

        private bool LegalY(int y) { //Returns true if line passes.
            return y >= 0 && y < height;
        }

        private int this[int x, int y] {
            get {
                return LegalX(x) && LegalY(y) ? map[x, y] : 0; //If LegalX and LegalY are true, return map[x, y], else return 0.
            }
        }

        private static Random rnd = new Random();

        public void Randomize(double frequency = 0.5) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    map[x, y] = rnd.NextDouble() < frequency ? 1 : 0; //Loops through the map and sets the value to 1 if the random number is less than the frequency, else 0.
                }
            }
        }

        private static int[] deltaX = { +1, +1, 0, -1, -1, -1, 0, +1 }; //Array of the x values of the 8 neighbours.
        private static int[] deltaY = { 0, +1, +1, +1, 0, -1, -1, -1 }; //Array of the y values of the 8 neighbours.

        public int Neighbours(int x, int y) {
            int count = 0;
            /* Loops through the 8 neighbours of the cell at x and y 
             * and adds a neighbour to the count if the neighbour 
             * is within the bounds of the map.
             */

            for (int i = 0; i < 8; i++) { //
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
                    sb.Append(map[x, y] == 1 ? "X" : "."); //If the cell is alive/1, append "X", else "."
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
