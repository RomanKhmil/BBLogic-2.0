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
        public string ToString()
        {
            return $"({this.x};{this.y})";
        }
    }
}
