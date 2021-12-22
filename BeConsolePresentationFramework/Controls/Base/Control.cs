using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using BeConsolePresentationFramework.Controls.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeConsolePresentationFramework.Utilities.Utilities;

namespace BeConsolePresentationFramework.Controls.Base
{
    public class Control
    {
        private int _X;
        public int X
        {
            get { return _X; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _X = value;
            }
        }

        private int _Y;
        public int Y
        {
            get { return _Y; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Y = value;
            }
        }

        private int _Width = 1;
        public int Width
        {
            get { return _Width; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Width = value;
            }
        }

        private int _Height = 1;
        public int Height
        {
            get { return _Height; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Height = value;
            }
        }

        private Thickness _Padding = new Thickness();
        public Thickness Padding
        {
            get { return _Padding; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Padding = value;
            }
        }

        private Thickness _Margin = new Thickness();
        public Thickness Margin
        {
            get { return _Margin; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Margin = value;
            }
        }

        private Line _Line;
        public Line Line
        {
            get { return _Line; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Line = value;
            }
        }

        private HorizontalAlignment _ContentHorizontalAlignment = HorizontalAlignment.Center;
        public HorizontalAlignment ContentHorizontalAlignment
        {
            get { return _ContentHorizontalAlignment; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _ContentHorizontalAlignment = value;
            }
        }

        private VerticalAlignment _ContentVerticalAlignment = VerticalAlignment.Center;
        public VerticalAlignment ContentVerticalAlignment
        {
            get { return _ContentVerticalAlignment; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _ContentVerticalAlignment = value;
            }
        }

        private ConsoleColor _ForegroundColor = ConsoleColor.White;
        public ConsoleColor ForegroundColor
        {
            get { return _ForegroundColor; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _ForegroundColor = value;
            }
        }

        private Visibility _Visibility = Visibility.Visible;
        public Visibility Visibility
        {
            get { return _Visibility; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Visibility = value;
            }
        }

        private string _Content = "";
        public string Content
        {
            get { return _Content; }

            set
            {
                _ValueChanged();
                _Content = value;
            }
        }

        private Control _Parent;
        public Control Parent
        {
            get
            {
                return _Parent;
            }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Parent = value;
            }
        }

        internal bool ValueChanged = false, ChangingByCore = false, RemoveRequest = false, ParentChanged = false, BlankApplied = true;
        public bool Hovered = false, Pressed = false;

        internal Rectangle Old;

        #region Event handlers
        // Click handler
        public delegate void ClickHandler(object sender, EventArgs e);
        public event ClickHandler OnClick;
        // Mouse enter handler
        public delegate void MouseEnterHandler(object sender, EventArgs e);
        public event MouseEnterHandler MouseEnter;
        // Mouse enter leave
        public delegate void MouseLeaveHandler(object sender, EventArgs e);
        public event MouseLeaveHandler MouseLeave;
        // Mouse pressed handler
        public delegate void MousePressedHandler(object sender, EventArgs e);
        public event MousePressedHandler MousePressed;
        // Mouse released leave
        public delegate void MouseReleasedHandler(object sender, EventArgs e);
        public event MouseReleasedHandler MouseReleased;
        // Focused
        public delegate void FocusedHandler(object sender, EventArgs e);
        public event FocusedHandler Focused;
        // Content changed
        public delegate void ContentChangedHandler(object sender, EventArgs e);
        public event ContentChangedHandler ContentChanged;
        #endregion

        public Control()
        {
            Old = new Rectangle(X, Y, CalculateActualWidth(), CalculateActualHeight());

            ConsolePresentation.AddControl(this);
        }

        // Called when any value changes
        internal void _ValueChanged()
        {
            if (!ValueChanged)
            {
                Old = new Rectangle(X, Y, CalculateActualWidth(), CalculateActualHeight());

                ValueChanged = true;
                BlankApplied = false;
            }
        }

        // Events
        internal void _OnClick()
        {
            if (OnClick == null) return;

            OnClick(this, EventArgs.Empty);
        }
        internal void _MouseEnter()
        {
            if (MouseEnter == null) return;

            MouseEnter(this, EventArgs.Empty);
        }
        internal void _MouseLeave()
        {
            if (MouseLeave == null) return;

            MouseLeave(this, EventArgs.Empty);
        }
        internal void _MousePressed()
        {
            if (MousePressed == null) return;

            MousePressed(this, EventArgs.Empty);
        }
        internal void _MouseReleased()
        {

            if (MouseReleased == null) return;

            MouseReleased(this, EventArgs.Empty);
        }
        internal void _Focused()
        {
            if (Focused == null) return;

            Focused(this, EventArgs.Empty);
        }
        internal void _ContentChanged()
        {
            if (ContentChanged == null) return;

            ContentChanged(this, EventArgs.Empty);
        }

        // Public functions
        /// <summary>
        /// Remove control.
        /// </summary>
        public void Remove()
        {
            RemoveRequest = true;
        }

        /// <summary>
        /// Calculates controls actual width.
        /// </summary>
        /// <returns>Actual width.</returns>
        public int CalculateActualWidth()
        {
            return Width + Padding.LeftRight + Content.GetLongestLineLength();
        }

        /// <summary>
        /// Calculates controls actual height.
        /// </summary>
        /// <returns>Actual height.</returns>
        public int CalculateActualHeight()
        {
            return Height + Padding.TopBottom + Content.GetNumberOfLines();
        }
    }
}
