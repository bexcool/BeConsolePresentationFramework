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
using static BeConsolePresentationFramework.Utilities.Utilities;
using BeConsolePresentationFramework.Interface;

namespace BeConsolePresentationFramework
{
    public abstract class ConsolePresentation
    {
        // All controls
        static List<Control> AllControls = new List<Control>();

        // Multithreading
        Thread InputThread, CoreThread;

        // Input
        private NativeMethods.INPUT_RECORD record;
        private Control _Focused;
        internal Control? Focused
        {
            get { return _Focused; }
            set
            {
                _Focused = value;
                FocusChanged();
            }
        }

        // Customization
        private ConsoleColor _AccentColor = ConsoleColor.Blue;
        public ConsoleColor AccentColor
        {
            get { return _AccentColor; }
            set
            {
                _AccentColor = value;
                // Add event "AccentColorChanged"
            }
        }

        // Time
        int DeltaTime = 0, LastTime;
        public float FPS { get; set; }

        // Basic values
        int MouseButtonPressed = 0;
        bool ExitRequest = false, RefreshingRender = false, KeyboardKeyPressed = false, HasFocusChanged = false;
        public bool ShowDebug = false;
        ConsoleKey LastKeyPressed;

        public ConsolePresentation()
        {

        }

        protected void InitializeApplication()
        {
            InitializeConsole();

            if (Loaded != null) Loaded(this, EventArgs.Empty);

            InputThread = new Thread(InputThreadLoop);
            InputThread.IsBackground = true;
            InputThread.Start();

            CoreThread = new Thread(CoreThreadLoop);
            CoreThread.IsBackground = false;
            CoreThread.Start();
        }

        private void InitializeConsole()
        {
            Console.Title = "New BeConsole Window";
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            ConsoleExtension.DisableEdit();
            Console.CursorVisible = false;
            SetForeColor(ConsoleColor.White);
        }

        public static void AddControl(Control control)
        {
            AllControls.Add(control);
        }
        public static void RemoveControl(Control control)
        {
            AllControls.Remove(control);
        }

        private void InputThreadLoop()
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

