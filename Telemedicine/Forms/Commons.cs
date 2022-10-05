using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public static class Native
    {
        #region 常數宣告
        #region WM
        public const uint WM_ACTIVATE = 0x0006;
        public const uint WM_ACTIVATEAPP = 0x001C;
        public const uint WM_AFXFIRST = 0x0360;
        public const uint WM_AFXLAST = 0x037F;
        public const uint WM_APP = 0x8000;
        public const uint WM_ASKCBFORMATNAME = 0x030C;
        public const uint WM_CANCELJOURNAL = 0x004B;
        public const uint WM_CANCELMODE = 0x001F;
        public const uint WM_CAPTURECHANGED = 0x0215;
        public const uint WM_CHANGECBCHAIN = 0x030D;
        public const uint WM_CHANGEUISTATE = 0x0127;
        public const uint WM_CHAR = 0x0102;
        public const uint WM_CHARTOITEM = 0x002F;
        public const uint WM_CHILDACTIVATE = 0x0022;
        public const uint WM_CLEAR = 0x0303;
        public const uint WM_CLOSE = 0x0010;
        public const uint WM_COMMAND = 0x0111;
        public const uint WM_COMPACTING = 0x0041;
        public const uint WM_COMPAREITEM = 0x0039;
        public const uint WM_CONTEXTMENU = 0x007B;
        public const uint WM_COPY = 0x0301;
        public const uint WM_COPYDATA = 0x004A;
        public const uint WM_CREATE = 0x0001;
        public const uint WM_CTLCOLORBTN = 0x0135;
        public const uint WM_CTLCOLORDLG = 0x0136;
        public const uint WM_CTLCOLOREDIT = 0x0133;
        public const uint WM_CTLCOLORLISTBOX = 0x0134;
        public const uint WM_CTLCOLORMSGBOX = 0x0132;
        public const uint WM_CTLCOLORSCROLLBAR = 0x0137;
        public const uint WM_CTLCOLORSTATIC = 0x0138;
        public const uint WM_CUT = 0x0300;
        public const uint WM_DEADCHAR = 0x0103;
        public const uint WM_DELETEITEM = 0x002D;
        public const uint WM_DESTROY = 0x0002;
        public const uint WM_DESTROYCLIPBOARD = 0x0307;
        public const uint WM_DEVICECHANGE = 0x0219;
        public const uint WM_DEVMODECHANGE = 0x001B;
        public const uint WM_DISPLAYCHANGE = 0x007E;
        public const uint WM_DRAWCLIPBOARD = 0x0308;
        public const uint WM_DRAWITEM = 0x002B;
        public const uint WM_DROPFILES = 0x0233;
        public const uint WM_ENABLE = 0x000A;
        public const uint WM_ENDSESSION = 0x0016;
        public const uint WM_ENTERIDLE = 0x0121;
        public const uint WM_ENTERMENULOOP = 0x0211;
        public const uint WM_ENTERSIZEMOVE = 0x0231;
        public const uint WM_ERASEBKGND = 0x0014;
        public const uint WM_EXITMENULOOP = 0x0212;
        public const uint WM_EXITSIZEMOVE = 0x0232;
        public const uint WM_FONTCHANGE = 0x001D;
        public const uint WM_GETDLGCODE = 0x0087;
        public const uint WM_GETFONT = 0x0031;
        public const uint WM_GETHOTKEY = 0x0033;
        public const uint WM_GETICON = 0x007F;
        public const uint WM_GETMINMAXINFO = 0x0024;
        public const uint WM_GETOBJECT = 0x003D;
        public const uint WM_GETTEXT = 0x000D;
        public const uint WM_GETTEXTLENGTH = 0x000E;
        public const uint WM_HANDHELDFIRST = 0x0358;
        public const uint WM_HANDHELDLAST = 0x035F;
        public const uint WM_HELP = 0x0053;
        public const uint WM_HOTKEY = 0x0312;
        public const uint WM_HSCROLL = 0x0114;
        public const uint WM_HSCROLLCLIPBOARD = 0x030E;
        public const uint WM_ICONERASEBKGND = 0x0027;
        public const uint WM_IME_CHAR = 0x0286;
        public const uint WM_IME_COMPOSITION = 0x010F;
        public const uint WM_IME_COMPOSITIONFULL = 0x0284;
        public const uint WM_IME_CONTROL = 0x0283;
        public const uint WM_IME_ENDCOMPOSITION = 0x010E;
        public const uint WM_IME_KEYDOWN = 0x0290;
        public const uint WM_IME_KEYLAST = 0x010F;
        public const uint WM_IME_KEYUP = 0x0291;
        public const uint WM_IME_NOTIFY = 0x0282;
        public const uint WM_IME_REQUEST = 0x0288;
        public const uint WM_IME_SELECT = 0x0285;
        public const uint WM_IME_SETCONTEXT = 0x0281;
        public const uint WM_IME_STARTCOMPOSITION = 0x010D;
        public const uint WM_INITDIALOG = 0x0110;
        public const uint WM_INITMENU = 0x0116;
        public const uint WM_INITMENUPOPUP = 0x0117;
        public const uint WM_INPUTLANGCHANGE = 0x0051;
        public const uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public const uint WM_KEYDOWN = 0x0100;
        public const uint WM_KEYFIRST = 0x0100;
        public const uint WM_KEYLAST = 0x0108;
        public const uint WM_KEYUP = 0x0101;
        public const uint WM_KILLFOCUS = 0x0008;
        public const uint WM_LBUTTONDBLCLK = 0x0203;
        public const uint WM_LBUTTONDOWN = 0x0201;
        public const uint WM_LBUTTONUP = 0x0202;
        public const uint WM_MBUTTONDBLCLK = 0x0209;
        public const uint WM_MBUTTONDOWN = 0x0207;
        public const uint WM_MBUTTONUP = 0x0208;
        public const uint WM_MDIACTIVATE = 0x0222;
        public const uint WM_MDICASCADE = 0x0227;
        public const uint WM_MDICREATE = 0x0220;
        public const uint WM_MDIDESTROY = 0x0221;
        public const uint WM_MDIGETACTIVE = 0x0229;
        public const uint WM_MDIICONARRANGE = 0x0228;
        public const uint WM_MDIMAXIMIZE = 0x0225;
        public const uint WM_MDINEXT = 0x0224;
        public const uint WM_MDIREFRESHMENU = 0x0234;
        public const uint WM_MDIRESTORE = 0x0223;
        public const uint WM_MDISETMENU = 0x0230;
        public const uint WM_MDITILE = 0x0226;
        public const uint WM_MEASUREITEM = 0x002C;
        public const uint WM_MENUCHAR = 0x0120;
        public const uint WM_MENUCOMMAND = 0x0126;
        public const uint WM_MENUDRAG = 0x0123;
        public const uint WM_MENUGETOBJECT = 0x0124;
        public const uint WM_MENURBUTTONUP = 0x0122;
        public const uint WM_MENUSELECT = 0x011F;
        public const uint WM_MOUSEACTIVATE = 0x0021;
        public const uint WM_MOUSEFIRST = 0x0200;
        public const uint WM_MOUSEHOVER = 0x02A1;
        public const uint WM_MOUSELAST = 0x020D;
        public const uint WM_MOUSELEAVE = 0x02A3;
        public const uint WM_MOUSEMOVE = 0x0200;
        public const uint WM_MOUSEWHEEL = 0x020A;
        public const uint WM_MOUSEHWHEEL = 0x020E;
        public const uint WM_MOVE = 0x0003;
        public const uint WM_MOVING = 0x0216;
        public const uint WM_NCACTIVATE = 0x0086;
        public const uint WM_NCCALCSIZE = 0x0083;
        public const uint WM_NCCREATE = 0x0081;
        public const uint WM_NCDESTROY = 0x0082;
        public const uint WM_NCHITTEST = 0x0084;
        public const uint WM_NCLBUTTONDBLCLK = 0x00A3;
        public const uint WM_NCLBUTTONDOWN = 0x00A1;
        public const uint WM_NCLBUTTONUP = 0x00A2;
        public const uint WM_NCMBUTTONDBLCLK = 0x00A9;
        public const uint WM_NCMBUTTONDOWN = 0x00A7;
        public const uint WM_NCMBUTTONUP = 0x00A8;
        public const uint WM_NCMOUSEHOVER = 0x02A0;
        public const uint WM_NCMOUSELEAVE = 0x02A2;
        public const uint WM_NCMOUSEMOVE = 0x00A0;
        public const uint WM_NCPAINT = 0x0085;
        public const uint WM_NCRBUTTONDBLCLK = 0x00A6;
        public const uint WM_NCRBUTTONDOWN = 0x00A4;
        public const uint WM_NCRBUTTONUP = 0x00A5;
        public const uint WM_NCXBUTTONDBLCLK = 0x00AD;
        public const uint WM_NCXBUTTONDOWN = 0x00AB;
        public const uint WM_NCXBUTTONUP = 0x00AC;
        public const uint WM_NCUAHDRAWCAPTION = 0x00AE;
        public const uint WM_NCUAHDRAWFRAME = 0x00AF;
        public const uint WM_NEXTDLGCTL = 0x0028;
        public const uint WM_NEXTMENU = 0x0213;
        public const uint WM_NOTIFY = 0x004E;
        public const uint WM_NOTIFYFORMAT = 0x0055;
        public const uint WM_NULL = 0x0000;
        public const uint WM_PAINT = 0x000F;
        public const uint WM_PAINTCLIPBOARD = 0x0309;
        public const uint WM_PAINTICON = 0x0026;
        public const uint WM_PALETTECHANGED = 0x0311;
        public const uint WM_PALETTEISCHANGING = 0x0310;
        public const uint WM_PARENTNOTIFY = 0x0210;
        public const uint WM_PASTE = 0x0302;
        public const uint WM_PENWINFIRST = 0x0380;
        public const uint WM_PENWINLAST = 0x038F;
        public const uint WM_POWER = 0x0048;
        public const uint WM_POWERBROADCAST = 0x0218;
        public const uint WM_PRINT = 0x0317;
        public const uint WM_PRINTCLIENT = 0x0318;
        public const uint WM_QUERYDRAGICON = 0x0037;
        public const uint WM_QUERYENDSESSION = 0x0011;
        public const uint WM_QUERYNEWPALETTE = 0x030F;
        public const uint WM_QUERYOPEN = 0x0013;
        public const uint WM_QUEUESYNC = 0x0023;
        public const uint WM_QUIT = 0x0012;
        public const uint WM_RBUTTONDBLCLK = 0x0206;
        public const uint WM_RBUTTONDOWN = 0x0204;
        public const uint WM_RBUTTONUP = 0x0205;
        public const uint WM_RENDERALLFORMATS = 0x0306;
        public const uint WM_RENDERFORMAT = 0x0305;
        public const uint WM_SETCURSOR = 0x0020;
        public const uint WM_SETFOCUS = 0x0007;
        public const uint WM_SETFONT = 0x0030;
        public const uint WM_SETHOTKEY = 0x0032;
        public const uint WM_SETICON = 0x0080;
        public const uint WM_SETREDRAW = 0x000B;
        public const uint WM_SETTEXT = 0x000C;
        public const uint WM_SETTINGCHANGE = 0x001A;
        public const uint WM_SHOWWINDOW = 0x0018;
        public const uint WM_SIZE = 0x0005;
        public const uint WM_SIZECLIPBOARD = 0x030B;
        public const uint WM_SIZING = 0x0214;
        public const uint WM_SPOOLERSTATUS = 0x002A;
        public const uint WM_STYLECHANGED = 0x007D;
        public const uint WM_STYLECHANGING = 0x007C;
        public const uint WM_SYNCPAINT = 0x0088;
        public const uint WM_SYSCHAR = 0x0106;
        public const uint WM_SYSCOLORCHANGE = 0x0015;
        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint WM_SYSDEADCHAR = 0x0107;
        public const uint WM_SYSKEYDOWN = 0x0104;
        public const uint WM_SYSKEYUP = 0x0105;
        public const uint WM_TCARD = 0x0052;
        public const uint WM_TIMECHANGE = 0x001E;
        public const uint WM_TIMER = 0x0113;
        public const uint WM_UNDO = 0x0304;
        public const uint WM_UNINITMENUPOPUP = 0x0125;
        public const uint WM_USER = 0x0400;
        public const uint WM_USERCHANGED = 0x0054;
        public const uint WM_VKEYTOITEM = 0x002E;
        public const uint WM_VSCROLL = 0x0115;
        public const uint WM_VSCROLLCLIPBOARD = 0x030A;
        public const uint WM_WINDOWPOSCHANGED = 0x0047;
        public const uint WM_WINDOWPOSCHANGING = 0x0046;
        public const uint WM_WININICHANGE = 0x001A;
        public const uint WM_XBUTTONDBLCLK = 0x020D;
        public const uint WM_XBUTTONDOWN = 0x020B;
        public const uint WM_XBUTTONUP = 0x020C;
        #endregion WM

        #region SIID
        public const uint SIID_DOCNOASSOC = 0;
        public const uint SIID_DOCASSOC = 1;
        public const uint SIID_APPLICATION = 2;
        public const uint SIID_FOLDER = 3;
        public const uint SIID_FOLDEROPEN = 4;
        public const uint SIID_DRIVE525 = 5;
        public const uint SIID_DRIVE35 = 6;
        public const uint SIID_DRIVEREMOVE = 7;
        public const uint SIID_DRIVEFIXED = 8;
        public const uint SIID_DRIVENET = 9;
        public const uint SIID_DRIVENETDISABLED = 10;
        public const uint SIID_DRIVECD = 11;
        public const uint SIID_DRIVERAM = 12;
        public const uint SIID_WORLD = 13;
        public const uint SIID_SERVER = 15;
        public const uint SIID_PRINTER = 16;
        public const uint SIID_MYNETWORK = 17;
        public const uint SIID_FIND = 22;
        public const uint SIID_HELP = 23;
        public const uint SIID_SHARE = 28;
        public const uint SIID_LINK = 29;
        public const uint SIID_SLOWFILE = 30;
        public const uint SIID_RECYCLER = 31;
        public const uint SIID_RECYCLERFULL = 32;
        public const uint SIID_MEDIACDAUDIO = 40;
        public const uint SIID_LOCK = 47;
        public const uint SIID_AUTOLIST = 49;
        public const uint SIID_PRINTERNET = 50;
        public const uint SIID_SERVERSHARE = 51;
        public const uint SIID_PRINTERFAX = 52;
        public const uint SIID_PRINTERFAXNET = 53;
        public const uint SIID_PRINTERFILE = 54;
        public const uint SIID_STACK = 55;
        public const uint SIID_MEDIASVCD = 56;
        public const uint SIID_STUFFEDFOLDER = 57;
        public const uint SIID_DRIVEUNKNOWN = 58;
        public const uint SIID_DRIVEDVD = 59;
        public const uint SIID_MEDIADVD = 60;
        public const uint SIID_MEDIADVDRAM = 61;
        public const uint SIID_MEDIADVDRW = 62;
        public const uint SIID_MEDIADVDR = 63;
        public const uint SIID_MEDIADVDROM = 64;
        public const uint SIID_MEDIACDAUDIOPLUS = 65;
        public const uint SIID_MEDIACDRW = 66;
        public const uint SIID_MEDIACDR = 67;
        public const uint SIID_MEDIACDBURN = 68;
        public const uint SIID_MEDIABLANKCD = 69;
        public const uint SIID_MEDIACDROM = 70;
        public const uint SIID_AUDIOFILES = 71;
        public const uint SIID_IMAGEFILES = 72;
        public const uint SIID_VIDEOFILES = 73;
        public const uint SIID_MIXEDFILES = 74;
        public const uint SIID_FOLDERBACK = 75;
        public const uint SIID_FOLDERFRONT = 76;
        public const uint SIID_SHIELD = 77;
        public const uint SIID_WARNING = 78;
        public const uint SIID_INFO = 79;
        public const uint SIID_ERROR = 80;
        public const uint SIID_KEY = 81;
        public const uint SIID_SOFTWARE = 82;
        public const uint SIID_RENAME = 83;
        public const uint SIID_DELETE = 84;
        public const uint SIID_MEDIAAUDIODVD = 85;
        public const uint SIID_MEDIAMOVIEDVD = 86;
        public const uint SIID_MEDIAENHANCEDCD = 87;
        public const uint SIID_MEDIAENHANCEDDVD = 88;
        public const uint SIID_MEDIAHDDVD = 89;
        public const uint SIID_MEDIABLURAY = 90;
        public const uint SIID_MEDIAVCD = 91;
        public const uint SIID_MEDIADVDPLUSR = 92;
        public const uint SIID_MEDIADVDPLUSRW = 93;
        public const uint SIID_DESKTOPPC = 94;
        public const uint SIID_MOBILEPC = 95;
        public const uint SIID_USERS = 96;
        public const uint SIID_MEDIASMARTMEDIA = 97;
        public const uint SIID_MEDIACOMPACTFLASH = 98;
        public const uint SIID_DEVICECELLPHONE = 99;
        public const uint SIID_DEVICECAMERA = 100;
        public const uint SIID_DEVICEVIDEOCAMERA = 101;
        public const uint SIID_DEVICEAUDIOPLAYER = 102;
        public const uint SIID_NETWORKCONNECT = 103;
        public const uint SIID_INTERNET = 104;
        public const uint SIID_ZIPFILE = 105;
        public const uint SIID_SETTINGS = 106;
        public const uint SIID_DRIVEHDDVD = 132;
        public const uint SIID_DRIVEBD = 133;
        public const uint SIID_MEDIAHDDVDROM = 134;
        public const uint SIID_MEDIAHDDVDR = 135;
        public const uint SIID_MEDIAHDDVDRAM = 136;
        public const uint SIID_MEDIABDROM = 137;
        public const uint SIID_MEDIABDR = 138;
        public const uint SIID_MEDIABDRE = 139;
        public const uint SIID_CLUSTEREDDRIVE = 140;
        public const uint SIID_MAX_ICONS = 175;
        #endregion

        #region SHGSI
        public const uint SHGFI_ICON = 0x000000100;     // get icon
        public const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
        public const uint SHGFI_TYPENAME = 0x000000400;     // get type name
        public const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
        public const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
        public const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
        public const uint SHGFI_SYSICONINDEX = 0x000004000;     // get system icon index
        public const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
        public const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
        public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
        public const uint SHGFI_LARGEICON = 0x000000000;     // get large icon
        public const uint SHGFI_SMALLICON = 0x000000001;     // get small icon
        public const uint SHGFI_OPENICON = 0x000000002;     // get open icon
        public const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
        public const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute
        public const uint SHGFI_ADDOVERLAYS = 0x000000020;     // apply the appropriate overlays
        public const uint SHGFI_OVERLAYINDEX = 0x000000040;     // Get the index of the overlay
        #endregion

        #region BIF
        public const uint BIF_RETURNONLYFSDIRS = 0x0001;
        public const uint BIF_DONTGOBELOWDOMAIN = 0x0002;
        public const uint BIF_STATUSTEXT = 0x0004;
        public const uint BIF_RETURNFSANCESTORS = 0x0008;
        public const uint BIF_EDITBOX = 0x0010;
        public const uint BIF_VALIDATE = 0x0020;
        public const uint BIF_NEWDIALOGSTYLE = 0x0040;
        public const uint BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX);
        public const uint BIF_BROWSEINCLUDEURLS = 0x0080;
        public const uint BIF_BROWSEFORCOMPUTER = 0x1000;
        public const uint BIF_BROWSEFORPRINTER = 0x2000;
        public const uint BIF_BROWSEINCLUDEFILES = 0x4000;
        public const uint BIF_SHAREABLE = 0x8000;
        #endregion
        #endregion

        public class Shell32
        {
            [DllImport("shell32.dll")]
            public static extern int SHGetStockIconInfo(uint siid, uint uFlags, ref SHSTOCKICONINFO psii);
            [DllImport("Shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        }

        public class User32
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, ref IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
            [DllImport("user32.dll")]
            public static extern bool DestroyIcon(IntPtr handle);
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public class CHARFORMAT2
        {
            public int cbSize = Marshal.SizeOf(typeof(CHARFORMAT2));
            public int dwMask;
            public int dwEffects;
            public int yHeight;
            public int yOffset;
            public int crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szFaceName;
            public short wWeight;
            public short sSpacing;
            public int crBackColor;
            public int lcid;
            public int dwReserved;
            public short sStyle;
            public short wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
            public byte bReserved1;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHSTOCKICONINFO
        {
            public uint cbSize;
            public IntPtr hIcon;
            public int iSysIconIndex;
            public int iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szPath;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SHITEMID
        {
            public ushort cb;
            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] abID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            public SHITEMID mkid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;
            public IntPtr pidlRoot;
            public IntPtr pszDisplayName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszTitle;
            public uint ulFlags;
            public IntPtr lpfn;
            public int lParam;
            public IntPtr iImage;
        }
    }
    public static class Commons
    {
        #region Const
        public const string CategoryIcon = "Icon";
        public const string CategoryAppearance = "Appearance";
        #endregion

        #region Global Variables
        /// <summary>神奇水平數字</summary>
        internal static readonly int MagicHorizonal = 6;
        /// <summary>神奇垂直數字</summary>
        internal static readonly int MagicVertical = 7;

        private static ConcurrentDictionary<FontFamily, FontCache> _fontCaches
            = new ConcurrentDictionary<FontFamily, FontCache>();
        #endregion

        #region Helper
        public static void Boostrap(Control control)
        {
            if (control != null)
            {
                var c = control as ICgComponent;
                if (c != null)
                    c.RuntimeBootstrap();

                var p = control as Panel;
                if (p != null)
                {
                    foreach (Control ch in p.Controls)
                        Boostrap(ch);
                }
            }
        }
        public static bool IsRuntime()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Runtime;
        }

        private static readonly ConcurrentDictionary<Type, DefaultValueCollection> _defaultValueCollectionMap = new ConcurrentDictionary<Type, DefaultValueCollection>();
        /// <summary>
        /// 套用 <see cref="DefaultValueAttribute"/> 的值作為預設值
        /// </summary>
        /// <param name="instance">實例</param>
        /// <param name="applyType">要套用的類別</param>
        /// <param name="inherit">是否要尋找繼承類別</param>
        public static void ApplyDefaultProperties(object instance, Type applyType, bool inherit)
        {
            var controlType = applyType ?? instance.GetType();
            var collection = _defaultValueCollectionMap.GetOrAdd(controlType, t => CreateDefaultValueCollection(controlType, inherit));
            collection.Apply(instance);
        }
        private static DefaultValueCollection CreateDefaultValueCollection(Type type, bool inherit)
        {
            DefaultValueCollection defaultValues = new DefaultValueCollection(type);
            var flags = BindingFlags.Public | BindingFlags.Instance;
            if (!inherit)
                flags |= BindingFlags.DeclaredOnly;
            foreach (PropertyInfo property in type.GetProperties(flags).Where(p => p.CanWrite))
            {
                var defaultValueAttr = (DefaultValueAttribute)property.GetCustomAttributes(typeof(DefaultValueAttribute), false).FirstOrDefault();
                if (defaultValueAttr != null)
                {
                    var defaultValue = defaultValueAttr.Value;
                    defaultValues.Add(property, defaultValue);
                }
            }
            return defaultValues;
        }

        private class DefaultValueCollection : Dictionary<PropertyInfo, object>
        {
            private readonly Type _targetType;

            public DefaultValueCollection(Type targetType)
            {
                _targetType = targetType;
            }

            public void Apply(object instance)
            {
                foreach (var kv in this)
                    kv.Key.SetValue(instance, kv.Value, null);
            }
        }
        public static Color GetNonEmptyColor(params Color[] colors)
        {
            foreach (var color in colors)
                if (!color.IsEmpty)
                    return color;
            return Color.Empty;
        }

        public class StringFormatCollection : Dictionary<ContentAlignment, StringFormat>, IDisposable
        {
            private bool _disposed;
            public StringFormatCollection(StringFormat baseFormat)
            {
                foreach (ContentAlignment ca in Enum.GetValues(typeof(ContentAlignment)))
                {
                    var sf = new StringFormat(baseFormat);
                    try
                    {
                        SetupContentAlignment(sf, ca);
                        Add(ca, sf);
                    }
                    catch { }
                }
            }

            public StringFormat TopLeft
            {
                get { return this[ContentAlignment.TopLeft]; }
            }
            public StringFormat TopCenter
            {
                get { return this[ContentAlignment.TopCenter]; }
            }
            public StringFormat TopRight
            {
                get { return this[ContentAlignment.TopRight]; }
            }
            public StringFormat MiddleLeft
            {
                get { return this[ContentAlignment.MiddleLeft]; }
            }
            public StringFormat MiddleCenter
            {
                get { return this[ContentAlignment.MiddleCenter]; }
            }
            public StringFormat MiddleRight
            {
                get { return this[ContentAlignment.MiddleRight]; }
            }
            public StringFormat BottomLeft
            {
                get { return this[ContentAlignment.BottomLeft]; }
            }
            public StringFormat BottomCenter
            {
                get { return this[ContentAlignment.BottomCenter]; }
            }
            public StringFormat BottomRight
            {
                get { return this[ContentAlignment.BottomRight]; }
            }

            ~StringFormatCollection()
            {
                Dispose(false);
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }            
            protected void _Dispose(bool disposing)
            {
                if(!_disposed)
                {
                    Dispose(disposing);
                    _disposed = true;
                }
            }
            protected virtual void Dispose(bool disposing)
            {
                var keys = Keys.ToArray();
                foreach (var key in keys)
                    this[key].Dispose();
                Clear();
            }
        }

        public static void Execute(Action action, Action<Exception> unexceptHandler)
        {
            try
            {
                action();
            }
            catch(Exception ex)
            {
                unexceptHandler(ex);
            }
        }
        public static void Execute<TException>(Action action, Action<TException> exceptHandler, Action<Exception> unexceptHandler)
            where TException: Exception
        {
            try
            {
                action();
            }          
            catch (TException ex)
            {
                exceptHandler(ex);
            }
            catch (Exception ex)
            {
                unexceptHandler(ex);
            }
        }
        public static T Execute<T>(Func<T> action, Action<Exception> unexceptHandler, T defaultValue = default(T))
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                unexceptHandler(ex);
            }
            return defaultValue;
        }
        public static T Execute<TException, T>(Func<T> action,  Action<TException> exceptHandler, Action<Exception> unexceptHandler, T defaultValue = default(T))
            where TException : Exception
        {
            try
            {
                return action();
            }
            catch(TException ex)
            {
                exceptHandler(ex);
            }
            catch (Exception ex)
            {
                unexceptHandler(ex);
            }
            return defaultValue;
        }

        #region 繪圖 Drawing
        /// <summary>
        /// 建立圓角圖形路徑
        /// </summary>
        /// <param name="rect">圖形大小</param>
        /// <param name="radius">圓角弧度</param>
        /// <returns></returns>
        public static GraphicsPath CreateRoundGraphicsPath(RectangleF rect, float radius)
        {
            return CreateRoundGraphicsPath(rect, radius, radius, radius, radius);
        }
        /// <summary>
        /// 建立圓角圖形路徑
        /// </summary>
        public static GraphicsPath CreateRoundGraphicsPath(RectangleF rect,
            float radiusLeftTop, float radiusRightTop, float radiusRightBottom, float radiusLeftBottom)
        {
            return CreateRoundGraphicsPath(rect,
                radiusLeftTop, radiusLeftTop,
                radiusRightTop, radiusRightTop,
                radiusRightBottom, radiusRightBottom,
                radiusLeftBottom, radiusLeftBottom);
        }
        /// <summary>
        /// 建立圓角圖形路徑
        /// </summary>
        public static GraphicsPath CreateRoundGraphicsPath(RectangleF rect,
            float radiusLeftTopWidth, float radiusLeftTopHeight,
            float radiusRightTopWidth, float radiusRightTopHeight,
            float radiusRightBottomWidth, float radiusRightBottomHeight,
            float radiusLeftBottomWidth, float radiusLeftBottomHeight)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            var p = rect.Location;
            var left = rect.Height - radiusLeftTopHeight - radiusLeftBottomHeight;
            var top = rect.Width - radiusLeftTopWidth - radiusRightTopWidth;
            var right = rect.Height - radiusRightTopHeight - radiusRightBottomHeight;
            var bottom = rect.Width - radiusLeftBottomWidth - radiusRightBottomWidth;
            if (radiusLeftTopWidth != 0 && radiusLeftTopHeight != 0)
            {
                roundedRect.AddArc(p.X, p.Y, radiusLeftTopWidth, radiusLeftTopHeight, 180, 90);
                p = p.GetOffset(radiusLeftTopWidth, 0);
            }

            roundedRect.AddLine(p.X, p.Y, p.X + top, rect.Y);
            p = p.GetOffset(top, 0);

            if (radiusRightTopHeight != 0 && radiusRightTopWidth != 0)
            {
                roundedRect.AddArc(p.X, p.Y, radiusRightTopWidth, radiusRightTopHeight, 270, 90);
                p = p.GetOffset(radiusRightTopWidth, radiusRightTopHeight);
            }

            roundedRect.AddLine(p.X, p.Y, p.X, p.Y + right);
            p = p.GetOffset(0, right);
            if (radiusRightBottomHeight != 0 && radiusRightBottomWidth != 0)
            {
                roundedRect.AddArc(p.X - radiusRightBottomWidth, p.Y, radiusRightBottomWidth, radiusRightBottomHeight, 0, 90);
                p = p.GetOffset(-radiusRightBottomWidth, radiusRightBottomHeight);
            }

            roundedRect.AddLine(p.X, p.Y, p.X - bottom, p.Y);
            p = p.GetOffset(-bottom, 0);

            if (radiusLeftBottomWidth != 0 && radiusLeftBottomHeight != 0)
            {
                roundedRect.AddArc(p.X - radiusLeftBottomWidth, p.Y - radiusLeftBottomHeight, radiusLeftBottomWidth, radiusLeftBottomHeight, 90, 90);
                p = p.GetOffset(-radiusLeftBottomWidth, -radiusLeftBottomHeight);
            }
            roundedRect.AddLine(p.X, p.Y, p.X, p.Y - left);
            roundedRect.CloseFigure();
            return roundedRect;
        }

        /// <summary>
        /// 取得單色或是雙色筆刷
        /// </summary>
        /// <param name="color1">顏色1</param>
        /// <param name="color2">顏色2</param>
        /// <param name="rect">區塊，雙色用</param>
        /// <param name="angle">角度，雙色用</param>
        /// <returns></returns>
        public static Brush GetSingleOrDoubleBrush(Color color1, Color color2, Rectangle rect, float angle)
        {
            if (color2 != default(Color))
                return new SolidBrush(color1);
            return new LinearGradientBrush(rect, color1, color2, angle);            
        }
        /// <summary>
        /// 取得單色或是雙色筆刷
        /// </summary>
        /// <param name="color1">顏色1</param>
        /// <param name="color2">顏色2</param>
        /// <param name="rect">區塊，雙色用</param>
        /// <param name="angle">角度，雙色用</param>
        /// <returns></returns>
        public static Brush GetSingleOrDoubleBrush(Color color1, Color color2, Rectangle rect, LinearGradientMode mode)
        {
            if (color2 != default(Color))
                return new SolidBrush(color1);
            return new LinearGradientBrush(rect, color1, color2, mode);
        }
        #endregion


        internal static string Quote(object value, string quote = "\"", string escape = "\"\"")
        {
            if (value == null)
                return null;
            var text = value.ToString();
            text.Replace(quote, escape);
            return quote + text + quote;
        }
        private static readonly ConcurrentDictionary<MemberInfo, string> _displayNameCache
            = new ConcurrentDictionary<MemberInfo, string>();
        /// <summary>
        /// 取得DisplayName
        /// </summary>        
        public static string GetDisplayName(MemberInfo member)
        {
            return _displayNameCache.GetOrAdd(member, m =>
            {
                var attr = Attribute.GetCustomAttribute(member, typeof(DisplayNameAttribute));
                return attr == null ? null : ((DisplayNameAttribute)attr).DisplayName;
            });
        }
        #endregion

        #region Extension

        #region 繪圖 Drawing 

        #region 矩形 Rectangle
        /// <summary>
        /// 計算加上<see cref="Padding"/>後的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="padding">要計算的<see cref="Padding"/></param>
        /// <returns>計算<see cref="Padding"/>後的矩形</returns>
        public static Rectangle ApplyPadding(this Rectangle rect, Padding padding)
        {
            return ApplyPadding(rect, padding.Left, padding.Top, padding.Right, padding.Bottom);
        }
        /// <summary>
        /// 計算邊框距離後的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="padding">邊框距離</param>
        /// <returns>計算邊框距離後的矩形</returns>
        public static Rectangle ApplyPadding(this Rectangle rect, int padding)
        {
            if (padding == 0) return rect;
            return ApplyPadding(rect, padding, padding, padding, padding);
        }
        /// <summary>
        /// 計算邊框距離後的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="paddingHorizon">水平邊框距離</param>
        /// <param name="paddingVertical">垂直邊框距離</param>
        /// <returns>計算邊框距離後的矩形</returns>
        public static Rectangle ApplyPadding(this Rectangle rect, int paddingHorizon, int paddingVertical)
        {
            var horizon = paddingHorizon / 2;
            var vertical = paddingVertical / 2;
            return ApplyPadding(rect, horizon, vertical, horizon, vertical);
        }
        /// <summary>
        /// 計算邊框距離後的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="paddingLeft">左側邊框距離</param>
        /// <param name="paddingTop">上方邊框距離</param>
        /// <param name="paddingRight">右側邊框距離</param>
        /// <param name="paddingBottom">下方邊框距離</param>
        /// <returns>計算邊框距離後的矩形</returns>
        public static Rectangle ApplyPadding(this Rectangle rect, int paddingLeft, int paddingTop, int paddingRight, int paddingBottom)
        {
            return new Rectangle(
                rect.X + paddingLeft,
                rect.Y + paddingTop,
                rect.Width - paddingLeft - paddingRight,
                rect.Height - paddingTop - paddingBottom
            );
        }
        /// <summary>
        /// 計算加上<see cref="Padding"/>後的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="padding">要計算的<see cref="Padding"/></param>
        /// <returns>計算<see cref="Padding"/>後的矩形</returns>
        public static RectangleF ApplyPadding(this RectangleF rect, Padding padding)
        {
            return ApplyPadding(rect, padding.Left, padding.Top, padding.Right, padding.Bottom);
        }
        /// <summary>
        /// 計算邊框距離後的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="padding">邊框距離</param>
        /// <returns>計算邊框距離後的矩形</returns>
        public static RectangleF ApplyPadding(this RectangleF rect, float padding)
        {
            if (padding == 0) return rect;
            return ApplyPadding(rect, padding, padding, padding, padding);
        }
        /// <summary>
        /// 計算邊框距離後的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="paddingHorizon">水平邊框距離</param>
        /// <param name="paddingVertical">垂直邊框距離</param>
        /// <returns>計算邊框距離後的矩形</returns>
        public static RectangleF ApplyPadding(this RectangleF rect, float paddingHorizon, float paddingVertical)
        {
            var horizon = paddingHorizon / 2;
            var vertical = paddingVertical / 2;
            return ApplyPadding(rect, horizon, vertical, horizon, vertical);
        }
        /// <summary>
        /// 計算邊框距離後的矩形
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="paddingLeft">左側邊框距離</param>
        /// <param name="paddingTop">上方邊框距離</param>
        /// <param name="paddingRight">右側邊框距離</param>
        /// <param name="paddingBottom">下方邊框距離</param>
        /// <returns>計算邊框距離後的矩形</returns>
        public static RectangleF ApplyPadding(this RectangleF rect, float paddingLeft, float paddingTop, float paddingRight, float paddingBottom)
        {
            return new RectangleF(
                rect.X + paddingLeft,
                rect.Y + paddingTop,
                rect.Width - paddingLeft - paddingRight,
                rect.Height - paddingTop - paddingBottom
            );
        }
        /// <summary>
        /// 取得位移後的新矩形
        /// </summary>        
        public static RectangleF GetOffset(this RectangleF rect, float x, float y)
        {
            var p = rect.Location;
            var newP = p.GetOffset(x, y);
            rect.Location = newP;
            return rect;
        }
        /// <summary>
        /// 取得位移後的新矩形
        /// </summary>    
        public static RectangleF GetOffset(this RectangleF rect, PointF p)
        {
            return GetOffset(rect, p.X, p.Y);
        }
        #endregion Rectangle

        #region 大小 Size
        /// <summary>
        /// 既有 <see cref="Size"/> 是否能包含新的 <see cref="Size"/>
        /// </summary>
        public static bool Contains(this Size sourceSize, Size size)
        {
            return Contains((SizeF)sourceSize, size);
        }
        /// <summary>
        /// 既有 <see cref="SizeF"/> 是否能包含新的 <see cref="SizeF"/>
        /// </summary>
        public static bool Contains(this SizeF sourceSize, SizeF size)
        {
            return sourceSize.Width >= size.Width && sourceSize.Height >= size.Height;
        }

        /// <summary>
        /// 計算扣掉<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="padding">要計算的<see cref="Padding"/></param>
        /// <returns>加上<see cref="Padding"/>後的大小</returns>
        public static Size ApplyPadding(this Size size, Padding padding)
        {
            return ApplyPadding(size, padding.Left, padding.Top, padding.Right, padding.Bottom);
        }
        /// <summary>
        /// 計算扣掉<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="padding">邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static Size ApplyPadding(this Size size, int padding)
        {
            if (padding == 0) return size;
            return ApplyPadding(size, padding, padding, padding, padding);
        }
        /// <summary>
        /// 計算扣掉<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="paddingHorizon">水平邊框距離</param>
        /// <param name="paddingVertical">垂直邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static Size ApplyPadding(this Size size, int paddingHorizon, int paddingVertical)
        {
            var horizon = paddingHorizon / 2;
            var vertical = paddingVertical / 2;
            return ApplyPadding(size, horizon, vertical, horizon, vertical);
        }
        /// <summary>
        /// 計算扣掉<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="paddingLeft">左側邊框距離</param>
        /// <param name="paddingTop">上方邊框距離</param>
        /// <param name="paddingRight">右側邊框距離</param>
        /// <param name="paddingBottom">下方邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static Size ApplyPadding(this Size size, int paddingLeft, int paddingTop, int paddingRight, int paddingBottom)
        {
            return new Size(
                size.Width - paddingLeft - paddingRight,
                size.Height - paddingTop - paddingBottom
            );
        }
        /// <summary>
        /// 計算扣掉<see cref="Padding"/>後的大小 
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="padding">要計算的<see cref="Padding"/></param>
        /// <returns>加上<see cref="Padding"/>後的大小</returns>
        public static SizeF ApplyPadding(this SizeF size, Padding padding)
        {
            return ApplyPadding(size, padding.Left, padding.Top, padding.Right, padding.Bottom);
        }
        /// <summary>
        /// 計算扣掉<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="padding">邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static SizeF ApplyPadding(this SizeF size, float padding)
        {
            if (padding == 0) return size;
            return ApplyPadding(size, padding, padding, padding, padding);
        }
        /// <summary>
        /// 計算扣掉<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="paddingHorizon">水平邊框距離</param>
        /// <param name="paddingVertical">垂直邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static SizeF ApplyPadding(this SizeF size, float paddingHorizon, float paddingVertical)
        {
            var horizon = paddingHorizon / 2;
            var vertical = paddingVertical / 2;
            return ApplyPadding(size, horizon, vertical, horizon, vertical);
        }
        /// <summary>
        /// 計算扣掉<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="paddingLeft">左側邊框距離</param>
        /// <param name="paddingTop">上方邊框距離</param>
        /// <param name="paddingRight">右側邊框距離</param>
        /// <param name="paddingBottom">下方邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static SizeF ApplyPadding(this SizeF size, float paddingLeft, float paddingTop, float paddingRight, float paddingBottom)
        {
            return new SizeF(
                size.Width - paddingLeft - paddingRight,
                size.Height - paddingTop - paddingBottom
            );
        }

        /// <summary>
        /// 計算加上邊框<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="margin">要計算的<see cref="Padding"/></param>
        /// <returns>加上<see cref="Padding"/>後的大小</returns>
        public static Size ApplyMargin(this Size size, Padding margin)
        {
            return ApplyMargin(size, margin.Left, margin.Top, margin.Right, margin.Bottom);
        }
        /// <summary>
        /// 計算加上邊框<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="margin">邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static Size ApplyMargin(this Size size, int margin)
        {
            if (margin == 0) return size;
            return ApplyMargin(size, margin, margin, margin, margin);
        }
        /// <summary>
        /// 計算加上邊框<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="marginHorizonal">水平邊框距離</param>
        /// <param name="marginVertical">垂直邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static Size ApplyMargin(this Size size, int marginHorizonal, int marginVertical)
        {
            var horizon = marginHorizonal / 2;
            var vertical = marginVertical / 2;
            return ApplyMargin(size, horizon, vertical, horizon, vertical);
        }
        /// <summary>
        /// 計算加上邊框<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="marginLeft">左側邊框距離</param>
        /// <param name="marginTop">上方邊框距離</param>
        /// <param name="marginRight">右側邊框距離</param>
        /// <param name="marginBottom">下方邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static Size ApplyMargin(this Size size, int marginLeft, int marginTop, int marginRight, int marginBottom)
        {
            return new Size(
                size.Width + marginLeft + marginRight,
                size.Height + marginTop + marginBottom
            );
        }
        /// <summary>
        /// 計算加上邊框<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="margin">要計算的<see cref="Padding"/></param>
        /// <returns>加上<see cref="Padding"/>後的大小</returns>
        public static SizeF ApplyMargin(this SizeF size, Padding margin)
        {
            return ApplyMargin(size, margin.Left, margin.Top, margin.Right, margin.Bottom);
        }
        /// <summary>
        /// 計算加上邊框<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="margin">邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static SizeF ApplyMargin(this SizeF size, float margin)
        {
            if (margin == 0) return size;
            return ApplyMargin(size, margin, margin, margin, margin);
        }
        /// <summary>
        /// 計算加上邊框<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="marginHorizonal">水平邊框距離</param>
        /// <param name="marginVertical">垂直邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static SizeF ApplyMargin(this SizeF size, float marginHorizonal, float marginVertical)
        {
            var horizon = marginHorizonal / 2;
            var vertical = marginVertical / 2;
            return ApplyMargin(size, horizon, vertical, horizon, vertical);
        }
        /// <summary>
        /// 計算加上邊框<see cref="Padding"/>後的大小
        /// </summary>
        /// <param name="size">大小</param>
        /// <param name="marginLeft">左側邊框距離</param>
        /// <param name="marginTop">上方邊框距離</param>
        /// <param name="marginRight">右側邊框距離</param>
        /// <param name="marginBottom">下方邊框距離</param>
        /// <returns>計算邊框距離後的大小</returns>
        public static SizeF ApplyMargin(this SizeF size, float marginLeft, float marginTop, float marginRight, float marginBottom)
        {
            return new SizeF(
                size.Width + marginLeft + marginRight,
                size.Height + marginTop + marginBottom
            );
        }

        /// <summary>
        /// 縮放
        /// </summary>
        public static Size Scale(this Size size, float rate)
        {
            return Scale(size, new SizeF(rate, rate));
        }
        /// <summary>
        /// 縮放
        /// </summary>
        public static Size Scale(this Size size, SizeF rate)
        {
            var s = Scale(size, rate);
            return Size.Round(s);
        }
        /// <summary>
        /// 縮放
        /// </summary>
        public static Size Scale(this SizeF size, SizeF rate)
        {
            var s = Scale(size, rate);
            return Size.Round(s);
        }
        /// <summary>
        /// 縮放
        /// </summary>
        public static SizeF ScaleF(this Size size, SizeF rate)
        {
            return Scale((SizeF)size, rate);
        }
        /// <summary>
        /// 縮放
        /// </summary>
        public static SizeF ScaleF(this SizeF size, SizeF rate)
        {
            return new SizeF(size.Width * rate.Width, size.Height * rate.Height);
        }
        /// <summary>
        /// 取得DPI倍率
        /// </summary>        
        public static SizeF ToDpiRate(this SizeF dpi, float dpiRate = 96F)
        {
            return new SizeF(dpi.Width / dpiRate, dpi.Height / dpiRate);
        }
        /// <summary>
        /// 交換長寬
        /// </summary>        
        public static SizeF Rotate90(this SizeF size)
        {
            return new SizeF(size.Height, size.Width);
        }
        /// <summary>
        /// 交換長寬
        /// </summary>        
        public static Size Rotate90(this Size size)
        {
            return new Size(size.Height, size.Width);
        }
        #endregion

        #region 座標 Point
        /// <summary>
        /// 縮放
        /// </summary>
        public static Point Scale(this Point point, SizeF rate)
        {
            var p = ScaleF(point, rate);
            return Point.Round(p);
        }
        /// <summary>
        /// 縮放
        /// </summary>
        public static Point Scale(this PointF point, SizeF rate)
        {
            var p = ScaleF(point, rate);
            return Point.Round(p);
        }
        /// <summary>
        /// 縮放
        /// </summary>
        public static PointF ScaleF(this Point point, SizeF rate)
        {
            return ScaleF((PointF)point, rate);
        }
        /// <summary>
        /// 縮放
        /// </summary>
        public static PointF ScaleF(this PointF point, SizeF rate)
        {
            return new PointF(point.X * rate.Width, point.Y * rate.Height);
        }
        /// <summary>
        /// 取得矩形的特定座標
        /// </summary>        
        public static PointF GetPoint(this RectangleF rect, ContentAlignment align)
        {
            PointF point;
            switch (align)
            {
                default:
                case ContentAlignment.TopLeft:
                    point = new PointF(rect.X, rect.Y);
                    break;
                case ContentAlignment.TopCenter:
                    point = new PointF(rect.X + rect.Width / 2, rect.Y);
                    break;
                case ContentAlignment.TopRight:
                    point = new PointF(rect.X + rect.Width, rect.Y);
                    break;
                case ContentAlignment.MiddleLeft:
                    point = new PointF(rect.X, rect.Y + rect.Height / 2);
                    break;
                case ContentAlignment.MiddleCenter:
                    point = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                    break;
                case ContentAlignment.MiddleRight:
                    point = new PointF(rect.X + rect.Width, rect.Y + rect.Height / 2);
                    break;
                case ContentAlignment.BottomLeft:
                    point = new PointF(rect.X, rect.Y + rect.Height);
                    break;
                case ContentAlignment.BottomCenter:
                    point = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height);
                    break;
                case ContentAlignment.BottomRight:
                    point = new PointF(rect.X + rect.Width, rect.Y + rect.Height);
                    break;
            }
            return point;
        }
        /// <summary>
        /// 取得矩形的特定座標
        /// </summary>        
        public static Point GetPoint(this Rectangle rect, ContentAlignment align)
        {
            var p = GetPoint((RectangleF)rect, align);
            return Point.Round(p);
        }
        /// <summary>
        /// 平移座標
        /// </summary>        
        public static PointF GetOffset(this PointF point, float x, float y)
        {
            return new PointF(point.X + x, point.Y + y);
        }


        #endregion

        #region 繪圖 Drawing
        /// <summary>
        /// 根據錨點繪製文字
        /// </summary>        
        public static void DrawString(this Graphics g, string s, Font font, Brush brush, PointF location, ContentAlignment align, StringFormat sf = null)
        {
            var size = g.MeasureString(s, font);
            RectangleF rect;
            switch (align)
            {
                default:
                case ContentAlignment.TopLeft:
                    rect = new RectangleF(location.X, location.Y, size.Width, size.Height);
                    break;
                case ContentAlignment.TopCenter:
                    rect = new RectangleF(location.X - size.Width / 2, location.Y, size.Width, size.Height);
                    break;
                case ContentAlignment.TopRight:
                    rect = new RectangleF(location.X - size.Width, location.Y, size.Width, size.Height);
                    break;
                case ContentAlignment.MiddleLeft:
                    rect = new RectangleF(location.X, location.Y - size.Height / 2, size.Width, size.Height);
                    break;
                case ContentAlignment.MiddleCenter:
                    rect = new RectangleF(location.X - size.Width / 2, location.Y - size.Height / 2, size.Width, size.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    rect = new RectangleF(location.X - size.Width, location.Y - size.Height / 2, size.Width, size.Height);
                    break;
                case ContentAlignment.BottomLeft:
                    rect = new RectangleF(location.X, location.Y - size.Height, size.Width, size.Height);
                    break;
                case ContentAlignment.BottomCenter:
                    rect = new RectangleF(location.X - size.Width / 2, location.Y - size.Height, size.Width, size.Height);
                    break;
                case ContentAlignment.BottomRight:
                    rect = new RectangleF(location.X - size.Width, location.Y - size.Height, size.Width, size.Height);
                    break;
            }
            if (sf == null)
                g.DrawString(s, font, brush, rect);
            else
                g.DrawString(s, font, brush, rect, sf);
        }
        /// <summary>
        /// 繪製矩形 (float)
        /// </summary>        
        public static void DrawRectangleF(this Graphics g, Pen pen, RectangleF rect)
        {
            g.DrawRectangles(pen, new RectangleF[] { rect });
        }
        /// <summary>
        /// 繪製圓角
        /// </summary>        
        public static void DrawRound(this Graphics g, Pen pen, Rectangle rect, int radius)
        {
            using (var path = CreateRoundGraphicsPath(rect, radius))
            {
                g.DrawPath(pen, path);
            }
        }
        /// <summary>
        /// 填滿圓角
        /// </summary>        
        public static void FillRound(this Graphics g, Brush brush, Rectangle rect, int radius)
        {
            using (var path = CreateRoundGraphicsPath(rect, radius))
            {
                g.FillPath(brush, path);
            }
        }
        /// <summary>
        /// 繪製適合大小的文字
        /// </summary>        
        public static void DrawScaleString(this Graphics g, string text, Font baseFont, Color foreColor, Rectangle rect, TextFormatFlags textFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter, int padding = 0, IFitFontSizeProvider fontSizeProvider = null, float minimize = 0f, float maximize = 0f)
        {
            var provider = fontSizeProvider ?? BfprtFontEngine.Default;
            var cache = _fontCaches.GetOrAdd(baseFont.FontFamily, fontFamily => new FontCache(fontFamily));
            var fitSize = provider.GetFitSize(minimize, maximize, size =>
            {
                var f = cache.GetFont(size);
                var s = TextRenderer.MeasureText(g, text, f);
                return rect.Size.Contains(s);
            });
            var font = cache.GetFont(fitSize);
            if (padding != 0)
                rect = rect.ApplyPadding(padding);
            TextRenderer.DrawText(g, text, font, rect, foreColor, textFlags);
        }
        /// <summary>
        /// 繪製適合大小的文字
        /// </summary>     
        public static void DrawScaleString(this Graphics g, string text, Font baseFont, Brush brush, RectangleF rect, StringFormat sf, float padding = 0f, IFitFontSizeProvider fontSizeProvider = null, float minimize = 0f, float maximize = 0f)
        {
            var provider = fontSizeProvider ?? BfprtFontEngine.Default;
            var cache = _fontCaches.GetOrAdd(baseFont.FontFamily, fontFamily => new FontCache(fontFamily));
            var fitSize = provider.GetFitSize(minimize, maximize, size =>
            {
                var f = cache.GetFont(size);
                var s = g.MeasureString(text, f);
                return rect.Size.Contains(s);
            });
            var font = cache.GetFont(fitSize);
            if (padding != 0)
                rect = rect.ApplyPadding(padding);
            g.DrawString(text, font, brush, rect, sf);
        }

        public static void SetupContentAlignment(StringFormat sf, ContentAlignment ca)
        {
            StringAlignment sa, lsa;
            switch (ca)
            {
                case ContentAlignment.TopLeft:
                    sa = StringAlignment.Near;
                    lsa = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    sa = StringAlignment.Center;
                    lsa = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    sa = StringAlignment.Far;
                    lsa = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                    sa = StringAlignment.Near;
                    lsa = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleCenter:
                    sa = StringAlignment.Center;
                    lsa = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    sa = StringAlignment.Far;
                    lsa = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    sa = StringAlignment.Near;
                    lsa = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    sa = StringAlignment.Center;
                    lsa = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    sa = StringAlignment.Far;
                    lsa = StringAlignment.Far;
                    break;
                default:
                    throw new NotSupportedException();
            }
            sf.Alignment = sa;
            sf.LineAlignment = lsa;
        }
        public static ContentAlignment GetContentAlignment(StringAlignment alignment, StringAlignment lineAlignment)
        {
            int offset = 0, value = 0;
            switch (lineAlignment)
            {
                case StringAlignment.Near:
                    offset = 0;
                    break;
                case StringAlignment.Center:
                    offset = 4;
                    break;
                case StringAlignment.Far:
                    offset = 8;
                    break;
            }
            switch (alignment)
            {
                case StringAlignment.Near:
                    value = 1;
                    break;
                case StringAlignment.Center:
                    value = 2;
                    break;
                case StringAlignment.Far:
                    value = 4;
                    break;
            }
            return (ContentAlignment)(value << offset);
        }
        #endregion

        #region 區塊 TableRectangle
        public static ColumnStyle[] CreateColumnStyles(int amount)
        {
            var width = 100f / amount;
            return Enumerable.Range(0, amount).Select(r => new ColumnStyle(SizeType.Percent, width)).ToArray();
        }
        public static RowStyle[] CreateRowStyles(int amount)
        {
            var height = 100f / amount;
            return Enumerable.Range(0, amount).Select(r => new RowStyle(SizeType.Percent, height)).ToArray();
        }
        public static RectangleCollection CreateTableRectangle(RectangleF bound, int column = 1, int row = 1)
        {
            var columns = Enumerable.Range(0, column).Select(r => 100f / column).ToArray();
            var rows = Enumerable.Range(0, row).Select(r => 100f / row).ToArray();
            return CreateTableRectangle(bound, columns, rows);
        }

        public static RectangleCollection CreateTableRectangle(RectangleF bound, float[] columns = null, float[] rows = null)
        {
            var styleCol = (columns ?? new float[] { 100f }).Select(r => new ColumnStyle(SizeType.Percent, r)).ToArray();
            var styleRow = (rows ?? new float[] { 100f }).Select(r => new RowStyle(SizeType.Percent, r)).ToArray();
            return CreateTableRectangle(bound, styleCol, styleRow);
        }

        public static RectangleCollection CreateTableRectangle(RectangleF bound, ColumnStyle[] columns = null, RowStyle[] rows = null)
        {
            var valCols = (columns ?? new ColumnStyle[] { new ColumnStyle(SizeType.Percent, 100f) }).Select((r, i) => new RowColumnValue(r.SizeType, r.Width, i)).ToArray();
            var valRows = (rows ?? new RowStyle[] { new RowStyle(SizeType.Percent, 100f) }).Select((r, i) => new RowColumnValue(r.SizeType, r.Height, i)).ToArray();
            return CreateTableRectangle(bound, valCols, valRows);
        }

        public static RectangleCollection CreateTableRectangle(RectangleF bound, RowColumnValue[] columns, RowColumnValue[] rows)
        {
            var rects = new RectangleF[columns.Length * rows.Length];
            var width = bound.Width;
            var height = bound.Height;

            var widLens = Split(width, columns);
            var heiLens = Split(height, rows);

            float x, y = bound.Y;

            for (var r = 0; r < heiLens.Length; r++)
            {
                x = bound.X;
                for (var c = 0; c < widLens.Length; c++)
                {
                    var index = r * widLens.Length + c;
                    rects[index] = new RectangleF(x, y, Math.Max(widLens[c], 0), Math.Max(heiLens[r], 0));
                    x += widLens[c];
                }
                y += heiLens[r];
            }
            return new RectangleCollection(columns.Length, rows.Length, rects);
        }
        public static RectangleF GetRectangle(RectangleF parent, int index, int splitAmount)
        {
            var w = parent.Width / splitAmount;
            return new RectangleF(parent.X + w * index, parent.Y, w, parent.Height);
        }

        public static float[] Split(float len, RowColumnValue[] values)
        {
            var lens = new float[values.Length];
            var group = values.Aggregate(new Dictionary<SizeType, List<RowColumnValue>>(), (seed, r) =>
            {
                if (!seed.ContainsKey(r.SizeType))
                    seed.Add(r.SizeType, new List<RowColumnValue>());
                seed[r.SizeType].Add(r);
                return seed;
            });
            if (group.ContainsKey(SizeType.Absolute))
            {
                foreach (var value in group[SizeType.Absolute])
                {
                    lens[value.Index] = value.Value;
                    len -= value.Value;
                }
            }
            if (group.ContainsKey(SizeType.Percent))
            {
                var totalPercent = group[SizeType.Percent].Sum(r => r.Value);
                foreach (var value in group[SizeType.Percent])
                {
                    var percent = value.Value / totalPercent;
                    lens[value.Index] = len * percent;
                }
            }
            if (group.ContainsKey(SizeType.AutoSize))
                throw new NotSupportedException("unsupported autosize");
            return lens;
        }

        public class RowColumnValue
        {
            public SizeType SizeType { get; set; }
            public float Value { get; set; }
            public int Index { get; set; }

            public RowColumnValue(SizeType sizeType, float value, int index)
            {
                SizeType = sizeType;
                Value = value;
                Index = index;
            }
        }

        public class RectangleCollection : IEnumerable<RectangleF>
        {
            private readonly RectangleF[] _rects;
            private readonly int _columnCount;
            private readonly int _rowCount;

            public RectangleCollection(int column, int row)
            {
                _rects = new RectangleF[column * row];
                _columnCount = column;
                _rowCount = row;
            }
            public RectangleCollection(int column, int row, RectangleF[] rects)
                : this(column, row)
            {
                _rects = rects;
                _columnCount = column;
                _rowCount = row;
            }

            public RectangleF this[int index]
            {
                get { return _rects[index]; }
            }
            public RectangleF this[int row, int column]
            {
                get { return GetRectangle(column, row); }
            }
            public int Length
            {
                get { return _rects.Length; }
            }
            public int ColumnCount
            {
                get { return _columnCount; }
            }

            public int RowCount
            {
                get { return _rowCount; }
            }

            public RectangleF GetLastRow(int column)
            {
                return GetRectangle(column, _rowCount - 1);
            }
            public RectangleF GetFirstRow(int column)
            {
                return GetRectangle(column, 0);
            }
            public RectangleF GetLastColumn(int row)
            {
                return GetRectangle(_columnCount - 1, row);
            }
            public RectangleF GetFirstColumn(int row)
            {
                return GetRectangle(0, row);
            }
            public RectangleF GetRectangle(int column, int row)
            {
                return _rects[row * _columnCount + column];
            }

            IEnumerator<RectangleF> IEnumerable<RectangleF>.GetEnumerator()
            {
                return ((IEnumerable<RectangleF>)_rects).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _rects.GetEnumerator();
            }
        }
        #endregion

        #endregion Drawing

        #region 基礎元件 System.ComponentModel
        /// <summary>
        /// 套用類別的預設值
        /// </summary>
        /// <param name="instance">物件</param>
        /// <param name="targetType">套用類別</param>
        /// <param name="inherit">是否要尋找繼承屬性</param>
        public static void ApplyDefaultValues(this object instance, Type targetType = null, bool inherit = false)
        {
            ApplyDefaultProperties(instance, targetType, inherit);
        }
        #endregion System.ComponentModel

        #endregion
    }

    public static class FmResManager
    {
        private static readonly string _baseNs;

        static FmResManager()
        {
            _baseNs = typeof(FmResManager).Namespace + ".EmbeddedResources";
        }

        public static string GetResourceName(string name)
        {
            return _baseNs + "." + name;
        }
        public static Stream GetResourceStream(string name, bool relativePath = true)
        {
            var n = relativePath ? GetResourceName(name) : name;
            return ResManager.GetResourceStream(typeof(FmResManager).Assembly, n);
        }
        public static string GetResourceString(string name, bool throwOnError = true, bool relativePath = true)
        {
            var n = relativePath ? GetResourceName(name) : name;
            return ResManager.GetResourceString(typeof(FmResManager).Assembly, n, throwOnError);
        }
        public static byte[] GetResourceBytes(string name, bool throwOnError = true, bool relativePath = true)
        {
            var n = relativePath ? GetResourceName(name) : name;
            return ResManager.GetResourceBytes(typeof(FmResManager).Assembly, n, throwOnError);
        }

        public static T GetResource<T>(string name, Func<Stream, T> streamResolver, bool relativePath = true)
        {
            var n = relativePath ? GetResourceName(name) : name;
            return ResManager.GetResource(typeof(FmResManager).Assembly, n, streamResolver);
        }
        public static Icon GetResourceIcon(string name, bool throwOnError = false, bool relativePath = true)
        {
            var n = relativePath ? GetResourceName(name) : name;
            return ResManager.GetResource(typeof(FmResManager).Assembly, n, s => s == null ? null : new Icon(s), throwOnError);
        }
        public static Image GetResourceImage(string name, bool throwOnError = false, bool relativePath = true)
        {
            var n = relativePath ? GetResourceName(name) : name;
            return ResManager.GetResource(typeof(FmResManager).Assembly, n, s => s == null ? null : Image.FromStream(s), throwOnError);
        }


        internal class ResManager
        {
            private readonly Assembly _assembly;
            private readonly Dictionary<string, object> _resCache;
            public ResManager(Assembly assembly)
            {
                _assembly = assembly;
                _resCache = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            }


            public Stream GetStream(string name, bool throwOnError = true)
            {
                var stream = _assembly.GetManifestResourceStream(name);
                if (stream == null && throwOnError)
                    throw new InvalidOperationException("resource '" + name + "' is not exists");
                return stream;
            }

            public string GetString(string name, bool throwOnError = true)
            {
                return Get(name, stream =>
                {
                    if (stream == null) return null;
                    using (var sr = new StreamReader(stream))
                        return sr.ReadToEnd();
                }, throwOnError);
            }

            public byte[] GetBytes(string name, bool throwOnError = true)
            {
                return Get(name, (stream) =>
                {
                    if (stream == null) return null;
                    var buffer = new byte[4096];
                    var readBytes = 0;
                    using (var ms = new MemoryStream())
                    {
                        while ((readBytes = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            ms.Write(buffer, 0, readBytes);
                            ms.Flush();
                        }
                        return ms.ToArray();
                    }
                }, throwOnError);
            }
            public T Get<T>(string name, Func<Stream, T> factory, bool throwOnError = true)
            {
                object resource;
                if (!_resCache.TryGetValue(name, out resource))
                {
                    using (var stream = GetStream(name, throwOnError))
                    {
                        resource = factory(stream);
                        _resCache.Add(name, resource);
                    }
                }
                return (T)resource;
            }
            private static readonly Dictionary<Assembly, ResManager> _cache
                = new Dictionary<Assembly, ResManager>();
            private static ResManager GetResManager(Assembly assembly)
            {
                ResManager manager;
                if (!_cache.TryGetValue(assembly, out manager))
                {
                    manager = new ResManager(assembly);
                    _cache.Add(assembly, manager);
                }
                return manager;
            }
            public static Stream GetResourceStream(Assembly assembly, string name)
            {
                return GetResManager(assembly).GetStream(name);
            }
            public static string GetResourceString(Assembly assembly, string name, bool throwOnError = true)
            {
                return GetResManager(assembly).GetString(name, throwOnError);
            }
            public static byte[] GetResourceBytes(Assembly assembly, string name, bool throwOnError = true)
            {
                return GetResManager(assembly).GetBytes(name, throwOnError);
            }

            public static T GetResource<T>(Assembly assembly, string name, Func<Stream, T> streamResolver, bool throwOnError = true)
            {
                return GetResManager(assembly).Get(name, streamResolver, throwOnError);
            }


            public static string GetResourceString(Type referenceType, string name, bool throwOnError = true)
            {
                var tuple = Resolve(referenceType, name);
                return GetResourceString(tuple.Item1, tuple.Item2, throwOnError);
            }
            public static byte[] GetResourceBytes(Type referenceType, string name, bool throwOnError = true)
            {
                var tuple = Resolve(referenceType, name);
                return GetResourceBytes(tuple.Item1, tuple.Item2, throwOnError);
            }

            public static T GetResource<T>(Type referenceType, string name, Func<Stream, T> streamResolver, bool throwOnError = true)
            {
                var tuple = Resolve(referenceType, name);
                return GetResource(tuple.Item1, tuple.Item2, streamResolver, throwOnError);
            }

            private static Tuple<Assembly, string> Resolve(Type referenceType, string name)
            {
                var assembly = referenceType.Assembly;
                var n = referenceType.Namespace + "." + name;
                return Tuple.Create(assembly, n);
            }
        }

        #region 系統Icon
        /// <summary>
        /// 取得系統Icon
        /// </summary>        
        public static Icon GetSystemIcon(uint iconId)
        {
            var info = new Native.SHSTOCKICONINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            Native.Shell32.SHGetStockIconInfo(iconId, Native.SHGFI_ICON | Native.SHGFI_LARGEICON, ref info);
            var icon = (Icon)Icon.FromHandle(info.hIcon).Clone();
            Native.User32.DestroyIcon(info.hIcon);
            return icon;
        }
        public static Icon GetSystemIcon(string path)
        {
            if (!File.Exists(path) && !Directory.Exists(path))
                return null; // 沒有找到Icon
            else if (Directory.Exists(path))
                return GetSystemIcon(Native.SIID_FOLDER);
            else
                return Icon.ExtractAssociatedIcon(path);
        }
        #endregion
    }
    /// <summary>
    /// 訊息工具
    /// </summary>
    public static class MsgBoxHelper
    {
        public static string Caption { get; set; }
        public static void Error(string message, string caption = null)
        {
            MessageBox.Show(
                message,
                caption ?? Caption ?? AppDomain.CurrentDomain.FriendlyName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1
            );
        }
        public static void Error(string message, Exception exception, string caption = null)
        {
            MessageBox.Show(
                string.Format("{0}:{1}", message, exception.Message),
                caption ?? Caption ?? AppDomain.CurrentDomain.FriendlyName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1
            );
        }
        public static void Warning(string message, string caption = null)
        {
            MessageBox.Show(
                message,
                caption ?? Caption ?? AppDomain.CurrentDomain.FriendlyName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1
            );
        }
        public static void Info(string message, string caption = null)
        {
            MessageBox.Show(
                message,
                caption ?? Caption ?? AppDomain.CurrentDomain.FriendlyName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1
            );
        }
        public static bool YesNo(string message, string caption = null, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            return MessageBox.Show(
                message,
                caption ?? Caption ?? AppDomain.CurrentDomain.FriendlyName,
                MessageBoxButtons.YesNo,
                icon,
                MessageBoxDefaultButton.Button1
            ) == DialogResult.Yes;
        }
    }
    /// <summary>
    /// 基礎選項元件
    /// </summary>
    public abstract class OptionItem
    {
        private Lazy<string> _lazyText;
        private Lazy<object> _lazyValue;
        private readonly Delegate _textResolver;
        private readonly Delegate _valueResolver;

        protected OptionItem(object item)
        {
            Item = item;
        }
        public OptionItem(object item, Delegate textResolver, Delegate valueResolver) : this(item)
        {
            _textResolver = textResolver;
            _valueResolver = valueResolver;
            _lazyText = new Lazy<string>(_GetResolvedText);
            _lazyValue = new Lazy<object>(_GetResolvedValue);
        }
        public OptionItem(object item, string text, object value) : this(item)
        {
            _lazyText = new Lazy<string>(() => text);
            _lazyValue = new Lazy<object>(() => value);
        }

        public OptionItem(string text)
            : this(text, text, text)
        {
        }

        public object Item { get; private set; }
        public string Text
        {
            get { return _lazyText.Value; }
        }
        public object Value
        {
            get { return _lazyValue.Value; }
        }

        private string _GetResolvedText()
        {
            return (string)_textResolver.DynamicInvoke(Item);
        }
        private object _GetResolvedValue()
        {
            return _valueResolver.DynamicInvoke(Item);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})",
                _lazyText.IsValueCreated ? _lazyText.Value : "_LazyValue_",
                _lazyValue.IsValueCreated ? _lazyValue.Value : "_LazyValue_");
        }
    }
}

