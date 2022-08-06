using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RelativeMouseRDP
{
    #region Last Input Info

    internal static class LastInputInfo
    {
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        public static uint GetLastInputSeconds()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? (idleTime / 1000) : 0);
        }

        public static uint GetLastInputTime()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? idleTime : 0);
        }
    }

    #endregion

    #region Cursor

    internal static class CursorInfo
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;

            public Int32 flags;


            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        public static IntPtr GetCursorHandle()
        {
            CURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            GetCursorInfo(out pci);

            return pci.hCursor;
        }

        public static CursorType? GetCursorType()
        {
            CURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            GetCursorInfo(out pci);

            return CursorType.GetByHandle(pci.hCursor.ToInt64());
        }
    }

    #region Custom Cursor Types

    public sealed class CursorType
    {
        private static List<CursorType> _cursorList = new List<CursorType>();

        public static CursorType AppStartin = new CursorType(1, Cursors.AppStarting.Handle.ToInt64());
        public static CursorType Arrow = new CursorType(2, Cursors.Arrow.Handle.ToInt64());
        public static CursorType Cross = new CursorType(3, Cursors.Cross.Handle.ToInt64());
        public static CursorType Default = new CursorType(4, Cursors.Default.Handle.ToInt64());
        public static CursorType Hand = new CursorType(5, Cursors.Hand.Handle.ToInt64());
        public static CursorType Help = new CursorType(6, Cursors.Help.Handle.ToInt64());
        public static CursorType HSplit = new CursorType(7, Cursors.HSplit.Handle.ToInt64());
        public static CursorType IBeam = new CursorType(8, Cursors.IBeam.Handle.ToInt64());
        public static CursorType No = new CursorType(9, Cursors.No.Handle.ToInt64());
        public static CursorType NoMove2D = new CursorType(10, Cursors.NoMove2D.Handle.ToInt64());
        public static CursorType NoMoveHori = new CursorType(11, Cursors.NoMoveHoriz.Handle.ToInt64());
        public static CursorType NoMoveVert = new CursorType(12, Cursors.NoMoveVert.Handle.ToInt64());
        public static CursorType PanEast = new CursorType(13, Cursors.PanEast.Handle.ToInt64());
        public static CursorType PanNE = new CursorType(14, Cursors.PanNE.Handle.ToInt64());
        public static CursorType PanNorth = new CursorType(15, Cursors.PanNorth.Handle.ToInt64());
        public static CursorType PanNW = new CursorType(16, Cursors.PanNW.Handle.ToInt64());
        public static CursorType PanSE = new CursorType(17, Cursors.PanSE.Handle.ToInt64());
        public static CursorType PanSouth = new CursorType(18, Cursors.PanSouth.Handle.ToInt64());
        public static CursorType PanSW = new CursorType(19, Cursors.PanSW.Handle.ToInt64());
        public static CursorType PanWest = new CursorType(20, Cursors.PanWest.Handle.ToInt64());
        public static CursorType SizeAll = new CursorType(21, Cursors.SizeAll.Handle.ToInt64());
        public static CursorType SizeNESW = new CursorType(22, Cursors.SizeNESW.Handle.ToInt64());
        public static CursorType SizeNS = new CursorType(23, Cursors.SizeNS.Handle.ToInt64());
        public static CursorType SizeNWSE = new CursorType(24, Cursors.SizeNWSE.Handle.ToInt64());
        public static CursorType SizeWE = new CursorType(25, Cursors.SizeWE.Handle.ToInt64());
        public static CursorType UpArrow = new CursorType(26, Cursors.UpArrow.Handle.ToInt64());
        public static CursorType VSplit = new CursorType(27, Cursors.VSplit.Handle.ToInt64());
        public static CursorType WaitCursor = new CursorType(28, Cursors.WaitCursor.Handle.ToInt64());

        public byte ID { get; private set; }
        public Cursor Cursor { get; private set; }
        public long Handle { get; private set; }

        private CursorType(byte _ID = 0, long _Handle = 0, Cursor? _Cursor = null)
        {
            if (_ID == 0)
                ID = 4;
            else
                ID = _ID;


            if (_Handle == 0)
                Handle = Cursors.Default.Handle.ToInt64();
            else
                Handle = _Handle;


            if (_Cursor == null)
                Cursor = Cursors.Default;
            else
                Cursor = _Cursor;

            _cursorList.Add(this);
        }

        public static CursorType? GetByID(byte id)
        {
            return _cursorList.Find(x => x.ID == id);
        }

        public static CursorType? GetByHandle(long handle)
        {
            return _cursorList.Find(x => x.Handle == handle);
        }

        public static CursorType? GetCursor(Cursor cursor)
        {
            return _cursorList.Find(x => x.Cursor == cursor);
        }

        public static IEnumerable<CursorType> All()
        {
            return _cursorList;
        }
    }

    /*public class CursorType
    {
        public byte ID { get; }
        public long Handle { get; }

        public CursorType(byte _ID, long _Handle)
        {
            ID = _ID;
            Handle = _Handle;
        }
    }

    public static class CursorTypes
    {
        public static CursorType AppStarting { get; }  = new CursorType(0, Cursors.AppStarting.Handle.ToInt64());
        public static CursorType Arrow       { get; }  = new CursorType(1, Cursors.Arrow.Handle.ToInt64());
        public static CursorType Cross       { get; }  = new CursorType(2, Cursors.Cross.Handle.ToInt64());
        public static CursorType Default     { get; }  = new CursorType(3, Cursors.Default.Handle.ToInt64());
        public static CursorType Hand        { get; }  = new CursorType(4, Cursors.Hand.Handle.ToInt64());
        public static CursorType Help        { get; }  = new CursorType(5, Cursors.Help.Handle.ToInt64());
        public static CursorType HSplit      { get; }  = new CursorType(6, Cursors.HSplit.Handle.ToInt64());
        public static CursorType IBeam       { get; }  = new CursorType(7, Cursors.IBeam.Handle.ToInt64());
        public static CursorType No          { get; }  = new CursorType(8, Cursors.No.Handle.ToInt64());
        public static CursorType NoMove2D    { get; }  = new CursorType(9, Cursors.NoMove2D.Handle.ToInt64());
        public static CursorType NoMoveHoriz { get; }  = new CursorType(10, Cursors.NoMoveHoriz.Handle.ToInt64());
        public static CursorType NoMoveVert  { get; }  = new CursorType(11, Cursors.NoMoveVert.Handle.ToInt64());
        public static CursorType PanEast     { get; }  = new CursorType(12, Cursors.PanEast.Handle.ToInt64());
        public static CursorType PanNE       { get; }  = new CursorType(13, Cursors.PanNE.Handle.ToInt64());
        public static CursorType PanNorth    { get; }  = new CursorType(14, Cursors.PanNorth.Handle.ToInt64());
        public static CursorType PanNW       { get; }  = new CursorType(15, Cursors.PanNW.Handle.ToInt64());
        public static CursorType PanSE       { get; }  = new CursorType(16, Cursors.PanSE.Handle.ToInt64());
        public static CursorType PanSouth    { get; }  = new CursorType(17, Cursors.PanSouth.Handle.ToInt64());
        public static CursorType PanSW       { get; }  = new CursorType(18, Cursors.PanSW.Handle.ToInt64());
        public static CursorType PanWest     { get; }  = new CursorType(19, Cursors.PanWest.Handle.ToInt64());
        public static CursorType SizeAll     { get; }  = new CursorType(20, Cursors.SizeAll.Handle.ToInt64());
        public static CursorType SizeNESW    { get; }  = new CursorType(21, Cursors.SizeNESW.Handle.ToInt64());
        public static CursorType SizeNS      { get; }  = new CursorType(22, Cursors.SizeNS.Handle.ToInt64());
        public static CursorType SizeNWSE    { get; }  = new CursorType(23, Cursors.SizeNWSE.Handle.ToInt64());
        public static CursorType SizeWE      { get; }  = new CursorType(24, Cursors.SizeWE.Handle.ToInt64());
        public static CursorType UpArrow     { get; }  = new CursorType(25, Cursors.UpArrow.Handle.ToInt64());
        public static CursorType VSplit      { get; }  = new CursorType(26, Cursors.VSplit.Handle.ToInt64());
        public static CursorType WaitCursor  { get; }  = new CursorType(27, Cursors.WaitCursor.Handle.ToInt64());
    }*/

    #endregion

    #region Enable Cursor Visibility

    public static class CursorExtensions
    {

        [StructLayout(LayoutKind.Sequential)]
        struct PointStruct
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct CursorInfoStruct
        {
            /// <summary> The structure size in bytes that must be set via calling Marshal.SizeOf(typeof(CursorInfoStruct)).</summary>
            public Int32 cbSize;
            /// <summary> The cursor state: 0 == hidden, 1 == showing, 2 == suppressed (is supposed to be when finger touch is used, but in practice finger touch results in 0, not 2)</summary>
            public Int32 flags;
            /// <summary> A handle to the cursor. </summary>
            public IntPtr hCursor;
            /// <summary> The cursor screen coordinates.</summary>
            public PointStruct pt;
        }

        /// <summary> Must initialize cbSize</summary>
        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(ref CursorInfoStruct pci);

        public static bool IsVisible(this Cursor cursor)
        {
            CursorInfoStruct pci = new CursorInfoStruct();
            pci.cbSize = Marshal.SizeOf(typeof(CursorInfoStruct));
            GetCursorInfo(ref pci);
            // const Int32 hidden = 0x00;
            const Int32 showing = 0x01;
            // const Int32 suppressed = 0x02;
            bool isVisible = ((pci.flags & showing) != 0);
            return isVisible;
        }
    }

    #endregion

    #endregion

    #region Data String

    public static class InputData
    {
        #region Indicators

        enum Input
        {
            Key = 'K',
            Mouse = 'M'
        }

        enum KeyEvent
        {
            Down = 'D',
            Up = 'U'
        }

        enum MouseEvent
        {
            MoveDelta = 'V',
            MovePosition = 'P',
            Scroll = 'S'
        }

        enum Movement
        {
            X = 'X',
            Y = 'Y'
        }

        enum Option
        {
            CursorState = 'C',
            SpeedTest = 'T',
            Compression = 'Z'
        }

        #endregion

        public static Keys DownKey { get; private set; }
        public static Keys UpKey { get; private set; }

        public static MouseButtons DownButton { get; private set; }
        public static MouseButtons UpButton { get; private set; }

        public static int CursorPositionX { get; private set; }
        public static int CursorPositionY { get; private set; }

        public static int CursorDeltaX { get; private set; }
        public static int CursorDeltaY { get; private set; }

        public static bool RequestCursorState { get; private set; }
        public static bool NotifySpeedTest { get; private set; }
        public static bool NotifyCompression { get; private set; }


        private static void ResetData()
        {
            DownKey = Keys.None;
            UpKey = Keys.None;

            DownButton = MouseButtons.None;
            UpButton = MouseButtons.None;

            CursorPositionX = 0;
            CursorPositionY = 0;
        }

        public static void SendData()
        {
            /*things happening*/

            ResetData();
        }

        #region Set Data

        #region DownEvents

        public static void DownEvent(Keys keysDown)
        {
            DownKey = keysDown;
        }

        public static void DownEvent(MouseButtons buttonsDown)
        {
            DownButton = buttonsDown;
        }

        #endregion

        #region UpEvents

        public static void UpEvent(Keys keysUp)
        {
            UpKey = keysUp;
        }

        public static void UpEvent(MouseButtons buttonsUp)
        {
            UpButton = buttonsUp;
        }

        #endregion

        public static void Position(Point position)
        {
            CursorPositionX = position.X;
            CursorPositionY = position.Y;
        }

        public static void Delta(Point delta)
        {
            CursorDeltaX = delta.X;
            CursorDeltaY = delta.Y;
        }

        public static void Options(bool requestCursorState, bool notifySpeedTest, bool notifyCompression)
        {
            RequestCursorState = requestCursorState;
            NotifySpeedTest = notifySpeedTest;
            NotifyCompression = notifyCompression;
        }

        #endregion
    }

    #endregion
}
