using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotpia
{
    public class FalseArea
    {
        public int minX;
        public int minY;
        public int maxX;
        public int maxY;

        public FalseArea()
        {
            minX = -1;
            maxX = -1;
            minY = -1;
            maxY = -1;
        }

        public FalseArea(FalseArea a)
        {
            minX = a.minX;
            minY = a.minY;
            maxX = a.maxX;
            maxY = a.maxY;
        }

        public FalseArea(int[] ints)
        {
            minX = ints[0];
            maxX = ints[1];
            minY = ints[2];
            maxY = ints[3];
        }

        public static bool operator ==(FalseArea a, FalseArea b)
        {
            if (a.minX == b.minX
             && a.minY == b.minY
             && a.maxX == b.maxY
             && a.maxY == b.maxY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(FalseArea a, FalseArea b)
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

        public static void ArrayPlus(ref FalseArea[] a)
        {
            FalseArea[] returner = new FalseArea[a.Length + 1];

            for(int i=0;i<a.Length;i++)
            {
                returner[i] = a[i];
            }
            a = returner;
        }

        public static void ArrayMinus(ref FalseArea[] a)
        {
            FalseArea[] returner = new FalseArea[a.Length - 1];

            for (int i = 0; i < returner.Length; i++)
            {
                returner[i] = a[i];
            }
            a = returner;
        }
    }
}
