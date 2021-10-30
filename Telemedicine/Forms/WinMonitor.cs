using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    /// <summary>
    /// 螢幕資訊
    /// </summary>
    public struct WinMonitor
    {
        private static readonly Dictionary<DisplayStandard, DisplayResolution> _resolutions;
        private const float DefaultPixels = 96f;
        static WinMonitor()
        {
            _resolutions = new DisplayResolution[]
            {
                new DisplayResolution(DisplayStandard.VGA, 640, 480),
                new DisplayResolution(DisplayStandard.SVGA, 800, 600),
                new DisplayResolution(DisplayStandard.XGA, 1024, 768),
                new DisplayResolution(DisplayStandard.HD, 1280, 720),
                new DisplayResolution(DisplayStandard.WXGA, 1280, 1024),
                new DisplayResolution(DisplayStandard.WSXGA, 1440, 900),
                new DisplayResolution(DisplayStandard.HDp, 1600, 900),
                new DisplayResolution(DisplayStandard.UXGA, 1600, 1200),
                new DisplayResolution(DisplayStandard.FHD, 1920, 1080),
                new DisplayResolution(DisplayStandard.QHD, 2560, 1440),
                new DisplayResolution(DisplayStandard.UHD, 3840, 2160),
            }.ToDictionary(r => r.Standard);
        }
        private string _name;
        private string _adapter;
        private int _w;
        private int _h;
        private int _dW;
        private int _dH;
        private float _lx;
        private float _ly;
        private float _scaleDevice;
        private float _scalePixels;
        private bool _pFlag;
        private IntPtr _hMonitor;
        private DisplayStandard _std;
        private DisplayStandard _dstd;
        public WinMonitor(string name, string adapter, int w, int h, int dw, int dh, float lx, float ly, bool pFlag)
        {
            _name = name;
            _adapter = adapter;
            _w = w;
            _h = h;
            _dW = dw;
            _dH = dh;
            _lx = lx;
            _ly = ly;
            _scaleDevice = (float)dw / w;
            _scalePixels = lx / DefaultPixels;
            _pFlag = pFlag;
            _hMonitor = IntPtr.Zero;
            _std = GetDisplayStandard(new Size(w, h));
            _dstd = GetDisplayStandard(new Size(dw, dh));
        }

        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// 寬
        /// </summary>
        public int Width
        {
            get { return _w; }
        }
        /// <summary>
        /// 高
        /// </summary>
        public int Height
        {
            get { return _h; }
        }
        /// <summary>
        /// 實體寬
        /// </summary>
        public int DeviceWidth
        {
            get { return _dW; }
        }
        /// <summary>
        /// 實體高
        /// </summary>
        public int DeviceHeight
        {
            get { return _dH; }
        }
        public float PixelX
        {
            get { return _lx; }
        }
        public float PixelY
        {
            get { return _ly; }
        }
        /// <summary>
        /// 縮放大小
        /// </summary>
        public float ResolutionScale
        {
            get
            {
                if (_scalePixels != 1)
                    return _scalePixels;
                else if (_scaleDevice != 1)
                    return _scaleDevice;
                else
                    return 1;
            }
        }
        /// <summary>
        /// 介面
        /// </summary>
        public string Adapter
        {
            get { return _adapter; }
        }
        public bool IsPrimary
        {
            get { return _pFlag; }
        }
        public IntPtr Handle
        {
            get { return _hMonitor; }
            set { _hMonitor = value; }
        }
        public DisplayStandard DisplayStd
        {
            get { return _std; }
        }
        public DisplayStandard DeviceStd
        {
            get { return _dstd; }
        }

        public static WinMonitor GetPrimary()
        {
            return GetAll().First(r => r.IsPrimary);
        }
        public static int GetPrimaryScaled(int value)
        {
            return (int)(GetPrimary().ResolutionScale * value);
        }
        public static float GetPrimaryScaled(float value)
        {
            return GetPrimary().ResolutionScale * value;
        }
        public static IEnumerable<WinMonitor> GetAll()
        {
            var hMonitors = new Dictionary<string, IntPtr>();
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
            {
                var mi = new MonitorInfoEx();
                mi.Size = Marshal.SizeOf(mi);
                if (GetMonitorInfo(hMonitor, ref mi))
                    hMonitors.Add(mi.DeviceName, hMonitor);
                return true;
            }, IntPtr.Zero);



            var d = new DISPLAY_DEVICE();
            d.cb = Marshal.SizeOf(d);
            for (uint i = 0; EnumDisplayDevices(null, i, ref d, 1); i++)
            {
                d.cb = Marshal.SizeOf(d);
                if (d.StateFlags != 0x0)
                {
                    var name = d.DeviceName;

                    // HDC
                    var hdc = CreateDC(name, null, null, IntPtr.Zero);
                    var w = GetDeviceCaps(hdc, (int)DeviceCap.HORZRES);
                    var h = GetDeviceCaps(hdc, (int)DeviceCap.VERTRES);
                    var dw = GetDeviceCaps(hdc, (int)DeviceCap.DESKTOPHORZRES);
                    var dh = GetDeviceCaps(hdc, (int)DeviceCap.DESKTOPVERTRES);
                    var lx = GetDeviceCaps(hdc, (int)DeviceCap.LOGPIXELSX);
                    var ly = GetDeviceCaps(hdc, (int)DeviceCap.LOGPIXELSY);
                    ReleaseDC(IntPtr.Zero, hdc);

                    var p = d.StateFlags.HasFlag(DisplayDeviceStateFlags.PrimaryDevice);
                    var monitor = new WinMonitor(name, d.DeviceString, w, h, dw, dh, lx, ly, p);
                    IntPtr handle;
                    if (hMonitors.TryGetValue(name, out handle))
                        monitor.Handle = handle;
                    yield return monitor;
                }
            }
        }

        public static Size GetDefinedSize(DisplayStandard std)
        {
            if (std == DisplayStandard.Unknown)
                return Size.Empty;
            var resolution = _resolutions[std];
            return new Size(resolution.Width, resolution.Height);
        }

        public static DisplayStandard GetDisplayStandard(Size size)
        {
            var stds = _resolutions.Keys.Reverse();
            foreach (var std in stds)
            {
                var resolution = _resolutions[std];
                if (size.Width >= resolution.Width && size.Height >= resolution.Height)
                    return std;
            }
            return DisplayStandard.Unknown;
        }

        public static DisplayStandard Larger(DisplayStandard std)
        {
            if (std == DisplayStandard.UHD)
                return DisplayStandard.Unknown;
            return std + 1;
        }
        public static DisplayStandard Smaller(DisplayStandard std)
        {
            if (std == DisplayStandard.Unknown)
                return DisplayStandard.Unknown;
            return std - 1;
        }

        public enum DisplayStandard : uint
        {
            Unknown = 0,
            /// <summary>640,480</summary>
            VGA = 1,
            /// <summary>800,600</summary>
            SVGA = 2,
            /// <summary>1024,768</summary>
            XGA = 3,
            /// <summary>1280,720</summary>
            HD = 4,
            /// <summary>1280,1024</summary>
            WXGA = 5,
            /// <summary>1440,900</summary>
            WSXGA = 6,
            /// <summary>1600,900</summary>
            HDp = 7,
            /// <summary>1600,1200</summary>
            UXGA = 8,
            /// <summary>1920,1080</summary>
            FHD = 9,
            /// <summary>2560,1440</summary>
            QHD = 10,
            /// <summary>3840,2160</summary>
            UHD = 11,
        }

        private class DisplayResolution
        {
            public DisplayResolution(DisplayStandard standard, int width, int height)
            {
                Standard = standard;
                Width = width;
                Height = height;
            }
            public DisplayStandard Standard { get; private set; }
            public int Width { get; private set; }
            public int Height { get; private set; }
        }

        #region Native WinAPI
        delegate bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr MonitorFromPoint([In] Point pt, [In] uint dwFlags);
        [DllImport("user32.dll")]
        static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);
        [DllImport("user32.dll")]
        static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumProc lpfnEnum, IntPtr dwData);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool GetMonitorInfo(IntPtr hMonitor, ref MonitorInfoEx lpmi);
        [StructLayout(LayoutKind.Sequential)]
        struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DISPLAY_DEVICE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceString;
            [MarshalAs(UnmanagedType.U4)]
            public DisplayDeviceStateFlags StateFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceKey;
        }
        [Flags()]
        public enum DisplayDeviceStateFlags : int
        {
            /// <summary>The device is part of the desktop.</summary>
            AttachedToDesktop = 0x1,
            MultiDriver = 0x2,
            /// <summary>The device is part of the desktop.</summary>
            PrimaryDevice = 0x4,
            /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
            MirroringDriver = 0x8,
            /// <summary>The device is VGA compatible.</summary>
            VGACompatible = 0x10,
            /// <summary>The device is removable; it cannot be the primary display.</summary>
            Removable = 0x20,
            /// <summary>The device has more display modes than its output devices support.</summary>
            ModesPruned = 0x8000000,
            Remote = 0x4000000,
            Disconnect = 0x2000000
        }
        public enum DeviceCap
        {
            /// <summary>
            /// Device driver version
            /// </summary>
            DRIVERVERSION = 0,
            /// <summary>
            /// Device classification
            /// </summary>
            TECHNOLOGY = 2,
            /// <summary>
            /// Horizontal size in millimeters
            /// </summary>
            HORZSIZE = 4,
            /// <summary>
            /// Vertical size in millimeters
            /// </summary>
            VERTSIZE = 6,
            /// <summary>
            /// Horizontal width in pixels
            /// </summary>
            HORZRES = 8,
            /// <summary>
            /// Vertical height in pixels
            /// </summary>
            VERTRES = 10,
            /// <summary>
            /// Number of bits per pixel
            /// </summary>
            BITSPIXEL = 12,
            /// <summary>
            /// Number of planes
            /// </summary>
            PLANES = 14,
            /// <summary>
            /// Number of brushes the device has
            /// </summary>
            NUMBRUSHES = 16,
            /// <summary>
            /// Number of pens the device has
            /// </summary>
            NUMPENS = 18,
            /// <summary>
            /// Number of markers the device has
            /// </summary>
            NUMMARKERS = 20,
            /// <summary>
            /// Number of fonts the device has
            /// </summary>
            NUMFONTS = 22,
            /// <summary>
            /// Number of colors the device supports
            /// </summary>
            NUMCOLORS = 24,
            /// <summary>
            /// Size required for device descriptor
            /// </summary>
            PDEVICESIZE = 26,
            /// <summary>
            /// Curve capabilities
            /// </summary>
            CURVECAPS = 28,
            /// <summary>
            /// Line capabilities
            /// </summary>
            LINECAPS = 30,
            /// <summary>
            /// Polygonal capabilities
            /// </summary>
            POLYGONALCAPS = 32,
            /// <summary>
            /// Text capabilities
            /// </summary>
            TEXTCAPS = 34,
            /// <summary>
            /// Clipping capabilities
            /// </summary>
            CLIPCAPS = 36,
            /// <summary>
            /// Bitblt capabilities
            /// </summary>
            RASTERCAPS = 38,
            /// <summary>
            /// Length of the X leg
            /// </summary>
            ASPECTX = 40,
            /// <summary>
            /// Length of the Y leg
            /// </summary>
            ASPECTY = 42,
            /// <summary>
            /// Length of the hypotenuse
            /// </summary>
            ASPECTXY = 44,
            /// <summary>
            /// Shading and Blending caps
            /// </summary>
            SHADEBLENDCAPS = 45,

            /// <summary>
            /// Logical pixels inch in X
            /// </summary>
            LOGPIXELSX = 88,
            /// <summary>
            /// Logical pixels inch in Y
            /// </summary>
            LOGPIXELSY = 90,

            /// <summary>
            /// Number of entries in physical palette
            /// </summary>
            SIZEPALETTE = 104,
            /// <summary>
            /// Number of reserved entries in palette
            /// </summary>
            NUMRESERVED = 106,
            /// <summary>
            /// Actual color resolution
            /// </summary>
            COLORRES = 108,

            // Printing related DeviceCaps. These replace the appropriate Escapes
            /// <summary>
            /// Physical Width in device units
            /// </summary>
            PHYSICALWIDTH = 110,
            /// <summary>
            /// Physical Height in device units
            /// </summary>
            PHYSICALHEIGHT = 111,
            /// <summary>
            /// Physical Printable Area x margin
            /// </summary>
            PHYSICALOFFSETX = 112,
            /// <summary>
            /// Physical Printable Area y margin
            /// </summary>
            PHYSICALOFFSETY = 113,
            /// <summary>
            /// Scaling factor x
            /// </summary>
            SCALINGFACTORX = 114,
            /// <summary>
            /// Scaling factor y
            /// </summary>
            SCALINGFACTORY = 115,

            /// <summary>
            /// Current vertical refresh rate of the display device (for displays only) in Hz
            /// </summary>
            VREFRESH = 116,
            /// <summary>
            /// Vertical height of entire desktop in pixels
            /// </summary>
            DESKTOPVERTRES = 117,
            /// <summary>
            /// Horizontal width of entire desktop in pixels
            /// </summary>
            DESKTOPHORZRES = 118,
            /// <summary>
            /// Preferred blt alignment
            /// </summary>
            BLTALIGNMENT = 119
        }
        // size of a device name string
        private const int CCHDEVICENAME = 32;
        /// <summary>
        /// The MONITORINFOEX structure contains information about a display monitor.
        /// The GetMonitorInfo function stores information into a MONITORINFOEX structure or a MONITORINFO structure.
        /// The MONITORINFOEX structure is a superset of the MONITORINFO structure. The MONITORINFOEX structure adds a string member to contain a name
        /// for the display monitor.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct MonitorInfoEx
        {
            /// <summary>
            /// The size, in bytes, of the structure. Set this member to sizeof(MONITORINFOEX) (72) before calling the GetMonitorInfo function.
            /// Doing so lets the function determine the type of structure you are passing to it.
            /// </summary>
            public int Size;

            /// <summary>
            /// A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates.
            /// Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
            /// </summary>
            public RectStruct Monitor;

            /// <summary>
            /// A RECT structure that specifies the work area rectangle of the display monitor that can be used by applications,
            /// expressed in virtual-screen coordinates. Windows uses this rectangle to maximize an application on the monitor.
            /// The rest of the area in rcMonitor contains system windows such as the task bar and side bars.
            /// Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
            /// </summary>
            public RectStruct WorkArea;

            /// <summary>
            /// The attributes of the display monitor.
            ///
            /// This member can be the following value:
            ///   1 : MONITORINFOF_PRIMARY
            /// </summary>
            public uint Flags;

            /// <summary>
            /// A string that specifies the device name of the monitor being used. Most applications have no use for a display monitor name,
            /// and so can save some bytes by using a MONITORINFO structure.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string DeviceName;

            public void Init()
            {
                this.Size = 40 + 2 * CCHDEVICENAME;
                this.DeviceName = string.Empty;
            }
        }

        /// <summary>
        /// The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
        /// </summary>
        /// <see cref="http://msdn.microsoft.com/en-us/library/dd162897%28VS.85%29.aspx"/>
        /// <remarks>
        /// By convention, the right and bottom edges of the rectangle are normally considered exclusive.
        /// In other words, the pixel whose coordinates are ( right, bottom ) lies immediately outside of the the rectangle.
        /// For example, when RECT is passed to the FillRect function, the rectangle is filled up to, but not including,
        /// the right column and bottom row of pixels. This structure is identical to the RECTL structure.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct RectStruct
        {
            /// <summary>
            /// The x-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int Left;

            /// <summary>
            /// The y-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int Top;

            /// <summary>
            /// The x-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int Right;

            /// <summary>
            /// The y-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int Bottom;
        }
        #endregion
    }
}

