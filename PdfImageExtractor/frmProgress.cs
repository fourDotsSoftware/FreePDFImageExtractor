using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfImageExtractor
{
    public partial class frmProgress : CustomForm
    {
        public static frmProgress Instance = null;
        public frmProgress()
        {
            InitializeComponent();
            Instance = this;
            //this.TopMost = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(2, 2, this.Width - 4, this.Height - 4));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain.Instance.OperationCancelled = true;
        }

    }
}

