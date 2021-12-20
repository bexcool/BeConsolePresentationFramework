﻿using BeConsolePresentationFramework.Controls.Base;
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
    public class StackPanel : Control
    {
        public List<Control> Children { get; set; }

        public StackPanel(int X, int Y, int Width, int Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        public StackPanel(int X, int Y, int Width, int Height, Line Line)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Line = Line;
        }
    }
}
