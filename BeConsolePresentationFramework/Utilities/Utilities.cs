using BeConsolePresentationFramework.Controls.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BeConsolePresentationFramework.Utilities
{
    public static class Utilities
    {
        public enum Visibility { Visible, Hidden, Collapsed };
        public enum Line { Single, Double, SingleRound, DoubleSingle, SingleDouble};
        public enum HorizontalAlignment { Left, Right, Center, Stretch };
        public enum VerticalAlignment { Top, Bottom, Center, Stretch };
        public enum Orientation { Horizontal, Vertical };

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

    public static class Clipboard
    {
        public static void SetText(string text)
        {
            var powershell = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-command \"Set-Clipboard -Value \\\"{text}\\\"\""
                }
            };
            powershell.Start();
            powershell.WaitForExit();
        }

        public static string GetText()
        {
            var powershell = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    RedirectStandardOutput = true,
                    FileName = "powershell",
                    Arguments = "-command \"Get-Clipboard\""
                }
            };

            powershell.Start();
            string text = powershell.StandardOutput.ReadToEnd();
            powershell.StandardOutput.Close();
            powershell.WaitForExit();
            return text.TrimEnd();
        }
    }
}
