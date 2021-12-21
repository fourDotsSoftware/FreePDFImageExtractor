using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FreeImageAPI;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    public class IconHelper
    {
        public static void SaveAsIcon(string filepath, Bitmap img)
        {            
            FreeImage.SaveBitmap(img, filepath, FREE_IMAGE_FORMAT.FIF_ICO, FREE_IMAGE_SAVE_FLAGS.DEFAULT);
        }

    }
}
