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
                DataSaver.intHeigth = int.Parse(RtbHeight.Text);
                BitMapMain BmmForm = new BitMapMain();
                BmmForm.Show();
                Pencil pclForm = new Pencil();
                pclForm.Show();
            }
            catch
            {

            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (OfdOpen.ShowDialog() == DialogResult.OK)
            {
                LoadFile(OfdOpen.FileName.ToString());
            }
        }

        private void RtbKeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar)||e.KeyChar==Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void LoadFile(string strFileName)
        {
            Bitmap btmDrag = new Bitmap(strFileName);
            DataSaver.intWidth = btmDrag.Width;
            DataSaver.intHeigth = btmDrag.Height;
            DataSaver.btmRGBA = new RGBA[btmDrag.Width, btmDrag.Height];
            for (int x = 0; x < DataSaver.btmRGBA.GetLength(0); x++)
            {
                for (int y = 0; y < DataSaver.btmRGBA.GetLength(1); y++)
                {
                    DataSaver.btmRGBA[x, y] = new RGBA(btmDrag.GetPixel(x, y));
                }
            }
            BitMapMain BmmForm = new BitMapMain();
            BmmForm.Show();
            Pencil pclForm = new Pencil();
            pclForm.Show();
        }

        private void BtnPencil_Click(object sender, EventArgs e)
        {
            Pencil pclForm = new Pencil();
            pclForm.Show();
        }
    }
}
