using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfImageExtractor
{
    public partial class frmColorTransformations : PdfImageExtractor.CustomForm
    {
        public static frmColorTransformations Instance = new frmColorTransformations();

        public int Brightness = 0;
        public int Contrast = 0;
        public int Gamma =0;
        public int Red = 0;
        public int Green = 0;
        public int Blue = 0;
        public int Hue = 0;
        public int Saturation = 0;
        public int Value = 0;
        public int Sharpen = 0;
        public int Alpha = 255;
        public int GaussianBlur = 0;
        public int Emboss = 0;
        public bool Sepia = false;
        public bool Grayscale = false;
        public bool Negative = false;

        // for preview

        public int brightness = 0;
        public int contrast = 0;
        public int gamma =0;
        public int red = 0;
        public int green = 0;
        public int blue = 0;
        public int hue = 0;
        public int saturation = 0;
        public int value = 0;
        public int sharpen = 0;
        public int alpha = 255;
        public int gaussianBlur = 0;
        public int emboss = 0;
        public bool sepia = false;
        public bool grayscale = false;
        public bool negative = false;

        // end

        public frmColorTransformations()
        {
            InitializeComponent();

            if (Brightness != -1)
            {
                nudBrightness.Value = Brightness;
                tbBrightness.Value = Brightness;
            }
            if (Contrast != -1)
            {
                nudContrast.Value = Contrast;
                tbContrast.Value = Contrast;
            }

            if (Gamma != -1)
            {
                nudGamma.Value = Gamma;
                tbGamma.Value = Gamma;
            }


            if (Red != -1)
            {
                nudRed.Value = Red;
                tbRed.Value = Red;
            }

            if (Green != -1)
            {
                nudGreen.Value = Green;
                tbGreen.Value = Green;

            }
            if (Blue != -1)
            {
                nudBlue.Value = Blue;
                tbBlue.Value = Blue;
            }
            if (Hue != -1)
            {
                nudHue.Value = Hue;
                tbHue.Value = Hue;
            }
            if (Saturation != -1)
            {
                nudSaturation.Value = Saturation;
                tbSaturation.Value = Saturation;
            }

            if (Value != -1)
            {
                nudValue.Value = Value;
                tbValue.Value = Value;

            }

            if (Sharpen != -1)
            {
                nudSharpen.Value = Sharpen;
                tbSharpen.Value = Sharpen;
            }

            if (Alpha != -1)
            {
                nudAlpha.Value = Alpha;
                tbAlpha.Value = Alpha;

            }

            if (GaussianBlur != -1)
            {
                nudBlur.Value = GaussianBlur;
                tbBlur.Value = GaussianBlur;
            }

            if (Emboss != -1)
            {
                nudEmboss.Value = Emboss;
                tbEmboss.Value = Emboss;

            }

            chkSepia.Checked = Sepia;
            chkGrayscale.Checked = Grayscale;
            chkNegative.Checked = Negative;
        }

        private void tbBrightness_Scroll(object sender, EventArgs e)
        {
            nudBrightness.Value = tbBrightness.Value;
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            nudContrast.Value = tbContrast.Value;            
        }

        private void tbGamma_Scroll(object sender, EventArgs e)
        {
            nudGamma.Value = tbGamma.Value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Brightness = (int)nudBrightness.Value;
            Contrast = (int)nudContrast.Value;
            Gamma = (int)nudGamma.Value;
            Red = (int)nudRed.Value;
            Green = (int)nudGreen.Value;
            Blue = (int)nudBlue.Value;
            Hue = (int)nudHue.Value;
            Saturation = (int)nudSaturation.Value;
            Value = (int)nudValue.Value;
            Sharpen = (int)nudSharpen.Value;
            Alpha = (int)nudAlpha.Value;
            GaussianBlur = (int)nudBlur.Value;
            Emboss = (int)nudEmboss.Value;
            Sepia = chkSepia.Checked;
            Grayscale = chkGrayscale.Checked;
            Negative = chkNegative.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void tbRed_Scroll(object sender, EventArgs e)
        {
            nudRed.Value = tbRed.Value;
        }

        private void tbGreen_Scroll(object sender, EventArgs e)
        {
            nudGreen.Value = tbGreen.Value;
        }

        private void tbBlue_Scroll(object sender, EventArgs e)
        {
            nudBlue.Value = tbBlue.Value;
        }

        private void tbHue_Scroll(object sender, EventArgs e)
        {
            nudHue.Value = tbHue.Value;
        }

        private void tbSaturation_Scroll(object sender, EventArgs e)
        {
            nudSaturation.Value = tbSaturation.Value;
        }

        private void tbLightness_Scroll(object sender, EventArgs e)
        {
            nudValue.Value = tbValue.Value;
        }

        private void tbSharpen_Scroll(object sender, EventArgs e)
        {
            nudSharpen.Value = tbSharpen.Value;
        }

        private void tbAlpha_Scroll(object sender, EventArgs e)
        {
            nudAlpha.Value = tbAlpha.Value;
        }

        private void tbEmboss_Scroll(object sender, EventArgs e)
        {
            nudEmboss.Value = tbEmboss.Value;
        }

        private void tbBlur_Scroll(object sender, EventArgs e)
        {
            nudBlur.Value = tbBlur.Value;
        }

        private void nudLightness_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ShowPreview()
        {
            brightness = (int)nudBrightness.Value;
            contrast = (int)nudContrast.Value;
            gamma = (int)nudGamma.Value;
            red = (int)nudRed.Value;
            green = (int)nudGreen.Value;
            blue = (int)nudBlue.Value;
            hue = (int)nudHue.Value;
            saturation = (int)nudSaturation.Value;
            value = (int)nudValue.Value;
            sharpen = (int)nudSharpen.Value;
            alpha = (int)nudAlpha.Value;
            gaussianBlur = (int)nudBlur.Value;
            emboss = (int)nudEmboss.Value;
            sepia = chkSepia.Checked;
            grayscale = chkGrayscale.Checked;
            negative = chkNegative.Checked;


            try
            {
                Bitmap img = ImagesExtractorHelper.ConvertPreview(true, PreviewImg, Module.previewFromPagePath,true);
                
                picPreview.Left = 31;
                picPreview.Top = 31;
                

                picPreview.Image = img;
                picPreview.Width = img.Width;
                picPreview.Height = img.Height;

                picPreview.Refresh();
            }
            catch
            {
                picPreview.Image = null;
                Module.ShowError("Error could not show Preview !");
                picPreview.Left = 31;
                picPreview.Top = 31;

                picPreview.Image = Module.imgmona;
                picPreview.Width = Module.imgmona.Width;
                picPreview.Height = Module.imgmona.Height;
            }
        }

        private void btnOpenPreview_Click(object sender, EventArgs e)
        {
            frmPreview f = new frmPreview(true);
            f.ShowDialog();
        }

        private Bitmap PreviewImg = (Bitmap)Image.FromFile(Module.previewFromPagePath);
     
        private void cmbPreviewFile_SelectedIndexChanged(object sender, EventArgs e)        
        {
           PreviewImg=FreeImageHelper.LoadImage(Module.previewFromPagePath);

           if (PreviewImg.Width > 256)
           {
               float scale = (float)PreviewImg.Height / (float)PreviewImg.Width;
               int new_height = (int)(scale * 256);

               PreviewImg = new Bitmap(PreviewImg, 256, new_height);

           }

            ShowPreview();
        }
        private void frmColorTransformations_Load(object sender, EventArgs e)
        {
            //cmbPreviewFile.Items.Clear();

            /*
            for (int k=0;k<frmMain.Instance.cmbPreviewFile.Items.Count;k++)
            {
                cmbPreviewFile.Items.Add(frmMain.Instance.cmbPreviewFile.Items[k].ToString());
            }

            cmbPreviewFile.SelectedIndex=frmMain.Instance.cmbPreviewFile.SelectedIndex;
            cmbPreviewFile_SelectedIndexChanged(null, null);
            */

            ShowPreview();
        }

        private void nudBrightness_ValueChanged(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void nudRed_ValueChanged(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void nudHue_ValueChanged(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void nudSharpen_ValueChanged(object sender, EventArgs e)
        {
            ShowPreview();
        }

        private void chkGrayscale_CheckedChanged(object sender, EventArgs e)
        {
            ShowPreview();
        }

        

        
    }
}

