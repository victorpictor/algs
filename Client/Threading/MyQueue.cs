using System;
using System.Collections.Generic;
using System.Threading;

namespace Client.Threading
{
    public class MyQueue
    {
        private readonly Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        private static object  o = new object();

        private int Undef = int.MinValue;

        public void Enqueue(int item)
        {
            try
            {
                Monitor.TryEnter(o);

                if (Monitor.IsEntered(o))
                {
                    if (queue.Count == 40)
                    {
                        Console.WriteLine("producer {0} waiting", Thread.CurrentThread.ManagedThreadId);
                        Monitor.Wait(o);
                    }


                    queue.Enqueue(new Tuple<int, int>(Thread.CurrentThread.ManagedThreadId, item));

                    Console.WriteLine("producer {0} request {1}", Thread.CurrentThread.ManagedThreadId, item);
                    Monitor.PulseAll(o);
                }
                
            }
            finally
            {
                if(Monitor.IsEntered(o))
                    Monitor.Exit(o);
            }
        }

        public int Dequeue()
        {
            var result = Undef;
            try
            {
                Monitor.TryEnter(o);
                if (queue.Count == 0)
                    Monitor.Wait(o);

                var res = queue.Dequeue();
                result = res.Item2;
                Console.WriteLine("worker {0} request {1} {2}", Thread.CurrentThread.ManagedThreadId, res.Item1, res.Item2);
                Monitor.PulseAll(o);
            }
            finally
            {
                if (Monitor.IsEntered(o))
                    Monitor.Exit(o);
            }

            return result;
        }

    }
}