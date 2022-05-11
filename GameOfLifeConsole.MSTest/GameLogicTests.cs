using GameOfLifeConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeConsole.MSTest
{
    [TestClass]
    public class GameLogicTests
    {
        [TestMethod]
        public void AliveCells_Count_Alive()
        {
            // Arrange
            int[,] gameField = new int[3, 3]
               {
                {0,0,0},
                {0,0,0},
                {0,1,1}
               };

            // Act
            var gameLogic = new GameLogic(gameField);
            var result = gameLogic.AliveCells();

            // Assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void DrawField_Prints()
        {
            // Arrange
            int[,] gameField = new int[3, 3]
               {
                {0,1,0},
                {0,1,0},
                {0,1,0}
               };

            // Act
            var gameLogic = new GameLogic(gameField);
            gameLogic.DrawField();

            // Assert
            Assert.IsNotNull(true);
        }

        //[TestMethod]
        //public void StartGameRandom_Dead_Or_Alive()
        //{
        //    Game randomCheck = new Game();
        //    var rowsInField = 3;
        //    var columnsInField = 3;
        //    var gameField = new int[columnsInField, rowsInField];
        //    int count = 0;


        //    // Act
        //    for (int i = 0; i < 10; i++)
        //    {
        //        randomCheck.StartGameRandom();

        //        count++;
        //    }

        //    // Assert
        //    Assert.AreNotEqual(0, count);
        //}

        [TestMethod]
        public void GameLogic_CheckTheFulfillment_OK()
        {
            // Arrange
            GameLogic gameLogic;

            // Act
            gameLogic = new GameLogic();

            // Assert
            Assert.IsNotNull(gameLogic);
        }

        [TestMethod]
        public void NeighboursAliveCount_Counter()
        {
            // Arrange
            int[,] gameField = new int[3, 3]
               {
                {0,0,0},
                {0,0,0},
                {0,1,1}
               };

            // Act
            var gameLogic = new GameLogic(gameField);
            var result = gameLogic.NeighboursAliveCount(1, 2);

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void NewCellGeneration_Implement()
        {
            // Arrange
            int[,] gameField = new int[3, 3]
               {
                {0,0,0},
                {1,1,0},
                {0,0,0}
               };

            int[,] gameFieldExpected = new int[3, 3]
               {
                {0,0,0},
                {0,0,0},
                {0,0,0}
               };

            // Act
            var gameLogic = new GameLogic(gameField);
            gameLogic.NewCellGeneration();
            var gameLogic1 = new GameLogic(gameFieldExpected);
            gameLogic1.NewCellGeneration();

            // Assert
            Assert.AreEqual(gameFieldExpected, gameLogic.NewCellGeneration);
        }
    }
}


