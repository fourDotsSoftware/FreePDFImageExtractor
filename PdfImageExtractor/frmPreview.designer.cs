namespace PdfImageExtractor
{
    partial class frmPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreview));
            this.btnClose = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbMain = new System.Windows.Forms.TrackBar();
            this.vsbMain = new System.Windows.Forms.VScrollBar();
            this.hsbMain = new System.Windows.Forms.HScrollBar();
            this.txtMainInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::PdfImageExtractor.Properties.Resources.exit;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picMain
            // 
            resources.ApplyResources(this.picMain, "picMain");
            this.picMain.Name = "picMain";
            this.picMain.TabStop = false;
            this.picMain.Paint += new System.Windows.Forms.PaintEventHandler(this.picMain_Paint);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::PdfImageExtractor.Properties.Resources.zoom_in;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // tbMain
            // 
            resources.ApplyResources(this.tbMain, "tbMain");
            this.tbMain.Maximum = 3200;
            this.tbMain.Name = "tbMain";
            this.tbMain.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMain.Value = 1600;
            this.tbMain.Scroll += new System.EventHandler(this.tbMain_Scroll);
            // 
            // vsbMain
            // 
            resources.ApplyResources(this.vsbMain, "vsbMain");
            this.vsbMain.Name = "vsbMain";
            this.vsbMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbMain_Scroll);
            // 
            // hsbMain
            // 
            resources.ApplyResources(this.hsbMain, "hsbMain");
            this.hsbMain.Name = "hsbMain";
            this.hsbMain.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbMain_Scroll);
            // 
            // txtMainInfo
            // 
            resources.ApplyResources(this.txtMainInfo, "txtMainInfo");
            this.txtMainInfo.Name = "txtMainInfo";
            this.txtMainInfo.ReadOnly = true;
            this.txtMainInfo.TabStop = false;
            // 
            // frmPreview
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.txtMainInfo);
            this.Controls.Add(this.vsbMain);
            this.Controls.Add(this.hsbMain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.btnClose);
            this.Name = "frmPreview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TrackBar tbMain;
        private System.Windows.Forms.VScrollBar vsbMain;
        private System.Windows.Forms.HScrollBar hsbMain;
        public System.Windows.Forms.TextBox txtMainInfo;
    }
}
