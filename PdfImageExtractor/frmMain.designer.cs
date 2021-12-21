namespace PdfImageExtractor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.importListFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepFolderStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreOutputFolderWhenDoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepCreationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepLastModificationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageOnSucessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandLineArgumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pleaseDonateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiHelpFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.youtubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSettings = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdSameFolder = new System.Windows.Forms.RadioButton();
            this.rdDocumentsFolder = new System.Windows.Forms.RadioButton();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkNegative = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPreviewPicSet = new System.Windows.Forms.Button();
            this.txtPreviewPicPage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearBorder = new System.Windows.Forms.Button();
            this.chkBorder = new System.Windows.Forms.CheckBox();
            this.btnClearCanvas = new System.Windows.Forms.Button();
            this.chkCanvas = new System.Windows.Forms.CheckBox();
            this.btnClearCrop = new System.Windows.Forms.Button();
            this.chkCrop = new System.Windows.Forms.CheckBox();
            this.btnClearResolution = new System.Windows.Forms.Button();
            this.chkResolution = new System.Windows.Forms.CheckBox();
            this.btnClearText = new System.Windows.Forms.Button();
            this.chkText = new System.Windows.Forms.CheckBox();
            this.btnClearWatermark = new System.Windows.Forms.Button();
            this.chkWatermark = new System.Windows.Forms.CheckBox();
            this.btnClearRotateFlip = new System.Windows.Forms.Button();
            this.chkRotateFlip = new System.Windows.Forms.CheckBox();
            this.btnClearColorDepth = new System.Windows.Forms.Button();
            this.chkColorDepth = new System.Windows.Forms.CheckBox();
            this.btnClearFormat = new System.Windows.Forms.Button();
            this.chkFormat = new System.Windows.Forms.CheckBox();
            this.btnClearColorTransformations = new System.Windows.Forms.Button();
            this.chkColorTransformations = new System.Windows.Forms.CheckBox();
            this.btnClearResize = new System.Windows.Forms.Button();
            this.chkResize = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnResetFilename = new System.Windows.Forms.Button();
            this.lblExplanation = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsdbAddFile = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdbAddFolder = new System.Windows.Forms.ToolStripSplitButton();
            this.tsdbImportList = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShare = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiGooglePlus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLinkedIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbConvert = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.documentSettingsToolStripMenuItem,
            this.duplicateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.folder;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // documentSettingsToolStripMenuItem
            // 
            this.documentSettingsToolStripMenuItem.Name = "documentSettingsToolStripMenuItem";
            resources.ApplyResources(this.documentSettingsToolStripMenuItem, "documentSettingsToolStripMenuItem");
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            resources.ApplyResources(this.duplicateToolStripMenuItem, "duplicateToolStripMenuItem");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.toolStripMenuItem4,
            this.importListFromTextFileToolStripMenuItem,
            this.importListFromExcelFileToolStripMenuItem,
            this.enterFileListToolStripMenuItem,
            this.saveCurrentFileListToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.add;
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            resources.ApplyResources(this.addFilesToolStripMenuItem, "addFilesToolStripMenuItem");
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            resources.ApplyResources(this.addFolderToolStripMenuItem, "addFolderToolStripMenuItem");
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // importListFromTextFileToolStripMenuItem
            // 
            this.importListFromTextFileToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.import1;
            this.importListFromTextFileToolStripMenuItem.Name = "importListFromTextFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromTextFileToolStripMenuItem, "importListFromTextFileToolStripMenuItem");
            this.importListFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromTextFileToolStripMenuItem_Click);
            // 
            // importListFromExcelFileToolStripMenuItem
            // 
            this.importListFromExcelFileToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.import1;
            this.importListFromExcelFileToolStripMenuItem.Name = "importListFromExcelFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromExcelFileToolStripMenuItem, "importListFromExcelFileToolStripMenuItem");
            this.importListFromExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromExcelFileToolStripMenuItem_Click);
            // 
            // enterFileListToolStripMenuItem
            // 
            this.enterFileListToolStripMenuItem.Name = "enterFileListToolStripMenuItem";
            resources.ApplyResources(this.enterFileListToolStripMenuItem, "enterFileListToolStripMenuItem");
            this.enterFileListToolStripMenuItem.Click += new System.EventHandler(this.enterFileListToolStripMenuItem_Click);
            // 
            // saveCurrentFileListToolStripMenuItem
            // 
            this.saveCurrentFileListToolStripMenuItem.Name = "saveCurrentFileListToolStripMenuItem";
            resources.ApplyResources(this.saveCurrentFileListToolStripMenuItem, "saveCurrentFileListToolStripMenuItem");
            this.saveCurrentFileListToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentFileListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem5,
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.btnClearMerge_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            resources.ApplyResources(this.selectNoneToolStripMenuItem, "selectNoneToolStripMenuItem");
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            resources.ApplyResources(this.invertSelectionToolStripMenuItem, "invertSelectionToolStripMenuItem");
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepFolderStructureToolStripMenuItem,
            this.exploreOutputFolderWhenDoneToolStripMenuItem,
            this.keepCreationDateToolStripMenuItem,
            this.keepLastModificationDateToolStripMenuItem,
            this.showMessageOnSucessToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // keepFolderStructureToolStripMenuItem
            // 
            this.keepFolderStructureToolStripMenuItem.Name = "keepFolderStructureToolStripMenuItem";
            resources.ApplyResources(this.keepFolderStructureToolStripMenuItem, "keepFolderStructureToolStripMenuItem");
            this.keepFolderStructureToolStripMenuItem.Click += new System.EventHandler(this.keepFolderStructureToolStripMenuItem_Click);
            // 
            // exploreOutputFolderWhenDoneToolStripMenuItem
            // 
            this.exploreOutputFolderWhenDoneToolStripMenuItem.CheckOnClick = true;
            this.exploreOutputFolderWhenDoneToolStripMenuItem.Name = "exploreOutputFolderWhenDoneToolStripMenuItem";
            resources.ApplyResources(this.exploreOutputFolderWhenDoneToolStripMenuItem, "exploreOutputFolderWhenDoneToolStripMenuItem");
            // 
            // keepCreationDateToolStripMenuItem
            // 
            this.keepCreationDateToolStripMenuItem.CheckOnClick = true;
            this.keepCreationDateToolStripMenuItem.Name = "keepCreationDateToolStripMenuItem";
            resources.ApplyResources(this.keepCreationDateToolStripMenuItem, "keepCreationDateToolStripMenuItem");
            // 
            // keepLastModificationDateToolStripMenuItem
            // 
            this.keepLastModificationDateToolStripMenuItem.CheckOnClick = true;
            this.keepLastModificationDateToolStripMenuItem.Name = "keepLastModificationDateToolStripMenuItem";
            resources.ApplyResources(this.keepLastModificationDateToolStripMenuItem, "keepLastModificationDateToolStripMenuItem");
            // 
            // showMessageOnSucessToolStripMenuItem
            // 
            this.showMessageOnSucessToolStripMenuItem.CheckOnClick = true;
            this.showMessageOnSucessToolStripMenuItem.Name = "showMessageOnSucessToolStripMenuItem";
            resources.ApplyResources(this.showMessageOnSucessToolStripMenuItem, "showMessageOnSucessToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractImagesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // extractImagesToolStripMenuItem
            // 
            this.extractImagesToolStripMenuItem.Name = "extractImagesToolStripMenuItem";
            resources.ApplyResources(this.extractImagesToolStripMenuItem, "extractImagesToolStripMenuItem");
            this.extractImagesToolStripMenuItem.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            resources.ApplyResources(this.downloadToolStripMenuItem, "downloadToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpGuideToolStripMenuItem,
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem,
            this.commandLineArgumentsToolStripMenuItem,
            this.pleaseDonateToolStripMenuItem1,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.tiHelpFeedback,
            this.visit4dotsSoftwareWebsiteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.youtubeChannelToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpGuideToolStripMenuItem
            // 
            this.helpGuideToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.help2;
            this.helpGuideToolStripMenuItem.Name = "helpGuideToolStripMenuItem";
            resources.ApplyResources(this.helpGuideToolStripMenuItem, "helpGuideToolStripMenuItem");
            this.helpGuideToolStripMenuItem.Click += new System.EventHandler(this.helpGuideToolStripMenuItem_Click);
            // 
            // tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem
            // 
            resources.ApplyResources(this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem, "tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem");
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Name = "tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem";
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Click += new System.EventHandler(this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click);
            // 
            // commandLineArgumentsToolStripMenuItem
            // 
            this.commandLineArgumentsToolStripMenuItem.Name = "commandLineArgumentsToolStripMenuItem";
            resources.ApplyResources(this.commandLineArgumentsToolStripMenuItem, "commandLineArgumentsToolStripMenuItem");
            this.commandLineArgumentsToolStripMenuItem.Click += new System.EventHandler(this.commandLineArgumentsToolStripMenuItem_Click);
            // 
            // pleaseDonateToolStripMenuItem1
            // 
            this.pleaseDonateToolStripMenuItem1.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem1, "pleaseDonateToolStripMenuItem1");
            this.pleaseDonateToolStripMenuItem1.Name = "pleaseDonateToolStripMenuItem1";
            this.pleaseDonateToolStripMenuItem1.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem1_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // tiHelpFeedback
            // 
            this.tiHelpFeedback.Image = global::PdfImageExtractor.Properties.Resources.edit;
            this.tiHelpFeedback.Name = "tiHelpFeedback";
            resources.ApplyResources(this.tiHelpFeedback, "tiHelpFeedback");
            this.tiHelpFeedback.Click += new System.EventHandler(this.tiHelpFeedback_Click);
            // 
            // visit4dotsSoftwareWebsiteToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Name = "visit4dotsSoftwareWebsiteToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebsiteToolStripMenuItem, "visit4dotsSoftwareWebsiteToolStripMenuItem");
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebsiteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // youtubeChannelToolStripMenuItem
            // 
            this.youtubeChannelToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.youtube_32;
            this.youtubeChannelToolStripMenuItem.Name = "youtubeChannelToolStripMenuItem";
            resources.ApplyResources(this.youtubeChannelToolStripMenuItem, "youtubeChannelToolStripMenuItem");
            this.youtubeChannelToolStripMenuItem.Click += new System.EventHandler(this.youtubeChannelToolStripMenuItem_Click);
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.twitter_24;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::PdfImageExtractor.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgFiles
            // 
            this.dgFiles.AllowDrop = true;
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgFiles, "dgFiles");
            this.dgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colSettings,
            this.colSize,
            this.colPassword,
            this.colFileDate,
            this.colFullFilePath});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFiles.GridColor = System.Drawing.Color.Black;
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFiles_CellContentClick);
            this.dgFiles.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgFiles_CellFormatting);
            this.dgFiles.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgFiles_CellValidating);
            this.dgFiles.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgFiles_EditingControlShowing);
            this.dgFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.dgFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            this.dgFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragOver);
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFilename.DataPropertyName = "filename";
            resources.ApplyResources(this.colFilename, "colFilename");
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colSettings
            // 
            resources.ApplyResources(this.colSettings, "colSettings");
            this.colSettings.Name = "colSettings";
            this.colSettings.ReadOnly = true;
            this.colSettings.Text = "...";
            this.colSettings.UseColumnTextForButtonValue = true;
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.DataPropertyName = "sizekb";
            resources.ApplyResources(this.colSize, "colSize");
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colPassword
            // 
            this.colPassword.DataPropertyName = "password";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.colPassword.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.colPassword, "colPassword");
            this.colPassword.Name = "colPassword";
            // 
            // colFileDate
            // 
            this.colFileDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFileDate.DataPropertyName = "filedate";
            resources.ApplyResources(this.colFileDate, "colFileDate");
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.ReadOnly = true;
            // 
            // colFullFilePath
            // 
            this.colFullFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFullFilePath.DataPropertyName = "fullfilepath";
            resources.ApplyResources(this.colFullFilePath, "colFullFilePath");
            this.colFullFilePath.Name = "colFullFilePath";
            this.colFullFilePath.ReadOnly = true;
            // 
            // rdSameFolder
            // 
            resources.ApplyResources(this.rdSameFolder, "rdSameFolder");
            this.rdSameFolder.BackColor = System.Drawing.Color.Transparent;
            this.rdSameFolder.Checked = true;
            this.rdSameFolder.Name = "rdSameFolder";
            this.rdSameFolder.TabStop = true;
            this.rdSameFolder.UseVisualStyleBackColor = false;
            // 
            // rdDocumentsFolder
            // 
            resources.ApplyResources(this.rdDocumentsFolder, "rdDocumentsFolder");
            this.rdDocumentsFolder.BackColor = System.Drawing.Color.Transparent;
            this.rdDocumentsFolder.Name = "rdDocumentsFolder";
            this.rdDocumentsFolder.UseVisualStyleBackColor = false;
            this.rdDocumentsFolder.CheckedChanged += new System.EventHandler(this.rdDocumentsFolder_CheckedChanged);
            // 
            // btnOpenFolder
            // 
            resources.ApplyResources(this.btnOpenFolder, "btnOpenFolder");
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnChangeFolder
            // 
            resources.ApplyResources(this.btnChangeFolder, "btnChangeFolder");
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnChangeFolder);
            this.groupBox1.Controls.Add(this.rdDocumentsFolder);
            this.groupBox1.Controls.Add(this.btnOpenFolder);
            this.groupBox1.Controls.Add(this.rdSameFolder);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.chkNegative);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Controls.Add(this.btnPreviewPicSet);
            this.groupBox2.Controls.Add(this.txtPreviewPicPage);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnClearBorder);
            this.groupBox2.Controls.Add(this.chkBorder);
            this.groupBox2.Controls.Add(this.btnClearCanvas);
            this.groupBox2.Controls.Add(this.chkCanvas);
            this.groupBox2.Controls.Add(this.btnClearCrop);
            this.groupBox2.Controls.Add(this.chkCrop);
            this.groupBox2.Controls.Add(this.btnClearResolution);
            this.groupBox2.Controls.Add(this.chkResolution);
            this.groupBox2.Controls.Add(this.btnClearText);
            this.groupBox2.Controls.Add(this.chkText);
            this.groupBox2.Controls.Add(this.btnClearWatermark);
            this.groupBox2.Controls.Add(this.chkWatermark);
            this.groupBox2.Controls.Add(this.btnClearRotateFlip);
            this.groupBox2.Controls.Add(this.chkRotateFlip);
            this.groupBox2.Controls.Add(this.btnClearColorDepth);
            this.groupBox2.Controls.Add(this.chkColorDepth);
            this.groupBox2.Controls.Add(this.btnClearFormat);
            this.groupBox2.Controls.Add(this.chkFormat);
            this.groupBox2.Controls.Add(this.btnClearColorTransformations);
            this.groupBox2.Controls.Add(this.chkColorTransformations);
            this.groupBox2.Controls.Add(this.btnClearResize);
            this.groupBox2.Controls.Add(this.chkResize);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // chkNegative
            // 
            resources.ApplyResources(this.chkNegative, "chkNegative");
            this.chkNegative.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkNegative.Name = "chkNegative";
            this.chkNegative.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            resources.ApplyResources(this.btnPreview, "btnPreview");
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPreviewPicSet
            // 
            resources.ApplyResources(this.btnPreviewPicSet, "btnPreviewPicSet");
            this.btnPreviewPicSet.Name = "btnPreviewPicSet";
            this.btnPreviewPicSet.UseVisualStyleBackColor = true;
            this.btnPreviewPicSet.Click += new System.EventHandler(this.btnPreviewPicSet_Click);
            // 
            // txtPreviewPicPage
            // 
            resources.ApplyResources(this.txtPreviewPicPage, "txtPreviewPicPage");
            this.txtPreviewPicPage.Name = "txtPreviewPicPage";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnClearBorder
            // 
            resources.ApplyResources(this.btnClearBorder, "btnClearBorder");
            this.btnClearBorder.Name = "btnClearBorder";
            this.btnClearBorder.UseVisualStyleBackColor = true;
            // 
            // chkBorder
            // 
            resources.ApplyResources(this.chkBorder, "chkBorder");
            this.chkBorder.Name = "chkBorder";
            this.chkBorder.UseVisualStyleBackColor = true;
            this.chkBorder.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearCanvas
            // 
            resources.ApplyResources(this.btnClearCanvas, "btnClearCanvas");
            this.btnClearCanvas.Name = "btnClearCanvas";
            this.btnClearCanvas.UseVisualStyleBackColor = true;
            // 
            // chkCanvas
            // 
            resources.ApplyResources(this.chkCanvas, "chkCanvas");
            this.chkCanvas.Name = "chkCanvas";
            this.chkCanvas.UseVisualStyleBackColor = true;
            this.chkCanvas.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearCrop
            // 
            resources.ApplyResources(this.btnClearCrop, "btnClearCrop");
            this.btnClearCrop.Name = "btnClearCrop";
            this.btnClearCrop.UseVisualStyleBackColor = true;
            // 
            // chkCrop
            // 
            resources.ApplyResources(this.chkCrop, "chkCrop");
            this.chkCrop.Name = "chkCrop";
            this.chkCrop.UseVisualStyleBackColor = true;
            this.chkCrop.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearResolution
            // 
            resources.ApplyResources(this.btnClearResolution, "btnClearResolution");
            this.btnClearResolution.Name = "btnClearResolution";
            this.btnClearResolution.UseVisualStyleBackColor = true;
            // 
            // chkResolution
            // 
            resources.ApplyResources(this.chkResolution, "chkResolution");
            this.chkResolution.Name = "chkResolution";
            this.chkResolution.UseVisualStyleBackColor = true;
            this.chkResolution.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearText
            // 
            resources.ApplyResources(this.btnClearText, "btnClearText");
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.UseVisualStyleBackColor = true;
            // 
            // chkText
            // 
            resources.ApplyResources(this.chkText, "chkText");
            this.chkText.Name = "chkText";
            this.chkText.UseVisualStyleBackColor = true;
            this.chkText.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearWatermark
            // 
            resources.ApplyResources(this.btnClearWatermark, "btnClearWatermark");
            this.btnClearWatermark.Name = "btnClearWatermark";
            this.btnClearWatermark.UseVisualStyleBackColor = true;
            // 
            // chkWatermark
            // 
            resources.ApplyResources(this.chkWatermark, "chkWatermark");
            this.chkWatermark.Name = "chkWatermark";
            this.chkWatermark.UseVisualStyleBackColor = true;
            this.chkWatermark.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearRotateFlip
            // 
            resources.ApplyResources(this.btnClearRotateFlip, "btnClearRotateFlip");
            this.btnClearRotateFlip.Name = "btnClearRotateFlip";
            this.btnClearRotateFlip.UseVisualStyleBackColor = true;
            // 
            // chkRotateFlip
            // 
            resources.ApplyResources(this.chkRotateFlip, "chkRotateFlip");
            this.chkRotateFlip.Name = "chkRotateFlip";
            this.chkRotateFlip.UseVisualStyleBackColor = true;
            this.chkRotateFlip.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearColorDepth
            // 
            resources.ApplyResources(this.btnClearColorDepth, "btnClearColorDepth");
            this.btnClearColorDepth.Name = "btnClearColorDepth";
            this.btnClearColorDepth.UseVisualStyleBackColor = true;
            // 
            // chkColorDepth
            // 
            resources.ApplyResources(this.chkColorDepth, "chkColorDepth");
            this.chkColorDepth.Name = "chkColorDepth";
            this.chkColorDepth.UseVisualStyleBackColor = true;
            this.chkColorDepth.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearFormat
            // 
            resources.ApplyResources(this.btnClearFormat, "btnClearFormat");
            this.btnClearFormat.Name = "btnClearFormat";
            this.btnClearFormat.UseVisualStyleBackColor = true;
            // 
            // chkFormat
            // 
            resources.ApplyResources(this.chkFormat, "chkFormat");
            this.chkFormat.Name = "chkFormat";
            this.chkFormat.UseVisualStyleBackColor = true;
            this.chkFormat.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearColorTransformations
            // 
            resources.ApplyResources(this.btnClearColorTransformations, "btnClearColorTransformations");
            this.btnClearColorTransformations.Name = "btnClearColorTransformations";
            this.btnClearColorTransformations.UseVisualStyleBackColor = true;
            // 
            // chkColorTransformations
            // 
            resources.ApplyResources(this.chkColorTransformations, "chkColorTransformations");
            this.chkColorTransformations.Name = "chkColorTransformations";
            this.chkColorTransformations.UseVisualStyleBackColor = true;
            this.chkColorTransformations.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // btnClearResize
            // 
            resources.ApplyResources(this.btnClearResize, "btnClearResize");
            this.btnClearResize.Name = "btnClearResize";
            this.btnClearResize.UseVisualStyleBackColor = true;
            // 
            // chkResize
            // 
            resources.ApplyResources(this.chkResize, "chkResize");
            this.chkResize.Name = "chkResize";
            this.chkResize.UseVisualStyleBackColor = true;
            this.chkResize.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnResetFilename);
            this.tabPage1.Controls.Add(this.lblExplanation);
            this.tabPage1.Controls.Add(this.txtFilename);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnResetFilename
            // 
            resources.ApplyResources(this.btnResetFilename, "btnResetFilename");
            this.btnResetFilename.Name = "btnResetFilename";
            this.btnResetFilename.UseVisualStyleBackColor = true;
            this.btnResetFilename.Click += new System.EventHandler(this.btnResetFilename_Click);
            // 
            // lblExplanation
            // 
            resources.ApplyResources(this.lblExplanation, "lblExplanation");
            this.lblExplanation.Name = "lblExplanation";
            // 
            // txtFilename
            // 
            resources.ApplyResources(this.txtFilename, "txtFilename");
            this.txtFilename.Name = "txtFilename";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdbAddFile,
            this.tsbRemove,
            this.toolStripSeparator2,
            this.tsdbAddFolder,
            this.tsdbImportList,
            this.toolStripSeparator4,
            this.tsbShare,
            this.toolStripSeparator3,
            this.tsbConvert});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsdbAddFile
            // 
            resources.ApplyResources(this.tsdbAddFile, "tsdbAddFile");
            this.tsdbAddFile.Image = global::PdfImageExtractor.Properties.Resources.add1;
            this.tsdbAddFile.Name = "tsdbAddFile";
            this.tsdbAddFile.ButtonClick += new System.EventHandler(this.btnAddFiles_Click);
            this.tsdbAddFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFile_DropDownItemClicked);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::PdfImageExtractor.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsdbAddFolder
            // 
            resources.ApplyResources(this.tsdbAddFolder, "tsdbAddFolder");
            this.tsdbAddFolder.Image = global::PdfImageExtractor.Properties.Resources.folder_add1;
            this.tsdbAddFolder.Name = "tsdbAddFolder";
            this.tsdbAddFolder.ButtonClick += new System.EventHandler(this.btnAddFolder_Click);
            this.tsdbAddFolder.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFolder_DropDownItemClicked);
            // 
            // tsdbImportList
            // 
            resources.ApplyResources(this.tsdbImportList, "tsdbImportList");
            this.tsdbImportList.Image = global::PdfImageExtractor.Properties.Resources.import1;
            this.tsdbImportList.Name = "tsdbImportList";
            this.tsdbImportList.ButtonClick += new System.EventHandler(this.btnImportList_Click);
            this.tsdbImportList.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbImportList_DropDownItemClicked);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // tsbShare
            // 
            resources.ApplyResources(this.tsbShare, "tsbShare");
            this.tsbShare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiFacebook,
            this.tsiTwitter,
            this.tsiGooglePlus,
            this.tsiLinkedIn,
            this.tsiEmail});
            this.tsbShare.Image = global::PdfImageExtractor.Properties.Resources.facebook_24;
            this.tsbShare.Name = "tsbShare";
            // 
            // tsiFacebook
            // 
            this.tsiFacebook.Image = global::PdfImageExtractor.Properties.Resources.facebook_241;
            this.tsiFacebook.Name = "tsiFacebook";
            resources.ApplyResources(this.tsiFacebook, "tsiFacebook");
            this.tsiFacebook.Click += new System.EventHandler(this.tsiFacebook_Click);
            // 
            // tsiTwitter
            // 
            this.tsiTwitter.Image = global::PdfImageExtractor.Properties.Resources.twitter_24;
            this.tsiTwitter.Name = "tsiTwitter";
            resources.ApplyResources(this.tsiTwitter, "tsiTwitter");
            this.tsiTwitter.Click += new System.EventHandler(this.tsiTwitter_Click);
            // 
            // tsiGooglePlus
            // 
            this.tsiGooglePlus.Image = global::PdfImageExtractor.Properties.Resources.googleplus_24;
            this.tsiGooglePlus.Name = "tsiGooglePlus";
            resources.ApplyResources(this.tsiGooglePlus, "tsiGooglePlus");
            this.tsiGooglePlus.Click += new System.EventHandler(this.tsiGooglePlus_Click);
            // 
            // tsiLinkedIn
            // 
            this.tsiLinkedIn.Image = global::PdfImageExtractor.Properties.Resources.linkedin_24;
            this.tsiLinkedIn.Name = "tsiLinkedIn";
            resources.ApplyResources(this.tsiLinkedIn, "tsiLinkedIn");
            this.tsiLinkedIn.Click += new System.EventHandler(this.tsiLinkedIn_Click);
            // 
            // tsiEmail
            // 
            this.tsiEmail.Image = global::PdfImageExtractor.Properties.Resources.mail;
            this.tsiEmail.Name = "tsiEmail";
            resources.ApplyResources(this.tsiEmail, "tsiEmail");
            this.tsiEmail.Click += new System.EventHandler(this.tsiEmail_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsbConvert
            // 
            resources.ApplyResources(this.tsbConvert, "tsbConvert");
            this.tsbConvert.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbConvert.Image = global::PdfImageExtractor.Properties.Resources.flash1;
            this.tsbConvert.Name = "tsbConvert";
            this.tsbConvert.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem tiHelpFeedback;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rdSameFolder;
        public System.Windows.Forms.RadioButton rdDocumentsFolder;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClearBorder;
        public System.Windows.Forms.CheckBox chkBorder;
        private System.Windows.Forms.Button btnClearCanvas;
        public System.Windows.Forms.CheckBox chkCanvas;
        private System.Windows.Forms.Button btnClearCrop;
        public System.Windows.Forms.CheckBox chkCrop;
        private System.Windows.Forms.Button btnClearResolution;
        public System.Windows.Forms.CheckBox chkResolution;
        private System.Windows.Forms.Button btnClearText;
        public System.Windows.Forms.CheckBox chkText;
        private System.Windows.Forms.Button btnClearWatermark;
        public System.Windows.Forms.CheckBox chkWatermark;
        private System.Windows.Forms.Button btnClearRotateFlip;
        public System.Windows.Forms.CheckBox chkRotateFlip;
        private System.Windows.Forms.Button btnClearColorDepth;
        public System.Windows.Forms.CheckBox chkColorDepth;
        private System.Windows.Forms.Button btnClearFormat;
        public System.Windows.Forms.CheckBox chkFormat;
        private System.Windows.Forms.Button btnClearColorTransformations;
        public System.Windows.Forms.CheckBox chkColorTransformations;
        private System.Windows.Forms.Button btnClearResize;
        public System.Windows.Forms.CheckBox chkResize;
        private System.Windows.Forms.Button btnPreviewPicSet;
        private System.Windows.Forms.TextBox txtPreviewPicPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblExplanation;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewButtonColumn colSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullFilePath;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepFolderStructureToolStripMenuItem;
        private System.Windows.Forms.Button btnResetFilename;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFile;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFolder;
        public System.Windows.Forms.ToolStripSplitButton tsdbImportList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton tsbShare;
        private System.Windows.Forms.ToolStripMenuItem tsiFacebook;
        private System.Windows.Forms.ToolStripMenuItem tsiTwitter;
        private System.Windows.Forms.ToolStripMenuItem tsiGooglePlus;
        private System.Windows.Forms.ToolStripMenuItem tsiLinkedIn;
        private System.Windows.Forms.ToolStripMenuItem tsiEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbConvert;
        public System.Windows.Forms.CheckBox chkNegative;
        private System.Windows.Forms.ToolStripMenuItem youtubeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem importListFromExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreOutputFolderWhenDoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepCreationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepLastModificationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessageOnSucessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandLineArgumentsToolStripMenuItem;
    }
}
