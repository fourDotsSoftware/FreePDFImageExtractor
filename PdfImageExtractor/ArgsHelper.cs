using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PdfImageExtractor
{ 
    class ArgsHelper
    {
        public static bool FromWindowsExplorer = false;

        public static bool IsCommandLine()
        {
            if (Module.args == null || Module.args.Length == 0)
            {
                return false;
            }

            // new
            if (Module.args.Length > 0 && (Module.args[0].ToLower().Trim().Contains("-tempfile:")
            //    || System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0])
            ))
            {                
                return false;
            }

            Module.IsCommandLine = true;
            return true;
        }


        public static bool ExamineArgs(string[] args)
        {
            if (args.Length == 0) return true;

            //MessageBox.Show(args[0]);

            try
            {
                if (args[0].ToLower().StartsWith("-tempfile:"))
                {
                    FromWindowsExplorer = true;

                    Module.IsFromWindowsExplorer = true;

                    string tempfile = GetParameter(args[0]);

                    //MessageBox.Show(tempfile);

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();

                        //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        args = SplitArguments(scont);
                        Module.args = args;

                        return true;
                       // MessageBox.Show(scont);
                    }
                }
                else if (Module.args.Length > 0 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0])))
                {
                   // FromWindowsExplorer = true;
                }

            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex);
                return false;
            }

            frmMain.Instance = new frmMain();

            try
            {
                //string commandline = "";

                //for (int k = 0; k < Module.args.Length; k++)
                //{
                //    commandline += Module.args[k] + " ";
                //}


                //Module.args = SplitArguments(commandline);

                Module.IsCommandLine = true;

                for (int k = 0; k < Module.args.Length; k++)
                {
                    if (Module.args[k].ToLower().Trim() == "/subdirs" || Module.args[k].ToLower().Trim() == "-subdirs")
                    {
                        Module.CmdAddSubdirectories = true;
                    }
                }

                for (int k = 0; k < Module.args.Length; k++)
                {
                    if (System.IO.File.Exists(Module.args[k]))
                    {
                        frmMain.Instance.AddFile(Module.args[k]);
                    }
                    else if (System.IO.Directory.Exists(Module.args[k]))
                    {
                        frmMain.Instance.AddFolder(Module.args[k]);
                    }
                    else if (Module.args[k].ToLower().Trim() == "/password" || Module.args[k].ToLower().Trim() == "-password")
                    {
                        Module.CmdPassword = Module.args[k + 1];
                    }
                    else if (Module.args[k].ToLower().Trim() == "/outfolder" || Module.args[k].ToLower().Trim() == "-outfolder")
                    {
                        Module.CmdOutputFolder = Module.args[k + 1];
                    }
                    else if (Module.args[k].ToLower().Trim() == "/outfile" || Module.args[k].ToLower().Trim() == "-outfile")
                    {
                        Module.CmdOutputFile = Module.args[k + 1];
                    }
                    else if (Module.args[k].ToLower().Trim() == "/pagerange" || Module.args[k].ToLower().Trim() == "-pagerange")
                    {
                        Module.CmdPageRange = Module.args[k + 1];
                        
                    }
                    else if (Module.args[k] == "/?" || Module.args[k]=="-?")
                    {
                        ShowCommandUsage();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex);
                return false;
            }

            return true;
        }

        public static bool ExecuteCommandLine()
        {
            for (int k = 0; k < frmMain.Instance.dt.Rows.Count; k++)
            {
                if (Module.CmdPageRange != String.Empty)
                {
                    PageRange pr = (PageRange)frmMain.Instance.dt.Rows[k]["pagerange"];
                    pr.AllPages = false;
                    pr.PageRanges = Module.CmdPageRange;
                }

                if (Module.CmdPassword != String.Empty)
                {
                    frmMain.Instance.dt.Rows[k]["password"] = Module.CmdPassword;
                }
            }

            if (Module.CmdOutputFolder != String.Empty)
            {
                frmMain.Instance.rdDocumentsFolder.Checked = true;
                frmMain.Instance.rdSameFolder.Checked = false;
                frmMain.Instance.rdDocumentsFolder.Text = Module.CmdOutputFolder;
            }

            if (Module.CmdOutputFile != String.Empty)
            {
                frmMain.Instance.txtFilename.Text = Module.CmdOutputFile;
            }

            if (frmMain.Instance.dt.Rows.Count > 0)
            {
                Module.ShowMessage("\n\nPlease wait while Extracting Images from PDF...");

                string err=ImagesExtractorHelper.ExtractImages(frmMain.Instance.dt,frmMain.Instance.rdDocumentsFolder.Checked,frmMain.Instance.rdDocumentsFolder.Text,frmMain.Instance.chkFormat.Checked,frmChangeFormat.Instance.SelectedFormat,frmMain.Instance.txtFilename.Text);

                if (err == String.Empty)
                {
                    Module.ShowMessage("Operation Completed Successfully !");

                }
                else
                {
                    Module.ShowMessage("Error" + "\r\n" + err);
                }
            }
            else
            {
                Module.ShowMessage("\n\nPlease specify at least one PDF file !");
            }
            return true;
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str=arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void ShowCommandUsage()
        {
            string msg = GetCommandUsage();

            Module.ShowMessage(msg);

            Environment.Exit(0);
        }
        public static string GetCommandUsage()
        {
            string msg = "PdfImageExtractor - Extracts Images from Pdf Documents.\n\n" +
            "PdfImageExtractor.exe [[file|directory]]" +
            "[/pagerange PAGE_RANGE] " +            
            "[/password PASSWORD]"+
            "[/subdirs]"+
            "[outfilename OUTPUT_FILENAME_PATTERN] "+
            "[outfolder OUTPUT_FOLDER_VALUE] "+
            "[/?]\n\n\n" +
            "file : one or more pdf or image files to be processed.\n" +
            "directory : one or more directories containing pdf or images files to be processed.\n" +
            "pagerange : process pages from only from this range. Command-separated\n"+
            "password: Pdf Password\n"+
            "subdirs : process also subdirectories of specified directories\n"+
            "outfilename : Output filename pattern. Use [PAGENUM],[NUM],[FILENAME],[FILETYPE]\n" +
            "outfolder: Output folder value (if different than the folder of file)\n"+
            "/? : show help\n";

            return msg;            
        }
              

        
                
                
    }

    public class ReadListsResult
    {
        public bool Success = true;
        public string err = "";
    }
}
