using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ParallelWorld.Domain.Models
{
    public class ThreadModel
    {
        public string ThreadMaster(string s)
        {
            

            var t1 = new Thread(()=> 
            {
                Writer('A', 1000);
            });

            var t2 = new Thread(() => 
            {
                Writer('B', 1000);
            });

            Console.WriteLine(s);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            //Thread.Sleep(5000);
            return s;
        }

        private void Writer(char c, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(c);
            }
        }
    }
}
