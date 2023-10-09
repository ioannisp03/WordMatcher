using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();


        static void Main(string[] args)
        {
            bool run= true;
            String filepath = @"C:\Users\Zachary PC\source\repos\WordMatcher\WordMatcher\bin\wordlist.txt";
            if (File.Exists(filepath))
            {
                Console.WriteLine("Exists");
            }
            try
            {
                while (run)// A while loop that runs the code again when user wants to continue 
                {
                    bool valid= false;
                    while (!valid)// this loop here ask the question again if the input does not match with the two option F/M
                    {
                        Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                        String option = Console.ReadLine() ?? throw new Exception("String is empty");

                        switch (option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine("Enter full path including the file name: ");
                                ExecuteScrambledWordsInFileScenario();
                                valid = true;
                                break;
                            case "M":
                                Console.WriteLine("Enter word(s) manually (separated by commas if multiple): ");
                                ExecuteScrambledWordsManualEntryScenario();
                                valid = true;
                                break;
                            default:

                                Console.WriteLine("The input does not match with the two option F/M");
                                break;
                        }
                    }
                       
                    



                    Console.WriteLine("Would you like to continue? Y/N");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        Console.WriteLine("The program will continue");
                        run = true;
                    }else if(answer=="N")
                    {
                        Console.WriteLine("The program stopped");
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine("Would you like to continue? Y/N ");
                    }
                    
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
            string[] wordList = _fileReader.Read(@"C:\Users\Zachary PC\source\repos\WordMatcher\WordMatcher\bin\wordlist.txt");

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
