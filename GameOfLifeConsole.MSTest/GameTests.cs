using GameOfLifeConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeConsole.MSTest
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_Create_Ok()
        {
            // Arrange
            Game game;

            // Act
            game = new Game();

            //Assert
            Assert.IsNotNull(game);
        }
    }
}


