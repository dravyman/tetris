using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Square :Figure
    {
        //Поля
        public override Point LeftPoint{get;set;}
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
        public override int State
        {
            get;
            set;
        }
        //Конструктор
        public Square(Color clr) : base(clr) { }
        //Методы
        public override void rotate()
        {
            this.State = 0;
            this.LeftPoint = this.LeftPoint;
        }
    }
}
