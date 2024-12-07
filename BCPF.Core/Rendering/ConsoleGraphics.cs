using BCPF.Core.Controls;
using BCPF.Core.Rendering.Style;
using BCPF.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static BCPF.Core.Utilities.SyntaxHighlight;
using static BCPF.Core.Utilities.Utilities;

namespace BCPF.Core.Rendering
{
    public static class ConsoleGraphics
    {
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        public static void DrawBox(int x, int y, int width, int height)
        {
            BorderStyle borderStyle = new BorderStyle(Line.Double);

            int _width = width - 2;
            int _height = height - 2;

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);
        }
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="padding">Control padding.</param>
        public static void DrawBox(int x, int y, int width, int height, Thickness padding)
        {
            BorderStyle borderStyle = new BorderStyle(Line.Double);

            int _width = width - 2 + padding.Left + padding.Right;
            int _height = height - 2 + padding.Top + padding.Bottom;

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);
        }
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="borderStyle">Control border style.</param>
        public static void DrawBox(int x, int y, int width, int height, BorderStyle borderStyle)
        {
            int _width = width - 2;
            int _height = height - 2;

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);
        }
        /// <summary>
        /// Draw box with fixed size.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="padding">Control padding.</param>
        /// <param name="borderStyle">Control border style.</param>
        public static void DrawBox(int x, int y, int width, int height, Thickness padding, BorderStyle borderStyle)
        {
            int _width = width - 2 + padding.Left + padding.Right;
            int _height = height - 2 + padding.Top + padding.Bottom;

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="content">Control content.</param>
        public static void DrawBox(int x, int y, int width, int height, string content)
        {
            BorderStyle borderStyle = new BorderStyle(Line.Double);

            int _width = width - 2;
            int _height = height - 2;
            int ContentX = (_width / 2) - content.GetLongestLineLength();
            int ContentY = (_height / 2) - content.GetNumberOfLines();

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y < y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);

            string[] Lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(x - ContentX, y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="content">Control content.</param>
        /// <param name="padding">Control padding.</param>
        public static void DrawBox(int x, int y, int width, int height, string content, Thickness padding)
        {
            BorderStyle borderStyle = new BorderStyle(Line.Double);

            int _width = width - 2 + padding.Left + padding.Right;
            int _height = height - 2 + padding.Top + padding.Bottom;
            int ContentY = (_height / 2) + 1;
            int ContentX = (_width / 2);

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);

            string[] Lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(x + ContentX, y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="content">Control content.</param>
        public static void DrawBox(int x, int y, int width, int height, string content, BorderStyle Border)
        {
            int _width = width - 2;
            int _height = height - 2;
            int ContentY = (_height / 2) + 1;
            int ContentX = (_width / 2);

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(Border.TopLeftCorner + new string(Border.Horizontal, _width) + Border.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(Border.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(Border.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(Border.BottomLeftCorner + new string(Border.Horizontal, _width) + Border.BottomRightCorner);

            string[] Lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(x + ContentX, y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="content">Control content.</param>
        /// <param name="padding">Control padding.</param>
        /// <param name="Border">Control border style.</param>
        public static void DrawBox(int x, int y, int width, int height, string content, Thickness padding, BorderStyle Border)
        {
            /*
            
            ╔══════╗
            ║      ║
            ║      ║ - 5 height (3 inside)
            ║      ║
            ╚══════╝ - 8 width (6 inside)

            */

            int _width = width - 2 + padding.Left + padding.Right;
            int _height = height - 2 + padding.Top + padding.Bottom;
            int ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;
            int ContentY = ((_height / 2) - content.GetNumberOfLines() / 2) + 1 + padding.Top - padding.Bottom;

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(Border.TopLeftCorner + new string(Border.Horizontal, _width) + Border.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(Border.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(Border.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(Border.BottomLeftCorner + new string(Border.Horizontal, _width) + Border.BottomRightCorner);

            string[] Lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(x + ContentX, y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="content">Control content.</param>
        /// <param name="padding">Control padding.</param>
        /// <param name="borderStyle">Control border style.</param>
        /// <param name="contentHorizontalAlignment">Control content Border.Horizontal alignment.</param>
        public static void DrawBox(int x, int y, int width, int height, string content, Thickness padding, BorderStyle borderStyle, HorizontalAlignment contentHorizontalAlignment)
        {
            int _width = width - 2 + padding.Left + padding.Right;
            int _height = height - 2 + padding.Top + padding.Bottom;

            int ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;
            int ContentY = ((_height / 2) - content.GetNumberOfLines() / 2) + 1 + padding.Top - padding.Bottom;

            switch (contentHorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        ContentX = 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Right:
                    {
                        ContentX = width - content.GetLongestLineLength() - 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Center:
                    {
                        ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Stretch:
                    {
                        ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;

                        break;
                    }
            }

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);

            string[] Lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(x + ContentX, y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="content">Control content.</param>
        /// <param name="padding">Control padding.</param>
        /// <param name="borderStyle">Control border style.</param>
        /// <param name="contentHorizontalAlignment">Control content Border.Horizontal alignment.</param>
        /// <param name="contentVerticalAlignment">Control content Border.Vertical alignment.</param>
        public static void DrawBox(int x, int y, int width, int height, string content, Thickness padding, BorderStyle borderStyle, HorizontalAlignment contentHorizontalAlignment, VerticalAlignment contentVerticalAlignment)
        {
            int _width = width - 2 + padding.Left + padding.Right;
            int _height = height - 2 + padding.Top + padding.Bottom;

            int ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;
            int ContentY = ((_height / 2) - content.GetNumberOfLines() / 2) + 1 + padding.Top - padding.Bottom;

            switch (contentHorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        ContentX = 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Right:
                    {
                        ContentX = width - content.GetLongestLineLength() - 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Center:
                    {
                        ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Stretch:
                    {
                        ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;

                        break;
                    }
            }

            switch (contentVerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        ContentY = 1 + padding.Top - padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Bottom:
                    {
                        ContentY = height - content.GetNumberOfLines() - 1 + padding.Top - padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Center:
                    {
                        ContentY = ((_height / 2) - content.GetNumberOfLines() / 2) + 1 + padding.Top - padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Stretch:
                    {
                        ContentY = ((_height / 2) - content.GetNumberOfLines() / 2) + 1 + padding.Top - padding.Bottom;

                        break;
                    }
            }

            // box top
            Console.SetCursorPosition(x, y);
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);

            string[] Lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(x + ContentX, y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw box with fixed size with content.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="width">Control width.</param>
        /// <param name="height">Control height.</param>
        /// <param name="content">Control content.</param>
        /// <param name="padding">Control padding.</param>
        /// <param name="borderStyle">Control border style.</param>
        /// <param name="contentHorizontalAlignment">Control content Border.Horizontal alignment.</param>
        /// <param name="contentVerticalAlignment">Control content Border.Vertical alignment.</param>
        /// <param name="BorderColor">Control border color.</param>
        public static void DrawBox(int x, int y, int width, int height, string content, Thickness padding, BorderStyle borderStyle, HorizontalAlignment contentHorizontalAlignment, VerticalAlignment contentVerticalAlignment, ConsoleColor BorderColor)
        {
            int _width = width - 2 + padding.Left + padding.Right;
            int _height = height - 2 + padding.Top + padding.Bottom;

            int ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;
            int ContentY = ((_height / 2) - content.GetNumberOfLines() / 2) + 1 + padding.Top - padding.Bottom;

            switch (contentHorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        ContentX = 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Right:
                    {
                        ContentX = width - content.GetLongestLineLength() - 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Center:
                    {
                        ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;

                        break;
                    }

                case HorizontalAlignment.Stretch:
                    {
                        ContentX = ((_width / 2) - content.GetLongestLineLength() / 2) + 1 - padding.Right + padding.Left;

                        break;
                    }
            }

            switch (contentVerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        ContentY = 1 + padding.Top - padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Bottom:
                    {
                        ContentY = height - content.GetNumberOfLines() - 1 + padding.Top - padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Center:
                    {
                        ContentY = ((_height / 2) - content.GetNumberOfLines() / 2) + 1 + padding.Top - padding.Bottom;

                        break;
                    }

                case VerticalAlignment.Stretch:
                    {
                        ContentY = ((_height / 2) - content.GetNumberOfLines() / 2) + 1 + padding.Top - padding.Bottom;

                        break;
                    }
            }

            // box top
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = BorderColor;
            Console.Write(borderStyle.TopLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.TopRightCorner);

            // Set width and height
            for (int _Y = y + 1; _Y <= y + _height; _Y++)
            {
                Console.SetCursorPosition(x, _Y);
                Console.Write(borderStyle.Vertical);
                Console.SetCursorPosition(x + _width + 1, _Y);
                Console.Write(borderStyle.Vertical);
            }

            // box bottom
            Console.SetCursorPosition(x, y + _height + 1);
            Console.Write(borderStyle.BottomLeftCorner + new string(borderStyle.Horizontal, _width) + borderStyle.BottomRightCorner);
            Console.ForegroundColor = ConsoleColor.White;

            string[] Lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int i = 0; i < Lines.Length; i++)
            {
                Console.SetCursorPosition(x + ContentX, y + i + ContentY);
                Console.Write(Lines[i]);
            }
        }
        /// <summary>
        /// Draw text.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="content">Control content.</param>
        public static void DrawText(int x, int y, string content)
        {
            string[] lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int height = 0; height < lines.Length; height++)
            {
                Console.SetCursorPosition(x, y + height);
                Console.Write(lines[height]);
            }
        }
        /// <summary>
        /// Draw text.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="content">Control content.</param>
        /// <param name="foregroundColor">Text foreground color.</param>
        public static void DrawText(int x, int y, string content, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;

            string[] lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int height = 0; height < lines.Length; height++)
            {
                Console.SetCursorPosition(x, y + height);
                Console.Write(lines[height]);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Draw text with syntax highlighting.
        /// </summary>
        /// <param name="x">Position from left.</param>
        /// <param name="y">Position from top.</param>
        /// <param name="content">Control content.</param>
        /// <param name="language">Programming language.</param>
        public static void DrawText(int x, int y, string content, ProgrammingLanguage language)
        {
            //.ReplaceLineEndings();
            string[] lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Text content
            for (int height = 0; height < lines.Length; height++)
            {
                int OffsetX = 0;

                string Pattern = KEYWORDS_CS.Replace(",", "|") + "|" + DATATYPES.Replace(",", "|");

                Dictionary<string, ConsoleColor> LanguageDictionary = GetHighlight(language);

                string PrevLinePart = "";

                bool LineIsComment = false;

                foreach (string LinePart in Regex.Split(lines[height], @"\b(" + Pattern + @")\b"))
                {
                    if (LanguageDictionary.ContainsKey(LinePart) && !LineIsComment && (PrevLinePart.Contains('\n') || height == 0))
                    {
                        Console.ForegroundColor = LanguageDictionary[LinePart];

                        Console.SetCursorPosition(x + OffsetX, y + height);
                        Console.Write(LinePart);

                        OffsetX += LinePart.Length;

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        foreach (string _LinePart in LinePart.Split('\n'))
                        {
                            if (_LinePart.IndexOf("//", 0) != -1)
                            {
                                int index = _LinePart.IndexOf("//", 0);

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(x + OffsetX, y + height);
                                Console.Write(_LinePart.Substring(0, index));

                                OffsetX += index;

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x + OffsetX, y + height);
                                Console.Write(_LinePart.Substring(index, _LinePart.Length - index));

                                Console.ForegroundColor = ConsoleColor.White;

                                LineIsComment = true;
                            }
                            else
                            {
                                if (!LineIsComment) Console.ForegroundColor = ConsoleColor.White;
                                else Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.SetCursorPosition(x + OffsetX, y + height);
                                Console.Write(_LinePart);

                            }

                            OffsetX += LinePart.Length;
                        }
                    }

                    PrevLinePart = LinePart;
                }
            }
        }
        /// <summary>
        /// Clear rectangle.
        /// </summary>
        /// <param name="Rectangle">Area to clear.</param>
        public static void DrawBlank(Rectangle Rectangle)
        {
            for (int y = Rectangle.Y; y <= Rectangle.Y + Rectangle.Height; y++)
            {
                Console.SetCursorPosition(Math.Clamp(Rectangle.X, 0, Console.BufferWidth - 1), Math.Clamp(y, 0, Console.BufferHeight - 1));
                Console.Write(new string(' ', Rectangle.Width));
            }
        }
    }
}
