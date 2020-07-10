using BadoonBotLogic_2._0_.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadoonBotLogic_2._0_.objects.Grid;
using BadoonBotLogic_2._0_.objects;
namespace BadoonBotLogic_2._0_
{
    class Thread1
    {


        static void Main()
        {
            Point rt = new Point(100, 100);
            Point lb = new Point(0, 0);
            GridMap map = new GridMap(2, rt, lb);
            //Console.WriteLine(map.ToString());
            map.FindAtRadius();
            map.MatrixDispl();
            Console.ReadLine();
        }


    }
}
