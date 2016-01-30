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
        int width = 15;
        Figur fallFigur = new Figur(Color.Yellow);
        bool[,] tetr = new bool[10,15];
        List<Point> liyPoints = new List<Point>(); 
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
            if (canFall(fallFigur))
            {
                fallFigur.stepFigure();
                panel1.Invalidate();
            }
            else 
            {
                liyPoints.AddRange(fallFigur.getFillPoints());
                fallFigur = new Figur(Color.Yellow);
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush br = new SolidBrush(Color.Gainsboro);
            e.Graphics.FillRectangle(br, panel1.Bounds);
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
        }

        private bool canFall(Figur fg)
        {
            bool result = true;
            Rectangle rect1 = new Rectangle(fg.bottomPoint, new Size(width,width));
            Rectangle rect2 = new Rectangle(panel1.Location.X + width,panel1.Location.Y,
                            panel1.ClientSize.Width - 2*width,panel1.ClientSize.Height - 2*width);
            result = rect1.IntersectsWith(rect2);
            foreach (Point point in liyPoints)
            { 
                foreach (Point point2 in fg.getFillPoints())
                {
                    if (point.Equals(new Point(point2.X, point2.Y + width)))
                        return false;
                }
            }
            return result;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (canFall(new F))
                        fallFigur.leftPoint = new Point(fallFigur.leftPoint.X - width, fallFigur.leftPoint.Y);
                    break;
                case Keys.D:
                    if (canFall(fallFigur))
                        fallFigur.leftPoint = new Point(fallFigur.leftPoint.X + width, fallFigur.leftPoint.Y);
                    break;
            }
        }
    }
}
