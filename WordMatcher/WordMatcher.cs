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
                char[] CharScramble = scramble.ToCharArray();
                //separating each words from the scramble array into characters 
                //not done

                foreach (string word in wordList)
                {
                    char[] CharWord = word.ToCharArray();

                    //separating each words from the wordList array into characters 
                    //not done

                }
            }

            // Implement code here.
            // Work with "scrambledWords" and "matchedWords".

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                // Build a matched-word object here, so that you can return it.

                //return matchedWord;
                return new MatchedWord();  // Delete this line when done.
            }

            return matchedWords;
        } 
    }

}
