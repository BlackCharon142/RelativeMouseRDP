using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RelativeMouseRDP
{
    public class Window
    {
        public static Process targetWindow;

        public int ID { get; set; }
        public string WindowName { get; set; }

        public Window(int _ID, string _WindowName)
        {
            ID = _ID;
            WindowName = _WindowName;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        }


        public static bool IsTargetWindowSelected()
        {
            if (targetWindow != null)
                if ((GetActiveWindowProcessId() == targetWindow.Id && GetActiveWindowTitle() == targetWindow.MainWindowTitle))
                    return true;
                else
                    return false;
            return false;
        }

        public static bool IsOverlayOnTop()
        {
            if (targetWindow != null)
                if (GetActiveWindowProcessId() == Process.GetCurrentProcess().Id && GetActiveWindowTitle() == new frm_Overlay().Text)
                    return true;
                else
                    return false;
            return false;
        }

        public static ArrayList GetOpenWindows()
        {
            Process[] processlist = Process.GetProcesses();
            ArrayList openWindowsList = new ArrayList();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.Id != Process.GetCurrentProcess().Id)
                        openWindowsList.Add(new Window(process.Id, process.MainWindowTitle));
                }
            }

            return openWindowsList;
        }

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public static int GetActiveWindowProcessId()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            return p.Id;
        }

        public static void BringMainWindowToFront(string processName)
        {
            // get the process
            Process bProcess = Process.GetProcessesByName(processName).FirstOrDefault();

            // check if the process is running
            if (bProcess != null)
            {
                // check if the window is hidden / minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    // the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.Restore);
                }

                // set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
            }
        }
        public static void BringMainWindowToFront(int processId)
        {
            // get the process
            Process bProcess = Process.GetProcessById(processId);

            // check if the process is running
            if (bProcess != null)
            {
                // check if the window is hidden / minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    // the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.Restore);
                }

                // set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
            }
        }

    }
}
