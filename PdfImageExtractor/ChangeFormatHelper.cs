using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using FreeImageAPI;

namespace PdfImageExtractor
{
    class ChangeFormatHelper
    {
        public static void ChangeFormat(string inputFilepath,Bitmap img, string filepath,int iformat)
        {
            bool sep = false;

            try
            {
                switch (iformat)
                {
                    case 0:
                        //return ChangeFormat(img, "Jpeg",filepath);
                        img.Save(filepath, ImageFormat.Jpeg);
                        break;
                    case 1:
                        //return ChangeFormat(img, "Png",filepath);
                        Color c = img.GetPixel(0, 0);
                        img.MakeTransparent(c);
                        img.Save(filepath, ImageFormat.Png);
                        break;
                    case 2:
                        //return ChangeFormat(img, "Gif",filepath);
                        Color c2 = img.GetPixel(0, 0);
                        img = MakeTransparentGif(img, c2);
                        //img.MakeTransparent(c2);
                        /*
                        ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/gif"); ;
                        EncoderParameter encCompressionrParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW); ;
                        EncoderParameter encQualityParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                        EncoderParameters myEncoderParameters = new EncoderParameters(2);
                        myEncoderParameters.Param[0] = encCompressionrParameter;
                        myEncoderParameters.Param[1] = encQualityParameter;

                        img.Save(filepath, myImageCodecInfo, myEncoderParameters);
                        */

                        img.Save(filepath, ImageFormat.Gif);


                        break;
                    case 3:
                        //return ChangeFormat(img, "Bmp", filepath);
                        img.Save(filepath, ImageFormat.Bmp);
                        break;
                    case 4:
                        //return ChangeFormat(img, "Ico", filepath);
                        //img.Save(filepath, ImageFormat.Icon);
                        Color c3 = img.GetPixel(0, 0);
                        img.MakeTransparent(c3);
                        IconHelper.SaveAsIcon(filepath, img);

                        break;
                    case 5:
                        /*
                        cmbFormat.Items.Add("Jpeg2000");
                        cmbFormat.Items.Add("EXR");
                        cmbFormat.Items.Add("HDR");
                        cmbFormat.Items.Add("PBM");
                        cmbFormat.Items.Add("PGM");
                        cmbFormat.Items.Add("PPM");
                        cmbFormat.Items.Add("PFM");
                        cmbFormat.Items.Add("TARGA");
                        cmbFormat.Items.Add("WBMP");
                        cmbFormat.Items.Add("XPM"); 
                        */


                        //return ChangeFormat(img, "Tiff", filepath);
                        img.Save(filepath, ImageFormat.Tiff);
                        break;
                    case 6:
                        //return ChangeFormat(img, "Wmf", filepath);
                        //WmfHelper.SaveAsWmf(filepath, img);                   

                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_JP2);
                        //img.Save(filepath, ImageFormat.Wmf);
                        break;
                    case 7:
                        //return ChangeFormat(img, "Emf", filepath);
                        //img.Save(filepath, ImageFormat.Emf);

                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_EXR);
                        break;
                    case 8:
                        //return ChangeFormat(img, "Exif", filepath);
                        //img.Save(filepath, ImageFormat.Exif);

                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_HDR);
                        break;

