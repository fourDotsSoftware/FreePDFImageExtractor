using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfImageExtractor
{
    public partial class frmChangeFormat : PdfImageExtractor.CustomForm
    {
        public  int SelectedFormat = -1;

        public static frmChangeFormat Instance = new frmChangeFormat();

        public frmChangeFormat()
        {
            InitializeComponent();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SelectedFormat = cmbFormat.SelectedIndex;
        }

        public void frmChangeFormat_Load(object sender, EventArgs e)
        {
            if (cmbFormat.Items.Count == 0)
            {
                cmbFormat.Items.Add("Jpeg");
                cmbFormat.Items.Add("Png");
                cmbFormat.Items.Add("Gif");
                cmbFormat.Items.Add("Bmp");
                cmbFormat.Items.Add("Ico");
                cmbFormat.Items.Add("Tiff");
                cmbFormat.Items.Add("Jpeg2000");
                cmbFormat.Items.Add("EXR");
                cmbFormat.Items.Add("HDR");
                cmbFormat.Items.Add("PBM");
                cmbFormat.Items.Add("PGM");
                cmbFormat.Items.Add("PPM");
                cmbFormat.Items.Add("PFM");
                cmbFormat.Items.Add("TARGA");
                cmbFormat.Items.Add("WBMP");
                cmbFormat.Items.Add("XPM");          
                
                /*
                cmbFormat.Items.Add("Wmf");
                cmbFormat.Items.Add("Emf");
                cmbFormat.Items.Add("Exif");
                 */
                 
                 
                cmbFormat.Items.Add("Pdf - One Document including all Images");
                cmbFormat.Items.Add("Pdf - One separate Document for each Image");

                cmbFormat.SelectedIndex = 0;
            }
        }
    }
}

