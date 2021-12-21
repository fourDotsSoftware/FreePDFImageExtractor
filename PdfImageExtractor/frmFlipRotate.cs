using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfImageExtractor
{
    public partial class frmFlipRotate : PdfImageExtractor.CustomForm
    {
        public static frmFlipRotate Instance = new frmFlipRotate();

        public bool FlipH = false;
        public bool FlipV = false;
        public bool Rotate90 = false;
        public bool RotateMinus90 = false;
        public bool Rotate180 = false;

        public frmFlipRotate()
        {            
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            FlipH = chkFlipHorizontally.Checked;
            FlipV = chkFlipVertically.Checked;
            Rotate90 = chkRotate90.Checked;
            RotateMinus90 = chkRotateMinus90.Checked;
            Rotate180 = chkRotate180.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void frmFlipRotate_Load(object sender, EventArgs e)
        {

        }
    }
}

