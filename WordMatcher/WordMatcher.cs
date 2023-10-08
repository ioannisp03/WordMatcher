using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        String word;
        String scramble;
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scramble in scrambledWords)
            {
                char[] charScramble = scramble.ToCharArray();

                foreach (string word in wordList)
                {
                    char[] charWord = word.ToCharArray();

                    if (charScramble.Length == charWord.Length)
                    {
                        Array.Sort(charScramble);
                        Array.Sort(charWord);
                        
                        bool wordsMatch = true;

                        for (int i = 0; i < charScramble.Length; i++)
                        {
                            if (charScramble[i] != charWord[i])
                            {
                                wordsMatch = false;
                                break;
                            }
                        }

                        if (wordsMatch)
                        {
                            BuildMatchedWord(scramble, word);
                            
                        }
                    }
                }
            }

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                // Build a matched-word object here, so that you can return it.
                MatchedWord matchedWord = new MatchedWord();
                matchedWord.ScrambledWord = scrambledWord;
                matchedWord.Word = word; ;
                matchedWords.Add(matchedWord); 

                return matchedWord;
               
            }

            return matchedWords;
        }
    }

}
