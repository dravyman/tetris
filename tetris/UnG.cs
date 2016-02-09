using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class UnG :Figure
    {
        //Поля
        public override List<Point> FillPoints
        {
            get 
            {
                List<Point> result = new List<Point>();
                switch (this.State)
                {
                    case 0:
                        result.Add(LeftPoint);
                        result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y));
                        result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y + Width));
                        result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y + 2 * Width));
                        break;
                    case 1:
                        result.Add(LeftPoint);
                        result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y));
                        result.Add(new Point(LeftPoint.X + 2* Width, LeftPoint.Y));
                        result.Add(new Point(LeftPoint.X + 2* Width, LeftPoint.Y - Width));
                        break;
                    case 2:
                        result.Add(LeftPoint);
                        result.Add(new Point(LeftPoint.X, LeftPoint.Y + Width));
                        result.Add(new Point(LeftPoint.X, LeftPoint.Y + 2 * Width));
                        result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y + 2 * Width));
                        break;
                    case 3:
                        result.Add(LeftPoint);
                        result.Add(new Point(LeftPoint.X, LeftPoint.Y + Width));
                        result.Add(new Point(LeftPoint.X + Width, LeftPoint.Y));
                        result.Add(new Point(LeftPoint.X + 2 * Width, LeftPoint.Y));
                        break;
                }
                return result;
            }
        }
        public override int countOfState
        {
            get { return 4; }
        }
        public UnG(Color clr) 
        //Конструктор
        : base(clr) 
        {
            Random rnd = new Random();
            int lol = rnd.Next(-1,this.countOfState);
            this.State = lol;
            switch (this.State)
            { 
                case 0:
                    this.LeftPoint = new Point(rnd.Next(0, 13) * 15, 0);
                    break;
                case 1:
                    this.LeftPoint = new Point(rnd.Next(0,12)*15,0);
                    break;
                case 2:
                    this.LeftPoint = new Point(rnd.Next(0, 13) * 15, 0);
                    break;
                case 4:
                    this.LeftPoint = new Point(rnd.Next(0, 12) * 15, 0);
                    break;
            }
        }
        //Методы
        public override void rotate()
        {
            this.State = (this.State + 1) % this.countOfState;
            switch (this.State)
            {
                case 0:
                    LeftPoint = new Point(LeftPoint.X- Width, LeftPoint.Y);
                    break;
                case 1:
                    LeftPoint = new Point(LeftPoint.X - Width, LeftPoint.Y);
                    break;
                case 2:
                    LeftPoint = new Point(LeftPoint.X + 2 * Width, LeftPoint.Y - 2*Width);
                    break;
                case 3:
                    LeftPoint = new Point(LeftPoint.X, LeftPoint.Y + 2 * Width);
                    break;

            }
        }
    }
}
