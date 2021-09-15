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

        private Point pntMouse;
        private Graphics[,] grpBitMap;
        private Graphics[] grpGrid;
        private bool bolMouseDClick;
        private bool bolBorder;
        private bool bolMouseDown;

        private void BitMapMain_Load(object sender, EventArgs e)
        {
            Timer.Start();
            grpGrid = new Graphics[DataSaver.intWidth + 1 + DataSaver.intHeight + 1 + 1];
            ButtonMake(DataSaver.intWidth, DataSaver.intHeight);
            if (DataSaver.btmRGBA == null)
            {
                DataSaver.btmRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight];
                for (int x = 0; x < DataSaver.intWidth; x++)
                {
                    for (int y = 0; y < DataSaver.intHeight; y++)
                    {
                        DataSaver.btmRGBA[x, y] = new RGBA();
                    }
                }
            }
        }

        public void PbxBorder()
        {
            if (!bolBorder)
            {
                Pen pen = new Pen(Color.Green, 5);
                for (int i = 0, j = 0; i < grpGrid.Length; i++)
                {
                    grpGrid[i] = Pnl.CreateGraphics();
                    if (i <= DataSaver.intHeight + 1)
                    {
                        grpGrid[i].DrawLine(pen, new Point(0, i * DataSaver.intSize), new Point(DataSaver.intSize * grpBitMap.GetLength(1), i * DataSaver.intSize));
                    }
                    else
                    {
                        grpGrid[i].DrawLine(pen, new Point(j * DataSaver.intSize, 0), new Point(j * DataSaver.intSize, DataSaver.intSize * grpBitMap.GetLength(0)));
                        j++;
                    }
                }
                bolBorder = true;
            }
            else
            {
                for (int i = 0; i < grpGrid.Length; i++)
                {
                    grpGrid[i].Clear(Pnl.BackColor);
                }
                bolBorder = false;
                for (int y = 0; y < grpBitMap.GetLength(1); y++)
                {
                    for (int x = 0; x < grpBitMap.GetLength(0); x++)
                    {
                        Rectangle rect = new Rectangle(x * DataSaver.intSize, y * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
                        Brush pen = new SolidBrush(DataSaver.btmRGBA[x, y].ColorReturn());
                        grpBitMap[x, y].FillRectangle(pen, rect);
                    }
                }
            }
        }

        private void ButtonMake(int intWidth, int intHeight)
        {
            grpBitMap = new Graphics[intWidth, intHeight];
            int intControlWidth = Pnl.Width / grpBitMap.GetLength(0);
            int intControlHeight = Pnl.Height / grpBitMap.GetLength(1);
            int intSize = Math.Min(intControlWidth, intControlHeight);
            DataSaver.intSize = intSize;
            for (int y = 0; y < grpBitMap.GetLength(1); y++)
            {
                for (int x = 0; x < grpBitMap.GetLength(0); x++)
                {
                    grpBitMap[x, y] = Pnl.CreateGraphics();
                    Rectangle rect = new Rectangle(x * intSize, y * intSize, intSize, intSize);
                    Brush pen = new SolidBrush(Color.White);
                    grpBitMap[x, y].FillRectangle(pen, rect);
                }
            }
        }

        private void MouseDClick(object sender, EventArgs e)
        {
            if (!bolMouseDClick)
            {
                bolMouseDClick = true;
            }
            else
            {
                bolMouseDClick = false;
            }
        }

        private void PaintTool(int x, int y, RGBA nowRGBA)
        {
            DataSaver.btmRGBA[x, y] = new RGBA(DataSaver.nowRGBA);
            DataSaver.btmRGBA[x, y] = new RGBA(DataSaver.nowRGBA);
            Rectangle rect = new Rectangle(x * DataSaver.intSize, y * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
            Brush pen = new SolidBrush(DataSaver.btmRGBA[x, y].ColorReturn());
            grpBitMap[x, y].FillRectangle(pen, rect);
            for (int j = 0; j < 4; j++)
            {
                if (y < DataSaver.btmRGBA.GetLength(1) - 1)
                {
                    if (DataSaver.btmRGBA[x, y + 1] == nowRGBA || (DataSaver.btmRGBA[x, y + 1].A == 0 && nowRGBA.A == 0))
                    {
                        PaintTool(x, y + 1, nowRGBA);
                    }
                }
                if (y >= 1)
                {
                    if (DataSaver.btmRGBA[x, y - 1] == nowRGBA || (DataSaver.btmRGBA[x, y - 1].A == 0 && nowRGBA.A == 0))
                    {
                        PaintTool(x, y - 1, nowRGBA);
                    }
                }
                if (x < DataSaver.btmRGBA.GetLength(0) - 1)
                {
                    if (DataSaver.btmRGBA[x + 1, y] == nowRGBA || (DataSaver.btmRGBA[x + 1, y].A == 0 && nowRGBA.A == 0))
                    {
                        PaintTool(x + 1, y, nowRGBA);
                    }
                }
                if (x >= 1)
                {
                    if (DataSaver.btmRGBA[x - 1, y] == nowRGBA || (DataSaver.btmRGBA[x - 1, y].A == 0 && nowRGBA.A == 0))
                    {
                        PaintTool(x - 1, y, nowRGBA);
                    }
                }
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            try
            {
                int intPointX = pntMouse.X / DataSaver.intSize, intPointY = pntMouse.Y / DataSaver.intSize;
                if (DataSaver.bolExtraction)
                {
                    DataSaver.nowRGBA = new RGBA(DataSaver.btmRGBA[intPointX, intPointY]);
                    DataSaver.pclNow.PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
                    DataSaver.pclNow.RtbR.Text = DataSaver.nowRGBA.R.ToString();
                    DataSaver.pclNow.RtbG.Text = DataSaver.nowRGBA.G.ToString();
                    DataSaver.pclNow.RtbB.Text = DataSaver.nowRGBA.B.ToString();
                    DataSaver.pclNow.RtbA.Text = DataSaver.nowRGBA.A.ToString();
                }
                else if (DataSaver.bolPaint)
                {
                    if (DataSaver.btmRGBA[intPointX, intPointY] != DataSaver.nowRGBA)
                    {
                        RGBA nowRGBA = DataSaver.btmRGBA[intPointX, intPointY];
                        PaintTool(intPointX, intPointY, nowRGBA);
                    }
                }
                else if (DataSaver.intMirror == 1)
                {
                    DataSaver.btmRGBA[intPointX, intPointY] = new RGBA(DataSaver.nowRGBA);
                    Rectangle rect = new Rectangle(intPointX * DataSaver.intSize, intPointY * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
                    Brush pen = new SolidBrush(DataSaver.btmRGBA[intPointX, intPointY].ColorReturn());
                    grpBitMap[intPointX, intPointY].FillRectangle(pen, rect);
                    int intNewY = (int)((DataSaver.intStrMirror - 0.5m) * 2) - intPointY;
                    if (intNewY >= 0 && intNewY < DataSaver.intHeight)
                    {
                        DataSaver.btmRGBA[intPointX, intNewY] = new RGBA(DataSaver.nowRGBA);
                        Rectangle rectM = new Rectangle(intPointX * DataSaver.intSize, intNewY * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
                        Brush penM = new SolidBrush(DataSaver.btmRGBA[intPointX, intNewY].ColorReturn());
                        grpBitMap[intPointX, intNewY].FillRectangle(penM, rectM);
                    }

                }
                else if (DataSaver.intMirror == 2)
                {
                    DataSaver.btmRGBA[intPointX, intPointY] = new RGBA(DataSaver.nowRGBA);
                    Rectangle rect = new Rectangle(intPointX * DataSaver.intSize, intPointY * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
                    Brush pen = new SolidBrush(DataSaver.btmRGBA[intPointX, intPointY].ColorReturn());
                    grpBitMap[intPointX, intPointY].FillRectangle(pen, rect);
                    int intNewX = (int)((DataSaver.intStrMirror - 0.5m) * 2) - intPointX;
                    if (intNewX >= 0 && intNewX < DataSaver.intWidth)
                    {
                        DataSaver.btmRGBA[intNewX, intPointY] = new RGBA(DataSaver.nowRGBA);
                        Rectangle rectM = new Rectangle(intNewX * DataSaver.intSize, intPointY * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
                        Brush penM = new SolidBrush(DataSaver.btmRGBA[intNewX, intPointY].ColorReturn());
                        grpBitMap[intNewX, intPointY].FillRectangle(penM, rectM);
                    }
                }
                else
                {
                    DataSaver.btmRGBA[intPointX, intPointY] = new RGBA(DataSaver.nowRGBA);
                    Rectangle rect = new Rectangle(intPointX * DataSaver.intSize, intPointY * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
                    Brush pen = new SolidBrush(DataSaver.btmRGBA[intPointX, intPointY].ColorReturn());
                    grpBitMap[intPointX, intPointY].FillRectangle(pen, rect);
                }
                if (bolBorder)
                {
                    Pen pen = new Pen(Color.Green, 5);
                    for (int i = 0, j = 0; i < grpGrid.Length; i++)
                    {
                        grpGrid[i] = Pnl.CreateGraphics();
                        if (i <= DataSaver.intHeight + 1)
                        {
                            grpGrid[i].DrawLine(pen, new Point(0, i * DataSaver.intSize), new Point(DataSaver.intSize * grpBitMap.GetLength(1), i * DataSaver.intSize));
                        }
                        else
                        {
                            grpGrid[i].DrawLine(pen, new Point(j * DataSaver.intSize, 0), new Point(j * DataSaver.intSize, DataSaver.intSize * grpBitMap.GetLength(0)));
                            j++;
                        }
                    }
                    bolBorder = true;
                }
            }
            catch
            {

            }
        }

        private void BitMapMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.bmmNow = null;
        }

        private void BitMapMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit Now?", "Wait!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pntMouse = Pnl.PointToClient(new Point(MousePosition.X, MousePosition.Y));
        }

        private void Pnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (bolMouseDClick || bolMouseDown)
            {
                BtnClick(sender, e);
            }
        }

        private void Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            bolMouseDown = true;
        }

        private void Pnl_MouseUp(object sender, MouseEventArgs e)
        {
            bolMouseDown = false;
        }
    }
}