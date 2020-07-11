using BadoonBotLogic_2._0_.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadoonBotLogic_2._0_.objects.Grid
{
    class GridCell
    {
        Point rt;
        Point lb;

        List<Point> _users;
        public GridCell(Point RightTop, Point LeftBottom)
        {
            this.rt = RightTop;
            this.lb = LeftBottom;
            _users = new List<Point>();
        }
        public Point GetRightTop()
        {
            return rt;
        }
        public Point GetLeftBottom()
        {
            return lb;
        }
        public List<Point> GetUsers()
        {
            return _users;
        }
        public void Add(Point point)
        {
            _users.Add(point);
        }
        public void Remove(Point point)
        {
            _users.Remove(point);
        }
        public string ToString()
        {
            return $"{{LB:{lb.ToString()},RT:{rt.ToString()}}}";
        }

    }
}
