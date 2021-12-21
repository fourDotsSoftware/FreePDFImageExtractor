using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PdfImageExtractor
{
    class BorderHelper
    {
        public static Bitmap AddBorder(Bitmap img,bool style1,bool style2,bool style3, Color colorA, Color colorB, Color colorC,
            int widthA, int widthB, int widthC,bool gradient,Color colorgrA,Color colorgrB,bool ellipse)
        {
            int width = img.Width;
            int height = img.Height;

            if (style1)
            {
                width = width + 2*widthA;
                height = height + 2 * widthA;
            }

            if (style2)
            {
                width = width + 2*widthB;
                height = height + 2 * widthB;
            }

            if (style3)
            {
                width = width + 2 * widthC;
                height = height + 2 * widthC;
            }

            Bitmap imgnew = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(imgnew);

            if (gradient)
            {
                int x = width;
                int y = height;

                System.Drawing.Drawing2D.LinearGradientBrush
                    lgBrush = new System.Drawing.Drawing2D.LinearGradientBrush
                    (new System.Drawing.Point(0, 0), new System.Drawing.Point(x, y),
                    colorgrA, colorgrB);
                lgBrush.GammaCorrection = true;
                g.FillRectangle(lgBrush, 0, 0, x, y);
            }

            int border = (int)(width - img.Width)/2;

            
                if ((style1 || ellipse) && !gradient) 
                {
                    g.FillRectangle(new SolidBrush(colorA), new Rectangle(0, 0, width, height));
                }

                if (ellipse)
                {                    
                    Brush tBrush = new TextureBrush(img, new Rectangle(0, 0, img.Width, img.Height));
                    g.FillEllipse(tBrush, 0,0,width,height);
                    tBrush.Dispose();

                }
                else
                {

                    if (style2)
                    {
                        g.FillRectangle(new SolidBrush(colorB), new Rectangle(widthA, widthA, img.Width+2*widthB+2*widthC,img.Height+2*widthB+2*widthC ));
                    }

                    if (style3)
                    {
                        g.FillRectangle(new SolidBrush(colorC), new Rectangle(widthA + widthB,widthA+widthB, 2*widthC+img.Width, 2 * widthC + img.Height));
                    }

                    g.DrawImage(img, new Rectangle(border, border, img.Width, img.Height));
                }

                g.Dispose();

                return imgnew;
        }
    }
}
