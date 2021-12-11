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

        private Thickness _Padding = new Thickness(1, 1, 1, 1);
        public Thickness Padding
        {
            get { return _Padding; }

            set
            {
                if (!ChangingByCore) _ValueChanged();
                _Padding = value;
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
                if (!ChangingByCore) _ValueChanged();
                _Content = value;
            }
        }

        internal bool ValueChanged = false, ChangingByCore = false;
        public bool Hovered = false;
        public bool Pressed = false;

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
        #endregion

        public Control()
        {
            ConsolePresentation.AddControl(this);
        }

        private void _ValueChanged()
        {
            if (!ValueChanged)
            {
                ValueChanged = true;
            }
        }

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

        // Public functions
        public void Remove()
        {
            ConsolePresentation.RemoveControl(this);

            Renderer.DrawBlank(new Rectangle(X, Y, Width, Height));
        }
    }
}
