using BCPF.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPF.Core.Rendering
{
    internal static class Renderer_old
    {
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        private static void DrawBox(int X, int Y, int Width, int Height)
        {
            char ulCorner = '╔';
            char llCorner = '╚';
            char urCorner = '╗';
            char lrCorner = '╝';
            char vertical = '║';
            char horizontal = '═';

            int _Width = Width - 2;
            int _Height = Height - 2;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(ulCorner + new string(horizontal, _Width) + urCorner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(vertical + new string(' ', _Width) + vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(llCorner + new string(horizontal, _Width) + lrCorner);
        }
        /// <summary>
        /// Draw box with auto sized border
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Content">Control content.</param>
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control height.</param>
        /// <param name="Content">Control content.</param>
        private static void DrawBox(int X, int Y, int Width, int Height, string Content)
        {
            char ulCorner = '╔';
            char llCorner = '╚';
            char urCorner = '╗';
            char lrCorner = '╝';
            char vertical = '║';
            char horizontal = '═';

            int _Width = Width - 2;
            int _Height = Height - 2;
            int ContentY = (_Height / 2) + 1;
            int ContentX = (_Width / 2);

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(ulCorner + new string(horizontal, _Width) + urCorner);

            // Set width and height
            for (int _Y = Y + 1; _Y <= Y + _Height; _Y++)
            {
                Console.SetCursorPosition(X, _Y);
                Console.Write(vertical + new string(' ', _Width) + vertical);
            }

            // box bottom
            Console.SetCursorPosition(X, Y + _Height + 1);
            Console.Write(llCorner + new string(horizontal, _Width) + lrCorner);

            string[] lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(X + ContentX, Y + i + ContentY);
                Console.Write(lines[i]);
            }
        }

        /// <summary>
        /// Draw box with auto sized border
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Content">Control content.</param>
        private static void DrawBox(int X, int Y, Thickness Padding, string Content)
        {
            string ulCorner = "╔";
            string llCorner = "╚";
            string urCorner = "╗";
            string lrCorner = "╝";
            string vertical = "║";
            string horizontal = "═";

            int longest = Content.GetLongestLineLength();

            int width = longest + 2; // 1 space on each side

            string h = string.Empty;
            for (int i = 0; i < width; i++)
                h += horizontal;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(ulCorner + h + urCorner);

            int Height = 1, pdng; ;

            // Set padding top
            if (Padding != null)
                for (pdng = 0; pdng < Padding.Top; pdng++)
                {
                    string Spacing = "";
                    for (int i = 0; i < width; i++)
                    {
                        Spacing += " ";
                    }

                    Console.SetCursorPosition(X, Y + Height);
                    Console.Write(vertical + Spacing + vertical);

                    Height++;
                }

            string[] lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // box contents
            foreach (string line in lines)
            {
                double dblSpaces = (width - (double)line.Length) / 2;
                int iSpaces = Convert.ToInt32(dblSpaces);

                if (dblSpaces > iSpaces) // not an even amount of chars
                {
                    iSpaces += 1; // round up to next whole number
                }

                string beginSpacing = "";
                string endSpacing = "";
                for (int i = 0; i < iSpaces; i++)
                {
                    beginSpacing += " ";

                    if (!(iSpaces > dblSpaces && i == iSpaces - 1)) // if there is an extra space somewhere, it should be in the beginning
                    {
                        endSpacing += " ";
                    }
                }
                // add the text line to the box

                Console.SetCursorPosition(X, Y + Height);
                Console.Write(vertical + beginSpacing + line + endSpacing + vertical);
                Height++;
            }

            // Set padding bottom
            if (Padding != null)
                for (pdng = 0; pdng < Padding.Bottom; pdng++)
                {
                    string Spacing = "";
                    for (int i = 0; i < width; i++)
                    {
                        Spacing += " ";
                    }

                    Console.SetCursorPosition(X, Y + Height);
                    Console.Write(vertical + Spacing + vertical);

                    Height++;
                }

            // box bottom
            Console.SetCursorPosition(X, Y + Height);
            Console.Write(llCorner + h + lrCorner);
        }
        /// <summary>
        /// Draw box with auto sized border
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Content">Control content.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Pressed">Control is pressed.</param>
        private static void DrawBox(int X, int Y, Thickness Padding, string Content, bool Pressed)
        {
            string ulCorner;
            string llCorner;
            string urCorner;
            string lrCorner;
            string vertical;
            string horizontal;

            if (!Pressed)
            {
                ulCorner = "┌";
                llCorner = "└";
                urCorner = "┐";
                lrCorner = "┘";
                vertical = "│";
                horizontal = "─";
            }
            else
            {
                ulCorner = "╔";
                llCorner = "╚";
                urCorner = "╗";
                lrCorner = "╝";
                vertical = "║";
                horizontal = "═";
            }

            string[] lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int longest = Content.GetLongestLineLength();

            int width = longest + 2; // 1 space on each side

            string h = string.Empty;
            for (int i = 0; i < width; i++)
                h += horizontal;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(ulCorner + h + urCorner);

            int Height = 1, pdng; ;

            // Set padding top
            if (Padding != null)
                for (pdng = 0; pdng < Padding.Top; pdng++)
                {
                    string Spacing = "";
                    for (int i = 0; i < width; i++)
                    {
                        Spacing += " ";
                    }

                    Console.SetCursorPosition(X, Y + Height);
                    Console.Write(vertical + Spacing + vertical);

                    Height++;
                }

            // box contents
            foreach (string line in lines)
            {
                double dblSpaces = (width - (double)line.Length) / 2;
                int iSpaces = Convert.ToInt32(dblSpaces);

                if (dblSpaces > iSpaces) // not an even amount of chars
                {
                    iSpaces += 1; // round up to next whole number
                }

                string beginSpacing = "";
                string endSpacing = "";
                for (int i = 0; i < iSpaces; i++)
                {
                    beginSpacing += " ";

                    if (!(iSpaces > dblSpaces && i == iSpaces - 1)) // if there is an extra space somewhere, it should be in the beginning
                    {
                        endSpacing += " ";
                    }
                }
                // add the text line to the box

                Console.SetCursorPosition(X, Y + Height);
                Console.Write(vertical + beginSpacing + line + endSpacing + vertical);
                Height++;
            }

            // Set padding bottom
            if (Padding != null)
                for (pdng = 0; pdng < Padding.Bottom; pdng++)
                {
                    string Spacing = "";
                    for (int i = 0; i < width; i++)
                    {
                        Spacing += " ";
                    }

                    Console.SetCursorPosition(X, Y + Height);
                    Console.Write(vertical + Spacing + vertical);

                    Height++;
                }

            // box bottom
            Console.SetCursorPosition(X, Y + Height);
            Console.Write(llCorner + h + lrCorner);
        }
        /// <summary>
        /// Draw box with auto sized border
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Width">Control width.</param>
        /// <param name="Height">Control Height.</param>
        /// <param name="Content">Control content.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Pressed">Control is pressed.</param>
        private static void DrawBox(int X, int Y, int Width, int Height, Thickness Padding, string Content, bool Pressed)
        {
            string ulCorner;
            string llCorner;
            string urCorner;
            string lrCorner;
            string vertical;
            string horizontal;

            if (!Pressed)
            {
                ulCorner = "┌";
                llCorner = "└";
                urCorner = "┐";
                lrCorner = "┘";
                vertical = "│";
                horizontal = "─";
            }
            else
            {
                ulCorner = "╔";
                llCorner = "╚";
                urCorner = "╗";
                lrCorner = "╝";
                vertical = "║";
                horizontal = "═";
            }

            string[] lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int longest = Content.GetLongestLineLength();

            int width = longest + 2; // 1 space on each side

            string h = string.Empty;
            for (int i = 0; i < width; i++)
                h += horizontal;

            // box top
            Console.SetCursorPosition(X, Y);
            Console.Write(ulCorner + h + urCorner);

            int CurrentHeight = 1, pdng; ;

            // Set padding top
            if (Padding != null)
                for (pdng = 0; pdng < Padding.Top; pdng++)
                {
                    string Spacing = "";
                    for (int i = 0; i < width; i++)
                    {
                        Spacing += " ";
                    }

                    Console.SetCursorPosition(X, Y + CurrentHeight);
                    Console.Write(vertical + Spacing + vertical);

                    CurrentHeight++;
                }

            // box contents
            foreach (string line in lines)
            {
                double dblSpaces = (width - (double)line.Length) / 2;
                int iSpaces = Convert.ToInt32(dblSpaces);

                if (dblSpaces > iSpaces) // not an even amount of chars
                {
                    iSpaces += 1; // round up to next whole number
                }

                string beginSpacing = "";
                string endSpacing = "";
                for (int i = 0; i < iSpaces; i++)
                {
                    beginSpacing += " ";

                    if (!(iSpaces > dblSpaces && i == iSpaces - 1)) // if there is an extra space somewhere, it should be in the beginning
                    {
                        endSpacing += " ";
                    }
                }
                // add the text line to the box

                Console.SetCursorPosition(X, Y + CurrentHeight);
                Console.Write(vertical + beginSpacing + line + endSpacing + vertical);
                CurrentHeight++;
            }

            // Set padding bottom
            if (Padding != null)
                for (pdng = 0; pdng < Padding.Bottom; pdng++)
                {
                    string Spacing = "";
                    for (int i = 0; i < width; i++)
                    {
                        Spacing += " ";
                    }

                    Console.SetCursorPosition(X, Y + CurrentHeight);
                    Console.Write(vertical + Spacing + vertical);

                    CurrentHeight++;
                }

            // box bottom
            Console.SetCursorPosition(X, Y + CurrentHeight);
            Console.Write(llCorner + h + lrCorner);
        }
        /// <summary>
        /// Draw text.
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Content">Control content.</param>
        private static void DrawText(int X, int Y, string Content)
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
        private static void DrawText(int X, int Y, string Content, ConsoleColor ForegroundColor)
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
        private static void DrawBlank(Rectangle Rectangle)
        {
            for (int Y = Rectangle.Y; Y <= Rectangle.Y + Rectangle.Height; Y++)
            {
                Console.SetCursorPosition(Rectangle.X, Y);
                Console.Write(new string(' ', Rectangle.Width));
            }
        }
    }
}
