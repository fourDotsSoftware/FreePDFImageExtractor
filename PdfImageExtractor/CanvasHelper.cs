using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    class CanvasHelper
    {
        public static Bitmap ChangeCanvas //(Bitmap img, int width, int height, Color backcolor, bool pixels)
            (Bitmap img, float width, float height, Color backcolor,bool keepratio, bool pixels,bool percentage,bool inches,bool cm,bool points)
        {
            /*
            if (pixels)
            {
                return ChangeCanvasPixels(img, width, height, backcolor);
            }
            else
            {
                return ChangeCanvasPercentage(img, width, height, backcolor);
            }*/

            if (pixels)
            {
                float ratio = (float)img.Width / (float)img.Height;

                if (width >0 && height >0)
                {
                    return ChangeCanvasPixels(img, (int)width, (int)height,backcolor);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height * ratio);
                    return ChangeCanvasPixels(img, newwidth, (int)height, backcolor);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)img.Width / ratio);
                    return ChangeCanvasPixels(img, (int)width, newheight, backcolor);
                }
            }
            else if (percentage)
            {
                if (keepratio)
                {
                    if (width >0)
                    {
                        return ChangeCanvasPercentage(img, width, width, backcolor);
                    }
                    else if (height >0)
                    {
                        return ChangeCanvasPercentage(img, height, height, backcolor);
                    }
                }
                else
                {
                    return ChangeCanvasPercentage(img, width, height, backcolor);
                }
            }
            else if (inches)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_inches = (float)height * img.VerticalResolution;

                float width_inches = (float)width * img.HorizontalResolution;

                if (width >0 && height >0)
                {
                    return ChangeCanvasPixels(img, (int)width_inches, (int)height_inches, backcolor);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_inches * ratio);
                    return ChangeCanvasPixels(img, newwidth, (int)height_inches, backcolor);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_inches / ratio);
                    return ChangeCanvasPixels(img, (int)width_inches, newheight, backcolor);
                }
            }
            else if (cm)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_cm = (float)0.393700787 * ((float)height * img.VerticalResolution);

                float width_cm = (float)0.393700787 * ((float)width * img.HorizontalResolution);

                if (width >0 && height >0)
                {
                    return ChangeCanvasPixels(img, (int)width_cm, (int)height_cm, backcolor);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_cm * ratio);
                    return ChangeCanvasPixels(img, newwidth, (int)height_cm, backcolor);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_cm / ratio);
                    return ChangeCanvasPixels(img, (int)width_cm, newheight, backcolor);
                }
            }
            else if (points)
            {
                float ratio = (float)img.Width / (float)img.Height;

                float height_points = ((float)height * (float)img.VerticalResolution) / (float)72;


                float width_points = ((float)width * (float)img.HorizontalResolution) / (float)72;

                if (width >0 && height >0)
                {
                    return ChangeCanvasPixels(img, (int)width_points, (int)height_points, backcolor);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_points * ratio);
                    return ChangeCanvasPixels(img, newwidth, (int)height_points, backcolor);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_points / ratio);
                    return ChangeCanvasPixels(img, (int)width_points, newheight, backcolor);
                }
            }
            return img;
        }

        public static Bitmap ChangeCanvasPixels(Bitmap img, int width, int height,Color backcolor)
        {
            Bitmap result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage((Bitmap)result))
            {
                g.FillRectangle(new SolidBrush(backcolor),new Rectangle(0,0,width,height));
                g.DrawImage(img, 0, 0, img.Width, img.Height);

            }
            return result;

        }

        public static Bitmap ChangeCanvasPercentage(Bitmap img, float percentage_width,float percentage_height,Color backcolor)
        {
            int width = (int)((float)percentage_width/(float)100 * img.Width);
            int height = (int)((float)percentage_height/(float)100 * img.Height);                       

            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.FillRectangle(new SolidBrush(backcolor),new Rectangle(0,0,width,height));
                g.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            return result;

        }
    }
}
