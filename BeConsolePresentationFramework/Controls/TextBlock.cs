using BeConsolePresentationFramework.Controls.Base;
using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeConsolePresentationFramework.Controls
{
    public class TextBlock : Control
    {
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
    }
}
