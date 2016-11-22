using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarWarsTrench
{
    public partial class Form1 : Form
    {
        Pen solidWhite, solidRed;
        Brush whiteBrush, orangeBrush;
        bool initiate, mission, expl = true, xWing = true;
        int cx, cy, xCoord = 10;
        int xSize = 5, ySize = 5;

        public Form1()
        {
            InitializeComponent();
            solidWhite = new Pen(Color.White); solidRed = new Pen(Color.Red);
            whiteBrush = new SolidBrush(Color.White); orangeBrush = new SolidBrush(Color.Orange);
            initiationLabel.Text = "Confidential mission document, click\nhere to begin";
            cx = this.Width / 2; cy = this.Height / 2;
        }

        private void initiationLabel_Click(object sender, EventArgs e)
        {
            initiationLabel.Text = "Press f to use the force, Luke.";
            pictureBox1.Dispose();
            timer.Enabled = true;
            initiate = true;
            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && xCoord >= cx - 20 && xCoord <= cx + 20)
            {
                initiationLabel.ForeColor = Color.Green;
                initiationLabel.Text = "Mission Success, well done.";
                mission = true;
                if (xCoord == 350)  //rect goes on forever
                {
                    timer.Enabled = false;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            xCoord += 10;
            if (xCoord >= 350 && mission != true)
            {
                timer.Enabled = false;
                initiationLabel.ForeColor = Color.Red;
                initiationLabel.Text = "Mission failed.";
            }
            if (mission && expl)
            {
                for (int x = 0; x < 10; x +=1)
                {
                    xSize++; ySize++;
                }
            }
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            if (initiate)
            {
                e.Graphics.FillRectangle(whiteBrush, xCoord, 50, 15, 15);
                #region Draw Death Star
                e.Graphics.DrawEllipse(solidWhite, cx - 100, cy - 100, 200, 200);
                e.Graphics.DrawEllipse(solidWhite, cx - 70, cy - 70, 60, 60);
                e.Graphics.DrawLine(solidWhite, 100, 215, 300, 215);
                e.Graphics.DrawLine(solidRed, cx, cy - 80, 200, 215);
                e.Graphics.DrawRectangle(solidWhite, cx - 10, cy - 100, 20, 20);
                e.Graphics.DrawEllipse(solidRed, cx - 10, cy + 5, 20, 20);
                #endregion                                                        

                if (mission == true && expl == true)
                {
                    e.Graphics.FillEllipse(orangeBrush, cx, cy, xSize, ySize);              
                }
            }
        }
    }
}
