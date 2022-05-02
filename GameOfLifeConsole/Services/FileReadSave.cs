using Newtonsoft.Json;

namespace GameOfLifeConsole.Services
{
    /// <summary>
    /// To read and save the data on hard disc.
    /// </summary>
    class FileReadSave
    {
        // The path to which the data will be saved and restored. The variable.
        private string Path = $"{Environment.CurrentDirectory}\\MyFile.json";
        private int[,] gameField;

        /// <summary>
        /// To read the data.
        /// </summary>
        /// <returns> To create the object of GameLogic and return it.</returns>
        public GameLogic LoadData()
        {
            // To load data from the file, need to check if the file exists.
            bool doesFileExists = File.Exists(Path);
            if (!doesFileExists)
            {
                using (var fileStream = new FileStream("MyFile.json", FileMode.CreateNew))
                {
                    // If the file/path does not exist, to create a file
                    // and free the resourses with Dispose method.
                    File.Create(Path).Dispose(); 

                    return new GameLogic(gameField); 
                }
            }

            // If file exists, the logic of loading/reading below.
            using (var reader = File.OpenText(Path))
            {
                string fileText = reader.ReadToEnd();
                GameLogic gameLogic = JsonConvert.DeserializeObject<GameLogic>(fileText);
                if (gameLogic == null)
                {
                    return new GameLogic(gameField);
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
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(gameLogic);
                writer.Write(output);
            }
        }
    }
}
