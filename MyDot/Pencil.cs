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
    public partial class Pencil : Form
    {
        public Pencil()
        {
            InitializeComponent();
        }

        private bool bolColorDialog = false;
        private bool bolSaveColorClick = false;
        public bool bolEsterEgg = false;

        private void Pencil_Load(object sender, EventArgs e)
        {
            this.Location = new Point(DataSaver.bmmNow.Location.X + DataSaver.bmmNow.Width, DataSaver.bmmNow.Location.Y);
            DataSaver.pclNow = this;
            for (int i = 0; i < 7; i++)
            {
                DataSaver.saveRGBA[i] = new RGBA();
            }
            PbxColor.BackColor = Color.White;
            DataSaver.nowRGBA = new RGBA(255, 255, 255, 255);
            LblWidth.Text = $"Width: {DataSaver.intWidth}";
            LblHeight.Text = $"Height: {DataSaver.intHeight}";
        }

        private void RtbKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void BtnChoice_Click(object sender, EventArgs e)
        {
            try
            {
                DataSaver.nowRGBA = new RGBA(int.Parse(RtbR.Text), int.Parse(RtbG.Text), int.Parse(RtbB.Text), int.Parse(RtbA.Text));
                PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
            }
            catch
            {

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SfdSave.ShowDialog() == DialogResult.OK)
            {
                BitSave(SfdSave.FileName.ToString());
            }
        }

        private void BitSave(string strPath)
        {
            Bitmap bitmap = new Bitmap(DataSaver.intWidth, DataSaver.intHeight);
            RGBA[,,] bitmapRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight, DataSaver.HIGH_RAYER];
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
                    //nowRGBA.A *= 2;
                    //if (nowRGBA.A > 255)
                    //{
                    //    nowRGBA.A = 255;
                    //}
                    bitmap.SetPixel(x, y, nowRGBA.ColorReturn());
                }
            }
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
            bitmap.Save(strPath);
            bitmap.Dispose();
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



        private void BtnSmart_Click(object sender, EventArgs e)
        {
            bolColorDialog = true;
            if (CldColor.ShowDialog() == DialogResult.OK)
            {
                DataSaver.nowRGBA = new RGBA(CldColor.Color);
                PbxColor.BackColor = DataSaver.nowRGBA.ColorReturn();
                RtbR.Text = DataSaver.nowRGBA.R.ToString();
                RtbG.Text = DataSaver.nowRGBA.G.ToString();
                RtbB.Text = DataSaver.nowRGBA.B.ToString();
                RtbA.Text = DataSaver.nowRGBA.A.ToString();
            }
            bolColorDialog = false;
        }

        private void BtnBorder_Click(object sender, EventArgs e)
        {
            DataSaver.bmmNow.PbxBorder();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                int intExport = int.Parse(RtbExport.Text);
                if (SfdSave.ShowDialog() == DialogResult.OK)
                {
                    string strPath = SfdSave.FileName.ToString();
                    Bitmap bitmap = new Bitmap(DataSaver.intWidth * intExport, DataSaver.intHeight * intExport);
                    RGBA[,,] bitmapRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight, DataSaver.HIGH_RAYER];
                    RGBA[,] combineRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight];
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
                                nowRGBA = new RGBA(Combine(new RGBA(nowRGBA), new RGBA(bitmapRGBA[x, y, r ])));
                            }
                            //nowRGBA.A *= 2;
                            //if (nowRGBA.A > 255)
                            //{
                            //    nowRGBA.A = 255;
                            //}
                            combineRGBA[x, y] = new RGBA(nowRGBA);
                        }
                    }
                    for (int x = 0; x < DataSaver.intWidth; x++)
                    {
                        for (int y = 0; y < DataSaver.intHeight; y++)
                        {
                            for (int xx = 0; xx < intExport; xx++)
                            {
                                for (int yy = 0; yy < intExport; yy++)
                                {
                                    bitmap.SetPixel(x * intExport + xx, y * intExport + yy, combineRGBA[x, y].ColorReturn());
                                }
                            }
                        }
                    }
                    if (File.Exists(strPath))
                    {
                        File.Delete(strPath);
                    }
                    bitmap.Save(strPath);
                    bitmap.Dispose();
                }
            }
            catch
            {

            }
        }

        private void BtnCombine_Click(object sender, EventArgs e)
        {
            bool bolBitSaveCheak = false;
            Bitmap[,] bitmaps = new Bitmap[int.Parse(RtbCWidth.Text), int.Parse(RtbCHeight.Text)];
            Bitmap btmBitSave = new Bitmap(1, 1);
            string strPath = "";
            for (int y = 0; y < int.Parse(RtbCHeight.Text); y++)
            {
                for (int x = 0; x < int.Parse(RtbCWidth.Text); x++)
                {
                    OfdOpen.FileName = $"File {x + 1}, {y + 1}";
                    if (OfdOpen.ShowDialog() == DialogResult.OK)
                    {
                        bitmaps[x, y] = new Bitmap(OfdOpen.FileName.ToString());
                        if (!bolBitSaveCheak)
                        {
                            btmBitSave = new Bitmap(int.Parse(RtbCWidth.Text) * bitmaps[x, y].Width, int.Parse(RtbCHeight.Text) * bitmaps[x, y].Height);
                            bolBitSaveCheak = true;
                        }
                    }
                    for (int xx = 0; xx < bitmaps[x, y].Width; xx++)
                    {
                        for (int yy = 0; yy < bitmaps[x, y].Height; yy++)
                        {
                            btmBitSave.SetPixel(x * bitmaps[x, y].Width + xx, y * bitmaps[x, y].Height + yy, (bitmaps[x, y]).GetPixel(xx, yy));
                        }
                    }
                }
            }
            if (SfdSave.ShowDialog() == DialogResult.OK)
            {
                strPath = SfdSave.FileName.ToString();
            }
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
            btmBitSave.Save(strPath);
            btmBitSave.Dispose();
        }

        private void BtnExtraction_Click(object sender, EventArgs e)
        {
            if (!DataSaver.bolExtraction)
            {
                DataSaver.bolExtraction = true;
                DataSaver.bolPaint = false;
                DataSaver.intMirror = 0;
                DataSaver.bolCut = false;
                DataSaver.bmmNow.bolDragOn = false;
                BtnExtraction.BackColor = Color.Green;
                BtnPaint.BackColor = SystemColors.Control;
                BtnMIrror.BackColor = SystemColors.Control;
                BtnCut.BackColor = SystemColors.Control;
                DataSaver.bmmNow.ReDrawing();
                if (DataSaver.grpMirror != null)
                {
                    DataSaver.grpMirror.Clear(DataSaver.bmmNow.BackColor);
                }
            }
            else
            {
                DataSaver.bolExtraction = false;
                BtnExtraction.BackColor = SystemColors.Control;
            }
        }

        private void Pencil_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.pclNow = null;
        }

        private void BtnPaint_Click(object sender, EventArgs e)
        {
            switch (DataSaver.bmmNow.intNowLayer)
            {
                case 0:
                    if (DataSaver.intLayerTP[4] == 19 && DataSaver.intLayerTP[3] == 72 && DataSaver.intLayerTP[2] == 11 && DataSaver.intLayerTP[1] == 21)
                    {
                        if (!bolEsterEgg)
                        {
                            PaintSetter paintSetter = new PaintSetter();
                            paintSetter.Show();
                            bolEsterEgg = true;
                        }
                    }
                    break;
                case 1:
                    if (DataSaver.intLayerTP[4] == 19 && DataSaver.intLayerTP[3] == 72 && DataSaver.intLayerTP[2] == 11 && DataSaver.intLayerTP[0] == 21)
                    {
                        if (!bolEsterEgg)
                        {
                            PaintSetter paintSetter = new PaintSetter();
                            paintSetter.Show();
                            bolEsterEgg = true;
                        }
                    }
                    break;
                case 2:
                    if (DataSaver.intLayerTP[4] == 19 && DataSaver.intLayerTP[3] == 72 && DataSaver.intLayerTP[1] == 11 && DataSaver.intLayerTP[0] == 21)
                    {
                        if (!bolEsterEgg)
                        {
                            PaintSetter paintSetter = new PaintSetter();
                            paintSetter.Show();
                            bolEsterEgg = true;
                        }
                    }
                    break;
                case 3:
                    if (DataSaver.intLayerTP[4] == 19 && DataSaver.intLayerTP[2] == 72 && DataSaver.intLayerTP[1] == 11 && DataSaver.intLayerTP[0] == 21)
                    {
                        if (!bolEsterEgg)
                        {
                            PaintSetter paintSetter = new PaintSetter();
                            paintSetter.Show();
                            bolEsterEgg = true;
                        }
                    }
                    break;
                case 4:
                    if (DataSaver.intLayerTP[3] == 19 && DataSaver.intLayerTP[2] == 72 && DataSaver.intLayerTP[1] == 11 && DataSaver.intLayerTP[0] == 21)
                    {
                        if (!bolEsterEgg)
                        {
                            PaintSetter paintSetter = new PaintSetter();
                            paintSetter.Show();
                            bolEsterEgg = true;
                        }
                    }
                    break;
            }
            if (!DataSaver.bolPaint)
            {
                DataSaver.bolPaint = true;
                DataSaver.bolExtraction = false;
                DataSaver.intMirror = 0;
                DataSaver.bolCut = false;
                DataSaver.bmmNow.bolDragOn = false;
                BtnPaint.BackColor = Color.Green;
                BtnExtraction.BackColor = SystemColors.Control;
                BtnMIrror.BackColor = SystemColors.Control;
                BtnCut.BackColor = SystemColors.Control;
                DataSaver.bmmNow.ReDrawing();
                if (DataSaver.grpMirror != null)
                {
                    DataSaver.grpMirror.Clear(DataSaver.bmmNow.BackColor);
                }
            }
            else
            {
                DataSaver.bolPaint = false;
                BtnPaint.BackColor = SystemColors.Control;
            }
        }

        private void BtnMIrror_Click(object sender, EventArgs e)
        {
            if (DataSaver.intMirror == 0)
            {
                DataSaver.bolPaint = false;
                DataSaver.bolExtraction = false;
                DataSaver.intMirror = 1;
                DataSaver.bolCut = false;
                DataSaver.bmmNow.bolDragOn = false;
                BtnPaint.BackColor = SystemColors.Control;
                BtnExtraction.BackColor = SystemColors.Control;
                BtnCut.BackColor = SystemColors.Control;
                BtnMIrror.BackColor = Color.Blue;
                RtbMirror_TextChanged(sender, e);
                DataSaver.bmmNow.ReDrawing();
            }
            else if (DataSaver.intMirror == 1)
            {
                DataSaver.intMirror = 2;
                BtnMIrror.BackColor = Color.Red;
                RtbMirror_TextChanged(sender, e);
            }
            else
            {
                DataSaver.intMirror = 0;
                BtnMIrror.BackColor = SystemColors.Control;
                RtbMirror_TextChanged(sender, e);
            }
        }

        private void RtbMirror_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSaver.intMirrorValue = int.Parse(RtbMirror.Text);
                DataSaver.grpMirror = DataSaver.bmmNow.CreateGraphics();
                DataSaver.grpMirror.Clear(DataSaver.bmmNow.BackColor);
                if (DataSaver.intMirror == 1)
                {
                    DataSaver.grpMirror.DrawLine(new Pen(Color.White),
                                        new Point(0, DataSaver.intSize * DataSaver.intMirrorValue + DataSaver.bmmNow.Pnl.Location.Y),
                                        new Point(DataSaver.bmmNow.Width, DataSaver.intSize * DataSaver.intMirrorValue + DataSaver.bmmNow.Pnl.Location.Y));
                }
                else if (DataSaver.intMirror == 2)
                {
                    DataSaver.grpMirror.DrawLine(new Pen(Color.White),
                                         new Point(DataSaver.intSize * int.Parse(RtbMirror.Text) + DataSaver.bmmNow.Pnl.Location.X, 0),
                                         new Point(DataSaver.intSize * int.Parse(RtbMirror.Text) + DataSaver.bmmNow.Pnl.Location.X, DataSaver.bmmNow.Height));
                }
            }
            catch
            {

            }
        }

        private void RtbColor_TextChanged(object sender, EventArgs e)
        {
            if (!bolColorDialog && !DataSaver.bolExtraction && !bolSaveColorClick)
            {
                BtnChoice_Click(sender, e);
            }
        }

        private void Pbx_Click(object sender, EventArgs e)
        {
            bolSaveColorClick = true;
            DataSaver.nowRGBA = new RGBA(DataSaver.saveRGBA[((PictureBox)sender).Name[3] - 48 - 1]);
            RtbR.Text = DataSaver.nowRGBA.R.ToString();
            RtbG.Text = DataSaver.nowRGBA.G.ToString();
            RtbB.Text = DataSaver.nowRGBA.B.ToString();
            RtbA.Text = DataSaver.nowRGBA.A.ToString();
            PbxColor.BackColor = DataSaver.saveRGBA[((PictureBox)sender).Name[3] - 48 - 1].ColorReturn();
            bolSaveColorClick = false;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            DataSaver.saveRGBA[((Button)sender).Name[3] - 48 - 1] = new RGBA(DataSaver.nowRGBA);
            switch (((Button)sender).Name[3] - 48 - 1)
            {
                case 0: Pbx1.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 1: Pbx2.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 2: Pbx3.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 3: Pbx4.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 4: Pbx5.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 5: Pbx6.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
                case 6: Pbx7.BackColor = DataSaver.nowRGBA.ColorReturn(); break;
            }
        }

        private void BtnZoom_Click(object sender, EventArgs e)
        {
            DataSaver.bmmNow.ZoomReset();
        }

        private void BtnLayer_Click(object sender, EventArgs e)
        {
            if (DataSaver.lyeNow == null)
            {
                Layer rayer = new Layer();
                DataSaver.lyeNow = rayer;
                rayer.Show();
            }
        }

        private void BtnNewSave_Click(object sender, EventArgs e)
        {
            if (SfdNewSave.ShowDialog() == DialogResult.OK)
            {
                string strPath = SfdNewSave.FileName.ToString();
                if (File.Exists(strPath))
                {
                    File.Delete(strPath);
                }
                string strSaveTxt = "";
                strSaveTxt += "WTD";
                strSaveTxt += DataSaver.intWidth.ToString("D4");
                strSaveTxt += DataSaver.intHeight.ToString("D4");
                strSaveTxt += DataSaver.HIGH_RAYER;
                for (int i = 0; i < DataSaver.HIGH_RAYER; i++)
                {
                    strSaveTxt += DataSaver.intLayerTP[i].ToString("D3");
                }
                StreamWriter w = File.AppendText(strPath);
                w.Write(strSaveTxt);
                w.Write(":");
                string strTemp = "";
                int intReNum = 1;
                bool bolFirst = false;
                for (int r = 0; r < DataSaver.HIGH_RAYER; r++)
                {
                    for (int y = 0; y < DataSaver.intHeight; y++)
                    {
                        for (int x = 0; x < DataSaver.intWidth; x++)
                        {
                            string strUnicode = DataSaver.btmRGBA[x, y, r].RGBAtoUni16();
                            if (!bolFirst)
                            {
                                bolFirst = true;
                            }
                            else if (strTemp != strUnicode)
                            {
                                w.Write($"|{intReNum}:" + strTemp);
                                intReNum = 1;
                            }
                            else
                            {
                                intReNum++;
                            }
                            strTemp = strUnicode;
                            //strSaveTxt += strUnicode1;
                            //strSaveTxt += strUnicode2;
                        }
                    }
                }
                w.Write($"|{intReNum}:" + strTemp);
                w.Write("|");
                w.Close();
                //File.WriteAllText(strPath, strSaveTxt, Encoding.Default);
                //Writer(strPath, strSaveTxt);
            }
        }

        public void BtnZ_Click(object sender, EventArgs e)
        {
            try
            {
                DataSaver.btmRGBA = DataSaver.ctrlZ.Pop();
                DataSaver.btmRGBA = DataSaver.ctrlZ.Pop();
                DataSaver.ctrlZ.Push(DataSaver.btmRGBA);
                DataSaver.bmmNow.ReDrawing();
            }
            catch
            {

            }
        }

        public void BtnV_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataSaver.bolCopyMod)
                {
                    for (int x = 0; x < Math.Min(DataSaver.intWidth, DataSaver.copyRGBA.GetLength(0)); x++)
                    {
                        for (int y = 0; y < Math.Min(DataSaver.intHeight, DataSaver.copyRGBA.GetLength(1)); y++)
                        {
                            if (DataSaver.copyRGBA[x, y] != new RGBA())
                            {
                                DataSaver.btmRGBA[x, y, DataSaver.bmmNow.intNowLayer] = new RGBA(DataSaver.copyRGBA[x, y]);
                            }
                        }
                    }
                    DataSaver.ctrlZ.Push(DataSaver.btmRGBA);
                    DataSaver.bmmNow.ReDrawing();
                }
                else
                {
                    Bitmap ctrlV = (Bitmap)Clipboard.GetImage();
                    if (ctrlV == null)
                    {
                        return;
                    }
                    for (int x = 0; x < Math.Min(DataSaver.intWidth, ctrlV.Width); x++)
                    {
                        for (int y = 0; y < Math.Min(DataSaver.intHeight, ctrlV.Height); y++)
                        {
                            DataSaver.btmRGBA[x, y, DataSaver.bmmNow.intNowLayer] = new RGBA(ctrlV.GetPixel(x, y));
                        }
                    }
                    DataSaver.ctrlZ.Push(DataSaver.btmRGBA);
                    DataSaver.bmmNow.ReDrawing();
                }
            }
            catch
            {

            }
        }

        private void BtnCut_Click(object sender, EventArgs e)
        {
            if (!DataSaver.bolCut)
            {
                DataSaver.bolPaint = false;
                DataSaver.bolExtraction = false;
                DataSaver.intMirror = 0;
                DataSaver.bolCut = true;
                BtnPaint.BackColor = SystemColors.Control;
                BtnExtraction.BackColor = SystemColors.Control;
                BtnCut.BackColor = Color.Green;
                BtnMIrror.BackColor = SystemColors.Control;
                DataSaver.bmmNow.ReDrawing();
            }
            else
            {
                DataSaver.bolCut = false;
                DataSaver.bmmNow.bolDragOn = false;
                BtnCut.BackColor = SystemColors.Control;
                DataSaver.bmmNow.ReDrawing();
            }
        }

        private void BtnResize_Click(object sender, EventArgs e)
        {
            try
            {
                DataSaver.intWidth = int.Parse(RtbResizeW.Text);
                DataSaver.intHeight = int.Parse(RtbResizeH.Text);
                RGBA[,,] resizeRGBA = new RGBA[DataSaver.intWidth, DataSaver.intHeight, DataSaver.HIGH_RAYER];
                for (int x = 0; x < DataSaver.intWidth; x++)
                {
                    for (int y = 0; y < DataSaver.intHeight; y++)
                    {
                        for (int r = 0; r < DataSaver.HIGH_RAYER; r++)
                        {
                            if (DataSaver.btmRGBA.GetLength(0) > x && DataSaver.btmRGBA.GetLength(1) > y)
                            {
                                resizeRGBA[x, y, r] = new RGBA(DataSaver.btmRGBA[x, y, r]);
                            }
                            else
                            {
                                resizeRGBA[x, y, r] = new RGBA();
                            }
                        }
                    }
                }
                DataSaver.btmRGBA = resizeRGBA;
                DataSaver.ctrlZ = new CtrlZ();
                DataSaver.bmmNow.grpGrid = new Graphics[DataSaver.intWidth + 1 + DataSaver.intHeight + 1 + 1];
                DataSaver.bmmNow.grpBitMap = new Graphics[DataSaver.intWidth, DataSaver.intHeight];
                DataSaver.bmmNow.Pnl.Width = 800;
                DataSaver.bmmNow.Pnl.Height = 600;
                int intControlWidth = DataSaver.bmmNow.Pnl.Width / DataSaver.intWidth;
                int intControlHeight = DataSaver.bmmNow.Pnl.Height / DataSaver.intHeight;
                int intSize = Math.Min(intControlWidth, intControlHeight);
                DataSaver.bmmNow.Pnl.Width = intSize * DataSaver.intWidth;
                DataSaver.bmmNow.Pnl.Height = intSize * DataSaver.intHeight;
                DataSaver.intSize = intSize;
                DataSaver.bmmNow.intDefaultSize = intSize;
                for (int y = 0; y < DataSaver.intHeight; y++)
                {
                    for (int x = 0; x < DataSaver.intWidth; x++)
                    {
                        DataSaver.bmmNow.grpBitMap[x, y] = DataSaver.bmmNow.Pnl.CreateGraphics();
                    }
                }
                DataSaver.ctrlZ.Push(DataSaver.btmRGBA);
                DataSaver.startRGBA = (RGBA[,,])DataSaver.btmRGBA.Clone();
                DataSaver.bmmNow.ReDrawing();
            }
            catch
            {

            }
        }
    }
}
