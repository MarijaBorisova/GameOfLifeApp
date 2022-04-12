namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            uint MaxRuns = 10;
            int runs = 0;

            int[,] seed = new int[,]
                {
                    {0,0,0,0,0},
                    {0,0,0,0,0},
                    {0,1,1,1,0},
                    {0,0,0,0,0},
                    {0,0,0,0,0}
                };

            GameSeed gameSeed = new GameSeed(seed);

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
                    //break;
                }
            }
        }
    }
}