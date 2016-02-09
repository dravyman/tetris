using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Square :Figur
    {
        public override Point LeftPoint{get;set;}

        public Square(Color clr) : base(clr) { }

        public override List<Point> FillPoints
        {
            get
            {
                List<Point> result = new List<Point>();
                result.Add(LeftPoint);
                result.Add(new Point(LeftPoint.X, LeftPoint.Y + Width));
                result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y + Width));
                result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y));
                return result;
            }

        }

        public override Point RightPoint
        {
            get
            {
                Point res = LeftPoint;
                foreach (Point pn in FillPoints)
                {
                    if (res.X < pn.X)
                        res = pn;
                }
                return res;
            }
        }
        
        public override Point BottomPoint
        {
            get
            {
                Point res = LeftPoint;
                foreach (Point pn in FillPoints)
                {
                    if (res.Y < pn.Y)
                        res = pn;
                }
                return res;
            }
        }

        public override void paintFigure(Graphics gr)
        {
            SolidBrush br = new SolidBrush(this.clr);
            Pen pn = new Pen(Color.Black, 1);
            foreach (Point pt in this.FillPoints)
            {
                gr.FillRectangle(br, pt.X, pt.Y, Width, Width);
                gr.DrawRectangle(pn, pt.X, pt.Y, Width, Width);
            }
        }
        public override void stepFigure()
        {
            this.LeftPoint = new Point(this.LeftPoint.X, this.LeftPoint.Y + Width);
        }
    }
}
