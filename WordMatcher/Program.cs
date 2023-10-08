using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.IO;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            String filepath = @"C:\Users\ipana\OneDrive\Desktop\CompSCi\Semester_3\.NET\LABS\lab-5\WordMatcher\WordMatcher\bin\wordlist.txt";
            if (File.Exists(filepath))
            {
                Console.WriteLine("Exists");
            }
            try
            {
                Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                String option = Console.ReadLine() ?? throw new Exception("String is empty");

                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter full path including the file name: ");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.WriteLine("Enter word(s) manually (separated by commas if multiple): ");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized.");
                        break;
                }

                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine("The program will be terminated." + ex.Message);

            }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var filename = Console.ReadLine();
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            string userInput = Console.ReadLine().ToLower();

            // Split the user input into strings
            string[] inputStrings = userInput.Split(',');


            //send the array
            DisplayMatchedUnscrambledWords(inputStrings);


        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //read the list of words from the system file. 
            string[] wordList = _fileReader.Read(@"C:\Users\ipana\OneDrive\Desktop\CompSCi\Semester_3\.NET\LABS\lab-5\WordMatcher\WordMatcher\bin\wordlist.txt");

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Count == 0)
            {
                Console.WriteLine("No matching words found");

            }
            else
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine($"Scrambled: {matchedWord.ScrambledWord}, Word: {matchedWord.Word}");

                }
            }
        }
    }
}
