﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GraphicEngine
{
    class HotKey
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
        IntPtr hWnd,
        int id,
        KeyModifiers fsModifiers,
        Keys vk
        );
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
        IntPtr hWnd,
        int id
        );
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
    }
}
