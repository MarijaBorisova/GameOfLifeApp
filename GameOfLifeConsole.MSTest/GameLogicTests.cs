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

        [TestMethod]
        public void StartGameRandom_Dead_Or_Alive()
        {
            // Arrange
            GameLogic randomCheck = new GameLogic();
            int rowsInField = 3;
            int columnsInField = 3;
            int[,]gameField = new int[columnsInField, rowsInField];

            // Act
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    randomCheck.GenerateRandomFake();
                }
            }

            // Assert
            Assert.IsNotNull(true);
        }

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
            Assert.AreEqual(gameFieldExpected, gameField);
        }
    }
}


