using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
    
{
    /// <summary>
    /// logic of game
    /// </summary>
    public class GameCore
    {
       // the place of cells in the field will be on x and y coordinates in array
        private bool[,] field; // playfield, an array in which all the cells will be counted (alive or dead)
        private readonly int rows; //in order to fix the number in constructor
        private readonly int columns;
        //private Random random= new Random(); //to insert the cells in the field Random number generator in the field

        public GameCore(int rows, int columns, int density)//rows and columns for the size of the field, density for cells quantity in the beginning
        {
            this.rows = rows;
            this.columns = columns; 
            field = new bool[columns, rows]; //creating the field, user should write the size of row (y) and cols (x)
            Random random= new Random();// to create the first cell generation, random number object generator
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(density)==0; //Random generates the random cells numbers till the parameter density ==0 (true), that the new cell in the field will be generated, 1=false
                }
            }

        }
        // method for next generation of cell
        public void CellNextGeneration()

        {
            var newfield = new bool[columns, rows];// the new array in which the new cell generation will be created
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int neighboursNumber = CellNeighboursCount(x, y); //calculation of neighbours
                    var cellAlive = field[x, y];// if there is any cell alive in the array

                    if (!cellAlive && neighboursNumber == 3)//if cellAlive is false (dead), the life shoulf be born

                        newfield[x, y] = true;// the alive cell will be put in newField
                    else if (cellAlive && (neighboursNumber < 2 || neighboursNumber > 3))//the cell is dying
                        newfield[x, y] = false;// in the next generation will not be alive cell
                    else
                        newfield[x, y] = field[x, y];
                }

            }

            field = newfield;
            
        }

        //  the method to count the neighbours to the current cell by x and y coordinates
        // in order to model the situation if the new life should be born or cell will be died

        private int CellNeighboursCount(int x, int y) 
        {
            int count = 0;// variable in which the quantity will be saved
            for (int i = -1; i < 2; i++)// -1, the info of neigbours from left side
            {
                for (int j = -1; j < 2; j++)//2- info of neighbours from right side;
                {
                    int column = (x + i+columns) % columns;
                    int row = (y + j+ rows) % rows;
                   
                    
                    var currentCellIs =column==x&row==y;//to check if it is not a current cell, it should be included
                    var cellAlive = field[column, row];// to count live neigbour cell

                    if (cellAlive && !currentCellIs)
                        count++;//live neighbour, +1 to counter
     
                }
            }
            return count;
        }
        
    }

}
