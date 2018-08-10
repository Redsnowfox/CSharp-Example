using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SharedTools {
    public static class Win32 {
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_LBUTTONDBLCLK = 0x0203;

        public const int WM_MOUSELEAVE = 0x02A3;

        public const int WM_PAINT = 0x000F;
        public const int WM_ERASEBKGND = 0x0014;

        public const int WM_PRINT = 0x0317;

        public const int WM_HSCROLL = 0x0114;
        public const int WM_VSCROLL = 0x0115;

        public const int EM_GETSEL = 0x00B0;
        public const int EM_LINEINDEX = 0x00BB;
        public const int EM_LINEFROMCHAR = 0x00C9;

        public const int EM_POSFROMCHAR = 0x00D6;

        [DllImport("USER32.DLL", CharSet = CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint msg, 
            int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("USER32.DLL")]
        private static extern bool SendMessage(IntPtr hwnd, int msg, 
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wParam, int lParam);

        [DllImport("USER32.DLL", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("USER32.DLL", EntryPoint = "GetCaretBlinkTime")]
        public static extern uint GetCaretBlinkTime();

        private const long PRF_CLIENT = 0x00000004L;
        private const long PRF_ERASEBKGND = 0x00000008L;
        public static bool CaptureWindow(this Control control, ref Bitmap bitmap) {
            //This function captures the contents of a window or control
            var g2 = Graphics.FromImage(bitmap);

            //PRF_CHILDREN // PRF_NONCLIENT
            const int meint = (int) (PRF_CLIENT | PRF_ERASEBKGND); //| PRF_OWNED ); //  );
            var meptr = new IntPtr(meint);

            var hdc = g2.GetHdc();
            SendMessage(control.Handle, WM_PRINT, hdc, meptr);

            g2.ReleaseHdc(hdc);
            g2.Dispose();

            return true;
        }

        private const int EM_SETCUEBANNER = 0x1501;
        private const int CB_SETCUEBANNER = 0x1703;
        public static void SetCueBanner(this Control control, string banner) {
            if (control is ComboBox) {
                SendMessage(control.Handle, CB_SETCUEBANNER, 0, banner);
            } else {
                SendMessage(control.Handle, EM_SETCUEBANNER, 0, banner);
            }
        }

        private const int EM_GETCUEBANNER = 0x1502;
        private const int CB_GETCUEBANNER = 0x1704;
        public static string GetCueBanner(this Control control) {
            var builder = new StringBuilder(255);
            if (control is ComboBox) {
                SendMessage(control.Handle, CB_GETCUEBANNER, builder, 255);
            } else {
                SendMessage(control.Handle, EM_GETCUEBANNER, builder, 255);
            }
            return builder.ToString();
        }
    }
}
