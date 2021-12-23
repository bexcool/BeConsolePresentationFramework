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

    public static class SyntaxHighlight
    {
        public enum ProgrammingLanguage { CS, None }

        public const string
            KEYWORDS_CS = "abstract,event,new,struct,as,explicit,null,switch,base,extern,this,false,operator,throw,break,finally,out,true,fixed,override,try,case,params,typeof,catch,for,private,foreach,protected,checked,goto,public,unchecked,if,readonly,unsafe,implicit,ref,continue,in,return,using,virtual,default,interface,sealed,volatile,delegate,internal,do,is,sizeof,while,double,lock,stackalloc,else,static,namespace",
            DATATYPES = "bool,object,byte,float,class,uint,char,ulong,ushort,const,decimal,int,sbyte,short,void,long,enum,string";

        public static Dictionary<string, ConsoleColor> GetHighlight(ProgrammingLanguage Language)
        {
            Dictionary<string, ConsoleColor> SyntaxKeywords = new Dictionary<string, ConsoleColor>();

            switch (Language)
            {
                case ProgrammingLanguage.CS:
                    {
                        foreach (string Word in KEYWORDS_CS.Split(',')) SyntaxKeywords.Add(Word, ConsoleColor.Green);
                        foreach (string Type in DATATYPES.Split(',')) SyntaxKeywords.Add(Type, ConsoleColor.Blue);
                        break;
                    }
            }

            return SyntaxKeywords;
        }
    }
}
