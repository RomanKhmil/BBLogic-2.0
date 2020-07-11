using BadoonBotLogic_2._0_.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadoonBotLogic_2._0_.objects.Grid;
using BadoonBotLogic_2._0_.objects;
using System.Threading;

namespace BadoonBotLogic_2._0_
{
    class Thread1
    {
        static Point rt;
        static Point lb;
        static GridMap map;
        static Mutex myMutex;
        static void append(ref GridMap A)
        {
            for(int i = 0;i < 100; i++)
            {
                A.Add(new Point(i, i));
            }
        }
        static void Main()
        {
            rt = new Point(100, 100);
            lb = new Point(0, 0);
            map = new GridMap(2, rt, lb);
            myMutex = new Mutex();
            AddingAsync();
            SearchingAsync();
            RemovingAsync();
            //Console.WriteLine(map.ToString());
            
            map.MatrixDispl();
            Console.ReadLine();
        }

        static async void AddingAsync()
        {
            await Task.Run(() => {
                while (true)
                {
                    //myMutex.WaitOne();
                    append(ref map);
                    //myMutex.ReleaseMutex();
                    Thread.Sleep(1000);
                }
                
            });
        }
        static async void RemovingAsync()
        {
            await Task.Run(() => {
            while (true)
            {
                    //myMutex.WaitOne();
                map.Remove(new Point(49, 49));
                    //myMutex.ReleaseMutex();
                    Thread.Sleep(500);
            }
                
            });
        }
        static async void SearchingAsync()
        {
            await Task.Run(() => {
            while (true)
                map.FindAtRadius();
                Thread.Sleep(500);
            });
        }
    }
}
