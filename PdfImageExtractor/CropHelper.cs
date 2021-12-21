using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PdfImageExtractor
{
    class CropHelper
    {
        public static Bitmap Crop(Bitmap img, float width, float height, bool keepratio, bool pixels, bool percentage, bool inches, bool cm, bool points)
        {
            /*
            if (unit == 1)
            {
                width = (int)(img.Width * ((float)width /(float)100));
                height = (int)(img.Height * ((float)height /(float)100));
            }
            else if (unit == 2)
            {
                Graphics g0 = Graphics.FromImage(img);
                width = width*(int)((float)g0.DpiX / 25.4f);
                height = height*(int)((float)g0.DpiY / 25.4f);

                g0.Dispose();
            }
            else if (unit == 3)
            {
                Graphics g0 = Graphics.FromImage(img);
                width = (int)(width*g0.DpiX);
                height = (int)(height*g0.DpiY);

                g0.Dispose();
            }
            */

            if (pixels)
            {
                float ratio = (float)img.Width / (float)img.Height;

                if (width >0 && height >0)
                {
                    return CropPixels(img, (int)width, (int)height);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height * ratio);
                    return CropPixels(img, newwidth, (int)height);
                }
                else if (height <= 0)
                {
                    int newheight = (int)((float)img.Width / ratio);
                    return CropPixels(img, (int)width, newheight);
                }
            }
            else if (percentage)
            {
                if (keepratio)
                {
                    if (width >0)
                    {
                        return CropPercentage(img, (float)width, (float)width);
                    }
                    else if (height >0)
                    {
                        return CropPercentage(img, (float)height, (float)height);
                    }
                }
                else
                {
                    return CropPercentage(img, (float)width, (float)height);
                }
            }
            else if (inches)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_inches = (float)height * img.VerticalResolution;

                float width_inches = (float)width * img.HorizontalResolution;

                if (width >0 && height >0)
                {
                    return CropPixels(img, (int)width_inches, (int)height_inches);
                }
                else if (width <= 0)
                {
                    int newwidth = (int)(height_inches * ratio);
                    return CropPixels(img, newwidth, (int)height_inches);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_inches / ratio);
                    return CropPixels(img, (int)width_inches, newheight);
                }
            }
            else if (cm)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_cm = (float)0.393700787 * ((float)height * img.VerticalResolution);

                float width_cm = (float)0.393700787 * ((float)width * img.HorizontalResolution);

                if (width >0 && height >0)
                {
                    return CropPixels(img, (int)width_cm, (int)height_cm);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_cm * ratio);
                    return CropPixels(img, newwidth, (int)height_cm);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_cm / ratio);
                    return CropPixels(img, (int)width_cm, newheight);
                }
            }
            else if (points)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_points = ((float)height * (float)img.VerticalResolution) / (float)72;


                float width_points = ((float)width * (float)img.HorizontalResolution) / (float)72;

                if (width >0 && height >0)
                {
                    return CropPixels(img, (int)width_points, (int)height_points);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_points * ratio);
                    return CropPixels(img, newwidth, (int)height_points);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_points / ratio);
                    return CropPixels(img, (int)width_points, newheight);
                }
            }
            return img;


            
        }

        public static Bitmap CropPixels(Bitmap img, int width, int height)
        {
            Bitmap imgnew = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(imgnew);

            g.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);

            g.Dispose();

            return imgnew;

        }

        public static Bitmap CropPercentage(Bitmap img, float percw, float perch)
        {
            int width = (int)((float)percw / (float)100 * img.Width);
            int height = (int)((float)perch / (float)100 * img.Height);

            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);                                                        

            return result;

        }
    }
}
