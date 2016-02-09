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
        public override int countOfState
        {
            get { return 1; }
        }
        //Конструктор
        public Square(Color clr)
            : base(clr)
        {
            Random rnd = new Random();
            LeftPoint = new Point(rnd.Next(0, 13) * 15, 0);
        }
        //Методы
        public override void rotate()
        {
            this.State = (this.State + 1) % this.countOfState;
            this.LeftPoint = this.LeftPoint;
        }
    }
}
