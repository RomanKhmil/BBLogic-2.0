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
            bool ableForScan(GridCell A, Point B)
            {
                if(     Math.Abs(A.GetLeftBottom().x - B.x) < radius
                          ||
                        Math.Abs(A.GetRightTop().x - B.x) < radius)
                    if (    Math.Abs(A.GetLeftBottom().y - B.y) < radius
                             ||
                            Math.Abs(A.GetRightTop().y - B.y) < radius)
                        return true;
                return false;
            }
            //OnBorder
            // if 1 value is between 0 and maxvalue, if 0 value == 0, if 2 value == maxvalue
            int onBorder(int value, int maxvalue)
            {
                if (value != 0 && value < maxvalue)
                    
                    return 1;
                else
                {
                    if(value == 0)
                        return 0;
                    else
                        return 2;
                }
                    
            }
            void ableForMeet(GridCell A,Point B, ref List<Point> C)
            {
                if (!ableForScan(A, B))
                    return;
                List<Point> users = A.GetUsers();
                for(int i = 0;i < users.Count; i++)
                {
                    if(Point.Dist(users[i] as Point, B) <= radius)
                    {
                        C.Add(users[i]);
                        Console.WriteLine($"Point: {i.ToString()} Dist: {Point.Dist(users[i] as Point, B)}");
                    }
                }
                    
                
            }
            void displ(List<Point> A)
            {
                foreach (var i in A)
                    Console.WriteLine(i.ToString());
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
            List<Point> result = new List<Point>();
            //       |A| |A| |A|   A - ableForMeet()
            //       |A|  M  |A|   M - center
            //       |A| |A| |A|  only if onBorder == 1 for x and y
            int bordX = onBorder(centerCell_x, this._map.GetLength(1) - 1),
                bordY = onBorder(centerCell_y, this._map.GetLength(0) - 1);
            // || - able, X - !( || )
            ableForMeet(this._map[centerCell_x, centerCell_y],center,ref result);
            if (bordX == 1)
            {
                switch (bordY)
                {
                    case 0:
                        //  || || ||
                        //  X     X
                        //  X  X  X
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y + 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y + 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y + 1], center, ref result);
                        //  X  X  X
                        //  ||    ||
                        //  X  X  X
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 0], center, ref result);
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 0], center, ref result);
                        break;
                    case 1:

                        // X  X  X
                        // X     ||
                        // X  X  ||
                        
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 0], center, ref result);
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y + 1], center, ref result);
                        //  || || ||
                        //  X     X
                        //  X  X  X
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y + 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y + 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y + 1], center, ref result);
                        
                        // X  X  X
                        // ||    X
                        // || || X
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y - 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 0], center, ref result);
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 1], center, ref result);

                        break;
                    case 2:
                        //  X  X  X
                        //  X     X
                        //  || || ||
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y - 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 1], center, ref result);
                        //  X  X  X
                        //  ||    ||
                        //  X  X  X
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 0], center, ref result);
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 0], center, ref result);
                        break;
                    default:
                        break;
                }
            }
            if (bordX == 0)
            {
                switch (bordY)
                {
                    case 0:
                        //  X  X  X
                        //  X     X
                        //  X  || ||
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y + 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y + 1], center, ref result);
                        //  X  X  X
                        //  X    ||
                        //  X  X  X
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 0], center, ref result);
                        break;
                    case 1:
                        // X  X  ||
                        // X     ||
                        // X  X  X
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 1], center, ref result);
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 0], center, ref result);
                        //  X  X  X
                        //  X     X
                        //  X || ||
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y + 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y + 1], center, ref result);
                        // X  || X
                        // X     X
                        // X  X  X
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y - 1], center, ref result);
                        break;
                    case 2:
                        //  X || ||
                        //  X     X
                        //  X  X  X
                        
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y - 1], center, ref result);
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 1], center, ref result);
                        //  X  X  X
                        //  X    ||
                        //  X  X  X
                        ableForMeet(this._map[centerCell_x + 1, centerCell_y - 0], center, ref result);
                        break;
                    default:
                        break;
                }
            }
            if (bordX == 2)
            {
                switch (bordY)
                {
                    case 0:
                        //  X  X  X
                        //  X     X
                        //  || || X
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y + 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y + 1], center, ref result);
                        //  X  X  X
                        //  ||    X
                        //  X  X  X
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 0], center, ref result);
                        break;
                    case 1:
                        // || X  X
                        // ||    X
                        // X  X  X
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 0], center, ref result);
                        //  X  X  X
                        //  X     X
                        //  || || X
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y + 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y + 1], center, ref result);
                        // X  || X
                        // X     X
                        // X  X  X
                        ableForMeet(this._map[centerCell_x - 0, centerCell_y - 1], center, ref result);
                        break;
                    case 2:
                        //  || || X
                        //  X     X
                        //  X  X  X

                        ableForMeet(this._map[centerCell_x - 0, centerCell_y - 1], center, ref result);
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 1], center, ref result);
                        //  X  X  X
                        //  ||     X
                        //  X  X  X
                        ableForMeet(this._map[centerCell_x - 1, centerCell_y - 0], center, ref result);
                        break;
                    default:
                        break;
                }
            }
            displ(result);
            Console.WriteLine($"Center: {centerCell_x};{centerCell_y}");
        }
    }
}
