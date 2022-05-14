using GameOfLifeConsole.Services;
using System.Diagnostics;

namespace GameOfLifeConsole
{
    /// <summary>
    /// Class of Implementation of GameLogic.
    /// </summary>
    public class Game
    {
        public GameLogic gameLogic;
        public GameLogic[] gameParallel;
        private FileReadSave _fileReadSave = new FileReadSave();
        private uint _maxRuns = 50;
        private int _runs = 0;
        //public Game(GameLogic gameLogic, GameLogic[] gameParallel)
        //{
        //    this.gameLogic = gameLogic;
        //    this.gameParallel = gameParallel;
        //}
        //{
        //    gameLogic = new GameLogic();
        //    GameLogic [] gameParallel= new GameLogic;
        //}

        public Game()
        {
            gameLogic = new GameLogic();
        }

        /// <summary>
        /// The method for running the game.
        /// </summary>
        public void Run()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            while (true)
            {
                Console.Clear();
                AppUserInterface.Start();
                switch (Console.ReadLine())
                {
                    case "M":
                        {
                            StartGameManually();
                        }
                        break;
                    case "R":
                        {
                            StartGameRandom();
                        }
                        break;
                    case "P":
                        {
                            ParallelStartGamesRandom();
                        }
                        break;
                    default:
                        {
                            AppUserInterface.IncorrectDataInput();
                            Console.ReadLine();
                        }
                        break;
                }
                while (gameLogic.AliveCells() > 0 && _runs++ < _maxRuns)
                {
                    //if (gameParallel != null)
                    //{
                    //    for (int i = 0; i < gameParallel.Length; i++)
                    //    {
                    //        //Console.WriteLine("The Game Count: {0}", gameParallel[i].gameTotal);
                    //    }
                    //}
                    //else
                    //{
                        Console.Clear();
                        Console.Title = gameLogic.countIteration.ToString("Iteration: {0}")
                            + gameLogic.AliveCells().ToString("   Alive cells number: {0}");
                        Console.SetCursorPosition(0, 0);
                        gameLogic.NewCellGeneration();
                        gameLogic.DrawField();
                        Thread.Sleep(1000);
                        Console.WriteLine();
                    //}


                    //Console.Clear();
                    //Console.Title = gameLogic.countIteration.ToString("Iteration: {0}")
                    //    + gameLogic.AliveCells().ToString("   Alive cells number: {0}");
                    //Console.SetCursorPosition(0, 0);
                    //gameLogic.NewCellGeneration();
                    //gameLogic.DrawField();
                    //Thread.Sleep(1000);
                    //Console.WriteLine();
                    ////Console.ReadLine();

                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        if (gameLogic.AliveCells() == 0)
                        {
                            Console.WriteLine(Repository.CellsDied);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine(Repository.SaveData);
                            string save = Console.ReadLine();
                            if (save == "S")
                            {
                                _fileReadSave.SaveData(gameLogic);
                                gameLogic = _fileReadSave.LoadData();
                            }
                            Console.WriteLine(Repository.StopOrContinue);
                            string exit = Console.ReadLine();
                            if (exit == "E")
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The method in order to print fulfilled data in array manually.
        /// </summary>
        private void StartGameManually()
        {
            gameLogic = new GameLogic(FieldGeneration.GetGlider());
        }

        /// <summary>
        /// The method to print fulfilled data in array randomly.
        /// </summary>
        public void StartGameRandom()
        {
            Console.Clear();
            try
            {
                gameLogic = new GameLogic(FieldGeneration.GenerateRandom());
            }
            catch (Exception)
            {
                AppUserInterface.IncorrectDataInput();
                Console.ReadLine();
            }
        }

        /// <summary>
        /// The method to print fulfilled data in array randomly for 1000 games.
        /// </summary>
        public void ParallelStartGamesRandom()
        {
            Console.Clear();
            Console.WriteLine(Repository.MultipleGameRequirements);
            Console.WriteLine(Repository.MultipleGameSelection);
            Console.WriteLine(Repository.MultipleGameSave);
            Console.ReadLine();
          
            // To call the parallelgames method many times in a column (based on the "times" variable)
            int times = 1000;
            var gameParallel = new GameLogic[1000];

            for (int i = 0; i < times; i++)
            {
                gameParallel[i] = new GameLogic(FieldGeneration.GenerateRandomMultipleGames(15, 15));
            }

            for (int i = 0; i < gameParallel.Length; i++)
            {
                Console.WriteLine("Game number: {0}", gameParallel[i].gameTotal);
                Console.Title = gameParallel[i].AliveCells().ToString("   Alive cells number: {0}");
                gameParallel[i].NewCellGeneration();
                gameParallel[i].DrawField();
                Thread.Sleep(2000);
                Console.WriteLine();

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    if (gameParallel[i].AliveCells() == 0)
                    {
                        Console.WriteLine(Repository.CellsDied);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(Repository.SaveData);
                        string save = Console.ReadLine();
                        if (save == "S")
                        {
                            _fileReadSave.SaveData(gameParallel[i]);
                            gameParallel[i] = _fileReadSave.LoadData();
                        }
                        Console.WriteLine(Repository.StopOrContinue);
                        string exit = Console.ReadLine();
                        if (exit == "E")
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
