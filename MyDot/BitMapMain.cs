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

        private const double ZOOM_FACTOR = 1.1;
        private const int MIN_MAX = 5;

        public Button[,] BtnButtons;

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
                    BtnButtons[x, y].BackColor = DataSaver.btmRGBA[x, y].ColorReturn();
                }
            }
        }

        private void ButtonMake(int intWidth, int intHeight)
        {
            BtnButtons = new Button[intHeight, intWidth];
            int intControlWidth = 800 / BtnButtons.GetLength(0);
            int intControlHeight = 800 / BtnButtons.GetLength(1);
            for (int y = 0; y < BtnButtons.GetLength(1); y++)
            {
                for (int x = 0; x < BtnButtons.GetLength(0); x++)
                {
                    BtnButtons[x, y] = new Button
                    {
                        Name = $"Btn{x.ToString("D5")}{y.ToString("D5")}",
                        Size = new Size(intControlWidth, intControlHeight),
                        Parent = this,
                        Location = new Point(x * intControlWidth, y * intControlHeight),
                        Text = "",
                    };
                    BtnButtons[x, y].Click += new EventHandler(BtnClick);
                    this.Controls.Add(BtnButtons[x, y]);
                }
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            string strName = ((Button)sender).Name;
            int intWidthCode = int.Parse($"{strName[3]}{strName[4]}{strName[5]}{strName[6]}{strName[7]}");
            int intHeightCode = int.Parse($"{strName[8]}{strName[9]}{strName[10]}{strName[11]}{strName[12]}");
            ((Button)sender).BackColor = DataSaver.nowRGBA.ColorReturn();
            DataSaver.btmRGBA[intWidthCode, intHeightCode] = DataSaver.nowRGBA;
        }
    }
}
