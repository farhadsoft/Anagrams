using System;
using System.Collections.Generic;
using System.Globalization;

namespace AnagramTask
{
    public class Anagram
    {
        private string sourceWord;

        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        public Anagram(string sourceWord)
        {
            if (sourceWord is null)
            {
                throw new ArgumentNullException($"Thrown when source word is null. {nameof(sourceWord)}");
            }

            if (string.IsNullOrEmpty(sourceWord))
            {
                throw new ArgumentException($"Thrown when source word is empty.");
            }

            this.sourceWord = sourceWord;
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates is null)
            {
                throw new ArgumentNullException($"Thrown when candidates list is null. {nameof(candidates)}");
            }

            List<string> result = new List<string>();
            foreach (var str in candidates)
            {
                if (this.SearchInWord(str))
                {
                    result.Add(str);
                }
            }

            return result.ToArray();
        }

        public bool SearchInWord(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.Length != this.sourceWord.Length)
            {
                return false;
            }

            if (str.ToLower(CultureInfo.CurrentCulture) == this.sourceWord.ToLower(CultureInfo.CurrentCulture))
            {
                return false;
            }

            var strChar = str.ToLower(CultureInfo.CurrentCulture).ToCharArray();
            var sourceChar = this.sourceWord.ToLower(CultureInfo.CurrentCulture).ToCharArray();

            Array.Sort(strChar);
            Array.Sort(sourceChar);

            str = new string(strChar);
            this.sourceWord = new string(sourceChar);

            return str == this.sourceWord;
        }
    }
}
