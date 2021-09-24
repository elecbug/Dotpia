using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dotpia
{
    public partial class BitMapMain : Form
    {
        public BitMapMain()
        {
            InitializeComponent();
        }

        private Point pntMouseWithPnl;
        private Point pntMouseWithForm;
        private Point[] pntDrag = new Point[2];
        private Point[] pntNewLocation = new Point[2];
        public Graphics[,] grpBitMap;
        public Graphics[] grpGrid;
        private Graphics grpDrag;
        private bool bolMouseDClick;
        private bool bolBorder;
        private bool bolNewFile;
        private bool bolCtrlPress = false;
        private bool bolMouseDown;
        public bool bolDragOn = false;
        private bool bolShiftPress = false;
        private int intTimer = 0;
        public int intNowLayer = 0;
        private int intScale = 0;
        public int intDefaultSize;
        private int intMousePixel = 1;
        private decimal[] dcmMouseLocationWithPnl = new decimal[2];

        private void BitMapMain_Load(object sender, EventArgs e)
        {
            try
            {
                DataSaver.ctrlZ = new CtrlZ();
                if (DataSaver.intLayerTP == null)
                {
                    DataSaver.intLayerTP = new int[DataSaver.HIGH_RAYER];
                    for (int i = 0; i < DataSaver.HIGH_RAYER; i++)
                    {
                        DataSaver.intLayerTP[i] = 100;
                    }
                }
                Pnl.MouseWheel += new MouseEventHandler(Pnl_MouseWheel);
                Timer.Start();
                grpGrid = new Graphics[DataSaver.intWidth + 1 + DataSaver.intHeight + 1 + 1];
                grpBitMap = new Graphics[DataSaver.intWidth, DataSaver.intHeight];
                int intControlWidth = Pnl.Width / grpBitMap.GetLength(0);
                int intControlHeight = Pnl.Height / grpBitMap.GetLength(1);
                int intSize = Math.Min(intControlWidth, intControlHeight);
                if (intSize < 1)
                {
                    intSize = 1;
                }
                Pnl.Width = intSize * DataSaver.intWidth;
                Pnl.Height = intSize * DataSaver.intHeight;
                DataSaver.intSize = intSize;
                intDefaultSize = intSize;
                for (int y = 0; y < grpBitMap.GetLength(1); y++)
                {
                    for (int x = 0; x < grpBitMap.GetLength(0); x++)
                    {
                        grpBitMap[x, y] = Pnl.CreateGraphics();
                    }
                }
                if (DataSaver.btmRGBA == null)
                {
                    bolNewFile = true;
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
                DataSaver.ctrlZ.Push(DataSaver.btmRGBA);
                DataSaver.startRGBA = (RGBA[,,])DataSaver.btmRGBA.Clone();
                ReDrawing();
                grpDrag = Pnl.CreateGraphics();
            }
            catch
            {

            }
        }

        private void BitMapMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.pclNow.Close();
            DataSaver.lyeNow.Close();
            DataSaver.pclNow = null;
            DataSaver.lyeNow = null;
            DataSaver.bmmNow = null;
            DataSaver.btmRGBA = null;
            DataSaver.intLayerTP = null;
            DataSaver.bolExtraction = false;
            DataSaver.bolPaint = false;
            DataSaver.intMirror = 0;
            DataSaver.paintRGBA = new RGBA();
            DataSaver.bolCut = false;
            DataSaver.nowStart.Show();
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

        private void BitMapMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (intTimer < 500 && !bolNewFile)
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

        private void BitMapMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                bolCtrlPress = true;
            }
            if (e.Shift)
            {
                bolShiftPress = true;
            }
            if (e.KeyCode == Keys.Z)
            {
                if (bolCtrlPress)
                {
                    DataSaver.pclNow.BtnZ_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.V)
            {
                if (bolCtrlPress)
                {
                    DataSaver.pclNow.BtnV_Click(sender, e);
                }
                if (bolShiftPress)
                {
                    if (bolDragOn)
                    {
                        int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
                        int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
                        int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
                        int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
                        RGBA[,] returnRGBA = new RGBA[maxX - minX, maxY - minY];
                        for (int x = minX; x < maxX; x++)
                        {
                            for (int y = minY; y < maxY; y++)
                            {
                                returnRGBA[x - minX, maxY - (y + 1)] = new RGBA(DataSaver.btmRGBA[x, y, intNowLayer]);
                            }
                        }
                        for (int x = minX; x < maxX; x++)
                        {
                            for (int y = minY; y < maxY; y++)
                            {
                                DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA(returnRGBA[x - minX, y - minY]);
                            }
                        }
                        ReDrawing();
                    }
                }
            }
            if (e.KeyCode == Keys.H)
            {
                if (bolShiftPress)
                {
                    if (bolDragOn)
                    {
                        int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
                        int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
                        int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
                        int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
                        RGBA[,] returnRGBA = new RGBA[maxX - minX, maxY - minY];
                        for (int x = minX; x < maxX; x++)
                        {
                            for (int y = minY; y < maxY; y++)
                            {
                                returnRGBA[maxX - (x + 1), y - minY] = new RGBA(DataSaver.btmRGBA[x, y, intNowLayer]);
                            }
                        }
                        for (int x = minX; x < maxX; x++)
                        {
                            for (int y = minY; y < maxY; y++)
                            {
                                DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA(returnRGBA[x - minX, y - minY]);
                            }
                        }
                        ReDrawing();
                    }
                }
            }
            if (e.KeyCode == Keys.C)
            {
                if (bolCtrlPress)
                {
                    if (bolDragOn)
                    {
                        Clipboard.Clear();
                        DataSaver.bolCopyMod = true;
                        int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
                        int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
                        int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
                        int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
                        DataSaver.copyRGBA = new RGBA[maxX - minX, maxY - minY];
                        for (int x = minX; x < maxX; x++)
                        {
                            for (int y = minY; y < maxY; y++)
                            {
                                DataSaver.copyRGBA[x - minX, y - minY] = new RGBA(DataSaver.btmRGBA[x, y, intNowLayer]);
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.X)
            {
                if (bolCtrlPress)
                {
                    if (bolDragOn)
                    {
                        Clipboard.Clear();
                        DataSaver.bolCopyMod = true;
                        int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
                        int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
                        int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
                        int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
                        DataSaver.copyRGBA = new RGBA[maxX - minX, maxY - minY];
                        for (int x = minX; x < maxX; x++)
                        {
                            for (int y = minY; y < maxY; y++)
                            {
                                DataSaver.copyRGBA[x - minX, y - minY] = new RGBA(DataSaver.btmRGBA[x, y, intNowLayer]);
                                DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA();
                            }
                        }
                        bolDragOn = false;
                        ReDrawing();
                    }
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (bolDragOn)
                {
                    int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
                    int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
                    int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
                    int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
                    for (int x = minX; x < maxX; x++)
                    {
                        for (int y = minY; y < maxY; y++)
                        {
                            DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA();
                        }
                    }
                    bolDragOn = false;
                    ReDrawing();
                }
            }
        }

        private void BitMapMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                bolCtrlPress = true;
            }
            else if (!e.Control)
            {
                bolCtrlPress = false;
                if (bolMouseDown)
                {
                    ReDrawing();
                }
            }
            if (e.Shift)
            {
                bolShiftPress = true;
            }
            else if (!e.Shift)
            {
                bolShiftPress = false;
            }
        }

        private void BitMapMain_Scroll(object sender, ScrollEventArgs e)
        {
            ReDrawing();
        }

        private void Pnl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (bolCtrlPress)
            {
                if (e.Delta / 120 > 0)
                {
                    intMousePixel += 2;
                }
                if (e.Delta / 120 < 0)
                {
                    intMousePixel -= 2;
                    if (intMousePixel < 1)
                    {
                        intMousePixel = 1;
                    }
                }
                DataSaver.pclNow.LblPx.Text = "Px: ";
                DataSaver.pclNow.LblPx.Text += intMousePixel.ToString();
            }
            else
            {
                if (e.Delta / 120 > 0)
                {
                    if (DataSaver.intSize < 300)
                    {
                        intScale++;
                        int intTempWidth = Pnl.Width;
                        int intTempHeight = Pnl.Height;
                        Point nowMouse = pntMouseWithPnl;
                        DataSaver.intSize = (int)Math.Ceiling(intDefaultSize * Math.Pow(2, intScale));
                        Pnl.Width = DataSaver.intWidth * DataSaver.intSize;
                        Pnl.Height = DataSaver.intHeight * DataSaver.intSize;
                        decimal dcmWidth = (Pnl.Width / (decimal)intTempWidth);
                        decimal dcmHeight = (Pnl.Height / (decimal)intTempHeight);
                        nowMouse.X = (int)(nowMouse.X * dcmWidth);
                        nowMouse.Y = (int)(nowMouse.Y * dcmHeight);
                        Pnl.Location = new Point(pntMouseWithForm.X - nowMouse.X, pntMouseWithForm.Y - nowMouse.Y);
                        pntMouseWithPnl = new Point(pntMouseWithPnl.X * 2, pntMouseWithPnl.Y * 2);
                        if(bolDragOn)
                        {
                            pntDrag[0].X = (int)(pntDrag[0].X * dcmWidth);
                            pntDrag[0].Y = (int)(pntDrag[0].Y * dcmHeight);
                            pntDrag[1].X = (int)(pntDrag[1].X * dcmWidth);
                            pntDrag[1].Y = (int)(pntDrag[1].Y * dcmHeight);
                        }
                    }
                }
                if (e.Delta / 120 < 0)
                {
                    if (DataSaver.intSize > 1)
                    {
                        intScale--;
                        int intTempWidth = Pnl.Width;
                        int intTempHeight = Pnl.Height;
                        Point nowMouse = pntMouseWithPnl;
                        DataSaver.intSize = (int)Math.Ceiling(intDefaultSize * Math.Pow(2, intScale));
                        Pnl.Width = DataSaver.intWidth * DataSaver.intSize;
                        Pnl.Height = DataSaver.intHeight * DataSaver.intSize;
                        decimal dcmWidth = (Pnl.Width / (decimal)intTempWidth);
                        decimal dcmHeight = (Pnl.Height / (decimal)intTempHeight);
                        nowMouse.X = (int)(nowMouse.X * dcmWidth);
                        nowMouse.Y = (int)(nowMouse.Y * dcmHeight);
                        Pnl.Location = new Point(pntMouseWithForm.X - nowMouse.X, pntMouseWithForm.Y - nowMouse.Y);
                        pntMouseWithPnl = new Point(pntMouseWithPnl.X / 2, pntMouseWithPnl.Y / 2);
                        if (bolDragOn)
                        {
                            pntDrag[0].X = (int)(pntDrag[0].X * dcmWidth);
                            pntDrag[0].Y = (int)(pntDrag[0].Y * dcmHeight);
                            pntDrag[1].X = (int)(pntDrag[1].X * dcmWidth);
                            pntDrag[1].Y = (int)(pntDrag[1].Y * dcmHeight);
                        }
                    }
                }
                try
                {
                    DataSaver.grpMirror = DataSaver.bmmNow.CreateGraphics();
                    DataSaver.grpMirror.Clear(DataSaver.bmmNow.BackColor);
                    if (DataSaver.intMirror == 1)
                    {
                        DataSaver.grpMirror.DrawLine(new Pen(Color.White),
                                             new Point(0, DataSaver.intSize * DataSaver.intMirrorValue + Pnl.Location.Y),
                                             new Point(DataSaver.bmmNow.Width, DataSaver.intSize * DataSaver.intMirrorValue + Pnl.Location.Y));
                    }
                    else if (DataSaver.intMirror == 2)
                    {
                        DataSaver.grpMirror.DrawLine(new Pen(Color.White),
                                             new Point(DataSaver.intSize * DataSaver.intMirrorValue + Pnl.Location.X, 0),
                                             new Point(DataSaver.intSize * DataSaver.intMirrorValue + Pnl.Location.X, DataSaver.bmmNow.Height));
                    }
                }
                catch
                {

                }
                ReDrawing();
            }
        }

        private void Pnl_DClick(object sender, EventArgs e)
        {
            if (!bolMouseDClick)
            {
                bolMouseDClick = true;
            }
            else
            {
                bolMouseDClick = false;
                CtrlZPush();
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

        private void Pnl_MouseMove(object sender, MouseEventArgs e)
        {

            if (!bolCtrlPress)
            {
                if (!DataSaver.bolCut)
                {
                    if (bolMouseDClick || bolMouseDown)
                    {
                        if (pntMouseWithPnl.X >= 0
                         && pntMouseWithPnl.Y >= 0
                         && pntMouseWithPnl.X <= Pnl.Width
                         && pntMouseWithPnl.Y <= Pnl.Height)
                        {
                            Pnl_Click(sender, e);
                        }
                    }
                }
            }
        }

        private void Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
            int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
            int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
            int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
            if (DataSaver.bolCut
            && (pntMouseWithPnl.X < minX * DataSaver.intSize || pntMouseWithPnl.Y < minY * DataSaver.intSize
             || pntMouseWithPnl.X > maxX * DataSaver.intSize || pntMouseWithPnl.Y > maxY * DataSaver.intSize))
            {
                pntDrag[0] = new Point(pntMouseWithPnl.X, pntMouseWithPnl.Y);
                bolDragOn = false;
            }
            else if (DataSaver.bolCut)
            {
                pntNewLocation[0] = new Point(pntMouseWithPnl.X, pntMouseWithPnl.Y);
            }
            bolMouseDown = true;
        }

        private void Pnl_MouseUp(object sender, MouseEventArgs e)
        {
            if (bolCtrlPress)
            {
                ReDrawing();
            }
            bolMouseDown = false;
            if (bolDragOn)
            {
                pntNewLocation[1] = new Point(pntMouseWithPnl.X, pntMouseWithPnl.Y);
                int xMove = pntNewLocation[0].X / DataSaver.intSize - pntNewLocation[1].X / DataSaver.intSize;
                int yMove = pntNewLocation[0].Y / DataSaver.intSize - pntNewLocation[1].Y / DataSaver.intSize;
                if (xMove >= 0)
                {
                    if (yMove >= 0)
                    {
                        for (int x = Math.Min(pntDrag[0].X, pntDrag[1].X) / DataSaver.intSize; x < Math.Max(pntDrag[0].X, pntDrag[1].X) / DataSaver.intSize + 1; x++)
                        {
                            for (int y = Math.Min(pntDrag[0].Y, pntDrag[1].Y) / DataSaver.intSize; y < Math.Max(pntDrag[0].Y, pntDrag[1].Y) / DataSaver.intSize + 1; y++)
                            {
                                if (x - xMove >= 0 && x - xMove < DataSaver.intWidth && y - yMove >= 0 && y - yMove < DataSaver.intHeight)
                                {
                                    if (DataSaver.btmRGBA[x, y, intNowLayer] != new RGBA())
                                    {
                                        DataSaver.btmRGBA[x - xMove, y - yMove, intNowLayer] = DataSaver.btmRGBA[x, y, intNowLayer];
                                    }
                                }
                                if (!bolCtrlPress)
                                {
                                    DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA();
                                }
                            }
                        }
                    }
                    else if (yMove < 0)
                    {
                        for (int x = Math.Min(pntDrag[0].X, pntDrag[1].X) / DataSaver.intSize; x < Math.Max(pntDrag[0].X, pntDrag[1].X) / DataSaver.intSize + 1; x++)
                        {
                            for (int y = Math.Max(pntDrag[0].Y, pntDrag[1].Y) / DataSaver.intSize; y >= Math.Min(pntDrag[0].Y, pntDrag[1].Y) / DataSaver.intSize; y--)
                            {
                                if (x - xMove >= 0 && x - xMove < DataSaver.intWidth && y - yMove >= 0 && y - yMove < DataSaver.intHeight)
                                {
                                    if (DataSaver.btmRGBA[x, y, intNowLayer] != new RGBA())
                                    {
                                        DataSaver.btmRGBA[x - xMove, y - yMove, intNowLayer] = DataSaver.btmRGBA[x, y, intNowLayer];
                                    }
                                }
                                if (!bolCtrlPress)
                                {
                                    DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA();
                                }
                            }
                        }
                    }
                }
                else if (xMove < 0)
                {
                    if (yMove >= 0)
                    {
                        for (int x = Math.Max(pntDrag[0].X, pntDrag[1].X) / DataSaver.intSize; x >= Math.Min(pntDrag[0].X, pntDrag[1].X) / DataSaver.intSize; x--)
                        {
                            for (int y = Math.Min(pntDrag[0].Y, pntDrag[1].Y) / DataSaver.intSize; y < Math.Max(pntDrag[0].Y, pntDrag[1].Y) / DataSaver.intSize + 1; y++)
                            {
                                if (x - xMove >= 0 && x - xMove < DataSaver.intWidth && y - yMove >= 0 && y - yMove < DataSaver.intHeight)
                                {
                                    if (DataSaver.btmRGBA[x, y, intNowLayer] != new RGBA())
                                    {
                                        DataSaver.btmRGBA[x - xMove, y - yMove, intNowLayer] = DataSaver.btmRGBA[x, y, intNowLayer];
                                    }
                                }
                                if (!bolCtrlPress)
                                {
                                    DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA();
                                }
                            }
                        }
                    }
                    else if (yMove < 0)
                    {
                        for (int x = Math.Max(pntDrag[0].X, pntDrag[1].X) / DataSaver.intSize; x >= Math.Min(pntDrag[0].X, pntDrag[1].X) / DataSaver.intSize; x--)
                        {
                            for (int y = Math.Max(pntDrag[0].Y, pntDrag[1].Y) / DataSaver.intSize; y >= Math.Min(pntDrag[0].Y, pntDrag[1].Y) / DataSaver.intSize; y--)
                            {
                                if (x - xMove >= 0 && x - xMove < DataSaver.intWidth && y - yMove >= 0 && y - yMove < DataSaver.intHeight)
                                {
                                    if (DataSaver.btmRGBA[x, y, intNowLayer] != new RGBA())
                                    {
                                        DataSaver.btmRGBA[x - xMove, y - yMove, intNowLayer] = DataSaver.btmRGBA[x, y, intNowLayer];
                                    }
                                }
                                if (!bolCtrlPress)
                                {
                                    DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA();
                                }
                            }
                        }
                    }
                }
                bolDragOn = false;
                ReDrawing();
                pntDrag = new Point[2];
                pntNewLocation = new Point[2];
            }
            else if (DataSaver.bolCut)
            {
                pntDrag[1] = new Point(pntMouseWithPnl.X, pntMouseWithPnl.Y);
                grpDrag.Clear(Pnl.BackColor);
                ReDrawing();
                int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
                int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
                int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
                int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
                Pen pen = new Pen(Color.White, 5);
                grpDrag = Pnl.CreateGraphics();
                grpDrag.DrawLine(pen, minX * DataSaver.intSize, minY * DataSaver.intSize, maxX * DataSaver.intSize, minY * DataSaver.intSize);
                grpDrag.DrawLine(pen, maxX * DataSaver.intSize, minY * DataSaver.intSize, maxX * DataSaver.intSize, maxY * DataSaver.intSize);
                grpDrag.DrawLine(pen, maxX * DataSaver.intSize, maxY * DataSaver.intSize, minX * DataSaver.intSize, maxY * DataSaver.intSize);
                grpDrag.DrawLine(pen, minX * DataSaver.intSize, maxY * DataSaver.intSize, minX * DataSaver.intSize, minY * DataSaver.intSize);
                bolDragOn = true;
            }
            if (!bolDragOn)
            {
                CtrlZPush();
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

        private void Pnl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bolCtrlPress && !bolShiftPress)
                {
                    RGBA color = new RGBA(DataSaver.nowRGBA);
                    if (((MouseEventArgs)e).Button == MouseButtons.Right)
                    {
                        DataSaver.nowRGBA = new RGBA(0, 0, 0, 0);
                    }
                    int intPointX = pntMouseWithPnl.X / DataSaver.intSize, intPointY = pntMouseWithPnl.Y / DataSaver.intSize;
                    if (!DataSaver.bolExtraction && !DataSaver.bolPaint && DataSaver.intMirror == 0 && !DataSaver.bolCut)
                    {
                        DataSaver.btmRGBA[intPointX, intPointY, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                        PartedReDrawing(intPointX, intPointY);
                        if (intMousePixel > 1)
                        {
                            for (int x = intPointX - (intMousePixel / 2 + 1); x < intPointX + (intMousePixel / 2 + 1); x++)
                            {
                                for (int y = intPointY - (intMousePixel / 2 + 1); y < intPointY + (intMousePixel / 2 + 1); y++)
                                {
                                    DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                                    PartedReDrawing(x, y);
                                }
                            }
                        }
                    }
                    else if (DataSaver.bolExtraction)
                    {
                        DataSaver.nowRGBA = new RGBA(DataSaver.btmRGBA[intPointX, intPointY, intNowLayer]);
                        DataSaver.pclNow.PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
                        DataSaver.pclNow.TrbR.Value = DataSaver.nowRGBA.R;
                        DataSaver.pclNow.TrbG.Value = DataSaver.nowRGBA.G;
                        DataSaver.pclNow.TrbB.Value = DataSaver.nowRGBA.B;
                        DataSaver.pclNow.TrbA.Value = DataSaver.nowRGBA.A;
                        color = new RGBA(DataSaver.nowRGBA);
                    }
                    else if (DataSaver.bolPaint)
                    {
                        RGBA clickRGBA = DataSaver.btmRGBA[intPointX, intPointY, intNowLayer];
                        PaintTool(intPointX, intPointY);
                        ReDrawing();
                    }
                    else if (DataSaver.intMirror == 1)
                    {
                        DataSaver.btmRGBA[intPointX, intPointY, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                        PartedReDrawing(intPointX, intPointY);
                        if (intMousePixel > 1)
                        {
                            for (int x = intPointX - (intMousePixel / 2 + 1); x < intPointX + (intMousePixel / 2 + 1); x++)
                            {
                                for (int y = intPointY - (intMousePixel / 2 + 1); y < intPointY + (intMousePixel / 2 + 1); y++)
                                {
                                    DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                                    PartedReDrawing(x, y);
                                }
                            }
                        }
                        int intNewY = (int)((DataSaver.intMirrorValue - 0.5m) * 2) - intPointY;
                        if (intNewY >= 0 && intNewY < DataSaver.intHeight)
                        {
                            DataSaver.btmRGBA[intPointX, intNewY, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                            PartedReDrawing(intPointX, intNewY);
                            if (intMousePixel > 1)
                            {
                                for (int x = intPointX - (intMousePixel / 2 + 1); x < intPointX + (intMousePixel / 2 + 1); x++)
                                {
                                    for (int y = intNewY - (intMousePixel / 2 + 1); y < intNewY + (intMousePixel / 2 + 1); y++)
                                    {
                                        DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                                        PartedReDrawing(x, y);
                                    }
                                }
                            }
                        }
                    }
                    else if (DataSaver.intMirror == 2)
                    {
                        DataSaver.btmRGBA[intPointX, intPointY, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                        PartedReDrawing(intPointX, intPointY);
                        if (intMousePixel > 1)
                        {
                            for (int x = intPointX - (intMousePixel / 2 + 1); x < intPointX + (intMousePixel / 2 + 1); x++)
                            {
                                for (int y = intPointY - (intMousePixel / 2 + 1); y < intPointY + (intMousePixel / 2 + 1); y++)
                                {
                                    DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                                    PartedReDrawing(x, y);
                                }
                            }
                        }
                        int intNewX = (int)((DataSaver.intMirrorValue - 0.5m) * 2) - intPointX;
                        if (intNewX >= 0 && intNewX < DataSaver.intWidth)
                        {
                            DataSaver.btmRGBA[intNewX, intPointY, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                            PartedReDrawing(intNewX, intPointY);
                            if (intMousePixel > 1)
                            {
                                for (int x = intNewX - (intMousePixel / 2 + 1); x < intNewX + (intMousePixel / 2 + 1); x++)
                                {
                                    for (int y = intPointY - (intMousePixel / 2 + 1); y < intPointY + (intMousePixel / 2 + 1); y++)
                                    {
                                        DataSaver.btmRGBA[x, y, intNowLayer] = new RGBA(DataSaver.nowRGBA);
                                        PartedReDrawing(x, y);
                                    }
                                }
                            }
                        }
                    }
                    if (bolBorder && !bolMouseDown && !bolMouseDClick)
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
                    if (bolDragOn)
                    {
                        int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
                        int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
                        int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
                        int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
                        Pen pen = new Pen(Color.White, 5);
                        grpDrag = Pnl.CreateGraphics();
                        grpDrag.DrawLine(pen, minX * DataSaver.intSize, minY * DataSaver.intSize, maxX * DataSaver.intSize, minY * DataSaver.intSize);
                        grpDrag.DrawLine(pen, maxX * DataSaver.intSize, minY * DataSaver.intSize, maxX * DataSaver.intSize, maxY * DataSaver.intSize);
                        grpDrag.DrawLine(pen, maxX * DataSaver.intSize, maxY * DataSaver.intSize, minX * DataSaver.intSize, maxY * DataSaver.intSize);
                        grpDrag.DrawLine(pen, minX * DataSaver.intSize, maxY * DataSaver.intSize, minX * DataSaver.intSize, minY * DataSaver.intSize);
                    }
                    DataSaver.nowRGBA = new RGBA(color);
                    CtrlZPush();
                }
            }
            catch
            {

            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.GetImage() != null)
                {
                    DataSaver.bolCopyMod = false;
                }
                intTimer++;
                pntMouseWithPnl = Pnl.PointToClient(new Point(MousePosition.X, MousePosition.Y));
                pntMouseWithForm = this.PointToClient(new Point(MousePosition.X, MousePosition.Y));
                dcmMouseLocationWithPnl[0] = pntMouseWithPnl.X / (decimal)DataSaver.intSize;
                dcmMouseLocationWithPnl[1] = pntMouseWithPnl.Y / (decimal)DataSaver.intSize;
                string strPositionX = dcmMouseLocationWithPnl[0].ToString("F2"),
                       strPositionY = dcmMouseLocationWithPnl[1].ToString("F2");
                if (dcmMouseLocationWithPnl[0] < 0)
                {
                    strPositionX = "Less";
                }
                if (dcmMouseLocationWithPnl[1] < 0)
                {
                    strPositionY = "Less";
                }
                if (dcmMouseLocationWithPnl[0] > DataSaver.intWidth)
                {
                    strPositionX = "Over";
                }
                if (dcmMouseLocationWithPnl[1] > DataSaver.intHeight)
                {
                    strPositionY = "Over";
                }
                if (DataSaver.pclNow != null)
                {
                    DataSaver.pclNow.LblMouse.Text = "Mouse Position(" + strPositionX + ", " + strPositionY + ")";
                }
            }
            catch
            {

            }
        }

        public void ZoomReset()
        {
            int nowWidth = Pnl.Width;
            int nowHeight = Pnl.Height;
            Pnl.Location = new Point(12, 12);
            Pnl.Width = 800;
            Pnl.Height = 600;
            DataSaver.intSize = Math.Min(Pnl.Width / grpBitMap.GetLength(0), Pnl.Height / grpBitMap.GetLength(1));
            if (DataSaver.intSize < 1)
            {
                DataSaver.intSize = 1;
            }
            Pnl.Width = DataSaver.intSize * DataSaver.intWidth;
            Pnl.Height = DataSaver.intSize * DataSaver.intHeight;
            decimal dcmWidth = Pnl.Width / (decimal)nowWidth;
            decimal dcmHeight = Pnl.Height / (decimal)nowHeight;
            if (bolDragOn)
            {
                pntDrag[0].X = (int)(pntDrag[0].X * dcmWidth);
                pntDrag[0].Y = (int)(pntDrag[0].Y * dcmHeight);
                pntDrag[1].X = (int)(pntDrag[1].X * dcmWidth);
                pntDrag[1].Y = (int)(pntDrag[1].Y * dcmHeight);
            }
            ReDrawing();
            try
            {
                DataSaver.grpMirror = DataSaver.bmmNow.CreateGraphics();
                DataSaver.grpMirror.Clear(DataSaver.bmmNow.BackColor);
                if (DataSaver.intMirror == 1)
                {
                    DataSaver.grpMirror.DrawLine(new Pen(Color.White),
                                         new Point(0, DataSaver.intSize * DataSaver.intMirrorValue + Pnl.Location.Y),
                                         new Point(DataSaver.bmmNow.Width, DataSaver.intSize * DataSaver.intMirrorValue + Pnl.Location.Y));
                }
                else if (DataSaver.intMirror == 2)
                {
                    DataSaver.grpMirror.DrawLine(new Pen(Color.White),
                                         new Point(DataSaver.intSize * DataSaver.intMirrorValue + Pnl.Location.X, 0),
                                         new Point(DataSaver.intSize * DataSaver.intMirrorValue + Pnl.Location.X, DataSaver.bmmNow.Height));
                }
            }
            catch
            {

            }
        }

        public void ReDrawing()
        {
            for (int y = Math.Max(-(DataSaver.intSize + Pnl.Location.Y) / DataSaver.intSize, 0);
                     y < Math.Min((this.Height - Pnl.Location.Y) / DataSaver.intSize + 1, DataSaver.intHeight); y++)
            {
                for (int x = Math.Max(-(DataSaver.intSize + Pnl.Location.X) / DataSaver.intSize, 0);
                         x < Math.Min((this.Width - Pnl.Location.X) / DataSaver.intSize + 1, DataSaver.intWidth); x++)
                {
                    PartedReDrawing(x, y);
                }
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
            if (bolDragOn)
            {
                int minX = Math.Min((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize));
                int minY = Math.Min((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize));
                int maxX = Math.Max((int)(pntDrag[0].X / DataSaver.intSize), (int)(pntDrag[1].X / DataSaver.intSize)) + 1;
                int maxY = Math.Max((int)(pntDrag[0].Y / DataSaver.intSize), (int)(pntDrag[1].Y / DataSaver.intSize)) + 1;
                Pen pen = new Pen(Color.White, 5);
                grpDrag = Pnl.CreateGraphics();
                grpDrag.DrawLine(pen, minX * DataSaver.intSize, minY * DataSaver.intSize, maxX * DataSaver.intSize, minY * DataSaver.intSize);
                grpDrag.DrawLine(pen, maxX * DataSaver.intSize, minY * DataSaver.intSize, maxX * DataSaver.intSize, maxY * DataSaver.intSize);
                grpDrag.DrawLine(pen, maxX * DataSaver.intSize, maxY * DataSaver.intSize, minX * DataSaver.intSize, maxY * DataSaver.intSize);
                grpDrag.DrawLine(pen, minX * DataSaver.intSize, maxY * DataSaver.intSize, minX * DataSaver.intSize, minY * DataSaver.intSize);

            }
        }

        public void BorderMaking()
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
                DataSaver.pclNow.BtnBorder.BackColor = Color.Green;
            }
            else
            {
                for (int i = 0; i < grpGrid.Length; i++)
                {
                    grpGrid[i].Clear(Pnl.BackColor);
                }
                bolBorder = false;
                ReDrawing();
                DataSaver.pclNow.BtnBorder.BackColor = SystemColors.Control;
            }
        }

        private void PaintTool(int x, int y)
        {
            RGBA[,] combineLayerRGBA = BitSave();
            int[,] intBitMap = new int[DataSaver.intWidth, DataSaver.intHeight];    //if 0: Don't able to paint; if 1: Be able to paint; if 2: Real painting area; 
            RGBA clickRGBA = combineLayerRGBA[x, y];
            for (int w = 0; w < intBitMap.GetLength(0); w++)
            {
                for (int h = 0; h < intBitMap.GetLength(1); h++)
                {
                    if (RGBA.Paint(combineLayerRGBA[w, h], clickRGBA))
                    {
                        intBitMap[w, h] = 1;
                    }
                }
            }
            intBitMap[x, y] = 2;
        ReTry:
            for (int h = y; h >= 0; h--)
            {
                for (int w = x + 1; w < intBitMap.GetLength(0); w++)
                {
                    if (intBitMap[w, h] == 1)
                    {
                        if ((w > 0 && intBitMap[w - 1, h] == 2)
                         || (h > 0 && intBitMap[w, h - 1] == 2)
                         || (w < intBitMap.GetLength(0) - 1 && intBitMap[w + 1, h] == 2)
                         || (h < intBitMap.GetLength(1) - 1 && intBitMap[w, h + 1] == 2))
                        {
                            intBitMap[w, h] = 2;
                        }
                    }
                }
            }
            for (int w = x; w >= 0; w--)
            {
                for (int h = y - 1; h >= 0; h--)
                {
                    if (intBitMap[w, h] == 1)
                    {
                        if ((w > 0 && intBitMap[w - 1, h] == 2)
                         || (h > 0 && intBitMap[w, h - 1] == 2)
                         || (w < intBitMap.GetLength(0) - 1 && intBitMap[w + 1, h] == 2)
                         || (h < intBitMap.GetLength(1) - 1 && intBitMap[w, h + 1] == 2))
                        {
                            intBitMap[w, h] = 2;
                        }
                    }
                }
            }
            for (int h = y; h < intBitMap.GetLength(1); h++)
            {
                for (int w = x - 1; w >= 0; w--)
                {
                    if (intBitMap[w, h] == 1)
                    {
                        if ((w > 0 && intBitMap[w - 1, h] == 2)
                         || (h > 0 && intBitMap[w, h - 1] == 2)
                         || (w < intBitMap.GetLength(0) - 1 && intBitMap[w + 1, h] == 2)
                         || (h < intBitMap.GetLength(1) - 1 && intBitMap[w, h + 1] == 2))
                        {
                            intBitMap[w, h] = 2;
                        }
                    }
                }
            }
            for (int w = x; w < intBitMap.GetLength(0); w++)
            {
                for (int h = y + 1; h < intBitMap.GetLength(1); h++)
                {
                    if (intBitMap[w, h] == 1)
                    {
                        if ((w > 0 && intBitMap[w - 1, h] == 2)
                         || (h > 0 && intBitMap[w, h - 1] == 2)
                         || (w < intBitMap.GetLength(0) - 1 && intBitMap[w + 1, h] == 2)
                         || (h < intBitMap.GetLength(1) - 1 && intBitMap[w, h + 1] == 2))
                        {
                            intBitMap[w, h] = 2;
                        }
                    }
                }
            }
            for (int w = 0; w < intBitMap.GetLength(0); w++)
            {
                for (int h = 0; h < intBitMap.GetLength(1); h++)
                {
                    if (intBitMap[w, h] == 2)
                    {
                        if ((w > 0 && intBitMap[w - 1, h] == 1)
                         || (h > 0 && intBitMap[w, h - 1] == 1)
                         || (w < intBitMap.GetLength(0) - 1 && intBitMap[w + 1, h] == 1)
                         || (h < intBitMap.GetLength(1) - 1 && intBitMap[w, h + 1] == 1))
                        {
                            x = w;
                            y = h;
                            goto ReTry;
                        }
                    }
                }
            }
            for (int w = 0; w < intBitMap.GetLength(0); w++)
            {
                for (int h = 0; h < intBitMap.GetLength(1); h++)
                {
                    if (intBitMap[w, h] == 2)
                    {
                        DataSaver.btmRGBA[w, h, intNowLayer] = DataSaver.nowRGBA;
                    }
                }
            }
        }

        private RGBA[,] BitSave()
        {
            try
            {
                RGBA[,,] bitmapRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight, DataSaver.HIGH_RAYER];
                RGBA[,] returnBitmap = new RGBA[DataSaver.intWidth, DataSaver.intHeight];
                for (int x = 0; x < DataSaver.intWidth; x++)
                {
                    for (int y = 0; y < DataSaver.intHeight; y++)
                    {
                        for (int r = 0; r < DataSaver.HIGH_RAYER; r++)
                        {
                            bitmapRGBA[x, y, r] = new RGBA(DataSaver.btmRGBA[x, y, r]);
                            bitmapRGBA[x, y, r].A = (int)(bitmapRGBA[x, y, r].A * DataSaver.intLayerTP[r] / 100m);
                        }
                    }
                }
                for (int x = 0; x < DataSaver.intWidth; x++)
                {
                    for (int y = 0; y < DataSaver.intHeight; y++)
                    {
                        RGBA nowRGBA = new RGBA(bitmapRGBA[x, y, 0]);
                        for (int r = 1; r < DataSaver.HIGH_RAYER; r++)
                        {
                            nowRGBA = new RGBA(Combine(new RGBA(nowRGBA), new RGBA(bitmapRGBA[x, y, r])));
                        }
                        returnBitmap[x, y] = nowRGBA;
                    }
                }
                return returnBitmap;
            }
            catch
            {
                return new RGBA[1, 1];
            }
        }

        private RGBA Combine(RGBA ibg, RGBA ifg)
        {
            RGBAby1 r = new RGBAby1();
            RGBAby1 bg = new RGBAby1(ibg.R / 255m, ibg.G / 255m, ibg.B / 255m, ibg.A / 255m);
            RGBAby1 fg = new RGBAby1(ifg.R / 255m, ifg.G / 255m, ifg.B / 255m, ifg.A / 255m);
            if (bg.A == 0 && fg.A == 0)
            {

            }
            else if (bg.A == 0)
            {
                r = new RGBAby1(fg);
            }
            else if (fg.A == 0)
            {
                r = new RGBAby1(bg);
            }
            else if (fg.A != 0 && bg.A != 0)
            {
                r.A = 1 - (1 - fg.A) * (1 - bg.A);
                r.R = (fg.R * fg.A / r.A) + (bg.R * bg.A * (1 - fg.A) / r.A);
                r.G = (fg.G * fg.A / r.A) + (bg.G * bg.A * (1 - fg.A) / r.A);
                r.B = (fg.B * fg.A / r.A) + (bg.B * bg.A * (1 - fg.A) / r.A);
            }
            return new RGBA((int)(r.R * 255), (int)(r.G * 255), (int)(r.B * 255), (int)(r.A * 255));
        }

        private void PartedReDrawing(int x, int y)
        {
            RGBA newRGBA = new RGBA(DataSaver.btmRGBA[x, y, 0])
            {
                A = (int)(DataSaver.btmRGBA[x, y, 0].A * (DataSaver.intLayerTP[0] / 100d))
            };
            Rectangle rect = new Rectangle(x * DataSaver.intSize, y * DataSaver.intSize, DataSaver.intSize, DataSaver.intSize);
            Brush brush = new SolidBrush(Pnl.BackColor);
            grpBitMap[x, y].FillRectangle(brush, rect);
            grpBitMap[x, y] = Pnl.CreateGraphics();
            for (int r = 0; r < DataSaver.HIGH_RAYER - 1; r++)
            {
                newRGBA = Combine(new RGBA(newRGBA), new RGBA(DataSaver.btmRGBA[x, y, r + 1])
                {
                    A = (int)(DataSaver.btmRGBA[x, y, r + 1].A * (DataSaver.intLayerTP[r + 1] / 100d))
                });
            }
            Brush pen = new SolidBrush(newRGBA.ColorReturn());
            grpBitMap[x, y].FillRectangle(pen, rect);
        }

        private void CtrlZPush()
        {
            if (!bolMouseDClick && !bolMouseDown)
            {
                DataSaver.ctrlZ.Push(DataSaver.btmRGBA);
            }
        }

        private void BitMapResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                DataSaver.pclNow.Show();
                DataSaver.lyeNow.Show();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                DataSaver.pclNow.Hide();
                DataSaver.lyeNow.Hide();
            }
        }
    }
}