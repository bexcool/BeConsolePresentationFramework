using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _ValueChanged();
                _X = value;
            }
        }

        private int _Y;
        public int Y
        {
            get { return _Y; }

            set
            {
                _ValueChanged();
                _Y = value;
            }
        }

        private int _Width = 1;
        public int Width
        {
            get { return _Width; }

            set
            {
                _ValueChanged();
                _Width = value;
            }
        }

        private int _Height = 1;
        public int Height
        {
            get { return _Height; }

            set
            {
                _ValueChanged();
                _Height = value;
            }
        }

        private Thickness _Padding;
        public Thickness Padding
        {
            get { return _Padding; }

            set
            {
                _ValueChanged();
                _Padding = value;
            }
        }

        public bool ValueChanged = false;

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

        #region Event handlers
        public delegate void ClickHandler(object sender, EventArgs e);
        public event ClickHandler OnClick;
        #endregion

        public Control()
        {
            ConsolePresentation.AddControl(this);
        }

        private void _ValueChanged()
        {
            ValueChanged = true;
        }

        public void Click()
        {
            if (OnClick == null) return;

            OnClick(this, EventArgs.Empty);
        }
    }
}
