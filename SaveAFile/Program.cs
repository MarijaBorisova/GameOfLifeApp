using System.IO;
using System.Text;

namespace ReadWriteFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object for reading stream.
            StreamReader streamreading; 
            //Object for saving stream.
            StreamWriter streamsaving;
            // Max number of records.
            int maxRec = 1000; 
            try
            {
                // Reading from the text file.
                // Connection with the file and coding of symbols with Unicode.
                streamreading = new StreamReader("info.txt", UTF8Encoding.Default);
                string[] readingList = new string[maxRec];
                // Reading of the first (0 index) line.
                string firstLine = streamreading.ReadLine(); 
                // Counter of Lines.
                int i = 0; 
                // Reading from the file but not more than maxRec.
                while ((firstLine != null) && (i < readingList.Length)) 
                {
                    // To check if the firstLine is to be saved.
                    Console.WriteLine(firstLine);  
                    readingList[i++] = firstLine; 
                    // Reading of the last lines.
                    firstLine = streamreading.ReadLine(); 
                }
                // Close info.txt for reading.
                streamreading.Close(); 

                readingList[i] = "Saving the info in a file finished successfully!"; 

                // Save the new info in file. 
                // To create the object with information about the file.
                FileInfo fileInformation = new FileInfo("result.txt"); 
                if (fileInformation.Exists)
                    // To open the stream for adding the info.
                    streamsaving = fileInformation.AppendText(); 
                else
                    // To open the stream for saving the info.
                    streamsaving = fileInformation.CreateText();  
                for (int j = 0; j <= i; j++)
                    // To save lines in the file.
                    streamsaving.WriteLine(readingList[j].ToString()); 
                streamsaving.Close();
            }
            // If there is not file for reading- exception
            catch (Exception ex) 
            {
                Console.WriteLine("There is no file for reading!\n" + ex);
            }
            Console.ReadKey();
        }
    }
}