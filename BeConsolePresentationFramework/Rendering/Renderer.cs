using BeConsolePresentationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeConsolePresentationFramework.Utilities.Utilities;

namespace BeConsolePresentationFramework.Rendering
{
    public static class Renderer
    {
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        public static void DrawBox(int X, int Y, int Width, int Height)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            int _Width = Width - 2;
            int _Height = Height - 2;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);
        }
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Padding">Control padding.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, Thickness Padding)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            int _Width = Width - 2 + Padding.Left + Padding.Right;
            int _Height = Height - 2 + Padding.Top + Padding.Bottom;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);
        }
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Line">Control border style.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, Line Line)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            switch (Line)
            {
                case Line.Single:
                    {
                        TL_Corner = '┌';
                        BL_Corner = '└';
                        TR_Corner = '┐';
                        BR_Corner = '┘';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.Double:
                    {
                        TL_Corner = '╔';
                        BL_Corner = '╚';
                        TR_Corner = '╗';
                        BR_Corner = '╝';
                        Vertical = '║';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleRound:
                    {
                        TL_Corner = '╭';
                        BL_Corner = '╰';
                        TR_Corner = '╮';
                        BR_Corner = '╯';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.DoubleSingle:
                    {
                        TL_Corner = '╒';
                        BL_Corner = '╘';
                        TR_Corner = '╕';
                        BR_Corner = '╛';
                        Vertical = '│';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleDouble:
                    {
                        TL_Corner = '╓';
                        BL_Corner = '╙';
                        TR_Corner = '╖';
                        BR_Corner = '╜';
                        Vertical = '║';
                        Horizontal = '─';

                        break;
                    }
            }

            int _Width = Width - 2;
            int _Height = Height - 2;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);
        }
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Line">Control border style.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, Thickness Padding, Line Line)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            switch (Line)
            {
                case Line.Single:
                    {
                        TL_Corner = '┌';
                        BL_Corner = '└';
                        TR_Corner = '┐';
                        BR_Corner = '┘';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.Double:
                    {
                        TL_Corner = '╔';
                        BL_Corner = '╚';
                        TR_Corner = '╗';
                        BR_Corner = '╝';
                        Vertical = '║';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleRound:
                    {
                        TL_Corner = '╭';
                        BL_Corner = '╰';
                        TR_Corner = '╮';
                        BR_Corner = '╯';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.DoubleSingle:
                    {
                        TL_Corner = '╒';
                        BL_Corner = '╘';
                        TR_Corner = '╕';
                        BR_Corner = '╛';
                        Vertical = '│';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleDouble:
                    {
                        TL_Corner = '╓';
                        BL_Corner = '╙';
                        TR_Corner = '╖';
                        BR_Corner = '╜';
                        Vertical = '║';
                        Horizontal = '─';

                        break;
                    }
            }

            int _Width = Width - 2 + Padding.Left + Padding.Right;
            int _Height = Height - 2 + Padding.Top + Padding.Bottom;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Content">Control content.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, string Content)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            int _Width = Width - 2;
            int _Height = Height - 2;
            int ContentX = (_Width / 2) - Content.GetLongestLineLength();
            int ContentY = (_Height / 2) - Content.GetNumberOfLines();

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y < Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);

            string[] Lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(X - ContentX, Y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Content">Control content.</param>
        /// <param name="Padding">Control padding.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, string Content, Thickness Padding)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            int _Width = Width - 2 + Padding.Left + Padding.Right;
            int _Height = Height - 2 + Padding.Top + Padding.Bottom;
            int ContentY = (_Height / 2) + 1;
            int ContentX = (_Width / 2);

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);

            string[] Lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(X + ContentX, Y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Content">Control content.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, string Content, Line Line)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            switch (Line)
            {
                case Line.Single:
                    {
                        TL_Corner = '┌';
                        BL_Corner = '└';
                        TR_Corner = '┐';
                        BR_Corner = '┘';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.Double:
                    {
                        TL_Corner = '╔';
                        BL_Corner = '╚';
                        TR_Corner = '╗';
                        BR_Corner = '╝';
                        Vertical = '║';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleRound:
                    {
                        TL_Corner = '╭';
                        BL_Corner = '╰';
                        TR_Corner = '╮';
                        BR_Corner = '╯';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.DoubleSingle:
                    {
                        TL_Corner = '╒';
                        BL_Corner = '╘';
                        TR_Corner = '╕';
                        BR_Corner = '╛';
                        Vertical = '│';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleDouble:
                    {
                        TL_Corner = '╓';
                        BL_Corner = '╙';
                        TR_Corner = '╖';
                        BR_Corner = '╜';
                        Vertical = '║';
                        Horizontal = '─';

                        break;
                    }
            }

            int _Width = Width - 2;
            int _Height = Height - 2;
            int ContentY = (_Height / 2) + 1;
            int ContentX = (_Width / 2);

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);

            string[] Lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(X + ContentX, Y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Content">Control content.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Line">Control border style.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            switch (Line)
            {
                case Line.Single:
                    {
                        TL_Corner = '┌';
                        BL_Corner = '└';
                        TR_Corner = '┐';
                        BR_Corner = '┘';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.Double:
                    {
                        TL_Corner = '╔';
                        BL_Corner = '╚';
                        TR_Corner = '╗';
                        BR_Corner = '╝';
                        Vertical = '║';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleRound:
                    {
                        TL_Corner = '╭';
                        BL_Corner = '╰';
                        TR_Corner = '╮';
                        BR_Corner = '╯';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.DoubleSingle:
                    {
                        TL_Corner = '╒';
                        BL_Corner = '╘';
                        TR_Corner = '╕';
                        BR_Corner = '╛';
                        Vertical = '│';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleDouble:
                    {
                        TL_Corner = '╓';
                        BL_Corner = '╙';
                        TR_Corner = '╖';
                        BR_Corner = '╜';
                        Vertical = '║';
                        Horizontal = '─';

                        break;
                    }
            }

            /*
            
            ╔══════╗
            ║      ║
            ║      ║ - 5 height (3 inside)
            ║      ║
            ╚══════╝ - 8 width (6 inside)

            */

            int _Width = Width - 2 + Padding.Left + Padding.Right;
            int _Height = Height - 2 + Padding.Top + Padding.Bottom;
            int ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;
            int ContentY = ((_Height / 2) - Content.GetNumberOfLines() / 2) + 1 + Padding.Top - Padding.Bottom;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);

            string[] Lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(X + ContentX, Y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Content">Control content.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Line">Control border style.</param>
        /// <param name="ContentHorizontalAlignment">Control content horizontal alignment.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line, HorizontalAlignment ContentHorizontalAlignment)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            switch (Line)
            {
                case Line.Single:
                    {
                        TL_Corner = '┌';
                        BL_Corner = '└';
                        TR_Corner = '┐';
                        BR_Corner = '┘';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.Double:
                    {
                        TL_Corner = '╔';
                        BL_Corner = '╚';
                        TR_Corner = '╗';
                        BR_Corner = '╝';
                        Vertical = '║';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleRound:
                    {
                        TL_Corner = '╭';
                        BL_Corner = '╰';
                        TR_Corner = '╮';
                        BR_Corner = '╯';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.DoubleSingle:
                    {
                        TL_Corner = '╒';
                        BL_Corner = '╘';
                        TR_Corner = '╕';
                        BR_Corner = '╛';
                        Vertical = '│';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleDouble:
                    {
                        TL_Corner = '╓';
                        BL_Corner = '╙';
                        TR_Corner = '╖';
                        BR_Corner = '╜';
                        Vertical = '║';
                        Horizontal = '─';

                        break;
                    }
            }

            int _Width = Width - 2 + Padding.Left + Padding.Right;
            int _Height = Height - 2 + Padding.Top + Padding.Bottom;

            int ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;
            int ContentY = ((_Height / 2) - Content.GetNumberOfLines() / 2) + 1 + Padding.Top - Padding.Bottom;

            switch (ContentHorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        ContentX = 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Right:
                    {
                        ContentX = Width - Content.GetLongestLineLength() - 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Center:
                    {
                        ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Stretch:
                    {
                        ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;

                        break;
                    }
            }

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);

            string[] Lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(X + ContentX, Y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Content">Control content.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Line">Control border style.</param>
        /// <param name="ContentHorizontalAlignment">Control content horizontal alignment.</param>
        /// <param name="ContentVerticalAlignment">Control content vertical alignment.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            switch (Line)
            {
                case Line.Single:
                    {
                        TL_Corner = '┌';
                        BL_Corner = '└';
                        TR_Corner = '┐';
                        BR_Corner = '┘';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.Double:
                    {
                        TL_Corner = '╔';
                        BL_Corner = '╚';
                        TR_Corner = '╗';
                        BR_Corner = '╝';
                        Vertical = '║';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleRound:
                    {
                        TL_Corner = '╭';
                        BL_Corner = '╰';
                        TR_Corner = '╮';
                        BR_Corner = '╯';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.DoubleSingle:
                    {
                        TL_Corner = '╒';
                        BL_Corner = '╘';
                        TR_Corner = '╕';
                        BR_Corner = '╛';
                        Vertical = '│';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleDouble:
                    {
                        TL_Corner = '╓';
                        BL_Corner = '╙';
                        TR_Corner = '╖';
                        BR_Corner = '╜';
                        Vertical = '║';
                        Horizontal = '─';

                        break;
                    }
            }

            int _Width = Width - 2 + Padding.Left + Padding.Right;
            int _Height = Height - 2 + Padding.Top + Padding.Bottom;

            int ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;
            int ContentY = ((_Height / 2) - Content.GetNumberOfLines() / 2) + 1 + Padding.Top - Padding.Bottom;

            switch (ContentHorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        ContentX = 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Right:
                    {
                        ContentX = Width - Content.GetLongestLineLength() - 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Center:
                    {
                        ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Stretch:
                    {
                        ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;

                        break;
                    }
            }

            switch (ContentVerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        ContentY = 1 + Padding.Top - Padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Bottom:
                    {
                        ContentY = Height - Content.GetNumberOfLines() - 1 + Padding.Top - Padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Center:
                    {
                        ContentY = ((_Height / 2) - Content.GetNumberOfLines() / 2) + 1 + Padding.Top - Padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Stretch:
                    {
                        ContentY = ((_Height / 2) - Content.GetNumberOfLines() / 2) + 1 + Padding.Top - Padding.Bottom;

                        break;
                    }
            }

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);

            string[] Lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(X + ContentX, Y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Content">Control content.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Line">Control border style.</param>
        /// <param name="ContentHorizontalAlignment">Control content horizontal alignment.</param>
        /// <param name="ContentVerticalAlignment">Control content vertical alignment.</param>
        /// <param name="BorderColor">Control border color.</param>
        public static void DrawBox(int X, int Y, int Width, int Height, string Content, Thickness Padding, Line Line, HorizontalAlignment ContentHorizontalAlignment, VerticalAlignment ContentVerticalAlignment, ConsoleColor BorderColor)
        {
            char TL_Corner = '╔';
            char BL_Corner = '╚';
            char TR_Corner = '╗';
            char BR_Corner = '╝';
            char Vertical = '║';
            char Horizontal = '═';

            switch (Line)
            {
                case Line.Single:
                    {
                        TL_Corner = '┌';
                        BL_Corner = '└';
                        TR_Corner = '┐';
                        BR_Corner = '┘';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.Double:
                    {
                        TL_Corner = '╔';
                        BL_Corner = '╚';
                        TR_Corner = '╗';
                        BR_Corner = '╝';
                        Vertical = '║';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleRound:
                    {
                        TL_Corner = '╭';
                        BL_Corner = '╰';
                        TR_Corner = '╮';
                        BR_Corner = '╯';
                        Vertical = '│';
                        Horizontal = '─';

                        break;
                    }

                case Line.DoubleSingle:
                    {
                        TL_Corner = '╒';
                        BL_Corner = '╘';
                        TR_Corner = '╕';
                        BR_Corner = '╛';
                        Vertical = '│';
                        Horizontal = '═';

                        break;
                    }

                case Line.SingleDouble:
                    {
                        TL_Corner = '╓';
                        BL_Corner = '╙';
                        TR_Corner = '╖';
                        BR_Corner = '╜';
                        Vertical = '║';
                        Horizontal = '─';

                        break;
                    }
            }

            int _Width = Width - 2 + Padding.Left + Padding.Right;
            int _Height = Height - 2 + Padding.Top + Padding.Bottom;

            int ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;
            int ContentY = ((_Height / 2) - Content.GetNumberOfLines() / 2) + 1 + Padding.Top - Padding.Bottom;

            switch (ContentHorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        ContentX = 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Right:
                    {
                        ContentX = Width - Content.GetLongestLineLength() - 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Center:
                    {
                        ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;

                        break;
                    }

                case HorizontalAlignment.Stretch:
                    {
                        ContentX = ((_Width / 2) - Content.GetLongestLineLength() / 2) + 1 - Padding.Right + Padding.Left;

                        break;
                    }
            }

            switch (ContentVerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        ContentY = 1 + Padding.Top - Padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Bottom:
                    {
                        ContentY = Height - Content.GetNumberOfLines() - 1 + Padding.Top - Padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Center:
                    {
                        ContentY = ((_Height / 2) - Content.GetNumberOfLines() / 2) + 1 + Padding.Top - Padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Stretch:
                    {
                        ContentY = ((_Height / 2) - Content.GetNumberOfLines() / 2) + 1 + Padding.Top - Padding.Bottom;

                        break;
                    }
            }

            // box top
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = BorderColor;
            Console.Write(TL_Corner + new string(Horizontal, _Width) + TR_Corner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(Vertical);
                Console.SetCursorPosition(X + _Width + 1, _Y);
                Console.Write(Vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(BL_Corner + new string(Horizontal, _Width) + BR_Corner);
            Console.ForegroundColor = ConsoleColor.White;

            string[] Lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(X + ContentX, Y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw text.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Content">Control content.</param>
        public static void DrawText(int X, int Y, string Content)
        {
            string[] lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int Height = 0; Height < lines.Length; Height++)
            {
                Console.SetCursorPosition(X, Y + Height);
                Console.Write(lines[Height]);
            }
        }
        /// <summary>
        /// Draw text.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Content">Control content.</param>
        /// <param name="ForegroundColor">Text foreground color.</param>
        public static void DrawText(int X, int Y, string Content, ConsoleColor ForegroundColor)
        {
            Console.ForegroundColor = ForegroundColor;

            string[] lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int Height = 0; Height < lines.Length; Height++)
            {
                Console.SetCursorPosition(X, Y + Height);
                Console.Write(lines[Height]);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Clear rectangle.
        /// </summary>
        /// <param name="Rectangle">Area to clear.</param>
        public static void DrawBlank(Rectangle Rectangle)
        {
            for (int Y = Rectangle.Y; Y <= Rectangle.Y + Rectangle.Height; Y++)
            {
                Console.SetCursorPosition(Rectangle.X, Y);
                Console.Write(new string(' ', Rectangle.Width));
            }
        }
    }
}
