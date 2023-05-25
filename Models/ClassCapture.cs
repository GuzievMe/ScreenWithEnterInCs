using System;
using System.Drawing;
using System.Runtime.InteropServices;


namespace StreamAtLesson_8May.Models
{
    public  class ClassCapture
    {
        public static Bitmap CaptureScreen()
        {
            Rectangle bounds = ScreenBounds();
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            }

            return screenshot;
        }

        static Rectangle ScreenBounds()
        {
            IntPtr screen = GetDesktopWindow();
            GetWindowRect(screen, out RECT bounds);
            return new Rectangle(bounds.Left, bounds.Top, bounds.Right - bounds.Left, bounds.Bottom - bounds.Top);
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


    }

  

}

/////////////////////


