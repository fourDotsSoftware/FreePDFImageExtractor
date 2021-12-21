using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PdfImageExtractor
{
    class PdfHelper
    {
        public static void CreatePdfOneForAllImages(string inputFilepath,string pdf_filepath, List<System.Drawing.Image> images)
        {
            Document document = new Document();

            try
            {
                                
                //Creates a Writer that listens to this document and writes the document to the Stream of your choice:
                PdfWriter.GetInstance(document, new FileStream(pdf_filepath, FileMode.Create));

                //Opens the document:
                document.Open();

                for (int k = 0; k < images.Count; k++)
                {
                    //System.Drawing.Image img_bpv = System.Drawing.Image.FromFile(images[k]);
                    //Image img = Image.GetInstance(images[k]);
                    Image img = Image.GetInstance(images[k], BaseColor.BLACK);
                    

                    int thumbwidth = 550;
                    int thumbheight = 600;

                    int new_thumbheight2 = (int)(thumbwidth * images[k].Height / images[k].Width);
                    int new_thumbwidth2 = (int)(thumbheight * images[k].Width / images[k].Height);

                    if (images[k].Height <= 600 && images[k].Width <= 550)
                    {
                    }
                    else
                    {
                        if (new_thumbwidth2 > 550)
                        {
                            img.ScaleAbsolute(thumbwidth, new_thumbheight2);
                        }
                        else
                        {
                            img.ScaleAbsolute(new_thumbwidth2, thumbheight);
                        }
                    }

                    img.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                    document.Add(img);
                    document.NewPage();
                }
                    
            }
            catch (Exception exp)
            {
                Module.ShowError(exp);

                return;
            }
            finally
            {
                try
                {
                    document.Close();
                }
                catch { }                
            }

            try
            {

                if (System.IO.File.Exists(pdf_filepath))
                {
                    FileInfo fi = new FileInfo(ImagesExtractorHelper.CurrentInputFilepath);

                    FileInfo fi2 = new FileInfo(pdf_filepath);

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
            catch { }
            return;

        }

        public static void CreatePdfSeparateDocument(string inputFilepath,string filepath,System.Drawing.Image image)
        {
            //for (int k = 0; k < images.Count; k++)
            //{
                Document document = new Document();

                try
                {                    
                    //Creates a Writer that listens to this document and writes the document to the Stream of your choice:
                    PdfWriter.GetInstance(document, new FileStream(filepath + ".pdf", FileMode.Create));

                    //Opens the document:
                    document.Open();
                    //Image img = Image.GetInstance(images[k]);
                    Image img = Image.GetInstance(image, BaseColor.BLACK);

                    int thumbwidth = 550;
                    int thumbheight = 600;

                    int new_thumbheight2 = (int)(thumbwidth * img.Height / img.Width);
                    int new_thumbwidth2 = (int)(thumbheight * img.Width / img.Height);

                    if (img.Height <= 600 && img.Width <= 550)
                    {                        
                    }
                    else
                    {
                        if (new_thumbwidth2 > 550)
                        {                            
                            img.ScaleAbsolute(thumbwidth, new_thumbheight2);
                        }
                        else
                        {
                            img.ScaleAbsolute(new_thumbwidth2, thumbheight);
                        }
                    }

                    img.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    document.Add(img);
                }
                catch (Exception exp)
                {
                    Module.ShowError(exp);
                    return;
                }
                finally
                {
                    try
                    {
                        document.Close();
                    }
                    catch { }
                }

            try {

                if (System.IO.File.Exists(filepath + ".pdf"))
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
            catch { }
            //}

            return;

        }

    }
}
