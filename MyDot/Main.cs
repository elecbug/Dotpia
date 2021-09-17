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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DataSaver.intWidth = int.Parse(RtbWidth.Text);
                DataSaver.intHeight = int.Parse(RtbHeight.Text);
                if (DataSaver.bmmNow == null)
                {
                    BitMapMain BmmForm = new BitMapMain();
                    DataSaver.bmmNow = BmmForm;
                    BmmForm.Show();

                }
                if (DataSaver.pclNow == null)
                {
                    Pencil pclForm = new Pencil();
                    DataSaver.pclNow = pclForm;
                    pclForm.Show();
                }
            }
            catch
            {

            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (OfdOpen.ShowDialog() == DialogResult.OK)
            {
                string strPath = OfdOpen.FileName.ToString();
                Bitmap btmFile = new Bitmap(strPath);
                DataSaver.intWidth = btmFile.Width;
                DataSaver.intHeight = btmFile.Height;
                DataSaver.btmRGBA = new RGBA[btmFile.Width, btmFile.Height, DataSaver.HIGH_RAYER];
                for (int x = 0; x < DataSaver.btmRGBA.GetLength(0); x++)
                {
                    for (int y = 0; y < DataSaver.btmRGBA.GetLength(1); y++)
                    {
                        DataSaver.btmRGBA[x, y, 0] = new RGBA(btmFile.GetPixel(x, y));
                    }
                }
                for (int r = 1; r < DataSaver.HIGH_RAYER; r++)
                {
                    for (int x = 0; x < DataSaver.btmRGBA.GetLength(0); x++)
                    {
                        for (int y = 0; y < DataSaver.btmRGBA.GetLength(1); y++)
                        {
                            DataSaver.btmRGBA[x, y, r] = new RGBA();
                        }
                    }
                }
                if (DataSaver.bmmNow == null)
                {
                    BitMapMain BmmForm = new BitMapMain();
                    DataSaver.bmmNow = BmmForm;
                    BmmForm.Show();
                }
                if (DataSaver.pclNow == null)
                {
                    Pencil pclForm = new Pencil();
                    DataSaver.pclNow = pclForm;
                    pclForm.Show();
                }
            }
        }

        private void RtbKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void BtnPencil_Click(object sender, EventArgs e)
        {
            if (DataSaver.pclNow == null)
            {
                Pencil pclForm = new Pencil();
                DataSaver.pclNow = pclForm;
                pclForm.Show();
            }
        }

        private void Main_HelpButtonClicked(object sender, EventArgs e)
        {
            new Helper().Show();
        }

        private void BtnNewLoad_Click(object sender, EventArgs e)
        {
            if (OfdNewOpen.ShowDialog() == DialogResult.OK)
            {
                string strValue = File.ReadAllText(OfdNewOpen.FileName.ToString());
                int intWidth = int.Parse(strValue[0].ToString() + strValue[1].ToString() + strValue[2].ToString() + strValue[3].ToString());
                int intHeight = int.Parse(strValue[4].ToString() + strValue[5].ToString() + strValue[6].ToString() + strValue[7].ToString());
                int intRayer = int.Parse(strValue[8].ToString());
                DataSaver.intRayerTP = new int[DataSaver.HIGH_RAYER];
                for (int r = 0; r < DataSaver.HIGH_RAYER; r++)
                {
                    DataSaver.intRayerTP[r] = int.Parse(strValue[r * 3 + 9].ToString() + strValue[r * 3 + 10].ToString() + strValue[r * 3 + 11].ToString());
                }
                DataSaver.intWidth = intWidth;
                DataSaver.intHeight = intHeight;
                int intReader = 24;
                DataSaver.btmRGBA = new RGBA[intWidth, intHeight, intRayer];
                for (int r = 0; r < intRayer; r++)
                {
                    for (int y = 0; y < intHeight; y++)
                    {
                        for (int x = 0; x < intWidth; x++)
                        {
                            int R = int.Parse(strValue[intReader].ToString() + strValue[intReader + 1].ToString() + strValue[intReader + 2].ToString());
                            intReader += 3;
                            int G = int.Parse(strValue[intReader].ToString() + strValue[intReader + 1].ToString() + strValue[intReader + 2].ToString());
                            intReader += 3;
                            int B = int.Parse(strValue[intReader].ToString() + strValue[intReader + 1].ToString() + strValue[intReader + 2].ToString());
                            intReader += 3;
                            int A = int.Parse(strValue[intReader].ToString() + strValue[intReader + 1].ToString() + strValue[intReader + 2].ToString());
                            intReader += 3;
                            DataSaver.btmRGBA[x, y, r] = new RGBA(R, G, B, A);
                        }
                    }
                }
                if (DataSaver.bmmNow == null)
                {
                    BitMapMain BmmForm = new BitMapMain();
                    DataSaver.bmmNow = BmmForm;
                    BmmForm.Show();
                }
                if (DataSaver.pclNow == null)
                {
                    Pencil pclForm = new Pencil();
                    DataSaver.pclNow = pclForm;
                    pclForm.Show();
                }
            }
        }
    }
}
