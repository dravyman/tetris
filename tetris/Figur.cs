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
        public Point leftPoint, rightPoint, bottomPoint;
        List<Point> fillPoint = new List<Point>();
        int width = 15;
        public Figur(Color clr)
        {
            this.clr = clr;
            leftPoint = new Point(40,0);
            rightPoint = new Point(leftPoint.X + width, leftPoint.Y);
            bottomPoint = new Point(leftPoint.X, leftPoint.Y + width);
            clr = Color.Yellow;
        }

        public List<Point> getFillPoints()
        {
            List<Point> result = new List<Point>();
            result.Add(leftPoint);
            result.Add(new Point(leftPoint.X, leftPoint.Y + width));
            result.Add(new Point(leftPoint.X + width, leftPoint.Y + width));
            result.Add(new Point(leftPoint.X + width, leftPoint.Y));
            return result;
        }

        public void paintFigure(Graphics gr)
        {
            SolidBrush br = new SolidBrush(Color.Yellow);
            Pen pn = new Pen(Color.Black,1);
            foreach (Point pt in this.getFillPoints())
            {
                gr.FillRectangle(br, pt.X, pt.Y, width, width);
                gr.DrawRectangle(pn, pt.X, pt.Y, width, width);
            }
        }

        public void stepFigure()
        {
            this.leftPoint = new Point(this.leftPoint.X, this.leftPoint.Y + width);
            this.rightPoint = new Point(this.leftPoint.X + width, this.leftPoint.Y);
            this.bottomPoint = new Point(this.leftPoint.X,this.leftPoint.Y + width);
        }
    }
}
