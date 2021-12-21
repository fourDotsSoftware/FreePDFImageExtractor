using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FreeImageAPI;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    class FreeImageHelper
    {
        private static FIBITMAP dib = new FIBITMAP();

        public static LoadImageReturn LoadImageWithFileType(string filepath)
        {
            if (!dib.IsNull)
                FreeImage.Unload(dib);

            dib = new FIBITMAP();

            // Safely unload to prevent memory leak.
            FreeImage.UnloadEx(ref dib);

            // Load the example bitmap.
            dib = FreeImage.LoadEx(filepath);

            // Check whether loading succeeded.
            if (dib.IsNull)
            {
                throw new Exception("No Image");
            }

            // Convert the FreeImage-Bitmap into a .NET bitmap

            /*
            if (FreeImage.GetPalette(dib) != IntPtr.Zero)
            {
                byte[] Transparency = new byte[1];
                Transparency[0] = 0x00;
                FreeImage.SetTransparencyTable(dib, Transparency);
                FreeImage.SetTransparent(dib, true);
            }
            */

            Bitmap bitmap = FreeImage.GetBitmap(dib);

            LoadImageReturn lr = new LoadImageReturn();
            lr.img = bitmap;
            lr.FileType = FreeImage.GetFileType(filepath, 0);

            return lr;
        }

        public static Bitmap LoadImage(string filepath)
        {
            if (!dib.IsNull)
                FreeImage.Unload(dib);

            dib = new FIBITMAP();

            // Safely unload to prevent memory leak.
            FreeImage.UnloadEx(ref dib);

            // Load the example bitmap.
            dib = FreeImage.LoadEx(filepath);
                        
            // Check whether loading succeeded.
            if (dib.IsNull)
            {
                throw new Exception("No Image");
            }

            /*
            if (FreeImage.GetPalette(dib) != IntPtr.Zero)
            {
                byte[] Transparency = new byte[1];
                Transparency[0] = 0x00;
                FreeImage.SetTransparencyTable(dib, Transparency);
                FreeImage.SetTransparent(dib, true);
            }
            */
            // Convert the FreeImage-Bitmap into a .NET bitmap
            Bitmap bitmap = FreeImage.GetBitmap(dib);

            return bitmap;
        }

        public static void SaveBitmap(string filepath, Bitmap img,FREE_IMAGE_FORMAT fmt)
        {            
            if (filepath.ToLower().EndsWith(".png"))
            {
                Color c = img.GetPixel(0, 0);
                img.MakeTransparent(c);
                img.Save(filepath, ImageFormat.Png);

            }
            else if (filepath.ToLower().EndsWith(".gif"))
            {
                Color c2 = img.GetPixel(0, 0);
                img=ChangeFormatHelper.MakeTransparentGif(img,c2);
                img.Save(filepath, ImageFormat.Gif);
            }
            else if (filepath.ToLower().EndsWith(".ico"))
            {                                    
                    Color c3 = img.GetPixel(0, 0);
                    img.MakeTransparent(c3);
                    IconHelper.SaveAsIcon(filepath, img);
            }
            else
            {

                //FreeImageAPI.FreeImageBitmap fb=new FreeImageAPI.FreeImageBitmap(img);
                //fb.MakeTransparent(Color.White);

                //fb.BackgroundColor = Color.White;
                // fb.MakeTransparent();

                //fb.Save(filepath, fmt, FREE_IMAGE_SAVE_FLAGS.DEFAULT);


                //if (!dib.IsNull)
                //  FreeImage.Unload(dib);

                //dib = FreeImage.CreateFromBitmap(img);

                //FreeImageAPI.FreeImageBitmap fb = FreeImageAPI.FreeImageBitmap.c

                /*
                if (FreeImage.GetPalette(dib) != IntPtr.Zero)
                {
                    Palette pal = new Palette(dib);
                    byte[] Transparency = new byte[pal.Length];

                    for (int k = 0; k < pal.Length; k++)
                    {
                        Transparency[0] = 0xFF;
                    }

                    FreeImage.SetTransparencyTable(dib, Transparency);
                    FreeImage.SetTransparent(dib, true);
                }
                  */

                //FreeImage.Save(fmt, dib, filepath, FREE_IMAGE_SAVE_FLAGS.DEFAULT);


                //img.MakeTransparent(Color.White);
                                
                FreeImage.SaveBitmap(img, filepath, fmt, FREE_IMAGE_SAVE_FLAGS.DEFAULT);
            }
        }
    }

    public class LoadImageReturn
    {
        public Bitmap img = null;
        public FREE_IMAGE_FORMAT FileType = FREE_IMAGE_FORMAT.FIF_JPEG;
    }
}
