using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ADVENTURETOWN!");
            Game game = new Game();

            var playing = true;
            while (playing)
            {
                Console.Clear();
                game.Setup();
            }

        }
    }
}
