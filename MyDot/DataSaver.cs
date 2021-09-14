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
        public static int intHeigth = 0;
        public static RGBA nowRGBA = new RGBA();
        public static RGBA[,] btmRGBA;
    }

    public class RGBA
    {
        public int R;
        public int G;
        public int B;
        public int A;
        private bool bolCheak;

        public RGBA()
        {
            R = 0;
            G = 0;
            B = 0;
            A = 0;
            bolCheak = true;
        }

        public RGBA(int R, int G, int B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = 255;
            bolCheak = true;
        }

        public RGBA(int R, int G, int B, int A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
            bolCheak = true;
        }

        public RGBA(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
            bolCheak = true;
        }

        public Color ColorReturn()
        {
            Color color = Color.FromArgb(A, R, G, B);
            return color;
        }
    }
}
