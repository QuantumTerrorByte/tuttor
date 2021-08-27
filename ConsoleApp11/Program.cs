using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Channels;
using ConsoleApp11.Mulltitraiding;
using Semaphore = System.Threading.Semaphore;

namespace ConsoleApp11
{
    class Program
    {
        public static int counter;

        //MAIN <<=========================================
        public static void Main(string[] args)
        {
            Action<int> action = new Action<int>(x => { Console.WriteLine(x + 20); });
            MySemaphore mySemaphore = new MySemaphore(20);
            for (int i = 0; i < 2000; i++)
            {
                mySemaphore.Run(action, 50);
            }
        }

        public static Action Combine(Action<Object> action, Object obj)
        {
            return new Action(() => action(obj));
        }

        public static void Test()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
            {
                result++;
            }

            Console.WriteLine($"{Interlocked.Increment(ref counter)}");
        }


        public static void InputPulse<T>(T synObj)
        {
            while (true)
            {
                if (synObj != null)
                    lock (synObj)
                    {
                        Console.WriteLine(NumbHolder.Counter);
                        Console.WriteLine("input");
                        Console.ReadLine();
                        Thread.Sleep(200);
                        Monitor.PulseAll(synObj);
                    }
            }
        }

        public static void InputWaitPulse()
        {
            List<Thread> list = new List<Thread>();
            List<NumbHolder> numbHolders = new List<NumbHolder>()
            {
                new NumbHolder() {Name = "First"},
                new NumbHolder() {Name = "Second"},
                new NumbHolder() {Name = "Third"},
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 10; j++)
                    list.Add(new Thread(numbHolders[i].Increment));
            }

            list.ForEach(x => x.Start());

            Thread.Sleep(1000);
            InputPulse(NumbHolder.SynObj);
        }
    }
}