namespace PdfImageExtractor
{
    partial class frmBorder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorder));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor2A = new System.Windows.Forms.Button();
            this.btnColor2C = new System.Windows.Forms.Button();
            this.btnColor2B = new System.Windows.Forms.Button();
            this.btnColorGrA = new System.Windows.Forms.Button();
            this.btnColorGrB = new System.Windows.Forms.Button();
            this.chkStyle1 = new System.Windows.Forms.CheckBox();
            this.chkStyle2 = new System.Windows.Forms.CheckBox();
            this.chkStyle3 = new System.Windows.Forms.CheckBox();
            this.chkGradient = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEllipse = new System.Windows.Forms.CheckBox();
            this.nudWidthA = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudWidthB = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudWidthC = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthC)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnColor2A
            // 
            resources.ApplyResources(this.btnColor2A, "btnColor2A");
            this.btnColor2A.Name = "btnColor2A";
            this.btnColor2A.UseVisualStyleBackColor = true;
            this.btnColor2A.Click += new System.EventHandler(this.btnColor2A_Click);
            // 
            // btnColor2C
            // 
            resources.ApplyResources(this.btnColor2C, "btnColor2C");
            this.btnColor2C.Name = "btnColor2C";
            this.btnColor2C.UseVisualStyleBackColor = true;
            this.btnColor2C.Click += new System.EventHandler(this.btnColor2C_Click);
            // 
            // btnColor2B
            // 
            resources.ApplyResources(this.btnColor2B, "btnColor2B");
            this.btnColor2B.Name = "btnColor2B";
            this.btnColor2B.UseVisualStyleBackColor = true;
            this.btnColor2B.Click += new System.EventHandler(this.btnColor2B_Click);
            // 
            // btnColorGrA
            // 
            resources.ApplyResources(this.btnColorGrA, "btnColorGrA");
            this.btnColorGrA.Name = "btnColorGrA";
            this.btnColorGrA.UseVisualStyleBackColor = true;
            this.btnColorGrA.Click += new System.EventHandler(this.btnColorGrA_Click);
            // 
            // btnColorGrB
            // 
            resources.ApplyResources(this.btnColorGrB, "btnColorGrB");
            this.btnColorGrB.Name = "btnColorGrB";
            this.btnColorGrB.UseVisualStyleBackColor = true;
            this.btnColorGrB.Click += new System.EventHandler(this.btnColorGrB_Click);
            // 
            // chkStyle1
            // 
            resources.ApplyResources(this.chkStyle1, "chkStyle1");
            this.chkStyle1.BackColor = System.Drawing.Color.Transparent;
            this.chkStyle1.Name = "chkStyle1";
            this.chkStyle1.UseVisualStyleBackColor = false;
            this.chkStyle1.CheckedChanged += new System.EventHandler(this.chkStyle1_CheckedChanged);
            // 
            // chkStyle2
            // 
            resources.ApplyResources(this.chkStyle2, "chkStyle2");
            this.chkStyle2.BackColor = System.Drawing.Color.Transparent;
            this.chkStyle2.Name = "chkStyle2";
            this.chkStyle2.UseVisualStyleBackColor = false;
            this.chkStyle2.CheckedChanged += new System.EventHandler(this.chkStyle1_CheckedChanged);
            // 
            // chkStyle3
            // 
            resources.ApplyResources(this.chkStyle3, "chkStyle3");
            this.chkStyle3.BackColor = System.Drawing.Color.Transparent;
            this.chkStyle3.Name = "chkStyle3";
            this.chkStyle3.UseVisualStyleBackColor = false;
            this.chkStyle3.CheckedChanged += new System.EventHandler(this.chkStyle1_CheckedChanged);
            // 
            // chkGradient
            // 
            resources.ApplyResources(this.chkGradient, "chkGradient");
            this.chkGradient.BackColor = System.Drawing.Color.Transparent;
            this.chkGradient.Name = "chkGradient";
            this.chkGradient.UseVisualStyleBackColor = false;
            this.chkGradient.CheckedChanged += new System.EventHandler(this.chkStyle1_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // chkEllipse
            // 
            resources.ApplyResources(this.chkEllipse, "chkEllipse");
            this.chkEllipse.BackColor = System.Drawing.Color.Transparent;
            this.chkEllipse.Name = "chkEllipse";
            this.chkEllipse.UseVisualStyleBackColor = false;
            this.chkEllipse.CheckedChanged += new System.EventHandler(this.chkStyle1_CheckedChanged);
            // 
            // nudWidthA
            // 
            resources.ApplyResources(this.nudWidthA, "nudWidthA");
            this.nudWidthA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWidthA.Name = "nudWidthA";
            this.nudWidthA.ValueChanged += new System.EventHandler(this.nudWidthA_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // nudWidthB
            // 
            resources.ApplyResources(this.nudWidthB, "nudWidthB");
            this.nudWidthB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWidthB.Name = "nudWidthB";
            this.nudWidthB.ValueChanged += new System.EventHandler(this.nudWidthA_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // nudWidthC
            // 
            resources.ApplyResources(this.nudWidthC, "nudWidthC");
            this.nudWidthC.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWidthC.Name = "nudWidthC";
            this.nudWidthC.ValueChanged += new System.EventHandler(this.nudWidthA_ValueChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
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
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // frmBorder
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudWidthC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudWidthB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudWidthA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkEllipse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkGradient);
            this.Controls.Add(this.chkStyle3);
            this.Controls.Add(this.chkStyle2);
            this.Controls.Add(this.chkStyle1);
            this.Controls.Add(this.btnColorGrA);
            this.Controls.Add(this.btnColorGrB);
            this.Controls.Add(this.btnColor2B);
            this.Controls.Add(this.btnColor2C);
            this.Controls.Add(this.btnColor2A);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBorder";
            this.Load += new System.EventHandler(this.frmBorder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthC)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor2B;
        private System.Windows.Forms.Button btnColor2C;
        private System.Windows.Forms.Button btnColor2A;
        private System.Windows.Forms.Button btnColorGrA;
        private System.Windows.Forms.Button btnColorGrB;
        private System.Windows.Forms.CheckBox chkStyle1;
        private System.Windows.Forms.CheckBox chkStyle2;
        private System.Windows.Forms.CheckBox chkStyle3;
        private System.Windows.Forms.CheckBox chkGradient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEllipse;
        private System.Windows.Forms.NumericUpDown nudWidthA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudWidthB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudWidthC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
