using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHook;
//using SharpHook;
//using SharpHook.Reactive;

namespace RelativeMouseRDP
{
    public class ShortcutKeys
    {
        public bool Control { get; set; }
        public bool Alt { get; set; }
        public bool Shift { get; set; }
        public System.Windows.Forms.Keys Key { get; set; }

        public ShortcutKeys(bool control = false, bool alt = false, bool shift = false, System.Windows.Forms.Keys key = System.Windows.Forms.Keys.None)
        {
            Control = control;
            Alt = alt;
            Shift = shift;

            if ((key != System.Windows.Forms.Keys.Control) && (key != System.Windows.Forms.Keys.ControlKey) && (key != System.Windows.Forms.Keys.RControlKey) && (key != System.Windows.Forms.Keys.LControlKey))
                if ((key != System.Windows.Forms.Keys.Alt) && (key != System.Windows.Forms.Keys.Menu) && (key != System.Windows.Forms.Keys.RMenu) && (key != System.Windows.Forms.Keys.LMenu))
                    if ((key != System.Windows.Forms.Keys.Shift) && (key != System.Windows.Forms.Keys.ShiftKey) && (key != System.Windows.Forms.Keys.RShiftKey) && (key != System.Windows.Forms.Keys.LShiftKey))
                    {
                        Key = key;
                        return;
                    }

            Key = System.Windows.Forms.Keys.None;
        }

        public bool? Compare(ShortcutKeys keys)
        {
            if (Control == keys.Control)
            {
                if (Alt == keys.Alt)
                {
                    if (Shift == keys.Shift)
                    {
                        if (Key == keys.Key)
                        {
                            return true;
                        }
                    }
                }
                return null;
            }
            return false;
        }

        public System.Windows.Forms.Keys GetKeys()
        {
            System.Windows.Forms.Keys key = new System.Windows.Forms.Keys();

            if (Key != System.Windows.Forms.Keys.None)
                key |= Key;

            if (Shift)
                key |= System.Windows.Forms.Keys.Shift;

            if (Alt)
                key |= System.Windows.Forms.Keys.Alt;

            if (Control)
                key |= System.Windows.Forms.Keys.Control;

            return key;
        }
    }

    /*public static class KeyEventHandler
    {
        static SimpleReactiveGlobalHook hook = new SimpleReactiveGlobalHook();

        public static void StartHook()
        {
            StopHook();
            hook.KeyPressed.Subscribe(M_GlobalHook_KeyDown);
            hook.KeyReleased.Subscribe(M_GlobalHook_KeyUp);
            hook.Run();
        }

        public static void StopHook()
        {
            if (hook == null)
                return;
            hook.Dispose();
        }

        private static void M_GlobalHook_KeyDown(KeyboardHookEventArgs e)
        {
            if (OverlaySettings.Exist())
            {
                ShortcutKeys keysDown = new ShortcutKeys(e.Data., e.Alt, e.Shift, Normalize(e.KeyCode));

                if (e.Control)
                {

                }

                if (keysDown == ShortcutFastActionMenu)
                {
                    OverlaySettings.OpenOverlayFastActionMenu();
                }

                if (!IgnoreKeys)
                {
                    InputData.DownEvent(Normalize(e.KeyData));
                    e.Handled = true;
                    return;
                }
            }
        }

        private static void M_GlobalHook_KeyUp(KeyboardHookEventArgs args)
        {
            if (OverlaySettings.Exist())
            {
                if (!IgnoreKeys)
                {
                    InputData.UpEvent(Normalize(e.KeyData));
                    e.Handled = true;
                    return;
                }
            }
        }
    }*/

    public static class KeyEventHandler
    {
        //Upgrade to https://github.com/TolikPylypchuk/SharpHook
        private static IKeyboardMouseEvents m_GlobalHook;

        public static bool IgnoreKeys { get; set; } = true;

        /*private static WindowsHook.Keys shortcutFastActionMenu = WindowsHook.Keys.F8 | WindowsHook.Keys.Control;

        public static System.Windows.Forms.Keys ShortcutFastActionMenu
        {
            get { return (System.Windows.Forms.Keys)shortcutFastActionMenu; }

            set
            {
                shortcutFastActionMenu = (WindowsHook.Keys)value;
            }
        }*/

        #region Fast Action Menu Shortcut

        /*private static List<System.Windows.Forms.Keys> shortcutFastActionMenu = new List<System.Windows.Forms.Keys>();

        public static System.Windows.Forms.Keys GetShortcutFastActionMenuKeys()
        {
            System.Windows.Forms.Keys keys = new System.Windows.Forms.Keys();

            for (int i = 0; i < shortcutFastActionMenu.Count; i++)
            {
                keys |= shortcutFastActionMenu[i];
            }

            return keys;
        }

        public static void SetFastActionMenuKeys()
        {

        }*/

        #endregion

        public static ShortcutKeys ShortcutFastActionMenu { get; set; } = new ShortcutKeys(true, false, false, System.Windows.Forms.Keys.F8);

        public static System.Windows.Forms.Keys Normalize(WindowsHook.Keys keys)
        {
            return (System.Windows.Forms.Keys)keys;
        }

        public static void StartHook()
        {
            StopHook();
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += M_GlobalHook_KeyDown;
            m_GlobalHook.KeyUp += M_GlobalHook_KeyUp;
        }

        private static void M_GlobalHook_KeyDown(object sender, WindowsHook.KeyEventArgs e)
        {
            if (OverlaySettings.Exist())
            {
                ShortcutKeys keysDown = new ShortcutKeys(e.Control, e.Alt, e.Shift, Normalize(e.KeyCode));

                /*if (keysDown.Compare(ShortcutFastActionMenu) == null)
                {
                    return;
                }*/

                if (e.Control)
                {

                }

                if (keysDown == ShortcutFastActionMenu)
                {
                    OverlaySettings.OpenOverlayFastActionMenu();
                }

                if (!IgnoreKeys)
                {
                    InputData.DownEvent(Normalize(e.KeyData));
                    e.Handled = true;
                    return;
                }
            }
        }

        private static void M_GlobalHook_KeyUp(object sender, WindowsHook.KeyEventArgs e)
        {
            if (OverlaySettings.Exist())
            {
                if (!IgnoreKeys)
                {
                    InputData.UpEvent(Normalize(e.KeyData));
                    e.Handled = true;
                    return;
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
