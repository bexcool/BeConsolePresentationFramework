﻿using BCPF.Core.Controls.Base;
using BCPF.Core.Rendering;
using BCPF.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BCPF.Core.Utilities.Utilities;

namespace BCPF.Core.Controls
{
    public class StackPanel : Control
    {
        public bool RemoveChildrenOnClear = true;

        public List<Control> Children = new List<Control> { };
        internal int LastChildrenCount;

        private Orientation _Orientation = Orientation.Vertical;
        public Orientation Orientation
        {
            get { return _Orientation; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Orientation = value;
            }
        }

        private int _Spacing = 0;
        public int Spacing
        {
            get { return _Spacing; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Spacing = value;
            }
        }

        // Refresh children
        private int LastChildAbsoluteSize;
        internal void RenderChildren()
        {
            LastChildAbsoluteSize = 0;

            if (Children.Count > 0)
            {
                if (Orientation == Orientation.Vertical)
                {
                    for (int i = 0; i < Children.Count; i++)
                    {
                        if (Children[i].Visibility != Visibility)
                        {
                            ConsoleGraphics.DrawBlank(new Rectangle(Children[i].X, Children[i].Y, Children[i].CalculateActualWidth(), Children[i].CalculateActualHeight()));
                        }

                        Children[i].X = X + Padding.Left;
                        Children[i].Y = Y + Padding.Top + LastChildAbsoluteSize;
                        Children[i].Visibility = Visibility;
                        Children[i].Parent = this;

                        // Height
                        if (Children[i].Visibility != Visibility.Collapsed) LastChildAbsoluteSize += Children[i].Height + Children[i].Padding.TopBottom + Children[i].Margin.TopBottom + Spacing;
                    }
                }
                else
                {
                    for (int i = 0; i < Children.Count; i++)
                    {
                        if (Children[i].Visibility != Visibility)
                        {
                            ConsoleGraphics.DrawBlank(new Rectangle(Children[i].X, Children[i].Y, Children[i].CalculateActualWidth(), Children[i].CalculateActualHeight()));
                        }

                        Children[i].X = X + Padding.Left + LastChildAbsoluteSize;
                        Children[i].Y = Y + Padding.Top;
                        Children[i].Visibility = Visibility;
                        Children[i].Parent = this;

                        // Width
                        if (Children[i].Visibility != Visibility.Collapsed) LastChildAbsoluteSize += Children[i].Width + Children[i].Padding.LeftRight + Children[i].Margin.LeftRight + Spacing;
                    }
                }
            }
        }

        public StackPanel()
        {

        }

        public StackPanel(int X, int Y, int Width, int Height)
        {
            LastChildrenCount = 0;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
    }
}
