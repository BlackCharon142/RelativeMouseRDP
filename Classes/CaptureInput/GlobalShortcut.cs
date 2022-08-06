using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHook;

namespace RelativeMouseRDP
{
    public static class GlobalShortcut
    {
        private static WindowsHook.Keys shortcutFastActionMenu = WindowsHook.Keys.F8 | WindowsHook.Keys.Control;

        public static System.Windows.Forms.Keys ShortcutFastActionMenu
        {
            get { return (System.Windows.Forms.Keys)shortcutFastActionMenu; }
            set { shortcutFastActionMenu = (WindowsHook.Keys)value; }
        }

        private static IKeyboardMouseEvents m_GlobalHook;

        public static void StartHook()
        {
            StopHook();
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += M_GlobalHook_KeyDown;
        }

        private static void M_GlobalHook_KeyDown(object sender, WindowsHook.KeyEventArgs e)
        {
            if (OverlaySettings.Exist())
            {
                if (e.KeyData == shortcutFastActionMenu)
                {
                    OverlaySettings.OpenOverlayFastActionMenu();
                }
            }
        }

        public static void StopHook()
        {
            if (m_GlobalHook == null)
                return;
            m_GlobalHook.Dispose();
        }
    }
}
