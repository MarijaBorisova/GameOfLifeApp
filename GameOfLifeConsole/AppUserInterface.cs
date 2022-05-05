namespace GameOfLifeConsole
{
    public static class AppUserInterface
    {
        public static void Start()
        {
            Console.WriteLine(Repository.Title);
            Console.WriteLine(Repository.ManualOrRandomSelection);
            Console.Write(Repository.Selection);
        }

        /// <summary>
        /// UI visual part method for asking to input the quantity of rows and columns.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <returns> The visual part the message-request.</returns>
        public static int RequestNumberFromUser(string promptMessage)
        {
            while (true)
            {
                Console.WriteLine(promptMessage);
                string value = Console.ReadLine();
                if (int.TryParse(value, out int userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine(Repository.IncorrectDataInputMessage);
                    Console.WriteLine(Repository.PressAnyKeyMessage);
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// UI method to input the request message and the number in appropriate limitations.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns> The number in appropriate limitations. </returns>
        public static int GetValidatedNumber(string promptMessage, int minValue, int maxValue)
        {
            while (true)
            {
                int number = RequestNumberFromUser(promptMessage);
                if (number < minValue || number > maxValue)
                {
                    Console.WriteLine(Repository.NumberIsOutOfRange);
                    Console.WriteLine(Repository.PressAnyKeyMessage);
                    Console.ReadKey();
                }
                else
                {
                    return number;
                }
            }
        }

        /// <summary>
        /// The method if the user input data incorrectly.
        /// </summary>
        public static void IncorrectDataInput()
        {
            Console.WriteLine(Repository.IncorrectDataInputMessage);
        }
    }
}