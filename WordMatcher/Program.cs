using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace WordUnscrambler
{
    //Ioannis P is here
    //zachary was here
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
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
            while (true)
            {
               
                Console.WriteLine("Enter values, separated by comas:");
                string userInput = Console.ReadLine();

                // Split the user input into strings
                string[] inputStrings = userInput.Split(',');

                Console.WriteLine("Would you like to continue? Y/N");
                string continueOption = Console.ReadLine().ToUpper();//read the input and converts it Uppercase value 
                if (continueOption == "N") {
                    break;
                }
                else if (continueOption !="Y")
                {
                    Console.WriteLine("Invalid values please try again");
                }
                
            }

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //read the list of words from the system file. 
            string[] wordList = _fileReader.Read("wordlist.txt");

            //call a word matcher method to get a list of structs of matched words.
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
        }
    }
}
