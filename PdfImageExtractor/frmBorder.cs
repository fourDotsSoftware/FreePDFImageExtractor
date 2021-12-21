using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfImageExtractor
{
    public partial class frmBorder : PdfImageExtractor.CustomForm
    {
        public static frmBorder Instance = new frmBorder();

        public  Color ColorA = Color.White;
        public  Color ColorB = Color.Black;
        public  Color ColorC = Color.White;
        public  Color ColorGrA = Color.FromArgb(150, 150, 150);
        public  Color ColorGrB = Color.White;
        public  bool Ellipse = false;
        public  bool Gradient = false;

        public  int widthA = 10;
        public  int widthB=1;
        public  int widthC = 2;

        public  bool Style1 = true;
        public  bool Style2 = true;
        public  bool Style3 = true;

        Bitmap imgmona = (Bitmap)Bitmap.FromFile(Module.previewFromPagePath);
        public frmBorder()
        {
            InitializeComponent();
        }

        private void btnColor1_Click(object sender, EventArgs e)
        {
            /*
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor1.BackColor = colorDialog1.Color;
            }

            ShowPreview();
            */
        }

        private void btnColor2A_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor2A.BackColor = colorDialog1.Color;
            }

            ShowPreview();
        }

        private void btnColor2B_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor2B.BackColor = colorDialog1.Color;
            }

            ShowPreview();
        }

        private void btnColor2C_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor2C.BackColor = colorDialog1.Color;
            }

            ShowPreview();
        }

        private void frmBorder_Load(object sender, EventArgs e)
        {
            btnColor2A.BackColor = ColorA;
            btnColor2B.BackColor = ColorB;
            btnColor2C.BackColor = ColorC;

            btnColorGrA.BackColor = ColorGrA;
            btnColorGrB.BackColor = ColorGrB;

            nudWidthA.Value = widthA;
            nudWidthB.Value = widthB;
            nudWidthC.Value = widthC;

            chkGradient.Checked = Gradient;
            chkEllipse.Checked = Ellipse;

            chkStyle1.Checked = Style1;
            chkStyle2.Checked = Style2;
            chkStyle3.Checked = Style3;
        }

        private void btnColorGrA_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColorGrA.BackColor = colorDialog1.Color;
            }

            ShowPreview();
        }

        private void btnColorGrB_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColorGrB.BackColor = colorDialog1.Color;
            }

            ShowPreview();
        }

        private void ShowPreview()
        {
            Bitmap img = BorderHelper.AddBorder(imgmona, chkStyle1.Checked, chkStyle2.Checked,
                chkStyle3.Checked, btnColor2A.BackColor, btnColor2B.BackColor,
                btnColor2C.BackColor,chkStyle1.Checked ? (int)nudWidthA.Value :0, chkStyle2.Checked ? (int)nudWidthB.Value : 0,chkStyle3.Checked ? (int)nudWidthC.Value : 0,
            chkGradient.Checked, btnColorGrA.BackColor, btnColorGrB.BackColor, chkEllipse.Checked);

            int border=(int)((img.Width-261)/2);
            pictureBox1.Left = 261 - border;
            pictureBox1.Top = 212 - border;

            pictureBox1.Width = img.Width;
            pictureBox1.Height = img.Height;

            pictureBox1.Image = img;
        }

        private void chkStyle1_CheckedChanged(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void nudWidthA_ValueChanged(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
             ColorA=btnColor2A.BackColor;
             ColorB = btnColor2B.BackColor;
             ColorC = btnColor2C.BackColor;

             ColorGrA = btnColorGrA.BackColor;
             ColorGrB = btnColorGrB.BackColor;

             widthA = (int)nudWidthA.Value;
             widthB = (int)nudWidthB.Value;
             widthC = (int)nudWidthC.Value;

             Gradient = chkGradient.Checked;
             Ellipse = chkEllipse.Checked;

             Style1 = chkStyle1.Checked;
             Style2 = chkStyle2.Checked;
             Style3 = chkStyle3.Checked;

             this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

