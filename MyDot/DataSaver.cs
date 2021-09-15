using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDot
{
    public static class DataSaver
    {
        public static int intWidth = 0;
        public static int intHeight = 0;
        public static RGBA nowRGBA = new RGBA();
        public static RGBA[,] btmRGBA;
        public static BitMapMain bmmNow = null;
        public static Pencil pclNow = null;
        public static RGBA clickRGBA = new RGBA();
        public static bool bolExtraction;
        public static bool bolPaint;
        public static int intMirror;
        public static int intStrMirror;
        public static Graphics g;
        public static int intSize;
    }

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
    }
}
