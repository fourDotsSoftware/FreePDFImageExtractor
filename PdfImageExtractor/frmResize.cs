using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PdfImageExtractor
{
    public partial class frmResize : CustomForm
    {
        public Image img;

        public float width = 0;
        public float height = 0;
        public bool KeepRatio = false;
        public bool Pixels = true;
        public bool Percentage = false;
        public bool Inches = false;
        public bool Cm = false;
        public bool Points = false;

        public bool SetValues = false;


        // 0 custom
        // 1 small
        // 2 medium
        // 3 large
        public int Mode = 0;

        public static frmResize Instance = new frmResize();

        private int nudWS;
        private int nudHS;
        private int nudWM;
        private int nudHM;
        private int nudWL;
        private int nudHL;
        
        public frmResize()
        {
            InitializeComponent();                      
        }

        public void frmCustomResize_Load(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser;

                key = key.OpenSubKey(@"Software\softpcapps Software\ImgTransformer", false);
                nudWS = int.Parse(key.GetValue("SmallW", "800").ToString());
                nudHS = int.Parse(key.GetValue("SmallH", "600").ToString());
                nudWM = int.Parse(key.GetValue("MediumW", "1024").ToString());
                nudHM = int.Parse(key.GetValue("MediumH", "768").ToString());
                nudWL = int.Parse(key.GetValue("LargeW", "1280").ToString());
                nudHL = int.Parse(key.GetValue("LargeH", "1024").ToString());

                key.Close();

            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not get options !", ex);
            }                        
            
            if (cmbPixelsPercent.Items.Count == 0)
            {
                cmbPixelsPercent.Items.Add("Pixels");
                cmbPixelsPercent.Items.Add("Percent");
                cmbPixelsPercent.Items.Add("Inches");
                cmbPixelsPercent.Items.Add("Cm");
                cmbPixelsPercent.Items.Add("Points");

                cmbPreset.Items.Add("Small");
                cmbPreset.Items.Add("Medium");
                cmbPreset.Items.Add("Large");
                
                cmbPreset.Items.Add("120 x 90");
                cmbPreset.Items.Add("160 x 120");
                cmbPreset.Items.Add("200 x 150");
                cmbPreset.Items.Add("320 x 240");
                cmbPreset.Items.Add("400 x 300");
                cmbPreset.Items.Add("640 x 480");
                cmbPreset.Items.Add("800 x 600");
                cmbPreset.Items.Add("1024 x 600");
                cmbPreset.Items.Add("1024 x 768");
                cmbPreset.Items.Add("1200 x 900");
                cmbPreset.Items.Add("1280 x 800");
                cmbPreset.Items.Add("1280 x 1024");
                cmbPreset.Items.Add("1366 x 768");
                cmbPreset.Items.Add("1440 x 900");
                cmbPreset.Items.Add("1600 x 1200");
                cmbPreset.Items.Add("1920 x 1080");
                cmbPreset.Items.Add("2048 x 1536");
                cmbPreset.Items.Add("2272 x 1704");
                cmbPreset.Items.Add("Screen Size");
                cmbPreset.Items.Add("25%");
                cmbPreset.Items.Add("50% (Half Size)");
                cmbPreset.Items.Add("150%");
                cmbPreset.Items.Add("200% (Double Size)");
                cmbPreset.Items.Add("250%");
                cmbPreset.Items.Add("300% (Triple Size)");
                cmbPreset.Items.Add("400%");
                cmbPreset.Items.Add("500%");

                cmbPixelsPercent.SelectedIndex = 0;
            }
            
            
            if (Pixels && !SetValues && frmMain.Instance != null)
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
                    Bitmap bmp=FreeImageHelper.LoadImage(fp);
                    width = bmp.Width;
                    height = bmp.Height;
                }
                catch (Exception ex)
                {

                }
            }
            

            nudWidth.Value = (decimal)width;
            nudHeight.Value = (decimal)height;
            chkKeepRatio.Checked = KeepRatio;

            if (Pixels)
            {
                cmbPixelsPercent.SelectedIndex = 0;
            }
            else if (Percentage)
            {
                cmbPixelsPercent.SelectedIndex = 1;
            }
            else if (Inches)
            {
                cmbPixelsPercent.SelectedIndex = 2;
            }
            else if (Cm)
            {
                cmbPixelsPercent.SelectedIndex = 3;
            }
            else if (Points)
            {
                cmbPixelsPercent.SelectedIndex = 4;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            SetValues = true;

            if (chkKeepRatio.Checked && ((nudWidth.Value)>0))
            {
                width =(float) nudWidth.Value;
                height = 0;
                KeepRatio = true;
            }
            else if (chkKeepRatio.Checked && ((nudHeight.Value) > 0))
            {
                KeepRatio = true;
                width = 0;
                height =(float)nudHeight.Value;
            }
            else
            {
                width =(float) nudWidth.Value;
                height = (float)nudHeight.Value;
            }

            KeepRatio = chkKeepRatio.Checked;
            Pixels = (cmbPixelsPercent.SelectedIndex == 0);
            Percentage = (cmbPixelsPercent.SelectedIndex == 1);
            Inches = (cmbPixelsPercent.SelectedIndex == 2);
            Cm = (cmbPixelsPercent.SelectedIndex == 3);
            Points = (cmbPixelsPercent.SelectedIndex == 4);

            switch (cmbPreset.SelectedIndex)
            {
                case 0:
                    Mode = 1;
                    break;
                case 1:
                    Mode = 2;
                    break;
                case 2:
                    Mode = 3;
                    break;
                default:
                    Mode = 0;
                    break;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            /*
            if (chkKeepRatio.Checked)
            {
                Height = (int)nudHeight.Value;
                Width = -1;
                KeepRatio = true;
            }
            else
            {
                KeepRatio = false;
                Height = (int)nudHeight.Value;
            }
            */
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            
        }

        public void SetCmdParameters(int preset)
        {
            
        }
        public void cmbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbPreset.SelectedIndex)
            {
                case 0:
                    nudWidth.Value = nudWS;
                    nudHeight.Value = nudHS;
                    cmbPixelsPercent.SelectedIndex = 0;
                    break;

                case 1:
                    nudWidth.Value = nudWM;
                    nudHeight.Value = nudHM;
                    cmbPixelsPercent.SelectedIndex = 0;
                    break;

                case 2:
                    nudWidth.Value = nudWL;
                    nudHeight.Value = nudHL;
                    cmbPixelsPercent.SelectedIndex = 0;
                    break;

                case 3:
                    nudWidth.Value=120;
                    nudHeight.Value=90;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 4:
                    nudWidth.Value=160;
                    nudHeight.Value=120;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 5:
                    nudWidth.Value=200;
                    nudHeight.Value=150;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 6:
                    nudWidth.Value=320;
                    nudHeight.Value=240;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 7:
                    nudWidth.Value=400;
                    nudHeight.Value=300;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 8:
                    nudWidth.Value=640;
                    nudHeight.Value=480;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 9:
                    nudWidth.Value=800;
                    nudHeight.Value=600;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 10:
                    nudWidth.Value=1024;
                    nudHeight.Value=600;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 11:
                    nudWidth.Value=1024;
                    nudHeight.Value=768;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 12:
                    nudWidth.Value=1200;
                    nudHeight.Value=900;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 13:
                    nudWidth.Value=1280;
                    nudHeight.Value=800;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 14:
                    nudWidth.Value=1280;
                    nudHeight.Value=1024;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 15:
                    nudWidth.Value=1366;
                    nudHeight.Value=768;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 16:
                    nudWidth.Value=1440;
                    nudHeight.Value=900;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 17:
                    nudWidth.Value=1600;
                    nudHeight.Value=1200;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;

                case 18:
                    nudWidth.Value=1920;
                    nudHeight.Value=1080;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;

                case 19:
                    nudWidth.Value=2048;
                    nudHeight.Value=1536;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;

                case 20:
                    nudWidth.Value=2272;
                    nudHeight.Value=1704;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 21:
                    nudWidth.Value=Screen.PrimaryScreen.WorkingArea.Width;
                    nudHeight.Value=Screen.PrimaryScreen.WorkingArea.Height;
                    cmbPixelsPercent.SelectedIndex=0;
                    break;
                case 22:
                    nudWidth.Value=25;
                    nudHeight.Value=25;
                    cmbPixelsPercent.SelectedIndex=1;
                    break;
                case 23:
                    nudWidth.Value=50;
                    nudHeight.Value=50;
                    cmbPixelsPercent.SelectedIndex=1;
                    break;
                case 24:
                    nudWidth.Value=150;
                    nudHeight.Value=150;
                    cmbPixelsPercent.SelectedIndex=1;
                    break;
                case 25:
                    nudWidth.Value=200;
                    nudHeight.Value=200;
                    cmbPixelsPercent.SelectedIndex=1;
                    break;
                case 26:
                    nudWidth.Value=250;
                    nudHeight.Value=250;
                    cmbPixelsPercent.SelectedIndex=1;
                    break;
                case 27:
                    nudWidth.Value=300;
                    nudHeight.Value=300;
                    cmbPixelsPercent.SelectedIndex=1;
                    break;
                case 28:
                    nudWidth.Value=400;
                    nudHeight.Value=400;
                    cmbPixelsPercent.SelectedIndex=1;
                    break;
                case 29:
                    nudWidth.Value=500;
                    nudHeight.Value=500;
                    cmbPixelsPercent.SelectedIndex=1;
                    break;
            }
        }

        private void chkKeepRatio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeepRatio.Checked)
            {
                if (nudWidth.Value > 0)
                {
                    nudHeight.Value = 0;
                }
                else
                {
                    nudWidth.Value = 0;
                }
            }

            label4.Visible = chkKeepRatio.Checked;
        }

        private void cmbPixelsPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPixelsPercent.SelectedIndex == 0 || cmbPixelsPercent.SelectedIndex==1 || cmbPixelsPercent.SelectedIndex==4)
            {
                nudWidth.DecimalPlaces = 0;
                nudHeight.DecimalPlaces = 0;
            }
            else if (cmbPixelsPercent.SelectedIndex == 2 || cmbPixelsPercent.SelectedIndex == 3)
            {
                nudWidth.DecimalPlaces = 1;
                nudHeight.DecimalPlaces = 1;
            }
        }
    }
}


