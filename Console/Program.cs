using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Client.Threading;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var store = new Store();
            var ts = new List<Thread>();
            for (var i = 0; i < 10; i++)
            {
                var t = new Thread(store.Enter);
                ts.Add(t); 
                t.Start();
            }

            for (var i = 0; i < 10; i++)
            {
                var t = new Thread(store.Leave);
                ts.Add(t);
                t.Start();
            }

            ts.ForEach(t => t.Join());

            var mq = new MyQueue();
            var pts = new List<Task>();
            var cts = new List<Task>();
            for (int i = 0; i < 40; i++)
            {
                pts.Add(new Task(() =>
                {
                    for (int j = 0; j < 50; j++)
                    {
                        mq.Enqueue(j);
                    }
                }));

                if (i < 10)
                    cts.Add(new Task(() =>
                    {
                        while (true)
                        {
                             mq.Dequeue();
                        }
                    }));

            }

            pts.ForEach(p => p.Start());
            cts.ForEach(c => c.Start());


            pts.ForEach(p => p.Wait());
            cts.ForEach(c => c.Wait());
        }
    }
}
