using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using BCPF.Core.Utilities;
using BCPF.Core.Rendering;
using BCPF.Core.Controls.Base;
using BCPF.Core.Controls;
using System.Drawing;
using static BCPF.Core.Utilities.Utilities;
using BCPF.Core.Interface;
using BCPF.Core.Helpers;

namespace BCPF.Core
{
    public abstract class ConsolePresentation
    {
        // All controls
        static List<Control> AllControls = new List<Control>();

        // Multithreading
        Thread InputThread, CoreThread;

        // Input
        private NativeMethods.INPUT_RECORD record;
        private static Control _focusedControl;
        public static Control? FocusedControl
        {
            get { return _focusedControl; }
            set
            {
                _focusedControl = value;
                FocusChanged();
            }
        }

        // Customization
        // Accent color
        private static ConsoleColor _AccentColor = ConsoleColor.Blue;
        public static ConsoleColor AccentColor
        {
            get { return _AccentColor; }
            set
            {
                _AccentColor = value;
                // Add event "AccentColorChanged"
            }
        }
        // Background color
        private static ConsoleColor _BackgroundColor;
        public static ConsoleColor BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                _BackgroundColor = value;
                Console.BackgroundColor = BackgroundColor;
                Console.Clear();
                // Add event "BackgroundColorChanged"
            }
        }
        // Foreground color
        private static ConsoleColor _ForegroundColor;
        public static ConsoleColor ForegroundColor
        {
            get { return _ForegroundColor; }
            set
            {
                _ForegroundColor = value;
                Console.ForegroundColor = ForegroundColor;
                // Add event "BackgroundColorChanged"
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

        private static void FocusChanged()
        {
            if (FocusedControl != null)
            {
                FocusedControl._Focused();
            }
        }

        private void CheckTextBoxInput()
        {
            if (FocusedControl is TextBox)
            {
                int _Width = FocusedControl.Width - 2 + FocusedControl.Padding.Left + FocusedControl.Padding.Right;
                int _Height = FocusedControl.Height - 2 + FocusedControl.Padding.Top + FocusedControl.Padding.Bottom;

                if ((_Width > FocusedControl.Content.Length + 1 && record.KeyEvent.wVirtualKeyCode != (int)ConsoleKey.Backspace) || (record.KeyEvent.wVirtualKeyCode == (int)ConsoleKey.Backspace && FocusedControl.Content.Length != 0))
                {
                    if (record.KeyEvent.wVirtualKeyCode == (int)ConsoleKey.Backspace)
                    {
                        FocusedControl.Content = FocusedControl.Content.Remove(FocusedControl.Content.ToCharArray().Length - 1);
                    }
                    else if (record.KeyEvent.wVirtualKeyCode == 17 && record.KeyEvent.UnicodeChar == 'v')
                    {
                        FocusedControl.Content += Clipboard.GetText().Normalize().Last();
                    }
                    else if ((record.KeyEvent.wVirtualKeyCode < 16 || record.KeyEvent.wVirtualKeyCode > 18) && record.KeyEvent.wVirtualKeyCode != 13)
                    {
                        FocusedControl.Content += record.KeyEvent.UnicodeChar;
                    }

                    FocusedControl.ValueChanged = true;
                }
            }
        }

        public void Exit()
        {
            BackgroundColor = ConsoleColor.Black;
            ExitRequest = true;
            AllControls.Clear();
            ConsoleExtension.EnableEdit();
            Console.CursorVisible = true;
            ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("Successfully exited application.");
            ForegroundColor = ConsoleColor.Gray;
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

                        // Render if visible
                        if (control.Visibility == Visibility.Visible)
                        {
                            if (control.RemoveRequest) ConsoleGraphics.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height));

                            if (control.ValueChanged)
                            {
                                ConsoleGraphics.DrawBlank(new Rectangle(control.Old.X, control.Old.Y, control.Old.Width, control.Old.Height));
                                control.ValueChanged = false;

                                control.RenderControl();

                                // Reset foreground color to default white
                                ForegroundColor = ConsoleColor.White;
                            }
                        }

                        if (control.RemoveRequest)
                        {
                            RemoveControl(control);

                            continue;
                        }

                        // Check parents
                        if (AllControls.Contains(control.Parent))
                        {
                            if (control.Parent is StackPanel)
                            {
                                var StackPanel = control.Parent as StackPanel;

                                if (!StackPanel.Children.Contains(control) && StackPanel.RemoveChildrenOnClear)
                                {
                                    StackPanel.RenderChildren();
                                    ConsoleGraphics.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height));
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
                                if (control.RemoveRequest) { ConsoleGraphics.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

                                if (control.ValueChanged)
                                {
                                    ConsoleGraphics.DrawBlank(new Rectangle(control.Old.X, control.Old.Y, control.Old.Width, control.Old.Height));
                                    control.ValueChanged = false;
                                }

                                var TextBlock = control as TextBlock;

                                if (control.Width != control.Content.GetLongestLineLength())
                                {
                                    control.Width = control.Content.GetLongestLineLength();

                                    if (control.Parent is StackPanel)
                                    {
                                        var StackPanel = control.Parent as StackPanel;
                                        StackPanel.RenderChildren();
                                    }
                                }

                                if (control.Height != control.Content.GetNumberOfLines())
                                {
                                    control.Height = control.Content.GetNumberOfLines();

                                    if (control.Parent is StackPanel)
                                    {
                                        var StackPanel = control.Parent as StackPanel;
                                        StackPanel.RenderChildren();
                                    }
                                }

                                if (TextBlock.Language == SyntaxHighlight.ProgrammingLanguage.None)
                                {
                                    ConsoleGraphics.DrawText(control.X, control.Y, control.Content, control.ForegroundColor);
                                }
                                else
                                {
                                    ConsoleGraphics.DrawText(control.X, control.Y, control.Content, TextBlock.Language);
                                }
                            }
                            else if (control is Button)
                            {
                                if (control.RemoveRequest) { ConsoleGraphics.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

                                if (control.ValueChanged)
                                {
                                    ConsoleGraphics.DrawBlank(new Rectangle(control.Old.X, control.Old.Y, control.Old.Width, control.Old.Height));
                                    control.ValueChanged = false;
                                }

                                if (control.Hovered) ForegroundColor = ConsoleColor.Gray;
                                if (control.Pressed) ForegroundColor = ConsoleColor.DarkGray;
                                ConsoleGraphics.DrawBox(control.X, control.Y, control.Width, control.Height, control.Content, control.Padding, control.BorderStyle, control.ContentHorizontalAlignment, control.ContentVerticalAlignment);
                                ForegroundColor = ConsoleColor.White;
                            }
                            else if (control is Border)
                            {
                            }
                            else if (control is TextBox)
                            {
                            }
                            else if (control is StackPanel)
                            {
                                if (control.RemoveRequest) { ConsoleGraphics.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

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
                                if (control.RemoveRequest) { ConsoleGraphics.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height)); RemoveControl(control); continue; }

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
                                    ConsoleGraphics.DrawBlank(new Rectangle(control.X, control.Y, control.Width, control.Height));
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
                                    if (FocusedControl != null)
                                    {
                                        FocusedControl.Old = new Rectangle(FocusedControl.X, FocusedControl.Y, FocusedControl.CalculateActualWidth(), FocusedControl.CalculateActualHeight());
                                        FocusedControl.ValueChanged = true;
                                    }

                                    HasFocusChanged = true;
                                    FocusedControl = control;
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

                    if (!HasFocusChanged && record.MouseEvent.dwButtonState != MouseButtonPressed && record.MouseEvent.dwButtonState == 0 && FocusedControl != null)
                    {
                        FocusedControl.Old = new Rectangle(FocusedControl.X, FocusedControl.Y, FocusedControl.CalculateActualWidth(), FocusedControl.CalculateActualHeight());
                        FocusedControl.ValueChanged = true;
                        FocusedControl = null;
                    }
                }
            }
            catch
            {

            }
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