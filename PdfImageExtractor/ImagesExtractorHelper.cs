using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PdfImageExtractor
{
    class ImagesExtractorHelper
    {
        public static String RESULT = "Img{0}.{1}";
        public static List<Image> lstAddImages = new List<Image>();

        public static string CurrentInputFilepath = "";

        public static string ExtractImages(DataTable dt, bool rdDocumentsFolder, string rdDocumentsFolderText, bool chkFormat, int SelectedFormat, string txtFilename)
        {
            string err = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (frmMain.Instance.OperationCancelled) return err;

                lstAddImages = new List<Image>();

                try
                {
                    string filepath = dt.Rows[k]["fullfilepath"].ToString();
                    
                    CurrentInputFilepath = filepath;

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
                        PdfHelper.CreatePdfOneForAllImages(CurrentInputFilepath,RESULT, lstAddImages);
                    }
                }
                catch (Exception ex)
                {
                    err += ex.Message;
                }
            }

            return err;

        }

        public static string ExtractImageForPreview(int pagenum, string password, string filepath)
        {
            string outfilepath = System.IO.Path.GetTempPath() + "\\pdfimageextractor.png";

            string err = "";

            try
            {
                if (System.IO.File.Exists(outfilepath))
                {
                    System.IO.File.Delete(outfilepath);
                }

                PdfReader reader = null;

                if (String.IsNullOrEmpty(password))
                {
                    reader = new PdfReader(filepath);
                }
                else
                {
                    reader = new PdfReader(filepath, Encoding.Default.GetBytes(password));
                }
                iTextSharp.text.pdf.parser.PdfReaderContentParser parser = new iTextSharp.text.pdf.parser.PdfReaderContentParser(reader);
                MyImageRenderListener listener = new MyImageRenderListener(outfilepath);
                listener.for_preview_page_extract = true;

                try
                {
                    parser.ProcessContent(pagenum, listener);
                }
                catch (Exception exi)
                {
                    err += exi.Message + "\r\n";
                }

            }
            catch (Exception ex)
            {
                err += ex.Message + "\r\n";
            }

            return err;

        }

        public static string ExtractImages(string filepath, string password, PageRange pagerange, bool add_to_one_pdf)
        {
            string err = "";

            try
            {
                PdfReader reader = null;

                if (String.IsNullOrEmpty(password))
                {
                    reader = new PdfReader(filepath);
                }
                else
                {
                    reader = new PdfReader(filepath, Encoding.Default.GetBytes(password));
                }
                iTextSharp.text.pdf.parser.PdfReaderContentParser parser = new iTextSharp.text.pdf.parser.PdfReaderContentParser(reader);
                MyImageRenderListener listener = new MyImageRenderListener(RESULT);
                listener.add_to_one_pdf = add_to_one_pdf;
                listener.PdfFile = System.IO.Path.GetFileName(filepath);

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    if (frmMain.Instance.OperationCancelled) return err;

                    try
                    {
                        if (ShouldAddPage(i, pagerange, reader))
                        {
                            listener.pagenumber = i;

                            parser.ProcessContent(i, listener);
                        }
                    }
                    catch (Exception exi)
                    {
                        err += exi.Message + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                err += ex.Message + "\r\n";
            }

            return err;
        }

        #region Methods
        #region Public Methods
        /// <summary>Checks whether a specified page of a PDF file contains images.</summary>
        /// <returns>True if the page contains at least one image; false otherwise.</returns>
        public static bool PageContainsImages(string filename, int pageNumber)
        {
            PdfReader reader = null;
            try
            {
                //using (var reader = new PdfReader(filename))
                //{

                //var parser = new PdfReaderContentParser(reader);                                     

                PdfReaderContentParser parser = new PdfReaderContentParser(reader);
                ImageRenderListener listener = null;
                parser.ProcessContent(pageNumber, (listener = new ImageRenderListener()));
                return listener.Images.Count > 0;

                //}
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        /// <summary>Extracts all images (of types that iTextSharp knows how to decode) from a PDF file.</summary>
        public static Dictionary<string, System.Drawing.Image> ExtractImages(string filename)
        {
            var images = new Dictionary<string, System.Drawing.Image>();
            //3using (var reader = new PdfReader(filename))
            PdfReader reader = null;

            try
            {
                reader = new PdfReader(filename);

                var parser = new PdfReaderContentParser(reader);
                ImageRenderListener listener = null;
                for (var i = 1; i <= reader.NumberOfPages; i++)
                {
                    parser.ProcessContent(i, (listener = new ImageRenderListener()));
                    var index = 1;
                    if (listener.Images.Count > 0)
                    {
                        Console.WriteLine("Found {0} images on page {1}.", listener.Images.Count, i);
                        foreach (var pair in listener.Images)
                        {
                            images.Add(string.Format("{0}_Page_{1}_Image_{2}{3}",
                                Path.GetFileNameWithoutExtension(filename), i.ToString("D4"), index.ToString("D4"), pair.Value), pair.Key);
                            index++;
                        }
                    }
                }
                return images;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        /// <summary>Extracts all images (of types that iTextSharp knows how to decode)
        /// from a specified page of a PDF file.</summary>
        /// <returns>Returns a generic <see cref="Dictionary&lt;string, System.Drawing.Image&gt;"/>,
        /// where the key is a suggested file name, in the format: PDF filename without extension,
        /// page number and image index in the page.</returns>
        public static Dictionary<string, System.Drawing.Image> ExtractImages(string filename, int pageNumber)
        {
            Dictionary<string, System.Drawing.Image> images = new Dictionary<string, System.Drawing.Image>();
            PdfReader reader = new PdfReader(filename);
            PdfReaderContentParser parser = new PdfReaderContentParser(reader);
            ImageRenderListener listener = null;
            parser.ProcessContent(pageNumber, (listener = new ImageRenderListener()));
            int index = 1;
            if (listener.Images.Count > 0)
            {
                Console.WriteLine("Found {0} images on page {1}.", listener.Images.Count, pageNumber);
                foreach (KeyValuePair<System.Drawing.Image, string> pair in listener.Images)
                {
                    images.Add(string.Format("{0}_Page_{1}_Image_{2}{3}",
                        Path.GetFileNameWithoutExtension(filename), pageNumber.ToString("D4"), index.ToString("D4"), pair.Value), pair.Key);
                    index++;
                }
            }
            return images;
        }
        #endregion Public Methods
        #endregion Methods

        public static bool ShouldAddPage(int pagenum, PageRange pagerange, PdfReader reader)
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

            if (pagerange.PagesContainingText && reader != null)
            {
                if (iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, pagenum).Contains(
                    pagerange.PageText))
                {
                    return true;
                }
            }
            return false;
        }

        public static string Convert(Image imgfile, string filepath, bool add_to_one_pdf)
        {
            //MessageBox.Show("TEST2");

            string errmsg = "";
            string tmpfile = "";

            FileInfo fi = new FileInfo(CurrentInputFilepath);

            DateTime dtcreated = fi.CreationTime;
            DateTime dtlastmod = fi.LastWriteTime;

            if (!frmMain.Instance.chkBorder.Checked && !frmMain.Instance.chkCanvas.Checked && !frmMain.Instance.chkColorDepth.Checked
                        && !frmMain.Instance.chkColorTransformations.Checked && !frmMain.Instance.chkCrop.Checked && !frmMain.Instance.chkFormat.Checked
                        && !frmMain.Instance.chkResize.Checked && !frmMain.Instance.chkResolution.Checked && !frmMain.Instance.chkRotateFlip.Checked
                        && !frmMain.Instance.chkText.Checked && !frmMain.Instance.chkWatermark.Checked
                && !frmMain.Instance.chkNegative.Checked)
            {
                string newfilename2 = RenameHelper.GetNewFilename(filepath);
                string newfilepath2 = System.IO.Path.GetDirectoryName(filepath) + "\\" + newfilename2;

                imgfile.Save(newfilepath2);

                FileInfo fi2=new FileInfo(newfilepath2);

                if (Properties.Settings.Default.KeepCreationDate)
                {
                    fi2.CreationTime = dtcreated;
                }

                if (Properties.Settings.Default.KeepLastModificationDate)
                {
                    fi2.LastWriteTime = dtlastmod;
                }

                return "";
            }

            try
            {
                tmpfile = System.IO.Path.GetTempFileName();
                imgfile.Save(tmpfile);

                LoadImageReturn lr = null;

                try
                {
                    lr = FreeImageHelper.LoadImageWithFileType(tmpfile);
                }
                catch { return "Error could not load : " + filepath; }

                Bitmap img = lr.img;

                //img.MakeTransparent(Color.White);
                //img.MakeTransparent(Color.Black);

                FreeImageAPI.FREE_IMAGE_FORMAT filetype = lr.FileType;

                //System.Drawing.Imaging.PixelFormat pif = img.PixelFormat;
                //System.Drawing.Imaging.ImageFormat pif = img.RawFormat;


                try
                {

                    if (frmMain.Instance.chkColorDepth.Checked)
                    {
                        img = ColorDepthHelper.ChangeColorDepth(img, filepath, frmColorDepth.Instance.SelectedMaxBits);
                    }

                    if (frmMain.Instance.chkResize.Checked)
                    {
                        img = ResizeHelper.Resize(img, frmResize.Instance.width, frmResize.Instance.height, frmResize.Instance.KeepRatio, frmResize.Instance.Pixels,
                            frmResize.Instance.Percentage, frmResize.Instance.Inches, frmResize.Instance.Cm,
                            frmResize.Instance.Points);
                    }



                    if (frmMain.Instance.chkResolution.Checked)
                    {
                        img = ResolutionHelper.SetResolution(img, frmResolution.Instance.XDPI, frmResolution.Instance.YDPI);
                    }

                    if (frmMain.Instance.chkColorTransformations.Checked)
                    {
                        img = BrightnessCGHelper.ApplyColorTransformations(img,
                           frmColorTransformations.Instance.Brightness, frmColorTransformations.Instance.Contrast, frmColorTransformations.Instance.Gamma,
                           frmColorTransformations.Instance.Red, frmColorTransformations.Instance.Green, frmColorTransformations.Instance.Blue, frmColorTransformations.Instance.Alpha, frmColorTransformations.Instance.Hue, frmColorTransformations.Instance.Saturation,
                           frmColorTransformations.Instance.Value, frmColorTransformations.Instance.Grayscale,
                           frmColorTransformations.Instance.Negative, frmColorTransformations.Instance.Sepia,
                           frmColorTransformations.Instance.Sharpen, frmColorTransformations.Instance.GaussianBlur,
                           frmColorTransformations.Instance.Emboss);
                    }

                    if (frmMain.Instance.chkCrop.Checked)
                    {
                        //img = CropHelper.Crop(img, frmCrop.Instance.width, frmCrop.Instance.height, frmCrop.Instance.unit);
                        img = CropHelper.Crop(img, frmCrop.Instance.width, frmCrop.Instance.height, frmCrop.Instance.KeepRatio, frmCrop.Instance.Pixels,
    frmCrop.Instance.Percentage, frmCrop.Instance.Inches, frmCrop.Instance.Cm, frmCrop.Instance.Points);

                    }


                    if (frmMain.Instance.chkCanvas.Checked)
                    {
                        //img = CanvasHelper.ChangeCanvas(img, frmCanvas.Instance.width, frmCanvas.Instance.height, frmCanvas.Instance.BackgroundColor, frmCanvas.Instance.Pixels);

                        img = CanvasHelper.ChangeCanvas(img, frmCanvas.Instance.width, frmCanvas.Instance.height, frmCanvas.Instance.BackgroundColor, frmCanvas.Instance.KeepRatio, frmCanvas.Instance.Pixels,
    frmCanvas.Instance.Percentage, frmCanvas.Instance.Inches, frmCanvas.Instance.Cm, frmCanvas.Instance.Points);
                    }

                    if (frmMain.Instance.chkRotateFlip.Checked)
                    {
                        img = FlipRotateHelper.FlipRotate(img, frmFlipRotate.Instance.Rotate90, frmFlipRotate.Instance.RotateMinus90, frmFlipRotate.Instance.Rotate180, frmFlipRotate.Instance.FlipH, frmFlipRotate.Instance.FlipV);
                    }

                    if (frmMain.Instance.chkText.Checked)
                    {
                        img = TextHelper.AddText(filepath, img, frmText.Instance.Position,
                            frmText.Instance.X, frmText.Instance.Y, frmText.Instance.txt, frmText.Instance.font, frmText.Instance.color);
                    }

                    if (frmMain.Instance.chkWatermark.Checked)
                    {
                        img = WatermarkHelper.AddWatermark(img, frmWatermark.Instance.Position,
                            frmWatermark.Instance.opacity, frmWatermark.Instance.X, frmWatermark.Instance.Y, frmWatermark.Instance.WaterMarkImage);

                    }

                    if (frmMain.Instance.chkBorder.Checked)
                    {
                        img = BorderHelper.AddBorder(img, frmBorder.Instance.Style1, frmBorder.Instance.Style2,
                    frmBorder.Instance.Style3, frmBorder.Instance.ColorA, frmBorder.Instance.ColorB,
                    frmBorder.Instance.ColorC, frmBorder.Instance.Style1 ? (int)frmBorder.Instance.widthA : 0, frmBorder.Instance.Style2 ? (int)frmBorder.Instance.widthB : 0, frmBorder.Instance.Style3 ? (int)frmBorder.Instance.widthC : 0,
                    frmBorder.Instance.Gradient, frmBorder.Instance.ColorGrA, frmBorder.Instance.ColorGrB, frmBorder.Instance.Ellipse);

                    }

                    if (frmMain.Instance.chkNegative.Checked)
                    {
                        img = (Bitmap)ImageInverter.InvertImage(img);
                    }

                    if (frmMain.Instance.chkFormat.Checked)
                    {
                        if (frmChangeFormat.Instance.SelectedFormat == 16)
                        {
                            add_to_one_pdf = true;
                        }
                        else if (frmChangeFormat.Instance.SelectedFormat == 17)
                        {
                            //sepparate_pdf = true;
                        }
                    }

                    if (!add_to_one_pdf)
                    {

                        string newfilename = RenameHelper.GetNewFilename(filepath);

                        string newfilepath = System.IO.Path.GetDirectoryName(filepath) + "\\" + newfilename;
                        /*
                        FileInfo fi = new FileInfo(filepath);

                        if (System.IO.File.Exists(newfilepath))
                        {
                            if (Module.AskBeforeOverwrite)
                            {
                                DialogResult dres = Module.ShowQuestionDialog("Are you sure that you want to overwrite Image File : " + newfilepath + " ?", "Overwrite Image ?");

                                if (dres != DialogResult.Yes)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                System.IO.File.Delete(newfilepath);
                            }
                        }
                        */

                        if (frmMain.Instance.chkFormat.Checked)
                        {
                            ChangeFormatHelper.ChangeFormat(CurrentInputFilepath,img, newfilepath, frmChangeFormat.Instance.SelectedFormat);
                        }
                        else
                        {
                            //img.Save(newfilepath, pif);

                            // if the format is for example RAW save to PNG since there is no writing enabed
                            // for RAW format..

                            try
                            {

                                FreeImageHelper.SaveBitmap(newfilepath, img, filetype);

                                FileInfo fi2 = new FileInfo(newfilepath);

                                if (Properties.Settings.Default.KeepCreationDate)
                                {
                                    fi2.CreationTime = dtcreated;
                                }

                                if (Properties.Settings.Default.KeepLastModificationDate)
                                {
                                    fi2.LastWriteTime = dtlastmod;
                                }
                            }
                            catch
                            {
                                filepath = System.IO.Path.GetDirectoryName(filepath) + "\\" +
                                    System.IO.Path.GetFileNameWithoutExtension(filepath) + ".png";

                                FreeImageHelper.SaveBitmap(filepath, img, FreeImageAPI.FREE_IMAGE_FORMAT.FIF_PNG);

                                FileInfo fi2 = new FileInfo(newfilepath);

                                if (Properties.Settings.Default.KeepCreationDate)
                                {
                                    fi2.CreationTime = dtcreated;
                                }

                                if (Properties.Settings.Default.KeepLastModificationDate)
                                {
                                    fi2.LastWriteTime = dtlastmod;
                                }
                            }
                        }

                    }
                    else if (add_to_one_pdf)
                    {
                        ImagesExtractorHelper.lstAddImages.Add(img);
                    }

                }
                catch
                {
                    errmsg += "Error. Could not convert Image : " + filepath + "\r\n";
                }
            }
            finally
            {
                if (System.IO.File.Exists(tmpfile))
                {
                    try
                    {
                        System.IO.File.Delete(tmpfile);
                    }
                    catch { }
                }
            }
            return errmsg;
        }

        public static Bitmap ConvertPreview(bool thumbnail, Bitmap img, string filepath, bool for_adjustments)
        {
            try
            {
                //ConvertHelper.imgmona = (Bitmap)Bitmap.FromFile(frmMain.Instance.cmbPreviewFile.SelectedItem.ToString());                               

                if (img == null)
                {
                    /*
                    if (!for_adjustments)
                    {
                        ConvertHelper.imgmona = FreeImageHelper.LoadImage(frmMain.Instance.cmbPreviewFile.SelectedItem.ToString());

                        ConvertHelper.imgmona_filepath = frmMain.Instance.cmbPreviewFile.SelectedItem.ToString();
                    }
                    else
                    {
                        ConvertHelper.imgmona = FreeImageHelper.LoadImage(frmColorTransformations.Instance.cmbPreviewFile.SelectedItem.ToString());

                        ConvertHelper.imgmona_filepath = frmColorTransformations.Instance.cmbPreviewFile.SelectedItem.ToString();
                    }
                    */

                    // img = (Bitmap)Image.FromFile(Module.previewFromPagePath);
                    // filepath = Module.previewFromPagePath;
                }

                img = (Bitmap)Image.FromFile(Module.previewFromPagePath);
                filepath = Module.previewFromPagePath;

                if (frmMain.Instance.chkColorDepth.Checked)
                {
                    img = ColorDepthHelper.ChangeColorDepth(img, filepath, frmColorDepth.Instance.SelectedMaxBits);
                }

                if (!for_adjustments)
                {
                    if (frmMain.Instance.chkResize.Checked)
                    {
                        img = ResizeHelper.Resize(img, frmResize.Instance.width, frmResize.Instance.height, frmResize.Instance.KeepRatio, frmResize.Instance.Pixels,
                            frmResize.Instance.Percentage, frmResize.Instance.Inches, frmResize.Instance.Cm,
                            frmResize.Instance.Points);

                    }
                }

                if (frmMain.Instance.chkResolution.Checked)
                {
                    img = ResolutionHelper.SetResolution(img, frmResolution.Instance.XDPI, frmResolution.Instance.YDPI);
                }

                if (for_adjustments)
                {
                    img = BrightnessCGHelper.ApplyColorTransformations(img,
                       frmColorTransformations.Instance.brightness, frmColorTransformations.Instance.contrast, frmColorTransformations.Instance.gamma,
                       frmColorTransformations.Instance.red, frmColorTransformations.Instance.green, frmColorTransformations.Instance.blue, frmColorTransformations.Instance.Alpha, frmColorTransformations.Instance.Hue, frmColorTransformations.Instance.saturation,
                       frmColorTransformations.Instance.value, frmColorTransformations.Instance.grayscale,
                       frmColorTransformations.Instance.negative, frmColorTransformations.Instance.sepia,
                       frmColorTransformations.Instance.sharpen, frmColorTransformations.Instance.gaussianBlur,
                       frmColorTransformations.Instance.emboss);
                }
                else if (frmMain.Instance.chkColorTransformations.Checked)
                {
                    img = BrightnessCGHelper.ApplyColorTransformations(img,
                       frmColorTransformations.Instance.Brightness, frmColorTransformations.Instance.Contrast, frmColorTransformations.Instance.Gamma,
                       frmColorTransformations.Instance.Red, frmColorTransformations.Instance.Green, frmColorTransformations.Instance.Blue, frmColorTransformations.Instance.Alpha, frmColorTransformations.Instance.Hue, frmColorTransformations.Instance.Saturation,
                       frmColorTransformations.Instance.Value, frmColorTransformations.Instance.Grayscale,
                       frmColorTransformations.Instance.Negative, frmColorTransformations.Instance.Sepia,
                       frmColorTransformations.Instance.Sharpen, frmColorTransformations.Instance.GaussianBlur,
                       frmColorTransformations.Instance.Emboss);
                }

                if (frmMain.Instance.chkCrop.Checked)
                {
                    //img = CropHelper.Crop(img, frmCrop.Instance.width, frmCrop.Instance.height, frmCrop.Instance.unit);
                    img = CropHelper.Crop(img, frmCrop.Instance.width, frmCrop.Instance.height, frmCrop.Instance.KeepRatio, frmCrop.Instance.Pixels,
    frmCrop.Instance.Percentage, frmCrop.Instance.Inches, frmCrop.Instance.Cm, frmCrop.Instance.Points);
                }


                if (frmMain.Instance.chkCanvas.Checked)
                {
                    //img = CanvasHelper.ChangeCanvas(img, frmCanvas.Instance.width, frmCanvas.Instance.height, frmCanvas.Instance.BackgroundColor,frmCanvas.Instance.Pixels);
                    img = CanvasHelper.ChangeCanvas(img, frmCanvas.Instance.width, frmCanvas.Instance.height, frmCanvas.Instance.BackgroundColor, frmCanvas.Instance.KeepRatio, frmCanvas.Instance.Pixels,
    frmCanvas.Instance.Percentage, frmCanvas.Instance.Inches, frmCanvas.Instance.Cm, frmCanvas.Instance.Points);

                }

                if (frmMain.Instance.chkRotateFlip.Checked)
                {
                    img = FlipRotateHelper.FlipRotate(img, frmFlipRotate.Instance.Rotate90, frmFlipRotate.Instance.RotateMinus90, frmFlipRotate.Instance.Rotate180, frmFlipRotate.Instance.FlipH, frmFlipRotate.Instance.FlipV);
                }

                if (frmMain.Instance.chkText.Checked)
                {

                    img = TextHelper.AddText(filepath, img, frmText.Instance.Position,
                        frmText.Instance.X, frmText.Instance.Y, frmText.Instance.txt, frmText.Instance.font, frmText.Instance.color);
                }

                if (frmMain.Instance.chkWatermark.Checked)
                {
                    img = WatermarkHelper.AddWatermark(img, frmWatermark.Instance.Position,
                        frmWatermark.Instance.opacity, frmWatermark.Instance.X, frmWatermark.Instance.Y, frmWatermark.Instance.WaterMarkImage);

                }

                if (frmMain.Instance.chkBorder.Checked)
                {
                    img = BorderHelper.AddBorder(img, frmBorder.Instance.Style1, frmBorder.Instance.Style2,
                frmBorder.Instance.Style3, frmBorder.Instance.ColorA, frmBorder.Instance.ColorB,
                frmBorder.Instance.ColorC, frmBorder.Instance.Style1 ? (int)frmBorder.Instance.widthA : 0, frmBorder.Instance.Style2 ? (int)frmBorder.Instance.widthB : 0, frmBorder.Instance.Style3 ? (int)frmBorder.Instance.widthC : 0,
                frmBorder.Instance.Gradient, frmBorder.Instance.ColorGrA, frmBorder.Instance.ColorGrB, frmBorder.Instance.Ellipse);

                }

                if (frmMain.Instance.chkNegative.Checked)
                {
                    img = (Bitmap)ImageInverter.InvertImage(img);
                }

                /*
                    if (frmMain.Instance.chkFormat.Checked)
                    {
                        if (frmChangeFormat.SelectedFormat == 9)
                        {
                            add_to_one_pdf = true;
                        }
                        else
                        {
                            img = ChangeFormatHelper.ChangeFormat(img, filepath, frmChangeFormat.SelectedFormat);
                        }
                    }
                */

                if (thumbnail)
                {
                    if (img.Width > 256)
                    {
                        float scale = (float)img.Height / (float)img.Width;
                        int new_height = (int)(scale * 256);

                        img = new Bitmap(img, 256, new_height);
                        //ConvertHelper.imgmona.Save(System.IO.Path.GetTempPath() + "\\ImgTransformerTemp.bmp");
                        //imgmona_filepath = System.IO.Path.GetTempPath() + "\\ImgTransformerTemp.bmp";


                    }
                }

                return img;
            }
            catch
            {
                return (Bitmap)Image.FromFile(Module.previewFromPagePath);
            }
        }
    }

        class NewMyImageRenderListener : iTextSharp.text.pdf.parser.IRenderListener
        {
            /** The new document to which we've added a border rectangle. */
            protected String path = "";
            public bool add_to_one_pdf = false;
            public bool for_preview_page_extract = false;

            public string PdfFile = "";
            public int pagenumber = 0;

            private int ImageNumber = 1;

            /**
             * Creates a RenderListener that will look for images.
             */
            public NewMyImageRenderListener(String path)
            {
                this.path = path;
            }

            /**
             * @see com.itextpdf.text.pdf.parser.RenderListener#beginTextBlock()
             */
            public void BeginTextBlock()
            {
            }

            /**
             * @see com.itextpdf.text.pdf.parser.RenderListener#endTextBlock()
             */
            public void EndTextBlock()
            {
            }

            /**
             * @see com.itextpdf.text.pdf.parser.RenderListener#renderImage(
             *     com.itextpdf.text.pdf.parser.ImageRenderInfo)
             */
            public void RenderImage(iTextSharp.text.pdf.parser.ImageRenderInfo renderInfo)
            {
                try
                {
                    String filename = path;

                    PdfImageObject image = renderInfo.GetImage();
                    PdfName filter = (PdfName)image.Get(PdfName.FILTER);

                    if (image == null) return;

                    if (filter != null)
                    {
                    System.Drawing.Image drawingImage = image.GetDrawingImage();

                        if (drawingImage==null) return;

                    //3string extension = ".";

                    string extension = "";

                    if (filter == PdfName.DCTDECODE)
                    {
                        extension += PdfImageObject.ImageBytesType.JPG.FileExtension;
                    }
                    else if (filter == PdfName.JPXDECODE)
                    {
                        extension += PdfImageObject.ImageBytesType.JP2.FileExtension;
                    }
                    else if (filter == PdfName.FLATEDECODE)
                    {
                        extension += PdfImageObject.ImageBytesType.PNG.FileExtension;
                    }
                    else if (filter == PdfName.LZWDECODE)
                    {
                        extension += PdfImageObject.ImageBytesType.CCITT.FileExtension;
                    }
                    /* Rather than struggle with the image stream and try to figure out how to handle
                     * BitMapData scan lines in various formats (like virtually every sample I’ve found
                     * online), use the PdfImageObject.GetDrawingImage() method, which does the work for us. */
                    //3this.Images.Add(drawingImage, extension);
                    
                    /*
                    System.IO.MemoryStream os;
                    iTextSharp.text.pdf.parser.PdfImageObject image = renderInfo.GetImage();
                    if (image == null) return;
                    */
                    filename = filename.Replace("[PAGENUM]", pagenumber.ToString());
                    filename = filename.Replace("[NUM]", ImageNumber.ToString());
                    filename = filename.Replace("[FILENAME]", PdfFile);
                    //3filename = filename.Replace("[FILETYPE]", image.GetFileType());

                    filename = filename.Replace("[FILETYPE]", extension);

                    //filename = String.Format(path, renderInfo.GetRef().Number, image.GetFileType());

                    ImageNumber++;

                    /*
                    os = new System.IO.MemoryStream(); //filename,System.IO.FileMode.Create);
                    os.Write(image.GetImageAsBytes(), 0, image.GetImageAsBytes().Length);
                    os.Flush();

                    os.Position = 0;

                    Image img = Image.FromStream(os);
                    */

                    if (for_preview_page_extract)
                    {
                        //3img.Save(System.IO.Path.GetTempPath() + "\\pdfimageextractor.png");

                        drawingImage.Save(System.IO.Path.GetTempPath() + "\\pdfimageextractor"+"."+extension);

                    }
                    else
                    {
                        //3ImagesExtractorHelper.Convert(img, filename, add_to_one_pdf);

                        ImagesExtractorHelper.Convert(drawingImage, filename, add_to_one_pdf);
                    }

                    //3os.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            /**
             * @see com.itextpdf.text.pdf.parser.RenderListener#renderText(
             *     com.itextpdf.text.pdf.parser.TextRenderInfo)
             */
            public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo)
            {
            }
        }

        class MyImageRenderListener : iTextSharp.text.pdf.parser.IRenderListener
        {
            /** The new document to which we've added a border rectangle. */
            protected String path = "";
            public bool add_to_one_pdf = false;
            public bool for_preview_page_extract = false;

            public string PdfFile = "";
            public int pagenumber = 0;

            private int ImageNumber = 1;

            /**
             * Creates a RenderListener that will look for images.
             */
            public MyImageRenderListener(String path)
            {
                this.path = path;
            }

            /**
             * @see com.itextpdf.text.pdf.parser.RenderListener#beginTextBlock()
             */
            public void BeginTextBlock()
            {
            }

            /**
             * @see com.itextpdf.text.pdf.parser.RenderListener#endTextBlock()
             */
            public void EndTextBlock()
            {
            }

            /**
             * @see com.itextpdf.text.pdf.parser.RenderListener#renderImage(
             *     com.itextpdf.text.pdf.parser.ImageRenderInfo)
             */
            public void RenderImage(iTextSharp.text.pdf.parser.ImageRenderInfo renderInfo)
            {
                try
                {
                    String filename = path;
                    System.IO.MemoryStream os;
                    iTextSharp.text.pdf.parser.PdfImageObject image = renderInfo.GetImage();
                    if (image == null) return;

                    filename = filename.Replace("[PAGENUM]", pagenumber.ToString());
                    filename = filename.Replace("[NUM]", ImageNumber.ToString());
                    filename = filename.Replace("[FILENAME]", PdfFile);
                    filename = filename.Replace("[FILETYPE]", image.GetFileType());

                    //filename = String.Format(path, renderInfo.GetRef().Number, image.GetFileType());

                    ImageNumber++;

                    os = new System.IO.MemoryStream(); //filename,System.IO.FileMode.Create);
                    os.Write(image.GetImageAsBytes(), 0, image.GetImageAsBytes().Length);
                    os.Flush();

                    os.Position = 0;

                    Image img = Image.FromStream(os);

                    if (for_preview_page_extract)
                    {
                        img.Save(System.IO.Path.GetTempPath() + "\\pdfimageextractor.png");

                    }
                    else
                    {
                        ImagesExtractorHelper.Convert(img, filename, add_to_one_pdf);
                    }

                    os.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            /**
             * @see com.itextpdf.text.pdf.parser.RenderListener#renderText(
             *     com.itextpdf.text.pdf.parser.TextRenderInfo)
             */
            public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo)
            {
            }
        }

        public class PreviewPic : System.Windows.Forms.PictureBox
        {
            protected override void OnPaint(PaintEventArgs pe)
            {
                try
                {
                    base.OnPaint(pe);
                }
                catch (Exception ex)
                {
                    this.Image = null;
                    Module.ShowError("Error could not show Preview !", ex);

                    this.Image = Module.imgmona;
                    this.Width = Module.imgmona.Width;
                    this.Height = Module.imgmona.Height;
                }
            }
        }

    public class ImageRenderListener : IRenderListener
        {
            #region Fields
            Dictionary<System.Drawing.Image, string> images = new Dictionary<System.Drawing.Image, string>();
            #endregion Fields
            #region Properties
            public Dictionary<System.Drawing.Image, string> Images
            {
                get { return images; }
            }
            #endregion Properties
            
            public void BeginTextBlock() { }
            public void EndTextBlock() { }
            public void RenderImage(ImageRenderInfo renderInfo)
            {
                PdfImageObject image = renderInfo.GetImage();
                PdfName filter = (PdfName)image.Get(PdfName.FILTER);

                //int width = Convert.ToInt32(image.Get(PdfName.WIDTH).ToString());
                //int bitsPerComponent = Convert.ToInt32(image.Get(PdfName.BITSPERCOMPONENT).ToString());
                //string subtype = image.Get(PdfName.SUBTYPE).ToString();
                //int height = Convert.ToInt32(image.Get(PdfName.HEIGHT).ToString());
                //int length = Convert.ToInt32(image.Get(PdfName.LENGTH).ToString());
                //string colorSpace = image.Get(PdfName.COLORSPACE).ToString();
                /* It appears to be safe to assume that when filter == null, PdfImageObject
                 * does not know how to decode the image to a System.Drawing.Image.
                 *
                 * Uncomment the code above to verify, but when I’ve seen this happen,
                 * width, height and bits per component all equal zero as well. */
                if (filter != null)
                {
                    System.Drawing.Image drawingImage = image.GetDrawingImage();
                    string extension = ".";
                    if (filter == PdfName.DCTDECODE)
                    {
                        extension += PdfImageObject.ImageBytesType.JPG.FileExtension;
                    }
                    else if (filter == PdfName.JPXDECODE)
                    {
                        extension += PdfImageObject.ImageBytesType.JP2.FileExtension;
                    }
                    else if (filter == PdfName.FLATEDECODE)
                    {
                        extension += PdfImageObject.ImageBytesType.PNG.FileExtension;
                    }
                    else if (filter == PdfName.LZWDECODE)
                    {
                        extension += PdfImageObject.ImageBytesType.CCITT.FileExtension;
                    }
                    /* Rather than struggle with the image stream and try to figure out how to handle
                     * BitMapData scan lines in various formats (like virtually every sample I’ve found
                     * online), use the PdfImageObject.GetDrawingImage() method, which does the work for us. */
                    this.Images.Add(drawingImage, extension);
                }
            }
            public void RenderText(TextRenderInfo renderInfo) { }
    }
    
}

