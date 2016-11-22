using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarWarsTrench
{
    public partial class Form1 : Form
    {
        Pen solidWhite, solidRed;
        Brush whiteBrush;
        bool initiate, xWing = true;
        int cx, cy;
        public Form1()
        {
            InitializeComponent();
            solidWhite = new Pen(Color.White); solidRed = new Pen(Color.Red);
            whiteBrush = new SolidBrush(Color.White);
            initiationLabel.Text = "Confidential mission document, click\nhere to begin";
            cx = this.Width / 2; cy = this.Height / 2;
        }

        private void timer_Tick(object sender, EventArgs e)
        {            
            this.Refresh();
        }

        private void initiationLabel_Click(object sender, EventArgs e)
        {
            initiationLabel.Text = "";
            pictureBox1.Dispose();
            initiate = true;
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            if (initiate)
            {
                #region Draw Death Star
                e.Graphics.DrawEllipse(solidWhite, cx - 100, cy - 100, 200, 200);
                e.Graphics.DrawEllipse(solidWhite, cx - 70, cy - 70, 60, 60);
                e.Graphics.DrawLine(solidWhite, 100, 215, 300, 215);
                e.Graphics.DrawLine(solidRed, cx, cy - 80, 200, 215);
                e.Graphics.DrawRectangle(solidWhite, cx - 10, cy - 100, 20, 20);
                e.Graphics.DrawEllipse(solidRed, cx - 10, cy + 5, 20, 20);

                e.Graphics.FillRectangle(whiteBrush, 5, 50, 10, 10);
                #endregion

                while (xWing)
                {

                }
            }
        }
    }
}
