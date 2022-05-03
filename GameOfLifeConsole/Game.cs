using GameOfLifeConsole.Services;

namespace GameOfLifeConsole
{
    public class Game
    {
        public GameLogic gameLogic;
        private FileReadSave _fileReadSave = new FileReadSave();
        private uint MaxRuns = 20;
        private int runs = 0;
        private int[,] seed = null;
        public Game()
        {
            gameLogic = new GameLogic();
        }
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
                    default:
                        {
                            AppUserInterface.IncorrectDataInput();
                            Console.ReadLine();
                        }
                        break;
                }
                //while (gameLogic.AliveCells() > 0 && runs++ < MaxRuns)
                while (gameLogic.AliveCells() > 0 && runs++ < MaxRuns)
                {
                    string exit;
                    string save;
                    Console.Clear();
                    Console.Title = gameLogic.countIteration.ToString("Iteration {0}");
                    Console.SetCursorPosition(0, 0);
                    gameLogic.NewCellGeneration();
                    gameLogic.DrawField();
                    Console.WriteLine();

                    if (gameLogic.AliveCells() == 0)
                    {
                        Console.WriteLine(Repository.cellsDied);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(Repository.saveData);
                        save = Console.ReadLine();
                        if (save == "s")
                        {
                            _fileReadSave.SaveData(gameLogic);
                            gameLogic = _fileReadSave.LoadData();
                        }
                        Console.WriteLine(Repository.stopOrContinue);
                        exit = Console.ReadLine();
                        if (exit == "e")
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void StartGameManually()
        {
            gameLogic = new GameLogic(FieldGeneration.GetGlider());
            gameLogic.AliveCells().ToString();
        }

        private void StartGameRandom()
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
            gameLogic.AliveCells().ToString();
        }
    }
}