using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeConsolePresentationFramework.Utilities
{
    public static class Utilities
    {
        public enum Visibility { Visible, Hidden, Collapsed };
        public enum Line { Single, Double, SingleRound, DoubleSingle, SingleDouble};

        /// <summary>
        /// Gets longest line from string.
        /// </summary>
        /// <param name="text">Input string.</param>
        /// <returns>Longest line length.</returns>
        public static int GetLongestLineLength(this string text)
        {
            string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int longest = 0;
            foreach (string line in lines)
            {
                if (line.Length > longest)
                    longest = line.Length;
            }

            return longest;
        }

        /// <summary>
        /// Gets number of lines from string.
        /// </summary>
        /// <param name="text">Input string.</param>
        /// <returns>Number of lines.</returns>
        public static int GetNumberOfLines(this string text)
        {
            return text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
