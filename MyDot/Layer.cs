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
    public partial class Layer : Form
    {
        public Layer()
        {
            InitializeComponent();
        }

        private void Rayer_Load(object sender, EventArgs e)
        {
            Rtb0.Text = DataSaver.intLayerTP[0].ToString();
            Rtb1.Text = DataSaver.intLayerTP[1].ToString();
            Rtb2.Text = DataSaver.intLayerTP[2].ToString();
            Rtb3.Text = DataSaver.intLayerTP[3].ToString();
            Rtb4.Text = DataSaver.intLayerTP[4].ToString();
        }

        private void Rayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataSaver.lyeNow = null;
        }

        private void Cbx_CheckedChanged(object sender, EventArgs e)
        {
            DataSaver.bmmNow.intNowLayer = int.Parse($"{((RadioButton)sender).Name[3]}");
        }

        private void Rtb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSaver.intLayerTP[int.Parse($"{ ((RichTextBox)sender).Name[3]}")] = int.Parse(((RichTextBox)sender).Text);
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