using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeConsolePresentationFramework.Utilities
{
    public class Thickness
    {
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public Thickness(int Top, int Right, int Bottom, int Left)
        {
            this.Top = Top;
            this.Right = Right;
            this.Bottom = Bottom;
            this.Left = Left;
        }
    }
}
