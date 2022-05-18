using Newtonsoft.Json;

namespace GameOfLifeConsole.Services
{
    /// <summary>
    /// To read and save the data on hard disc.
    /// </summary>
    class FileReadSaveMultipleGames
    {
        //// The path to which the data will be saved and restored. The variable.
        private string _pathMultipleGames = $"{Environment.CurrentDirectory}\\MyFile.json";

        /// <summary>
        /// To read the data.
        /// </summary>
        /// <returns> To create the object of GameLogic and return it.</returns>
        public List<GameLogic> LoadData()
        {
            // To load data from the file, need to check if the file exists.
            bool doesFileExists = File.Exists(_pathMultipleGames);
            if (!doesFileExists)
            {
                using (var fileStream = new FileStream("MyFile.json", FileMode.CreateNew))
                {
                    // If the file/path does not exist, to create a file
                    // and free the resourses with Dispose method.
                    File.Create(_pathMultipleGames).Dispose();

                    return new List<GameLogic>();
                }
            }

            // If file exists, the logic of loading/reading below.
            using (var reader = File.OpenText(_pathMultipleGames))
            {
                string fileText = reader.ReadToEnd();

                List<GameLogic> games = JsonConvert.DeserializeObject<List<GameLogic>>(fileText);
                if (games == null)
                {
                    return new List<GameLogic>();
                }
                return games;
            }
        }

        /// <summary>
        /// Save data on hard disc.
        /// </summary>
        /// <param name="games"> To save data of the object.</param>
        public void SaveData(List<GameLogic> games)
        {
            // Using object StreamWriter which create taking the method CreateText at File class.
            using (StreamWriter writer = File.CreateText(_pathMultipleGames))
            {
                string output = JsonConvert.SerializeObject(games);
                writer.Write(output);
            }
        }
    }
}
