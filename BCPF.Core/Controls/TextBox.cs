using BCPF.Core.Controls.Base;
using BCPF.Core.Rendering;
using BCPF.Core.Rendering.Style;
using BCPF.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BCPF.Core.Utilities.Utilities;

namespace BCPF.Core.Controls
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
        public TextBox(int X, int Y, int Width, int Height, string Content, BorderStyle borderStyle)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.BorderStyle = borderStyle;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, BorderStyle borderStyle, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.BorderStyle = borderStyle;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, BorderStyle borderStyle, HorizontalAlignment ContentHorizontalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.BorderStyle = borderStyle;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, BorderStyle borderStyle, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.BorderStyle = borderStyle;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, BorderStyle borderStyle)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.BorderStyle = borderStyle;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, BorderStyle borderStyle, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.BorderStyle = borderStyle;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, BorderStyle borderStyle, HorizontalAlignment ContentHorizontalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.BorderStyle = borderStyle;
            this.ContentHorizontalAlignment= ContentHorizontalAlignment;
        }
        public TextBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, BorderStyle borderStyle, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Content = Content;
            this.Padding = Padding;
            this.BorderStyle = borderStyle;
            this.ContentHorizontalAlignment = ContentHorizontalAlignment;
            this.ContentVerticalAlignment = ContentVerticalAlignment;
        }
    }
}
