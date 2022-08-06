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
    public static class OverlaySettings
    {
        static frm_Overlay overlay = new frm_Overlay();
        static Rect bounds = new Rect();


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        public static bool Exist()
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == overlay.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public static void MakeOverlay()
        {
            overlay = new frm_Overlay();
            overlay.Show();
        }

        public static void CloseOverlay()
        {
            overlay.Close();
        }

        public static void DisableOverlay()
        {
            overlay.Opacity = 0;
        }

        public static void EnableOverlay()
        {
            overlay.Opacity = 1;
            overlay.BringToFront();
            overlay.Focus();
        }

        public static void OpenOverlayFastActionMenu()
        {
            if (Exist())
            {
                overlay.OpenFastActionMenu();
            }
        }

        public static string DrawOverWindowsRect(int programID)
        {
            try
            {
                Process lol = Process.GetProcessById(programID);
                IntPtr ptr = lol.MainWindowHandle;
                Rect programRect = new Rect();
                GetWindowRect(ptr, ref programRect);

                if ((programRect.Right - Math.Abs(programRect.Left)) >= Screen.PrimaryScreen.Bounds.Width && (programRect.Bottom - Math.Abs(programRect.Top)) >= Screen.PrimaryScreen.Bounds.Height)
                {
                    programRect.Left = 0;
                    programRect.Right = Screen.PrimaryScreen.Bounds.Width;
                    programRect.Top = 1;
                    programRect.Bottom = Screen.PrimaryScreen.Bounds.Height;
                }
                else
                {
                    programRect.Left = programRect.Left + 9;
                    programRect.Right = programRect.Right - 9;
                    programRect.Top = (programRect.Top < 0 ? programRect.Top + 9 : programRect.Top) + SystemInformation.CaptionHeight;
                    programRect.Bottom = programRect.Bottom - 9;
                }

                overlay.SetLocation(programRect.Top, programRect.Left);
                overlay.SetSize(programRect.Right - Math.Abs(programRect.Left), programRect.Bottom - Math.Abs(programRect.Top));

                bounds = programRect;

                return string.Format("Left: {0}\r\nTop: {1}\r\nRight: {2}\r\nBottom: {3}\r\nWidth: {4}\r\nHight: {5}", programRect.Left, programRect.Top, programRect.Right, programRect.Bottom, programRect.Right - Math.Abs(programRect.Left), programRect.Bottom - Math.Abs(programRect.Top));
            }
            catch
            {
                return "ERROR";
            }
        }
    }
}
