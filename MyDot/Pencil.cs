using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDot
{
    public partial class Pencil : Form
    {
        public Pencil()
        {
            InitializeComponent();
        }

        private bool bolColorDialog = false;
        private bool bolSaveColorClick = false;

        private void Pencil_Load(object sender, EventArgs e)
        {
            DataSaver.pclNow = this;
            for (int i = 0; i < 7; i++)
            {
                DataSaver.saveRGBA[i] = new RGBA();
            }
        }

        private void RtbKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void BtnChoice_Click(object sender, EventArgs e)
        {
            try
            {
                DataSaver.nowRGBA = new RGBA(int.Parse(RtbR.Text), int.Parse(RtbG.Text), int.Parse(RtbB.Text), int.Parse(RtbA.Text));
                PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
            }
            catch
            {

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SfdSave.ShowDialog() == DialogResult.OK)
            {
                BitSave(SfdSave.FileName.ToString());
            }
        }

        private void BitSave(string strPath)
        {
            Bitmap bitmap = new Bitmap(DataSaver.intWidth, DataSaver.intHeight);
            for (int x = 0; x < DataSaver.intWidth; x++)
            {
                for (int y = 0; y < DataSaver.intHeight; y++)
                {
                    Color color = DataSaver.btmRGBA[x, y].ColorReturn();
                    bitmap.SetPixel(x, y, color);
                }
            }
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
            bitmap.Save(strPath);
            bitmap.Dispose();
        }

        private void BtnSmart_Click(object sender, EventArgs e)
        {
            bolColorDialog = true;
            if (CldColor.ShowDialog() == DialogResult.OK)
            {
                DataSaver.nowRGBA = new RGBA(CldColor.Color);
                PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
                RtbR.Text = DataSaver.nowRGBA.R.ToString();
                RtbG.Text = DataSaver.nowRGBA.G.ToString();
                RtbB.Text = DataSaver.nowRGBA.B.ToString();
                RtbA.Text = DataSaver.nowRGBA.A.ToString();
            }
            bolColorDialog = false;
        }

        private void BtnBorder_Click(object sender, EventArgs e)
        {
            DataSaver.bmmNow.PbxBorder();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                int intExport = int.Parse(RtbExport.Text);
                if (SfdSave.ShowDialog() == DialogResult.OK)
                {
                    string strPath = SfdSave.FileName.ToString();
                    Bitmap bitmap = new Bitmap(DataSaver.intWidth * intExport, DataSaver.intHeight * intExport);
                    for (int x = 0; x < bitmap.Width; x += intExport)
                    {
                        for (int y = 0; y < bitmap.Height; y += intExport)
                        {
                            for (int xx = 0; xx < intExport; xx++)
                            {
                                for (int yy = 0; yy < intExport; yy++)
                                {
                                    Color color = DataSaver.btmRGBA[x / intExport, y / intExport].ColorReturn();
                                    bitmap.SetPixel(x + xx, y + yy, color);
                                }
                            }
                        }
                    }
                    if (File.Exists(strPath))
                    {
                        File.Delete(strPath);
                    }
                    bitmap.Save(strPath);
                    bitmap.Dispose();
                }
            }
            catch
            {

            }
        }

        private void BtnCombine_Click(object sender, EventArgs e)
        {
            bool bolBitSaveCheak = false;
            Bitmap[,] bitmaps = new Bitmap[int.Parse(RtbCWidth.Text), int.Parse(RtbCHeight.Text)];
            Bitmap btmBitSave = new Bitmap(1, 1);
            string strPath = "";
            for (int y = 0; y < int.Parse(RtbCHeight.Text); y++)
            {
                for (int x = 0; x < int.Parse(RtbCWidth.Text); x++)
                {
                    OfdOpen.FileName = $"File {x + 1}, {y + 1}";
                    if (OfdOpen.ShowDialog() == DialogResult.OK)
                    {
                        bitmaps[x, y] = new Bitmap(OfdOpen.FileName.ToString());
                        if (!bolBitSaveCheak)
                        {
                            btmBitSave = new Bitmap(int.Parse(RtbCWidth.Text) * bitmaps[x, y].Width, int.Parse(RtbCHeight.Text) * bitmaps[x, y].Height);
                            bolBitSaveCheak = true;
                        }
                    }
                    for (int xx = 0; xx < bitmaps[x, y].Width; xx++)
                    {
                        for (int yy = 0; yy < bitmaps[x, y].Height; yy++)
                        {
                            btmBitSave.SetPixel(x * bitmaps[x, y].Width + xx, y * bitmaps[x, y].Height + yy, (bitmaps[x, y]).GetPixel(xx, yy));
                        }
                    }
                }
            }
            if (SfdSave.ShowDialog() == DialogResult.OK)
            {
                strPath = SfdSave.FileName.ToString();
            }
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
            btmBitSave.Save(strPath);
            btmBitSave.Dispose();
        }

        private void BtnExtraction_Click(object sender, EventArgs e)
        {
            if (!DataSaver.bolExtraction)
            {
                DataSaver.bolExtraction = true;
                DataSaver.bolPaint = false;
                DataSaver.intMirror = 0;
                BtnExtraction.BackColor = Color.Green;
                BtnPaint.BackColor = SystemColors.Control;
                BtnMIrror.BackColor = SystemColors.Control;
            }
            else
            {
                DataSaver.bolExtraction = false;
                BtnExtraction.BackColor = SystemColors.Control;
            }
        }

        private void Pencil_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.pclNow = null;
        }

        private void BtnPaint_Click(object sender, EventArgs e)
        {
            if (!DataSaver.bolPaint)
            {
                DataSaver.bolPaint = true;
                DataSaver.bolExtraction = false;
                DataSaver.intMirror = 0;
                BtnPaint.BackColor = Color.Green;
                BtnExtraction.BackColor = SystemColors.Control;
                BtnMIrror.BackColor = SystemColors.Control;
            }
            else
            {
                DataSaver.bolPaint = false;
                BtnPaint.BackColor = SystemColors.Control;
            }
        }

        private void BtnMIrror_Click(object sender, EventArgs e)
        {
            if(DataSaver.intMirror==0)
            {
                DataSaver.bolPaint = false;
                DataSaver.bolExtraction = false;
                DataSaver.intMirror = 1;
                BtnPaint.BackColor = SystemColors.Control;
                BtnExtraction.BackColor = SystemColors.Control;
                BtnMIrror.BackColor = Color.Blue;
                RtbMirror_TextChanged(sender, e);
            }
            else if (DataSaver.intMirror==1)
            {
                DataSaver.intMirror = 2;
                BtnMIrror.BackColor = Color.Red;
                RtbMirror_TextChanged(sender, e);
            }
            else
            {
                DataSaver.intMirror = 0;
                BtnMIrror.BackColor = SystemColors.Control;
                RtbMirror_TextChanged(sender, e);
            }
        }

        private void RtbMirror_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSaver.intStrMirror = int.Parse(RtbMirror.Text);
                DataSaver.g = DataSaver.bmmNow.CreateGraphics();
                DataSaver.g.Clear(DataSaver.bmmNow.BackColor);
                if (DataSaver.intMirror == 1)
                {
                    DataSaver.g.DrawLine(new Pen(Color.White),
                                         new Point(0, DataSaver.intSize * int.Parse(RtbMirror.Text) + 12),
                                         new Point(DataSaver.bmmNow.Width, DataSaver.intSize * int.Parse(RtbMirror.Text) + 12));
                }
                else if (DataSaver.intMirror == 2)
                {
                    DataSaver.g.DrawLine(new Pen(Color.White),
                                          new Point(DataSaver.intSize * int.Parse(RtbMirror.Text) + 12, 0),
                                          new Point(DataSaver.intSize * int.Parse(RtbMirror.Text) + 12, DataSaver.bmmNow.Height));
                }
            }
            catch
            {

            }
        }

        private void RtbColor_TextChanged(object sender, EventArgs e)
        {
            if (!bolColorDialog && !DataSaver.bolExtraction && !bolSaveColorClick)
            {
                BtnChoice_Click(sender, e);
            }
        }

        private void Pbx_Click(object sender, EventArgs e)
        {
            bolSaveColorClick = true;
            DataSaver.nowRGBA = new RGBA(DataSaver.saveRGBA[((PictureBox)sender).Name[3] - 48 - 1]);
            RtbR.Text = DataSaver.nowRGBA.R.ToString();
            RtbG.Text = DataSaver.nowRGBA.G.ToString();
            RtbB.Text = DataSaver.nowRGBA.B.ToString();
            RtbA.Text = DataSaver.nowRGBA.A.ToString();
            PbxColor.BackColor = DataSaver.saveRGBA[((PictureBox)sender).Name[3] - 48 - 1].ColorReturn();
            bolSaveColorClick = false;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            DataSaver.saveRGBA[((Button)sender).Name[3] - 48 - 1] = new RGBA(DataSaver.nowRGBA);
            switch(((Button)sender).Name[3] - 48 - 1)
            {
                case 0: Pbx1.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 1: Pbx2.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 2: Pbx3.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 3: Pbx4.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 4: Pbx5.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 5: Pbx6.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 6: Pbx7.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
            }
        }
    }
}
