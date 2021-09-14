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
    public partial class BitMapMain : Form
    {
        public BitMapMain()
        {
            InitializeComponent();
        }

        public PictureBox[,] PbxButtons;
        private bool bolMouseDown;
        private bool bolBorder;

        private void BitMapMain_Load(object sender, EventArgs e)
        {
            ButtonMake(DataSaver.intWidth, DataSaver.intHeigth);
            if (DataSaver.btmRGBA == null)
            {
                DataSaver.btmRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeigth];
                for (int x = 0; x < DataSaver.intWidth; x++)
                {
                    for (int y = 0; y < DataSaver.intHeigth; y++)
                    {
                        DataSaver.btmRGBA[x, y] = new RGBA();
                    }
                }
            }
            for (int x = 0; x < DataSaver.intWidth; x++)
            {
                for (int y = 0; y < DataSaver.intHeigth; y++)
                {
                    PbxButtons[x, y].BackColor = DataSaver.btmRGBA[x, y].ColorReturn();
                }
            }
        }

        public void PbxBorder()
        {
            if (!bolBorder)
            {
                for (int y = 0; y < PbxButtons.GetLength(1); y++)
                {
                    for (int x = 0; x < PbxButtons.GetLength(0); x++)
                    {
                        PbxButtons[x, y].BorderStyle = BorderStyle.FixedSingle;
                    }
                }
                bolBorder = true;
            }
            else
            {
                for (int y = 0; y < PbxButtons.GetLength(1); y++)
                {
                    for (int x = 0; x < PbxButtons.GetLength(0); x++)
                    {
                        PbxButtons[x, y].BorderStyle = BorderStyle.None;
                    }
                }
                bolBorder = false;
            }
        }

        private void ButtonMake(int intWidth, int intHeight)
        {
            PbxButtons = new PictureBox[intHeight, intWidth];
            int intControlWidth = 800 / PbxButtons.GetLength(0);
            int intControlHeight = 800 / PbxButtons.GetLength(1);
            for (int y = 0; y < PbxButtons.GetLength(1); y++)
            {
                for (int x = 0; x < PbxButtons.GetLength(0); x++)
                {
                    PbxButtons[x, y] = new PictureBox
                    {
                        Name = $"Pbx{x.ToString("D5")}{y.ToString("D5")}",
                        Size = new Size(intControlWidth, intControlHeight),
                        Parent = this,
                        Location = new Point(x * intControlWidth, y * intControlHeight),
                        Text = "",
                    };
                    PbxButtons[x, y].Click += new EventHandler(BtnClick);
                    PbxButtons[x, y].MouseDown += new MouseEventHandler(BitMapMain_MouseDown);
                    PbxButtons[x, y].MouseEnter += new EventHandler(MouseInside);
                    PbxButtons[x, y].MouseUp += new MouseEventHandler(BitMapMain_MouseUp);
                    this.Controls.Add(PbxButtons[x, y]);
                }
            }
        }

        private void MouseInside(object sender, EventArgs e)
        {
            if (bolMouseDown)
            {
                BtnClick(sender,e);
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            string strName = ((PictureBox)sender).Name;
            int intWidthCode = int.Parse($"{strName[3]}{strName[4]}{strName[5]}{strName[6]}{strName[7]}");
            int intHeightCode = int.Parse($"{strName[8]}{strName[9]}{strName[10]}{strName[11]}{strName[12]}");
            ((PictureBox)sender).BackColor = DataSaver.nowRGBA.ColorReturn();
            DataSaver.btmRGBA[intWidthCode, intHeightCode] = DataSaver.nowRGBA;
        }

        private void BitMapMain_MouseDown(object sender, MouseEventArgs e)
        {
            bolMouseDown = true;
        }

        private void BitMapMain_MouseUp(object sender, MouseEventArgs e)
        {
            bolMouseDown = false;
        }

        private void BitMapMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.bmmNow = null;
        }
    }
}
