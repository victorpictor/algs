using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Client.Threading
{
    public class Store
    {
        private Semaphore semaphore = new Semaphore(0,5);
        private readonly List<int> inTheStore = new List<int>();
        private static object o = new object();

        public void Enter()
        {
            Console.WriteLine("Entered the store {0}", Thread.CurrentThread.ManagedThreadId);
            semaphore.WaitOne();
            lock (o)
            {
                inTheStore.Add(Thread.CurrentThread.ManagedThreadId);
            }
        }

        public void Leave()
        {
            lock (o)
            {
                Console.WriteLine("in the store {0}", string.Join(",", inTheStore));
                
                if (inTheStore.Any())
                    inTheStore.RemoveAt(0);

                Console.WriteLine("one left {0}", string.Join(",", inTheStore));
            }

            semaphore.Release();
        }

    }
}