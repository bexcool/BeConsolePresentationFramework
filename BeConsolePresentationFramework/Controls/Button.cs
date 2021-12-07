using BeConsolePresentationFramework.Controls.Base;
using BeConsolePresentationFramework.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeConsolePresentationFramework.Controls
{
    public class Button : Control
    {
        public Button(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
        }

        public Button(int X, int Y, string Content)
        {
            this.X = X;
            this.Y = Y;
            this.Content = Content;
            Width = Content.Length + 3;
            Height = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length + (Padding != null ? Padding.Top + Padding.Bottom : 0) + 2;
        }
    }
}
