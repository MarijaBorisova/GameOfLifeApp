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
        //private FileReadSave _fileReadSave = new FileReadSave();
        private FileReadSaveMultipleGames _fileReadSaveMultipleGames = new FileReadSaveMultipleGames();
        private uint _maxRuns = 50;
        private int _runs = 0;
        private int[] selectedEightGames;
        public int gameNumberFirst;
        public int gameNumberLast;

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
            Console.WriteLine(Repository.MultipleGameRequirements);
            Console.WriteLine(Repository.MultipleGameSave);
            Console.WriteLine(Repository.SelectEightGames);

            // To call the parallelgames method many times in a column (based on the "times" variable)
            int times = 1000;

            for (int i = 0; i < times; i++)
            {
                games.Add(new GameLogic(FieldGeneration.GenerateRandomMultipleGames(15, 15)));
            }
        }

        public void SelectEightGamesFromThousand()
        {
            //int [] selectedEighGames = games.Last()
            //                   .Where(x => games.Contains(x.gameNr));

            //Console.WriteLine(Repository.SelectEightGamesFirstNumber);
            ////int target = Convert.ToInt32(Console.ReadLine());
            //for (var gameNr = 0; gameNr < games.Count; gameNr++)
            //{
            //    string target = ($"Game Nr :") + gameNr;
            //    if (games[gameNr].Equals(target))
            //    {
            //        Console.WriteLine(games[gameNr]);
            //    }
            //}
            //Console.ReadLine();
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
                for (var gameNr = 0; gameNr < games.Count; gameNr++)
                {
                    Console.Title = games[gameNr].AliveCells().ToString("   Alive cells number: {0}");
                    games[gameNr].NewCellGeneration();
                    Console.WriteLine("Game Nr :" + gameNr);
                    games[gameNr].DrawField();
                    Thread.Sleep(1000);
                    if (exit = PauseMenu())
                    {
                        break;
                    }
                     
                        //Console.WriteLine(Repository.SelectEightGamesFirstNumber);
                        //int target = Convert.ToInt32(Console.ReadLine());
                        //for (var selectedGameNr = 0; selectedGameNr < games.Count; selectedGameNr++)
                        //{
                        //    if (games[selectedGameNr].Equals(target))
                        //    {
                        //        Console.WriteLine(games[selectedGameNr]);
                        //    }
                        //}
                        //Console.ReadLine();
                        //bool isExist = games[gameNr].Find(target);
                        //if (isExist)
                        //{
                        //    Console.WriteLine("Element found in the list");
                        //Console.WriteLine(target);
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Element not found in the given list");
                        //}

                        // Contains - Check if an item is in the list    

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
                    //Console.WriteLine(Repository.SelectEightGamesFirstNumber);
                    //string select = Console.ReadLine();
                    //if (select == "G")
                    //{
                    //    SelectEightGamesFromThousand();
                    //}
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

