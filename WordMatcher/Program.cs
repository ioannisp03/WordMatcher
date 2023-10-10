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
            Console.WriteLine("Select a language: 1 - English / 2 - French");
            int languageChoice = int.Parse(Console.ReadLine());

            if (languageChoice == 2)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-CA");// selecting the language used to run the program 
            }
    

            bool run = true;
            String filepath = @"C:\Users\Zachary PC\source\repos\WordMatcher\WordMatcher\bin\wordlist.txt";
            if (File.Exists(filepath))
            {
                Console.WriteLine(Properties.String.Status);
            }
            try
            {
                while (run)// A while loop that runs the code again when user wants to continue 
                {
                    if (languageChoice == 2)
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-CA");// selecting the language used to run the program 
                    }
                    bool valid= false;
                    while (!valid)// this loop here ask the question again if the input does not match with the two option F/M
                    {
                        Console.WriteLine(Properties.String.Question);

                        String option = Console.ReadLine() ?? throw new Exception("String is empty");

                        switch (option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine(Properties.String.F);
                                ExecuteScrambledWordsInFileScenario();
                                valid = true;
                                break;
                            case "M":
                                Console.WriteLine(Properties.String.M);
                                ExecuteScrambledWordsManualEntryScenario();
                                valid = true;
                                break;
                            default:

                                Console.WriteLine(Properties.String.Inputmatch);
                                break;
                        }
                    }
                       
 
                    Console.WriteLine(Properties.String.Continue);
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        Console.WriteLine(Properties.String.Keep);
                        run = true;
                    }else if(answer=="N")
                    {
                        Console.WriteLine(Properties.String.Stop);
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine(Properties.String.Continue2);
                    }
                    
                }

                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine(Properties.String.Terminated + ex.Message);

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
                    Console.WriteLine(Properties.String.Terminated);
            }
            else
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Properties.String.Scrambled+  matchedWord.ScrambledWord+ Properties.String.Word+ matchedWord.Word);
                }
 

            }
            
        }
    }
}
