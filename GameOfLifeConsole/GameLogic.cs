namespace GameOfLifeConsole
{
    /// <summary>
    /// Logic of game.
    /// </summary>
    [Serializable]
    public class GameLogic
    {
        // The place of cells in the field will be with x and y coordinates in array.
        // Current field of cells, playfield, an array in which all the cells will be counted
        // (alive or dead).
        public int[,] gameField;
        // Current field will be changed after new requirements.
        public int[,] changedField;
        // Field sizes.
        private int rowsInField;
        private int columnsInField;
        //Field, property to count the next cell generation.
        public int CountIteration { get; set; }

        // Constructor to inialiaze Json convert from int to string.
        public GameLogic()
        {
            gameField = new int[0, 0];
            changedField = new int[0, 0];
        }

        /// <summary>
        /// Const. creates the field of cells by cloning the array.
        /// </summary>
        /// <param name="newField"> The new array in which the new cell generation will be created. </param>
        public GameLogic(int[,] newField)
        {
            gameField = (int[,])newField.Clone();
            rowsInField = gameField.GetLength(1);
            columnsInField = gameField.GetLength(0);
            // Creates an empty field to store the next changed field.
            changedField = new int[columnsInField, rowsInField];
            CountIteration = 0;
        }

        /// <summary>
        /// Print the current field on console.
        /// </summary>
        public void DrawField()
        {
            for (int y = 0; y < columnsInField; y++)
            {
                for (int x = 0; x < rowsInField; x++)
                    // Ternar operator in order to fulfill the array, if alive cell(1) - #, if no .
                    Console.Write(gameField[y, x] == 1 ? " # " : " . ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// The method to create and fulfill the random number array with the data of alive and dead cells.
        /// </summary>
        public void GetGameData()
        {
            rowsInField = AppUserInterface.GetValidatedNumber("Please, insert the number of rows: ", 5, 100);
            columnsInField = AppUserInterface.GetValidatedNumber("Please, insert the quantity of columns: ", 5, 200);
            gameField = new int[rowsInField, columnsInField];
            Random random = new Random();

            for (int row = 0; row < gameField.GetLength(0); row++) // Solid principles, the code of random numbers generating.
            {
                for (int column = 0; column < gameField.GetLength(1); column++)
                {
                    gameField[row, column] = random.Next(2); // 0- dead cell, 1- alive
                }
            }
        }

        /// <summary>
        /// To count the number of alive cells.
        /// </summary>
        /// <returns> Alive cells number.</returns>
        public int AliveCells()
        {
            int count = 0;
            for (int y = 0; y < columnsInField; y++)
                for (int x = 0; x < rowsInField; x++)
                    if (gameField[y, x] == 1)
                        count++;
            Console.WriteLine("Alive cells number: " + count);

            // Adds one to the count if there is a cell that is alive and
            // returns the value.
            return count;
        }

        /// <summary>
        /// Passes the coordinates of the cell and count the number of neighbours the cell has.
        /// </summary>
        /// <param name="x"> The current cell x coordinate. </param>
        /// <param name="y"> The current cell y coordinate. </param>
        /// <returns> Alive number of neighbours. </returns>
        public int NeighboursCount(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i < x + 1; i++)
            {
                for (int j = y - 1; j < y + 1; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= columnsInField || j >= rowsInField)))
                    {
                        if (gameField[i, j] == 1)
                            count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// New Cells/Field generation method.
        /// </summary>
        public void NewCellGeneration()
        {
            int[,] newGameField = new int[columnsInField, rowsInField];
            changedField = (int[,])gameField.Clone();


            for (int y = 0; y < columnsInField; y++)
            {
                for (int x = 0; x < rowsInField; x++)
                {
                    int neighboursNumber = NeighboursCount(x, y);
                    // If the cell is dead and has three neighbours.
                    // If it does a new cell is born. 
                    if (gameField[y, x] == 0 && neighboursNumber == 3)
                        newGameField[y, x] = 1;
                    else if (gameField[y, x] == 1 &&
                           (neighboursNumber == 2 || neighboursNumber == 3))// If the cell is alive and it has two or three neighbours.
                                                                            // If that is true the cell is alive.
                        newGameField[y, x] = 1;
                    else if (gameField[y, x] == 1 && (neighboursNumber < 2 || neighboursNumber > 3))
                        newGameField[y, x] = 0;
                }
            }
            gameField = (int[,])newGameField.Clone();
            CountIteration++;
        }
    }
}
