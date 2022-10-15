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
    public class Border : Control
    {
        public Border()
        {

        }
        public Border(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
        public Border(int X, int Y, int Width, int Height, BorderStyle borderStyle)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.BorderStyle = borderStyle;
        }
    }
}
