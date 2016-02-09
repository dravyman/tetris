using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    abstract class Figure
    {
        //Поля
        public abstract Point LeftPoint { get; set; }
        public Point RightPoint
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
        public Point BottomPoint
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
        public abstract List<Point> FillPoints{get;}
        public abstract int State { get; set; }
        public int Width {get{return 15;}}
        public Color clr;
        //Конструктор
        public Figure(Color clr)
        {
            Random rnd = new Random();
            this.clr = clr;
            LeftPoint = new Point(rnd.Next(0,13) * 15,0);
            clr = Color.Yellow;
        }
        //Методы
        public void stepFigure()
        {
            this.LeftPoint = new Point(this.LeftPoint.X, this.LeftPoint.Y + Width);
        }
        public void paintFigure(Graphics gr)
        {
            SolidBrush br = new SolidBrush(this.clr);
            Pen pn = new Pen(Color.Black, 1);
            foreach (Point pt in this.FillPoints)
            {
                gr.FillRectangle(br, pt.X, pt.Y, Width, Width);
                gr.DrawRectangle(pn, pt.X, pt.Y, Width, Width);
            }
        }
        public abstract void rotate();
    }
}




