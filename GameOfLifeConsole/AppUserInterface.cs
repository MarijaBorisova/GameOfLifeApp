
namespace GameOfLifeConsole
{
    public static class AppUserInterface
    {
        public static void Start()
        {
            Console.WriteLine("App Title: Game Of Life");
            Console.WriteLine("Please, select if you would like to see the Blinker life circle (M) or " +
                "LifeCircle with Random numbers (R). \t");
            Console.Write("Select : M or R:\t ");   
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
                    Console.WriteLine(Repository.incorrectDataInputMessage);
                    Console.WriteLine(Repository.pressAnyKeyMessage);
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
        public static int GetValidatedNumber(string promptMessage,int minValue, int maxValue)
        {
            while (true)
            {
                int number = RequestNumberFromUser(promptMessage);
                if (number < minValue || number > maxValue)
                {
                    Console.WriteLine(Repository.numberIsOutOfRange);
                    Console.WriteLine(Repository.pressAnyKeyMessage);
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
            Console.WriteLine(Repository.incorrectDataInputMessage);
        }
    }
}