namespace GameOfLifeConsole
{
    /// <summary>
    /// Class for the methods to generate Manual or Random fields.
    /// </summary>
    public static class FieldGeneration
    {
        /// <summary>
        /// The method to initialize the array as in Glider order.
        /// </summary>
        /// <returns> The array as Glider order.</returns>
        public static int[,] GetGlider()
        {
            return new int[,]
            {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,1,0},
                {0,0,0,1,0},
                {0,0,1,0,0}
            };
        }

        /// <summary>
        /// The method to initialize the array field by the random order.
        /// </summary>
        /// <returns> The array fulfilled by symbols randomly.</returns>
        public static int[,] GenerateRandom()
        {
            var rowsInField = AppUserInterface.GetValidatedNumber("Please, insert the number of rows: ", 5, 100);
            var columnsInField = AppUserInterface.GetValidatedNumber("Please, insert the quantity of columns: ", 5, 200);
            var gameField = new int[columnsInField, rowsInField];
            Random random = new Random();

            for (int row = 0; row < gameField.GetLength(1); row++)
            {
                for (int column = 0; column < gameField.GetLength(0); column++)
                {
                    gameField[column, row] = random.Next(2);
                }
            }

            return gameField;
        }

        /// <summary>
        /// The method to initialize the array field by the random order for multiple games.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns> The array fulfilled by symbols randomly.</returns>
        public static int[,] GenerateRandomMultipleGames(int width, int height)
        {
            var gameField = new int[width, height];
            Random random = new Random();

            for (int row = 0; row < gameField.GetLength(1); row++)
            {
                for (int column = 0; column < gameField.GetLength(0); column++)
                {
                    gameField[column, row] = random.Next(2);
                }
            }

            return gameField;
        }
    }
}
