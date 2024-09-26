using System;
using System.Collections.Generic;

namespace FirstTask
{
    public static class Strings
    {
        /// <summary>
        /// For example:
        /// "ggkljg" => 4
        /// </summary>
        /// <param name="str" ></param>
        /// <returns> maximum count of unique sequential characters. </returns>
        /// <exception cref="ArgumentNullException"> if str is null</exception>
        public static int MaxCountOfUniqueSequentialCharacters(this string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            int max = 0;
            for (int i = 0; i < str.Length; i++)
            {
                HashSet<char> items = new HashSet<char> { str[i] };
                int j = i + 1;

                while (j < str.Length && !items.Contains(str[j]))
                {
                    items.Add(str[j]);
                    j++;
                }

                if (j - i > max)
                {
                    max = j - i;
                }
            }

            return max;
        }
    }
}
