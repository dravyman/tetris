using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Line : Figure
    {
        //Поля
        public override List<Point> FillPoints
        {
            get
            {
                List<Point> result = new List<Point>();
                switch(this.State)
                {
                    case 0:
                        result.Add(LeftPoint);
                        result.Add(new Point(LeftPoint.X, LeftPoint.Y + Width));
                        result.Add(new Point(LeftPoint.X, LeftPoint.Y + 2*Width));
                        result.Add(new Point(LeftPoint.X, LeftPoint.Y + 3*Width));
                        break;
                    case 1:
                        result.Add(LeftPoint);
                        result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y));
                        result.Add(new Point(LeftPoint.X + 2 * Width, LeftPoint.Y));
                        result.Add(new Point(LeftPoint.X + 3 * Width, LeftPoint.Y));
                        break;
                }
                return result;
            }
        }
        public override int countOfState
        {
            get { return 2; }
        }
        //Конструктор
        public Line(Color clr) 
        : base(clr) 
        {
            Random rnd = new Random();
            int lol = rnd.Next(0,this.countOfState);
            this.State = lol;
            switch (this.State)
            { 
                case 0:
                    this.LeftPoint = new Point(rnd.Next(0, 14) * 15, 0);
                    break;
                case 1:
                    this.LeftPoint = new Point(rnd.Next(0,11)*15,0);
                    break;
            }
        }
        //Методы
        public override void rotate()
        {
            this.State = (this.State + 1) % this.countOfState;
            this.LeftPoint = this.LeftPoint;
        }
    }
}
