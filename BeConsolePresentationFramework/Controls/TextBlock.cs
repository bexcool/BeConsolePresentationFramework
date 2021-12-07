using BeConsolePresentationFramework.Controls.Base;
using BeConsolePresentationFramework.Rendering;
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
        public TextBlock(int X, int Y, Size Size)
        {
            this.X = X;
            this.Y = Y;
        }

        public TextBlock(int X, int Y, string Content)
        {
            this.X = X;
            this.Y = Y;
            //Renderer.DrawText(X, Y, Content);
        }
    }
}
