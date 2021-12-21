using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfImageExtractor
{
    public partial class frmColorDepth : PdfImageExtractor.CustomForm
    {
        public static frmColorDepth Instance = new frmColorDepth();
        public long SelectedColorDepth = 32L;

        public int SelectedMaxColors = 16700000;
        public int SelectedMaxBits = 24;
        
        public frmColorDepth()
        {
            InitializeComponent();
        }

        public void frmColorDepth_Load(object sender, EventArgs e)
        {
            if (cmbColorDepth.Items.Count == 0)
            {
                cmbColorDepth.Items.Add("(32bit)");
                cmbColorDepth.Items.Add("16.7 Million (24bit)");
                cmbColorDepth.Items.Add("65536 (16bit)");
                cmbColorDepth.Items.Add("256 (8bit)");
                //cmbColorDepth.Items.Add("128 (7bit)");
                //cmbColorDepth.Items.Add("64 (6bit)");
                //cmbColorDepth.Items.Add("32 (5bit)");
                cmbColorDepth.Items.Add("16 (4bit)");
                //cmbColorDepth.Items.Add("8 (3bit)");
                //cmbColorDepth.Items.Add("4 (2bit)");
                cmbColorDepth.Items.Add("2 (1bit)");

                cmbColorDepth.SelectedIndex = 0;
            }
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            /*
            switch (cmbColorDepth.SelectedIndex)
            {
                case 0:
                    SelectedColorDepth = "24L";
                    break;
                case 1:
                    SelectedColorDepth = "16L";
                    break;
                case 2:
                    SelectedColorDepth = "8L";
                    break;
                case 3:
                    SelectedColorDepth = "7L";
                    break;
                case 4:
                    SelectedColorDepth = "6L";
                    break;
                case 5:
                    SelectedColorDepth = "5L";
                    break;
                case 6:
                    SelectedColorDepth = "4L";
                    break;
                case 7:
                    SelectedColorDepth = "3L";
                    break;
                case 8:
                    SelectedColorDepth = "2L";
                    break;
                case 9:
                    SelectedColorDepth = "1L";
                    break;

            }
            */
            //SelectedColorDepth = cmbColorDepth.SelectedIndex;

            /*
            switch (cmbColorDepth.SelectedIndex)
            {
                case 0:
                    SelectedColorDepth = 24L;
                    SelectedMaxColors = 16700000;
                    SelectedMaxBits = 24;
                    break;
                case 1:
                    SelectedColorDepth = 16L;
                    SelectedMaxColors=65536;
                    SelectedMaxBits = 16;
                    break;
                case 2:
                    SelectedColorDepth = 8L;
                    SelectedMaxColors=256;
                    SelectedMaxBits = 8;
                    break;
                case 3:
                    SelectedColorDepth = 7L;
                    SelectedMaxColors=128;
                    SelectedMaxBits=7;
                    break;
                case 4:
                    SelectedColorDepth = 6L;
                    SelectedMaxColors=64;
                    SelectedMaxBits=6;
                    break;
                case 5:
                    SelectedColorDepth = 5L;
                    SelectedMaxColors=32;
                    SelectedMaxBits=5;
                    break;
                case 6:
                    SelectedColorDepth = 4L;
                    SelectedMaxColors=16;
                    SelectedMaxBits=4;
                    break;
                case 7:
                    SelectedColorDepth = 3L;
                    SelectedMaxColors=8;
                    SelectedMaxBits=3;
                    break;
                case 8:
                    SelectedColorDepth = 2L;
                    SelectedMaxColors=4;
                    SelectedMaxBits=2;
                    break;
                case 9:
                    SelectedColorDepth = 1L;
                    SelectedMaxColors=2;
                    SelectedMaxBits=1;
                    break;

            }
            */

            string txt = cmbColorDepth.SelectedItem.ToString();
            int spos = txt.IndexOf("(");
            int epos = txt.IndexOf("bit");

            int depth=int.Parse(txt.Substring(spos+1,epos-spos-1));

            SelectedMaxBits=depth;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

