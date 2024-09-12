using System;

namespace ConwaysGoL {
    public class Program {
        public static void Main(string[] args) {
            World world = new World(120, 60);
            world.Randomize();
            Console.WriteLine(world.ToString());
        }
    }
}