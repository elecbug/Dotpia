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

        private void Pencil_Load(object sender, EventArgs e)
        {
            DataSaver.pclNow = this;
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
            Bitmap bitmap = new Bitmap(DataSaver.intWidth, DataSaver.intHeigth);
            for (int x = 0; x < DataSaver.intWidth; x++)
            {
                for (int y = 0; y < DataSaver.intHeigth; y++)
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

            if (CldColor.ShowDialog() == DialogResult.OK)
            {
                DataSaver.nowRGBA = new RGBA(CldColor.Color);
                PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
                RtbR.Text = DataSaver.nowRGBA.R.ToString();
                RtbG.Text = DataSaver.nowRGBA.G.ToString();
                RtbB.Text = DataSaver.nowRGBA.B.ToString();
                RtbA.Text = DataSaver.nowRGBA.A.ToString();
            }
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
                    Bitmap bitmap = new Bitmap(DataSaver.intWidth * intExport, DataSaver.intHeigth * intExport);
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
            DataSaver.bolExtractionMod = true;
        }

        private void Pencil_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.pclNow = null;
        }
    }
}
