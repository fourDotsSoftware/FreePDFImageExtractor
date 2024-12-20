using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using Microsoft.Win32;
using System.Diagnostics;
//timer1 not enabled timer2 enabled timer3 enabled

namespace PdfImageExtractor
{
    public partial class frmMain : PdfImageExtractor.CustomForm
    {
        public static frmMain Instance = null;

        public string PreviewFile = Module.imgmona_filepath;

        public DataTable dt = new DataTable("pdfs");

        public bool OperationCancelled = false;

        private string Err = "";

        private bool rdDocumentsFolderChecked=false;
        private string rdDocumentsFolderText="";
        private bool chkFormatChecked=false;
        private int SelectedFormat=-1;
        private string txtFilenameText = "";

        public frmMain()
        {
            InitializeComponent();

            rdDocumentsFolder.Text = Module.UserDocumentsFolder;
            dgFiles.AutoGenerateColumns = false;

            dt.Columns.Add("filename");
            dt.Columns.Add("sizekb");
            dt.Columns.Add("fullfilepath");
            dt.Columns.Add("filedate");
            dt.Columns.Add("password");
            dt.Columns.Add("pagerange", typeof(PageRange));
            dt.Columns.Add("rootfolder");

            Instance = this;

            if (Module.IsCommandLine || Module.IsFromWindowsExplorer)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
            else  if (Properties.Settings.Default.ShowPromotion)
            {
                frmPromotion fp = new frmPromotion();
                fp.Show(this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //iTextSharp.text.Document doc = new iTextSharp.text.Document();

            PdfReader reader = new PdfReader(@"c:\4\head first ajax.pdf");

            Document doc = new Document(reader.GetPageSizeWithRotation(1));

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"c:\4\test.pdf",FileMode.Create));
            doc.Open();
            PdfContentByte cb = writer.DirectContent;

            /*
            for (int k = 1; k <= reader.NumberOfPages; k++)
            {
                doc.SetPageSize(reader.GetPageSizeWithRotation(i));
                PdfDictionary pdfdict=pdfReader.GetPageN(k);
                PdfImportedPage imp=pdfWriter.GetImportedPage(pdfReader, k);
                pdfWriter.Add(imp);

            }
            */
        }

        private void AddVisual(string[] argsvisual)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //Module.ShowMessage("Is From Windows Explorer");                                

