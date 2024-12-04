using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PdfImageExtractor
{
    public class PDFImageManager
    {
        public static Image GetFixedInvertedImage(Image img)
        {
            if (ShowMsg)
            {
                //Module.ShowMessage("1");
                ShowMsg = false;
            }

            //3return Convert(img);

            Bitmap bmp = (Bitmap)img;

            BitmapData bData = bmp.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int lineSize = bData.Width * 3;
            int byteCount = lineSize * bData.Height;
            byte[] bmpBytes = new byte[byteCount];
            byte[] tempLine = new byte[lineSize];
            int bmpIndex = 0;

            IntPtr scan = new IntPtr(bData.Scan0.ToInt32() + (lineSize * (bData.Height - 1)));

            for (int i = 0; i < bData.Height; i++)
            {
                Marshal.Copy(scan, tempLine, 0, lineSize);
                scan = new IntPtr(scan.ToInt32() - bData.Stride);
                tempLine.CopyTo(bmpBytes, bmpIndex);
                bmpIndex += lineSize;
            }

            bmp.UnlockBits(bData);

            return (Image)bmp;
        }

        private static bool ShowMsg = true;

        public static Image Convert(Image img)
        {            
            if (ShowMsg)
            {
                //Module.ShowMessage("1");
                ShowMsg = false;
            }
            Bitmap imgFullSize = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(imgFullSize))
            {
                g.DrawImage(img, 0, 0, img.Width, img.Height);                
            }

            Bitmap clone = new Bitmap(imgFullSize);

            return (Image)clone;
        }
    }
}
