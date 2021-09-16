using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if(!Char.IsDigit(e.KeyChar)||e.KeyChar==Convert.ToChar(Keys.Back))
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
    }
}
