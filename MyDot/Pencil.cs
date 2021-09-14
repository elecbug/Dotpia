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
                DataSaver.nowRGBA = new RGBA(int.Parse(PbxR.Text), int.Parse(PbxG.Text), int.Parse(PbxB.Text), int.Parse(PbxA.Text));
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
                PbxR.Text = DataSaver.nowRGBA.R.ToString();
                PbxG.Text = DataSaver.nowRGBA.G.ToString();
                PbxB.Text = DataSaver.nowRGBA.B.ToString();
                PbxA.Text = DataSaver.nowRGBA.A.ToString();
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
    }
}
