namespace GameOfLifeConsole
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
                    {0,0,1,0,0},
                    {0,1,1,1,0},
                    {0,0,1,0,0},
                    {0,0,0,0,0}
                   };
                        GameSeed gameSeed = new GameSeed(seed);
                        Console.ReadLine();
                        Console.WriteLine("Start Field");
                        gameSeed.DrawField();
                        Console.WriteLine();

                        while (gameSeed.AliveCells() > 0 && runs++ < MaxRuns)
                        {
                            Console.WriteLine();
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

                                GameSeed gameSeedRandom = new GameSeed(seed);
                                Console.WriteLine("Start Field");
                                gameSeedRandom.DrawField();
                                Console.WriteLine();

                                while (gameSeedRandom.AliveCells() > 0 && runs++ < MaxRuns)
                                {
                                    Console.WriteLine();
                                    gameSeedRandom.NewCellGeneration();
                                    gameSeedRandom.DrawField();
                                    Console.WriteLine();

                                    if (gameSeedRandom.AliveCells() == 0)
                                    {
                                        Console.WriteLine("Everyone is died!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.ReadLine();
                                    }
                                }
                            }
                            catch (Exception)
                            {                                   
                                    Console.WriteLine("Input incorrect data! Please, try again.");
                                    Console.ReadLine();
                                    continue;
                            }
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
