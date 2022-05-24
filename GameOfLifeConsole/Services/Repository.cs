namespace GameOfLifeConsole
{
    /// <summary>
    /// Class for literal text.
    /// </summary>
    public static class Repository
    {
        public const string IncorrectDataInputMessage = "Incorrect input data, please," +
            " try again.";
        public const string PressAnyKeyMessage = "Press any key to continue.";
        public const string NumberIsOutOfRange = "Number is out of range. Please, input correct value.";
        public const string StopOrContinue = "\nTo continue iteration, press the key 'Enter'.\n" +
                            " \nTo quit iteration, press 'E' key.";
        public const string CellsDied = "Everyone is died!";
        public const string SaveData = "\nTo sava data in the file, press 'S' key.\n";
        public const string Title = "App Title: Game Of Life";
        public const string ManualOrRandomSelection = "Please, select if you would like to see the Blinker life circle (M) or " +
                "LifeCircle with Random numbers (R). \t";
        public const string SelectEightGamesInRandomlyExecuted1000Games = "To show selected 8 games in 1000 games in parallel, please, select (P).\t";
        public const string Selection = "Select : M or R: or P:\t ";
        public const string MultipleGameSave = "To save all 1000 games, press 'S':\t \n";
        public const string SelectEightGames = "Select 8 games from 1000 executed games in parallel list";
        public const string SelectEightGamesNumber = "Please, write what game's number you would like to select in 1000:\t\n";
        public const string WrongGameNumberInput = "You input game number is out of range.";
    }
}
