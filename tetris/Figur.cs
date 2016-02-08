using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    abstract class Figur
    {
        public Point LeftPoint { get; set; }
        public Point RightPoint { get; set; }
        public Point BottomPoint { get; set; }
        public List<Point> FillPoints{get;set;}
        public int Width {get{return 15;}}
        public Color clr;

        public Figur(Color clr)
        {
            Random rnd = new Random();
            this.clr = clr;
            LeftPoint = new Point(rnd.Next(0,13) * 15,0);
            clr = Color.Yellow;
        }
        public abstract void stepFigure();
        public abstract void paintFigure(Graphics gr);
        /*
        public List<Point> FillPoints { get; }*/
        /*public void paintFigure(Graphics gr)
        {
            SolidBrush br = new SolidBrush(Color.Yellow);
            Pen pn = new Pen(Color.Black, 1);
            foreach (Point pt in this.FillPoints)
            {
                gr.FillRectangle(br, pt.X, pt.Y, Width, Width);
                gr.DrawRectangle(pn, pt.X, pt.Y, Width, Width);
            }
        }
        public void stepFigure()
        {

            this.LeftPoint = new Point(this.LeftPoint.X, this.LeftPoint.Y + Width);
        }*/
    }
}




