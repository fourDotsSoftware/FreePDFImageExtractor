using System;
using System.Collections.Generic;
using System.Text;

namespace PdfImageExtractor
{
    class ImageInverter
    {
        public static System.Drawing.Image InvertImage(System.Drawing.Image img)
        {
            System.Drawing.Bitmap pic = new System.Drawing.Bitmap(img);

            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    System.Drawing.Color inv = pic.GetPixel(x, y);
                    inv = System.Drawing.Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }

            return (System.Drawing.Image)pic;
        }


    }
}
