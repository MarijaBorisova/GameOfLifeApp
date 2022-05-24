using GameOfLifeConsole.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GameOfLifeConsole
{
    /// <summary>
    /// Class of Implementation of GameLogic.
    /// </summary>
    public class Game
    {
        public List<GameLogic> games = new List<GameLogic>();
        private FileReadSaveMultipleGames _fileReadSaveMultipleGames = new FileReadSaveMultipleGames();
        private uint _maxRuns = 50;
        private int _runs = 0;
        public List<int> selectedEightGames = new List<int>(8);
        public int times;

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
                            RunGame();
                        }
                        break;
                    case "R":
                        {
                            StartGameRandom();
                            RunGame();
                        }
                        break;
                    case "P":
                        {
                            ParallelStartGamesRandom();
                            SelectEightGamesFromThousand();
                            RunThousandGames();
                        }
                        break;
                    default:
                        {
                            AppUserInterface.IncorrectDataInput();
                            Console.ReadLine();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// The method in order to print fulfilled data in array manually.
        /// </summary>
        private void StartGameManually()
        {
            games.Add(new GameLogic(FieldGeneration.GetGlider()));
        }

        /// <summary>
        /// The method to print fulfilled data in array randomly.
        /// </summary>
        public void StartGameRandom()
        {
            Console.Clear();
            try
            {
                games.Add(new GameLogic(FieldGeneration.GenerateRandom()));
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
            Console.WriteLine(Repository.SelectEightGames);
            Console.WriteLine(Repository.MultipleGameSave);

            // To call the parallelgames method many times in a column (based on the "times" variable)
            int times = 1000;

            for (int i = 0; i < times; i++)
            {
                games.Add(new GameLogic(FieldGeneration.GenerateRandomMultipleGames(15, 15)));
            }
        }

        /// <summary>
        /// To select eight games from the executed in parallel thousand games.
        /// </summary>
        public void SelectEightGamesFromThousand()
        {
            selectedEightGames = new List<int>();
            while (selectedEightGames.Count <= 8)
            {
                try
                {
                    Console.WriteLine(Repository.SelectEightGamesNumber);
                    int gameNumber = Convert.ToInt32(Console.ReadLine());
                    if (gameNumber < games.Count)
                    {
                        selectedEightGames.Add(gameNumber);
                    }
                }
                catch (Exception)
                {
                    AppUserInterface.IncorrectDataInput();
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// To run game as manual as random.
        /// </summary>
        private void RunGame()
        {
            var exit = false;
            while ((games.Last().AliveCells() > 0 && _runs++ < _maxRuns) || !exit)
            {
                Console.Clear();
                Console.Title = games.Last().countIteration.ToString("Iteration: {0}")
                    + games.Last().AliveCells().ToString("   Alive cells number: {0}");
                Console.SetCursorPosition(0, 0);
                games.Last().NewCellGeneration();
                games.Last().DrawField();
                Thread.Sleep(1000);
                Console.WriteLine();
                if (exit = PauseMenu())
                {
                    break;
                }
            }
        }

        /// <summary>
        /// To run the game for 1000 games.
        /// </summary>
        private void RunThousandGames()
        {
            var exit = false;
            while (!exit)
            {
                for (var totalGamesNr = 0; totalGamesNr < games.Count; totalGamesNr++)
                {
                    //games.Add(games[totalGamesNr]);
                    ////Console.WriteLine("Total Alive Cells count in 1000 games:"
                    ////    + games[totalGamesNr].AliveCells().ToString("{0}"));
                    ////Console.WriteLine(games[totalGamesNr].AliveCells().ToString("   Alive cells number: {0}"));
                    //Console.ReadLine();

            }
                foreach (var gameNr in selectedEightGames)
                {
                    Console.Title = games[gameNr].AliveCells().ToString("   Alive cells number: {0}");
                    games[gameNr].NewCellGeneration();
                    Console.WriteLine("Game Nr :" + gameNr);
                    games[gameNr].DrawField();
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    if (exit = PauseMenu())
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// To implement the functionality of keys: restore the data, continue or quit from the game variant.
        /// </summary>
        /// <returns> If the keys are input incorrectly the method will not implement the needed keys.</returns>
        private bool PauseMenu()
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                if (games.Last().AliveCells() == 0)
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
                        _fileReadSaveMultipleGames.SaveData(games);
                        _fileReadSaveMultipleGames.LoadData();
                    }
                    Console.WriteLine(Repository.StopOrContinue);
                    string exit = Console.ReadLine();
                    if (exit == "E")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