                    case 9:
                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_PBM);
                        break;
                    case 10:
                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_PGM);
                        break;

                    case 11:
                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_PPM);
                        break;

                    case 12:
                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_PFM);
                        break;

                    case 13:
                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_TARGA);
                        break;

                    case 14:
                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_WBMP);
                        break;

                    case 15:
                        FreeImageHelper.SaveBitmap(filepath, img, FREE_IMAGE_FORMAT.FIF_XPM);
                        break;

                    case 17:
                        sep = true;

                        PdfHelper.CreatePdfSeparateDocument(inputFilepath, filepath, (Image)img);
                        return;
                        break;

                    default:
                        return;
                        break;

                }
            }
            finally
            {
                if (System.IO.File.Exists(filepath) && !sep)
                {
                    FileInfo fi = new FileInfo(ImagesExtractorHelper.CurrentInputFilepath);

                    FileInfo fi2 = new FileInfo(filepath);

                    if (Properties.Settings.Default.KeepCreationDate)
                    {
                        fi2.CreationTime = fi.CreationTime;
                    }

                    if (Properties.Settings.Default.KeepLastModificationDate)
                    {
                        fi2.LastWriteTime = fi.LastWriteTime;
                    }
                }
            }

            //cmbFormat.Items.Add("Pdf - One Document including all Images");
            //cmbFormat.Items.Add("Pdf - One separate Document for each Image")
        }

        /// <summary>  
        /// Returns a transparent background GIF image from the specified Bitmap.  
        /// </summary>  
        /// <param name="bitmap">The Bitmap to make transparent.</param>  
        /// <param name="color">The Color to make transparent.</param>  
        /// <returns>New Bitmap containing a transparent background gif.</returns>  
        public static Bitmap MakeTransparentGif(Bitmap bitmap, Color color)
        {
            byte R = color.R;
            byte G = color.G;
            byte B = color.B;
            MemoryStream fin = new MemoryStream();
            bitmap.Save(fin, System.Drawing.Imaging.ImageFormat.Gif);
            MemoryStream fout = new MemoryStream((int)fin.Length);
            int count = 0;
            byte[] buf = new byte[256];
            byte transparentIdx = 0;
            fin.Seek(0, SeekOrigin.Begin);
            //header  
            count = fin.Read(buf, 0, 13);
            if ((buf[0] != 71) || (buf[1] != 73) || (buf[2] != 70)) return null; //GIF  
            fout.Write(buf, 0, 13);
            int i = 0;
            if ((buf[10] & 0x80) > 0)
            {
                i = 1 << ((buf[10] & 7) + 1) == 256 ? 256 : 0;
            }
            for (; i != 0; i--)
            {
                fin.Read(buf, 0, 3);
                if ((buf[0] == R) && (buf[1] == G) && (buf[2] == B))
                {
                    transparentIdx = (byte)(256 - i);
                }
                fout.Write(buf, 0, 3);
            }
            bool gcePresent = false;
            while (true)
            {
                fin.Read(buf, 0, 1);
                fout.Write(buf, 0, 1);
                if (buf[0] != 0x21) break;
                fin.Read(buf, 0, 1);
                fout.Write(buf, 0, 1);
                gcePresent = (buf[0] == 0xf9);
                while (true)
                {
                    fin.Read(buf, 0, 1);
                    fout.Write(buf, 0, 1);
                    if (buf[0] == 0) break;
                    count = buf[0];
                    if (fin.Read(buf, 0, count) != count) return null;
                    if (gcePresent)
                    {
                        if (count == 4)
                        {
                            buf[0] |= 0x01;
                            buf[3] = transparentIdx;
                        }
                    }
                    fout.Write(buf, 0, count);
                }
            }
            while (count > 0)
            {
                count = fin.Read(buf, 0, 1);
                fout.Write(buf, 0, 1);
            }
            fin.Close();
            fout.Flush();
            return new Bitmap(fout);
        }

        public static Bitmap ChangeFormat(Bitmap img,string format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                /*
                myEncoder = Encoder.ColorDepth;
                myEncoderParameters = new EncoderParameters(1);

                // Save the image with a color depth of 24 bits per pixel.
                myEncoderParameter = new EncoderParameter(myEncoder, depth);
                myEncoderParameters.Param[0] = myEncoderParameter;
                */                                

                img.Save(ms, EncoderHelper.GetEncoderInfo(format,true), new EncoderParameters());

                return img;
            }
        }

        
        public static Bitmap ChangeFormat(Bitmap img, string format,string filepath)
        {
            using (FileStream ms = new FileStream(filepath,FileMode.Create))
            {
                /*
                myEncoder = Encoder.ColorDepth;
                myEncoderParameters = new EncoderParameters(1);

                // Save the image with a color depth of 24 bits per pixel.
                myEncoderParameter = new EncoderParameter(myEncoder, depth);
                myEncoderParameters.Param[0] = myEncoderParameter;
                */
                
                img.Save(ms, EncoderHelper.GetEncoderInfo(format, true), new EncoderParameters());

                return img;
            }
        }

        
        public static Bitmap ReadJpeg2000(string filepath)
        {
            FIBITMAP dib = new FIBITMAP();

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
            Bitmap bitmap = FreeImage.GetBitmap(dib);

            return bitmap;


        }

        public static void SaveAsJpeg2000(string filepath, Bitmap img)
        {
            FreeImage.SaveBitmap(img, filepath, FREE_IMAGE_FORMAT.FIF_JP2, FREE_IMAGE_SAVE_FLAGS.DEFAULT);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
         
    }
}
