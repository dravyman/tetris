﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int width = 15;
        Figur fallFigur = new Figur(Color.Yellow);
        bool[,] tetr = new bool[14,20];
        List<Point> liyPoints = new List<Point>();
        public enum KeyPressed
        {
            None, A, D
        }
        private KeyPressed lastKey = KeyPressed.None;
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            start.Text = timer1.Enabled.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (lastKey)
            {
                case KeyPressed.A:
                    if (canLeft(fallFigur))
                    {
                        fallFigur.leftPoint = new Point(fallFigur.leftPoint.X - width, fallFigur.leftPoint.Y);
                        pictureBox1.Invalidate();
                    }
                    break;
                case KeyPressed.D:
                    if (canRight(fallFigur))
                    {
                        fallFigur.leftPoint = new Point(fallFigur.leftPoint.X + width, fallFigur.leftPoint.Y);
                        pictureBox1.Invalidate();
                    }
                    break;
            }

            if (canFall(fallFigur))
            {
                //fallFigur.clearFigure(pictureBox1.CreateGraphics());
                fallFigur.stepFigure();
                
            }
            else 
            {
                liyPoints.AddRange(fallFigur.FillPoints);
                foreach (Point pn in fallFigur.FillPoints)
                {
                    tetr[pn.X / width, pn.Y / width] = true;
                }
                checkLine();
                fallFigur = new Figur(Color.Yellow);
                
            }
            pictureBox1.Invalidate();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    lastKey = KeyPressed.A;
                    break;
                case Keys.D:
                    lastKey = KeyPressed.D;
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    lastKey = KeyPressed.None;
                    break;
                case Keys.D:
                    lastKey = KeyPressed.None;
                    break;
            }
        }

            private bool canFall(Figur fg)
            {
            bool result = true;
            Rectangle rect1 = new Rectangle(fg.BottomPoint, new Size(width, width));
            Rectangle rect2 = new Rectangle(pictureBox1.Location.X - 1, pictureBox1.Location.Y,
                            pictureBox1.ClientSize.Width + 1, pictureBox1.ClientSize.Height - 2 * width);
            result = rect1.IntersectsWith(rect2);
            foreach (Point point in liyPoints)
            {
                foreach (Point point2 in fg.FillPoints)
                {
                    if (point.Equals(new Point(point2.X, point2.Y + width)))
                        return false;
                }
            }
            return result;

        }
        private bool canLeft(Figur fg)
        {
            bool result = fg.LeftPoint.X - width >= 0;
            foreach (Point point in liyPoints)
            {
                foreach (Point point2 in fg.FillPoints)
                {
                    if (point.Equals(new Point(point2.X - width, point2.Y)))
                        return false;
                }
            }
            return result;
        }
        private bool canRight(Figur fg)
        {
            bool result = fg.RightPoint.X + width < pictureBox1.Width - 1;
            foreach (Point point in liyPoints)
            {
                foreach (Point point2 in fg.FillPoints)
                {
                    if (point.Equals(new Point(point2.X + width, point2.Y)))
                        return false;
                }
            }

            return result;
        }

        private void checkLine()
        {
            for (int i = 0; i < tetr.GetLength(1); i++)
            {
                bool lineAble = true;
                for (int j = 0; j < tetr.GetLength(0); j++)
                {
                    lineAble = lineAble && tetr[j,i];
                }
                if (lineAble)
                {
                    for (int j = 0; j < tetr.GetLength(0); j++)
                    {
                        tetr[j, i] = false;
                        for (int k = i; k > 0; k--)
                        {
                            tetr[j, k] = tetr[j, k - 1];
                        }
                    }
                    liyPoints.Clear();
                    for (int i1 = 0; i1 < tetr.GetLength(0); i1++)
                    {
                        for (int j = 0; j < tetr.GetLength(1); j++)
                        {
                            if (tetr[i1, j])
                            {
                                Point pt = new Point(i1 * 15, j * 15);
                                liyPoints.Add(pt);
                            }
                        }
                    }
                }
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush br = new SolidBrush(Color.Gainsboro);

            //fallFigur.clearFigure(e.Graphics);
            //fallFigur.stepFigure();
            fallFigur.paintFigure(e.Graphics);
            paintLieFigure(e.Graphics);
        }

        private void paintLieFigure(Graphics gr)
        {
            SolidBrush br = new SolidBrush(Color.Yellow);
            Pen pn = new Pen(Color.Black, 1);
            foreach (Point pt in liyPoints)
            {
                gr.FillRectangle(br, pt.X, pt.Y, width, width);
                gr.DrawRectangle(pn, pt.X, pt.Y, width, width);
            }
            // Отрисовка красных точек
            for (int i = 0; i < tetr.GetLength(0); i++)
            {
                for (int j = 0; j < tetr.GetLength(1); j++)
                {
                    if (tetr[i,j])
                    {
                        //Point pt = new Point(i * 15, j * 15);
                        //gr.FillRectangle(br, pt.X, pt.Y, width, width);
                        //gr.DrawRectangle(pn, pt.X, pt.Y, width, width);
                        SolidBrush Brush = new SolidBrush(Color.Red);
                        gr.FillEllipse(Brush, new Rectangle(new Point(i * 15, j * 15), new Size(5, 5)));
                    }
                }
            }
        }




    }
}
