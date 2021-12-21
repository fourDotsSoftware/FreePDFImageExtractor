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
    public partial class frmText : CustomForm
    {
        public static frmText Instance = new frmText();        
        public int Position = 6;
        public int X = 0;
        public int Y = 0;
        public int opacity = 100;
        public string txt = "";
        public Font font = new Font(FontFamily.GenericSansSerif,14.25f);
        public Color color = Color.Black;

        public int _Position = 6;
        public int _X = 0;
        public int _Y = 0;
        public int _opacity = 100;
        public string _txt = "";
        public Font _font = new Font(FontFamily.GenericSansSerif, 14.25f);
        public Color _color = Color.Black;


        public string Filepath = "";
        public Bitmap img = null;



        public frmText()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Module.ShowError(ex);
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtMain.SelectAll();
                txtMain.SelectionFont = fontDialog1.Font;
                //font = fontDialog1.Font;
                UpdateText();
            }
        }

        private void UpdateText()
        {
           // MessageBox.Show(txtMain.SelectionFont.Size.ToString());

            UpdateValues();

            Bitmap bmp=ImagesExtractorHelper.ConvertPreview(false, img, Filepath, false);

            float ratio = (float)bmp.Width / (float)bmp.Height;

            int width = bmp.Width;
            int height = bmp.Height; 

            int new_width = (int)(ratio * height);
            int new_height = (int)((float)width / ratio);                       

            if (width > picText.Width)
            {
                width = picText.Width;
                height = (int)((float)width / ratio);
            }                       

            if (height > picText.Height)
            {
                height = picText.Height;
                width = (int)(ratio * height);
            }                       
            
            Bitmap bmp2 = new Bitmap(bmp, width, height);
            picText.Image = bmp2;

            picText.Invalidate();
        
        }                

        private void frmText_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(frmMain.Instance.chkText.Checked.ToString());

            try
            {
                if (cmbPosition.Items.Count == 0)
                {
                    cmbPosition.Items.Add(TranslateHelper.Translate("Top - Left"));
                    cmbPosition.Items.Add(TranslateHelper.Translate("Top - Center"));
                    cmbPosition.Items.Add(TranslateHelper.Translate("Top - Right"));
                    cmbPosition.Items.Add(TranslateHelper.Translate("Center"));
                    cmbPosition.Items.Add(TranslateHelper.Translate("Bottom - Left"));
                    cmbPosition.Items.Add(TranslateHelper.Translate("Bottom - Center"));
                    cmbPosition.Items.Add(TranslateHelper.Translate("Bottom - Right"));

                    cmbVariable.Items.Add("{Filename}");
                    cmbVariable.Items.Add("{Full Filepath}");
                    cmbVariable.Items.Add("{Creation Date}");
                    cmbVariable.Items.Add("{Creation Date Time}");
                    cmbVariable.Items.Add("{Creation Time}");

                    cmbVariable.Items.Add("{Last Accessed Date}");
                    cmbVariable.Items.Add("{Last Accessed Date Time}");
                    cmbVariable.Items.Add("{Last Accessed Time}");
                    cmbVariable.SelectedIndex = 0;
                }

                cmbPosition.SelectedIndex = Position;

                nudX.Value = X;
                nudY.Value = Y;

                txtMain.Text = txt;
                txtMain.SelectAll();
                txtMain.Font = font;
                txtMain.SelectionFont = font;
                txtMain.SelectionColor = color;
            }
            catch { }

            try
            {
                Filepath = Module.previewFromPagePath;//Application.StartupPath + "\\mona_portrait.jpg";

                /*
                if (frmMain.Instance != null)
                {
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
                }
                 */ 
            }
            catch { }

            try
            {
                img = FreeImageHelper.LoadImage(Filepath);
            }
            catch { }

            _Position = Position;
            _X = X;
            _Y = Y;
            _opacity = opacity;
            _txt = txt;
            _font =font;
            _color = color;

            UpdateText();

            this.AcceptButton = null;

            
        }

        private void picText_Paint(object sender, PaintEventArgs e)
        {
            return;
            try
            {                                               
                int x = -1;
                int y = -1;

                SizeF size=e.Graphics.MeasureString(txtMain.Text, txtMain.SelectionFont);
                int sizew = (int)size.Width;
                int sizeh = (int)size.Height;

                switch (cmbPosition.SelectedIndex)
                {
                    case 0:
                        x = 0;
                        y = 0;
                        break;
                    case 1:
                        x = (int)(picText.Width / 2) - (int)(sizew / 2);
                        y = 0;
                        break;
                    case 2:
                        x = (int)(picText.Width) - (int)(sizew);
                        y = 0;
                        break;

                    case 3:
                        x = (int)(picText.Width / 2) - (int)(sizew / 2);
                        y = (int)(picText.Height / 2) - (int)(sizeh / 2);
                        break;

                    case 4:
                        x = 0;
                        y = picText.Height - sizeh;
                        break;
                    case 5:
                        x = (int)(picText.Width / 2) - (int)(sizew / 2);
                        y = picText.Height - sizeh;
                        break;
                    case 6:
                        x = (int)(picText.Width) - (sizew);
                        y = picText.Height - sizeh;
                        break;
                }

                x = x + (int)nudX.Value;
                y = y + (int)nudY.Value;                              

                Brush b=new SolidBrush(txtMain.SelectionColor);
                
                e.Graphics.DrawString(txtMain.Text, txtMain.SelectionFont, b, (float)x, (float)y);
                
            }
            catch
            {
            }
        
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //color = colorDialog1.Color;
                txtMain.SelectAll();
                txtMain.SelectionColor = colorDialog1.Color;
                UpdateText();
            }
        }

        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            //txt = txtMain.Text;
            UpdateText();
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateText();
        }

        private void nudX_ValueChanged(object sender, EventArgs e)
        {
            UpdateText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void UpdateValues()
        {
            Position = cmbPosition.SelectedIndex;
            //Opacity = (int)nudOpacity.Value;

            X = (int)nudX.Value;
            Y = (int)nudY.Value;

            //txtMain.SelectAll();

            font = txtMain.SelectionFont;
            txt = txtMain.Text;
            color = txtMain.SelectionColor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Position = cmbPosition.SelectedIndex;
            //Opacity = (int)nudOpacity.Value;

            X = (int)nudX.Value;
            Y = (int)nudY.Value;

            txtMain.SelectAll();

            font = txtMain.SelectionFont;
            txt = txtMain.Text;
            color = txtMain.SelectionColor;

            this.DialogResult = DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMain.SelectedText = cmbVariable.SelectedItem.ToString();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Bitmap bmp = ImagesExtractorHelper.ConvertPreview(false, img, Filepath, false);
            frmPreview f = new frmPreview(bmp, Filepath);
            f.Show();
        }

        private void frmText_Activated(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }
    }
}

