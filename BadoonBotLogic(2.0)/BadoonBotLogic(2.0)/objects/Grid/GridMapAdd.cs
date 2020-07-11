using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadoonBotLogic_2._0_.objects.Grid
{
    public partial class GridMap
    {
        partial void _add(Point user)
        {
            bool inside(GridCell A, Point B)
            {
                if (B.x >= A.GetLeftBottom().x && B.x <= A.GetRightTop().x)
                    if (B.y >= A.GetLeftBottom().y && B.y <= A.GetRightTop().y)
                        return true;
                return false;
            }
            int number = 0;
            foreach (var i in this._map)
            {
                if (inside(i, user))
                    break;
                else
                    number++;
            }

            int centerCell_x = number / this._map.GetLength(0);
            int centerCell_y = number % this._map.GetLength(0);
            //only adds new user without check if user already exist
            this._map[centerCell_x, centerCell_y].Add(user);
        }
    }
}
