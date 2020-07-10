using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadoonBotLogic_2._0_.objects.Grid
{
    public partial class GridMap
    {
        partial void _findAtRadius(double radius,Point center)
        {
            bool inside(GridCell A, Point B)
            {
                if (B.x >= A.GetLeftBottom().x && B.x <= A.GetRightTop().x)
                    if (B.y >= A.GetLeftBottom().y && B.y <= A.GetRightTop().y)
                        return true;
                return false;
            }
            bool ableToScan(GridCell A, Point B)
            {
                if(     Math.Abs(A.GetLeftBottom().x - B.x) < radius
                          &&
                        Math.Abs(A.GetRightTop().x - B.x) < radius)
                    if (    Math.Abs(A.GetLeftBottom().y - B.y) < radius
                             &&
                            Math.Abs(A.GetRightTop().y - B.y) < radius)
                        return true;
                return false;
            }
            //find cell of center
            int number = 0;
            foreach (var i in this._map)
            {
                if (inside(i, center))
                    break;
                else
                    number++;
            }
            
            int centerCell_x = number / this._map.GetLength(0);
            int centerCell_y = number % this._map.GetLength(0);
            
            

            Console.WriteLine($"Center: {centerCell_x};{centerCell_y}");
        }
    }
}
