using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadoonBotLogic_2._0_.objects
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public static Point zero;
        static public double Dist(Point A,Point B)
        {
            return Math.Sqrt((A.x - B.x)*(A.x - B.x) + (A.y - B.y) * (A.y - B.y));
        }
        static Point()
        {
            zero = new Point(0, 0);
        }
        public Point(double X,double Y)
        {
            this.x = X;
            this.y = Y;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Point))
                return false;
            Point temp = obj as Point;
            return ((this.x == temp.x) && (this.y == temp.y));
        }
        public string ToString()
        {
            return $"({this.x};{this.y})";
        }
    }
}
