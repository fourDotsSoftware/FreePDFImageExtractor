using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PdfImageExtractor
{
    class FlipRotateHelper
    {
        public static Bitmap FlipRotate(Bitmap img, bool rotright90, bool rotleft90, bool rot180, bool fliph, bool flipv)        
        {
            if (rotright90)
            {
                img = RotRight90(img);
            }

            if (rotleft90)
            {
                img = RotLeft90(img);
            }

            if (rot180)
            {
                img = Rot180(img);
            }

            if (fliph)
            {
                img = FlipHorizontal(img);
            }

            if (flipv)
            {
                img = FlipVertical(img);
            }

            return img;
        }

        public static Bitmap RotRight90(Bitmap img)
        {            
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            return img;
        }               

        public static Bitmap RotLeft90(Bitmap img)
        {            
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);

            return img;
        }
        
        public static Bitmap Rot180(Bitmap img)
        {
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);

            return img;
        }
        
        public static Bitmap FlipHorizontal(Bitmap img)
        {            
            img.RotateFlip(RotateFlipType.RotateNoneFlipX);

            return img;
        }                

        public static Bitmap FlipVertical(Bitmap img)
        {            
            img.RotateFlip(RotateFlipType.RotateNoneFlipY);

            return img;
        }

    }
}
