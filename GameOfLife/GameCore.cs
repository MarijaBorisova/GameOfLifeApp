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
       
        private bool[,] field; //an array in which all the cells will be an account (alive or dead)
        private readonly int rows; //in order to fix the number in constructor
        private readonly int columns;
        private Random random= new Random(); //to insert the cells in the field Random number generator in the field

        public GameCore(int rows, int columns, int density)//rows and columns for the size of the field, density for cells quantity in the beginning
        {
            this.rows = rows;
            this.columns = columns; 
            field = new bool[rows, columns];
            Random random= new Random();
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(density)==0; //Random generates the random cells numbers till ==0 (true), so the new cell in the field will be generated, 1=false
                }
            }

        }
        // method for next generation of cell
        public void CellNextGeneration()

        {
            var newfield = new bool[rows, columns];// the new array in which the new cell generation will be created
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighboursNumber = CellNeighboursCount(x, y);
                    var cellAlive = field[x, y];// if there is any cell alive in the array

                    if (!cellAlive && neighboursNumber == 2)//if cellAlive is false (dead)

                        newfield[x, y] = true;
                    else if (cellAlive && (neighboursNumber < 1 || neighboursNumber > 2))
                        newfield[x, y] = false;
                    else
                        newfield[x, y] = field[x, y];
                }

            }

            field = newfield;
            //generation++;
        }

        // the method to get the cell current generation  after creating next generation

        public bool [,]CallCurrentGeneration()
        {
            var result =new bool[rows, columns]; // create the new array on the basis of the running our old array
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    result[x,y]=field[x,y];//copy the data from old field to the new result array
                }

            }
            return result;
        }

        //  the method to count the neighbours to the current cell by x and y coordinates

        private int CellNeighboursCount(int x, int y) 
        {
            int count = 0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    int column = x + i;
                    int row = y + j;
                   
                    
                    var currentCellIs =column==x&row==y;//to check if it is not a current cell
                    var cellAlive = field[column, row];

                    if (cellAlive && !currentCellIs)
                        count++;
     
                }
            }
            return count;
        }
        
    }

}
