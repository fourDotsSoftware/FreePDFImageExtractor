using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PdfImageExtractor
{
    class TextHelper
    {
        public static Bitmap AddText(string imgfilepath,Bitmap img, int position, int xoffset, int yoffset, string txt, Font font, Color color)
        {
            try
            {
                Bitmap imgnew = (Bitmap)img.Clone();

                if (System.IO.File.Exists(imgfilepath))
                {
                    FileInfo fi=new FileInfo(imgfilepath);
                    txt=txt.Replace("{Filename}",System.IO.Path.GetFileName(fi.FullName));
                    txt = txt.Replace("{Full Filepath}", fi.FullName);
                    txt = txt.Replace("{Creation Date}", fi.CreationTime.ToShortDateString());
                    txt = txt.Replace("{Creation Date Time}", fi.CreationTime.ToString());
                    txt = txt.Replace("{Creation Time}", fi.CreationTime.ToShortTimeString());

                    txt = txt.Replace("{Last Accessed Date}", fi.LastAccessTime.ToShortDateString());
                    txt = txt.Replace("{Last Accessed Date Time}", fi.LastAccessTime.ToString());
                    txt = txt.Replace("{Last Accessed Time}", fi.LastAccessTime.ToShortTimeString());

                }

                int x = -1;
                int y = -1;

                Graphics g = Graphics.FromImage(imgnew);

                SizeF size = g.MeasureString(txt, font);
                int sizew = (int)size.Width;
                int sizeh = (int)size.Height;

                switch (position)
                {
                    case 0:
                        x = 0;
                        y = 0;
                        break;
                    case 1:
                        x = (int)(img.Width / 2) - (int)(sizew / 2);
                        y = 0;
                        break;
                    case 2:
                        x = (int)(img.Width) - (int)(sizew);
                        y = 0;
                        break;

                    case 3:
                        x = (int)(img.Width / 2) - (int)(sizew / 2);
                        y = (int)(img.Height / 2) - (int)(sizeh / 2);
                        break;

                    case 4:
                        x = 0;
                        y = img.Height - sizeh;
                        break;
                    case 5:
                        x = (int)(img.Width / 2) - (int)(sizew / 2);
                        y = img.Height - sizeh;
                        break;
                    case 6:
                        x = (int)(img.Width) - (sizew);
                        y = img.Height - sizeh;
                        break;
                }

                x = x + xoffset;
                y = y + yoffset;

                Brush b = new SolidBrush(color);

                g.DrawString(txt, font, b, (float)x, (float)y);

                g.Dispose();

                return imgnew;
            }
            catch
            {
                return img;
            }
        }
    }
}
