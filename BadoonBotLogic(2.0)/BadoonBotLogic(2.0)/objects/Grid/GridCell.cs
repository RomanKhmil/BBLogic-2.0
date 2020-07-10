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

        List<Person> users;
        public GridCell(Point RightTop, Point LeftBottom)
        {
            this.rt = RightTop;
            this.lb = LeftBottom;
        }
        public Point GetRightTop()
        {
            return rt;
        }
        public Point GetLeftBottom()
        {
            return lb;
        }
        public string ToString()
        {
            return $"{{LB:{lb.ToString()},RT:{rt.ToString()}}}";
        }

    }
}
