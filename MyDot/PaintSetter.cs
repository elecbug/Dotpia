using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dotpia
{
    public partial class PaintSetter : Form
    {
        public PaintSetter()
        {
            InitializeComponent();
        }

        private void PaintSetter_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.pclNow.bolEsterEgg = false;
        }

        private void TrbB_Scroll(object sender, EventArgs e)
        {
            DataSaver.paintRGBA.B = TrbB.Value;
        }

        private void TrbG_Scroll(object sender, EventArgs e)
        {
            DataSaver.paintRGBA.G = TrbG.Value;
        }

        private void TrbR_Scroll(object sender, EventArgs e)
        {
            DataSaver.paintRGBA.R = TrbR.Value;
        }

        private void TrbA_Scroll(object sender, EventArgs e)
        {
            DataSaver.paintRGBA.A = TrbA.Value;
        }
    }
}
