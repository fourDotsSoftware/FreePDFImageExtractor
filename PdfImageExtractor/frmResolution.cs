using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfImageExtractor
{
    public partial class frmResolution : CustomForm
    {
        public int XDPI = 0;
        public int YDPI = 0;

        public bool SetValues = false;

        public static frmResolution Instance = new frmResolution();

        public frmResolution()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            XDPI = (int)nudX.Value;
            YDPI = (int)nudY.Value;

            SetValues = true;

            this.DialogResult = DialogResult.OK;
        }

        private void frmResolution_Load(object sender, EventArgs e)
        {      
            
            if (!SetValues && frmMain.Instance != null)
            {
                string fp = Module.previewFromPagePath;
                /*
                if (frmMain.Instance.lstSelectedFiles.SelectedIndex != -1)
                {
                    fp = frmMain.Instance.lstSelectedFiles.SelectedItem.ToString();
                }
                else
                {
                    if (frmMain.Instance.lsSelectedFiles.Count > 0)
                    {
                        fp = frmMain.Instance.lsSelectedFiles[0];
                    }
                    else
                    {
                        fp = Application.StartupPath + "\\mona_portrait.jpg";
                    }
                }
                */
                try
                {
                    Bitmap bmp = FreeImageHelper.LoadImage(fp);
                    XDPI = (int)bmp.HorizontalResolution;
                    YDPI = (int)bmp.VerticalResolution;
                }
                catch (Exception ex)
                {

                }
            }
            

            nudX.Value = XDPI;
            nudY.Value = YDPI;
        }
    }
}

