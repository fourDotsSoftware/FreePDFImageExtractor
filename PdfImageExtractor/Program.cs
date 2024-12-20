using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace PdfImageExtractor
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        const int ATTACH_PARENT_PROCESS = -1;
        const int ERROR_ACCESS_DENIED = 5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        static void SetupLocalized()
        {
            string[] dirz = System.IO.Directory.GetDirectories(@"c:\Code\Pdf Tools\FreePDFPasswordRemover\helpfile\");
            for (int k = 0; k < dirz.Length; k++)
            {
                System.IO.File.Copy(dirz[k] + "\\PDF Password Remover Users Manual.chm",
                    @"c:\Code\Pdf Tools\FreePDFPasswordRemover\FreePDFPasswordRemover\bin\Debug\" +
                System.IO.Path.GetFileName(dirz[k]) + "\\PDF Password Remover Users Manual.chm");
            }

            dirz = System.IO.Directory.GetDirectories(@"c:\MyWebpages\4dotsSoftware\pdfdocmerge\pdf_password_remover\");

            for (int k = 0; k < dirz.Length; k++)
            {
                System.IO.File.Copy(dirz[k]+"\\index.html",
                @"c:\MyWebpages\4dotsSoftware\pdfdocmerge\pdf_password_remover\index_"+
                System.IO.Path.GetFileName(dirz[k])+".html");
            }
        }

        static void SetupNSILang()
        {
            string[] dirz = System.IO.Directory.GetDirectories(@"c:\MyWebpages\4dotsSoftware\pdfdocmerge\pdf_password_remover\");

            using (StreamWriter sw = new StreamWriter(@"c:\Code\Pdf Tools\FreePDFPasswordRemover\FreePDFPasswordRemover\bin\Debug\nsilang.txt"))
            {
                for (int k = 0; k < dirz.Length; k++)
                {
                    sw.WriteLine("CreateDirectory \"$INSTDIR\\" + System.IO.Path.GetFileName(dirz[k]) + "\"");
                    sw.WriteLine("SetOutPath \"$INSTDIR\\" + System.IO.Path.GetFileName(dirz[k]) + "\"");
                    sw.WriteLine("File \"..\\..\\..\\Dotfuscated\\" + System.IO.Path.GetFileName(dirz[k]) + "\\PDFPasswordRemover.resources.dll\"");
                    sw.WriteLine("File \"" + System.IO.Path.GetFileName(dirz[k]) + "\\PDF Password Remover Users Manual.chm\"");
                }
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            //SetupNSILang();
            //SetupLocalized();
            //Environment.Exit(0);
            //ContextMenuHelper.WriteTest();
            //Environment.Exit(0);
            
            //Module.args = args;
            
            for (int k = 0; k < args.Length; k++)
            {
                //Module.ShowMessage(args[k]);

            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLanguage.SetLanguages();
            SetLanguage();

            if (args.Length > 0 && args[0].StartsWith("/uninstall"))
            {
                Module.DeleteApplicationSettingsFile();

                /*
                frmUninstallQuestionnaire fq = new frmUninstallQuestionnaire();
                fq.ShowDialog();
                */

                System.Diagnostics.Process.Start("https://softpcapps.com/support/bugfeature.php?uninstall=true&app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));

                return;
                Environment.Exit(0);
            }
            
            ExceptionHandlersHelper.AddUnhandledExceptionHandlers();

            if (args.Length > 0)
            {
                //System.Threading.Thread.Sleep(2000);
            }
                      

          //  ContextMenuHelper.DisplayContextMenu();


            Module.args = args;


            
            if (ArgsHelper.IsCommandLine())
            {
                try
                {
                    if (!AttachConsole(ATTACH_PARENT_PROCESS) && Marshal.GetLastWin32Error() == ERROR_ACCESS_DENIED)
                    {
                        AllocConsole();
                    }

                    if (ArgsHelper.ExamineArgs(Module.args))
                    {
                        ArgsHelper.ExecuteCommandLine();
                    }
                    
                }
                finally
                {
                    Environment.Exit(0);
                }
            }

            ArgsHelper.ExamineArgs(args);

            Application.Run(new frmMain());

            return;

            /*
            InitRegistryLuminati();

            while (true)
            {
                string regval = RegistryHelper2.GetKeyValue("Free PDF Image Extractor 4dots", "LuminatiChoice");

                if (regval == "NOTSET")
                {
                    System.Threading.Thread.Sleep(1000);
                }
                else if (regval == "ACCEPT")
                {
                    break;
                }
                else
                {
                    Environment.Exit(0);

                    return;
                }

                Application.DoEvents();
            }           

            //else
            //{
             //   AppDomain.CurrentDomain.ProcessExit += new EventHandler(MiscHelper.CurrentDomain_ProcessExit);

               // if (frmProsEggrafi.RenMove)
               // {
               //     return;
              //  }

                if (frmMain.Instance == null)
                {
                    Application.Run(new frmMain());
                }
                else
                {
                    if (!frmMain.Instance.IsDisposed)
                    {
                        Application.Run(frmMain.Instance);
                    }
                }
            //}
           */
    
            Environment.Exit(0);
        }

        public static void InitRegistryLuminati()
        {
            if (Properties.Settings.Default.FirstTimeRun)
            {
                System.Diagnostics.Process proc2 = new Process();
                proc2.StartInfo.Arguments = "-clearchoice \"Free PDF Image Extractor 4dots\"";
                proc2.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "LuminatiHelper.exe");
                proc2.Start();

                Properties.Settings.Default.FirstTimeRun = false;
            }
            RegistryHelper2.SetKeyValue("Free PDF Image Extractor 4dots", "LuminatiChoice", "NOTSET");

            System.Diagnostics.Process proc = new Process();
            proc.StartInfo.Arguments = "-setup \"win_freepdfimageextractor.4dotssoftware.com\" \"Free PDF Image Extractor 4dots\" \"" + System.IO.Path.Combine(Application.StartupPath, "free-pdf-image-extractor-150.png") + "\"";
            proc.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "LuminatiHelper.exe");
            proc.Start();
        }

        public static void SetLanguage()
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey key2 = Registry.CurrentUser;
            string lang = "";

            try
            {
                key = key.OpenSubKey("Software\\softpcapps Software", true);

                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\softpcapps Software");
                }

                key2 = key.OpenSubKey("PDF Image Extractor", true);

                if (key2 == null)
                {
                    key2 = key.CreateSubKey("PDF Image Extractor");
                }

                key = key2;

                bool setlang = false;

                if (key.GetValue("Language") == null)
                {
                    frmLanguage fl = new frmLanguage();
                    fl.ShowDialog();

                    key.SetValue("Language", frmLanguage.SelectedLanguageCode);
                    setlang = true;   
                    
                }

                if (key != null && key.GetValue("Language") != null)
                {
                    lang = key.GetValue("Language").ToString();
                    Module.SelectedLanguage = lang;
                    if (lang == "en-US")
                    {
                        System.Threading.Thread.CurrentThread.CurrentUICulture =
                            System.Globalization.CultureInfo.InvariantCulture;

                        Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

                    }
                    else
                    {

                        try
                        {
                            System.Threading.Thread.CurrentThread.CurrentUICulture = new
                            System.Globalization.CultureInfo(lang);

                            Application.CurrentCulture = new System.Globalization.CultureInfo(lang);
                        }
                        catch (Exception ex)
                        {
                            Module.ShowError(ex);
                        }
                    }
                }

                if (setlang)
                {
                    key.SetValue("Menu Item Caption", TranslateHelper.Translate("Extract Images from PDF"));
                }
                
            }
            catch (Exception exr)
            {
                Module.ShowError(exr);
            }
            finally
            {
                key.Close();
                key2.Close();
            }            
        }
    }
}