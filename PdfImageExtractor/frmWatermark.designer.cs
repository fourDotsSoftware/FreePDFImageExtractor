namespace PdfImageExtractor
{
    partial class frmWatermark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWatermark));
            this.txtWatermarkImage = new System.Windows.Forms.TextBox();
            this.btnWatermarkImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.nudOpacity = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picWatermark = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWatermarkImage
            // 
            resources.ApplyResources(this.txtWatermarkImage, "txtWatermarkImage");
            this.txtWatermarkImage.Name = "txtWatermarkImage";
            this.txtWatermarkImage.ReadOnly = true;
            // 
            // btnWatermarkImage
            // 
            resources.ApplyResources(this.btnWatermarkImage, "btnWatermarkImage");
            this.btnWatermarkImage.Name = "btnWatermarkImage";
            this.btnWatermarkImage.UseVisualStyleBackColor = true;
            this.btnWatermarkImage.Click += new System.EventHandler(this.btnWatermarkImage_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // tbOpacity
            // 
            resources.ApplyResources(this.tbOpacity, "tbOpacity");
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.TickFrequency = 10;
            this.tbOpacity.Value = 100;
            this.tbOpacity.Scroll += new System.EventHandler(this.tbOpacity_Scroll);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // nudOpacity
            // 
            resources.ApplyResources(this.nudOpacity, "nudOpacity");
            this.nudOpacity.Name = "nudOpacity";
            this.nudOpacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudOpacity.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // picWatermark
            // 
            resources.ApplyResources(this.picWatermark, "picWatermark");
            this.picWatermark.Name = "picWatermark";
            this.picWatermark.TabStop = false;
            this.picWatermark.Paint += new System.Windows.Forms.PaintEventHandler(this.picWatermark_Paint);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPosition, "cmbPosition");
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.SelectedIndexChanged += new System.EventHandler(this.cmbPosition_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // nudX
            // 
            resources.ApplyResources(this.nudX, "nudX");
            this.nudX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nudX.Name = "nudX";
            this.nudX.ValueChanged += new System.EventHandler(this.nudX_ValueChanged);
            // 
            // nudY
            // 
            resources.ApplyResources(this.nudY, "nudY");
            this.nudY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nudY.Name = "nudY";
            this.nudY.ValueChanged += new System.EventHandler(this.nudY_ValueChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
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
            // btnPreview
            // 
            resources.ApplyResources(this.btnPreview, "btnPreview");
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // frmWatermark
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picWatermark);
            this.Controls.Add(this.nudOpacity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbOpacity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWatermarkImage);
            this.Controls.Add(this.txtWatermarkImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWatermark";
            this.Load += new System.EventHandler(this.frmWatermark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWatermarkImage;
        private System.Windows.Forms.Button btnWatermarkImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbOpacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudOpacity;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picWatermark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnPreview;
    }
}
