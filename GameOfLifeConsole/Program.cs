using GameOfLifeConsole.Services;
using System.IO;

namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            while (true)
            {
                Console.Clear();
                try
                {

                    uint MaxRuns = 20;
                    int runs = 0;
                    int[,] seed = null;

                    Console.WriteLine("App Title: Game Of Life");
                    Console.WriteLine("Please, select if you would like to see the Blinker life circle (M) or " +
                        "LifeCircle with Random numbers (R). \t");
                    Console.Write("Select : M or R:\t ");

                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    switch (consoleKey)
                    {
                        case ConsoleKey.M:
                            seed = new int[,]
                           {
                    {0,0,0,0,0},
                    {0,0,0,0,0},
                    {0,1,1,1,0},
                    {0,0,0,0,0},
                    {0,0,0,0,0}

                           };
                            //in order to create the object, ctor of this class, path should be
                            FileReadSave _fileReadSave = new FileReadSave();
                            GameSeed gameSeed = new GameSeed(seed);

                            gameSeed.AliveCells().ToString();

                            while (gameSeed.AliveCells() > 0 && runs++ < MaxRuns)
                            {
                                Console.Clear();
                                Console.WriteLine("Iteration {0}", gameSeed.CountIteration);
                                gameSeed.NewCellGeneration();
                                gameSeed.DrawField();
                                Console.WriteLine();

                                if (gameSeed.AliveCells() == 0)
                                {
                                    Console.WriteLine("Everyone is died!");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.ReadLine();
                                }
                            }
                            _fileReadSave.SaveData(gameSeed);
                            gameSeed = _fileReadSave.LoadData();
                            try
                            {

                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;

                        case ConsoleKey.R:
                            while (true)
                            {
                                Console.Clear();
                                try
                                {
                                    Console.WriteLine("Please, insert the size of game and number of cells. \t");
                                    Console.Write("The number of rows:\t ");
                                    int row = int.Parse(Console.ReadLine());
                                    Console.Write("The number of columns:\t ");
                                    int column = int.Parse(Console.ReadLine());

                                    seed = new int[row, column];
                                    Random random = new Random();

                                    for (int y = 0; y < seed.GetLength(0); y++) // Solid principles, the code of random numbers generating.
                                    {
                                        for (int x = 0; x < seed.GetLength(1); x++)
                                        {
                                            seed[y, x] = random.Next(2); // 0- dead cell, 1- alive
                                        }
                                    }
                                    for (int y = 0; y < seed.GetLength(0); y++) // The part which input the array elements.
                                    {
                                        for (int x = 0; x < seed.GetLength(1); x++)
                                        {

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

                                //in order to create the object, ctor of this class, path should be
                                FileReadSave _fileReadSaveR = new FileReadSave();
                                GameSeed gameSeedRandom = new GameSeed(seed);
                                gameSeedRandom.AliveCells().ToString();

                                while (gameSeedRandom.AliveCells() > 0 && runs++ < MaxRuns)
                                {
                                    Console.Clear();
                                    Console.Title = gameSeedRandom.CountIteration.ToString("Iteration {0}");
                                    Console.SetCursorPosition(0, 0);
                                    gameSeedRandom.NewCellGeneration();
                                    gameSeedRandom.DrawField();
                                    Console.WriteLine();

                                    string stop;

                                    if (gameSeedRandom.AliveCells() == 0)
                                    {
                                        Console.WriteLine("Everyone is died!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nTo continue iteration, press the key 'Enter'." +
                                            " \nTo stop iteration, press 's' key.");
                                        stop = Console.ReadLine();
                                        if (stop == "s")
                                        {
                                            break;
                                        }
                                    }
                                }
                                _fileReadSaveR.SaveData(gameSeedRandom);
                                gameSeed = _fileReadSaveR.LoadData();        
                            }
                        default:

                            Console.WriteLine("\nYou input incorrect data! Please, try again.");
                            Console.ReadLine();
                            break;
                        }
                    }
                catch (Exception)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
