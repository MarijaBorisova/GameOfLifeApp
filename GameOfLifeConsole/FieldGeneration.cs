using GameOfLifeConsole.Services;

namespace GameOfLifeConsole
{
    /// <summary>
    /// Class for the methods to generate Manual or Random fields.
    /// </summary>
    public static class FieldGeneration
    {
        public static int[,] GenerateBlinker()
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

        public static int[,] GenerateRandom()
        {
                var rowsInField = AppUserInterface.GetValidatedNumber("Please, insert the number of rows: ", 5, 100);
                var columnsInField = AppUserInterface.GetValidatedNumber("Please, insert the quantity of columns: ", 5, 200);
                var gameField = new int[rowsInField, columnsInField];
                Random random = new Random();

                for (int row = 0; row < gameField.GetLength(0); row++) // Solid principles, the code of random numbers generating.
                {
                    for (int column = 0; column < gameField.GetLength(1); column++)
                    {
                        gameField[row, column] = random.Next(2); // 0- dead cell, 1- alive
                    }
                }

            return gameField;
        }
    }
}
