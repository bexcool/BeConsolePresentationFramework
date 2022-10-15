using BCPF.Core.Controls.Base;
using BCPF.Core.Rendering;
using BCPF.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BCPF.Core.Utilities.SyntaxHighlight;

namespace BCPF.Core.Controls
{
    public class TextBlock : Control
    {
        private ProgrammingLanguage _Language = ProgrammingLanguage.None;
        public ProgrammingLanguage Language
        {
            get { return _Language; }
            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Language = value;
            }
        }

        public TextBlock()
        {

        }
        public TextBlock(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public TextBlock(int X, int Y, string Content)
        {
            this.X = X;
            this.Y = Y;
            this.Content = Content;
            Width = Content.GetLongestLineLength();
            Height = Content.GetNumberOfLines();
        }
        public TextBlock(int X, int Y, string Content, ConsoleColor ForegroundColor)
        {
            this.X = X;
            this.Y = Y;
            this.Content = Content;
            this.ForegroundColor = ForegroundColor;
            Width = Content.GetLongestLineLength();
            Height = Content.GetNumberOfLines();
        }
        public TextBlock(int X, int Y, string Content, ProgrammingLanguage Language)
        {
            this.X = X;
            this.Y = Y;
            this.Content = Content;
            this.Language = Language;
            Width = Content.GetLongestLineLength();
            Height = Content.GetNumberOfLines();
        }
    }
}
