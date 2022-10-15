using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BCPF.Core.Utilities.Utilities;

namespace BCPF.Core.Rendering.Style
{
    public class BorderStyle
    {
        public char TopLeftCorner { get; set; }
        public char BottomLeftCorner { get; set; }
        public char TopRightCorner { get; set; }
        public char BottomRightCorner { get; set; }
        public char Horizontal { get; set; }
        public char Vertical { get; set; }

        public BorderStyle(Line style = Line.Single)
        {
            switch (style)
            {
                case Line.Single:
                    {
                        TopLeftCorner = '┌';
                        BottomLeftCorner = '└';
                        TopRightCorner = '┐';
                        BottomRightCorner = '┘';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.Double:
                    {
                        TopLeftCorner = '╔';
                        BottomLeftCorner = '╚';
                        TopRightCorner = '╗';
                        BottomRightCorner = '╝';
                        Vertical = '║';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleRound:
                    {
                        TopLeftCorner = '╭';
                        BottomLeftCorner = '╰';
                        TopRightCorner = '╮';
                        BottomRightCorner = '╯';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.DoubleSingle:
                    {
                        TopLeftCorner = '╒';
                        BottomLeftCorner = '╘';
                        TopRightCorner = '╕';
                        BottomRightCorner = '╛';
                        Vertical = '│';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleDouble:
                    {
                        TopLeftCorner = '╓';
                        BottomLeftCorner = '╙';
                        TopRightCorner = '╖';
                        BottomRightCorner = '╜';
                        Vertical = '║';
                        Horizontal = '─';

                        break;
                    }
            }
        }
    }
}
