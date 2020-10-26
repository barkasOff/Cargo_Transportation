using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Cargo_Transportation.ViewModels
{
    public class WindowResizability
    {
        private readonly Window                     _window;
        private Rect                                _screenSize = new Rect();
        private readonly int                        _edgeTolerance = 2;
        private Matrix                              _transformToDevice;
        private IntPtr                              _lastScreen;
        private WindowDockPosition                  _lastDock = WindowDockPosition.Undocked;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool                          GetCursorPos(out POINT lpPoint);
        [DllImport("user32.dll")]
        static extern bool                          GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr                        MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

        public event Action<WindowDockPosition>     WindowDockChanged = (dock) => { };

        public Rectangle                            CurrentMonitorSize { get; set; } = new Rectangle();

        public WindowResizability(Window window)
        {
            _window = window;
            GetTransform();
            _window.SourceInitialized += Window_SourceInitialized;
            _window.SizeChanged += Window_SizeChanged;
        }

        private void                                GetTransform()
        {
            var source = PresentationSource.FromVisual(_window);
            _transformToDevice = default;
            if (source == null)
                return;
            _transformToDevice = source.CompositionTarget.TransformToDevice;
        }
        private void                                Window_SourceInitialized(object sender, System.EventArgs e)
        {
            var handle = (new WindowInteropHelper(_window)).Handle;
            var handleSource = HwndSource.FromHwnd(handle);

            if (handleSource == null)
                return;
            handleSource.AddHook(WindowProc);
        }

        private void                                Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_transformToDevice == default)
                return;
            var size = e.NewSize;
            var top = _window.Top;
            var left = _window.Left;
            var bottom = top + size.Height;
            var right = left + _window.Width;
            var windowTopLeft = _transformToDevice.Transform(new Point(left, top));
            var windowBottomRight = _transformToDevice.Transform(new Point(right, bottom));
            var edgedTop = windowTopLeft.Y <= (_screenSize.Top + _edgeTolerance);
            var edgedLeft = windowTopLeft.X <= (_screenSize.Left + _edgeTolerance);
            var edgedBottom = windowBottomRight.Y >= (_screenSize.Bottom - _edgeTolerance);
            var edgedRight = windowBottomRight.X >= (_screenSize.Right - _edgeTolerance);
            WindowDockPosition dock;
            if (edgedTop && edgedBottom && edgedLeft)
                dock = WindowDockPosition.Left;
            else if (edgedTop && edgedBottom && edgedRight)
                dock = WindowDockPosition.Right;
            else
                dock = WindowDockPosition.Undocked;
            if (dock != _lastDock)
                WindowDockChanged(dock);
            _lastDock = dock;
        }

        private IntPtr                              WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(lParam);
                    handled = true;
                    break;
            }
            return (IntPtr)0;
        }
        private void                                WmGetMinMaxInfo(IntPtr lParam)
        {
            GetCursorPos(out POINT lMousePosition);
            var lPrimaryScreen = MonitorFromPoint(new POINT(0, 0), MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
            var lPrimaryScreenInfo = new MONITORINFO();

            if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
                return;
            var lCurrentScreen = MonitorFromPoint(lMousePosition, MonitorOptions.MONITOR_DEFAULTTONEAREST);

            if (lCurrentScreen != _lastScreen || _transformToDevice == default)
                GetTransform();
            _lastScreen = lCurrentScreen;
            var lMmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            if (lPrimaryScreen.Equals(lCurrentScreen) == true)
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcBIN.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcBIN.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcBIN.Right - lPrimaryScreenInfo.rcBIN.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcBIN.Bottom - lPrimaryScreenInfo.rcBIN.Top;
            }
            else
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcMonitor.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcMonitor.Right - lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcMonitor.Bottom - lPrimaryScreenInfo.rcMonitor.Top;
            }
            CurrentMonitorSize = new Rectangle(lMmi.ptMaxPosition.X, lMmi.ptMaxPosition.Y, lMmi.ptMaxSize.X + lMmi.ptMaxPosition.X, lMmi.ptMaxSize.Y + lMmi.ptMaxPosition.Y);
            var minSize = _transformToDevice.Transform(new Point(_window.MinWidth, _window.MinHeight));

            lMmi.ptMinTrackSize.X = (int)minSize.X;
            lMmi.ptMinTrackSize.Y = (int)minSize.Y;
            _screenSize = new Rect(lMmi.ptMaxPosition.X, lMmi.ptMaxPosition.Y, lMmi.ptMaxSize.X, lMmi.ptMaxSize.Y);
            Marshal.StructureToPtr(lMmi, lParam, true);
        }
    }

    enum                                            MonitorOptions : uint
    {
        MONITOR_DEFAULTTONULL = 0x00000000,
        MONITOR_DEFAULTTOPRIMARY = 0x00000001,
        MONITOR_DEFAULTTONEAREST = 0x00000002
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class                                    MONITORINFO
    {
        public int                                  cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        public Rectangle                            rcMonitor = new Rectangle();
        public Rectangle                            rcBIN = new Rectangle();
        public int                                  dwFlags = 0;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct                                   Rectangle
    {
        public int Left, Top, Right, Bottom;

        public Rectangle(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct                                   MINMAXINFO
    {
        public POINT                                ptReserved;
        public POINT                                ptMaxSize;
        public POINT                                ptMaxPosition;
        public POINT                                ptMinTrackSize;
        public POINT                                ptMaxTrackSize;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct                                   POINT
    {
        public int                                  X;
        public int                                  Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
