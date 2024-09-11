using System;

namespace ConwaysGoL {
    public class Program {
        public static void Main(string[] args) {
            World world = new World();
            world.Randomize();
            Console.WriteLine(world.ToString());
        }
    }
}