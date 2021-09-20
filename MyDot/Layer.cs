using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dotpia
{
    public partial class Layer : Form
    {
        public Layer()
        {
            InitializeComponent();
        }

        private bool bolUDClick = false;

        private void Layer_Load(object sender, EventArgs e)
        {
            this.Location = new Point(DataSaver.bmmNow.Location.X + DataSaver.bmmNow.Width, DataSaver.pclNow.Location.Y + DataSaver.pclNow.Height);
            if (DataSaver.intLayerTP[0] != 100)
            {
                Rtb0.Text = DataSaver.intLayerTP[0].ToString();
            }
            if (DataSaver.intLayerTP[1] != 100)
            {
                Rtb1.Text = DataSaver.intLayerTP[1].ToString();
            }
            if (DataSaver.intLayerTP[2] != 100)
            {
                Rtb2.Text = DataSaver.intLayerTP[2].ToString();
            }
            if (DataSaver.intLayerTP[3] != 100)
            {
                Rtb3.Text = DataSaver.intLayerTP[3].ToString();
            }
            if (DataSaver.intLayerTP[4] != 100)
            {
                Rtb4.Text = DataSaver.intLayerTP[4].ToString();
            }
        }

        private void Layer_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.lyeNow = null;
        }

        private void Cbx_CheckedChanged(object sender, EventArgs e)
        {
            DataSaver.bmmNow.intNowLayer = int.Parse($"{((RadioButton)sender).Name[3]}");
        }

        private void Rtb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!bolUDClick)
                {
                    DataSaver.intLayerTP[int.Parse($"{ ((RichTextBox)sender).Name[3]}")] = int.Parse(((RichTextBox)sender).Text);
                    DataSaver.bmmNow.ReDrawing();
                }
            }
            catch
            {

            }
        }

        private void RtbKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void BtnUD_Click(object sender, EventArgs e)
        {
            bolUDClick = true;
            RGBA[,] uRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight];
            RGBA[,] dRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight];
            switch (((Button)sender).Name[3])
            {
                case 'U':
                    {
                        switch (((Button)sender).Name[4])
                        {
                            case '0':
                                {
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            uRGBA[x, y] = DataSaver.btmRGBA[x, y, 0];
                                            dRGBA[x, y] = DataSaver.btmRGBA[x, y, 1];
                                        }
                                    }
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            DataSaver.btmRGBA[x, y, 0] = dRGBA[x, y];
                                            DataSaver.btmRGBA[x, y, 1] = uRGBA[x, y];
                                        }
                                    }
                                    int temp = DataSaver.intLayerTP[0];
                                    DataSaver.intLayerTP[0] = DataSaver.intLayerTP[1];
                                    DataSaver.intLayerTP[1] = temp;
                                }
                                break;
                            case '1':
                                {
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            uRGBA[x, y] = DataSaver.btmRGBA[x, y, 1];
                                            dRGBA[x, y] = DataSaver.btmRGBA[x, y, 2];
                                        }
                                    }
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            DataSaver.btmRGBA[x, y, 1] = dRGBA[x, y];
                                            DataSaver.btmRGBA[x, y, 2] = uRGBA[x, y];
                                        }
                                    }
                                    int temp = DataSaver.intLayerTP[1];
                                    DataSaver.intLayerTP[1] = DataSaver.intLayerTP[2];
                                    DataSaver.intLayerTP[2] = temp;
                                }
                                break;
                            case '2':
                                {
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            uRGBA[x, y] = DataSaver.btmRGBA[x, y, 2];
                                            dRGBA[x, y] = DataSaver.btmRGBA[x, y, 3];
                                        }
                                    }
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            DataSaver.btmRGBA[x, y, 2] = dRGBA[x, y];
                                            DataSaver.btmRGBA[x, y, 3] = uRGBA[x, y];
                                        }
                                    }
                                    int temp = DataSaver.intLayerTP[2];
                                    DataSaver.intLayerTP[2] = DataSaver.intLayerTP[3];
                                    DataSaver.intLayerTP[3] = temp;
                                }
                                break;
                            case '3':
                                {
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            uRGBA[x, y] = DataSaver.btmRGBA[x, y, 3];
                                            dRGBA[x, y] = DataSaver.btmRGBA[x, y, 4];
                                        }
                                    }
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            DataSaver.btmRGBA[x, y, 3] = dRGBA[x, y];
                                            DataSaver.btmRGBA[x, y, 4] = uRGBA[x, y];
                                        }
                                    }
                                    int temp = DataSaver.intLayerTP[3];
                                    DataSaver.intLayerTP[3] = DataSaver.intLayerTP[4];
                                    DataSaver.intLayerTP[4] = temp;
                                }
                                break;
                        }
                    }
                    break;
                case 'D':
                    {
                        switch (((Button)sender).Name[4])
                        {
                            case '1':
                                {
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            uRGBA[x, y] = DataSaver.btmRGBA[x, y, 0];
                                            dRGBA[x, y] = DataSaver.btmRGBA[x, y, 1];
                                        }
                                    }
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            DataSaver.btmRGBA[x, y, 0] = dRGBA[x, y];
                                            DataSaver.btmRGBA[x, y, 1] = uRGBA[x, y];
                                        }
                                    }
                                    int temp = DataSaver.intLayerTP[0];
                                    DataSaver.intLayerTP[0] = DataSaver.intLayerTP[1];
                                    DataSaver.intLayerTP[1] = temp;
                                }
                                break;
                            case '2':
                                {
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            uRGBA[x, y] = DataSaver.btmRGBA[x, y, 1];
                                            dRGBA[x, y] = DataSaver.btmRGBA[x, y, 2];
                                        }
                                    }
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            DataSaver.btmRGBA[x, y, 1] = dRGBA[x, y];
                                            DataSaver.btmRGBA[x, y, 2] = uRGBA[x, y];
                                        }
                                    }
                                    int temp = DataSaver.intLayerTP[1];
                                    DataSaver.intLayerTP[1] = DataSaver.intLayerTP[2];
                                    DataSaver.intLayerTP[2] = temp;
                                }
                                break;
                            case '3':
                                {
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            uRGBA[x, y] = DataSaver.btmRGBA[x, y, 2];
                                            dRGBA[x, y] = DataSaver.btmRGBA[x, y, 3];
                                        }
                                    }
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            DataSaver.btmRGBA[x, y, 2] = dRGBA[x, y];
                                            DataSaver.btmRGBA[x, y, 3] = uRGBA[x, y];
                                        }
                                    }
                                    int temp = DataSaver.intLayerTP[2];
                                    DataSaver.intLayerTP[2] = DataSaver.intLayerTP[3];
                                    DataSaver.intLayerTP[3] = temp;
                                }
                                break;
                            case '4':
                                {
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            uRGBA[x, y] = DataSaver.btmRGBA[x, y, 3];
                                            dRGBA[x, y] = DataSaver.btmRGBA[x, y, 4];
                                        }
                                    }
                                    for (int x = 0; x < DataSaver.intWidth; x++)
                                    {
                                        for (int y = 0; y < DataSaver.intHeight; y++)
                                        {
                                            DataSaver.btmRGBA[x, y, 3] = dRGBA[x, y];
                                            DataSaver.btmRGBA[x, y, 4] = uRGBA[x, y];
                                        }
                                    }
                                    int temp = DataSaver.intLayerTP[3];
                                    DataSaver.intLayerTP[3] = DataSaver.intLayerTP[4];
                                    DataSaver.intLayerTP[4] = temp;
                                }
                                break;
                        }
                    }
                    break;
            }
            Rtb0.Text = DataSaver.intLayerTP[0].ToString();
            Rtb1.Text = DataSaver.intLayerTP[1].ToString();
            Rtb2.Text = DataSaver.intLayerTP[2].ToString();
            Rtb3.Text = DataSaver.intLayerTP[3].ToString();
            Rtb4.Text = DataSaver.intLayerTP[4].ToString();
            DataSaver.bmmNow.ReDrawing();
            bolUDClick = false;
        }
    }
}