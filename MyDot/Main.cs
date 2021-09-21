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

namespace Dotpia
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

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
                    Pencil pclForm = new Pencil();
                    DataSaver.pclNow = pclForm;
                    pclForm.Show();
                    Layer lyeForm = new Layer();
                    DataSaver.lyeNow = lyeForm;
                    lyeForm.Show();
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
                    Pencil pclForm = new Pencil();
                    DataSaver.pclNow = pclForm;
                    pclForm.Show();
                    Layer lyeForm = new Layer();
                    DataSaver.lyeNow = lyeForm;
                    lyeForm.Show();
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
            int intMagicNum = "WTD".Length;
            if (OfdNewOpen.ShowDialog() == DialogResult.OK)
            {
                string strValue = File.ReadAllText(OfdNewOpen.FileName.ToString());
                for (int i = 0; i < "WTD".Length; i++)
                {
                    if (strValue[i] != "WTD"[i])
                    {
                        return;
                    }
                }
                int intWidth = int.Parse(strValue[0 + intMagicNum].ToString() + strValue[1 + intMagicNum].ToString() + strValue[2 + intMagicNum].ToString() + strValue[3 + intMagicNum].ToString());
                int intHeight = int.Parse(strValue[4 + intMagicNum].ToString() + strValue[5 + intMagicNum].ToString() + strValue[6 + intMagicNum].ToString() + strValue[7 + intMagicNum].ToString());
                int intLayer = int.Parse(strValue[8 + intMagicNum].ToString());
                DataSaver.intLayerTP = new int[DataSaver.HIGH_RAYER];
                for (int r = 0; r < DataSaver.HIGH_RAYER; r++)
                {
                    DataSaver.intLayerTP[r] = int.Parse(strValue[r * 3 + 9 + intMagicNum].ToString() + strValue[r * 3 + 10 + intMagicNum].ToString() + strValue[r * 3 + 11 + intMagicNum].ToString());
                }
                DataSaver.intWidth = intWidth;
                DataSaver.intHeight = intHeight;
                int intReader = 24 + 1 + intMagicNum;
                DataSaver.btmRGBA = new RGBA[intWidth, intHeight, intLayer];
                for (int r = 0; r < intLayer; r++)
                {
                    for (int y = 0; y < intHeight; y++)
                    {
                        for (int x = 0; x < intWidth; x++)
                        {
                            int intNum = 0;
                            if (strValue[intReader] == '|')
                            {
                                string strNum = "";
                                for (intReader++; strValue[intReader] != ':'; intReader++)
                                {
                                    strNum += strValue[intReader];
                                }
                                intNum = int.Parse(strNum);
                                intReader++;
                            }
                            int R = Int32.Parse(strValue[intReader].ToString() + strValue[intReader + 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                            int G = Int32.Parse(strValue[intReader + 2].ToString() + strValue[intReader + 3].ToString(), System.Globalization.NumberStyles.HexNumber);
                            int B = Int32.Parse(strValue[intReader + 4].ToString() + strValue[intReader + 5].ToString(), System.Globalization.NumberStyles.HexNumber);
                            int A = Int32.Parse(strValue[intReader + 6].ToString() + strValue[intReader + 7].ToString(), System.Globalization.NumberStyles.HexNumber);
                            for (int i = 0; i < intNum; i++)
                            {
                                DataSaver.btmRGBA[x, y, r] = new RGBA(R, G, B, A);
                                x++;
                                if (x == intWidth)
                                {
                                    x = 0;
                                    y++;
                                }
                                if (y == intHeight)
                                {
                                    y = 0;
                                    r++;
                                }
                            }
                            if (r == intLayer)
                            {
                                r = intLayer - 1;
                                y = intHeight - 1;
                                x = intWidth - 1;
                            }
                            else
                            {
                                x--;
                                if (x == -1)
                                {
                                    x = intWidth - 1;
                                    y--;
                                }
                                if (y == -1)
                                {
                                    y = intHeight - 1;
                                    r--;
                                }
                            }
                            intReader += 8;
                        }
                    }
                }
                if (DataSaver.bmmNow == null)
                {
                    BitMapMain BmmForm = new BitMapMain();
                    DataSaver.bmmNow = BmmForm;
                    BmmForm.Show();
                    Pencil pclForm = new Pencil();
                    DataSaver.pclNow = pclForm;
                    pclForm.Show();
                    Layer lyeForm = new Layer();
                    DataSaver.lyeNow = lyeForm;
                    lyeForm.Show();
                }
            }
        }
    }
}
