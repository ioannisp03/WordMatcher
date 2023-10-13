using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    internal static class ExtensionMethod
    {
        public static bool AreEqual(this char[] word, char[] scramble)
        {
            if (word.Length != scramble.Length)
            {
                return false;
            }

            Array.Sort(word);
            Array.Sort(scramble);

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != scramble[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
