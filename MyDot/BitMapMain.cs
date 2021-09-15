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
                    if (DataSaver.btmRGBA[x, y].A != 0)
                    {
                        PbxButtons[x, y].BackColor = DataSaver.btmRGBA[x, y].ColorReturn();
                        PbxButtons[x, y].Image = null;
                    }
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
            PbxButtons = new PictureBox[intWidth, intHeight];
            int intControlWidth = Pnl.Width / PbxButtons.GetLength(0);
            int intControlHeight = Pnl.Height / PbxButtons.GetLength(1);
            int intSize = Math.Min(intControlWidth, intControlHeight);
            DataSaver.intSize = intSize;
            for (int y = 0; y < PbxButtons.GetLength(1); y++)
            {
                for (int x = 0; x < PbxButtons.GetLength(0); x++)
                {
                    PbxButtons[x, y] = new PictureBox
                    {
                        Name = $"Pbx{x.ToString("D5")}{y.ToString("D5")}",
                        Size = new Size(intSize, intSize),
                        Parent = Pnl,
                        Location = new Point(x * intSize, y * intSize),
                        Text = "",
                        BackColor = new RGBA(0, 0, 0, 0).ColorReturn(),
                        Image = Properties.Resources.Empty
                    };
                    PbxButtons[x, y].Click += new EventHandler(BtnClick);
                    PbxButtons[x, y].MouseEnter += new EventHandler(MouseInside);
                    PbxButtons[x, y].DoubleClick += new EventHandler(MouseDClick);
                    Pnl.Controls.Add(PbxButtons[x, y]);
                }
            }
        }

        private void MouseDClick(object sender, EventArgs e)
        {
            if (!bolMouseDown)
            {
                bolMouseDown = true;
            }
            else
            {
                bolMouseDown = false;
            }
        }

        private void MouseInside(object sender, EventArgs e)
        {
            if (bolMouseDown)
            {
                BtnClick(sender, e);
            }
        }

        private void PbxSave(ref PictureBox[] buttons,ref int i,int x, int y, RGBA nowRGBA)
        {
            DataSaver.btmRGBA[x, y] = DataSaver.nowRGBA;
            PbxButtons[x, y].BackColor = DataSaver.nowRGBA.ColorReturn();
            Emptyer(PbxButtons[x, y]);
            for (int j = 0; j < 4; j++)
            {
                if (y < DataSaver.btmRGBA.GetLength(1) - 1)
                {
                    if (DataSaver.btmRGBA[x, y + 1] == nowRGBA)
                    {
                        buttons[i++] = PbxButtons[x, y + 1];
                        PbxSave(ref buttons, ref i, x, y + 1, nowRGBA);
                    }
                }
                if (y >= 1)
                {
                    if (DataSaver.btmRGBA[x, y - 1] == nowRGBA)
                    {
                        buttons[i++] = PbxButtons[x, y - 1];
                        PbxSave(ref buttons, ref i, x, y - 1, nowRGBA);
                    }
                }
                if (x < DataSaver.btmRGBA.GetLength(0) - 1)
                {
                    if (DataSaver.btmRGBA[x + 1, y] == nowRGBA)
                    {
                        buttons[i++] = PbxButtons[x + 1, y];
                        PbxSave(ref buttons, ref i, x + 1, y, nowRGBA);
                    }
                }
                if (x >= 1)
                {
                    if (DataSaver.btmRGBA[x - 1, y] == nowRGBA)
                    {
                        buttons[i++] = PbxButtons[x - 1, y];
                        PbxSave(ref buttons, ref i, x - 1, y, nowRGBA);
                    }
                }
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            if (DataSaver.bolExtraction)
            {
                DataSaver.nowRGBA = new RGBA(((PictureBox)sender).BackColor);
                DataSaver.pclNow.PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
                DataSaver.pclNow.RtbR.Text = DataSaver.nowRGBA.R.ToString();
                DataSaver.pclNow.RtbG.Text = DataSaver.nowRGBA.G.ToString();
                DataSaver.pclNow.RtbB.Text = DataSaver.nowRGBA.B.ToString();
                DataSaver.pclNow.RtbA.Text = DataSaver.nowRGBA.A.ToString();
            }
            else if (DataSaver.bolPaint)
            {
                if (((PictureBox)sender).BackColor != DataSaver.nowRGBA.ColorReturn())
                {
                    string strName = ((PictureBox)sender).Name;
                    int intWidthCode = int.Parse($"{strName[3]}{strName[4]}{strName[5]}{strName[6]}{strName[7]}");
                    int intHeightCode = int.Parse($"{strName[8]}{strName[9]}{strName[10]}{strName[11]}{strName[12]}");
                    PictureBox[] buttons = new PictureBox[DataSaver.intWidth * DataSaver.intHeigth];
                    RGBA nowRGBA = new RGBA(((PictureBox)sender).BackColor);
                    int i = 0;
                    PbxSave(ref buttons, ref i, intWidthCode, intHeightCode, nowRGBA);
                }
            }
            else if (DataSaver.intMirror == 1)
            {
                string strName = ((PictureBox)sender).Name;
                int intWidthCode = int.Parse($"{strName[3]}{strName[4]}{strName[5]}{strName[6]}{strName[7]}");
                int intHeightCode = int.Parse($"{strName[8]}{strName[9]}{strName[10]}{strName[11]}{strName[12]}");
                ((PictureBox)sender).BackColor = DataSaver.nowRGBA.ColorReturn();
                DataSaver.btmRGBA[intWidthCode, intHeightCode] = DataSaver.nowRGBA;
                Emptyer(sender);
                int intNewY = (int)((DataSaver.intStrMirror - 0.5m) * 2) - intHeightCode;
                if (intNewY >= 0 && intNewY < DataSaver.intHeigth)
                {
                    PbxButtons[intWidthCode, intNewY].BackColor = DataSaver.nowRGBA.ColorReturn();
                    DataSaver.btmRGBA[intWidthCode, intNewY] = DataSaver.nowRGBA;
                    Emptyer(PbxButtons[intWidthCode, intNewY]);
                }
                
            }
            else if (DataSaver.intMirror == 2)
            {
                string strName = ((PictureBox)sender).Name;
                int intWidthCode = int.Parse($"{strName[3]}{strName[4]}{strName[5]}{strName[6]}{strName[7]}");
                int intHeightCode = int.Parse($"{strName[8]}{strName[9]}{strName[10]}{strName[11]}{strName[12]}");
                ((PictureBox)sender).BackColor = DataSaver.nowRGBA.ColorReturn();
                DataSaver.btmRGBA[intWidthCode, intHeightCode] = DataSaver.nowRGBA;
                Emptyer(sender);
                int intNewX = (int)((DataSaver.intStrMirror - 0.5m) * 2) - intWidthCode;
                if (intNewX >= 0 && intNewX < DataSaver.intWidth)
                {
                    PbxButtons[intNewX, intHeightCode].BackColor = DataSaver.nowRGBA.ColorReturn();
                    DataSaver.btmRGBA[intNewX, intHeightCode] = DataSaver.nowRGBA;
                    Emptyer(PbxButtons[intNewX, intHeightCode]);
                }
            }
            else
            {
                string strName = ((PictureBox)sender).Name;
                int intWidthCode = int.Parse($"{strName[3]}{strName[4]}{strName[5]}{strName[6]}{strName[7]}");
                int intHeightCode = int.Parse($"{strName[8]}{strName[9]}{strName[10]}{strName[11]}{strName[12]}");
                ((PictureBox)sender).BackColor = DataSaver.nowRGBA.ColorReturn();
                DataSaver.btmRGBA[intWidthCode, intHeightCode] = DataSaver.nowRGBA;
                Emptyer(sender);
            }
        }

        private void Emptyer(object sender)
        {
            if (((PictureBox)sender).BackColor.A == new RGBA(0, 0, 0, 0).ColorReturn().A)
            {
                ((PictureBox)sender).Image = Properties.Resources.Empty;
            }
            else
            {
                ((PictureBox)sender).Image = null;
            }
        }

        private void BitMapMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.bmmNow = null;
        }
    }
}
