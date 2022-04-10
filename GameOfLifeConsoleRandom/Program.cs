
using System;


namespace GameOfLifeConsoleRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("App Title: Game Of Life");
                    Console.WriteLine("Please, insert the size of game and number of cells. \t");

                    Console.Write("The number of rows:\t ");
                    int rows = int.Parse(Console.ReadLine());
                    Console.Write("The number of columns:\t ");
                    int columns = int.Parse(Console.ReadLine());
                    //Console.Write("The quantity of cells:\t ");
                    //int density = int.Parse(Console.ReadLine());



                    int[,] field = new int[rows, columns];
                    Random random = new Random();

                    for (int y = 0; y < field.GetLength(0); y++) //solid principles, the code of random numbers generating
                    {
                        for (int x = 0; x < field.GetLength(1); x++)
                        {
                            field[y, x] = random.Next(2); // 0- dead cell, 1- alive
                        }

                    }

                    for (int y = 0; y < field.GetLength(0); y++) // the part which input the array elements
                    {
                        for (int x = 0; x < field.GetLength(1); x++)
                        {
                            Console.Write(field[y, x] + " ");
                        }
                        Console.WriteLine();
                    }
                }

                catch (Exception)
                {
                    Console.WriteLine("Input incorrect data! Please, try again.");
                    Console.ReadLine();
                    continue;
                }
                Console.ReadLine();

                //int[,] field = new int[5,5];
                //Random random = new Random();
                //int rows = field.GetLength(0);
                //int columns = field.GetLength(1);

                //	for (int y = 0; y < rows; y++) //solid principles, the code of random numbers generating
                //	{
                //		for (int x = 0; x < columns; x++)
                //		{
                //			field[y, x] = random.Next(2); // 0- dead cell, 1- alive
                //		}

                //	}

                //	for (int y = 0; y < rows; y++) // the part which input the array elements
                //	{
                //		for (int x = 0; x < columns; x++)
                //		{
                //			Console.Write(field[y, x] + " ");
                //		}
                //		Console.WriteLine();
                //	}
                //}
            }
        }
    }
}