                for (int k = 0; k < argsvisual.Length; k++)
                {
                    if (System.IO.File.Exists(argsvisual[k]))
                    {
                        AddFile(argsvisual[k]);

                    }
                    else if (System.IO.Directory.Exists(argsvisual[k]))
                    {
                        AddFolder(argsvisual[k]);
                    }
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        bool FreeForPersonalUse = false;
        bool FreeForPersonalAndCommercialUse = true;

        private void SetTitle()
        {
            string str = "";

            if (!FreeForPersonalUse && !FreeForPersonalAndCommercialUse)
            {
                /*
                if (frmAbout.LDT == string.Empty)
                {
                    str += " - " + TranslateHelper.Translate("Trial Version - Unlicensed - Please Buy !");
                }
                else
                {
                    str += " - " + TranslateHelper.Translate("Licensed Version");
                }*/
            }
            else if (FreeForPersonalUse)
            {
                str += " - " + TranslateHelper.Translate("Free for Personal Use Only - Please Donate !");
            }
            else if (FreeForPersonalAndCommercialUse)
            {
                str += " - " + TranslateHelper.Translate("Free for Personal and Commercial Use - Please Donate !");
            }

            this.Text = Module.ApplicationTitle + str.ToUpper();
        }

        private void SetupOnLoad()
        {            
            this.Text = Module.ApplicationTitle;

            SetTitle();

            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Left = 0;
            AddLanguageMenuItems();                                 

            lblExplanation.Text = "[PAGENUM] : " + TranslateHelper.Translate("Page Number") + "\r\n" +
                "[NUM] : " + TranslateHelper.Translate("Number of Image") + "\r\n" +
                "[FILETYPE] : " + TranslateHelper.Translate("Image File Type") + "\r\n" +
                "[FILENAME] : " + TranslateHelper.Translate("Filename of Pdf File");
               // "[FULLPATH] : " + TranslateHelper.Translate("Full Path of Pdf File");
                           
            keepFolderStructureToolStripMenuItem.Checked = Properties.Settings.Default.KeepFolderStructure;

            if (Properties.Settings.Default.DocumentOutputFolder != string.Empty)
            {
                rdDocumentsFolder.Text = Properties.Settings.Default.DocumentOutputFolder;
            }

            if (Properties.Settings.Default.OutputRadioIndex == 0)
            {
                rdSameFolder.Checked = true;
            }
            else
            {
                rdDocumentsFolder.Checked = true;
            }

            txtFilename.Text = Properties.Settings.Default.FilenamePattern;

            RecentFilesHelper.FillMenuRecentFile();
            RecentFilesHelper.FillMenuRecentFolder();
            RecentFilesHelper.FillMenuRecentImportList();

            checkForNewVersionEachWeekToolStripMenuItem.Checked = Properties.Settings.Default.CheckWeek;

            //=========

            exploreOutputFolderWhenDoneToolStripMenuItem.Checked =
                Properties.Settings.Default.ExploreOutputFolder;

            keepCreationDateToolStripMenuItem.Checked =
                Properties.Settings.Default.KeepCreationDate;

            keepLastModificationDateToolStripMenuItem.Checked =
                Properties.Settings.Default.KeepLastModificationDate;

            showMessageOnSucessToolStripMenuItem.Checked =
                Properties.Settings.Default.ShowMessageOnSucess;

            saveOnlyUniqueImagesToolStripMenuItem.Checked = Properties.Settings.Default.SaveOnlyUniqueImages;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {                                   
            dgFiles.DataSource = dt;

            SetupOnLoad();

            if (!Module.IsCommandLine && !Module.IsFromWindowsExplorer)
            {
                if (Properties.Settings.Default.CheckWeek)
                {
                    UpdateHelper.InitializeCheckVersionWeek();
                }
            }

            ResizeControls();

            if (ArgsHelper.FromWindowsExplorer)
            {
                AddVisual(Module.args);

                btnExtractImages_Click(null, null);

                Environment.Exit(0);
            }
        }

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Module.SelectedLanguage == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);
                languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languageToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }

        private void ChangeLanguage(string language_code)
        {
            RegistryKey key = Registry.CurrentUser;
            try
            {
                key = key.OpenSubKey("SOFTWARE\\softpcapps Software\\PDF Image Extractor", true);

                key.SetValue("Language", language_code);
                Program.SetLanguage();
                key.SetValue("Menu Item Caption", TranslateHelper.Translate("Extract Images from PDF"));
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);
                return;
            }
            finally
            {
                key.Close();
            }            

            this.Controls.Clear();           

            InitializeComponent();            

            SetupOnLoad();

        }

