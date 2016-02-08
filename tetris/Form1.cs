using System;
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
        int score = 0;
        int width = 15;
        Figur fallFigur = new Figur(Color.Yellow);
        bool[,] tetr = new bool[14,20];
        List<Point> liyPoints = new List<Point>();
        public enum KeyPressed
        {
            None, A, D, S
        }
        private KeyPressed lastKey = KeyPressed.None;
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer2.Enabled = timer1.Enabled = !timer1.Enabled;
            start.Text = timer1.Enabled.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (canFall(fallFigur))
            {
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
        private void timer2_Tick(object sender, EventArgs e)
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
                case KeyPressed.S:
                    timer1.Enabled=timer2.Enabled=false;
                    while (canFall(fallFigur))
                    {
                        fallFigur.stepFigure();
                    }
                    liyPoints.AddRange(fallFigur.FillPoints);
                    foreach (Point pn in fallFigur.FillPoints)
                    {
                        tetr[pn.X / width, pn.Y / width] = true;
                    }
                    checkLine();
                    fallFigur = new Figur(Color.Yellow);
                    pictureBox1.Invalidate();
                    timer1.Enabled = timer2.Enabled = true;
                    lastKey = KeyPressed.None;
                    break;
            }
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
                case Keys.S:
                    lastKey = KeyPressed.S;
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
                case Keys.S:
                    lastKey = KeyPressed.None;
                    break;
            }
        }

        private bool canFall(Figur fg)
            {
            bool result = fg.BottomPoint.Y + width < pictureBox1.Height - 1;
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
            int pow = 0;
            for (int i = 0; i < tetr.GetLength(1); i++)
            {
                bool lineAble = true;
                for (int j = 0; j < tetr.GetLength(0); j++)
                {
                    if (!tetr[j, i])
                    {
                        lineAble = false;
                        break;
                    }
                }
                if (lineAble)
                {
                    pow++;
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
            score += pow * pictureBox1.Width /(2 * width  )* 10 * pow;
            label1.Text = "Score: " + score;

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush br = new SolidBrush(Color.Gainsboro);
            fallFigur.paintFigure(e.Graphics);
            paintLieFigure(e.Graphics);
        }

        private void paintLieFigure(Graphics gr)
        {
            SolidBrush br = new SolidBrush(Color.Yellow);
            Pen pn = new Pen(Color.Black, 1);
            // Отрисовка лежащих фигур
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
                        SolidBrush Brush = new SolidBrush(Color.Red);
                        gr.FillEllipse(Brush, new Rectangle(new Point(i * 15, j * 15), new Size(5, 5)));
                    }
                }
            }
        }
    }
}
