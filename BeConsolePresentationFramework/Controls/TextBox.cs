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
    public class TextBox : Control
    {
        public TextBox(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
        }
        public TextBox(int X, int Y, int Width, int Height, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, HorizontalAlignment ContentHorizontalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, HorizontalAlignment ContentHorizontalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.ContentHorizontalAlignment= ContentHorizontalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, HorizontalAlignment ContentHorizontalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Line Line)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Line = Line;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Line Line, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Line = Line;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Line Line, HorizontalAlignment ContentHorizontalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Line = Line;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Line Line, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Line = Line;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.Line = Line;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.Line = Line;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line, HorizontalAlignment ContentHorizontalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.Line = Line;
            this.ContentHorizontalAlignment= ContentHorizontalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.Line = Line;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
    }
}
