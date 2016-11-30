//Star wars trench run
//by Bailey, Nov 30, 2016
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
        Button restartButton;

        bool initiate, mission, restart, expl = true, starDraw = true;
        int cx, cy, xCoord = 10, yCoord;
        int growth = 1;

        public Form1()
        {
            InitializeComponent();
            cx = this.Width / 2; cy = this.Height / 2;
            yCoord = cy - 110;

            solidWhite = new Pen(Color.White); solidRed = new Pen(Color.Red);
            whiteBrush = new SolidBrush(Color.White); orangeBrush = new SolidBrush(Color.Orange);
            initiationLabel.Text = "Confidential mission document, click\nhere to begin";
        }

        private void initiationLabel_Click(object sender, EventArgs e)
        {
            initiationLabel.Text = "Press f to use the force, Luke.";
            pictureBox1.Visible = false;
            timer.Enabled = true;
            initiate = true;
            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && xCoord >= cx - 15 && xCoord <= cx + 15)
            {
                mission = true;
                initiationLabel.Text = "";
            }
            else if (e.KeyCode == Keys.F && xCoord < cx - 20 || xCoord > cx + 20)
            {
                initiationLabel.ForeColor = Color.Red;
                initiationLabel.Text = "Mission failed, bomb dropped off target.";
                ResetMethod();
                timer.Enabled = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            xCoord += 10;
            if (xCoord >= 300 && mission != true)
            {
                timer.Enabled = false;
                initiationLabel.ForeColor = Color.Red;
                initiationLabel.Text = "Mission failed.";
                ResetMethod();
                restartButton.Click += delegate
                {
                    Application.Restart();
                };
            }
            if (mission && expl)
            {
                for (int x = 0; x < 21; x += 1)
                {
                    yCoord++;
                    growth++;
                }
                this.Refresh();
            }
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            if (initiate)
            {
                e.Graphics.DrawString("X", new Font("Microsoft Sans Serif", 10.0f, FontStyle.Bold), whiteBrush, xCoord, 50);
                if (starDraw)
                {
                    #region Draw Death Star
                    e.Graphics.DrawArc(solidWhite, cx - 100, cy - 100, 200, 200, 277, 345); //main figure
                    e.Graphics.DrawEllipse(solidWhite, cx - 70, cy - 70, 60, 60); //offset circle
                    e.Graphics.DrawLine(solidWhite, cx - 100, cy + 20, cx + 100, cy + 20); //mid line
                    e.Graphics.DrawLine(solidRed, cx - 3, cy - 80, cx - 3, cy + 10); //red vertical line 1
                    e.Graphics.DrawLine(solidRed, cx + 3, cy - 80, cx + 3, cy + 10); //red vertical line 1
                    e.Graphics.DrawLine(solidWhite, cx - 13, cy - 100, cx - 3, cy - 80); //white line 1
                    e.Graphics.DrawLine(solidWhite, cx + 13, cy - 100, cx + 3, cy - 80); //white line 2
                    e.Graphics.DrawArc(solidRed, cx - 10, cy + 10, 20, 20, 273, 345); //main figure
                    #endregion
                }
                if (mission)
                {
                    e.Graphics.FillEllipse(whiteBrush, cx - 5, yCoord, 10, 10);
                }
                if (expl && yCoord >= 200)
                {
                    e.Graphics.FillEllipse(orangeBrush, cx - growth / 2, cy - growth / 2, growth, growth);
                    if (growth >= 400)
                    {
                        timer.Enabled = false;
                        starDraw = false;
                        growth = 0;
                    }
                    e.Graphics.DrawString("Mission Success.", new Font("Courier New", 20.0f, FontStyle.Bold), whiteBrush, cx - 130, cy);
                    ResetMethod(); 
                    {
                        restartButton.Click += delegate
                        {
                            Application.Restart();
                        };
                    } 
                }
            }
        }

        private void ResetMethod()
        {
            restartButton = new Button();
            restartButton.Location = new Point(cx - 50, cy + 100);
            this.Controls.Add(restartButton);
            restartButton.ForeColor = Color.White;
            restartButton.Text = "Restart";
        }
    }
}
