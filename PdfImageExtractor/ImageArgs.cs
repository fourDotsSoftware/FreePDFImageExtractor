using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace PdfImageExtractor
{
    public class ImageArgs : IDisposable 
    {
        public int Rotate = 0;
        public bool Mirror = false;
        public Image bmp = null;
        public string Filepath = "";
        public string Comments = "";
        public string Diagnosis = "";
        public int ScrollTop = 0;
        public int ScrollLeft = 0;

        public int OverlayOffsetX = 0;
        public int OverlayOffsetY = 0;
        public float OverlayOpacity = 0f;
        public int OverlayX = 0;
        public int OverlayY = 0;
        public int OverlayWidth = 0;
        public int OverlayHeight = 0;

        public float OverlayScale= 0;
        public ImageArgs OverlayCompareImageArgs = null;
        public float ScaleStep = (float)0.0025;

        private int _Left = 0;
        private int _Top = 0;
        public int Left
        {
            get { return _Left; }
            set
            {
                int old_left = _Left;

                if (value <= 0)
                {
                    _Left = 0;
                }
                else if (value > (Width - PictureBox.Width))
                {
                    _Left = Width - PictureBox.Width;
                }
                else
                {
                    _Left = value;
                }
                
            }
        }
        public int Top
        {
            get { return _Top; }
            set
            {
                int old_top = _Top;

                if (value <= 0)
                {
                    _Top = 0;
                }
                else if (value > (Height - PictureBox.Height))
                {
                    _Top = Height - PictureBox.Height;
                }
                else
                {
                    _Top = value;
                }

                
            }

        }

        private float _Scale = (float)1;
        public float Scale
        {
            get { return _Scale; }
            set
            {
                _Scale = value;

                int zoomscale = (int)(_Scale * 100);

                //TxtInfo.Text = Filename + " ( " + TranslateHelper.Translate("Zoom") + " : " + zoomscale.ToString("#,##0.##") + "% )";
                TxtInfo.Text = Filename + "  ( " + TranslateHelper.Translate("Zoom") + " : " + zoomscale.ToString() + "% )";


                // initial scale
                //  ; x      new scale
                // x=(new scale) * initial/scale

                //if (OverlayCompareImageArgs != null)
                //{
                    //OverlayCompareImageArgs.Scale = _Scale * OverlayCompareImageArgs.OverlayInitialScaleFraction;
                //}
            }

        }

        public float fWidth = 0;
        public float fHeight = 0;

        public int Width
        {
            get { return (int)fWidth; }
            set { 
                
                if (value>5)
                {                
                    fWidth = (float)value;
                }
            }
        

        }
        public int Height
        {
            get { return (int)fHeight; }
            set
            {
                if (value > 5)
                {
                    fHeight = (float)value;
                }
            }
        }

        // 0 no zoom
        // 1 left corner set
        // 2 right corner set
        public int ZoomMode = 0;
        public int ZoomModeLeft = 0;
        public int ZoomModeTop = 0;
        public int ZoomModeRight = 0;
        public int ZoomModeBottom = 0;

        // 0 none
        // 1 left corner set
        // 2 right corner set
        public int CropMode = 0;
        public Point CropModeLeftTop = Point.Empty;
        public Point CropModeRightBottom = Point.Empty;

        public PictureBox PictureBox = null;
        public Panel Panel = null;
        public HScrollBar HScrollBar = null;
        public VScrollBar VScrollBar = null;
        public TextBox TxtInfo = null;
        

        public bool InSetBrightnessContrastGamma = false;
        public float Brightness = 0.0f;
        public float Contrast = 1.0f;
        public float Gamma = 1.0f;
        public bool IsMainImgArgs = true;
        public PixelFormat PixelFormat;
        public ImageFormat ImageFormat;
        
        public string Filename = "";
                
        public double RulerVerticalHooverValue = 0d;
        public double RulerHorizontalHooverValue = 0d;

        public ImageArgs(Bitmap img,string filepath, PictureBox picbox, Panel pnl, HScrollBar hsb, VScrollBar vsb, TextBox txtinfo, bool set_scrollbars, bool is_main_imgargs)
        {
            bmp = img;
            TxtInfo = txtinfo;
            PixelFormat = bmp.PixelFormat;
            ImageFormat = bmp.RawFormat;

            _Left = 0;
            _Top = 0;
            Width = bmp.Width;
            Height = bmp.Height;
            Rotate = 0;
            Scale = (float)1;

            Filepath = filepath;
            PictureBox = picbox;
            Panel = pnl;
            HScrollBar = hsb;
            VScrollBar = vsb;


            IsMainImgArgs = is_main_imgargs;
                    

            if (set_scrollbars)
            {
                SetScrollbars();
            }

            System.IO.FileInfo fi = new System.IO.FileInfo(filepath);
            Filename = fi.Name;
            TxtInfo.Text = fi.Name;
            
        }

        public void SetDimensions()
        {
            Width = (int)(bmp.Width * Scale);
            Height = (int)(bmp.Height * Scale);
            //Left = 0;
            //Top = 0;
        }

        public void SetScrollbars()
        {
            bool invalidate = false;

            if (PictureBox.Width < Width)
            {
                HScrollBar.Enabled = true;
                HScrollBar.Maximum = Width - PictureBox.Width;
            }
            else
            {
                Left = 0;
                HScrollBar.Enabled = false;
                invalidate = true;
            }

            if (PictureBox.Height < Height)
            {
                VScrollBar.Enabled = true;
                VScrollBar.Maximum = Height - PictureBox.Height;

            }
            else
            {
                Top = 0;
                VScrollBar.Enabled = false;
                invalidate = true;
            }

            try
            {
                HScrollBar.Value = this.Left;
            }
            catch
            {
                HScrollBar.Value = 0;
            }
            try
            {
                VScrollBar.Value = this.Top;
            }
            catch
            {
                VScrollBar.Value = 0;
            }
            //MessageBox.Show(this.MainImageArgs.PictureBox.Height.ToString());

            try
            {
                HScrollBar.SmallChange = HScrollBar.Maximum / 10;
                HScrollBar.LargeChange = HScrollBar.Maximum / 10;
            }
            catch { }

            try
            {
                VScrollBar.SmallChange = VScrollBar.Maximum / 10;
                VScrollBar.LargeChange = VScrollBar.Maximum / 10;

            }
            catch { }

           // if (frmImage.Instance != null)
           // {
           //     frmImage.Instance.picMain_MouseEnter(PictureBox, null);                               
          //  }

            if (invalidate)
            {
                PictureBox.Invalidate();
            }
        }

        

        private Image _UndoBmp = null;
        public Image UndoBmp
        {
            get { return _UndoBmp; }
            set
            {
                if (_UndoBmp != null)
                {
                    _UndoBmp.Dispose();

                }

                _UndoBmp = value;
                
            }
        }

        public void Dispose()
        {
            bmp.Dispose();

            if (UndoBmp != null)
            {
                UndoBmp.Dispose();
            }           
        }
    }
}
