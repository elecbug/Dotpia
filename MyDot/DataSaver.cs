using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotpia
{
    public static class DataSaver
    {
        public static int intWidth = 0;
        public static int intHeight = 0;
        public static RGBA nowRGBA = new RGBA();
        public const int HIGH_RAYER = 5;
        public static RGBA[,,] btmRGBA;
        public static BitMapMain bmmNow = null;
        public static Pencil pclNow = null;
        public static RGBA clickRGBA = new RGBA();
        public static bool bolExtraction;
        public static bool bolPaint;
        public static int intMirror;
        public static int intStrMirror;
        public static Graphics g;
        public static int intSize;
        public static RGBA[] saveRGBA = new RGBA[7];
        public static Layer lyeNow;
        public static int[] intLayerTP;
        public static Stack<int> intPaintX;
        public static Stack<int> intPaintY;
    }
}