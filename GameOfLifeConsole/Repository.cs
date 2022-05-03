using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole
{
    /// <summary>
    /// Class for literal text.
    /// </summary>
    public static class Repository
    {
        public const string incorrectDataInputMessage = "Incorrect input data, please," +
            " try again.";
        public const string pressAnyKeyMessage = "Press any key to continue.";
        public const string numberIsOutOfRange = "Number is out of range. Please, input correct value.";
        public const string stopOrContinue = "\nTo continue iteration, press the key 'Enter'.\n" +
                            " \nTo quit iteration, press 'e' key.";
        public const string cellsDied = "Everyone is died!";
        public const string saveData = "\nTo sava data in the file, press 's' key.\n";
    }
}
