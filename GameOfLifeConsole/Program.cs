using GameOfLifeConsole.Services;
using System.IO;

namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Run();
        }
    }
}
