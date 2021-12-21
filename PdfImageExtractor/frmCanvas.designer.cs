namespace PdfImageExtractor
{
    partial class frmCanvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCanvas));
            this.cmbPreset = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkKeepRatio = new System.Windows.Forms.CheckBox();
            this.cmbPixelsPercent = new System.Windows.Forms.ComboBox();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblBackgroundColor = new System.Windows.Forms.Label();
            this.btnBackgroundColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPreset
            // 
            this.cmbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreset.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPreset, "cmbPreset");
            this.cmbPreset.Name = "cmbPreset";
            this.cmbPreset.SelectedIndexChanged += new System.EventHandler(this.cmbPreset_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // chkKeepRatio
            // 
            resources.ApplyResources(this.chkKeepRatio, "chkKeepRatio");
            this.chkKeepRatio.BackColor = System.Drawing.Color.Transparent;
            this.chkKeepRatio.Name = "chkKeepRatio";
            this.chkKeepRatio.UseVisualStyleBackColor = false;
            this.chkKeepRatio.CheckedChanged += new System.EventHandler(this.chkKeepRatio_CheckedChanged);
            // 
            // cmbPixelsPercent
            // 
            this.cmbPixelsPercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPixelsPercent.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPixelsPercent, "cmbPixelsPercent");
            this.cmbPixelsPercent.Name = "cmbPixelsPercent";
            this.cmbPixelsPercent.SelectedIndexChanged += new System.EventHandler(this.cmbPixelsPercent_SelectedIndexChanged);
            // 
            // nudHeight
            // 
            resources.ApplyResources(this.nudHeight, "nudHeight");
            this.nudHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // nudWidth
            // 
            resources.ApplyResources(this.nudWidth, "nudWidth");
            this.nudWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // btnCancel
            // 
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
            // lblBackgroundColor
            // 
            this.lblBackgroundColor.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblBackgroundColor, "lblBackgroundColor");
            this.lblBackgroundColor.Name = "lblBackgroundColor";
            // 
            // btnBackgroundColor
            // 
            resources.ApplyResources(this.btnBackgroundColor, "btnBackgroundColor");
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.UseVisualStyleBackColor = true;
            this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // frmCanvas
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBackgroundColor);
            this.Controls.Add(this.lblBackgroundColor);
            this.Controls.Add(this.cmbPreset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkKeepRatio);
            this.Controls.Add(this.cmbPixelsPercent);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCanvas";
            this.Load += new System.EventHandler(this.frmCanvas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkKeepRatio;
        public System.Windows.Forms.ComboBox cmbPixelsPercent;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblBackgroundColor;
        private System.Windows.Forms.Button btnBackgroundColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.ComboBox cmbPreset;
        private System.Windows.Forms.Label label4;
    }
}