        #endregion
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.DialogFilesFilter;
            openFileDialog1.Multiselect = true;
            
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                    {                        
                        AddFile(openFileDialog1.FileNames[k]);
                        RecentFilesHelper.AddRecentFile(openFileDialog1.FileNames[k]);
                    }
                }
                finally
                {
                    this.Cursor = null;
                }
            }
        }

        public bool AddFile(string filepath)
        {
            return AddFile(filepath, "","");
        }

        public bool AddFile(string filepath, string password)
        {
            return AddFile(filepath, password, "");
        }

        public bool AddFile(string filepath,string password,string rootfolder)
        {
            if (filepath.Trim() == string.Empty) return false;

            if (System.IO.Path.GetExtension(filepath).ToLower() != ".pdf")
            {
                Module.ShowMessage("Please add only PDF Files !");
                return false;
            }

            DataRow dr = dt.NewRow();
                        
            FileInfo fi=new FileInfo(filepath);

            long sizekb=fi.Length/1024;
            dr["filename"]=fi.Name;
            dr["fullfilepath"] = filepath;
            dr["sizekb"] = sizekb.ToString() + "KB";
            dr["filedate"] = fi.LastWriteTime.ToString();
            dr["pagerange"] = new PageRange();
            dr["password"] = password;
            dr["rootfolder"] = rootfolder;

            dt.Rows.Add(dr);

            return true;
        }                                                                

        private void btnAddFolder_Click(object sender, EventArgs e)
        {            
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFolder(folderBrowserDialog1.SelectedPath);
                RecentFilesHelper.AddRecentFolder(folderBrowserDialog1.SelectedPath);
            }
        }

        public void AddFolder(string folder_path)
        {
            AddFolder(folder_path, "");
        }

        public void AddFolder(string folder_path,string password)
        {
            string[] filez = null;

            if (Module.IsCommandLine)
            {
                if (Module.CmdAddSubdirectories)
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                }
            }
            else
            {

                if (System.IO.Directory.GetDirectories(folder_path).Length > 0)
                {
                    DialogResult dres = Module.ShowQuestionDialog("Would you like to add also Subdirectories ?", "Add Subdirectories ?");

                    if (dres == DialogResult.Yes)
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                    }
                    else
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                    }
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                }
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < filez.Length; k++)
                {
                    if (filez[k].ToLower().EndsWith(".pdf"))
                    {
                        AddFile(filez[k],password,folder_path);
                    }
                    
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }                        

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = dgFiles.SelectedCells;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int k = 0; k < cells.Count; k++)
            {
                if (rows.IndexOf(dgFiles.Rows[cells[k].RowIndex]) < 0)
                {
                    rows.Add(dgFiles.Rows[cells[k].RowIndex]);
                }
            }

            for (int k = 0; k < rows.Count; k++)
            {
                dgFiles.Rows.Remove(rows[k]);
            }
                       
        }

        private void tiHelpFeedback_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://softpcapps.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.SelectedRows.Count == 0) return;

            System.Diagnostics.Process.Start(dgFiles.SelectedRows[0].Cells["colFullFilepath"].Value.ToString());

        }               

        private bool IsDragging = false;

        /*
        private void lvDocs_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void lvDocs_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void lvDocs_DragDrop(object sender, DragEventArgs e)
        {           

            Point pt = lvDocs.PointToClient(Cursor.Position);
            ListViewHitTestInfo hiti = lvDocs.HitTest(pt.X, pt.Y);

            //if (hiti.Item != null)
            //{

            int ind = -1;
            if (hiti.Item != null)
            {
                ind = hiti.Item.Index;
            }

            List<ListViewItem> lst = new List<ListViewItem>();

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    bool isimage = false;                                        

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }

                    lst.Add(lvDocs.Items[lvDocs.Items.Count - 1]);
                }

                if (hiti.Item != null && (lvDocs.Items.Count != lst.Count))
                {
                    for (int k = 0; k < lst.Count; k++)
                    {
                        lvDocs.Items.Remove(lst[k]);
                    }

                    for (int k = 0; k < lst.Count; k++)
                    {
                        lvDocs.Items.Insert(ind + k, lst[k]);
                    }
                }
            }


            //}

        }
        */                                                      

        private void buyNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.StoreUrl);
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        protected override void WndProc(ref Message m)
        {
            /*
            if (m.Msg == Program.WM_MULTIPLE_SEARCH_REPLACE)
            {
                MessageBox.Show(m.GetLParam(typeof(string)).ToString());
                lstIncludePaths.Items.Add(m.GetLParam(typeof(string)));
            }
            base.WndProc(ref m);
            */

            if (m.Msg == MessageHelper.WM_COPYDATA)
            {
                MessageHelper.COPYDATASTRUCT mystr = new MessageHelper.COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (MessageHelper.COPYDATASTRUCT)m.GetLParam(mytype);
                //MessageBox.Show(mystr.lpData);

                string arg = mystr.lpData;

                //MessageBox.Show("RECEIVED MESSAGE :" + arg);
                string[] args = arg.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

                //frmClientImages.Instance.ShowSendToMenuForm(args);
                for (int n = 1; n <= args.GetUpperBound(0); n++)
                {
                    //MessageBox.Show(args[n]);
                }

                AddVisual(args);


            }
            else if (m.Msg == MessageHelper.WM_ACTIVATEAPP)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }



            base.WndProc(ref m);
        }

        private void helpGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Module.SelectedLanguage == "en-US")
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Free PDF Image Extractor 4dots - Users Manual.chm");
            }
            else
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + Module.SelectedLanguage + "\\Free PDF Image Extractor 4dots - Users Manual.chm");
            }
        }

        private void btnClearMerge_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();                        
            
        }

        private void btnExtractImages_Click(object sender, EventArgs e)
        {            
            try
            {
                //=========

                Properties.Settings.Default.ExploreOutputFolder = exploreOutputFolderWhenDoneToolStripMenuItem.Checked;

                Properties.Settings.Default.KeepCreationDate = keepCreationDateToolStripMenuItem.Checked;

                Properties.Settings.Default.KeepLastModificationDate = keepLastModificationDateToolStripMenuItem.Checked;

                Properties.Settings.Default.ShowMessageOnSucess = showMessageOnSucessToolStripMenuItem.Checked;

                Properties.Settings.Default.SaveOnlyUniqueImages = saveOnlyUniqueImagesToolStripMenuItem.Checked;

                dgFiles.EndEdit();


                if (dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please add PDF Files first !");
                    return;
                }

                //this.Enabled = false;

                EnableDisableForm(false);

                /*
                if (dt.Rows.Count > 3 && frmAbout.LDT == String.Empty)
                {
                    frmFullActivate fa = new frmFullActivate();
                    fa.ShowDialog();
                    return;
                }
                */

                OperationCancelled = false;
                Err = "";

                rdDocumentsFolderChecked=rdDocumentsFolder.Checked;
                rdDocumentsFolderText=rdDocumentsFolder.Text;
                chkFormatChecked=chkFormat.Checked;
                SelectedFormat=frmChangeFormat.Instance.SelectedFormat;
                txtFilenameText = txtFilename.Text;

                frmProgress fp = new frmProgress();
                fp.Show(this);

                backgroundWorker1.RunWorkerAsync();

                //string err = EncryptHelper.EncryptMultiplePDF(dt);                                                

                while (backgroundWorker1.IsBusy)
                {
                    Application.DoEvents();
                }

                fp.Close();

                if (OperationCancelled)
                {
                    Module.ShowMessage("Operation Cancelled !");
                }
                else if (Err == String.Empty)
                {
                    if (Properties.Settings.Default.ShowMessageOnSucess)
                    {
                        Module.ShowMessage("Operation completed successfully !");
                    }

                    if (!Module.IsFromWindowsExplorer)
                    {
                        if (Properties.Settings.Default.ExploreOutputFolder)
                        {
                            btnOpenFolder_Click(null, null);
                        }
                    }
                }
                else
                {
                    frmMessage f = new frmMessage();
                    f.lblMsg.Text = TranslateHelper.Translate("Operation completed with Errors !");
                    f.txtMsg.Text = Err;

                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error", ex);
            }
            finally
            {
                //this.Enabled = true;

                EnableDisableForm(true);
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            /*
            int bsize = btnExtractImages.Width + 20 + btnExit.Width;
            btnExtractImages.Left = (this.ClientRectangle.Width / 2) - (bsize / 2);
            btnExit.Left = btnExtractImages.Right + 20;
            */
            
        }

        private void dgFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    bool isimage = false;

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }                    
                }                
            }

        }

        private void dgFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void dgFiles_DragOver(object sender, DragEventArgs e)
        {
            IsDragging = true;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void downloadMultipleSearchAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.multiplereplace.com");
        }

        private void downloadPDFMergeSplitToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pdfdocmerge.com/pdfmergesplittool/");

        }

        private void downloadFreeFileUnlockerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.freefileunlocker.com");
        }

        private void downloadImgTransformerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.imgtransformer.com");
        }

        private void downloadFreeImagemapperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/imagemapper2/");
        }

        private void downloadCopyPathToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/copypathtoclipboard/");
        }

        private void downloadCopyTextContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/copytextcontents/");
        }

        private void downloadOpenCommandPromptHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/open_command_prompt_here/");
        }

        private void downloadFreeColorwheelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/colorwheel/");
        }

        private void visit4dotsSoftwareWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://softpcapps.com");
        }


        private void downloadDocusTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/freedocustree/");
        }               

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            dgFiles.EndEdit();

            if (rdSameFolder.Checked)
            {
                if (dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please add a PDF File first !");

                }
                else
                {
                    string dirpath = "";
                    string filepath = "";

                    
                    dirpath = System.IO.Path.GetDirectoryName(dgFiles.Rows[0].Cells["colFullfilepath"].Value.ToString());
                    filepath = dirpath + "\\" + System.IO.Path.GetFileName(dgFiles.Rows[0].Cells["colFullfilepath"].Value.ToString()) + ".extracted_images\\";
                                      
                                        
                    //string args = string.Format("/e, /select, \"{0}\"",filepath);
                    string args = filepath;

                    if (chkFormat.Checked && frmChangeFormat.Instance.SelectedFormat == 16)
                    {
                        args = string.Format("/e, /select, \"{0}\"", dgFiles.Rows[0].Cells["colFullfilepath"].Value.ToString()+".extracted_images.pdf");
                    }

                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "explorer";
                    info.UseShellExecute = true;
                    info.Arguments = args;
                    Process.Start(info);
                    
                    /*
                    return;
                    List<IntPtr> lst = new List<IntPtr>();
                    IntPtr pidlFolder = IntPtr.Zero;
                    IntPtr[] pidl = new IntPtr[] { IntPtr.Zero };

                    

                    UInt32 a = 0;

                    if (Module.SHParseDisplayName(filepath, IntPtr.Zero,out pidlFolder,(UInt32) 0, out (UInt32)a) != 0)
                    {
                        lst.Add(pidlFolder);
                        pidl = lst.ToArray();
                        Module.SHOpenFolderAndSelectItems(pidlFolder, (UInt32)pidl.Length,pidl, (UInt32) 0);
                    }
                    */
                }
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    //System.IO.Directory.CreateDirectory(Module.UserDocumentsFolder);

                    //System.Diagnostics.Process.Start(Module.UserDocumentsFolder);

                    if (!System.IO.Directory.Exists(rdDocumentsFolder.Text))
                    {
                        System.IO.Directory.CreateDirectory(rdDocumentsFolder.Text);
                    }

                    System.Diagnostics.Process.Start(rdDocumentsFolder.Text);

                }
                else
                {
                    string file = "";
                    
                    file = System.IO.Path.GetFileName(dgFiles.Rows[0].Cells["colFullfilepath"].Value.ToString());
                                     

                    string filepath = rdDocumentsFolder.Text + "\\" + file+".extracted_images\\";

                    //System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + filepath + "\"");

                    //string args = string.Format("/e, /select, {0}", filepath);
                    string args = filepath;
                    
                    if (chkFormat.Checked && frmChangeFormat.Instance.SelectedFormat == 16)
                    {
                        args = string.Format("/e, /select, \"{0}\"", rdDocumentsFolder.Text + "\\" + file+".extracted_images.pdf");
                    }

                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "explorer.exe";
                    info.Arguments = args;
                    Process.Start(info);
                }
            }
        }

        private void EnableDisableForm(bool enable)
        {
            foreach (Control co in this.Controls)
            {
                co.Enabled = enable;
            }
        }
        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                rdDocumentsFolder.Checked = true;
                rdDocumentsFolder.Text = folderBrowserDialog2.SelectedPath;

                Properties.Settings.Default.DocumentOutputFolder = rdDocumentsFolder.Text;

                frmMain_Resize(null, null);
            }
        }

        private void rdDocumentsFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDocumentsFolder.Checked)
            {
                System.IO.Directory.CreateDirectory(rdDocumentsFolder.Text);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //3Err = ImagesExtractorHelper.ExtractImages(dt,rdDocumentsFolderChecked, rdDocumentsFolderText, chkFormatChecked, SelectedFormat, txtFilenameText);

            Err = PdfiumImageExtractor.ExtractImages(dt, rdDocumentsFolderChecked, rdDocumentsFolderText, chkFormatChecked, SelectedFormat, txtFilenameText);
        }

        private void dgFiles_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        private void dgFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSettings.Index)
            {
                if (e.RowIndex != -1)
                {
                    DataTable dt = (DataTable)dgFiles.DataSource;
                    frmDocOptions f = new frmDocOptions((PageRange)(dt.Rows[e.RowIndex]["pagerange"]), dt.Rows[e.RowIndex]["fullfilepath"].ToString(), dt.Rows[e.RowIndex]["password"].ToString());
                    f.ShowDialog();
                }
            }
        }

        private void dgFiles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dgFiles_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void btnPreviewPicSet_Click(object sender, EventArgs e)
        {
            try
            {

                int i = int.Parse(txtPreviewPicPage.Text);
            }
            catch
            {
                Module.ShowMessage("Please insert a valid Page Number !");
                return;
            }

            Module.previewFromPagePath = Module.imgmona_filepath;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string err = ImagesExtractorHelper.ExtractImageForPreview(int.Parse(txtPreviewPicPage.Text), dgFiles[colPassword.Index, dgFiles.CurrentCell.RowIndex].Value.ToString(), dgFiles[colFullFilePath.Index, dgFiles.CurrentCell.RowIndex].Value.ToString());

                this.Cursor = null;

                if (err != String.Empty)
                {
                    Module.ShowError("Error could not extract image !", err);
                    return;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = null;
                Module.ShowError(ex);
            }
            
            if (System.IO.File.Exists(System.IO.Path.GetTempPath() + "\\pdfimageextractor.png"))
            {
                Module.previewFromPagePath = System.IO.Path.GetTempPath() + "\\pdfimageextractor.png";
            }

            Module.ShowMessage("Preview Picture Set !");
        }

        private void chkResize_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk=(CheckBox)sender;

            //if (PresetHelper.FillingPresetValues) return;

            if (chk.Checked)
            {

                DialogResult dres = DialogResult.Cancel;

                if (chk == chkBorder)
                {
                    dres = frmBorder.Instance.ShowDialog();
                }
                else if (chk == chkCanvas)
                {
                    dres = frmCanvas.Instance.ShowDialog();
                }
                else if (chk == chkColorDepth)
                {
                    dres = frmColorDepth.Instance.ShowDialog();
                }
                else if (chk == chkColorTransformations)
                {
                    dres = frmColorTransformations.Instance.ShowDialog();
                }
                else if (chk == chkCrop)
                {
                    dres = frmCrop.Instance.ShowDialog();
                }
                else if (chk == chkFormat)
                {
                    dres = frmChangeFormat.Instance.ShowDialog();
                }
                else if (chk == chkResize)
                {
                    dres = frmResize.Instance.ShowDialog();
                }
                else if (chk == chkResolution)
                {
                    dres = frmResolution.Instance.ShowDialog();
                }
                else if (chk == chkRotateFlip)
                {
                    dres = frmFlipRotate.Instance.ShowDialog();
                }
                else if (chk == chkText)
                {
                    dres = frmText.Instance.ShowDialog();
                }
                else if (chk == chkWatermark)
                {
                    dres = frmWatermark.Instance.ShowDialog();
                }
                
                if (dres == DialogResult.OK)
                {
                    chk.BackColor = Color.LightBlue;
                }
                else
                {
                    chk.Checked = false;
                    chk.BackColor = Color.Transparent;
                }
            }
            else
            {
                chk.Checked = false;
                chk.BackColor = Color.Transparent;
            }

            //ShowPreview();
        
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
           // frmPreview f = new frmPreview((Bitmap)System.Drawing.Image.FromFile(Module.previewFromPagePath), Module.previewFromPagePath);

            frmPreview f = new frmPreview(false);
            f.ShowDialog();            
        }

        private void downloadFreePDFPasswordRemoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pdfdocmerge.com/pdf_password_remover/");
        }

        private void downloadPdfImageExtractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pdfdocmerge.com/pdf_metadata_editor/");
        }

        private void downloadPDFEncrypterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pdfdocmerge.com/pdfencrypter/");
        }

        private void pleaseDonateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/donate.php");
        }

        private void dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/downloads/4dots-Software-PRODUCT-CATALOG.pdf");
        }

        private void btnImportList_Click(object sender, EventArgs e)
        {
            ImportListHelper.SilentAddErr = "";

            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportListHelper.ImportList(openFileDialog1.FileName);
                RecentFilesHelper.ImportListRecent(openFileDialog1.FileName);

                if (ImportListHelper.SilentAddErr != string.Empty)
                {
                    Module.ShowMessage(TranslateHelper.Translate("An error occured while Importing the List !")+"\n\n"+ ImportListHelper.SilentAddErr);
                    //3frmError f = new frmError(TranslateHelper.Translate("An error occured while Importing the List !"), ImportListHelper.SilentAddErr);
                    //3f.ShowDialog();
                }
            }
        }

        private void keepFolderStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keepFolderStructureToolStripMenuItem.Checked = !keepFolderStructureToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepFolderStructure = keepFolderStructureToolStripMenuItem.Checked;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                DialogResult dres = Module.ShowQuestionDialog(TranslateHelper.Translate("Are you sure that you want to exit the application ?"),
        Module.ApplicationTitle);

                if (dres != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Properties.Settings.Default.OutputRadioIndex = rdSameFolder.Checked ? 0 : 1;

            Properties.Settings.Default.FilenamePattern = txtFilename.Text;

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;

            //=========

            Properties.Settings.Default.ExploreOutputFolder = exploreOutputFolderWhenDoneToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepCreationDate = keepCreationDateToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepLastModificationDate = keepLastModificationDateToolStripMenuItem.Checked;

            Properties.Settings.Default.ShowMessageOnSucess = showMessageOnSucessToolStripMenuItem.Checked;

            Properties.Settings.Default.SaveOnlyUniqueImages = saveOnlyUniqueImagesToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();
        }

        private void btnResetFilename_Click(object sender, EventArgs e)
        {
            txtFilename.Text = "Img[PAGENUM]-[NUM].[FILETYPE]";
        }

        #region Share

        private void tsiFacebook_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void tsiTwitter_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void tsiGooglePlus_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void tsiLinkedIn_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void tsiEmail_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
        }

        #endregion

        private void tsdbAddFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                AddFile(e.ClickedItem.Text);
                RecentFilesHelper.AddRecentFile(e.ClickedItem.Text);

            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void tsdbAddFolder_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddFolder(e.ClickedItem.Text, "");
            RecentFilesHelper.AddRecentFolder(e.ClickedItem.Text);
        }

        private void tsdbImportList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ImportListHelper.SilentAddErr = "";

            ImportListHelper.ImportList(e.ClickedItem.Text);
            RecentFilesHelper.ImportListRecent(e.ClickedItem.Text);

            if (ImportListHelper.SilentAddErr != string.Empty)
            {
                Module.ShowMessage(TranslateHelper.Translate("An error occured while Importing the List !")+"\n\n"+ImportListHelper.SilentAddErr);
                //3frmError f = new frmError(TranslateHelper.Translate("An error occured while Importing the List !"), ImportListHelper.SilentAddErr);
                //3f.ShowDialog();
            }
        }

        private void luminatiSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void youtubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCovA-lld9Q79l08K-V1QEng");
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void importListFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SilentAddErr = "";

            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportList(openFileDialog1.FileName);

                if (SilentAddErr != string.Empty)
                {
                    frmMessage f = new frmMessage();
                    f.txtMsg.Text = SilentAddErr;
                    f.ShowDialog();

                }
            }
        }

        public bool SilentAdd = false;
        public string SilentAddErr = "";

        public void ImportList(string listfilepath)
        {
            string curdir = Environment.CurrentDirectory;

            try
            {
                SilentAdd = true;
                using (StreamReader sr = new StreamReader(listfilepath, Encoding.Default, true))
                {
                    string line = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("#"))
                        {
                            continue;
                        }

                        string filepath = line;
                        string password = "";

                        try
                        {
                            if (line.StartsWith("\""))
                            {
                                int epos = line.IndexOf("\"", 1);

                                if (epos > 0)
                                {
                                    filepath = line.Substring(1, epos - 1);
                                }
                            }
                            else if (line.StartsWith("'"))
                            {
                                int epos = line.IndexOf("'", 1);

                                if (epos > 0)
                                {
                                    filepath = line.Substring(1, epos - 1);
                                }
                            }

                            int compos = line.IndexOf(",");

                            if (compos > 0)
                            {
                                password = line.Substring(compos + 1);

                                if (!line.StartsWith("\"") && !line.StartsWith("'"))
                                {
                                    filepath = line.Substring(0, compos);
                                }

                                if ((password.StartsWith("\"") && password.EndsWith("\""))
                                    || (password.StartsWith("'") && password.EndsWith("'")))
                                {
                                    if (password.Length == 2)
                                    {
                                        password = "";
                                    }
                                    else
                                    {
                                        password = password.Substring(1, password.Length - 2);
                                    }
                                }

                            }
                        }
                        catch (Exception exq)
                        {
                            SilentAddErr += TranslateHelper.Translate("Error while processing List !") + " " + line + " " + exq.Message + "\r\n";
                        }

                        line = filepath;

                        Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(listfilepath);

                        line = System.IO.Path.GetFullPath(line);

                        if (System.IO.File.Exists(line))
                        {
                            if (System.IO.Path.GetExtension(line).ToLower() == ".pdf")
                            {
                                AddFile(line, password);
                            }
                            else
                            {
                                SilentAddErr += TranslateHelper.Translate("Error wrong file type !") + " " + line + "\r\n";
                            }
                        }
                        else if (System.IO.Directory.Exists(line))
                        {
                            AddFolder(line, password);
                        }
                        else
                        {
                            SilentAddErr += TranslateHelper.Translate("Error. File or Directory not found !") + " " + line + "\r\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SilentAddErr += TranslateHelper.Translate("Error could not read file !") + " " + ex.Message + "\r\n";
            }
            finally
            {
                Environment.CurrentDirectory = curdir;

                SilentAdd = false;
            }
        }

        private void importListFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel Files (*.xls;*.xlsx;*.xlt)|*.xls;*.xlsx;*.xlt";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter xl = new ExcelImporter();
                xl.ImportListExcel(openFileDialog1.FileName);
            }

        }

        private void enterFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                txt += dt.Rows[k]["fullfilepath"].ToString() + "\r\n";
            }

            frmMultipleFiles f = new frmMultipleFiles(false, txt);

            if (f.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();

                for (int k = 0; k < f.txtFiles.Lines.Length; k++)
                {
                    AddFile(f.txtFiles.Lines[k].Trim());
                }
            }

        }

        private void saveCurrentFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                Module.ShowMessage("Current Selection is Empty !");
                return;
            }

            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default))
                {
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        sw.WriteLine(dt.Rows[k]["fullfilepath"].ToString());
                    }
                }
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k=0;k<dgFiles.Rows.Count;k++)
            {
                dgFiles.Rows[k].Selected = true;
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.Rows[k].Selected = false;
            }
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.Rows[k].Selected = !dgFiles.Rows[k].Selected;
            }
        }

        private void tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://onlinepdfapps.com");
        }

        private void commandLineArgumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMessage fm = new frmMessage(true);
            fm.ShowDialog(this);
        }

        private void saveOnlyUniqueImagesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveOnlyUniqueImages = saveOnlyUniqueImagesToolStripMenuItem.Checked;
        }
    }
}

