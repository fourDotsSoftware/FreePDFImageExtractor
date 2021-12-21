namespace PdfImageExtractor
{
    partial class frmFlipRotate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlipRotate));
            this.chkFlipHorizontally = new System.Windows.Forms.CheckBox();
            this.chkFlipVertically = new System.Windows.Forms.CheckBox();
            this.chkRotate90 = new System.Windows.Forms.CheckBox();
            this.chkRotateMinus90 = new System.Windows.Forms.CheckBox();
            this.chkRotate180 = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkFlipHorizontally
            // 
            resources.ApplyResources(this.chkFlipHorizontally, "chkFlipHorizontally");
            this.chkFlipHorizontally.BackColor = System.Drawing.Color.Transparent;
            this.chkFlipHorizontally.Name = "chkFlipHorizontally";
            this.chkFlipHorizontally.UseVisualStyleBackColor = false;
            // 
            // chkFlipVertically
            // 
            resources.ApplyResources(this.chkFlipVertically, "chkFlipVertically");
            this.chkFlipVertically.BackColor = System.Drawing.Color.Transparent;
            this.chkFlipVertically.Name = "chkFlipVertically";
            this.chkFlipVertically.UseVisualStyleBackColor = false;
            // 
            // chkRotate90
            // 
            resources.ApplyResources(this.chkRotate90, "chkRotate90");
            this.chkRotate90.BackColor = System.Drawing.Color.Transparent;
            this.chkRotate90.Name = "chkRotate90";
            this.chkRotate90.UseVisualStyleBackColor = false;
            // 
            // chkRotateMinus90
            // 
            resources.ApplyResources(this.chkRotateMinus90, "chkRotateMinus90");
            this.chkRotateMinus90.BackColor = System.Drawing.Color.Transparent;
            this.chkRotateMinus90.Name = "chkRotateMinus90";
            this.chkRotateMinus90.UseVisualStyleBackColor = false;
            // 
            // chkRotate180
            // 
            resources.ApplyResources(this.chkRotate180, "chkRotate180");
            this.chkRotate180.BackColor = System.Drawing.Color.Transparent;
            this.chkRotate180.Name = "chkRotate180";
            this.chkRotate180.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::PdfImageExtractor.Properties.Resources.exit;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::PdfImageExtractor.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmFlipRotate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkRotate180);
            this.Controls.Add(this.chkRotateMinus90);
            this.Controls.Add(this.chkRotate90);
            this.Controls.Add(this.chkFlipVertically);
            this.Controls.Add(this.chkFlipHorizontally);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFlipRotate";
            this.Load += new System.EventHandler(this.frmFlipRotate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.CheckBox chkFlipHorizontally;
        public System.Windows.Forms.CheckBox chkFlipVertically;
        public System.Windows.Forms.CheckBox chkRotate90;
        public System.Windows.Forms.CheckBox chkRotateMinus90;
        public System.Windows.Forms.CheckBox chkRotate180;
    }
}
