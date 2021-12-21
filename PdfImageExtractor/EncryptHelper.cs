using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.factories;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace PdfImageExtractor
{
    class EncryptHelper
    {
        //PdfEncryptor.Encrypt(reader,myFileStream,PdfWriter.ENCRYPTION_RC4_128,sU 
        //Password,"test",PdfWriter.AllowPrinting|PdfWriter.AllowCopy); 

        public static string Title = "";
        public static string Author = "";
        public static string Subject = "";
        public static string Keywords = "";
        public static bool SetDocInfo = false;

        public static string EncryptMultiplePDF(DataTable dt)
        {
            string err = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                string outfilepath="";
                string filepath=dt.Rows[k]["fullfilepath"].ToString();

                if (frmMain.Instance.rdDocumentsFolder.Checked)
                {
                    outfilepath = Module.UserDocumentsFolder + "\\" + System.IO.Path.GetFileName(filepath);
                }
                else
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);
                    outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_protected.pdf");
                }

                try
                {
                    err += EncryptSinglePDF(filepath, outfilepath);
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }
            }

            return err;
        }

        public static string EncryptSinglePDF(string InputFile, string OutputFile)
        {
            string err = "";

            try
            {
                using (FileStream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    PdfReader reader = null;

                    try
                    {
                        reader = new PdfReader(input);

                        using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            int permissions = 0;
                            if (frmMain.Instance.chkAnnotations.Checked)
                            {
                                permissions |= PdfWriter.ALLOW_MODIFY_ANNOTATIONS;
                            }

                            if (frmMain.Instance.chkAssembly.Checked)
                            {
                                permissions |= PdfWriter.ALLOW_ASSEMBLY;
                            }

                            if (frmMain.Instance.chkCopy.Checked)
                            {
                                permissions |= PdfWriter.ALLOW_COPY;
                            }

                            if (frmMain.Instance.chkFormFill.Checked)
                            {
                                permissions |= PdfWriter.ALLOW_FILL_IN;
                            }

                            if (frmMain.Instance.chkHighPrinting.Checked)
                            {
                                permissions |= PdfWriter.ALLOW_PRINTING;
                            }

                            if (frmMain.Instance.chkLowPrinting.Checked)
                            {
                                permissions |= PdfWriter.ALLOW_DEGRADED_PRINTING;
                            }

                            if (frmMain.Instance.chkModifyContents.Checked)
                            {
                                permissions |= PdfWriter.ALLOW_MODIFY_CONTENTS;
                            }

                            if (frmMain.Instance.chkScreenReaders.Checked)
                            {
                                permissions |= PdfWriter.ALLOW_SCREENREADERS;
                            }

                            bool strength = frmMain.Instance.rd128Bits.Checked;

                            string userp = frmMain.Instance.txtUserPassword.Text;
                            if (userp == "")
                            {
                                userp = null;
                            }

                            string ownerp = frmMain.Instance.txtOwnerPassword.Text;
                            if (ownerp == "")
                            {
                                ownerp = null;
                            }

                            if (SetDocInfo)
                            {
                                Dictionary<string, string> dict = new Dictionary<string, string>();
                                dict.Add("Author", Author);
                                dict.Add("Subject", Subject);
                                dict.Add("Keywords", Keywords);
                                dict.Add("Title", Title);

                                PdfEncryptor.Encrypt(reader, output, strength, userp, ownerp, permissions, dict);
                            }
                            else
                            {
                                PdfEncryptor.Encrypt(reader, output, strength, userp, ownerp, permissions);
                            }
                        }
                    }
                    catch (Exception exm)
                    {
                        err += exm.Message;
                    }
                    finally
                    {
                        reader.Close();

                    }

                }
            }
            catch (Exception ex)
            {
                err += ex.Message;
            }

            return err;
        }
    }
}
