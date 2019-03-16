#define test
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;


namespace Time.Code
{
    public class globalKeyboardHook : Modifine_string, HootKeys
    {
        public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);

        public struct keyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        public List<Keys> HookedKeys = new List<Keys>();

        IntPtr hhook = IntPtr.Zero;
        IntPtr hhook_site = IntPtr.Zero;

        public event System.Windows.Forms.KeyEventHandler KeyDown;
        public event System.Windows.Forms.KeyEventHandler KeyUp;

      
        public event Modifine_String _Modifine_string;
        public event Hoot_Keys hoot_Keys;

        Convert_Key _convert;

        string last_hootkey = "";

        int? _Index_Cell;
        public void Set_index_cell(int? i)
        {
            try
            {
                _Index_Cell = i;
            }
            catch
            {
                _Index_Cell = null;
            }
        }


        bool _is_edit_Cell;
        public void Is_edit_Cell(bool i)
        {
            
            _is_edit_Cell = i;

            
        }

        public globalKeyboardHook()
        {
            _convert = new Convert_Key();
        
            hook();
        }

        ~globalKeyboardHook()
        {
            unhook();
        }


        #region keyboar
        private static keyboardHookProc callbackDelegate;

        public void hook()
        {
            try
            {
                if (callbackDelegate != null) throw new InvalidOperationException("Can't hook more than once");
                IntPtr hInstance = LoadLibrary("User32");


                callbackDelegate = new keyboardHookProc(hookProc);
                hhook = SetWindowsHookEx(WH_KEYBOARD_LL, callbackDelegate, hInstance, 0);

                hhook_site = SetWindowsHookEx(WH_KEYBOARD_LL, callbackDelegate, hInstance, 0);


                if (hhook == IntPtr.Zero)
                    throw new Win32Exception();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        public void unhook()
        {
            try
            {
                if (callbackDelegate == null) return;
                bool ok = UnhookWindowsHookEx(hhook);
                if (!ok)
                    throw new Win32Exception();
                callbackDelegate = null;
            }catch(Exception ex)
            {
                Log.Write(ex);
            }
        }

        public int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
        {
            if (code >= 0)
            {

                try { 
                Keys key = (Keys)lParam.vkCode;
                if (!HookedKeys.Contains(key) && key != Keys.Enter && key != Keys.Back)
                {

                    System.Windows.Forms.KeyEventArgs kea = new System.Windows.Forms.KeyEventArgs(key);
                    if (kea.KeyCode != Keys.Back
                        && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))/* && (KeyDown != null)*/
                    {


                        if (_is_edit_Cell && _Index_Cell == 1)
                        {
                            _Modifine_string.Invoke(_convert.KeyDown(key.ToString()));
                            return 1;
                        }
                        else 
                        {
                            try
                            {
                                var now_hootkey = _convert.KeyDown(key.ToString());

                                if (now_hootkey.CompareTo(last_hootkey) != 0)
                                    hoot_Keys.Invoke(now_hootkey);

                                last_hootkey = now_hootkey;
                            }
                            catch
                            {
                                _convert.Clean();
                            }

                        }
                      
                        // KeyDown(this, kea);
                    }
                    else if (kea.KeyCode != Keys.Back && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP) /*&& (KeyUp != null)*/)
                    {
                        if (_is_edit_Cell && _Index_Cell == 1)
                        {
                            _convert.KeyUp(key.ToString());
                            return 1;
                        }
                        else
                        {

                            _convert.KeyUp(key.ToString());
                          
                        }
                        // KeyUp(this, kea);
                    }
                    // if (kea.Handled)
                    //   return 1;


                }



                }
                catch (Exception ex)
                {
#if test
                    Log.Write(ex);
                    System.Windows.MessageBox.Show(ex.Message);
#endif 
                }
            }
            return CallNextHookEx(hhook, code, wParam, ref lParam);
        }
#endregion keyboar


        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);


        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

    }
}
