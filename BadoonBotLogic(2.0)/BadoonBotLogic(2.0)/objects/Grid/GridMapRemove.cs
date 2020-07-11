using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadoonBotLogic_2._0_.objects.Grid
{
    public partial class GridMap
    {
        partial void _remove(Point user)
        {
            bool inside(GridCell A, Point B)
            {
                if (B.x >= A.GetLeftBottom().x && B.x <= A.GetRightTop().x)
                    if (B.y >= A.GetLeftBottom().y && B.y <= A.GetRightTop().y)
                        return true;
                return false;
            }
            foreach(var i in this._map)
            {
                if(inside(i, user))
                {
                    i.Remove(user);
                }
            }
        }
    }
}
