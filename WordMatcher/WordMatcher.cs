using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
       
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scramble in scrambledWords)
            {
                char[] charScramble = scramble.ToCharArray();

                foreach (string word in wordList)
                {
                    char[] charWord = word.ToCharArray();

                    if (charWord.AreEqual(charScramble))
                    {
                        BuildMatchedWord(scramble, word);
                    }
                }
            }

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                //matched-word object
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
