namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] field = new int[5, 5]
            //	{
            //		{0,0,0,0,0},
            //		{0,0,0,0,0},
            //		{0,1,1,1,0},
            //		{0,0,0,0,0},
            //		{0,0,0,0,0}

            //	};
            //int rows = field.GetLength(0);
            //int columns = field.GetLength(1);	

            //         for (int y = 0; y < rows; y++)
            //         {
            //             for (int x = 0; x < columns; x++)
            //             {
            //                 Console.Write(field[y,x] + " ");
            //             }
            //             Console.WriteLine();
            //         }
            /////
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
                //Console.WriteLine("Field {0}", gameSeed.ChangesCounter);

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