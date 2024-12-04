using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using PdfiumViewer;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    public class PdfiumImageExtractor
    {
        public static String RESULT = "Img{0}.{1}";
        public static List<Image> lstAddImages = new List<Image>();

        public static string CurrentInputFilepath = "";

        public static string ExtractImages(DataTable dt, bool rdDocumentsFolder, string rdDocumentsFolderText, bool chkFormat, int SelectedFormat, string txtFilename)
        {
            string err = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (frmMain.Instance.OperationCancelled)
                {
                    ImagesExtractorHelper.uniqueImageSaver.ClearAfterUse();

                    return err;
                }

                lstAddImages = new List<Image>();

                try
                {
                    string filepath = dt.Rows[k]["fullfilepath"].ToString();

                    CurrentInputFilepath = filepath;
                    ImagesExtractorHelper.CurrentInputFilepath = filepath;

                    ImagesExtractorHelper.uniqueImageSaver.ClearAfterUse();

                    string password = dt.Rows[k]["password"].ToString();
                    PageRange pagerange = (PageRange)dt.Rows[k]["pagerange"];

                    string rootfolder = dt.Rows[k]["rootfolder"].ToString();

                    if (rdDocumentsFolder)
                    {
                        if (rootfolder != string.Empty && Properties.Settings.Default.KeepFolderStructure)
                        {
                            string dep = System.IO.Path.GetDirectoryName(filepath).Substring(rootfolder.Length);

                            string outdfp = rdDocumentsFolderText + dep;

                            if (!System.IO.Directory.Exists(outdfp))
                            {
                                System.IO.Directory.CreateDirectory(outdfp);
                            }

                            RESULT = System.IO.Path.Combine(outdfp, System.IO.Path.GetFileName(filepath) + ".extracted_images");
                        }
                        else
                        {
                            RESULT = System.IO.Path.Combine(rdDocumentsFolderText, System.IO.Path.GetFileName(filepath) + ".extracted_images");
                        }
                    }
                    else
                    {
                        string dirpath = System.IO.Path.GetDirectoryName(filepath);

                        RESULT = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileName(filepath) + ".extracted_images");
                    }

                    bool add_to_one_pdf = false;

                    //if (frmMain.Instance.chkFormat.Checked && frmChangeFormat.Instance.SelectedFormat == 16)
                    if (chkFormat && SelectedFormat == 16)
                    {
                        add_to_one_pdf = true;
                        RESULT += ".pdf";

                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(RESULT)))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(RESULT));
                        }
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(RESULT))
                        {
                            System.IO.Directory.CreateDirectory(RESULT);
                        }

                        //1RESULT += "\\" + frmMain.Instance.txtFilename.Text;   //"\\Img{0}.{1}";

                        RESULT += "\\" + txtFilename;   //"\\Img{0}.{1}";

                    }

                    err += ExtractImages(filepath, password, pagerange, add_to_one_pdf);

                    if (add_to_one_pdf)
                    {
                        PdfHelper.CreatePdfOneForAllImages(CurrentInputFilepath, RESULT, lstAddImages);
                    }
                }
                catch (Exception ex)
                {
                    err += ex.Message;
                }
                finally
                {
                    ImagesExtractorHelper.uniqueImageSaver.ClearAfterUse();
                }
            }

            return err;

        }

        public static string ExtractImages(string filepath, string password, PageRange pagerange, bool add_to_one_pdf)
        {
            string err = "";

            string tmpfile = System.IO.Path.GetTempPath() + "\\" + Guid.NewGuid().ToString() + ".bmp";

            string PdfFile = System.IO.Path.GetFileName(filepath);

            int pageNumber = -1;

            var images = new Dictionary<string, System.Drawing.Image>();

            try
            {                               
                IntPtr doc = NativeMethods.FPDF_LoadDocument(filepath, password);                

                int pageCount = NativeMethods.FPDF_GetPageCount(doc);                

                for (int k = 0; k < pageCount; k++)
                {
                    if (frmMain.Instance.OperationCancelled) return err;

                    var index = 1;

                    IntPtr page = NativeMethods.FPDF_LoadPage(doc, k);

                    pageNumber = k + 1;

                    try
                    {
                        if (!ShouldAddPage(pageNumber, pagerange,page))
                        {
                            continue;
                        }
                    }
                    catch (Exception exi)
                    {
                        err += exi.Message + "\r\n";
                    }                    

                    int objectCount = PdfiumViewer.NativeMethods.FPDFPage_CountObjects(page);                    

                    for (int m=0;m<objectCount;m++)
                    {
                        IntPtr pageObject = PdfiumViewer.NativeMethods.FPDFPage_GetObject(page, m);

                        int objectType = PdfiumViewer.NativeMethods.FPDFPageObj_GetType(pageObject);

                        if (objectType==PdfiumViewer.NativeMethods.FPDF_PAGEOBJ_IMAGE)
                        {                            
                            PdfiumViewer.NativeMethods.FPDF_IMAGEOBJ_METADATA metadata2 = new NativeMethods.FPDF_IMAGEOBJ_METADATA();

                            IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(metadata2));

                            PdfiumViewer.NativeMethods.FPDF_IMAGEOBJ_METADATA metadata = PdfiumViewer.NativeMethods.FPDFImageObj_GetImageMetadata(pageObject,
                              page, pnt);

                            var size = (metadata.width * metadata.height * metadata.bits_per_pixel) / 8;

                            //var size = (metadata.width * metadata.height * 24) / 8;

                            byte[] buffer = new byte[(int)size];

                            PdfiumViewer.NativeMethods.FPDFImageObj_GetImageDataDecoded(pageObject, buffer, (ulong)size);                            

                            IntPtr pBitmap = PdfiumViewer.NativeMethods.FPDFImageObj_GetBitmap(pageObject);                            

                            int imageFormat=PdfiumViewer.NativeMethods.FPDFBitmap_GetFormat(pBitmap);

                            int pWidth= PdfiumViewer.NativeMethods.FPDFBitmap_GetWidth(pBitmap);

                            int pHeight = PdfiumViewer.NativeMethods.FPDFBitmap_GetHeight(pBitmap);

                            int pStride = PdfiumViewer.NativeMethods.FPDFBitmap_GetStride(pBitmap);

                            IntPtr pData = PdfiumViewer.NativeMethods.FPDFBitmap_GetBuffer(pBitmap);

                            double dpiX = 72;
                            double dpiY = 72;

                            string filename = RESULT;

                            filename = filename.Replace("[PAGENUM]", pageNumber.ToString());
                            filename = filename.Replace("[NUM]", index.ToString());
                            filename = filename.Replace("[FILENAME]", PdfFile);
                            //3filename = filename.Replace("[FILETYPE]", image.GetFileType());

                            filename = filename.Replace("[FILETYPE]", RenameHelper.GetExtension(filename));
                                                        
                            index++;

                            tmpfile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");

                            try
                            {

                                using (FileStream stream = new FileStream(tmpfile, FileMode.Create))
                                {
                                    BmpStream bs = new BmpStream(pData, (uint)pStride, (BitmapFormats)imageFormat, pWidth, pHeight, dpiX, dpiY);

                                    bs.CopyTo(stream);
                                    bs.Close();
                                    bs.Dispose();
                                }

                                Image img = Image.FromFile(tmpfile);

                                ImagesExtractorHelper.Convert(img, filename, add_to_one_pdf);

                                //3img.Save(@"c:\1\pdfsharp2a.bmp");

                                img.Dispose();
                                img = null;
                            }
                            catch (Exception exm) {

                                err += exm.Message + exm.ToString() + "\r\n";
                            }
                            /*
                            Image bmpa = Image.FromStream(new MemoryStream(buffer));

                            Bitmap bmpa2 = (Bitmap)bmpa;

                            ImageCodecInfo myImageCodecInfo;
                            System.Drawing.Imaging.Encoder myEncoder;
                            EncoderParameter myEncoderParameter;
                            EncoderParameters myEncoderParameters;

                            // Get an ImageCodecInfo object that represents the TIFF codec.
                            myImageCodecInfo = GetEncoderInfo("image/tiff");

                            // Create an Encoder object based on the GUID
                            // for the ColorDepth parameter category.
                            myEncoder = System.Drawing.Imaging.Encoder.ColorDepth;

                            // Create an EncoderParameters object.
                            // An EncoderParameters object has an array of EncoderParameter
                            // objects. In this case, there is only one
                            // EncoderParameter object in the array.
                            myEncoderParameters = new EncoderParameters(1);

                            // Save the image with a color depth of 24 bits per pixel.
                            myEncoderParameter =
                                new EncoderParameter(myEncoder, 24L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            bmpa2.Save(@"c:\1\Shapes24bpp.tiff", myImageCodecInfo, myEncoderParameters);
                            */
                            
                            /*3
                            var src = new Mat(tmpfile, ImreadModes.AnyDepth | ImreadModes.AnyColor);

                            var srcCopy = new Mat();

                            src.CopyTo(srcCopy);

                            var markerMask = new Mat();

                            Cv2.CvtColor(srcCopy, markerMask, ColorConversionCodes.BGR2RGB);

                            markerMask.SaveImage(@"c:\1\opencv.bmp");
                            */                            
                        }
                    }

                }
                //}
                
            }
            catch (Exception ex)
            {
                err += ex.Message + ex.ToString()+"\r\n";
            }

            return err;
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
        
        public static bool ShouldAddPage(int pagenum, PageRange pagerange,IntPtr page)
        {
            if (pagerange.AllPages)
            {
                return true;
            }

            bool add = false;

            if (pagerange.Pages)
            {
                if (pagenum < pagerange.PagesFrom || pagenum > pagerange.PagesTo)
                {

                }
                else
                {
                    return true;

                }

            }

            if (pagerange.PagesOdd)
            {
                if (pagenum % 2 != 0)
                {
                    if (pagenum < pagerange.PagesOddFrom || pagenum > pagerange.PagesOddTo)
                    {

                    }
                    else
                    {
                        return true;
                    }
                }
            }

            if (pagerange.PagesEven)
            {
                if (pagenum % 2 == 0)
                {

                    if (pagenum < pagerange.PagesEvenFrom || pagenum > pagerange.PagesEvenTo)
                    {

                    }
                    else
                    {
                        return true;
                    }
                }
            }

            if (pagerange.PagesEvery)
            {
                if (pagenum < pagerange.PagesEveryFrom || pagenum > pagerange.PagesEveryTo)
                {

                }
                else
                {
                    int ieveryfrom = (int)pagerange.PagesEveryFrom;

                    if ((pagenum - ieveryfrom) % pagerange.PagesEveryValue == 0)
                    {
                        return true;
                    }
                }
            }

            if (pagerange.PageRanges.Trim() != String.Empty)
            {
                string[] ranges = pagerange.PageRanges.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < ranges.Length; k++)
                {
                    string[] range = ranges[k].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                    int ifrom = int.Parse(range[0]);
                    int ito = int.Parse(range[1]);

                    if (pagenum < ifrom || pagenum > ito)
                    {

                    }
                    else
                    {
                        return true;
                    }
                }

            }

            if (pagerange.PagesContainingText)
            {
                int countChars = NativeMethods.FPDFText_CountChars(page);

                if (countChars > 0)
                {
                    int bCount = NativeMethods.FPDFText_GetText(page, 0, countChars, null);

                    byte[] btext = new byte[bCount];

                    NativeMethods.FPDFText_GetText(page, 0, countChars, btext);

                    string text = System.Text.Encoding.Unicode.GetString(btext);

                    if (text.Contains(
                        pagerange.PageText))
                    {
                        return true;
                    }
                }
            }

            return false;
        }        
    }

    class BmpStream : Stream
    {
        const uint BmpHeaderSize = 14;
        const uint DibHeaderSize = 108; // BITMAPV4HEADER
        const uint PixelArrayOffset = BmpHeaderSize + DibHeaderSize;
        const uint CompressionMethod = 3; // BI_BITFIELDS
        const uint MaskR = 0x00_FF_00_00;
        const uint MaskG = 0x00_00_FF_00;
        const uint MaskB = 0x00_00_00_FF;
        const uint MaskA = 0xFF_00_00_00;

        //3readonly PDFiumBitmap _bitmap;

        readonly BitmapFormats _format;
        readonly byte[] _header;
        readonly uint _length;
        readonly uint _stride;
        readonly uint _rowLength;

        public int BytesPerPixel = -1;
        public int _Width;
        public int _Height;
        public uint _Stride = 0;
        public IntPtr _Scan0 = IntPtr.Zero;

        uint _pos;

        public BmpStream(IntPtr scan0,uint stride,BitmapFormats format, int width,int height,double dpiX, double dpiY)
        {
            _Scan0 = scan0;
            _Stride = stride;
            _format = format;
            _Width = width;
            _Height = height;

            if (_format == BitmapFormats.FPDFBitmap_Gray)
                throw new NotSupportedException($"Bitmap format {_format} is not yet supported.");

             BytesPerPixel =GetBytesPerPixel(_format);
            //_bitmap = bitmap;
            _rowLength = (uint)BytesPerPixel * (uint)width;
            _stride = (((uint)BytesPerPixel * 8 * (uint)width + 31) / 32) * 4;
            _length = PixelArrayOffset + _stride * (uint)height;
            _header = GetHeader(_length, _format,_Width,_Height,BytesPerPixel, dpiX, dpiY);
            _pos = 0;
        }

        static int GetBytesPerPixel(BitmapFormats format)
        {
            if (format == BitmapFormats.FPDFBitmap_BGR)
                return 3;
            if (format == BitmapFormats.FPDFBitmap_BGRA || format == BitmapFormats.FPDFBitmap_BGRx)
                return 4;
            if (format == BitmapFormats.FPDFBitmap_Gray)
                return 1;
            throw new ArgumentOutOfRangeException(nameof(format));
        }

        static byte[] GetHeader(uint fileSize, BitmapFormats format, int width,int height,int bytesPerPixel,double dpiX, double dpiY)
        {
            const double MetersPerInch = 0.0254;

            byte[] header = new byte[BmpHeaderSize + DibHeaderSize];

            using (var ms = new MemoryStream(header))
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write((byte)'B');
                writer.Write((byte)'M');
                writer.Write(fileSize);
                writer.Write(0u);
                writer.Write(PixelArrayOffset);
                writer.Write(DibHeaderSize);
                writer.Write(width);
                writer.Write(-height); // top-down image
                writer.Write((ushort)1);
                writer.Write((ushort)(bytesPerPixel * 8));
                writer.Write(CompressionMethod);
                writer.Write(0);
                writer.Write((int)Math.Round(dpiX / MetersPerInch));
                writer.Write((int)Math.Round(dpiY / MetersPerInch));
                writer.Write(0L);
                writer.Write(MaskR);
                writer.Write(MaskG);
                writer.Write(MaskB);
                if (format == BitmapFormats.FPDFBitmap_BGRA)
                    writer.Write(MaskA);
            }
            return header;
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _length;

        public override long Position
        {
            get => _pos;
            set
            {
                if (value < 0 || value >= _length)
                    throw new ArgumentOutOfRangeException();
                _pos = (uint)value;
            }
        }

        public override void Flush() { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesToRead = count;
            int returnValue = 0;
            if (_pos < PixelArrayOffset)
            {
                returnValue = Math.Min(count, (int)(PixelArrayOffset - _pos));
                Buffer.BlockCopy(_header, (int)_pos, buffer, offset, returnValue);
                _pos += (uint)returnValue;
                offset += returnValue;
                bytesToRead -= returnValue;
            }

            if (bytesToRead <= 0)
                return returnValue;

            bytesToRead = Math.Min(bytesToRead, (int)(_length - _pos));
            uint idxBuffer = _pos - PixelArrayOffset;

            if (_stride == _Stride)
            {
                Marshal.Copy(_Scan0 + (int)idxBuffer, buffer, offset, bytesToRead);
                returnValue += bytesToRead;
                _pos += (uint)bytesToRead;
                return returnValue;
            }

            while (bytesToRead > 0)
            {
                int idxInStride = (int)(idxBuffer / _stride);
                int leftInRow = Math.Max(0, (int)_rowLength - idxInStride);
                int paddingBytes = (int)(_stride - _rowLength);
                int read = Math.Min(bytesToRead, leftInRow);
                if (read > 0)
                    Marshal.Copy(_Scan0 + (int)idxBuffer, buffer, offset, read);
                offset += read;
                idxBuffer += (uint)read;
                bytesToRead -= read;
                returnValue += read;
                read = Math.Min(bytesToRead, paddingBytes);
                for (int i = 0; i < read; i++)
                    buffer[offset + i] = 0;
                offset += read;
                idxBuffer += (uint)read;
                bytesToRead -= read;
                returnValue += read;
            }
            _pos = PixelArrayOffset + (uint)idxBuffer;
            return returnValue;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
                Position = offset;
            else if (origin == SeekOrigin.Current)
                Position += offset;
            else if (origin == SeekOrigin.End)
                Position = Length + offset;
            return Position;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }

    public enum BitmapFormats : int
    {
        /// <summary>
        /// Gray scale bitmap, one byte per pixel.
        /// </summary>
        FPDFBitmap_Gray = 1,

        /// <summary>
        /// 3 bytes per pixel, byte order: blue, green, red.
        /// </summary>
        FPDFBitmap_BGR = 2,

        /// <summary>
        /// 4 bytes per pixel, byte order: blue, green, red, unused.
        /// </summary>
        FPDFBitmap_BGRx = 3,

        /// <summary>
        /// 4 bytes per pixel, byte order: blue, green, red, alpha.
        /// </summary>
        FPDFBitmap_BGRA = 4
    }


}
