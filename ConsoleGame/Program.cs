using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;


namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.Clear();

                int rows;
                int columns;
                int density;

                try
                {
                    Console.WriteLine("App Title: Game Of Life");
                    Console.WriteLine("Please, insert the size of game and number of cells.");


                    Console.WriteLine("The number of rows: ");
                    rows = int.Parse(Console.ReadLine());
                    Console.Write("The number of columns: ");
                    columns = int.Parse(Console.ReadLine());
                    Console.Write("The quantity of cells: ");
                    density = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Input incorrect data! Please, try again.");
                    Console.ReadLine();
                    continue;
                }


                GameCore gameCore = new GameCore(rows, columns, density);

                while (true)
                {
                    var field = gameCore.CallCurrentGeneration();
                    Console.Write('#');

                    gameCore.CellNextGeneration();

                }
            }
            
        }
    }


}