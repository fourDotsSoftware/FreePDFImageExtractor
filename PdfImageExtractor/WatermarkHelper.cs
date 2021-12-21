using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    class WatermarkHelper
    {
        public static Bitmap AddWatermark(Bitmap main_img,int position, int opacity, int xoffset, int yoffset, string filepath)
        {
            try
            {
                if (filepath == String.Empty) return main_img;
                if (!System.IO.File.Exists(filepath)) return main_img;

                //Image img = Image.FromFile(filepath);
                Image img = FreeImageHelper.LoadImage(filepath);

                int x = -1;
                int y = -1;

                switch (position)
                {
                    case 0:
                        x = 0;
                        y = 0;
                        break;
                    case 1:
                        x = (int)(main_img.Width / 2) - (int)(img.Width / 2);
                        y = 0;
                        break;
                    case 2:
                        x = (int)(main_img.Width) - (int)(img.Width);
                        y = 0;
                        break;

                    case 3:
                        x = (int)(main_img.Width / 2) - (int)(img.Width / 2);
                        y = (int)(main_img.Height / 2) - (int)(img.Height / 2);
                        break;

                    case 4:
                        x = 0;
                        y = main_img.Height - img.Height;
                        break;
                    case 5:
                        x = (int)(main_img.Width / 2) - (int)(img.Width / 2);
                        y = main_img.Height - img.Height;
                        break;
                    case 6:
                        x = (int)(main_img.Width) - (img.Width);
                        y = main_img.Height - img.Height;
                        break;
                }

                x = x + xoffset;
                y = y + yoffset;

                float TransparencyLevel = (float)((float)opacity / (float)100);
                float[][] matrixItems = new float[][] {
                                new float[] {1, 0, 0, 0, 0},
                                new float[] {0, 1, 0, 0, 0},
                                new float[] {0, 0, 1, 0, 0},
                                new float[] {0, 0, 0, TransparencyLevel, 0},
                                new float[] {0, 0, 0, 0, 1}};


                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

                Point[] rdestinationPoints = new Point[] { new Point(x, y), new Point(x + img.Width, y), new Point(x, y + img.Height) };

                Bitmap imgnew = (Bitmap)main_img.Clone();//new Bitmap(main_img.Width, main_img.Height);
                Graphics g = Graphics.FromImage(imgnew);

                g.DrawImage(
                img, rdestinationPoints,
                new Rectangle(
                0,             // source rectangle x
                0,             // source rectangle y
                img.Width,        // source rectangle width
                img.Height),       // source rectangle height               
                GraphicsUnit.Pixel,
                imageAtt);

                g.Dispose();

                return imgnew;
            }
            catch
            {
                return main_img;
            }
        }
    }
}
