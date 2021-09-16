using System;
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
    public partial class Rayer : Form
    {
        public Rayer()
        {
            InitializeComponent();
        }

        private void Rayer_Load(object sender, EventArgs e)
        {

        }

        private void Rayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.ryeNow = null;
        }

        private void Cbx_CheckedChanged(object sender, EventArgs e)
        {
            DataSaver.bmmNow.intNowRayer = int.Parse($"{((RadioButton)sender).Name[3]}");
        }

        private void Rtb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSaver.intRayerTP[int.Parse($"{ ((RichTextBox)sender).Name[3]}")] = int.Parse(((RichTextBox)sender).Text);
                DataSaver.bmmNow.ReDrawing();
            }
            catch
            {

            }
        }


        private void RtbKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
