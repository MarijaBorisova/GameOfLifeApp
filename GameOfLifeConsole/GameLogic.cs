﻿namespace GameOfLifeConsole
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
        private int rowsInField;
        private int columnsInField;
        //Field, property to count the next cell generation.
        public int countIteration { get; set; }

        // Constructor to inialiaze Json convert from int to string.
        public GameLogic()
        {
            gameField = new int[0, 0];
        }

        /// <summary>
        /// Const. creates the field of cells by cloning the array.
        /// </summary>
        /// <param name="newField"> The new array in which the new cell generation will be created. </param>
        public GameLogic(int[,] newField)
        {
            gameField = (int[,])newField.Clone();
            rowsInField = gameField.GetLength(0);
            columnsInField = gameField.GetLength(1);
            countIteration = 1;
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
        /// To count the number of alive cells.
        /// </summary>
        /// <returns> Alive cells number.</returns>
        public int AliveCells()
        {
            int count = 0;
            for (int y = 0; y < columnsInField; y++) 
            {
                for (int x = 0; x < rowsInField; x++)
                {
                    if (gameField[y, x] == 1)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Alive cells number: " + count);
            // Adds one to the count if there is a cell that is alive and
            // returns the value.
            return count;
        }

        /// <summary>
        /// Passes the coordinates of the cell and count the number of neighbours the cell has.
        /// </summary>
        /// <param name="currentRow"> The current cell x coordinate. </param>
        /// <param name="currentColumn"> The current cell y coordinate. </param>
        /// <returns> Alive number of neighbours. </returns>
        public int NeighboursCount(int currentColumn, int currentRow)
        {
            int count = 0;

            for (int column = currentColumn - 1; column < currentColumn + 1; column++)
            {
                for (int row = currentRow - 1; row < currentRow + 1; row++)
                {
                    int actualrow = (row + gameField.GetLength(0)) % gameField.GetLength(0);
                    int actualColumn = (column + gameField.GetLength(1)) % gameField.GetLength(1);
                    count++;
                }
            }

            count -= gameField[currentColumn, currentRow];
            return count;
        }

        /// <summary>
        /// New Cells/Field generation method.
        /// </summary>
        public void NewCellGeneration()
        {
            int[,] newGameField = new int[columnsInField, rowsInField];
            for (int y = 0; y < columnsInField; y++)
            {
                for (int x = 0; x < rowsInField; x++)
                {
                    int neighboursNumber = NeighboursCount(x, y);
                    // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                    if (gameField[y, x] == 1 && neighboursNumber <= 2)
                    {
                        newGameField[y, x] = 0;
                    }
                    //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                    else if (gameField[y, x] == 0 && neighboursNumber == 3)
                    {
                        newGameField[y, x] = 1;
                    }
                    //Any live cell with two or three live neighbours lives on to the next generation.
                    else if (gameField[y, x] == 1 &&
                           (neighboursNumber == 2 || neighboursNumber == 3))
                    { 
                        newGameField[y, x] = 1;
                    }
                    //Any live cell with more than three live neighbours dies, as if by overpopulation.
                    else if (gameField[y, x] == 1 && neighboursNumber == 4 || neighboursNumber > 4)
                    {
                        newGameField[y, x] = 0;
                    }
                }
            }

            gameField = (int[,])newGameField.Clone();
            countIteration++;
        }
    }
}
