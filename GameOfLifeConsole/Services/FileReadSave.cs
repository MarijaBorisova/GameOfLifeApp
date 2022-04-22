using Newtonsoft.Json;

namespace GameOfLifeConsole.Services
{
    /// <summary>
    /// To read and save the data on HD.
    /// </summary>
    class FileReadSave
    {
        // The path to which the data will be saved and restored. The variable
        // The path for FileReadSave object, ctor.
        private string Path = $"{Environment.CurrentDirectory}\\MyFile.json";
        private int[,] gameField;

        /// <summary>
        /// To read the data.
        /// </summary>
        /// <returns> To create the object of GameSeed and return it.</returns>
        public GameSeed LoadData()
        {
            // To load data from the file, need to check if the file exists.
            var fileIs = File.Exists(Path);
            using (var fileStream = new FileStream("MyFile.json", FileMode.CreateNew))
            {
                if (!fileIs)
                {
                    File.Create(Path).Dispose(); // If the file/path does not exist, to create a file
                                                 // and free the resourses with Dispose method.

                    return new GameSeed(gameField);
                    //return null;
                }
            }

            // If file exists, the logic of loading/reading below.
            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<GameSeed>(fileText);
            }
        }

        /// <summary>
        /// Save data on HD.
        /// </summary>
        public void SaveData(GameSeed gameSeed)
        {
            // Using object StreamWriter which create taking the method CreateText at File class
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(gameSeed);
                writer.Write(output);
            }
        }

        public void SaveDataR(GameSeed gameSeedRandom)
        {
            // Using object StreamWriter which create taking the method CreateText at File class
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(gameSeedRandom);
                writer.Write(output);
            }
        }
    }
}
