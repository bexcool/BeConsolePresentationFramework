using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using BeConsolePresentationFramework.Utilities;
using BeConsolePresentationFramework.Rendering;
using BeConsolePresentationFramework.Controls.Base;
using BeConsolePresentationFramework.Controls;
using System.Drawing;

namespace BeConsolePresentationFramework
{
    public abstract class ConsolePresentation
    {
        static List<Control> AllControls = new List<Control>();
        Thread InputThread, RenderThread;
        private NativeMethods.INPUT_RECORD record;
        int LastLeftMouseButtonPressed = 0;
        bool ExitRequest = false;

        public ConsolePresentation()
        {
            InitializeConsole();
            Render();

            InputThread = new Thread(InitializeCore);
            InputThread.IsBackground = false;
            InputThread.Start();
            /*
            RenderThread = new Thread(Test);
            RenderThread.Start();*/
        }

        private void Test()
        {
            while (!ExitRequest)
            {
                Debug.WriteLine("ff");
                Render();
            }
        }

        private void InitializeConsole()
        {
            ConsoleExtension.DisableEdit();
            Console.CursorVisible = false;
        }

        public static void AddControl(Control control)
        {
            AllControls.Add(control);
        }
        public static void RemoveControl(Control control)
        {
            AllControls.Remove(control);
        }

        private void InitializeCore()
        {
            var handle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE);
            
            int mode = 0;
            if (!(NativeMethods.GetConsoleMode(handle, ref mode))) { throw new Win32Exception(); }

            mode |= NativeMethods.ENABLE_MOUSE_INPUT;
            mode &= ~NativeMethods.ENABLE_QUICK_EDIT_MODE;
            mode |= NativeMethods.ENABLE_EXTENDED_FLAGS;

            if (!(NativeMethods.SetConsoleMode(handle, mode))) { throw new Win32Exception(); }
            
            record = new NativeMethods.INPUT_RECORD();
            uint recordLen = 0;

            while (!ExitRequest)
            {
                if (!NativeMethods.ReadConsoleInput(handle, ref record, 1, ref recordLen)) { throw new Win32Exception(); }
                Console.SetCursorPosition(0, 0);
                
                switch (record.EventType)
                {
                    case NativeMethods.MOUSE_EVENT:
                        {
                            Console.WriteLine("Mouse event");
                            Console.WriteLine(string.Format("    X ...............:   {0,4:0}  ", record.MouseEvent.dwMousePosition.X));
                            Console.WriteLine(string.Format("    Y ...............:   {0,4:0}  ", record.MouseEvent.dwMousePosition.Y));
                            Console.WriteLine(string.Format("    dwButtonState ...: 0x{0:X4}  ", record.MouseEvent.dwButtonState));
                            Console.WriteLine(string.Format("    dwControlKeyState: 0x{0:X4}  ", record.MouseEvent.dwControlKeyState));
                            Console.WriteLine(string.Format("    dwEventFlags ....: 0x{0:X4}  ", record.MouseEvent.dwEventFlags));
                        }
                        break;

                    case NativeMethods.KEY_EVENT:
                        {
                            Console.WriteLine("Key event  ");
                            Console.WriteLine(string.Format("    bKeyDown  .......:  {0,5}  ", record.KeyEvent.bKeyDown));
                            Console.WriteLine(string.Format("    wRepeatCount ....:   {0,4:0}  ", record.KeyEvent.wRepeatCount));
                            Console.WriteLine(string.Format("    wVirtualKeyCode .:   {0,4:0}  ", record.KeyEvent.wVirtualKeyCode));
                            Console.WriteLine(string.Format("    uChar ...........:      {0}  ", record.KeyEvent.UnicodeChar));
                            Console.WriteLine(string.Format("    dwControlKeyState: 0x{0:X4}  ", record.KeyEvent.dwControlKeyState));

                            if (record.KeyEvent.wVirtualKeyCode == (int)ConsoleKey.Escape) { return; }
                        }
                        break;
                }

                if (record.KeyEvent.wVirtualKeyCode != 0 && record.EventType == NativeMethods.KEY_EVENT)
                {
                    KeyPressed((ConsoleKey)record.KeyEvent.wVirtualKeyCode);
                }

                CheckInput();
                Render();

                // Left mouse button press
                if (record.MouseEvent.dwButtonState == 0 || record.MouseEvent.dwButtonState == 1)
                {
                    LastLeftMouseButtonPressed = record.MouseEvent.dwButtonState;
                }
                else
                {
                    LastLeftMouseButtonPressed = 0;
                }
            }
        }

