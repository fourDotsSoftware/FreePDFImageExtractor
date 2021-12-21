using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    class BrightnessCGHelper
    {
        public static Bitmap ApplyColorTransformations(Bitmap img, int ibrightness, int icontrast, int igamma,
        int red, int green, int blue, int alpha, int h, int s, int v, bool grayscale, bool negative, bool sepia, int sharpen,int blur,int emboss)
        {
            img = (Bitmap)img.Clone();

            bool rgb = false;
            bool hsv = false;

            if (red == 0 && green == 0 && blue == 0) rgb = false;
            else
                rgb = true;

            if (h == 0 && s == 0 && v == 0) hsv = false;
            else
                hsv = true;


            float brightness = (float)(1 + ((float)ibrightness / 100));
            float contrast = (float)(1 + ((float)icontrast / 100));
            float gamma = (float)(1 + ((float)igamma / 100));

            if (hsv)
            {
                Color col = ColorHelper.HSVtoRGB((float)h, (float)s / 100, (float)v / 100);
                //Color col = ColorHelper.HsvToRgb((double)h, (double)s, (double)v);
                red = col.R;
                green = col.G;
                blue = col.B;
                alpha = col.A;
            }

            float fred = (float)red /(float) 255;
            float fgreen = (float)green / (float)255;
            float fblue = (float)blue / (float)255;
            float falpha = (float)alpha / (float)255;

            Bitmap imgnew = new Bitmap(img.Width, img.Height);

            brightness = brightness - 1.0f;// (float)(brightness - 1.0f);
            //contrast = contrast - 1.0f;// (float)(brightness - 1.0f);

            if (ibrightness == 0)
            {
                brightness = 0.0f;
            }

            if (icontrast == 0)
            {
                contrast = 1.0f;
            }

            if (igamma == 0)
            {
                gamma = 1.0f;
            }


            //gamma = gamma - 1.0f;// (float)(brightness - 1.0f);

            // create matrix that will brighten and contrast the image
            float[][] ptsArray = null;

            if (rgb || hsv)
            {
                ptsArray = new float[][] {
                    new float[] {contrast, 0, 0, 0, 0}, // scale red
                    new float[] {0, contrast, 0, 0, 0}, // scale green
                    new float[] {0, 0, contrast, 0, 0}, // scale blue
                    new float[] {0, 0, 0, falpha, 0}, // don't scale alpha
                    new float[] {fred, fgreen, fblue, 0, 1}};
            }
            else
            {

                ptsArray = new float[][] {
                    new float[] {contrast, 0, 0, 0, 0}, // scale red
                    new float[] {0, contrast, 0, 0, 0}, // scale green
                    new float[] {0, 0, contrast, 0, 0}, // scale blue
                    new float[] {0, 0, 0, falpha, 0}, // don't scale alpha
                    new float[] {brightness, brightness, brightness, 0, 1}};
            }

            if (grayscale)
            {
                ptsArray = new float[][] { 
                             new float[] {0.299f, 0.299f, 0.299f, 0, 0}, 
                             new float[] {0.587f, 0.587f, 0.587f, 0, 0}, 
                             new float[] {0.114f, 0.114f, 0.114f, 0, 0}, 
                             new float[] {0, 0, 0, 1, 0}, 
                             new float[] {0, 0, 0, 0, 1}};
            }
            else if (sepia)
            {
                ptsArray = new float[][]{
                       new float[] {.393f, .349f, .272f, 0, 0},
                       new float[] {.769f, .686f, .534f, 0, 0},
                       new float[] {.189f, .168f, .131f, 0, 0},
                       new float[] {0, 0, 0, 1, 0},
                       new float[] {0, 0, 0, 0, 1}
                   };
            }
            else if (negative)
            {
                ptsArray = new float[][]{
                            new float[] {-1f, 0, 0, 0, 0}, 
                            new float[] {0, -1f, 0, 0, 0}, 
                            new float[] {0, 0, -1f, 0, 0}, 
                            new float[] {0, 0, 0, 1f, 0}, 
                            new float[] {0, 0, 0, 0, 1f}};
            }

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(imgnew);
            g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height)
                , 0, 0, img.Width, img.Height,
                GraphicsUnit.Pixel, imageAttributes);


            if (sharpen > 0)
            {
                //imgnew = Sharpen(imgnew, sharpen);
                //imgnew = Sharpen((double)sharpen, imgnew);
                
                while (sharpen > 0)
                {
                    imgnew = Sharpen((double)11, imgnew);
                    //imgnew = Sharpen(imgnew);
                    sharpen--;
                }
                
            }
            else if (sharpen < 0)
            {
                //imgnew = Blur(img, sharpen);

                while (sharpen < 0)
                {
                    imgnew = Smooth((double)(5), imgnew);
                    //imgnew = Sharpen(imgnew);
                    sharpen++;
                }
                
            }

            while (emboss > 0)
            {
                imgnew = Emboss((double)4,imgnew);           
                emboss--;
            }

            while (blur > 0)
            {
                imgnew = Blur(imgnew,4);                
                blur--;
            }

            return imgnew;
        }


        public static Bitmap Sharpen(double weight,Bitmap bmp)
        {
            ConvolutionMatrix matrix = new ConvolutionMatrix(3);
            matrix.SetAll(1);
            matrix.Matrix[0, 0] = 0;
            matrix.Matrix[1, 0] = -2;
            matrix.Matrix[2, 0] = 0;
            matrix.Matrix[0, 1] = -2;
            matrix.Matrix[1, 1] = weight;
            matrix.Matrix[2, 1] = -2;
            matrix.Matrix[0, 2] = 0;
            matrix.Matrix[1, 2] = -2;
            matrix.Matrix[2, 2] = 0;
            matrix.Factor = weight - 8;
            bmp = ConvolutionHelper.Convolution3x3(bmp, matrix);

            return bmp;
        }

        public static Bitmap Smooth(double weight,Bitmap bmp)
        {
            ConvolutionMatrix matrix = new ConvolutionMatrix(3);
            matrix.SetAll(1);
            matrix.Matrix[1, 1] = weight;
            matrix.Factor = weight + 8;
            bmp = ConvolutionHelper.Convolution3x3(bmp, matrix);

            return bmp;
        }

        public static Bitmap GaussianBlur(double peakValue,Bitmap bmp)
        {
            ConvolutionMatrix matrix = new ConvolutionMatrix(3);
            matrix.SetAll(1);
            matrix.Matrix[0, 0] = peakValue / 4;
            matrix.Matrix[1, 0] = peakValue / 2;
            matrix.Matrix[2, 0] = peakValue / 4;
            matrix.Matrix[0, 1] = peakValue / 2;
            matrix.Matrix[1, 1] = peakValue;
            matrix.Matrix[2, 1] = peakValue / 2;
            matrix.Matrix[0, 2] = peakValue / 4;
            matrix.Matrix[1, 2] = peakValue / 2;
            matrix.Matrix[2, 2] = peakValue / 4;
            matrix.Factor = peakValue * 4;
            bmp = ConvolutionHelper.Convolution3x3(bmp, matrix);

            return bmp;
        }

        public static Bitmap Emboss(double weight,Bitmap bmp)
        {
            ConvolutionMatrix matrix = new ConvolutionMatrix(3);
            matrix.SetAll(1);
            matrix.Matrix[0, 0] = -1;
            matrix.Matrix[1, 0] = 0;
            matrix.Matrix[2, 0] = -1;
            matrix.Matrix[0, 1] = 0;
            matrix.Matrix[1, 1] = weight;
            matrix.Matrix[2, 1] = 0;
            matrix.Matrix[0, 2] = -1;
            matrix.Matrix[1, 2] = 0;
            matrix.Matrix[2, 2] = -1;
            matrix.Factor = 4;
            matrix.Offset = 127;
            bmp = ConvolutionHelper.Convolution3x3(bmp, matrix);

            return bmp;
        }



        public static Bitmap S1harpen(Bitmap image,int shfactor)
        {
            Bitmap sharpenImage = (Bitmap)image.Clone();

            //int filterWidth = 3;
            //int filterHeight = 3;
            int width = image.Width;
            int height = image.Height;

            const int filterWidth = 5;
            const int filterHeight = 5;

            double[,] filter = new double[filterWidth, filterHeight] {
    { -1, -1, -1, -1, -1 },
    { -1,  2,  2,  2, -1 },
    { -1,  2,  16,  2, -1 },
    { -1,  2,  2,  2, -1 },
    { -1, -1, -1, -1, -1 }
    };

            //double factor = ((double)shfactor*1.0) / 16.0;


            /*
            // Create sharpening filter.
            double[,] filter = new double[filterWidth, filterHeight];
            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;
            */

            double factor = 1.0;
            
            
            double bias = 0.0;

            Color[,] result = new Color[image.Width, image.Height];

            // Lock image bits for read/write.
            BitmapData pbits = sharpenImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Declare an array to hold the bytes of the bitmap.
            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;

            for (int w = 0; w==0 && w < shfactor; w++)
            {
                // Fill the color array with the new sharpened color values.
                for (int x = 0; x < width; ++x)
                {
                    for (int y = 0; y < height; ++y)
                    {
                        double red = 0.0, green = 0.0, blue = 0.0;

                        for (int filterX = 0; filterX < filterWidth; filterX++)
                        {
                            for (int filterY = 0; filterY < filterHeight; filterY++)
                            {
                                int imageX = (x - filterWidth / 2 + filterX + width) % width;
                                int imageY = (y - filterHeight / 2 + filterY + height) % height;

                                rgb = imageY * pbits.Stride + 3 * imageX;

                                red += rgbValues[rgb + 2] * filter[filterX, filterY];
                                green += rgbValues[rgb + 1] * filter[filterX, filterY];
                                blue += rgbValues[rgb + 0] * filter[filterX, filterY];
                            }
                            int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                            int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                            int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                            result[x, y] = Color.FromArgb(r, g, b);
                        }
                    }
                }

                // Update the image with the sharpened pixels.
                for (int x = 0; x < width; ++x)
                {
                    for (int y = 0; y < height; ++y)
                    {
                        rgb = y * pbits.Stride + 3 * x;

                        rgbValues[rgb + 2] = result[x, y].R;
                        rgbValues[rgb + 1] = result[x, y].G;
                        rgbValues[rgb + 0] = result[x, y].B;
                    }
                }
            }

            // Copy the RGB values back to the bitmap.
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            // Release image bits.
            sharpenImage.UnlockBits(pbits);

            return sharpenImage;
        }

        public static Bitmap Blur(Bitmap image, int blurSize)
        {
            Bitmap blurred = new Bitmap(image.Width, image.Height);
            Rectangle rectangle = new Rectangle(0,0,image.Width, image.Height);
            
            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // look at every pixel in the blur rectangle
            for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    Int32 avgR = 0, avgG = 0, avgB = 0;
                    Int32 blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (Int32 x = xx; (x < xx + blurSize && x < image.Width); x++)
                    {
                        for (Int32 y = yy; (y < yy + blurSize && y < image.Height); y++)
                        {
                            Color pixel = blurred.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    if (blurPixelCount > 0)
                    {
                        avgR = avgR / blurPixelCount;
                        avgG = avgG / blurPixelCount;
                        avgB = avgB / blurPixelCount;
                    }

                    // now that we know the average for the blur size, set each pixel to that color
                    for (Int32 x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                        for (Int32 y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                            blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return blurred;
        }
    }
}
