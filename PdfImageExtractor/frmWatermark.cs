using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    public partial class frmWatermark : PdfImageExtractor.CustomForm
    {
        public static frmWatermark Instance = new frmWatermark();
        public string WaterMarkImage = "";
        public int Position = 6;
        public int X = 0;
        public int Y = 0;
        public int opacity = 100;

        public string Filepath = "";
        public Bitmap img = null;

        public string _WaterMarkImage = "";
        public int _Position = 6;
        public int _X = 0;
        public int _Y = 0;
        public int _opacity = 100;
        
        public frmWatermark()
        {
            InitializeComponent();

        }

        private void tbOpacity_Scroll(object sender, EventArgs e)
        {
            nudOpacity.Value = tbOpacity.Value;
            UpdateWatermark();
        }

        private void nudOpacity_ValueChanged(object sender, EventArgs e)
        {
            tbOpacity.Value = (int)nudOpacity.Value;
            UpdateWatermark();
        }

        private void btnWatermarkImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = txtWatermarkImage.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtWatermarkImage.Text = openFileDialog1.FileName;
                UpdateWatermark();
            }
        }

        private void UpdateWatermark()
        {
            UpdateValues();

            Bitmap bmp=ImagesExtractorHelper.ConvertPreview(false, img, Filepath, false);

            float ratio = (float)bmp.Width / (float)bmp.Height;

            int width = bmp.Width;
            int height = bmp.Height; 

            int new_width = (int)(ratio * height);
            int new_height = (int)((float)width / ratio);                       

            if (width > picWatermark.Width)
            {
                width = picWatermark.Width;
                height = (int)((float)width / ratio);
            }                       

            if (height > picWatermark.Height)
            {
                height = picWatermark.Height;
                width = (int)(ratio * height);
            }                       
            
            Bitmap bmp2 = new Bitmap(bmp, width, height);
            picWatermark.Image = bmp2;

            picWatermark.Invalidate();
        }

        private void frmWatermark_Load(object sender, EventArgs e)
        {
            _WaterMarkImage = WaterMarkImage;
            _Position = Position;
            _X = X;
            _Y = Y;
            _opacity = opacity;

            if (cmbPosition.Items.Count == 0)
            {
                cmbPosition.Items.Add(TranslateHelper.Translate("Top - Left"));
                cmbPosition.Items.Add(TranslateHelper.Translate("Top - Center"));
                cmbPosition.Items.Add(TranslateHelper.Translate("Top - Right"));
                cmbPosition.Items.Add(TranslateHelper.Translate("Center"));
                cmbPosition.Items.Add(TranslateHelper.Translate("Bottom - Left"));
                cmbPosition.Items.Add(TranslateHelper.Translate("Bottom - Center"));
                cmbPosition.Items.Add(TranslateHelper.Translate("Bottom - Right"));
            }

            try
            {
                Filepath = Module.previewFromPagePath;//Application.StartupPath + "\\mona_portrait.jpg";

                /*
                if (frmMain.Instance.lstSelectedFiles.SelectedIndex != -1)
                {
                    Filepath = frmMain.Instance.lstSelectedFiles.SelectedItem.ToString();
                }
                else
                {
                    if (frmMain.Instance.lsSelectedFiles.Count > 0)
                    {
                        Filepath = frmMain.Instance.lsSelectedFiles[0];
                    }
                    else
                    {
                        Filepath = Application.StartupPath + "\\mona_portrait.jpg";
                    }
                }
                 */ 
            }
            catch { }
            try
            {
                img = FreeImageHelper.LoadImage(Filepath);
            }
            catch { }

            cmbPosition.SelectedIndex = Position;
            nudOpacity.Value = opacity;
            tbOpacity.Value = opacity;

            nudX.Value = X;
            nudY.Value = Y;

            txtWatermarkImage.Text = WaterMarkImage;

            if (WaterMarkImage == String.Empty)
            {
                txtWatermarkImage.Text = Application.StartupPath + "\\4dots_logo.png";
                WaterMarkImage = txtWatermarkImage.Text;
            }

            UpdateWatermark();
        }

        private void picWatermark_Paint(object sender, PaintEventArgs e)
        {
            return;
            try
            {
                if (txtWatermarkImage.Text == String.Empty) return;
                if (!System.IO.File.Exists(txtWatermarkImage.Text)) return;

                //Image img = Image.FromFile(txtWatermarkImage.Text);
                Image img = FreeImageHelper.LoadImage(txtWatermarkImage.Text);

                int x = -1;
                int y = -1;

                switch (cmbPosition.SelectedIndex)
                {
                    case 0:
                        x = 0;
                        y = 0;
                        break;
                    case 1:
                        x = (int)(picWatermark.Width / 2) - (int)(img.Width / 2);
                        y = 0;
                        break;
                    case 2:
                        x = (int)(picWatermark.Width) - (int)(img.Width);
                        y = 0;
                        break;

                    case 3:
                        x = (int)(picWatermark.Width / 2) - (int)(img.Width / 2);
                        y = (int)(picWatermark.Height / 2) - (int)(img.Height / 2);
                        break;

                    case 4:
                        x = 0;
                        y = picWatermark.Height - img.Height;
                        break;
                    case 5:
                        x = (int)(picWatermark.Width / 2) - (int)(img.Width / 2);
                        y = picWatermark.Height - img.Height;
                        break;
                    case 6:
                        x = (int)(picWatermark.Width) - (img.Width);
                        y = picWatermark.Height - img.Height;
                        break;
                }

                x = x + (int)nudX.Value;
                y = y + (int)nudY.Value;

                float TransparencyLevel=(float)((float)nudOpacity.Value / (float)100);                
                float[][] matrixItems = new float[][] {
                                new float[] {1, 0, 0, 0, 0},
                                new float[] {0, 1, 0, 0, 0},
                                new float[] {0, 0, 1, 0, 0},
                                new float[] {0, 0, 0, TransparencyLevel, 0},
                                new float[] {0, 0, 0, 0, 1}};


                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
                                
                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

                Point[] rdestinationPoints = new Point[] { new Point(x, y), new Point(x+img.Width, y), new Point(x, y+img.Height) };

                e.Graphics.DrawImage(
                img, rdestinationPoints,
                new Rectangle(
                0,             // source rectangle x
                0,             // source rectangle y
                img.Width,        // source rectangle width
                img.Height),       // source rectangle height               
                GraphicsUnit.Pixel,
                imageAtt);                                
            }
            catch
            {
            }
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWatermark();
        }

        private void nudY_ValueChanged(object sender, EventArgs e)
        {
            UpdateWatermark();
        }

        private void nudX_ValueChanged(object sender, EventArgs e)
        {
            UpdateWatermark();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            WaterMarkImage = _WaterMarkImage;
            Position = _Position;
            X = _X;
            Y = _Y;
            opacity = _opacity;

            this.DialogResult = DialogResult.Cancel;
        }

        private void UpdateValues()
        {
            Position = cmbPosition.SelectedIndex;
            opacity = (int)nudOpacity.Value;

            X = (int)nudX.Value;
            Y = (int)nudY.Value;

            WaterMarkImage = txtWatermarkImage.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Position = cmbPosition.SelectedIndex;
            opacity = (int)nudOpacity.Value;

            X = (int)nudX.Value;
            Y = (int)nudY.Value;

            WaterMarkImage = txtWatermarkImage.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Bitmap bmp = ImagesExtractorHelper.ConvertPreview(false, img, Filepath, false);
            frmPreview f = new frmPreview(bmp, Filepath);
            f.Show();
        }
    }
}

