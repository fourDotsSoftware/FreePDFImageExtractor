using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace PdfImageExtractor
{
    class RenameHelper
    {
        public static string GetExtension(string filepath)
        {
            string extension = System.IO.Path.GetExtension(filepath);
            extension = extension.Substring(1);

            if (!frmMain.Instance.chkFormat.Checked || frmChangeFormat.Instance.SelectedFormat == -1)
            {
                //12.2024
                extension = "png";
            }
            else
            {
                switch (frmChangeFormat.Instance.SelectedFormat)
                {
                    case 0:
                        extension = "jpg";
                        break;
                    case 1:
                        extension = "png";
                        break;
                    case 2:
                        extension = "gif";
                        break;
                    case 3:
                        extension = "bmp";
                        break;
                    case 4:
                        extension = "ico";
                        break;
                    case 5:
                        extension = "tiff";
                        break;
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
                    case 6:
                        extension = "jp2";
                        break;
                    case 7:
                        extension = "exr";
                        break;
                    case 8:
                        extension = "hdr";
                        break;
                    case 9:
                        extension = "pbm";
                        break;
                    case 10:
                        extension = "pgm";
                        break;
                    case 11:
                        extension = "ppm";
                        break;
                    case 12:
                        extension = "pfm";
                        break;
                    case 13:
                        extension = "tga";
                        break;
                    case 14:
                        extension = "wbmp";
                        break;
                    case 15:
                        extension = "xpm";
                        break;
                    case 16:
                        extension = "all.pdf";
                        break;
                    case 17:
                        extension = "pdf";
                        break;
                }
            }

            return extension;
        }
        public static string GetNewFilename(string filepath)
        {
            string extension = GetExtension(filepath);
                        
            string filenamenoext = System.IO.Path.GetFileNameWithoutExtension(filepath);
            string newfilename = filenamenoext + "." + extension;
                                    
            if (true) //Module.DoNotOverwriteFiles)
            {
                int k = 0;

                while (true)
                {
                    string newfilepath=System.IO.Path.GetDirectoryName(filepath) + "\\" + newfilename;

                    if (System.IO.File.Exists(newfilepath))
                    {
                        k++;
                        string fn = System.IO.Path.GetFileNameWithoutExtension(newfilepath);

                        if (fn.EndsWith(")"))
                        {
                            int spos = fn.LastIndexOf("(");
                            int num = k;

                            if (int.TryParse(fn.Substring(spos + 1, fn.Length - 1 - spos - 1), out num))
                            {
                                int num1 = num + 1;

                                newfilename = fn.Substring(0, spos + 1) + num1.ToString() + ")" + System.IO.Path.GetExtension(newfilepath);
                            }
                            else
                            {
                                newfilename = System.IO.Path.GetFileNameWithoutExtension(newfilepath) + " (" + k.ToString() + ")" +
                                System.IO.Path.GetExtension(newfilepath);
                            }
                        }
                        else
                        {
                            newfilename = System.IO.Path.GetFileNameWithoutExtension(newfilepath) + " (" + k.ToString() + ")" +
                                System.IO.Path.GetExtension(newfilepath);
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }         

            return newfilename;             
        }        
    }
}
