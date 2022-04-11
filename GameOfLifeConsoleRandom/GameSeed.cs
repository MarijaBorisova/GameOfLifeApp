﻿namespace GameOfLifeConsoleRandom
{
    /// <summary>
    /// logic of game
    /// </summary>
    public class GameSeed
    {
        // the place of cells in the field will be with x and y coordinates in array

        int row; //field sizes
        int column;
        int[,] gameField;//current field of cells, playfield, an array in which all the cells will be counted (alive or dead)
        int[,] changedField;// current field will be changed after new requirements
        int changesCounter; //counter that holds the number of changes that have been iterated


        //public int ChangesCounter //property to allow the user to get the current generation
        //{
        //    get { return changesCounter; }
        //}

        public GameSeed(int[,] newField) //const. creates the field of cells by cloning the array
        {
            gameField = (int[,])newField.Clone();

            changesCounter = 1;

            Random random = new Random();

            for (int y = 0; y < gameField.GetLength(0); y++) //solid principles, the code of random numbers generating
            {
                for (int x = 0; x < gameField.GetLength(1); x++)
                {
                    gameField[y, x] = random.Next(2); // 0- dead cell, 1- alive
                }

            }

            for (int y = 0; y < gameField.GetLength(0); y++) // the part which input the array elements
            {
                for (int x = 0; x < gameField.GetLength(1); x++)
                {
                    //Console.Write(gameField[y, x] + " ");
                }
                Console.WriteLine();
            }

            row = gameField.GetLength(1);
            column = gameField.GetLength(0);

            changedField = new int[column, row];//creates an empty field to store the next changed field
        }

        public void DrawField()
        {
            for (int y = 0; y < column; y++)
            {
                for (int x = 0; x < row; x++)
                    Console.Write(gameField[y, x] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int AliveCells()
        {
            int count = 0;

            for (int y = 0; y < column; y++)
                for (int x = 0; x < row; x++)
                    if (gameField[y, x] == 1)
                        count++;

            return count;
        }


        //passes the coordinates of the cell and count the number of neighbours the cell has
        private int Neighbours(int x, int y)
        {
            int count = 0;//variable to hold the number of neighbours the cell has
                          //and then checks each neighbour on which coordinate to the cell is

            //for (int i = -1; i < 2; i++)// -1, the info of neigbours from left side
            //{
            //	for (int j = -1; j < 2; j++)//2- info of neighbours from right side;
            //	{
            //		int column = (x + i);
            //		int row = (y + j);

            //		count++;
            // Check for x - 1, y - 1
            if (x > 0 && y > 0)
            {
                if (gameField[y - 1, x - 1] == 1)
                    count++;
            }

            // Check for x, y - 1
            if (y > 0)
            {
                if (gameField[y - 1, x] == 1)
                    count++;
            }

            // Check for x + 1, y - 1
            if (x < row - 1 && y > 0)
            {
                if (gameField[y - 1, x + 1] == 1)
                    count++;
            }

            // Check for x - 1, y
            if (x > 0)
            {
                if (gameField[y, x - 1] == 1)
                    count++;
            }

            // Check for x + 1, y
            if (x < row - 1)
            {
                if (gameField[y, x + 1] == 1)
                    count++;
            }

            // Check for x - 1, y + 1
            if (x > 0 && y < column - 1)
            {
                if (gameField[y + 1, x - 1] == 1)
                    count++;
            }

            // Check for x, y + 1
            if (y < column - 1)
            {
                if (gameField[y + 1, x] == 1)
                    count++;
            }

            // Check for x + 1, y + 1
            if (x < row - 1 && y < column - 1)
            {
                if (gameField[y + 1, x + 1] == 1)
                    count++;
            }

            return count;
        }

        public void NewCellGeneration()
        {
            int[,] newGameField = new int[column, row];// the new array in which the new cell generation will be created

            changedField = (int[,])gameField.Clone();

            for (int y = 0; y < column; y++)
            {
                for (int x = 0; x < row; x++)
                {
                    if (gameField[y, x] == 0 && Neighbours(x, y) == 3)
                        newGameField[y, x] = 1;
                    //if (gameField[y, x] == 1 &&
                    //	   (Neighbours(x, y) < 2 || Neighbours(x, y) > 3))// in the next generation will not be alive cell
                    //                   newGameField[y, x] = 1; //if false (0)- it will die
                    if (gameField[y, x] == 1 &&
                           (Neighbours(x, y) == 2 || Neighbours(x, y) == 3))// in the next generation will not be alive cell
                        newGameField[y, x] = 1; // if this will be valid with the 2, the overpopulation
                }
            }

            gameField = (int[,])newGameField.Clone();
        }

    }
}
