using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PdfImageExtractor
{
    class ResolutionHelper
    {
        public static Bitmap SetResolution(Bitmap img, int xdpi, int ydpi)
        {
            img.SetResolution((float)xdpi, (float)ydpi);

            return img;
        }
    }
}
