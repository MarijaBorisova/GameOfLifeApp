namespace GameOfLifeConsole
{
    /// <summary>
    /// logic of game
    /// </summary>
    public class GameSeed
    {
        // the place of cells in the field will be with x and y coordinates in array
        //current field of cells, playfield, an array in which all the cells will be counted (alive or dead)
        int[,] gameField;
        // current field will be changed after new requirements
        int[,] changedField;
        //field sizes
        int row; 
        int column;

        /// <summary>
        /// const. creates the field of cells by cloning the array
        /// </summary>
        /// <param name="newField"></param>
        public GameSeed(int[,] newField) 
        {
            gameField = (int[,])newField.Clone();

            row = gameField.GetLength(1);
            column = gameField.GetLength(0);

            //creates an empty field to store the next changed field
            changedField = new int[column, row];
        }

        public void DrawField()
        {
            for (int y = 0; y < column; y++)
            {
                for (int x = 0; x < row; x++)
                    Console.Write("{0}", gameField[y, x]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// to count the number of alive cells
        /// </summary>
        /// <returns></returns>
        public int AliveCells()
        {
            int count = 0;

            for (int y = 0; y < column; y++)
                for (int x = 0; x < row; x++)
                    if (gameField[y, x] == 1)
                        count++;

            return count;//adds one to the count if there is a cell that is alive and returns the value
        }

        /// <summary>
        /// passes the coordinates of the cell and count the number of neighbours the cell has
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int NeighboursCount(int x, int y)
        {
            int count = 0;
            
                for (int i = x - 1; i < x + 1; i++)
                {
                    for (int j = y - 1; j < y + 1; j++)
                    {
                        if (!((i < 0 || j < 0) || (i >= column || j >= row)))
                        {
                            if (gameField[i, j] == 1)
                                count++;
                        }
                    }
                }
                return count;
            }

        public void NewCellGeneration()
        {
            int[,] newGameField = new int[column, row];
            changedField = (int[,])gameField.Clone();

            for (int y = 0; y < column; y++)
            {
                for (int x = 0; x < row; x++)
                {
                    int neighboursNumber = NeighboursCount(x,y);
                    //if the cell is dead and has three neighbours.
                    //If it does a new cell is born. 
                    if (gameField[y, x] == 0 && neighboursNumber == 3)
                        newGameField[y, x] = 1;
                    else if (gameField[y, x] == 1 &&
                           (neighboursNumber == 2 || neighboursNumber == 3))//if the cell is alive and it has two or three neighbours.
                                                                            //If that is true the cell is alive
                        newGameField[y, x] = 1;
                }
            }
            gameField = (int[,])newGameField.Clone();
        }
    }
}
