using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Time.Code
{
    class TopWindow
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern long SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);



        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);

        public void Top_Window(string name)
        {
            uint flags = 0x0001 | 0x0002;
            IntPtr w = FindWindow(null, name);
            SetWindowPos(w, (IntPtr)(-1), 1, 1, 0, 0, flags);
        }

        public void Top_All_Window(string name)
        {
            Process[] procs = Process.GetProcessesByName(name);
            foreach (Process p in procs)
            {
                ShowWindow(p.MainWindowHandle, 1);
                SetForegroundWindow(p.MainWindowHandle);
            }
        }
    }
}
