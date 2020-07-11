using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadoonBotLogic_2._0_.objects.Grid
{
    public partial class GridMap
    {

        Point _rt;
        Point _lb;
        
        GridCell[,] _map;
        partial void _findAtRadius(double radius,Point center);
        partial void _add(Point user);
        partial void _remove(Point user);
        public void FindAtRadius()
        {
            _findAtRadius(6, new Point(49,49));
        }
        public void Remove(Point user)
        {
            _remove(user);
        }
        public void Add(Person user)
        {
            _add(user);
        }
        public void Add(Point user)
        {
            _add(user);
        }
        public GridMap(int Resolution, Point RightTop,Point LeftBottom)
        {
            if(Resolution <= 0)
            {
                throw new Exception("Incorrect Resolution( <= 0 )");
            }
            this._rt = RightTop;
            this._lb = LeftBottom;
            this._map = new GridCell[Resolution, Resolution];

            double CellLen = (this._rt.x - this._lb.x)/Resolution;
            double CellHei = (this._rt.y - this._lb.y) / Resolution;
            
            
            for(int i = 0;i < Resolution; i++)
            {
                for(int k = 0;k < Resolution; k++)
                {
                    
                    this._map[i, k] = new GridCell(
                        RightTop: new Point(
                            _lb.x + (CellLen * (k + 1)), 
                            _lb.y + (CellHei * (i + 1))
                            ),
                        LeftBottom: new Point(
                            _lb.x + (CellLen * k),
                            _lb.y + (CellHei * i)
                            )
                        );
                    
                }
            }
        }
        public string ToString()
        {
            string res = "";
            //Parameters
            res += "[";
            res += $"RT:{_rt.ToString()},LB:{_lb.ToString()},Res:{_map.GetLength(0)}";
            res += "]";
            //Cells
            res += "[";
            foreach (var i in this._map)
                res += $"{i.ToString()},";
            res += "]";



            return res;
        }
        public void MatrixDispl()
        {
            //      
            // ^y
            // |  
            // | - - ->x
            if (_map.Length < 1)
                throw new Exception("map is empty!");
            var mapLen = this._map.GetLength(0);
            var mapHei = this._map.GetLength(1);
            
            for(int i = mapHei - 1;i >= 0; i--)
            {
                for(int k = 0;k < mapLen; k++)
                {
                    Console.Write(this._map[i, k].ToString());
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
                
            
        }
    }
}
