using BeConsolePresentationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeConsolePresentationFramework.Rendering
{
    public static class Renderer
    {
        /// <summary>
        /// Draw box with auto sized border
        /// </summary>
        /// <param name="X">Position from left.</param>
        /// <param name="Y">Position from top.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Content">Control content.</param>
        public static void DrawBox(int X, int Y, Thickness Padding, string Content)
        {
            string ulCorner = "╔";
            string llCorner = "╚";
            string urCorner = "╗";
            string lrCorner = "╝";
            string vertical = "║";
            string horizontal = "═";

            string[] lines = Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int longest = 0;
            foreach (string line in lines)
            {
                if (line.Length > longest)
                    longest = line.Length;
            }
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
        /// <param name="Content">Control content.</param>
        /// <param name="Padding">Control padding.</param>
        /// <param name="Pressed">Control is pressed.</param>
        public static void DrawBox(int X, int Y, Thickness Padding, string Content, bool Pressed)
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

            int longest = 0;
            foreach (string line in lines)
            {
                if (line.Length > longest)
                    longest = line.Length;
            }
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
        public static void DrawBox(int X, int Y, int Width, int Height, Thickness Padding, string Content, bool Pressed)
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

            int longest = 0;
            foreach (string line in lines)
            {
                if (line.Length > longest)
                    longest = line.Length;
            }
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
        public static void DrawText(int X, int Y, string Content)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Content);
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
            Console.SetCursorPosition(X, Y);
            Console.Write(Content);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Clear rectangle.
        /// </summary>
        /// <param name="Rectangle">Area to clear.</param>
        public static void DrawBlank(Rectangle Rectangle)
        {
            for (int X = Rectangle.X; X < Rectangle.X + Rectangle.Width; X++)
            {
                for (int Y = Rectangle.Top; Y < Rectangle.Y + Rectangle.Height; Y++)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write(' ');
                }
            }
        }
    }
}
