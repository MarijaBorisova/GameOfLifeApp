using Newtonsoft.Json;

namespace GameOfLifeConsole.Services
{
    /// <summary>
    /// To read and save the data on hard disc.
    /// </summary>
    class FileReadSave
    {
        // The path to which the data will be saved and restored. The variable.
        private string _path = $"{Environment.CurrentDirectory}\\MyFile.json";
        private int[,] _gameField;

        /// <summary>
        /// To read the data.
        /// </summary>
        /// <returns> To create the object of GameLogic and return it.</returns>
        public GameLogic LoadData()
        {
            // To load data from the file, need to check if the file exists.
            bool doesFileExists = File.Exists(_path);
            if (!doesFileExists)
            {
                using (var fileStream = new FileStream("MyFile.json", FileMode.CreateNew))
                {
                    // If the file/path does not exist, to create a file
                    // and free the resourses with Dispose method.
                    File.Create(_path).Dispose();

                    return new GameLogic(_gameField);
                }
            }

            // If file exists, the logic of loading/reading below.
            using (var reader = File.OpenText(_path))
            {
                string fileText = reader.ReadToEnd();
                GameLogic gameLogic = JsonConvert.DeserializeObject<GameLogic>(fileText);
                if (gameLogic == null)
                {
                    return new GameLogic(_gameField);
                }
                return gameLogic;
            }
        }

        /// <summary>
        /// Save data on hard disc.
        /// </summary>
        /// <param name="gameLogic"> To save data of the object.</param>
        public void SaveData(GameLogic gameLogic)
        {
            // Using object StreamWriter which create taking the method CreateText at File class.
            using (StreamWriter writer = File.CreateText(_path))
            {
                string output = JsonConvert.SerializeObject(gameLogic);
                writer.Write(output);
            }
        }
    }
}
