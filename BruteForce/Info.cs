using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForce
{
    internal static class Info
    {
        public static int ThreadsCount = 0;
        private static char[] alphabet=null!;
        private static int initialThreadsCount = 0;

        public static int InitialThreadsCount
        {
            get { return initialThreadsCount; }
            set
            {
                if (initialThreadsCount != 0) return;
                else initialThreadsCount = value;
            }
        }
        public static char[] GetAlphabet()
        {
            char[] array;
            if (alphabet is null)
            {
                alphabet = new char[26];
                for(int i = 0; i < 26; i++)
                {
                    int lower = 97;
                    alphabet[i] = (char) (lower + i);
                }
                array = new char[alphabet.Length];
                Array.Copy(alphabet, array, alphabet.Length);
                return array;
            }
            else
            {
                array = new char[alphabet.Length];
                Array.Copy(alphabet, array, alphabet.Length);
                return array;
            }
        }


    }
}
