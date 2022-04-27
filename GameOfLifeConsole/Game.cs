using GameOfLifeConsole.Services;

namespace GameOfLifeConsole
{
    public class Game
    {
        private GameLogic gameLogic;
        FileReadSave _fileReadSave = new FileReadSave();
        uint MaxRuns = 20;
        int runs = 0;
        int[,] seed = null;
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
                string key;
                key=Console.ReadLine();
                //ConsoleKey consoleKey = Console.ReadKey().Key;
                switch (key)
                {
                    case "M":
                    //case ConsoleKey.M:
                        seed = new int[,]
                       {
                    {0,0,0,0,0},
                    {0,0,0,0,0},
                    {0,1,1,1,0},
                    {0,0,0,0,0},
                    {0,0,0,0,0}

                       };
                        // In order to create the object, ctor of this class, path should be.
                        GameLogic gameLogic = new GameLogic(seed);

                        gameLogic.AliveCells().ToString();

                        while (gameLogic.AliveCells() > 0 && runs++ < MaxRuns)
                        {
                            Console.Clear();
                            Console.WriteLine("Iteration {0}", gameLogic.CountIteration);
                            gameLogic.NewCellGeneration();
                            gameLogic.DrawField();
                            Console.WriteLine();

                            if (gameLogic.AliveCells() == 0)
                            {
                                Console.WriteLine("Everyone is died!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.ReadLine();
                            }
                        }
                        _fileReadSave.SaveData(gameLogic);
                        gameLogic = _fileReadSave.LoadData();
                        break;

                    case "R":
                        GameValidation();
                        break;

                    default:

                        AppUserInterface.IncorrectDataInput();
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void GameValidation()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            while (true)
            {
                Console.Clear();
                try
                {
                    gameLogic.GetGameData();
                }
                catch (Exception)
                {
                    AppUserInterface.IncorrectDataInput();
                    Console.ReadLine();
                    continue;
                }
                gameLogic.AliveCells().ToString();

                while (gameLogic.AliveCells() > 0 && runs++ < MaxRuns)
                {
                    Console.Clear();
                    Console.Title = gameLogic.CountIteration.ToString("Iteration {0}");
                    Console.SetCursorPosition(0, 0);
                    gameLogic.NewCellGeneration();
                    gameLogic.DrawField();
                    Console.WriteLine();


                    string stop;
                    if (gameLogic.AliveCells() == 0)
                    {
                        Console.WriteLine("Everyone is died!");
                        Console.ReadLine();
                    }
                    else
                    { 
                        //AppUserInterface.StopIteration();
                        Console.WriteLine("\nTo continue iteration, press the key 'Enter'." +
                            " \nTo stop iteration, press 's' key.");
                        stop = Console.ReadLine();
                        if (stop == "s")
                        {
                            break;
                        }
                    }    
                }
                _fileReadSave.SaveData(gameLogic);
                gameLogic = _fileReadSave.LoadData();
            }
        }

    }
}