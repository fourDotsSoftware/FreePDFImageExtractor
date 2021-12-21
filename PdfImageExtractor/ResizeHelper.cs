using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PdfImageExtractor
{
    class ResizeHelper
    {
        public static Bitmap Resize(Bitmap img, float width, float height, bool keepratio, bool pixels,bool percentage,bool inches,bool cm,bool points)
        {
            if (pixels)
            {
                float ratio = (float)img.Width / (float)img.Height;

                if (width >0 && height >0)
                {
                    return ResizePixels(img,(int) width, (int)height);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height * ratio);
                    return ResizePixels(img, newwidth,(int) height);
                }
                else if (height <= 0)
                {
                    int newheight = (int)((float)width / ratio);
                    return ResizePixels(img, (int)width, newheight);
                }
            }
            else if (percentage)
            {
                if (keepratio)
                {
                    if (width >0)
                    {
                        return ResizePercentage(img, (float)width, (float)width);
                    }
                    else if (height>0)
                    {
                        return ResizePercentage(img, (float)height, (float)height);
                    }
                }
                else
                {
                    return ResizePercentage(img, (float)width, (float)height);
                }
            }
            else if (inches)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_inches = (float)height * img.VerticalResolution;

                float width_inches = (float)width * img.HorizontalResolution;
                
                if (width >0 && height >0)
                {
                    return ResizePixels(img, (int)width_inches, (int)height_inches);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_inches * ratio);
                    return ResizePixels(img, newwidth, (int)height_inches);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_inches / ratio);
                    return ResizePixels(img, (int)width_inches, newheight);
                }
            }
            else if (cm)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_cm = (float)0.393700787*((float)height * img.VerticalResolution);

                float width_cm = (float)0.393700787*((float)width * img.HorizontalResolution);

                if (width >0 && height >0)
                {
                    return ResizePixels(img, (int)width_cm, (int)height_cm);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_cm * ratio);
                    return ResizePixels(img, newwidth, (int)height_cm);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_cm / ratio);
                    return ResizePixels(img, (int)width_cm, newheight);
                }
            }
            else if (points)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_points = ((float)height * (float)img.VerticalResolution) / (float)72;
                         

                float width_points = ((float)width*(float)img.HorizontalResolution)/(float)72;

                if (width >0 && height >0)
                {
                    return ResizePixels(img, (int)width_points, (int)height_points);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_points * ratio);
                    return ResizePixels(img, newwidth, (int)height_points);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_points / ratio);
                    return ResizePixels(img, (int)width_points, newheight);
                }
            }
            return img;
        }
        public static Bitmap ResizePixels(Bitmap img,int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage((Bitmap)result))
                g.DrawImage(img, 0, 0, width, height);
            return result;

        }

        public static Bitmap ResizePercentage(Bitmap img, float percw,float perch)
        {
            int width = (int)((float)percw/(float)100 * img.Width);
            int height = (int)((float)perch/(float)100 * img.Height);
            
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(img, 0, 0, width, height);
            return result;

        }
    }
}
