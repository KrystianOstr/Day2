using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            1 Text file word counter:
            //Create a console application that reads all text files from a given folder and counts the total number of words in them.
            //The application should display the total count for each file and the grand total count for all files.
            //a.Create a new Console Application project in C#.
            //b.Add a method to get a list of all text files in a given directory using the Directory.GetFiles() method with a "*.txt" search pattern.
            //c.Create a method to read the contents of a text file using File.ReadAllText().
            //d.Add a method to count the number of words in a text file by splitting the file's content using the string.Split() method with space as a delimiter.
            //e.Loop through all text files, count the words in each file, and display the results.
            //f.Calculate and display the total number of words in all text files.

            string path = @"C:\data\textfiles";

            string[] textFiles = Directory.GetFiles(path, "*.txt");

            int numberOfWordsInTotal = 0;
            int wordsInFile;

            foreach (string file in textFiles)
            {
                string fileContent = File.ReadAllText(file);

                string[] words = fileContent.Split(' ');

                wordsInFile = words.Length;

                numberOfWordsInTotal += wordsInFile;

                Console.WriteLine("{0} contains {1} words", Path.GetFileName(file), wordsInFile);

            }

            Console.WriteLine("All text files contains {0}", numberOfWordsInTotal);

            Console.ReadKey();

        }
    }
}
