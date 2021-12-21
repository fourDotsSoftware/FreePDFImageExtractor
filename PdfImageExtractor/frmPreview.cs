using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace PdfImageExtractor
{
    public partial class frmPreview : CustomForm
    {
        public ImageArgs MainImageArgs = null;
        // the step for zoom in and zoom out
        private float ScaleStep = (float)0.10;

        public frmPreview(bool for_adjustments)
        {
            InitializeComponent();

            Bitmap img = null;
            string filepath = null;

            if (!for_adjustments)
            {
                this.Text = "Preview - " + Module.previewFromPagePath;

                img = ImagesExtractorHelper.ConvertPreview(false, null, "", false);
                //picMain.Image = img;

                filepath = Module.previewFromPagePath;
            }
            else
            {
                // this.Text = "Preview - " + frmColorTransformations.Instance.cmbPreviewFile.SelectedItem.ToString();

                this.Text = "Preview - " + Module.previewFromPagePath;
                                
                //picMain.Image = img;

                filepath = Module.previewFromPagePath;


                img = ImagesExtractorHelper.ConvertPreview(false, null, "",true);
                //picMain.Image = img;

               // filepath = frmColorTransformations.Instance.cmbPreviewFile.SelectedItem.ToString();
            }

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
                        
            MainImageArgs = new ImageArgs(img, filepath, picMain, null, hsbMain, vsbMain, txtMainInfo, true, true);            

        }

        public frmPreview(Bitmap img,string filepath)
        {
            InitializeComponent();                       
            
            this.Text = "Preview - " + filepath;
                            
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            MainImageArgs = new ImageArgs(img, filepath, picMain, null, hsbMain, vsbMain, txtMainInfo, true, true);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            
            MainImageArgs.SetScrollbars();                        

            btnFitScreenMain_Click(null, null);
            
        }

        private void btnFitScreenMain_Click(object sender, EventArgs e)
        {
            float scalex = (float)((float)MainImageArgs.PictureBox.Width / (float)MainImageArgs.bmp.Width);
            float scaley = (float)((float)MainImageArgs.PictureBox.Height / (float)MainImageArgs.bmp.Height);
            float scale;
            if (scalex < scaley)
            {
                scale = scalex;
            }
            else
            {
                scale = scaley;
            }
            MainImageArgs.Scale = scale;
            MainImageArgs.Width = (int)(MainImageArgs.bmp.Width * MainImageArgs.Scale);
            MainImageArgs.Height = (int)(MainImageArgs.bmp.Height * MainImageArgs.Scale);
            MainImageArgs.Left = 0;
            MainImageArgs.Top = 0;
            MainImageArgs.SetScrollbars();
            //MainImageArgs.PictureBox.Refresh();
            MainImageArgs.PictureBox.Invalidate();
        }

        private void DrawImage(Graphics g, ImageArgs imgargs)
        {
            if (imgargs == null) return;

            //Graphics g = this.MainImageArgs.PictureBox.CreateGraphics();

            Point[] destinationPoints = null;
            g.Clear(imgargs.PictureBox.BackColor);
                        
            
            
            destinationPoints = new Point[]{
                    new Point(0-imgargs.Left,0-imgargs.Top),new Point(imgargs.Width-imgargs.Left,0-imgargs.Top),new Point(0-imgargs.Left,imgargs.Height-imgargs.Top)};
            

            g.DrawImage(imgargs.bmp, destinationPoints);

            g.Transform = new Matrix();
            
        }

        bool InHandleZoom = false;
        public bool ZoomInZoomOut = false;
        public bool SmartZoom = false;

        private void HandleZoom(object sender, MouseEventArgs e)
        {
            try
            {
                InHandleZoom = true;

                if (MainImageArgs == null) return;
                                

                if (MainImageArgs.ZoomMode == 1)
                {
                    MainImageArgs.ZoomModeLeft = e.X;
                    MainImageArgs.ZoomModeTop = e.Y;
                    MainImageArgs.ZoomMode = 2;

                    //MessageBox.Show("OK0");
                }
                /* !
                else if (MainImageArgs.CropMode == 1)
                {
                    MainImageArgs.CropModeLeftTop = new Point(e.X, e.Y);
                    MainImageArgs.CropMode = 2;

                    //MessageBox.Show("OK0");
                }
                */
                else if (MainImageArgs.ZoomMode == 2)
                {
                    MainImageArgs.ZoomMode = 0;
                    MainImageArgs.ZoomModeRight = e.X;
                    MainImageArgs.ZoomModeBottom = e.Y;

                    int boxwidth = MainImageArgs.ZoomModeRight - MainImageArgs.ZoomModeLeft;
                    int boxheight = MainImageArgs.ZoomModeBottom - MainImageArgs.ZoomModeTop;
                    float oldScale = MainImageArgs.Scale;

                    //MainImageArgs.Scale = oldScale*(float)((float)MainImageArgs.PictureBox.Width/(float)boxwidth);
                    MainImageArgs.Scale = oldScale * (float)((float)MainImageArgs.PictureBox.Height / (float)boxheight);

                    MainImageArgs.fWidth = ((float)MainImageArgs.Width * MainImageArgs.Scale / oldScale);
                    MainImageArgs.fHeight = ((float)MainImageArgs.Height * MainImageArgs.Scale / oldScale);

                    int new_boxwidth = (int)((float)MainImageArgs.PictureBox.Width / MainImageArgs.Scale);
                    //float picwidth = (float)MainImageArgs.PictureBox.Width* MainImageArgs.Scale;

                    MainImageArgs.Left = -new_boxwidth / 2 + (int)((float)(MainImageArgs.Left + MainImageArgs.ZoomModeLeft) * MainImageArgs.Scale / oldScale);
                    MainImageArgs.Top = (int)((float)(MainImageArgs.Top + MainImageArgs.ZoomModeTop) * MainImageArgs.Scale / oldScale);

                    MainImageArgs.SetScrollbars();


                    //MainImageArgs.PictureBox.Refresh();
                    MainImageArgs.PictureBox.Invalidate();


                }
                                

                if (ZoomInZoomOut || SmartZoom)
                {
                    float oldScale = MainImageArgs.Scale;
                    // Zoom In
                    if (e.Button == MouseButtons.Left)
                    {
                        MainImageArgs.Scale = (float)(MainImageArgs.Scale + ScaleStep);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        MainImageArgs.Scale = (float)(MainImageArgs.Scale - ScaleStep);
                    }
                    else
                    {
                        return;
                    }

                    int new_x = (int)((e.X + MainImageArgs.HScrollBar.Value) * MainImageArgs.Scale / oldScale);
                    int new_y = (int)((e.Y + MainImageArgs.VScrollBar.Value) * MainImageArgs.Scale / oldScale);

                    int old_left = MainImageArgs.Left;
                    int old_top = MainImageArgs.Top;

                    MainImageArgs.Left = (int)new_x - (int)(MainImageArgs.PictureBox.Width / 2);
                    MainImageArgs.Top = (int)new_y - (int)(MainImageArgs.PictureBox.Height / 2);

                    // al cl
                    // nal ; x
                                        
                    MainImageArgs.fWidth = ((float)MainImageArgs.bmp.Width * MainImageArgs.Scale);
                    MainImageArgs.fHeight = ((float)MainImageArgs.bmp.Height * MainImageArgs.Scale);
                    //MainImageArgs.Left = (int)(MainImageArgs.Left + ScaleStep * MainImageArgs.Left);
                    //MainImageArgs.Top = (int)(MainImageArgs.Top + ScaleStep * MainImageArgs.Top);



                    MainImageArgs.SetScrollbars();
                    MainImageArgs.PictureBox.Invalidate();//.Refresh();
                }

                
            }
            finally
            {
                InHandleZoom = false;
            }
        }

        private void tbMain_Scroll(object sender, EventArgs e)
        {            
           
            MainImageArgs.ZoomModeRight = picMain.Height / 2;
            MainImageArgs.ZoomModeBottom = picMain.Width / 2;
                        
            float oldScale = MainImageArgs.Scale;
            float tbstep = (float)(tbMain.Value - (float)(tbMain.Maximum / 2));

            MainImageArgs.Scale = 1 + tbstep * MainImageArgs.ScaleStep;
            MainImageArgs.fWidth = ((float)MainImageArgs.fWidth * MainImageArgs.Scale / oldScale);
            MainImageArgs.fHeight = ((float)MainImageArgs.fHeight * MainImageArgs.Scale / oldScale);                        

            int new_boxwidth = (int)((float)MainImageArgs.PictureBox.Width / MainImageArgs.Scale);            

            MainImageArgs.Left = -new_boxwidth / 2 + (int)((float)(MainImageArgs.Left + MainImageArgs.ZoomModeLeft) * MainImageArgs.Scale / oldScale);
            MainImageArgs.Top = (int)((float)(MainImageArgs.Top + MainImageArgs.ZoomModeTop) * MainImageArgs.Scale / oldScale);

            MainImageArgs.SetScrollbars();
            picMain.Invalidate();
        
        }

        private void picMain_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics, MainImageArgs);
        }

        private void vsbMain_Scroll(object sender, ScrollEventArgs e)
        {
            vsbMain.Focus();
            if (MainImageArgs == null) return;
            MainImageArgs.Top = e.NewValue;// -e.OldValue;
            //MainImageArgs.PictureBox.Refresh();
            MainImageArgs.PictureBox.Invalidate();
        }

        private void hsbMain_Scroll(object sender, ScrollEventArgs e)
        {
            if (MainImageArgs == null) return;

            hsbMain.Focus();

            MainImageArgs.Left = e.NewValue;// -e.OldValue;
            //MainImageArgs.PictureBox.Refresh();
            MainImageArgs.PictureBox.Invalidate();
        }

        
    }
}

