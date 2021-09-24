using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotpia
{
    public class RGBA
    {
        public int R;
        public int G;
        public int B;
        public int A;

        public RGBA()
        {
            R = 0;
            G = 0;
            B = 0;
            A = 0;
        }

        public RGBA(int R, int G, int B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = 255;
        }

        public RGBA(int R, int G, int B, int A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }

        public RGBA(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }

        public Color ColorReturn()
        {
            Color color = Color.FromArgb(A, R, G, B);
            return color;
        }

        public RGBA(RGBA color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }

        public static bool operator ==(RGBA a, RGBA b)
        {
            if (a.R == b.R)
            {
                if (a.G == b.G)
                {
                    if (a.B == b.B)
                    {
                        if (a.A == b.A)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool operator !=(RGBA a, RGBA b)
        {
            if (a == b)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int RGBAtoUni1()
        {
            int returner;
            int R = this.R * 256;
            int G = this.G;
            returner = R + G;
            return returner;
        }

        public int RGBAtoUni2()
        {
            int returner;
            int B = this.B * 256;
            int A = this.A;
            returner = B + A;
            return returner;
        }

        public static bool Paint(RGBA a, RGBA b)
        {
            if (Math.Abs(a.R - b.R) <= DataSaver.paintRGBA.R)
            {
                if (Math.Abs(a.G - b.G) <= DataSaver.paintRGBA.G)
                {
                    if (Math.Abs(a.B - b.B) <= DataSaver.paintRGBA.B)
                    {
                        if (Math.Abs(a.A - b.A) <= DataSaver.paintRGBA.A)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public string RGBAtoUni16()
        {
            string returner = "";
            returner += R.ToString("X2");
            returner += G.ToString("X2");
            returner += B.ToString("X2");
            returner += A.ToString("X2");
            return returner;
        }
    }

    public class RGBAby1
    {
        public decimal R;
        public decimal G;
        public decimal B;
        public decimal A;

        public RGBAby1()
        {
            R = 0;
            G = 0;
            B = 0;
            A = 0;
        }

        public RGBAby1(decimal R, decimal G, decimal B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = 255;
        }

        public RGBAby1(decimal R, decimal G, decimal B, decimal A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }

        public RGBAby1(RGBAby1 a)
        {
            this.R = a.R;
            this.G = a.G;
            this.B = a.B;
            this.A = a.A;
        }
    }

    public class SaveBitMap
    {
        public RGBA[,,] data;

        public SaveBitMap()
        {
            data = null;
        }

        public SaveBitMap(RGBA[,,] bitMap)
        {
            data = (RGBA[,,])bitMap.Clone();
        }
    }

    public class CtrlZ
    {
        public SaveBitMap[] data;
        private decimal dcmMaxByte = 2m * 1024m * 1024m * 1024m;
        private int intArrayMax;

        public CtrlZ()
        {
            intArrayMax = (int)(dcmMaxByte / 16 / DataSaver.intWidth / DataSaver.intHeight / DataSaver.HIGH_RAYER);
            data = new SaveBitMap[0];
        }

        public void Push(RGBA[,,] push)
        {
            int intNowArrayLength = data.Length;
            if (intNowArrayLength < intArrayMax)
            {
                SaveBitMap[] tempBitMap = new SaveBitMap[intNowArrayLength + 1];
                for (int i = 0; i < data.Length; i++)
                {
                    tempBitMap[i] = data[i];
                }
                tempBitMap[intNowArrayLength] = new SaveBitMap(push);
                data = (SaveBitMap[])tempBitMap.Clone();
            }
            else
            {
                for (int i = 0; i < intNowArrayLength - 1; i++)
                {
                    data[i] = data[i + 1];
                }
                data[intNowArrayLength - 1] = new SaveBitMap(push);
            }
        }

        public RGBA[,,] Pop()
        {
            if (data.Length > 0)
            {
                SaveBitMap[] tempBitMap = new SaveBitMap[data.Length - 1];
                for (int i = 0; i < tempBitMap.Length; i++)
                {
                    tempBitMap[i] = data[i];
                }
                SaveBitMap temp;
                temp = new SaveBitMap(data[data.Length - 1].data);
                data = (SaveBitMap[])tempBitMap.Clone();
                return temp.data;
            }
            return DataSaver.startRGBA;
        }
    }
}
