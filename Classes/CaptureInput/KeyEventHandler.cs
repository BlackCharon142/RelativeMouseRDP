using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHook;
using KeyEventArgs = WindowsHook.KeyEventArgs;
using KeyPressEventArgs = WindowsHook.KeyPressEventArgs;

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

            if ((key != System.Windows.Forms.Keys.Control) || (key != System.Windows.Forms.Keys.ControlKey) || (key != System.Windows.Forms.Keys.RControlKey) || (key != System.Windows.Forms.Keys.LControlKey))
                if ((key != System.Windows.Forms.Keys.Alt) || (key != System.Windows.Forms.Keys.Menu) || (key != System.Windows.Forms.Keys.RMenu) || (key != System.Windows.Forms.Keys.LMenu))
                    if ((key != System.Windows.Forms.Keys.Shift) || (key != System.Windows.Forms.Keys.ShiftKey) || (key != System.Windows.Forms.Keys.RShiftKey) || (key != System.Windows.Forms.Keys.LShiftKey))
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

    public static class KeyEventHandler
    {
        private static IKeyboardMouseEvents m_GlobalHook;
        public static bool IgnoreKeys { get; set; } = true;
        private static ShortcutKeys keysDown = new ShortcutKeys(false, false, false, Normalize(WindowsHook.Keys.None));


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
                if ((e.KeyCode == WindowsHook.Keys.Control) || (e.KeyCode == WindowsHook.Keys.ControlKey) || (e.KeyCode == WindowsHook.Keys.RControlKey) || (e.KeyCode == WindowsHook.Keys.LControlKey))
                {
                    keysDown.Control = true;
                    InputData.DownEvent(Normalize(e.KeyData));
                    return;
                }

                if ((e.KeyCode == WindowsHook.Keys.Alt) || (e.KeyCode == WindowsHook.Keys.Menu) || (e.KeyCode == WindowsHook.Keys.RMenu) || (e.KeyCode == WindowsHook.Keys.LMenu))
                {
                    keysDown.Alt = true;
                    InputData.DownEvent(Normalize(e.KeyData));
                    return;
                }

                if ((e.KeyCode == WindowsHook.Keys.Shift) || (e.KeyCode == WindowsHook.Keys.ShiftKey) || (e.KeyCode == WindowsHook.Keys.RShiftKey) || (e.KeyCode == WindowsHook.Keys.LShiftKey))
                {
                    keysDown.Shift = true;
                    InputData.DownEvent(Normalize(e.KeyData));
                    return;
                }


                keysDown = new ShortcutKeys(keysDown.Control, keysDown.Alt, keysDown.Shift, Normalize(e.KeyCode));

                if (keysDown.Compare(ShortcutFastActionMenu) == true)
                {
                    OverlaySettings.OpenOverlayFastActionMenu();
                    e.Handled = true;
                    return;
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
                keysDown = new ShortcutKeys(keysDown.Control, keysDown.Alt, keysDown.Shift, keysDown.Key);

                if ((e.KeyCode == WindowsHook.Keys.Control) || (e.KeyCode == WindowsHook.Keys.ControlKey) || (e.KeyCode == WindowsHook.Keys.RControlKey) || (e.KeyCode == WindowsHook.Keys.LControlKey))
                {
                    keysDown.Control = false;
                    InputData.UpEvent(Normalize(e.KeyData));
                    return;
                }

                if ((e.KeyCode == WindowsHook.Keys.Alt) || (e.KeyCode == WindowsHook.Keys.Menu) || (e.KeyCode == WindowsHook.Keys.RMenu) || (e.KeyCode == WindowsHook.Keys.LMenu))
                {
                    keysDown.Alt = false;
                    InputData.UpEvent(Normalize(e.KeyData));
                    return;
                }

                if ((e.KeyCode == WindowsHook.Keys.Shift) || (e.KeyCode == WindowsHook.Keys.ShiftKey) || (e.KeyCode == WindowsHook.Keys.RShiftKey) || (e.KeyCode == WindowsHook.Keys.LShiftKey))
                {
                    keysDown.Shift = false;
                    InputData.UpEvent(Normalize(e.KeyData));
                    return;
                }


                keysDown.Key = System.Windows.Forms.Keys.None;

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
