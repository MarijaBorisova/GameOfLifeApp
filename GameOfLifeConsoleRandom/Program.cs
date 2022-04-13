namespace GameOfLifeConsoleRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            uint MaxRuns = 100;
            int runs = 0;

            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("App Title: Game Of Life");
                    Console.WriteLine("Please, insert the size of game and number of cells. \t");

                    Console.Write("The number of rows:\t ");
                    int row = int.Parse(Console.ReadLine());
                    Console.Write("The number of columns:\t ");
                    int column = int.Parse(Console.ReadLine());

                    int[,] gameField = new int[row, column];
                    GameSeed gameSeed = new GameSeed(gameField);

                    Console.WriteLine("Field 0");
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
                }
                catch (Exception)
                {
                    Console.WriteLine("Input incorrect data! Please, try again.");
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}