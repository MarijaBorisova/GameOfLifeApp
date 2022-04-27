namespace GameOfLifeMVC.Models
{
    public class GameModel
    {
        // The place of cells in the field will be with x and y coordinates in array.
        // Current field of cells, playfield, an array in which all the cells will be counted
        // (alive or dead).
        public int[,] gameField;
        // Current field will be changed after new requirements.
        public int[,] changedField;
        // Field sizes.
        private int row;
        private int column;
        //Field, property to count the next cell generation.
        public int CountIteration { get; set; }

        public GameModel()
        {
            gameField = new int[0, 0];
            changedField = new int[0, 0];
        }

        /// <summary>
        /// Const. creates the field of cells by cloning the array.
        /// </summary>
        /// <param name="newField"> The new array in which the new cell generation will be created. </param>
        public GameModel(int[,] newField)
        {
            gameField = (int[,])newField.Clone();
            row = gameField.GetLength(1);
            column = gameField.GetLength(0);

            // Creates an empty field to store the next changed field.
            changedField = new int[column, row];
            CountIteration = 0;
        }
    }
}
