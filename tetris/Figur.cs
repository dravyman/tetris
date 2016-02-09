using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    abstract class Figur
    {
        public abstract Point LeftPoint { get; set; }
        public abstract Point RightPoint { get; }
        public abstract Point BottomPoint { get; }
        public abstract List<Point> FillPoints{get;}
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

    }
}




