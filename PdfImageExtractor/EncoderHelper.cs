using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    class EncoderHelper
    {
        public static ImageCodecInfo GetEncoderInfo(String filepath,bool is_extension)
        {
            string extension = "";

            if (!is_extension)
            {
                extension = "*"+System.IO.Path.GetExtension(filepath).ToUpper()+";";
            }
            else
            {
                extension = filepath.ToUpper();
            }

            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].FilenameExtension.IndexOf(extension)>=0)
                    return encoders[j];
            }
            return null;
        }
    }
}
