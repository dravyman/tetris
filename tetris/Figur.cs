using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Figur
    {
        Color clr;
        public Point leftPoint;
        int width = 15;
        public Figur(Color clr)
        {
            this.clr = clr;
            leftPoint = new Point(30,0);
            clr = Color.Yellow;
        }

        public List<Point> FillPoints
        {
            get 
            {
                List<Point> result = new List<Point>();
                result.Add(leftPoint);
                result.Add(new Point(leftPoint.X, leftPoint.Y + width));
                result.Add(new Point(leftPoint.X + width, leftPoint.Y + width));
                result.Add(new Point(leftPoint.X + width, leftPoint.Y));
                return result;
            }
            
        }

        public Point RightPoint
        {
            get
            {
                Point res = leftPoint;
                foreach (Point pn in FillPoints)
                {
                    if (res.X < pn.X)
                        res = pn;
                }
                return res;
            }
        }
        public Point LeftPoint
        {
            get
            {
                Point res = leftPoint;
                foreach (Point pn in FillPoints)
                {
                    if (res.X > pn.X)
                        res = pn;
                }
                return res;
            }
        }
        public Point BottomPoint
        {
            get
            {
                Point res = leftPoint;
                foreach (Point pn in FillPoints)
                {
                    if (res.Y < pn.Y)
                        res = pn;
                }
                return res;
            }
        }
        public void paintFigure(Graphics gr)
        {
            SolidBrush br = new SolidBrush(Color.Yellow);
            Pen pn = new Pen(Color.Black,1);
            foreach (Point pt in this.FillPoints)
            {
                gr.FillRectangle(br, pt.X, pt.Y, width, width);
                gr.DrawRectangle(pn, pt.X, pt.Y, width, width);
            }
        }
        public void clearFigure(Graphics gr)
        {
            SolidBrush br = new SolidBrush(Color.Transparent);
            Pen pn = new Pen(Color.Transparent, 1);
            foreach (Point pt in this.FillPoints)
            {
                gr.FillRectangle(br, pt.X, pt.Y, width, width);
                gr.DrawRectangle(pn, pt.X, pt.Y, width, width);
            }
        }

        public void stepFigure()
        {
            this.leftPoint = new Point(this.leftPoint.X, this.leftPoint.Y + width);
        }
    }
}