        private void Render()
        {
            try
            {
                if (AllControls.Count > 0)
                {
                    foreach (Control control in AllControls)
                    {
                        if (control is TextBlock)
                        {
                            if (control.ValueChanged)
                            {
                                Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height));
                                control.ValueChanged = false;
                            }
                            control.Width = control.Content.Length;
                            control.ValueChanged = false;
                            Renderer.DrawText(control.X, control.Y, control.Content, control.ForegroundColor);
                        }
                        else if (control is Button)
                        {
                            control.Height = control.Content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length + (control.Padding != null ? control.Padding.Top + control.Padding.Bottom : 0) + 1;
                            if (control.Hovered) SetForeColor(ConsoleColor.Gray);
                            if (control.Pressed) SetForeColor(ConsoleColor.DarkGray);
                            Renderer.DrawBox(control.X, control.Y, control.Padding != null ? control.Padding : new Thickness(), control.Content, control.Pressed);
                            SetForeColor(ConsoleColor.White);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void CheckInput()
        {
            try
            {
                if (AllControls.Count > 0)
                {
                    foreach (Control control in AllControls)
                    {
                        if (control is TextBlock)
                        {

                        }
                        else if (control is Button)
                        {
                            if (
                                record.MouseEvent.dwButtonState != LastLeftMouseButtonPressed &&
                                record.MouseEvent.dwButtonState == 0 &&
                                record.MouseEvent.dwMousePosition.X >= control.X &&
                                record.MouseEvent.dwMousePosition.X <= control.X + control.Width &&
                                record.MouseEvent.dwMousePosition.Y >= control.Y &&
                                record.MouseEvent.dwMousePosition.Y <= control.Y + control.Height
                                )
                            {
                                ((Button)control)._OnClick();
                            }

                            if (
                                record.MouseEvent.dwButtonState > 0 &&
                                record.MouseEvent.dwMousePosition.X >= control.X &&
                                record.MouseEvent.dwMousePosition.X <= control.X + control.Width &&
                                record.MouseEvent.dwMousePosition.Y >= control.Y &&
                                record.MouseEvent.dwMousePosition.Y <= control.Y + control.Height
                                )
                            {
                                if (!control.Pressed)
                                {
                                    ((Button)control)._MousePressed();
                                    control.Pressed = true;
                                }
                            }
                            else
                            {
                                if (control.Pressed)
                                {
                                    ((Button)control)._MouseReleased();
                                    control.Pressed = false;
                                }
                            }

                            if (
                                record.MouseEvent.dwMousePosition.X >= control.X &&
                                record.MouseEvent.dwMousePosition.X <= control.X + control.Width &&
                                record.MouseEvent.dwMousePosition.Y >= control.Y &&
                                record.MouseEvent.dwMousePosition.Y <= control.Y + control.Height
                                )
                            {
                                if (!control.Hovered)
                                {
                                    ((Button)control)._MouseEnter();
                                    control.Hovered = true;
                                }
                            }
                            else
                            {
                                if (control.Hovered)
                                {
                                    ((Button)control)._MouseLeave();
                                    control.Hovered = false;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void SetForeColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        private void SetBackColor(ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
        }

        protected abstract void KeyPressed(ConsoleKey consoleKey);

        private class NativeMethods
        {

            public const Int32 STD_INPUT_HANDLE = -10;

            public const Int32 ENABLE_MOUSE_INPUT = 0x0010;
            public const Int32 ENABLE_QUICK_EDIT_MODE = 0x0040;
            public const Int32 ENABLE_EXTENDED_FLAGS = 0x0080;

            public const Int32 KEY_EVENT = 1;
            public const Int32 MOUSE_EVENT = 2;


            [DebuggerDisplay("EventType: {EventType}")]
            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT_RECORD
            {
                [FieldOffset(0)]
                public Int16 EventType;
                [FieldOffset(4)]
                public KEY_EVENT_RECORD KeyEvent;
                [FieldOffset(4)]
                public MOUSE_EVENT_RECORD MouseEvent;
            }

            [DebuggerDisplay("{dwMousePosition.X}, {dwMousePosition.Y}")]
            public struct MOUSE_EVENT_RECORD
            {
                public COORD dwMousePosition;
                public Int32 dwButtonState;
                public Int32 dwControlKeyState;
                public Int32 dwEventFlags;
            }

            [DebuggerDisplay("{X}, {Y}")]
            public struct COORD
            {
                public UInt16 X;
                public UInt16 Y;
            }

            [DebuggerDisplay("KeyCode: {wVirtualKeyCode}")]
            [StructLayout(LayoutKind.Explicit)]
            public struct KEY_EVENT_RECORD
            {
                [FieldOffset(0)]
                [MarshalAsAttribute(UnmanagedType.Bool)]
                public Boolean bKeyDown;
                [FieldOffset(4)]
                public UInt16 wRepeatCount;
                [FieldOffset(6)]
                public UInt16 wVirtualKeyCode;
                [FieldOffset(8)]
                public UInt16 wVirtualScanCode;
                [FieldOffset(10)]
                public Char UnicodeChar;
                [FieldOffset(10)]
                public Byte AsciiChar;
                [FieldOffset(12)]
                public Int32 dwControlKeyState;
            };


            public class ConsoleHandle : SafeHandleMinusOneIsInvalid
            {
                public ConsoleHandle() : base(false) { }

                protected override bool ReleaseHandle()
                {
                    return true; //releasing console handle is not our business
                }
            }


            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean GetConsoleMode(ConsoleHandle hConsoleHandle, ref Int32 lpMode);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            public static extern ConsoleHandle GetStdHandle(Int32 nStdHandle);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean ReadConsoleInput(ConsoleHandle hConsoleInput, ref INPUT_RECORD lpBuffer, UInt32 nLength, ref UInt32 lpNumberOfEventsRead);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean SetConsoleMode(ConsoleHandle hConsoleHandle, Int32 dwMode);

        }
    }
}