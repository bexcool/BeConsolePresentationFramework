using BeConsolePresentationFramework.Controls.Base;
using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeConsolePresentationFramework.Utilities.Utilities;

namespace BeConsolePresentationFramework.Controls
{
    public class Button : Control
    {
        public Button(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        public Button(int X, int Y, int Width, int Height, string Content)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
        }

        public Button(int X, int Y, int Width, int Height, string Content, Thickness Padding)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
        }

        public Button(int X, int Y, int Width, int Height, string Content, Line Line)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Line = Line;
        }

        public Button(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.Line = Line;
        }
    }
}
