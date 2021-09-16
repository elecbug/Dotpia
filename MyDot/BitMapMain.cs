﻿using System;
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
        public Graphics[,] grpBitMap;
        private Graphics[] grpGrid;
        private bool bolMouseDClick;
        private bool bolBorder;
        private bool bolMouseDown;
        private int intTimer = 0;
        public int intNowRayer = 0;

        private void BitMapMain_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < DataSaver.HIGH_RAYER; i++)
                {
                    DataSaver.intRayerTP[i] = 100;
                }
                Pnl.MouseWheel += new MouseEventHandler(Mouse_Wheel);
                Timer.Start();
                grpGrid = new Graphics[DataSaver.intWidth + 1 + DataSaver.intHeight + 1 + 1];
                grpBitMap = new Graphics[DataSaver.intWidth, DataSaver.intHeight];
                int intControlWidth = Pnl.Width / grpBitMap.GetLength(0);
                int intControlHeight = Pnl.Height / grpBitMap.GetLength(1);
                int intSize = Math.Min(intControlWidth, intControlHeight);
                Pnl.Width = intSize *DataSaver. intWidth;
                Pnl.Height = intSize *DataSaver. intHeight;
                DataSaver.intSize = intSize;
                for (int y = 0; y < grpBitMap.GetLength(1); y++)
                {
                    for (int x = 0; x < grpBitMap.GetLength(0); x++)
                    {
                        grpBitMap[x, y] = Pnl.CreateGraphics();
                    }
                }
                if (DataSaver.btmRGBA == null)
                {
                    DataSaver.btmRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight, DataSaver.HIGH_RAYER];
                    for (int r = 0; r < DataSaver.HIGH_RAYER; r++)
                    {
                        for (int x = 0; x < DataSaver.intWidth; x++)
                        {
                            for (int y = 0; y < DataSaver.intHeight; y++)
                            {
                                DataSaver.btmRGBA[x, y, r] = new RGBA();
                            }
                        }
                    }
                }
                ReDrawing();
            }
            catch
            {

            }
        }

        private void Mouse_Wheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                Point pntNow = Pnl.Location;
                pntNow.X -= pntMouse.X;
                pntNow.Y -= pntMouse.Y;
                Pnl.Location = pntNow;
                Pnl.Width *= 2;
                Pnl.Height *= 2;
                DataSaver.intSize *= 2;
            }
            if (e.Delta < 0)
            {
                Point pntNow = Pnl.Location;
                pntNow.X += pntMouse.X / 2;
                pntNow.Y += pntMouse.Y / 2;
                Pnl.Location = pntNow;
                Pnl.Width /= 2;
                Pnl.Height /= 2;
                DataSaver.intSize /= 2;
            }
            ReDrawing();
        }

        public void ZoomReset()
        {
            Pnl.Location = new Point(12, 12);
            Pnl.Width = 800;
            Pnl.Height = 600;
            DataSaver.intSize = Math.Min(Pnl.Width / grpBitMap.GetLength(0), Pnl.Height / grpBitMap.GetLength(1));
            Pnl.Width = DataSaver.intSize * DataSaver.intWidth;
            Pnl.Height = DataSaver.intSize * DataSaver.intHeight;
            ReDrawing();
        }

        public void ReDrawing()
        {
            for (int y = 0; y < grpBitMap.GetLength(1); y++)
            {
                for (int x = 0; x < grpBitMap.GetLength(0); x++)
                {
                    grpBitMap[x, y].Clear(Pnl.BackColor);
                    grpBitMap[x, y] = Pnl.CreateGraphics();
                }
            }
            SeeBitSet();
            if (bolBorder)
            {
                Pen pen = new Pen(Color.Green, 1);
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
            }
        }

        public void PbxBorder()
        {
            if (!bolBorder)
            {
                Pen pen = new Pen(Color.Green, 1);
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
                ReDrawing();
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
            DataSaver.btmRGBA[x, y, intNowRayer] = new RGBA(DataSaver.nowRGBA);
            for (int j = 0; j < 4; j++)
            {
                if (y < DataSaver.btmRGBA.GetLength(1) - 1)
                {
                    if (DataSaver.btmRGBA[x, y + 1, intNowRayer] == nowRGBA || (DataSaver.btmRGBA[x, y + 1, intNowRayer].A == 0 && nowRGBA.A == 0))
                    {
                        PaintTool(x, y + 1, nowRGBA);
                    }
                }
                if (y >= 1)
                {
                    if (DataSaver.btmRGBA[x, y - 1, intNowRayer] == nowRGBA || (DataSaver.btmRGBA[x, y - 1, intNowRayer].A == 0 && nowRGBA.A == 0))
                    {
                        PaintTool(x, y - 1, nowRGBA);
                    }
                }
                if (x < DataSaver.btmRGBA.GetLength(0) - 1)
                {
                    if (DataSaver.btmRGBA[x + 1, y, intNowRayer] == nowRGBA || (DataSaver.btmRGBA[x + 1, y, intNowRayer].A == 0 && nowRGBA.A == 0))
                    {
                        PaintTool(x + 1, y, nowRGBA);
                    }
                }
                if (x >= 1)
                {
                    if (DataSaver.btmRGBA[x - 1, y, intNowRayer] == nowRGBA || (DataSaver.btmRGBA[x - 1, y, intNowRayer].A == 0 && nowRGBA.A == 0))
                    {
                        PaintTool(x - 1, y, nowRGBA);
                    }
                }
            }
        }

        private void PartedReDrawing(int x, int y)
        {
            Rectangle rect = new Rectangle(x * DataSaver.intSize, y * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
            Brush brush = new SolidBrush(Pnl.BackColor);
            grpBitMap[x, y].FillRectangle(brush, rect);
            for (int r = 0; r < DataSaver.HIGH_RAYER; r++)
            {
                if (DataSaver.btmRGBA[x,y,r].A != 0)
                {
                    RGBA newRGBA;
                    newRGBA = new RGBA(DataSaver.btmRGBA[x, y, r]);
                    newRGBA.A = (int)(DataSaver.btmRGBA[x, y, r].A * (DataSaver.intRayerTP[r] / 100d));
                    Brush pen = new SolidBrush(newRGBA.ColorReturn());
                    grpBitMap[x, y].FillRectangle(pen, rect);
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
                    DataSaver.nowRGBA = new RGBA(DataSaver.btmRGBA[intPointX, intPointY, intNowRayer]);
                    DataSaver.pclNow.PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
                    DataSaver.pclNow.RtbR.Text = DataSaver.nowRGBA.R.ToString();
                    DataSaver.pclNow.RtbG.Text = DataSaver.nowRGBA.G.ToString();
                    DataSaver.pclNow.RtbB.Text = DataSaver.nowRGBA.B.ToString();
                    DataSaver.pclNow.RtbA.Text = DataSaver.nowRGBA.A.ToString();
                }
                else if (DataSaver.bolPaint)
                {
                    if (DataSaver.btmRGBA[intPointX, intPointY, intNowRayer] != DataSaver.nowRGBA)
                    {
                        RGBA nowRGBA = DataSaver.btmRGBA[intPointX, intPointY, intNowRayer];
                        PaintTool(intPointX, intPointY, nowRGBA);
                        ReDrawing();
                    }
                }
                else if (DataSaver.intMirror == 1)
                {
                    DataSaver.btmRGBA[intPointX, intPointY, intNowRayer] = new RGBA(DataSaver.nowRGBA);
                    PartedReDrawing(intPointX, intPointY);
                    int intNewY = (int)((DataSaver.intStrMirror - 0.5m) * 2) - intPointY;
                    if (intNewY >= 0 && intNewY < DataSaver.intHeight)
                    {
                        DataSaver.btmRGBA[intPointX, intNewY, intNowRayer] = new RGBA(DataSaver.nowRGBA);
                        PartedReDrawing(intPointX, intNewY);
                    }

                }
                else if (DataSaver.intMirror == 2)
                {
                    DataSaver.btmRGBA[intPointX, intPointY, intNowRayer] = new RGBA(DataSaver.nowRGBA);
                    PartedReDrawing(intPointX,intPointY);
                    int intNewX = (int)((DataSaver.intStrMirror - 0.5m) * 2) - intPointX;
                    if (intNewX >= 0 && intNewX < DataSaver.intWidth)
                    {
                        DataSaver.btmRGBA[intNewX, intPointY, intNowRayer] = new RGBA(DataSaver.nowRGBA);
                        PartedReDrawing(intNewX,intPointY);
                    }
                }
                else
                {
                    DataSaver.btmRGBA[intPointX, intPointY, intNowRayer] = new RGBA(DataSaver.nowRGBA);
                    PartedReDrawing(intPointX,intPointY);
                }
                if (bolBorder)
                {
                    Pen pen = new Pen(Color.Green, 1);
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
                }
            }
            catch
            {

            }
        }

        private void SeeBitSet()
        {
            for (int y = 0; y < grpBitMap.GetLength(1); y++)
            {
                for (int x = 0; x < grpBitMap.GetLength(0); x++)
                {
                    PartedReDrawing(x, y);
                }
            }
        }

        private void BitMapMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.bmmNow = null;
            DataSaver.btmRGBA = null;
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
            intTimer++;
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

        private void BitMapMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (intTimer < 500)
            {
                ReDrawing();
                if (bolBorder)
                {
                    Pen pen = new Pen(Color.Green, 1);
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
                }
            }
        }
    }
}