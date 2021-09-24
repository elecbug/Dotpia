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
        public static Start nowStart;       
        public static Pencil pclNow = null;
        public static BitMapMain bmmNow = null;
        public static Layer lyeNow;

        public static RGBA[,,] btmRGBA;
        public static RGBA[,,] startRGBA;
        public static RGBA[,] dragRGBA;
        public static RGBA[,] copyRGBA;
        public static RGBA[] saveRGBA = new RGBA[7];
        public static RGBA nowRGBA = new RGBA();
        public static RGBA paintRGBA = new RGBA();
        public static RGBA clickRGBA = new RGBA();

        public static Graphics grpMirror;
        public static CtrlZ ctrlZ;
     
        public static int intWidth = 0;
        public static int intHeight = 0;
        public const int HIGH_RAYER = 5;
        public static int intSize;
        public static int[] intLayerTP;

        public static bool bolExtraction;
        public static bool bolPaint;
        public static int intMirror;
        public static int intMirrorValue;
        public static bool bolCut;
        public static bool bolCopyMod;
    }
}