                if (!RefreshingRender)
                {
                    // Check text box input
                    if (record.KeyEvent.wVirtualKeyCode != 0 && record.EventType == NativeMethods.KEY_EVENT && (LastKeyPressed != (ConsoleKey)record.KeyEvent.wVirtualKeyCode || !KeyboardKeyPressed))
                    {
                        LastKeyPressed = (ConsoleKey)record.KeyEvent.wVirtualKeyCode;
                        KeyboardKeyPressed = true;
                        CheckTextBoxInput();
                    }
                    else if (!record.KeyEvent.bKeyDown && record.EventType == NativeMethods.KEY_EVENT)
                    {
                        KeyboardKeyPressed = false;
                    }
                    
                    CheckInput();

                    // Left mouse button press
                    if (record.MouseEvent.dwButtonState == 0 || record.MouseEvent.dwButtonState == 1)
                    {
                        MouseButtonPressed = record.MouseEvent.dwButtonState;
                    }
                    else
                    {
                        MouseButtonPressed = 0;
                    }
                }

            }
        }

        private void CoreThreadLoop()
        {
            while (!ExitRequest)
            {
                Render();
            }
        }

        private void FocusChanged()
        {
            if (Focused != null)
            {
                Focused._Focused();
            }
        }

        private void CheckTextBoxInput()
        {
            if (Focused is TextBox)
            {
                int _Width = Focused.Width - 2 + Focused.Padding.Left + Focused.Padding.Right;
                int _Height = Focused.Height - 2 + Focused.Padding.Top + Focused.Padding.Bottom;

                if ((_Width > Focused.Content.Length + 1 && record.KeyEvent.wVirtualKeyCode != (int)ConsoleKey.Backspace) || (record.KeyEvent.wVirtualKeyCode == (int)ConsoleKey.Backspace && Focused.Content.Length != 0))
                {
                    if (record.KeyEvent.wVirtualKeyCode == (int)ConsoleKey.Backspace)
                    {
                        Focused.Content =  Focused.Content.Remove(Focused.Content.ToCharArray().Length - 1);
                    }
                    else if (record.KeyEvent.wVirtualKeyCode == 17 && record.KeyEvent.UnicodeChar == 'v')
                    {
                        Focused.Content += Clipboard.GetText();
                    }
                    else if ((record.KeyEvent.wVirtualKeyCode < 16 || record.KeyEvent.wVirtualKeyCode > 18) && record.KeyEvent.wVirtualKeyCode != 13)
                    {
                        Focused.Content += record.KeyEvent.UnicodeChar;
                    }

                    Focused.ValueChanged = true;
                }
            }
        }

        public void Exit()
        {
            AllControls.Clear();
            Console.Clear();
            ConsoleExtension.EnableEdit();
            Console.CursorVisible = true;
            SetForeColor(ConsoleColor.Green);
            Console.WriteLine("Successfully exited application.");
            SetForeColor(ConsoleColor.Gray);
            ExitRequest = true;
        }

        private void Render()
        {
            try
            {
                if (BeforeRender != null) BeforeRender(this, EventArgs.Empty);

                LastTime = DateTime.Now.Millisecond;

                if (ShowDebug)
                {
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
                }
                
                if (AllControls.Count > 0)
                {
                    foreach (Control control in AllControls)
                    {
                        control.ChangingByCore = true;

                        // Check parents
                        if (AllControls.Contains(control.Parent))
                        {
                            if (control.Parent is StackPanel)
                            {
                                var StackPanel = control.Parent as StackPanel;

                                if (!StackPanel.Children.Contains(control) && StackPanel.RemoveChildrenOnClear)
                                {
                                    StackPanel.RenderChildren();
                                    Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height));
                                    RemoveControl(control);
                                    continue;
                                }
                            }
                        }

                        // Rendering and calculating
                        if (control.Visibility == Visibility.Visible)
                        {
                            if (control is TextBlock)
                            {
                                if (control.RemoveRequest) { Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

                                if (control.ValueChanged)
                                {
                                    Renderer.DrawBlank(new Rectangle(control.Old.X, control.Old.Y, control.Old.Width, control.Old.Height));
                                    control.ValueChanged = false;
                                }

                                control.Width = control.Content.GetLongestLineLength();
                                control.Height = control.Content.GetNumberOfLines();
                                Renderer.DrawText(control.X, control.Y, control.Content, control.ForegroundColor);
                            }
                            else if (control is Button)
                            {
                                if (control.RemoveRequest) { Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

                                if (control.ValueChanged)
                                {
                                    Renderer.DrawBlank(new Rectangle(control.Old.X, control.Old.Y, control.Old.Width, control.Old.Height));
                                    control.ValueChanged = false;
                                }

                                if (control.Hovered) SetForeColor(ConsoleColor.Gray);
                                if (control.Pressed) SetForeColor(ConsoleColor.DarkGray);
                                Renderer.DrawBox(control.X, control.Y, control.Width, control.Height, control.Content, control.Padding, control.Line, control.ContentHorizontalAlignment, control.ContentVerticalAlignment);
                                SetForeColor(ConsoleColor.White);
                            }
                            else if (control is Border)
                            {
                                if (control.RemoveRequest) { Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

                                if (control.ValueChanged)
                                {
                                    Renderer.DrawBlank(new Rectangle(control.Old.X, control.Old.Y, control.Old.Width, control.Old.Height));
                                    control.ValueChanged = false;
                                }

                                Renderer.DrawBox(control.X, control.Y, control.Width, control.Height, control.Content, control.Padding, control.Line, control.ContentHorizontalAlignment, control.ContentVerticalAlignment);
                                SetForeColor(ConsoleColor.White);
                            }
                            else if (control is TextBox)
                            {
                                if (control != Focused)
                                {
                                    if (control.RemoveRequest) { Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

                                    if (control.ValueChanged)
                                    {
                                        Renderer.DrawBlank(new Rectangle(control.Old.X, control.Old.Y, control.Old.Width, control.Old.Height));
                                        control.ValueChanged = false;
                                    }

                                    Renderer.DrawBox(control.X, control.Y, control.Width, control.Height, control.Content, control.Padding, control.Line, control.ContentHorizontalAlignment, control.ContentVerticalAlignment);
                                    SetForeColor(ConsoleColor.White);
                                }
                                else
                                {
                                    if (control.RemoveRequest) { Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

                                    int _Width = Focused.Width - 2 + Focused.Padding.Left + Focused.Padding.Right;
                                    int _Height = Focused.Height - 2 + Focused.Padding.Top + Focused.Padding.Bottom;

                                    int ContentX = Focused.X + ((_Width / 2) - Focused.Content.GetLongestLineLength() / 2) + 1 - Focused.Padding.Right + Focused.Padding.Left;
                                    int ContentY = Focused.Y + ((_Height / 2) - Focused.Content.GetNumberOfLines() / 2) + 1 + Focused.Padding.Top - Focused.Padding.Bottom;

                                    switch (Focused.ContentHorizontalAlignment)
                                    {
                                        case HorizontalAlignment.Left:
                                            {
                                                ContentX = 1 - Focused.Padding.Right + Focused.Padding.Left;

                                                break;
                                            }

                                        case HorizontalAlignment.Right:
                                            {
                                                ContentX = Focused.Width - Focused.Content.GetLongestLineLength() - 1 - Focused.Padding.Right + Focused.Padding.Left;

                                                break;
                                            }

                                        case HorizontalAlignment.Center:
                                            {
                                                ContentX = ((_Width / 2) - Focused.Content.GetLongestLineLength() / 2) + 1 - Focused.Padding.Right + Focused.Padding.Left;

                                                break;
                                            }

                                        case HorizontalAlignment.Stretch:
                                            {
                                                ContentX = ((_Width / 2) - Focused.Content.GetLongestLineLength() / 2) + 1 - Focused.Padding.Right + Focused.Padding.Left;

                                                break;
                                            }
                                    }
                                    ContentX += Focused.X;

                                    Console.SetCursorPosition(ContentX, ContentY);
                                    Console.Write(Focused.Content);
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    Console.Write("█");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    if (Focused != null && _Width - Focused.Content.Length - 1 >= 0) Console.Write(new string(' ', _Width - Focused.Content.Length - 1));
                                    Renderer.DrawBox(control.X, control.Y, control.Width, control.Height, control.Content, control.Padding, control.Line, control.ContentHorizontalAlignment, control.ContentVerticalAlignment, AccentColor);
                                }
                            }
                            else if (control is StackPanel)
                            {
                                if (control.RemoveRequest) { Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }
                                
                                var StackPanel = control as StackPanel;

                                if (control.ValueChanged)
                                {
                                    StackPanel.RenderChildren();
                                    control.ValueChanged = false;
                                }
                                else
                                {
                                    if (StackPanel.LastChildrenCount != StackPanel.Children.Count)
                                    {
                                        StackPanel.RenderChildren();
                                    }
                                }

                                StackPanel.LastChildrenCount = StackPanel.Children.Count;
                            }
                        }
                        else
                        {
                            if (control is StackPanel)
                            {
                                if (control.RemoveRequest) { Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

                                var StackPanel = control as StackPanel;

                                if (control.ValueChanged)
                                {
                                    StackPanel.RenderChildren();
                                    control.ValueChanged = false;
                                }
                                else
                                {
                                    if (StackPanel.LastChildrenCount != StackPanel.Children.Count)
                                    {
                                        StackPanel.RenderChildren();
                                    }
                                }

                                StackPanel.LastChildrenCount = StackPanel.Children.Count;
                            }
                            else
                            {
                                if (!control.BlankApplied && control is Border)
                                {
                                    Renderer.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height));
                                    control.ValueChanged = false;
                                    control.BlankApplied = true;
                                }
                            }
                        }

                        control.ChangingByCore = false;
                    }
                }

                if (AfterRender != null) AfterRender(this, EventArgs.Empty);

                // Time calculations
                DeltaTime = DateTime.Now.Millisecond - LastTime;
                FPS = (float)1 / DeltaTime * 1000;
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void CheckInput()
        {
            try
            {
                if (AllControls.Count > 0)
                {
                    HasFocusChanged = false;

                    foreach (Control control in AllControls)
                    {
                        if (control.Visibility != Visibility.Collapsed)
                        {
                            Thickness Padding = control.Padding;

                            if (
                                record.MouseEvent.dwButtonState != MouseButtonPressed &&
                                record.MouseEvent.dwButtonState == 0 &&
                                record.MouseEvent.dwMousePosition.X >= control.X &&
                                record.MouseEvent.dwMousePosition.X <= control.X + control.Width + control.Padding.LeftRight - 1 &&
                                record.MouseEvent.dwMousePosition.Y >= control.Y &&
                                record.MouseEvent.dwMousePosition.Y <= control.Y + control.Height + control.Padding.TopBottom - 1
                                )
                            {
                                if (control is not StackPanel)
                                {
                                    if (Focused != null)
                                    {
                                        Focused.Old = new Rectangle(Focused.X, Focused.Y, Focused.CalculateActualWidth(), Focused.CalculateActualHeight());
                                        Focused.ValueChanged = true;
                                    }

                                    HasFocusChanged = true;
                                    Focused = control;
                                }
                                control._OnClick();
                            }

                            if (
                                record.MouseEvent.dwButtonState > 0 &&
                                record.MouseEvent.dwMousePosition.X >= control.X &&
                                record.MouseEvent.dwMousePosition.X <= control.X + control.Width + control.Padding.LeftRight - 1 &&
                                record.MouseEvent.dwMousePosition.Y >= control.Y &&
                                record.MouseEvent.dwMousePosition.Y <= control.Y + control.Height + control.Padding.TopBottom - 1
                                )
                            {
                                if (!control.Pressed)
                                {
                                    control.Pressed = true;
                                    control._MousePressed();
                                }
                            }
                            else
                            {
                                if (control.Pressed)
                                {
                                    control.Pressed = false;
                                    control._MouseReleased();
                                }
                            }

                            if (
                                record.MouseEvent.dwMousePosition.X >= control.X &&
                                record.MouseEvent.dwMousePosition.X <= control.X + control.Width + control.Padding.LeftRight - 1 &&
                                record.MouseEvent.dwMousePosition.Y >= control.Y &&
                                record.MouseEvent.dwMousePosition.Y <= control.Y + control.Height + control.Padding.TopBottom - 1
                                )
                            {
                                if (!control.Hovered)
                                {
                                    control.Hovered = true;
                                    control._MouseEnter();
                                }
                            }
                            else
                            {
                                if (control.Hovered)
                                {
                                    control.Hovered = false;
                                    control._MouseLeave();
                                }
                            }

                            if (control is TextBlock)
                            {

                            }
                            else if (control is Button)
                            {

                            }
                            else if (control is TextBox)
                            {

                            }
                        }
                    }
                    
                    if (!HasFocusChanged && record.MouseEvent.dwButtonState != MouseButtonPressed && record.MouseEvent.dwButtonState == 0 && Focused != null)
                    {
                        Focused.Old = new Rectangle(Focused.X, Focused.Y, Focused.CalculateActualWidth(), Focused.CalculateActualHeight());
                        Focused.ValueChanged = true;
                        Focused = null;
                    }
                }
            }
            catch
            {

            }
        }

        private static void SetForeColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        private static void SetBackColor(ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
        }

        #region DLL IMPORTS

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        #endregion

        #region CONSTANTS

        public const uint KEYEVENTF_KEYUP = 0x0002;
        public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;

        #endregion

        #region Event handlers
        // Before render handler
        public delegate void BeforeRenderHandler(object sender, EventArgs e);
        public event BeforeRenderHandler BeforeRender;
        // Before render handler
        public delegate void AfterRenderHandler(object sender, EventArgs e);
        public event AfterRenderHandler AfterRender;
        // Loaded handler
        public delegate void LoadedHandler(object sender, EventArgs e);
        public event LoadedHandler Loaded;
        #endregion

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