using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        bool canPaint = false;
        Graphics g;
        int? prevX = null;
        int? prevY = null;
        bool drawSquare = false;
        bool drawRectangle = false;
        bool drawCircle = false;
        Point o = new Point();
        Point d = new Point();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            canPaint = true;
            if (drawSquare || drawRectangle || drawCircle)
            {
                o = new Point(e.X, e.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(toolStripButton3.BackColor, float.Parse(toolStripTextBox1.Text));
            canPaint = false;
            prevX = null;
            prevY = null;
            if (drawSquare || drawRectangle || drawCircle)
            {
                d = new Point(e.X, e.Y);
            }
            if (drawSquare)
            {
                g.DrawRectangle(pen, o.X, o.Y, (Math.Abs((e.X - o.X)) > Math.Abs((e.Y - o.Y)) ? Math.Abs((e.X - o.X)) : Math.Abs((e.X - o.X))), (Math.Abs((e.X - o.X)) > Math.Abs((e.Y - o.Y)) ? Math.Abs((e.X - o.X)) : Math.Abs((e.X - o.X))));
                drawSquare = false;
            }
            else if (drawRectangle)
            {
                g.DrawRectangle(pen, o.X, o.Y, Math.Abs((e.X - o.X)), Math.Abs((e.Y - o.Y)));
                drawRectangle = false;
            }
            else if (drawCircle)
            {
                g.DrawEllipse(pen, o.X, o.Y, (Math.Abs((e.X - o.X)) > Math.Abs((e.Y - o.Y)) ? Math.Abs((e.X - o.X)) : Math.Abs((e.X - o.X))), (Math.Abs((e.X - o.X)) > Math.Abs((e.Y - o.Y)) ? Math.Abs((e.X - o.X)) : Math.Abs((e.X - o.X))));
                drawCircle = false;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (canPaint && !(drawSquare || drawRectangle || drawCircle))
            {
                Pen pen = new Pen(toolStripButton3.BackColor, float.Parse(toolStripTextBox1.Text));
                g.DrawLine(pen, new Point(prevX ?? e.X, prevY ?? e.Y), new Point(e.X, e.Y));
                prevX = e.X;
                prevY = e.Y;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                toolStripButton3.BackColor = cd.Color;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                toolStripButton4.BackColor = cd.Color;
                panel1.BackColor = cd.Color;
            }
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawSquare = true;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawRectangle = true;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawCircle = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            g.Clear(panel1.BackColor);
        }
    }
}
